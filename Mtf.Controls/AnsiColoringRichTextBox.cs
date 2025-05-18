using Mtf.Controls.Enums;
using Mtf.Controls.Interfaces;
using Mtf.Controls.Services;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Mtf.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(AnsiColoringRichTextBox), "Resources.SourceCodeViewerRichTextBox.png")]
    public class AnsiColoringRichTextBox : RichTextBox, IAnsiColoringCommandContext, IAnsiMovingCommandContext
    {
        private static readonly Regex AnsiPattern = new Regex(@"\x1B\[[0-9;]*[A-HJKSTfmisu]", RegexOptions.Compiled);
        
        private Color currentColor;
        private Color currentBackColor;
        private FontStyle currentFontStyle;
        private Color defaultBackColor;
        private Color defaultFontColor;

        public AnsiColoringRichTextBox()
        {
            currentColor = ForeColor;
            currentBackColor = BackColor;
            currentFontStyle = Font.Style;

            LastUsedFontColor = ForeColor;
            DefaultFontColor = ForeColor;
            DefaultBackColor = BackColor;
        }

        #region Hidden Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Last used background color.")]
        public int SavedCaretPosition { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Default font color.")]
        public Color DefaultFontColor
        {
            get => defaultFontColor;
            set
            {
                defaultFontColor = value;
                AppendText(String.Empty, ColorToAnsiColoringMode(value));
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Default background color.")]
        public Color DefaultBackColor
        {
            get => defaultBackColor;
            set
            {
                defaultBackColor = value;
                AppendText(String.Empty, ColorToAnsiColoringMode(value, true));
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Last used font color.")]
        public Color LastUsedFontColor { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Last used background color.")]
        public Color LastUsedBackColor { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Current color.")]
        public Color CurrentColor { get => currentColor; set => currentColor = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Current background color.")]
        public Color CurrentBackColor { get => currentBackColor; set => currentBackColor = value; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Font style.")]
        public FontStyle CurrentFontStyle { get => currentFontStyle; set => currentFontStyle = value; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Line separators.")]
        public string[] LineSeparators => new string[] { "\r", "\n" };

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("String split options for lines.")]
        public StringSplitOptions StringSplitOptions => StringSplitOptions.RemoveEmptyEntries;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Lines.")]
        public string[] Lines => Text.Split(LineSeparators, StringSplitOptions);

        #endregion

        #region Color Properties

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
            if (ansiColoringModes != null)
            {
                foreach (var ansiColoringMode in ansiColoringModes)
                {
                    var msg = $"\u001b[{(int)ansiColoringMode}m";
                    _ = sb.Append(msg);
                }
            }
            _ = sb.Append(text);
            AppendText(sb.ToString());
        }

        public new void AppendText(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return;
            }

            var matches = AnsiPattern.Matches(text);
            var currentIndex = 0;

            foreach (Match match in matches)
            {
                var plainText = text.Substring(currentIndex, match.Index - currentIndex);
                if (!String.IsNullOrEmpty(plainText))
                {
                    ApplyStyle(plainText);
                }

                if (AnsiCodeFormattingDecider.IsColoringCode(match.Value))
                {
                    ProcessAnsiColoringCode(match.Value);
                }
                else if (AnsiCodeFormattingDecider.IsMovingCode(match.Value, out var m))
                {
                    ProcessAnsiMovingCode(m.Value);
                }

                currentIndex = match.Index + match.Length;
            }

            if (currentIndex < text.Length)
            {
                var plainText = text.Substring(currentIndex);
                ApplyStyle(plainText);
            }
        }

        private void ApplyStyle(string plainText)
        {
            var start = TextLength;
            base.AppendText(plainText);
            Select(start, plainText.Length);
            SelectionColor = CurrentColor;
            SelectionBackColor = CurrentBackColor;
            SetSelectionFont(Font, CurrentFontStyle);
        }

        private void ProcessAnsiMovingCode(string ansiCode)
        {
            var codeRegex = new Regex(@"\x1b\[(\d*(;\d+)*)[A-Hf]");
            var match = codeRegex.Match(ansiCode);

            if (match.Success)
            {
                var codesString = match.Groups[1].Value;
                var command = AnsiMovingCommandFactory.Create(ansiCode, codesString, match);
                command.Execute(this);
            }
        }

        private void ProcessAnsiColoringCode(string ansiCode)
        {
            var codeRegex = new Regex(@"\x1b\[(\d+(;\d+)*)m");
            var match = codeRegex.Match(ansiCode);

            if (match.Success)
            {
                var codesString = match.Groups[1].Value;
                var individualCodes = codesString.Split(';');

                foreach (var codeStr in individualCodes)
                {
                    if (Int32.TryParse(codeStr, out int code))
                    {
                        var command = AnsiColoringCommandFactory.Create(code, this);
                        command.Execute(this);
                    }
                }
            }
        }

        private void SetSelectionFont(Font font, FontStyle fontStyle)
        {
            try
            {
                SelectionFont = new Font(font, fontStyle);
            }
            catch
            {
                SelectionFont = font;
            }
        }

        public void ClearColoring()
        {
            SelectAll();
            SelectionColor = ForeColor;
            SelectionFont = Font;
        }

        public AnsiColoringMode ColorToAnsiColoringMode(Color color, bool backColor = false)
        {
            return ColoringModeConverter.ColorToAnsiColoringMode(this, color, backColor);
        }

        public int GetLineLength(int lineIndex)
        {
            return Lines.Length > lineIndex ? Lines[lineIndex].Length : 0;
        }

        public int GetLineIndexAtCaret()
        {
            return GetLineFromCharIndex(SelectionStart);
        }

        public int GetColumnAtCaret()
        {
            var lineIndex = GetLineFromCharIndex(SelectionStart);
            var lineStartCharIndex = GetFirstCharIndexFromLine(lineIndex);
            var column = SelectionStart - lineStartCharIndex;
            return Math.Max(0, column);
        }

        public int GetLineCount()
        {
            return Lines.Length;
        }

        public int GetCharIndexFromLineAndColumn(int lineIndex, int col)
        {
            if (lineIndex < 0 || lineIndex >= Lines.Length)
            {
                return 0;
            }

            var lineStartCharIndex = GetFirstCharIndexFromLine(lineIndex);
            if (lineStartCharIndex < 0)
            {
                return TextLength;
            }

            var lineLength = GetLineLength(lineIndex);
            col = Math.Min(col, lineLength);
            return lineStartCharIndex + col;
        }
    }
}
