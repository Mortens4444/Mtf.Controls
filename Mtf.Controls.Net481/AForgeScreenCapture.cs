using AForge.Video;
using Mtf.Controls.Net481.Interfaces;
using Mtf.MessageBoxes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Net481
{
    public class AForgeScreenCapture : AForge, IScreenCapture
    {
        private readonly Rectangle rectangle;
        private ScreenCaptureStream aForgeScreenCapture;

        public AForgeScreenCapture(PictureBox pictureBox, Rectangle rectangle) : base(pictureBox)
        {
            this.rectangle = rectangle;
        }

        public void Start()
        {
            aForgeScreenCapture = new ScreenCaptureStream(rectangle);
            StartVideoSource(aForgeScreenCapture);
        }

        public void Stop()
        {
            StopVideoSource(aForgeScreenCapture);
        }

        protected override void Stop(IVideoSource videoSource)
        {
            try
            {
                videoSource?.Stop();
                aForgeScreenCapture?.Stop();
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
                throw;
            }
            finally
            {
                aForgeScreenCapture = null;
            }
        }
    }
}
