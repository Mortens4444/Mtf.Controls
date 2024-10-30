using Mtf.Controls.Enums;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MovablePanel), "Resources.MovablePanel.bmp")]
    public class MovablePanel : TransparentPanel
    {
        private Point dragStartPoint;
        private bool isDragging;

        public MovablePanel()
        {
            CanMove = true;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Determines whether the panel can be repositioned by dragging.")]
        public bool CanMove { get; set; }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            if (e.Button == MouseButtons.Left && CanMove)
            {
                isDragging = true;
                dragStartPoint = e.Location;
                Cursor = Cursors.SizeAll;
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (CanMove && isDragging)
            {
                isDragging = false;
                Cursor = Cursors.Default;
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            if (isDragging && CanMove)
            {
                var newLocation = new Point(Location.X + e.X - dragStartPoint.X, Location.Y + e.Y - dragStartPoint.Y);
                Location = newLocation;
                Invalidate();
            }
            base.OnMouseMove(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)WindowMessage.WM_NCPAINT)
            {
                Invalidate();
            }
            base.WndProc(ref m);
        }
    }
}
