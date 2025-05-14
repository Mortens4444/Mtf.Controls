using Accord.Video;
using Mtf.Controls.Interfaces;
using System.Windows.Forms;

namespace Mtf.Controls.Video.Legacy
{
    public class AccordMjpeg : Accord, IVideoPlayer
    {
        private MJPEGStream accordMjpegStream;

        public AccordMjpeg(PictureBox pictureBox) : base(pictureBox)
        {
        }

        public void Start(string resource)
        {
            accordMjpegStream = new MJPEGStream(resource);
            StartVideoSource(accordMjpegStream);
        }

        public void SetCredentials(string userName, string password)
        {
            accordMjpegStream.Login = userName;
            accordMjpegStream.Password = password;
        }

        public void Stop()
        {
            StopVideoSource(accordMjpegStream);
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
