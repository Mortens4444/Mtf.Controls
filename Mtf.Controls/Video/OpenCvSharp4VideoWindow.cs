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

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Text to be displayed on the control.")]
        public string OverlayText { get; set; } = String.Empty;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Font type of the text to be displayed on the control.")]
        public Font OverlayFont { get; set; } = new Font("Arial", 32, FontStyle.Bold);

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color of the text to be displayed on the control.")]
        public Brush OverlayBrush { get; set; } = Brushes.White;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Location of the text to be displayed on the control.")]
        public System.Drawing.Point OverlayLocation { get; set; } = new System.Drawing.Point(10, 10);

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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!String.IsNullOrEmpty(OverlayText))
            {
                var graphics = e.Graphics;
                _ = graphics.MeasureString(OverlayText, OverlayFont);
                graphics.DrawString(OverlayText, OverlayFont, OverlayBrush, OverlayLocation);
            }
        }
    }
}
