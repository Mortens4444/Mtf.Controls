using Mtf.Controls.Enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MovableSizablePanel), "Resources.MovableSizablePanel.png")]
    public class MovableSizablePanel : MovablePanel, ICloneable
    {
        public MovableSizablePanel()
        {
            InitializeResizeHandles();
            CanSize = true;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Allows resizing of the panel by adjusting its dimensions.")]
        public bool CanSize { get; set; }

        private void InitializeResizeHandles()
        {
            AddResizeHandle("pbEast", Cursors.SizeWE, AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right, ResizeDirection.East);
            AddResizeHandle("pbSouth", Cursors.SizeNS, AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right, ResizeDirection.South);
            AddResizeHandle("pbSouthEast", Cursors.SizeNWSE, AnchorStyles.Bottom | AnchorStyles.Right, ResizeDirection.SouthEast);
        }

        private void AddResizeHandle(string name, Cursor cursor, AnchorStyles anchor, ResizeDirection direction)
        {
            var pb = new PictureBox
            {
                Name = name,
                Width = Constants.Border,
                Height = Constants.Border,
                Anchor = anchor,
                Cursor = cursor,
                BackColor = Color.DimGray,
                BorderStyle = BorderStyle.Fixed3D
            };

            pb.MouseDown += (s, e) => pb.Capture = true;
            pb.MouseUp += (s, e) => pb.Capture = false;
            pb.MouseMove += (s, e) => HandleResizeMouseMove(e, direction);
            Controls.Add(pb);
        }

        private void HandleResizeMouseMove(MouseEventArgs e, ResizeDirection direction)
        {
            if (e.Button == MouseButtons.Left && CanSize)
            {
                if (direction.HasFlag(ResizeDirection.East))
                {
                    Width += e.X;
                }

                if (direction.HasFlag(ResizeDirection.South))
                {
                    Height += e.Y;
                }

                CheckSize();
                Invalidate();
            }
        }

        private void CheckSize()
        {
            Width = Math.Max(Width, Constants.MinSize);
            Height = Math.Max(Height, Constants.MinSize);
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            RelocateResizeHandles();
        }

        private void RelocateResizeHandles()
        {
            var pbEast = Controls["pbEast"];
            var pbSouth = Controls["pbSouth"];
            var pbSouthEast = Controls["pbSouthEast"];

            if (pbEast != null)
            {
                pbEast.Location = new Point(Width - Constants.Border, 0);
                pbEast.Height = Height - Constants.Border;
            }

            if (pbSouth != null)
            {
                pbSouth.Location = new Point(0, Height - Constants.Border);
                pbSouth.Width = Width - Constants.Border;
            }

            if (pbSouthEast != null)
            {
                pbSouthEast.Location = new Point(Width - Constants.Border, Height - Constants.Border);
            }
        }

        public object Clone()
        {
            return new MovableSizablePanel
            {
                Size = Size,
                BackColor = BackColor,
                BorderStyle = BorderStyle,
                CanMove = CanMove,
                CanSize = CanSize,
                Location = Location
            };
        }

        public MovableSizablePanel Clone(Point location)
        {
            return new MovableSizablePanel
            {
                Size = Size,
                BackColor = BackColor,
                BorderStyle = BorderStyle,
                CanMove = true,
                CanSize = CanSize,
                Location = location
            };
        }
    }
}
