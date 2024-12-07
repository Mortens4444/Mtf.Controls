using Accord.Video;
using Mtf.Controls.Net481.Interfaces;
using Mtf.MessageBoxes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Net481
{
    public class AccordScreenCapture : Accord, IScreenCapture
    {
        private readonly Rectangle rectangle;
        private ScreenCaptureStream accordScreenCapture;

        public AccordScreenCapture(PictureBox pictureBox, Rectangle rectangle) : base(pictureBox)
        {
            this.rectangle = rectangle;
        }

        public void Start()
        {
            accordScreenCapture = new ScreenCaptureStream(rectangle);
            StartVideoSource(accordScreenCapture);
        }

        public void Stop()
        {
            StopVideoSource(accordScreenCapture);
        }

        protected override void Stop(IVideoSource videoSource)
        {
            try
            {
                videoSource?.Stop();
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }
    }
}
