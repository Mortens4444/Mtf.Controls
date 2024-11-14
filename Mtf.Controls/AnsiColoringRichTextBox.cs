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
        private static readonly char[] separator = new char[] { '\n', '\n' };
        private const string AnsiPattern = @"\x1B\[[0-9;]*m";
        private bool isApplyingColoring;
        private bool displayAnsiColors;
        private int previousTextLength;

        private Dictionary<string, Color>  ansiColorMap = new Dictionary<string, Color>
        {
            // Regular Colors
            { "\x1B[0;30m", Color.Black }, { "\x1B[0;31m", Color.Red }, { "\x1B[0;32m", Color.Green },
            { "\x1B[0;33m", Color.Yellow }, { "\x1B[0;34m", Color.Blue }, { "\x1B[0;35m", Color.Purple },
            { "\x1B[0;36m", Color.Cyan }, { "\x1B[0;37m", Color.White },

            // Bold Colors
            { "\x1B[1;30m", Color.Black }, { "\x1B[1;31m", Color.Red }, { "\x1B[1;32m", Color.Green },
            { "\x1B[1;33m", Color.Yellow }, { "\x1B[1;34m", Color.Blue }, { "\x1B[1;35m", Color.Purple },
            { "\x1B[1;36m", Color.Cyan }, { "\x1B[1;37m", Color.White },

            // High Intensity Colors
            { "\x1B[0;90m", Color.DarkGray }, { "\x1B[0;91m", Color.LightCoral }, { "\x1B[0;92m", Color.LightGreen },
            { "\x1B[0;93m", Color.Khaki }, { "\x1B[0;94m", Color.LightBlue }, { "\x1B[0;95m", Color.Plum },
            { "\x1B[0;96m", Color.LightCyan }, { "\x1B[0;97m", Color.White },

            // Bold High Intensity Colors
            { "\x1B[1;90m", Color.DarkGray }, { "\x1B[1;91m", Color.Red }, { "\x1B[1;92m", Color.Lime },
            { "\x1B[1;93m", Color.Yellow }, { "\x1B[1;94m", Color.RoyalBlue }, { "\x1B[1;95m", Color.MediumOrchid },
            { "\x1B[1;96m", Color.Aqua }, { "\x1B[1;97m", Color.White }
        };

        private Dictionary<string, bool> ansiBoldMap = new Dictionary<string, bool>
        {
            { "\x1B[1;30m", true }, { "\x1B[1;31m", true }, { "\x1B[1;32m", true }, { "\x1B[1;33m", true },
            { "\x1B[1;34m", true }, { "\x1B[1;35m", true }, { "\x1B[1;36m", true }, { "\x1B[1;37m", true }
        };

        private Dictionary<string, bool> ansiUnderlineMap = new Dictionary<string, bool>
        {
            { "\x1B[4;30m", true }, { "\x1B[4;31m", true }, { "\x1B[4;32m", true }, { "\x1B[4;33m", true },
            { "\x1B[4;34m", true }, { "\x1B[4;35m", true }, { "\x1B[4;36m", true }, { "\x1B[4;37m", true }
        };

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Specifies if ANSI coloring is enabled or not.")]
        public bool DisplayAnsiColors
        {
            get => displayAnsiColors;
            set
            {
                displayAnsiColors = value;
                if (displayAnsiColors)
                {
                    ApplyAnsiColoring(previousTextLength);
                }
                else
                {
                    ClearColoring();
                }
            }
        }

        private void ApplyAnsiColoring(int startIndex)
        {
            if (!DisplayAnsiColors || isApplyingColoring)
            {
                return;
            }

            isApplyingColoring = true;

            var ansiColorMap = new Dictionary<string, Color>
            {
                { "\x1B[0;30m", Color.Black }, { "\x1B[0;31m", Color.Red }, { "\x1B[0;32m", Color.Green },
                { "\x1B[0;33m", Color.Yellow }, { "\x1B[0;34m", Color.Blue }, { "\x1B[0;35m", Color.Purple },
                { "\x1B[0;36m", Color.Cyan }, { "\x1B[0;37m", Color.White },
                { "\x1B[1;30m", Color.Black }, { "\x1B[1;31m", Color.Red }, { "\x1B[1;32m", Color.Green },
                { "\x1B[1;33m", Color.Yellow }, { "\x1B[1;34m", Color.Blue }, { "\x1B[1;35m", Color.Purple },
                { "\x1B[1;36m", Color.Cyan }, { "\x1B[1;37m", Color.White }
            };

            var ansiBoldMap = new Dictionary<string, bool> { { "\x1B[1;31m", true }, { "\x1B[1;32m", true } };
            var ansiUnderlineMap = new Dictionary<string, bool> { { "\x1B[4;30m", true }, { "\x1B[4;31m", true } };

            var regex = new Regex(AnsiPattern, RegexOptions.Compiled);
            var matches = regex.Matches(Text.Substring(startIndex));

            foreach (Match match in matches)
            {
                var ansiCode = match.Value;
                Select(startIndex + match.Index, match.Length);

                if (ansiColorMap.TryGetValue(ansiCode, out var color))
                {
                    SelectionColor = color;
                }

                if (ansiBoldMap.TryGetValue(ansiCode, out _))
                {
                    SelectionFont = new Font(Font, FontStyle.Bold);
                }

                if (ansiUnderlineMap.TryGetValue(ansiCode, out _))
                {
                    SelectionFont = new Font(Font, FontStyle.Underline);
                }
            }
            isApplyingColoring = false;
        }

        public new void AppendText(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return;
            }

            var parts = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts)
            {
                AppendTextPart(part);
            }
        }

        private void AppendTextPart(string text)
        {
            isApplyingColoring = true;

            var insertionStartIndex = TextLength;

            var regex = new Regex(AnsiPattern, RegexOptions.Compiled);
            var matches = regex.Matches(text);
            var formattedBlocks = new List<(int start, int length, Color? color, FontStyle style)>();

            var lastIndex = 0;
            Color? currentColor = ForeColor;
            var currentStyle = FontStyle.Regular;
            var totalRemovedLength = 0;

            for (var i = 0; i < matches.Count; i++)
            {
                var match = matches[i];
                var blockStart = insertionStartIndex + match.Index - totalRemovedLength;
                var blockEnd = insertionStartIndex + (i < matches.Count - 1 ? matches[i + 1].Index : text.Length) - totalRemovedLength - match.Length;

                var ansiCode = match.Value;
                if (ansiCode == "\u001b[0m")
                {
                    currentColor = ForeColor;
                    currentStyle = FontStyle.Regular;
                }
                else
                {
                    if (ansiColorMap.TryGetValue(ansiCode, out var ansiColor))
                    {
                        currentColor = ansiColor;
                    }
                    if (ansiBoldMap.TryGetValue(ansiCode, out var isBold))
                    {
                        currentStyle = isBold ? currentStyle | FontStyle.Bold : currentStyle & ~FontStyle.Bold;
                    }
                    if (ansiUnderlineMap.TryGetValue(ansiCode, out var isUnderline))
                    {
                        currentStyle = isUnderline ? currentStyle | FontStyle.Underline : currentStyle & ~FontStyle.Underline;
                    }
                }

                formattedBlocks.Add((blockStart, blockEnd - blockStart, currentColor, currentStyle));
                totalRemovedLength += match.Length;
            }

            var cleanText = regex.Replace(text, String.Empty);
            base.AppendText(cleanText);

            foreach (var (start, length, color, style) in formattedBlocks)
            {
                Select(start, length);
                SelectionColor = color ?? ForeColor;
                SelectionFont = new Font(Font, style);
            }

            isApplyingColoring = false;
        }

        public void ClearColoring()
        {
            SelectAll();
            SelectionColor = ForeColor;
            SelectionFont = Font;
        }
    }
}
