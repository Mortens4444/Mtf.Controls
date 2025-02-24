using Mtf.Controls.Extensions;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mtf.Controls.Video
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(OpenCvSharp4VideoWindow), "Resources.VideoSource.png")]
    public class OpenCvSharp4VideoWindow : PictureBox
    {
        private CancellationTokenSource cancellationTokenSource;
        private Task videoTask;

        public OpenCvSharp4VideoWindow()
        {
            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /// <summary>
        /// Starts the stream.
        /// </summary>
        /// <param name="resource">Resource is an URI or a filename.</param>
        public void Start(string resource)
        {
            Stop();

            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            videoTask = Task.Run(() =>
            {
                try
                {
                    using (var capture = new VideoCapture(resource))
                    {
                        capture.Set(VideoCaptureProperties.BufferSize, 0);
                        capture.Set(VideoCaptureProperties.Fps, 60);
                        //capture.Set(VideoCaptureProperties.RtspTransport, (double)VideoCaptureAPIs.ANY);
                        capture.Set(VideoCaptureProperties.HwAcceleration, (double)VideoCaptureAPIs.ANY);

                        if (!capture.IsOpened())
                        {
                            return;
                        }

                        using (var frame = new Mat())
                        {
                            while (!token.IsCancellationRequested && capture.Read(frame) && !frame.Empty())
                            {
                                var bitmap = frame.ToBitmap();

                                if (!token.IsCancellationRequested)
                                {
                                    this.InvokeAction(() =>
                                    {
                                        this.SetImage(bitmap);
                                    });
                                }

                                Thread.Sleep(1);
                            }
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                }
            }, token);
        }

        public void Stop()
        {
            cancellationTokenSource?.Cancel();

            try
            {
                videoTask?.Wait();
            }
            catch (AggregateException)
            {
            }

            cancellationTokenSource?.Dispose();
            cancellationTokenSource = null;

            this.InvokeAction(() => { this.SetImage(null); });
        }
    }
}
