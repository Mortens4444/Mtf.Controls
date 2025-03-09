using Mtf.Controls.CustomEventArgs;
using Mtf.Controls.Enums;
using Mtf.Controls.Extensions;
using Mtf.Controls.Interfaces;
using Mtf.MessageBoxes;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mtf.Controls.Video
{
    /// <summary>
    /// Can show images from a JPEG stream
    /// </summary>
    public class MortoGraphy : BaseVideoPlayer, IVideoPlayer
    {
        private int total;
        private byte[] buffer = new byte[BufferSize];
        private readonly object sync = new object();
        private readonly MortoGraphyWindow mortoGraphyWindow;
        private string url;
        private string username;
        private string password;
        private CancellationTokenSource cancellationTokenSource;
        private const int BufferSize = 512 * 1024;  // buffer size
        public event FrameArrivedEventHandler FrameArrived;
        public delegate void FrameArrivedEventHandler(object sender, FrameArrivedEventArgs e);

        public MortoGraphy(MortoGraphyWindow mortoGraphyWindow, string username, string password)
        {
            if (mortoGraphyWindow == null)
            {
                throw new ArgumentNullException(nameof(mortoGraphyWindow));
            }
            this.mortoGraphyWindow = mortoGraphyWindow;
            this.username = username;
            this.password = password;
            FrameArrived += MortoGraphy_FrameArrived;
        }

        private void MortoGraphy_FrameArrived(object sender, FrameArrivedEventArgs e)
        {
            mortoGraphyWindow.InvokeAction(() =>
            {
                mortoGraphyWindow.ThreadSafeSetImageWithCloning(e.Frame, sync);
            });
        }

        public void Start(string url)
        {
            Stop();
            this.url = url;
            cancellationTokenSource = new CancellationTokenSource();
            _ = Task.Run(async () =>
            {
                await FrameReceiver(cancellationTokenSource.Token);
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

        private async Task FrameReceiver(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (mortoGraphyWindow.StreamType == StreamType.Mjpeg)
                {
                    await GrabMjpegFrameAsync(cancellationToken);
                }
                else
                {
                    var frame = await GrabJpegFrameAsync();
                    mortoGraphyWindow.InvokeAction(() =>
                    {
                        mortoGraphyWindow.ThreadSafeSetImageWithCloning(frame, sync);
                    });
                }
            }
            mortoGraphyWindow.ThreadSafeClearImage(sync);
        }

        private async Task GrabMjpegFrameAsync(CancellationToken cancellationToken)
        {
            try
            {
                if (String.IsNullOrEmpty(url))
                {
                    return;
                }

                using (var handler = new HttpClientHandler { Credentials = new NetworkCredential(username, password) })
                using (var httpClient = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(30) })
                {
                    //using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                    {
                        //request.Content = new StringContent(String.Empty);
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/x-mixed-replace"));
                        //httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("MortoGraphy/1.0");

                        //if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
                        //{
                        //    var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                        //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                        //    //request.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                        //}

                        //var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
                        var response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

                        if (!response.IsSuccessStatusCode || !response.Content.Headers.ContentType?.MediaType.Contains("multipart/x-mixed-replace") == true)
                        {
                            return;
                        }

                        var boundary = response.Content.Headers.ContentType.Parameters.FirstOrDefault(p => p.Name == "boundary")?.Value;
                        if (String.IsNullOrEmpty(boundary))
                        {
                            throw new ApplicationException("Invalid MJPEG stream: Missing boundary");
                        }

                        if (!boundary.StartsWith("--"))
                        {
                            boundary = "--" + boundary;
                        }

                        var boundaryBytes = Encoding.ASCII.GetBytes(boundary);

                        using (var stream = await response.Content.ReadAsStreamAsync())
                        {
                            //var buffer = new byte[BufferSize];
                            total = 0;

                            while (!cancellationToken.IsCancellationRequested)
                            {
                                var read = await stream.ReadAsync(buffer, total, BufferSize - total, cancellationToken);

                                if (read == 0)
                                {
                                    throw new ApplicationException("Stream closed unexpectedly");
                                }

                                total += read;

                                var start = FindSequence(buffer, boundaryBytes, 0, total);

                                if (start != -1)
                                {
                                    var end = FindSequence(buffer, boundaryBytes, start + boundaryBytes.Length, total - (start + boundaryBytes.Length));

                                    if (end != -1)
                                    {
                                        var imageStart = start + boundaryBytes.Length;
                                        while (buffer[imageStart] != 0xFF && buffer[imageStart + 1] != 0xD8)
                                        {
                                            imageStart++;
                                        }
                                        var imageEnd = end;

                                        using (var ms = new MemoryStream(buffer, imageStart, imageEnd - imageStart))
                                        {
                                            var frame = Image.FromStream(ms);
                                            FrameArrived?.Invoke(this, new FrameArrivedEventArgs(frame));
                                            Array.Copy(buffer, end, buffer, 0, total - end);
                                            total -= end;
                                            //return frame;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
                throw;
            }
            return;
        }

        private static int FindSequence(byte[] buffer, byte[] sequence, int offset, int count)
        {
            for (var i = offset; i <= count - sequence.Length; i++)
            {
                var match = true;
                for (var j = 0; j < sequence.Length; j++)
                {
                    if (buffer[i + j] != sequence[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    return i;
                }
            }
            return -1;
        }

        private async Task<Image> GrabJpegFrameAsync()
        {
            if (url == null)
            {
                return null;
            }

            try
            {
                using (var httpClient = new HttpClient())
                {
                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {
                        var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                    }

                    var response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);

                    if (!response.IsSuccessStatusCode)
                    {
                        return null;
                    }

                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        return await GetImageFromStream(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
                throw;
            }
        }

        private static async Task<Image> GetImageFromStream(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                if (memoryStream.Length == 0)
                {
                    return null;
                }

                memoryStream.Position = 0;
                return Image.FromStream(memoryStream);
            }
        }
    }
}
