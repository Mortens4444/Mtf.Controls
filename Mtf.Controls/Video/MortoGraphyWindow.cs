using Mtf.Controls.Enums;
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
        private readonly MortoGraphy mortoGraphy;

        public MortoGraphyWindow()
        {
            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;
            mortoGraphy = new MortoGraphy(this, Username, Password);
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("StreamType.")]
        public StreamType StreamType { get; set; } = StreamType.Mjpeg;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Username.")]
        public string Username { get; set; }


        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Password.")]
        public string Password { get; set; }

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
    }
}
