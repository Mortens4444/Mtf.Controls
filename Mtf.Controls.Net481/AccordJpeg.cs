using Accord.Video;
using Mtf.Controls.Net481.Interfaces;
using System.Windows.Forms;

namespace Mtf.Controls.Net481
{
    public class AccordJpeg : Accord, IVideoPlayer
    {
        private JPEGStream accordJpegStream;

        public AccordJpeg(PictureBox pictureBox) : base(pictureBox)
        {
        }

        public void Start(string resource)
        {
            accordJpegStream = new JPEGStream(resource);
            StartVideoSource(accordJpegStream);
        }

        public void SetCredentials(string userName, string password)
        {
            accordJpegStream.Login = userName;
            accordJpegStream.Password = password;
        }

        public void Stop()
        {
            StopVideoSource(accordJpegStream);
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
