using Accord.Video;
using Mtf.Controls.Video.Legacy.Extensions;
using System;
using System.Windows.Forms;

namespace Mtf.Controls.Video.Legacy
{
    public abstract class Accord : BaseVideoPlayer
    {
        private readonly object sync = new object();
        private readonly PictureBox pictureBox;

        protected Accord(PictureBox pictureBox)
        {
            if (pictureBox == null)
            {
                throw new ArgumentNullException(nameof(pictureBox));
            }
            this.pictureBox = pictureBox;
        }

        protected void StartVideoSource(IVideoSource videoSource)
        {
            if (videoSource == null)
            {
                throw new ArgumentNullException(nameof(videoSource));
            }

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
                Stop(videoSource);
                pictureBox.InvokeAction(() =>
                {
                    pictureBox.ThreadSafeClearImage(sync);
                });
            }
        }
    }
}