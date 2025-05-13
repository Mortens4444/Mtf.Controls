using System.Drawing;

namespace Mtf.Controls.Models
{
    public class AnsiColoringRichTextBoxFormatter
    {
        public int Start { get; private set; }
        
        public int Length { get; private set; }

        public Color FontColor { get; private set; }

        public Color BackColor { get; private set; }

        public FontStyle Style { get; private set; }

        public AnsiColoringRichTextBoxFormatter(int start, int length, Color color, Color backColor, FontStyle style)
        {
            Start = start;
            Length = length;
            FontColor = color;
            BackColor = backColor;
            Style = style;
        }
    }
}
