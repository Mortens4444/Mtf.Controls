using Mtf.Controls.Extensions;
using Mtf.Controls.Interfaces;
using Mtf.MessageBoxes;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mtf.Controls.Video
{
    public class OpenCvSharpWrapper : BaseVideoPlayer, IVideoPlayer
    {
        private readonly object sync = new object();
        private readonly PictureBox pictureBox;
        private VideoCapture videoCapture;
        private CancellationTokenSource cancellationTokenSource;

        public OpenCvSharpWrapper(PictureBox pictureBox) : base()
        {
            this.pictureBox = pictureBox;
        }

        public void Start(string url)
        {
            _ = StartAsync(url);
        }

        public async Task StartAsync(string url)
        {
            await Task.Run(() =>
            {
                Stop();
                videoCapture = new VideoCapture(url);
            }).ContinueWith(async (t) =>
            {
                await Task.Run(() =>
                {
                    if (videoCapture.IsOpened())
                    {
                        try
                        {
                            var frame = new Mat();
                            cancellationTokenSource = new CancellationTokenSource();
                            while (!cancellationTokenSource.Token.IsCancellationRequested)
                            {
                                lock (sync)
                                {
                                    if (videoCapture.IsDisposed)
                                    {
                                        break;
                                    }

                                    videoCapture.Read(frame);
                                }

                                if (!frame.Empty())
                                {
                                    try
                                    {
                                        var bitmap = BitmapConverter.ToBitmap(frame);
                                        pictureBox.InvokeAction(() =>
                                        {
                                            pictureBox.ThreadSafeSetImageWithCloning(bitmap, sync);
                                        });
                                    }
                                    catch (ObjectDisposedException)
                                    {
                                        Stop();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            DebugErrorBox.Show(ex);
                        }
                    }
                    else
                    {
                        Stop();
                    }
                }).ContinueWith((t2) =>
                {
                    try
                    {
                        pictureBox.InvokeAction(() =>
                        {
                            pictureBox.ThreadSafeClearImage(sync);
                        });
                    }
                    catch (Exception ex)
                    {
                        DebugErrorBox.Show(ex);
                    }
                });
            });
        }

        public void Stop()
        {
            cancellationTokenSource?.Cancel();
            lock (sync)
            {
                videoCapture?.Dispose();
            }
        }

        protected override void DisposeManagedResources()
        {
            pictureBox.Dispose();
            cancellationTokenSource?.Dispose();
            videoCapture?.Dispose();
        }
    }
}
