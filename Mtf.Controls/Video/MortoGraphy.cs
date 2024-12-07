using Mtf.Controls.Extensions;
using Mtf.Controls.Interfaces;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mtf.Controls.Video
{
    /// <summary>
    /// Can show images from a JPEG stream
    /// </summary>
    public class MortoGraphy : BaseVideoPlayer, IVideoPlayer
    {
        private readonly object sync = new object();
        private readonly PictureBox pictureBox;
        private string url;
        private CancellationTokenSource cancellationTokenSource;

        public MortoGraphy(PictureBox pictureBox)
        {
            if (pictureBox == null)
            {
                throw new ArgumentNullException(nameof(pictureBox));
            }
            this.pictureBox = pictureBox;
        }

        public void Start(string url)
        {
            Stop();
            this.url = url;
            cancellationTokenSource = new CancellationTokenSource();
            _ = Task.Run(() =>
            {
                FrameReceiver(cancellationTokenSource.Token);
            });
        }

        public void Stop()
        {
            cancellationTokenSource?.Cancel();
        }

        protected override void DisposeManagedResources()
        {
            Stop();
        }

        private void FrameReceiver(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (url.EndsWith(".mjpg") || url.EndsWith(".mjpeg"))
                {
                    try
                    {
                        using (var wc = new WebClient())
                        {
                            using (var stream = wc.OpenRead(url))
                            {
                                if (stream == null)
                                {
                                    return;
                                }

                                var boundary = GetBoundary(stream);
                                //ReadToImage(stream);
                                if (String.IsNullOrEmpty(boundary))
                                {
                                    throw new InvalidOperationException("Failed to detect MJPEG boundary.");
                                }

                                var buffer = new MemoryStream();
                                var imageBuffer = new byte[100000];
                                //var imageBuffer = new byte[4096];
                                int bytesRead;

                                while (!cancellationToken.IsCancellationRequested && (bytesRead = stream.Read(imageBuffer, 0, imageBuffer.Length)) > 0)
                                {
                                    buffer.Write(imageBuffer, 0, bytesRead);
                                    var frame = ExtractFrame(buffer, boundary);
                                    if (frame != null)
                                    {
                                        pictureBox.InvokeAction(() =>
                                        {
                                            pictureBox.ThreadSafeSetImageWithCloning(frame, sync);
                                        });
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log or handle exception as needed
                    }
                }
                else
                {
                    var frame = GrabJpegFrame();
                    pictureBox.InvokeAction(() =>
                    {
                        pictureBox.ThreadSafeSetImageWithCloning(frame, sync);
                    });
                }
            }
        }

        private string GetBoundary(Stream stream)
        {
            var buffer = new byte[1024];
            var boundaryLine = string.Empty;

            while (stream.CanRead)
            {
                var bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0) break;

                boundaryLine += System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                var lines = boundaryLine.Split(new[] { "\r\n" }, StringSplitOptions.None);

                foreach (var line in lines)
                {
                    if (line.StartsWith("Content-Type: multipart/x-mixed-replace; boundary=", StringComparison.OrdinalIgnoreCase))
                    {
                        return line.Substring("Content-Type: multipart/x-mixed-replace; boundary=".Length).Trim();
                    }
                    else if (line.ToLower().Contains("boundary"))
                    {
                        return line;
                    }
                }
            }
            return null;
        }

        private void ReadToImage(Stream stream)
        {
            var buffer = new byte[1024];
            var boundaryLine = string.Empty;

            while (stream.CanRead)
            {
                var bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0) break;

                boundaryLine += System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                var lines = boundaryLine.Split(new[] { "\r\n" }, StringSplitOptions.None);

                foreach (var line in lines)
                {
                    if (String.IsNullOrEmpty(line))
                    {
                        return;
                    }
                }
            }
        }

        private Image ExtractFrame(MemoryStream buffer, string boundary)
        {
            var boundaryBytes = System.Text.Encoding.ASCII.GetBytes("--" + boundary);
            var startIdx = FindBoundary(buffer.GetBuffer(), 0, (int)buffer.Length, boundaryBytes);

            if (startIdx < 0) return null;

            var endIdx = FindBoundary(buffer.GetBuffer(), startIdx + boundaryBytes.Length, (int)buffer.Length, boundaryBytes);

            if (endIdx > 0)
            {
                // Extract JPEG data between boundaries
                buffer.Position = startIdx + boundaryBytes.Length;
                var length = endIdx - startIdx - boundaryBytes.Length;
                var jpegData = new byte[length];
                buffer.Read(jpegData, 0, length);

                // Create an Image from the JPEG data
                using (var ms = new MemoryStream(jpegData))
                {
                    return Image.FromStream(ms);
                }
            }

            // Clear the processed data from buffer
            buffer.Position = startIdx;
            buffer.SetLength(startIdx);

            return null;
        }

        private int FindBoundary(byte[] buffer, int start, int end, byte[] boundary)
        {
            for (int i = start; i <= end - boundary.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < boundary.Length; j++)
                {
                    if (buffer[i + j] != boundary[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match) return i;
            }
            return -1;
        }

        private Image GrabJpegFrame()
        {
            var imageArray = new byte[100000];
            var totalBytes = 0;

            if (url == null)
            {
                return null;
            }

            try
            {
                using (var wc = new WebClient())
                {
                    //if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
                    //{
                    //    wc.Credentials = new NetworkCredential(Username, Password);
                    //}

                    using (var stream = wc.OpenRead(url))
                    {
                        if (stream == null)
                        {
                            return null;
                        }

                        int readBytes;
                        while ((readBytes = stream.Read(imageArray, totalBytes, imageArray.Length - totalBytes)) > 0)
                        {
                            totalBytes += readBytes;
                        }

                        if (totalBytes == 0)
                        {
                            return null;
                        }

                        using (var ms = new MemoryStream(imageArray, 0, totalBytes))
                        {
                            return Image.FromStream(ms);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception if needed, e.g., Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
