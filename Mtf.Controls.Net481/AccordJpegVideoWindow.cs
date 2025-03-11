using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Net481
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(AccordJpegVideoWindow), "Resources.VideoSource.png")]
    public partial class AccordJpegVideoWindow : PictureBox
    {
        private readonly AccordJpeg accordJpeg;

        public AccordJpegVideoWindow()
        {
            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;
            accordJpeg = new AccordJpeg(this);
        }

        /// <summary>
        /// Starts the stream.
        /// </summary>
        /// <param name="resource">Resource is an URI.</param>
        public void Start(string resource)
        {
            accordJpeg.Start(resource);
        }

        public void SetCredentials(string userName, string password)
        {
            accordJpeg?.SetCredentials(userName, password);
        }

        public void Stop()
        {
            accordJpeg.Stop();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                accordJpeg.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}