using Mtf.Controls.Enums;
using Mtf.Controls.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Video
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(FFmpegWindow), "Resources.VideoSource.png")]
    public class FFmpegWindow : PictureBox
    {
        private bool disposed;
        private readonly FFmpeg fFmpeg;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("FFMPEG Codec.")]
        public Codec Codec { get; set; } = Codec.mjpeg;

        public FFmpegWindow()
        {
            BackgroundImage = Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;
            fFmpeg = new FFmpeg(this, Codec);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                fFmpeg.Dispose();
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
            fFmpeg.Start(resource);
        }

        public void Stop()
        {
            fFmpeg.Stop();
        }
    }
}
