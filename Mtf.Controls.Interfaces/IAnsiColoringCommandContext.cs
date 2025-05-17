using System.Drawing;

namespace Mtf.Controls.Interfaces
{
    public interface IAnsiColoringCommandContext
    {
        Color ForeColor { get; set; }

        Color BackColor { get; set; }

        Color CurrentColor { get; set; }

        Color CurrentBackColor { get; set; }

        FontStyle CurrentFontStyle { get; set; }

        Color DefaultFontColor { get; }

        Color DefaultBackColor { get; }

        Color LastUsedFontColor { get; set; }

        Color LastUsedBackColor { get; set; }
    }
}
