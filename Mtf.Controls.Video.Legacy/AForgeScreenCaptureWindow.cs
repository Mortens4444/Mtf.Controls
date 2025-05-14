using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Video.Legacy
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(AForgeScreenCaptureWindow), "Resources.VideoSource.png")]
    public partial class AForgeScreenCaptureWindow : PictureBox
    {
        private readonly AForgeScreenCapture aForgeScreenCapture;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The recording area.")]
        public Rectangle RecordingArea { get; set; } = Screen.PrimaryScreen.Bounds;

        public AForgeScreenCaptureWindow()
        {
            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;
            aForgeScreenCapture = new AForgeScreenCapture(this, RecordingArea);
        }

        public void Start()
        {
            aForgeScreenCapture.Start();
        }

        public void Stop()
        {
            aForgeScreenCapture.Stop();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                aForgeScreenCapture.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}