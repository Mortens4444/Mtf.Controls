using Mtf.Controls.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Video.OpenCvSharp
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(OpenCvSharpVideoWindow), "Resources.VideoSource.png")]
    public class OpenCvSharpVideoWindow : PictureBox, IVideoWindow
    {
        private bool disposed;
        private readonly OpenCvSharpWrapper openCvSharpWrapper;

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

        public OpenCvSharpVideoWindow()
        {
            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;
            openCvSharpWrapper = new OpenCvSharpWrapper(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                openCvSharpWrapper.Dispose();
            }
            base.Dispose(disposing);
            disposed = true;
        }

        /// <summary>
        /// Starts the stream.
        /// </summary>
        /// <param name="resource">Resource is an URI or a filename.</param>
        public void Start(string resource)
        {
            openCvSharpWrapper.Start(resource);
        }

        public void Stop()
        {
            openCvSharpWrapper.Stop();
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
