using AForge.Video;
using Mtf.Controls.Interfaces;
using System.Windows.Forms;

namespace Mtf.Controls.Video.Legacy
{
    public class AForgeJpeg : AForge, IVideoPlayer
    {
        private JPEGStream aForgeJpegStream;

        public AForgeJpeg(PictureBox pictureBox) : base(pictureBox)
        {
        }

        public void Start(string resource)
        {
            aForgeJpegStream = new JPEGStream(resource);
            StartVideoSource(aForgeJpegStream);
        }

        public void SetCredentials(string userName, string password)
        {
            aForgeJpegStream.Login = userName;
            aForgeJpegStream.Password = password;
        }

        public void Stop()
        {
            StopVideoSource(aForgeJpegStream);
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
