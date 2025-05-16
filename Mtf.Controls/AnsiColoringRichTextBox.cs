using Mtf.Controls.Enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Mtf.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(SourceCodeViewerRichTextBox), "Resources.SourceCodeViewerRichTextBox.png")]
    public class AnsiColoringRichTextBox : RichTextBox
    {
        private const string AnsiPattern = @"\x1B\[[0-9;]*m";
        private Color lastUsedFontColor;
        private Color lastUsedBackColor;
        private Color defaultFontColor;
        private Color defaultBackColor;

        public AnsiColoringRichTextBox()
        {
            lastUsedFontColor = ForeColor;
            defaultFontColor = ForeColor;
            defaultBackColor = BackColor;
        }

        #region Color properties

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Black color.")]
        public Color BlackColor { get; set; } = Color.Black;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Red color.")]
        public Color RedColor { get; set; } = Color.Red;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Green color.")]
        public Color GreenColor { get; set; } = Color.Green;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Yellow color.")]
        public Color YellowColor { get; set; } = Color.Yellow;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Blue color.")]
        public Color BlueColor { get; set; } = Color.Blue;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Purple color.")]
        public Color PurpleColor { get; set; } = Color.Purple;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Cyan color.")]
        public Color CyanColor { get; set; } = Color.Cyan;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("White color.")]
        public Color WhiteColor { get; set; } = Color.White;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Bright black color.")]
        public Color BrightBlackColor { get; set; } = Color.DarkGray;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Bright red color.")]
        public Color BrightRedColor { get; set; } = Color.LightCoral;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Bright green color.")]
        public Color BrightGreenColor { get; set; } = Color.LightGreen;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Bright yellow color.")]
        public Color BrightYellowColor { get; set; } = Color.LightYellow;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Bright blue color.")]
        public Color BrightBlueColor { get; set; } = Color.LightBlue;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Bright Purple color.")]
        public Color BrightPurpleColor { get; set; } = Color.Plum;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Bright cyan color.")]
        public Color BrightCyanColor { get; set; } = Color.LightCyan;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Bright white color.")]
        public Color BrightWhiteColor { get; set; } = Color.Wheat;

        #endregion
        
        public void ChangeMode(AnsiColoringMode ansiColoringMode)
        {
            AppendText($"\u001b[{(int)ansiColoringMode}m");
        }

        public void AppendText(string text, params AnsiColoringMode[] ansiColoringModes)
        {
            var sb = new StringBuilder();
            foreach (var ansiColoringMode in ansiColoringModes)
            {
                sb.Append($"\u001b[{(int)ansiColoringMode}m");
            }
            sb.Append(text);
            AppendText(sb.ToString());
        }

        private void AppendText(string text)
        {
            var regex = new Regex(AnsiPattern, RegexOptions.Compiled);
            var matches = regex.Matches(text);

            var currentColor = ForeColor;
            var currentBackColor = BackColor;
            var currentStyle = FontStyle.Regular;

            var insertionStartIndex = TextLength;
            var currentIndex = 0;

            foreach (Match match in matches)
            {
                var plainText = text.Substring(currentIndex, match.Index - currentIndex);
                if (!String.IsNullOrEmpty(plainText))
                {
                    var start = TextLength;
                    base.AppendText(plainText);
                    Select(start, plainText.Length);
                    SelectionColor = currentColor;
                    SelectionBackColor = currentBackColor;
                    SetSelectionFont(Font, currentStyle);
                }

                ProcessAnsiCode(match.Value, ref currentColor, ref currentBackColor, ref currentStyle);
                currentIndex = match.Index + match.Length;
            }

            if (currentIndex < text.Length)
            {
                var plainText = text.Substring(currentIndex);
                var start = TextLength;
                base.AppendText(plainText);
                Select(start, plainText.Length);
                SelectionColor = currentColor;
                SelectionBackColor = currentBackColor;
                SetSelectionFont(Font, currentStyle);
            }
        }

        private void ProcessAnsiCode(string ansiCode, ref Color currentColor, ref Color currentBackColor, ref FontStyle currentStyle)
        {
            var numbers = ansiCode.Trim('\x1B', '[', 'm').Split(';');
            foreach (var numStr in numbers)
            {
                if (!Int32.TryParse(numStr, out var code)) continue;

                switch (code)
                {
                    case 0:
                        currentColor = defaultFontColor;
                        currentBackColor = defaultBackColor;
                        currentStyle = FontStyle.Regular;
                        break;

                    case 1: currentStyle |= FontStyle.Bold; break;
                    case 2: /* set dim/faint mode */
                        currentColor = Color.FromArgb(128, currentColor);
                        break;
                    case 3: currentStyle |= FontStyle.Italic; break;
                    case 4: currentStyle |= FontStyle.Underline; break;
                    case 5: /* set blinking mode */ break;
                    case 7:
                        lastUsedFontColor = ForeColor;
                        lastUsedBackColor = BackColor;
                        var tmp = currentColor;
                        currentColor = currentBackColor;
                        currentBackColor = tmp;
                        break;
                    case 8:
                        lastUsedFontColor = ForeColor;
                        ForeColor = BackColor;
                        break;
                    case 9: currentStyle |= FontStyle.Strikeout; break;

                    case 22:
                        currentStyle &= ~FontStyle.Bold;
                        currentColor = Color.FromArgb(Byte.MaxValue, currentColor);
                        break;

                    case 23: currentStyle &= ~FontStyle.Italic; break;
                    case 24: currentStyle &= ~FontStyle.Underline; break;
                    case 25: /* reset blinking mode */ break;
                    case 27:
                        currentColor = lastUsedFontColor;
                        currentBackColor = lastUsedBackColor;
                        break;
                    case 28:
                        ForeColor = lastUsedFontColor;
                        break;
                    case 29: currentStyle &= ~FontStyle.Strikeout; break;

                    case 30: currentColor = BlackColor; break;
                    case 31: currentColor = RedColor; break;
                    case 32: currentColor = GreenColor; break;
                    case 33: currentColor = YellowColor; break;
                    case 34: currentColor = BlueColor; break;
                    case 35: currentColor = PurpleColor; break;
                    case 36: currentColor = CyanColor; break;
                    case 37: currentColor = WhiteColor; break;

                    case 40: currentBackColor = BlackColor; break;
                    case 41: currentBackColor = RedColor; break;
                    case 42: currentBackColor = GreenColor; break;
                    case 43: currentBackColor = YellowColor; break;
                    case 44: currentBackColor = BlueColor; break;
                    case 45: currentBackColor = PurpleColor; break;
                    case 46: currentBackColor = CyanColor; break;
                    case 47: currentBackColor = WhiteColor; break;

                    case 90: currentColor = BrightBlackColor; break;
                    case 91: currentColor = BrightRedColor; break;
                    case 92: currentColor = BrightGreenColor; break;
                    case 93: currentColor = BrightYellowColor; break;
                    case 94: currentColor = BrightBlueColor; break;
                    case 95: currentColor = BrightPurpleColor; break;
                    case 96: currentColor = BrightCyanColor; break;
                    case 97: currentColor = BrightWhiteColor; break;

                    case 100: currentBackColor = BrightBlackColor; break;
                    case 101: currentBackColor = BrightRedColor; break;
                    case 102: currentBackColor = BrightGreenColor; break;
                    case 103: currentBackColor = BrightYellowColor; break;
                    case 104: currentBackColor = BrightBlueColor; break;
                    case 105: currentBackColor = BrightPurpleColor; break;
                    case 106: currentBackColor = BrightCyanColor; break;
                    case 107: currentBackColor = BrightWhiteColor; break;
                }
            }
        }

        public AnsiColoringMode ColorToAnsiColoringMode(Color color, bool backColor = false)
        {
            if (color == BlackColor)
            {
                return backColor ? AnsiColoringMode.BlackBackColor : AnsiColoringMode.BlackFontColor;
            }
            if (color == RedColor)
            {
                return backColor ? AnsiColoringMode.RedBackColor : AnsiColoringMode.RedFontColor;
            }
            if (color == GreenColor)
            {
                return backColor ? AnsiColoringMode.GreenBackColor : AnsiColoringMode.GreenFontColor;
            }
            if (color == YellowColor)
            {
                return backColor ? AnsiColoringMode.YellowBackColor : AnsiColoringMode.YellowFontColor;
            }

            if (color == BlueColor)
            {
                return backColor ? AnsiColoringMode.BlueBackColor : AnsiColoringMode.BlueFontColor;
            }
            if (color == PurpleColor)
            {
                return backColor ? AnsiColoringMode.PurpleBackColor : AnsiColoringMode.PurpleFontColor;
            }
            if (color == CyanColor)
            {
                return backColor ? AnsiColoringMode.CyanBackColor : AnsiColoringMode.CyanFontColor;
            }
            if (color == WhiteColor)
            {
                return backColor ? AnsiColoringMode.WhiteBackColor : AnsiColoringMode.WhiteFontColor;
            }

            if (color == BrightBlackColor)
            {
                return backColor ? AnsiColoringMode.BrightBlackBackColor : AnsiColoringMode.BrightBlueFontColor;
            }
            if (color == BrightRedColor)
            {
                return backColor ? AnsiColoringMode.BrightRedBackColor: AnsiColoringMode.BrightRedFontColor;
            }
            if (color == BrightGreenColor)
            {
                return backColor ? AnsiColoringMode.BrightGreenBackColor: AnsiColoringMode.BrightGreenFontColor;
            }
            if (color == BrightYellowColor)
            {
                return backColor ? AnsiColoringMode.BrightYellowBackColor : AnsiColoringMode.BrightYellowFontColor;
            }

            if (color == BrightBlueColor)
            {
                return backColor ? AnsiColoringMode.BrightBlueBackColor : AnsiColoringMode.BrightBlueFontColor;
            }
            if (color == BrightPurpleColor)
            {
                return backColor ? AnsiColoringMode.BrightPurpleBackColor : AnsiColoringMode.BrightPurpleFontColor;
            }
            if (color == BrightCyanColor)
            {
                return backColor ? AnsiColoringMode.BrightCyanBackColor : AnsiColoringMode.BrightCyanFontColor;
            }
            if (color == WhiteColor)
            {
                return backColor ? AnsiColoringMode.BrightWhiteBackColor : AnsiColoringMode.BrightWhiteFontColor;
            }

            throw new NotSupportedException("This color is not supported.");
        }

        private void SetSelectionFont(Font font, FontStyle fontStyle)
        {
            try
            {
                SelectionFont = new Font(Font, fontStyle);
            }
            catch
            {
                SelectionFont = Font;
            }
        }

        public void ClearColoring()
        {
            SelectAll();
            SelectionColor = ForeColor;
            SelectionFont = Font;
        }
    }
}
