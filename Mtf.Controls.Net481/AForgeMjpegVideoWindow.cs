using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Net481
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(AForgeMjpegVideoWindow), "Resources.VideoSource.png")]
    public partial class AForgeMjpegVideoWindow : PictureBox
    {
        private readonly AForgeMjpeg aForgeMjpeg;

        public AForgeMjpegVideoWindow()
        {
            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;
            aForgeMjpeg = new AForgeMjpeg(this);
        }

        /// <summary>
        /// Starts the stream.
        /// </summary>
        /// <param name="resource">Resource is an URI.</param>
        public void Start(string resource)
        {
            aForgeMjpeg.Start(resource);
        }

        public void SetCredentials(string userName, string password)
        {
            aForgeMjpeg?.SetCredentials(userName, password);
        }

        public void Stop()
        {
            aForgeMjpeg.Stop();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                aForgeMjpeg.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}