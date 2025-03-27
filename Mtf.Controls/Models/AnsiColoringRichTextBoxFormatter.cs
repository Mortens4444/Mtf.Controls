using System.Drawing;

namespace Mtf.Controls.Models
{
    public class AnsiColoringRichTextBoxFormatter
    {
        public int Start { get; private set; }
        
        public int Length { get; private set; }

        public Color? Color { get; private set; }

        public FontStyle Style { get; private set; }

        public AnsiColoringRichTextBoxFormatter(int start, int length, Color? color, FontStyle style)
        {
            Start = start;
            Length = length;
            Color = color;
            Style = style;
        }
    }
}
