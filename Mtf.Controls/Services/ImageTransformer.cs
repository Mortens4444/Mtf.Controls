using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Mtf.Controls.Services
{
    public static class ImageTransformer
    {
        public static Image ZoomImage(Image img, Size size)
        {
            var sx = (double)size.Width / img.Width;
            var sy = (double)size.Height / img.Height;

            size = sx < sy ? new Size(size.Width, Convert.ToInt32(img.Height * sx)) : new Size(Convert.ToInt32(img.Width * sy), size.Height);

            return StretchImage(img, size);
        }

        public static Image StretchImage(Image img, Size size)
        {
            var bmp = new Bitmap(img, size.Width, size.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            }
            return bmp;
        }
    }
}
