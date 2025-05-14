using AForge.Video;
using AForge.Video.DirectShow;
using Mtf.Controls.Interfaces;
using Mtf.MessageBoxes;
using System;
using System.Windows.Forms;

namespace Mtf.Controls.Video.Legacy
{
    public class AForgeVideoCaptureDevice : AForge, IVideoPlayer
    {
        private VideoCaptureDevice videoSource;

        public AForgeVideoCaptureDevice(PictureBox pictureBox) : base(pictureBox)
        {
        }

        public void Start(string deviceMoniker)
        {
            videoSource = new VideoCaptureDevice(deviceMoniker);
            StartVideoSource(videoSource);
        }

        public void Stop()
        {
            StopVideoSource(videoSource);
        }

        protected override void Stop(IVideoSource videoSource)
        {
            try
            {
                videoSource?.SignalToStop();
                videoSource?.WaitForStop();
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
                throw;
            }
        }
    }
}
