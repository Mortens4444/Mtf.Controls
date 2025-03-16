using Mtf.Controls.CustomEventArgs;
using Mtf.Controls.Enums;
using Mtf.Controls.Extensions;
using Mtf.Controls.Interfaces;
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
        private static HttpClientHandler handler;
        private static HttpClient httpClient;

        private const int BufferSize = 512 * 1024;  // buffer size

        private readonly byte[] buffer = new byte[BufferSize];
        private readonly object sync = new object();
        private readonly MortoGraphyWindow mortoGraphyWindow;

        private string username;
        private string password;
        private int total;
        private string url;
        private CancellationTokenSource cancellationTokenSource;

        public event FrameArrivedEventHandler FrameArrived;
        public delegate void FrameArrivedEventHandler(object sender, FrameArrivedEventArgs e);

        public MortoGraphy(MortoGraphyWindow mortoGraphyWindow, string username, string password, long timeoutInSeconds = 5)
        {
            if (mortoGraphyWindow == null)
            {
                throw new ArgumentNullException(nameof(mortoGraphyWindow));
            }
            this.mortoGraphyWindow = mortoGraphyWindow;
            this.username = username;
            this.password = password;
            FrameArrived += MortoGraphy_FrameArrived;

            handler = new HttpClientHandler() { Credentials = new NetworkCredential(username, password) };
            httpClient = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(timeoutInSeconds) };
        }

        private void MortoGraphy_FrameArrived(object sender, FrameArrivedEventArgs e)
        {
            mortoGraphyWindow.InvokeAction(() =>
            {
                mortoGraphyWindow.ThreadSafeSetImageWithCloning(e.Frame, sync);
                e.Frame.Dispose();
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
            handler?.Dispose();
            httpClient?.Dispose();
            cancellationTokenSource?.Dispose();
        }

        private async Task FrameReceiver(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
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
                catch
                {
                    mortoGraphyWindow.ThreadSafeSetImageWithCloning(Properties.Resources.NoSignal, sync);
                    _ = Task.Delay(10, cancellationToken);
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

                //using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    //request.Content = new StringContent(String.Empty);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/x-mixed-replace"));
                    //httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("MortoGraphy/1.0");

                    var uri = new Uri(url);
                    if (!String.IsNullOrEmpty(uri.UserInfo))
                    {
                        username = uri.UserInfo.Split(':')[0];
                        password = uri.UserInfo.Split(':')[1];
                        url = $"{uri.Scheme}://{uri.Host}{uri.PathAndQuery}";
                    }

                    if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
                    {
                        var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                        //request.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                    }

                    //var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
                    var response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

                    if (!response.IsSuccessStatusCode || !response.Content.Headers.ContentType?.MediaType.Contains("multipart/x-mixed-replace") == true)
                    {
                        throw new ApplicationException($"Invalid response received: {response}.");
                    }

                    var boundary = response.Content.Headers.ContentType.Parameters.FirstOrDefault(p => p.Name == "boundary")?.Value;
                    if (String.IsNullOrEmpty(boundary))
                    {
                        throw new ApplicationException("Invalid MJPEG stream: Missing boundary.");
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
                            //var readTask = await stream.ReadAsync(buffer.AsMemory(total, BufferSize - total), cancellationToken);
                            var readTask = stream.ReadAsync(buffer, total, BufferSize - total, cancellationToken);
                            var timeoutTask = Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
                            var completedTask = await Task.WhenAny(readTask, timeoutTask);
                            if (completedTask == timeoutTask)
                            {
                                throw new TimeoutException("Stream is not responding.");
                            }

                            var read = await readTask;
                            if (read == 0)
                            {
                                throw new ApplicationException("Stream closed unexpectedly.");
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
                                        using (var frame = Image.FromStream(ms))
                                        {
                                            FrameArrived?.Invoke(this, new FrameArrivedEventArgs((Image)frame.Clone()));
                                        }
                                    }

                                    Array.Copy(buffer, end, buffer, 0, total - end);
                                    total -= end;
                                }
                            }
                        }
                    }
                }

                return;
            }
            catch (Exception ex)
            {
                throw;
            }
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Stop();
            }
            base.Dispose(disposing);
        }
    }
}
