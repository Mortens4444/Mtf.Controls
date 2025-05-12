using System.Drawing;

namespace Mtf.Controls.Interfaces
{
    public interface IVideoWindow
    {
        string OverlayText { get; set; }

        Font OverlayFont { get; set; }

        Brush OverlayBrush { get; set; }

        Point OverlayLocation { get; set; }
    }
}
