using System.Drawing;

namespace Mtf.Controls.Models
{
    public class LocationAndSize
    {
        public Point Location { get; set; }

        public Size Size { get; set; }

        public int Left => Location.X;

        public int Top => Location.Y;

        public int Width => Size.Width;

        public int Height => Size.Height;

        public LocationAndSize(int x, int y, int width, int height)
            : this(new Point(x, y), new Size(width, height))
        { }

        public LocationAndSize(Point location, Size size)
        {
            Location = location;
            Size = size;
        }

        public override string ToString()
        {
            return $"X: {Location.X}, Y: {Location.Y}), Width: {Size.Width}, Height: {Size.Height}";
        }
    }
}
