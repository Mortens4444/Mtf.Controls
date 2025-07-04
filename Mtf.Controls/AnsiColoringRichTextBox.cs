﻿using Mtf.Controls.Enums;
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
    /// <summary>
    /// https://en.wikipedia.org/wiki/ANSI_escape_code
    /// https://gist.github.com/ConnerWill/d4b6c776b509add763e17f9f113fd25b
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(AnsiColoringRichTextBox), "Resources.SourceCodeViewerRichTextBox.png")]
    public class AnsiColoringRichTextBox : RichTextBox, IAnsiColoringCommandContext, IAnsiMovingCommandContext, IAnsiErasingCommandContext, IAnsiControlCommandContext
    {
        public delegate void TextModifierCallback(int index, string text);

        private static readonly Regex AnsiPattern = new Regex(@"\x1B\[[0-9;]*[A-HJKSTfmisu]|\a|\x08|\t|\v|\f|\x7F", RegexOptions.Compiled);
        
        private Color currentColor;
        private Color currentBackColor;
        private FontStyle currentFontStyle;
        private Color defaultBackColor;
        private Color defaultFontColor;
        private Theme theme;

        public AnsiColoringRichTextBox() : this(Theme.Dark) { }

        public AnsiColoringRichTextBox(Theme theme)
        {
            UpdateThemeColors(theme);
        }

        public void UpdateThemeColors(Theme theme = Theme.Dark)
        {
            this.theme = theme;
            BackColor = theme == Theme.Dark ? BlackColor : WhiteColor;
            ForeColor = theme == Theme.Dark ? WhiteColor : BlackColor;

            currentColor = ForeColor;
            currentBackColor = BackColor;
            currentFontStyle = Font.Style;
            LastUsedFontColor = ForeColor;
            DefaultFontColor = ForeColor;
            DefaultBackgroundColor = BackColor;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Current theme.")]
        public Theme Theme
        {
            get => theme;
            set
            {
                theme = value;
                UpdateThemeColors(theme);
                if (ClearScreenOnThemeChange)
                {
                    EraseScreen();
                }
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Clears the screen after the theme changes.")]
        public bool ClearScreenOnThemeChange { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Delete newline characters when the EraseLine method is called.")]
        public bool DeleteNewLineCharactersWhenEraseLineCalled { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Line separators.")]
        public string[] LineSeparators { get; set; } = new string[] { "\r", "\n" };

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("String split options for lines.")]
        public StringSplitOptions StringSplitOptions { get; set; } = StringSplitOptions.RemoveEmptyEntries;

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
        public Color DefaultBackgroundColor
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

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Lines.")]
        public new string[] Lines => Text.Split(LineSeparators, StringSplitOptions);

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
            AppendText($"\x1B[{(int)ansiColoringMode}m");
        }

        public void AppendText(string text, params AnsiColoringMode[] ansiColoringModes)
        {
            var sb = new StringBuilder();
            if (ansiColoringModes != null)
            {
                foreach (var ansiColoringMode in ansiColoringModes)
                {
                    var msg = $"\x1B[{(int)ansiColoringMode}m";
                    _ = sb.Append(msg);
                }
            }
            _ = sb.Append(text);
            AppendText(sb.ToString());
        }

        public new void AppendText(string text)
        {
            AppendOrInsertText(0, text, Append);
        }

        public void AppendTextAndUpdate(string text)
        {
            AppendText(text);
            Update();
        }

        private void Append(int index, string text)
        {
            base.AppendText(text);
        }

        public void InsertText(int index, string text)
        {
            AppendOrInsertText(index, text, InsertAt);
        }

        public void InsertTextAndUpdate(int index, string text)
        {
            InsertText(index, text);
            Update();
        }

        public void InsertTextAtCaret(string text)
        {
            AppendOrInsertText(SelectionStart, text, InsertAt);
        }

        public void InsertTextAtCaretAndUpdate(string text)
        {
            InsertTextAtCaret(text);
            Update();
        }

        private void InsertAt(int index, string text)
        {
            var originalSelectionStart = SelectionStart;
            var originalSelectionLength = SelectionLength;

            SelectionStart = index;
            SelectionLength = 0;
            SelectedText = text;

            SelectionStart = originalSelectionStart + text?.Length ?? 0;
            SelectionLength = originalSelectionLength;
        }


        private void AppendOrInsertText(int index, string text, TextModifierCallback textModifierCallback)
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
                    ApplyStyle(index, plainText, textModifierCallback);
                }

                if (AnsiCodeFormattingDecider.IsControlCode(match.Value))
                {
                    var controlCommand = AnsiControlCommandFactory.Create(match.Value[0]);
                    controlCommand?.Execute(this);
                }
                else if (AnsiCodeFormattingDecider.IsColoringCode(match.Value))
                {
                    ProcessAnsiColoringCode(match.Value);
                }
                else if (AnsiCodeFormattingDecider.IsMovingCode(match.Value, out var m))
                {
                    index = ProcessAnsiMovingCode(m.Value);
                }
                else if (AnsiCodeFormattingDecider.IsErasingCode(match.Value))
                {
                    ProcessAnsiErasingCode(match.Value);
                }

                currentIndex = match.Index + match.Length;
            }

            if (currentIndex < text.Length)
            {
                var plainText = text.Substring(currentIndex);
                ApplyStyle(index, plainText, textModifierCallback);
            }
        }

        private void ProcessAnsiErasingCode(string value)
        {
            var command = AnsiErasingCommandFactory.Create(value);
            command.Execute(this);
        }

        private void ApplyStyle(int index, string plainText, TextModifierCallback textModifierCallback)
        {
            var start = TextLength;
            textModifierCallback(index, plainText);
            Select(start, plainText.Length);
            SelectionColor = CurrentColor;
            SelectionBackColor = CurrentBackColor;
            SetSelectionFont(Font, CurrentFontStyle);
        }

        private int ProcessAnsiMovingCode(string ansiCode)
        {
            var codeRegex = new Regex(@"\x1B\[(\d*(;\d+)*)[A-Hf]");
            var match = codeRegex.Match(ansiCode);

            if (match.Success)
            {
                var codesString = match.Groups[1].Value;
                var command = AnsiMovingCommandFactory.Create(ansiCode, codesString, match);
                command.Execute(this);
            }

            return SelectionStart;
        }

        private void ProcessAnsiColoringCode(string ansiCode)
        {
            var codeRegex = new Regex(@"\x1B\[(\d+(;\d+)*)m");
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

        public void EraseFromCursorToEndOfLine()
        {
            var lineIndex = GetLineFromCharIndex(SelectionStart);
            var lineStart = GetFirstCharIndexFromLine(lineIndex);
            var lineLength = GetLineLength(lineIndex);
            var cursorOffset = SelectionStart - lineStart;

            var charsToErase = lineLength - cursorOffset;

            if (charsToErase > 0)
            {
                Select(SelectionStart, charsToErase);
                SelectedText = String.Empty;
            }
        }

        public void EraseFromCursorToEndOfScreen()
        {
            var cursor = SelectionStart;
            var totalLength = TextLength;
            if (cursor < totalLength)
            {
                Select(cursor, totalLength - cursor);
                SelectedText = String.Empty;
            }
        }

        public void EraseFromStartOfLineToCursor()
        {
            var lineIndex = GetLineFromCharIndex(SelectionStart);
            var lineStart = GetFirstCharIndexFromLine(lineIndex);
            var cursor = SelectionStart;
            var length = cursor - lineStart;

            if (length > 0)
            {
                Select(lineStart, length);
                SelectedText = String.Empty;
                SelectionStart = cursor - length;
            }
        }

        public void EraseFromStartToCursor()
        {
            var cursor = SelectionStart;
            if (cursor > 0)
            {
                Select(0, cursor);
                SelectedText = String.Empty;
                SelectionStart = 0;
            }
        }

        public void EraseLine()
        {
            var lineIndex = GetLineFromCharIndex(SelectionStart);
            var lineStart = GetFirstCharIndexFromLine(lineIndex);
            var lineText = Lines.Length > lineIndex ? Lines[lineIndex] : String.Empty;

            if (!String.IsNullOrEmpty(lineText))
            {
                Select(lineStart, lineText.Length);
                SelectedText = String.Empty;
                SelectionStart = lineStart;
            }
        }

        public void EraseLineWithNewLine()
        {
            var lineIndex = GetLineFromCharIndex(SelectionStart);
            var lineStart = GetFirstCharIndexFromLine(lineIndex);
            var nextLineStart = lineIndex + 1 < Lines.Length
                ? GetFirstCharIndexFromLine(lineIndex + 1)
                : TextLength;

            var length = nextLineStart - lineStart;
            if (length > 0)
            {
                Select(lineStart, length);
                SelectedText = String.Empty;
                SelectionStart = lineStart;
            }
        }

        public void EraseSavedLines()
        {
            Clear();
        }

        public void EraseScreen()
        {
            Text = String.Empty;
        }

        public void Bell()
        {
            Console.Beep();
        }

        public void Backspace()
        {
            var selectionStart = SelectionStart;
            var selectionLength = SelectionLength;

            if (selectionLength > 0)
            {
                SelectedText = String.Empty;
                SelectionStart = selectionStart;
                SelectionLength = 0;
            }
            else if (selectionStart > 0)
            {
                Select(selectionStart - 1, 1);
                SelectedText = String.Empty;
                SelectionStart = selectionStart - 1;
                SelectionLength = 0;
            }
        }

        public void HorizontalTab()
        {
            AppendText("\t");
        }

        public void LineFeed()
        {
            AppendText(Environment.NewLine);
        }

        public void VerticalTab()
        {
            AppendText(Environment.NewLine);
        }

        public void FormFeed()
        {
            Clear();
        }

        public void CarriageReturn()
        {
            SelectionStart = GetFirstCharIndexOfCurrentLine();
        }

        public void Delete()
        {
            if (SelectionStart < TextLength)
            {
                var pos = SelectionStart;
                Text = Text.Remove(pos, 1);
                SelectionStart = pos;
            }
        }
    }
}
