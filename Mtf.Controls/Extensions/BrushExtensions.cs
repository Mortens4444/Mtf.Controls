using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Mtf.Controls.Extensions
{
    public static class BrushExtensions
    {
        public static Color ToColor(this Brush brush)
        {
            if (brush is SolidBrush solidBrush)
            {
                return solidBrush.Color;
            }
            else if (brush is LinearGradientBrush linearGradientBrush)
            {
                return linearGradientBrush.LinearColors[0];
            }
            else if (brush is HatchBrush hatchBrush)
            {
                return hatchBrush.ForegroundColor;
            }

            throw new InvalidOperationException();
        }
    }
}
