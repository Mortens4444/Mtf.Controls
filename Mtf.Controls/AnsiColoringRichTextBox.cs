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
        private static readonly Regex AnsiPattern = new Regex(@"[\x1B\u001b]\[[0-9;]*[A-HJKSTfmisu]", RegexOptions.Compiled);
        
        private Color currentColor;
        private Color currentBackColor;
        private FontStyle currentFontStyle;

        public AnsiColoringRichTextBox()
        {
            currentColor = ForeColor;
            currentBackColor = BackColor;
            currentFontStyle = Font.Style;

            LastUsedFontColor = ForeColor;
            DefaultFontColor = ForeColor;
            DefaultBackColor = BackColor;
        }

        #region Properties

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Default font color.")]
        public Color DefaultFontColor { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Default background color.")]
        public Color DefaultBackColor { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Last used font color.")]
        public Color LastUsedFontColor { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Last used background color.")]
        public Color LastUsedBackColor { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Current color.")]
        public Color CurrentColor { get => currentColor; set => currentColor = value; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Current background color.")]
        public Color CurrentBackColor { get => currentBackColor; set => currentBackColor = value; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Font style.")]
        public FontStyle CurrentFontStyle { get => currentFontStyle; set => currentFontStyle = value; }

        #endregion

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
                else if (AnsiCodeFormattingDecider.IsMovingCode(match.Value))
                {
                    ProcessAnsiMovingCode(match.Value);
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
            var codeRegex = new Regex(@"\x1b\[(\d*(;\d+)*)[Hf]");
            var match = codeRegex.Match(ansiCode);

            if (match.Success)
            {
                var codesString = match.Groups[1].Value;
                var individualCodes = codesString.Split(';');

                foreach (var codeStr in individualCodes)
                {
                    var command = AnsiMovingCommandFactory.Create(ansiCode, codesString, this);
                    command.Execute(this);
                }
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
    }
}
