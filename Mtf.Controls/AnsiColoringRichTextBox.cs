using Mtf.Controls.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Mtf.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(SourceCodeViewerRichTextBox), "Resources.SourceCodeViewerRichTextBox.png")]
    public class AnsiColoringRichTextBox : RichTextBox
    {
        private static readonly char[] separator = { '\r', '\n' };
        private const string AnsiPattern = @"\x1B\[[0-9;]*m";
        private Color lastUsedFontColor;
        private Color defaultFontColor;
        private Color defaultBackColor;

        public AnsiColoringRichTextBox()
        {
            lastUsedFontColor = ForeColor;
            defaultFontColor = ForeColor;
            defaultBackColor = BackColor;
        }

        public new void AppendText(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return;
            }

            var lines = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                AppendTextPart(line);
                base.AppendText(Environment.NewLine);
            }
        }

        private void AppendTextPart(string text)
        {
            var insertionStartIndex = TextLength;

            var regex = new Regex(AnsiPattern, RegexOptions.Compiled);
            var matches = regex.Matches(text);
            var formattedBlocks = new List<AnsiColoringRichTextBoxFormatter>();

            Color currentColor = ForeColor;
            Color currentBackColor = BackColor;
            var currentStyle = FontStyle.Regular;
            var totalRemovedLength = 0;

            for (var i = 0; i < matches.Count; i++)
            {
                var match = matches[i];
                var blockStart = insertionStartIndex + match.Index - totalRemovedLength;
                var blockEnd = insertionStartIndex + (i < matches.Count - 1 ? matches[i + 1].Index : text.Length) - totalRemovedLength - match.Length;

                var ansiCode = match.Value;
                ProcessAnsiCode(ansiCode, ref currentColor, ref currentBackColor, ref currentStyle);

                formattedBlocks.Add(new AnsiColoringRichTextBoxFormatter(blockStart, blockEnd - blockStart, currentColor, currentBackColor, currentStyle));
                totalRemovedLength += match.Length;
            }

            var cleanText = regex.Replace(text, String.Empty);
            base.AppendText(cleanText);

            foreach (var formatter in formattedBlocks)
            {
                Select(formatter.Start, formatter.Length);
                SelectionColor = formatter.FontColor;
                SelectionBackColor = formatter.BackColor;
                SetSelectionFont(Font, formatter.Style);
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
                        currentColor = ForeColor;
                        currentBackColor = BackColor;
                        break;
                    case 28:
                        ForeColor = lastUsedFontColor;
                        break;
                    case 29: currentStyle &= ~FontStyle.Strikeout; break;

                    case 30: currentColor = Color.Black; break;
                    case 31: currentColor = Color.Red; break;
                    case 32: currentColor = Color.Green; break;
                    case 33: currentColor = Color.Yellow; break;
                    case 34: currentColor = Color.Blue; break;
                    case 35: currentColor = Color.Purple; break;
                    case 36: currentColor = Color.Cyan; break;
                    case 37: currentColor = Color.White; break;

                    case 40: currentBackColor = Color.Black; break;
                    case 41: currentBackColor = Color.Red; break;
                    case 42: currentBackColor = Color.Green; break;
                    case 43: currentBackColor = Color.Yellow; break;
                    case 44: currentBackColor = Color.Blue; break;
                    case 45: currentBackColor = Color.Purple; break;
                    case 46: currentBackColor = Color.Cyan; break;
                    case 47: currentBackColor = Color.White; break;

                    case 90: currentColor = Color.DarkGray; break;
                    case 91: currentColor = Color.LightCoral; break;
                    case 92: currentColor = Color.LightGreen; break;
                    case 93: currentColor = Color.Khaki; break;
                    case 94: currentColor = Color.LightBlue; break;
                    case 95: currentColor = Color.Plum; break;
                    case 96: currentColor = Color.LightCyan; break;
                    case 97: currentColor = Color.White; break;

                    case 100: currentBackColor = Color.DarkGray; break;
                    case 101: currentBackColor = Color.LightCoral; break;
                    case 102: currentBackColor = Color.LightGreen; break;
                    case 103: currentBackColor = Color.Khaki; break;
                    case 104: currentBackColor = Color.LightBlue; break;
                    case 105: currentBackColor = Color.Plum; break;
                    case 106: currentBackColor = Color.LightCyan; break;
                    case 107: currentBackColor = Color.White; break;
                }
            }
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
