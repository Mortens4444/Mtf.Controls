using LibVLCSharp.WinForms;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Video
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(VlcWindow), "Resources.VideoSource.png")]
    public class VlcWindow : VideoView
    {
        private bool disposed;
        private readonly Vlc openCvSharpWrapper;

        public VlcWindow()
        {
            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            openCvSharpWrapper = new Vlc(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                openCvSharpWrapper.Dispose();
            }
            base.Dispose(disposing);
            disposed = true;
        }

        /// <summary>
        /// Starts the stream.
        /// </summary>
        /// <param name="resource">Resource is an URI.</param>
        public void Start(string resource)
        {
            openCvSharpWrapper.Start(resource);
        }

        public void Stop()
        {
            openCvSharpWrapper.Stop();
        }
    }
}
