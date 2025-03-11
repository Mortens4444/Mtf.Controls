using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Net481
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(AccordScreenCaptureWindow), "Resources.VideoSource.png")]
    public partial class AccordScreenCaptureWindow : PictureBox
    {
        private readonly AccordScreenCapture accordScreenCapture;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The recording area.")]
        public Rectangle RecordingArea { get; set; } = Screen.PrimaryScreen.Bounds;

        public AccordScreenCaptureWindow()
        {
            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;
            accordScreenCapture = new AccordScreenCapture(this, RecordingArea);
        }

        public void Start()
        {
            accordScreenCapture.Start();
        }

        public void Stop()
        {
            accordScreenCapture.Stop();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                accordScreenCapture.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}