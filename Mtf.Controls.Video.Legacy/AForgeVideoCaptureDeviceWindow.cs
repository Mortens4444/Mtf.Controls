using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Video.Legacy
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(AForgeVideoCaptureDeviceWindow), "Resources.VideoSource.png")]
    public partial class AForgeVideoCaptureDeviceWindow : PictureBox
    {
        private readonly AForgeVideoCaptureDevice aForgeVideoCaptureDevice;

        public AForgeVideoCaptureDeviceWindow()
        {
            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;
            aForgeVideoCaptureDevice = new AForgeVideoCaptureDevice(this);
        }

        /// <summary>
        /// Starts the stream.
        /// </summary>
        /// <param name="resource">Resource is a moniker string.</param>
        public void Start(string resource)
        {
            aForgeVideoCaptureDevice.Start(resource);
        }

        public void Stop()
        {
            aForgeVideoCaptureDevice.Stop();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                aForgeVideoCaptureDevice.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}