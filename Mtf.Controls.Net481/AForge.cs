using AForge.Video;
using Mtf.Controls.Net481.Extensions;
using System.Threading;
using System.Windows.Forms;

namespace Mtf.Controls.Net481
{
    public abstract class AForge : BaseVideoPlayer
    {
        private readonly object sync = new object();
        private readonly PictureBox pictureBox;

        protected AForge(PictureBox pictureBox) : base()
        {
            this.pictureBox = pictureBox;
        }

        protected void StartVideoSource(IVideoSource videoSource)
        {
            videoSource.NewFrame += VideoSource_NewFrame;
            videoSource.Start();
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox.InvokeAction(() =>
            {
                pictureBox.ThreadSafeSetImageWithCloning(eventArgs.Frame, sync);
            });
        }

        protected abstract void Stop(IVideoSource videoSource);

        protected void StopVideoSource(IVideoSource videoSource)
        {
            if (videoSource?.IsRunning ?? false)
            {
                videoSource.NewFrame -= VideoSource_NewFrame;
                pictureBox.InvokeAction(() =>
                {
                    pictureBox.ThreadSafeClearImage(sync);
                });
                Stop(videoSource);
            }
        }
    }
}
