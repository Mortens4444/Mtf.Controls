using AForge.Video;
using Mtf.Controls.Interfaces;
using System.Windows.Forms;

namespace Mtf.Controls.Video.Legacy
{
    public class AForgeMjpeg : AForge, IVideoPlayer
    {
        private MJPEGStream aForgeMjpegStream;

        public AForgeMjpeg(PictureBox pictureBox) : base(pictureBox)
        {
        }

        public void Start(string resource)
        {
            aForgeMjpegStream = new MJPEGStream(resource);
            StartVideoSource(aForgeMjpegStream);
        }

        public void SetCredentials(string userName, string password)
        {
            aForgeMjpegStream.Login = userName;
            aForgeMjpegStream.Password = password;
        }

        public void Stop()
        {
            StopVideoSource(aForgeMjpegStream);
        }

        protected override void Stop(IVideoSource videoSource)
        {
            if (videoSource != null)
            {
                videoSource.SignalToStop();
                videoSource.Stop();
                videoSource.WaitForStop();
            }
        }
    }
}
