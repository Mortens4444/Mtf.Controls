using Mtf.Controls.Enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Video.FFmpeg
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(FFmpegWindow), "Resources.VideoSource.png")]
    public class FFmpegWindow : PictureBox
    {
        private bool disposed;
        private readonly FFmpeg fFmpeg;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("FFMPEG Codec.")]
        public Codec Codec { get; set; } = Codec.mjpeg;

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
        public Point OverlayLocation { get; set; } = new Point(10, 10);

        public FFmpegWindow()
        {
            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;
            fFmpeg = new FFmpeg(this, Codec);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                fFmpeg.Dispose();
            }
            base.Dispose(disposing);
            disposed = true;
        }

        /// <summary>
        /// Starts the stream.
        /// </summary>
        /// <param name="resource">Resource is an URI.</param>
        public void Start(string resource)
        {
            fFmpeg.Start(resource);
        }

        public void Stop()
        {
            fFmpeg.Stop();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!String.IsNullOrEmpty(OverlayText))
            {
                var graphics = e.Graphics;
                //_ = graphics.MeasureString(OverlayText, OverlayFont);
                graphics.DrawString(OverlayText, OverlayFont, OverlayBrush, OverlayLocation);
            }
        }
    }
}
