using Mtf.Controls.Enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Video
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MortoGraphyWindow), "Resources.VideoSource.png")]
    public class MortoGraphyWindow : PictureBox
    {
        private bool disposed;
        private string username;
        private MortoGraphy mortoGraphy;
        private string password;
        private int bufferSize = 409600;

        public MortoGraphyWindow()
        {
            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;
            mortoGraphy = new MortoGraphy(this, Username, Password) { BufferSize = bufferSize };
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("StreamType.")]
        public StreamType StreamType { get; set; } = StreamType.Mjpeg;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Username.")]
        public string Username
        {
            get => username;
            set
            {
                username = value;
                mortoGraphy = new MortoGraphy(this, Username, Password) { BufferSize = bufferSize };
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Password.")]
        public string Password
        {
            get => password;
            set
            {
                password = value;
                mortoGraphy = new MortoGraphy(this, Username, Password) { BufferSize = bufferSize };
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Size of the VideoCaptureClient buffers when MortoGraphy is used with an endpoint.")]
        public int BufferSize
        {
            get => bufferSize;
            set
            {
                bufferSize = value;
                mortoGraphy = new MortoGraphy(this, Username, Password) { BufferSize = bufferSize };
            }
        }

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

        /// <summary>
        /// Starts the stream.
        /// </summary>
        /// <param name="resource">Resource is an URI.</param>
        public void Start(string resource)
        {
            mortoGraphy.Start(resource);
        }

        public void Stop()
        {
            mortoGraphy.Stop();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                mortoGraphy.Dispose();
            }
            base.Dispose(disposing);
            disposed = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
                if (!String.IsNullOrEmpty(OverlayText))
                {
                    var graphics = e.Graphics;
                    //_ = graphics.MeasureString(OverlayText, OverlayFont);
                    graphics.DrawString(OverlayText, OverlayFont, OverlayBrush, OverlayLocation);
                }
            }
            catch (Exception _)
            {
            }
        }
    }
}
