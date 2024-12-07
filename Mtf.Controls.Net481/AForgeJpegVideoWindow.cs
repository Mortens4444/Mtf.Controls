using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Net481
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(AForgeJpegVideoWindow), "Resources.VideoSource.png")]
    public partial class AForgeJpegVideoWindow : PictureBox
    {
        private AForgeJpeg aForgeJpeg;

        public AForgeJpegVideoWindow()
        {
            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;
            aForgeJpeg = new AForgeJpeg(this);
        }

        /// <summary>
        /// Starts the stream.
        /// </summary>
        /// <param name="resource">Resource is an URI.</param>
        public void Start(string resource)
        {
            aForgeJpeg.Start(resource);
        }

        public void SetCredentials(string userName, string password)
        {
            aForgeJpeg?.SetCredentials(userName, password);
        }

        public void Stop()
        {
            aForgeJpeg.Stop();
        }
    }
}