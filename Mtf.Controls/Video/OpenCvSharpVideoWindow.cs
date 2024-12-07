using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Video
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(OpenCvSharpVideoWindow), "Resources.VideoSource.png")]
    public class OpenCvSharpVideoWindow : PictureBox
    {
        private bool disposed;
        private readonly OpenCvSharpWrapper openCvSharpWrapper;

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
    }
}
