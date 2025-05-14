using AxVIDEOCONTROL4Lib;
using Mtf.Controls.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Video.ActiveX
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(AxVideoPlayerWindow), "Resources.VideoSource.png")]
    public partial class AxVideoPlayerWindow : UserControl, IVideoWindow
    {
        public AxVideoPlayerWindow()
        {
            InitializeComponent();
            AxVideoPlayer = new AxVideoPlayer(this);

            pictureBox.Paint += PictureBox_Paint;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Direct access to the ActiveX control.")]
        public AxVideoPicture AxVideoPicture => axVideoPicture;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Video player that provides a more user-friendly experience during use.")]
        public AxVideoPlayer AxVideoPlayer { get; private set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Text to be displayed on the control.")]
        public string OverlayText { get; set; } = String.Empty;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Font type of the text to be displayed on the control.")]
        public Font OverlayFont { get; set; } = new Font("Arial", 32, FontStyle.Bold);

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color of the text to be displayed on the control.")]
        public Brush OverlayBrush { get; set; } = Brushes.White;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Location of the text to be displayed on the control.")]
        public Point OverlayLocation { get; set; } = new Point(10, 10);

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (!String.IsNullOrEmpty(OverlayText))
            {
                var graphics = e.Graphics;
                //_ = graphics.MeasureString(OverlayText, OverlayFont);
                graphics.DrawString(OverlayText, OverlayFont, OverlayBrush, OverlayLocation);
            }
        }
    }
}
