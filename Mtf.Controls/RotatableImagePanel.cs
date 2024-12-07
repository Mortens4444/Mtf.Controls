using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Mtf.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(RotatableImagePanel), "Resources.MovableSizablePanel.png")]
    public class RotatableImagePanel : MovableSizablePanel, ICloneable
    {
        private Point mouseDownLocation;
        private bool move, size, changeOriginal;
        private Image originalImage;
        private float modifier;
        private float? rotation;

        public RotatableImagePanel()
        {
            RotatingMouseButton = MouseButtons.Middle;
            mouseDownLocation = Point.Empty;
            changeOriginal = true;
            modifier = float.NaN;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Gets or sets the rotating mouse button.")]
        public MouseButtons RotatingMouseButton { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Gets or sets the initial rotation in degrees.")]
        public float? Rotation
        {
            get => rotation;
            set
            {
                rotation = value;

                if (value.HasValue && BackgroundImage != null)
                {
                    Rotate(value.Value, true);
                }
            }
        }

        public object Clone()
        {
            var clone = new RotatableImagePanel
            {
                CanMove = CanMove,
                CanSize = CanSize,
                changeOriginal = changeOriginal,
                modifier = modifier,
                mouseDownLocation = mouseDownLocation,
                move = move,
                RotatingMouseButton = RotatingMouseButton,
                size = size,
                BackgroundImage = BackgroundImage,
                Location = Location,
                Size = Size,
                BackColor = BackColor,
                BackgroundImageLayout = BackgroundImageLayout,
                Tag = Tag,
                Rotation = Rotation
            };
            if (originalImage != null)
            {
                clone.originalImage = (Image)originalImage.Clone();
            }

            return clone;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == RotatingMouseButton)
            {
                move = CanMove;
                size = CanSize;

                CanMove = false;
                CanSize = false;

                mouseDownLocation = e.Location;
            }
            else
            {
                mouseDownLocation = Point.Empty;
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (mouseDownLocation != Point.Empty)
            {
                if (float.IsNaN(modifier) && !e.Location.Equals(mouseDownLocation))
                {
                    modifier = GetAngleBetweenPoints(mouseDownLocation, e.Location);
                }

                var angle = GetAngleBetweenPoints(mouseDownLocation, e.Location) - modifier;
                Rotate(angle, false);
            }
            base.OnMouseMove(e);
        }

        private void Rotate(float angle, bool highQualityBicubicInterpolation)
        {
            if (!float.IsNaN(angle))
            {
                changeOriginal = false;
                BackgroundImage = RotateImage(originalImage, angle, highQualityBicubicInterpolation);
                changeOriginal = true;
            }
        }

        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            if (changeOriginal)
            {
                originalImage = BackgroundImage;

                if (Rotation.HasValue)
                {
                    Rotate(Rotation.Value, true);
                }
            }

            base.OnBackgroundImageChanged(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (mouseDownLocation != Point.Empty)
            {
                var angle = GetAngleBetweenPoints(mouseDownLocation, e.Location) - modifier;
                Rotation = angle;
                ResetRotationState();
            }
            base.OnMouseUp(e);
        }

        private void ResetRotationState()
        {
            mouseDownLocation = Point.Empty;
            modifier = float.NaN;
            CanMove = move;
            CanSize = size;
        }

        private static Image RotateImage(Image image, float angle, bool highQualityBicubicInterpolation)
        {
            if (float.IsNaN(angle) || image == null)
            {
                return image;
            }

            var rotatedBitmap = new Bitmap(image.Width, image.Height);
            rotatedBitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var g = Graphics.FromImage(rotatedBitmap))
            {
                g.InterpolationMode = highQualityBicubicInterpolation ? InterpolationMode.HighQualityBicubic : InterpolationMode.Default;
                var matrix = new Matrix();
                matrix.RotateAt(angle, new PointF(image.Width / 2f, image.Height / 2f));
                g.Transform = matrix;
                g.DrawImage(image, new Point(0, 0));
            }
            return rotatedBitmap;
        }

        private static float GetAngleBetweenPoints(Point pt1, Point pt2)
        {
            var deltaX = pt2.X - pt1.X;
            var deltaY = pt2.Y - pt1.Y;

            if (deltaX == 0 && deltaY == 0)
            {
                return 0;
            }

            var angle = Math.Atan2(deltaY, deltaX) * (180 / Math.PI);
            return (float)(angle < 0 ? angle + 360 : angle);
        }
    }
}
