using Mtf.Controls.Extensions;
using Mtf.Controls.Interfaces;
using Mtf.MessageBoxes;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mtf.Controls.Video.OpenCvSharp
{
    public class OpenCvSharpWrapper : BaseVideoPlayer, IVideoPlayer
    {
        private readonly object sync = new object();
        private readonly PictureBox pictureBox;
        private VideoCapture videoCapture;
        private CancellationTokenSource cancellationTokenSource;

        //static OpenCvSharpWrapper()
        //{
        //    //NativeMethods.TryPInvoke = true;
        //    NativeMethods.LoadLibraries(new[] { "opencv_world480.dll" });
        //}

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
                if (videoCapture.IsOpened())
                {
                    videoCapture.Set(VideoCaptureProperties.BufferSize, 0);
                    videoCapture.Set(VideoCaptureProperties.Fps, 60);
                    //videoCapture.Set(VideoCaptureProperties.RtspTransport, (double)VideoCaptureAPIs.ANY);
                    videoCapture.Set(VideoCaptureProperties.HwAcceleration, (double)VideoCaptureAPIs.ANY);

                    try
                    {
                        using (var frame = new Mat())
                        {
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
                    }
                    catch (Exception ex)
                    {
                        DebugErrorBox.Show(ex);
                        throw;
                    }
                }
                else
                {
                    Stop();
                }

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
                    throw;
                }
            }).ConfigureAwait(false);
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
            cancellationTokenSource?.Dispose();
            videoCapture?.Dispose();
        }
    }
}
