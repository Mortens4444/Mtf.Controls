using Mtf.Controls.Enums;
using Mtf.Controls.Services;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(TransparentPanel), "Resources.TransparentPanel.png")]
    public class TransparentPanel : Panel
    {
        public TransparentPanel()
        {
            UseTransparentColor = false;
            TransparentColor = Color.Black;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Indicates whether to use a transparent color for the panel.")]
        public bool UseTransparentColor { get; set; } = true;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Specifies the color that will be treated as transparent in the panel.")]
        public Color TransparentColor { get; set; } = Color.White;

        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;
                if (UseTransparentColor)
                {
                    createParams.ExStyle |= (int)ExtendedWindowStyle.WS_EX_TRANSPARENT;
                }

                return createParams;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (!UseTransparentColor)
            {
                base.OnPaintBackground(e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            if (UseTransparentColor && BackgroundImage != null)
            {
                using (var bmp = (Bitmap)ImageTransformer.ZoomImage(BackgroundImage, Size))
                {
                    bmp.MakeTransparent(TransparentColor);
                    e.Graphics.DrawImage(bmp, Point.Empty);
                }
            }
            else
            {
                base.OnPaint(e);
            }
        }
    }
}
