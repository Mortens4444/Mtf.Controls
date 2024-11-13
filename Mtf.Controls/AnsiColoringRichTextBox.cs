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
        private const string AnsiPattern = @"\x1B\[[0-9;]*m";

        private bool displayAnsiColors;

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
                    ApplyAnsiColoring();
                }
                else
                {
                    ClearColoring();
                }
            }
        }

        public AnsiColoringRichTextBox()
        {
            DisplayAnsiColors = true;
        }

        private void ApplyAnsiColoring()
        {
            if (!DisplayAnsiColors)
            {
                return;
            }

            var ansiColorMap = new Dictionary<string, Color>
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

            var ansiBoldMap = new Dictionary<string, bool>
            {
                { "\x1B[1;30m", true }, { "\x1B[1;31m", true }, { "\x1B[1;32m", true }, { "\x1B[1;33m", true },
                { "\x1B[1;34m", true }, { "\x1B[1;35m", true }, { "\x1B[1;36m", true }, { "\x1B[1;37m", true }
            };

            var ansiUnderlineMap = new Dictionary<string, bool>
            {
                { "\x1B[4;30m", true }, { "\x1B[4;31m", true }, { "\x1B[4;32m", true }, { "\x1B[4;33m", true },
                { "\x1B[4;34m", true }, { "\x1B[4;35m", true }, { "\x1B[4;36m", true }, { "\x1B[4;37m", true }
            };



            var regex = new Regex(AnsiPattern);
            var matches = regex.Matches(Text);

            var lastIndex = 0;
            Clear();

            foreach (Match match in matches)
            {
                if (match.Index > lastIndex)
                {
                    AppendText(Text.Substring(lastIndex, match.Index - lastIndex));
                }

                var ansiCode = match.Value;
                var color = Color.Black;
                var bold = false;
                var underline = false;

                if (ansiColorMap.TryGetValue(ansiCode, out var ansiColor))
                {
                    color = ansiColor;
                }
                if (ansiBoldMap.TryGetValue(ansiCode, out var isBold))
                {
                    bold = isBold;
                }
                if (ansiUnderlineMap.TryGetValue(ansiCode, out var isUnderline))
                {
                    underline = isUnderline;
                }
                SelectionStart = Text.Length;
                SelectionColor = color;
                SelectionFont = new Font(Font, (bold ? FontStyle.Bold : FontStyle.Regular) | (underline ? FontStyle.Underline : FontStyle.Regular));
                lastIndex = match.Index + match.Length;
            }

            if (lastIndex < Text.Length)
            {
                AppendText(Text.Substring(lastIndex));
            }

            SelectionColor = Color.Black;
            SelectionFont = new Font(Font, FontStyle.Regular);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (DisplayAnsiColors)
            {
                ApplyAnsiColoring();
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
