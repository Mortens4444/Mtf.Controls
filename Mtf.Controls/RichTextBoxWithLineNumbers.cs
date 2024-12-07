using Mtf.Controls.Enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(RichTextBoxWithLineNumbers), "Resources.SourceCodeViewerRichTextBox.png")]
    public partial class RichTextBoxWithLineNumbers : UserControl
    {
        private bool showLineNumbers;
        private bool embeddedContextMenuStrip;

        public RichTextBoxWithLineNumbers()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();

            ShowLineNumbers = true;
            WrapLines = false;
            EmbeddedContextMenuStrip = true;
            RichTextBoxForeColor = ForeColor;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Whether to show line number panels on the left.")]
        public bool ShowLineNumbers
        {
            get => showLineNumbers;
            set
            {
                showLineNumbers = value;
                pLineNumbers.Visible = showLineNumbers;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Back color of the control.")]
        public Color RichTextBoxBackColor
        {
            get => rtbTextArea.BackColor;
            set => rtbTextArea.BackColor = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Fore color of the control.")]
        public Color RichTextBoxForeColor
        {
            get => rtbTextArea.ForeColor;
            set => rtbTextArea.ForeColor = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Text of the control.")]
        public override string Text
        {
            get => rtbTextArea.GetTextThreadSafe();
            set => rtbTextArea.SetTextThreadSafe(value);
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Whether to wrap the lines.")]
        public bool WrapLines
        {
            get => rtbTextArea.WordWrap;
            set => rtbTextArea.WordWrap = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Use embedded context menu.")]
        public bool EmbeddedContextMenuStrip
        {
            get => embeddedContextMenuStrip;
            set
            {
                embeddedContextMenuStrip = value;
                if (value)
                {
                    rtbTextArea.ContextMenuStrip = cmsMenu;
                }
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Change the coloring mode of the control.")]
        public ColoringMethod ColoringMethod
        {
            get => rtbTextArea.ColoringMethod;
            set => rtbTextArea.ColoringMethod = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color of the selection.")]
        public Color SelectionColor
        {
            get => rtbTextArea.SelectionColor;
            set => rtbTextArea.SelectionColor = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Start of the selection.")]
        public int SelectionStart
        {
            get
            {
                try
                {
                    return rtbTextArea.SelectionStart;
                }
                catch (ArgumentOutOfRangeException)
                {
                    return -1;
                }
            }
            set => rtbTextArea.SelectionStart = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Length of the selection.")]
        public int SelectionLength
        {
            get => rtbTextArea.SelectionLength;
            set => rtbTextArea.SelectionLength = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Fore color of the control.")]
        public override Color ForeColor
        {
            get => rtbTextArea.ForeColor;
            set
            {
                rtbTextArea.ForeColor = value;
                pLineNumbers.ForeColor = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Background color of the control.")]
        public override Color BackColor
        {
            get
            => rtbTextArea.BackColor;
            set
            {
                rtbTextArea.BackColor = value;
                rtbTextAreaUnseenAble.BackColor = value;
                pLineNumbers.BackColor = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Text property of the cut menuitem.")]
        public string CutText
        {
            get => tsmiCut.Text;
            set => tsmiCut.Text = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Text property of the copy menuitem.")]
        public string CopyText
        {
            get => tsmiCopy.Text;
            set => tsmiCopy.Text = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Text property of the paste menuitem.")]
        public string PasteText
        {
            get => tsmiPaste.Text;
            set => tsmiPaste.Text = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Text context menu of the control.")]
        public override ContextMenuStrip ContextMenuStrip
        {
            get => rtbTextArea.ContextMenuStrip;
            set => rtbTextArea.ContextMenuStrip = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Whether the control is readonly.")]
        public bool ReadOnly
        {
            get => rtbTextArea.ReadOnly;
            set => rtbTextArea.ReadOnly = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Border style of the control.")]
        public new BorderStyle BorderStyle
        {
            get => rtbTextAreaUnseenAble.BorderStyle;
            set => UpdateBorderStyle(value);
        }

        private void UpdateBorderStyle(BorderStyle borderStyle)
        {
            pLineNumbers.BorderStyle = borderStyle;
            rtbTextArea.BorderStyle = borderStyle;
            rtbTextAreaUnseenAble.BorderStyle = borderStyle;
        }

        private void SetLineNumbers()
        {
            if (showLineNumbers)
            {
                pLineNumbers.Invalidate();
            }
        }

        private void RtbTextArea_TextChanged(object sender, EventArgs e)
        {
            rtbTextAreaUnseenAble.Text = "";
            var ss = rtbTextArea.SelectionStart;
            var sl = rtbTextArea.SelectionLength;
            rtbTextArea.SelectionStart = 0;
            rtbTextArea.SelectionLength = rtbTextArea.Text.Length;
            rtbTextAreaUnseenAble.SelectedRtf = rtbTextArea.SelectedRtf;
            rtbTextArea.SelectionStart = ss;
            rtbTextArea.SelectionLength = sl;
            SetLineNumbers();
        }

        private void RtbTextArea_VScroll(object sender, EventArgs e)
        {
            SetLineNumbers();
        }

        private void RtbTextArea_ClientSizeChanged(object sender, EventArgs e)
        {
            SetLineNumbers();
        }

        /// <summary>
        /// Save file in RTF format
        /// </summary>
        /// <param name="filename">Where to save the file</param>
        public void SaveToFile(string filename)
        {
            if (String.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentException("Filename cannot be null or empty.", nameof(filename));
            }

            try
            {
                rtbTextArea.SaveFile(filename, RichTextBoxStreamType.RichText);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to save the file.", ex);
            }
        }

        /// <summary>
        /// Load an RTF file
        /// </summary>
        /// <param name="filename">Where to save the file</param>
        public void LoadFromFile(string filename)
        {
            if (String.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentException("Filename cannot be null or empty.", nameof(filename));
            }

            try
            {
                rtbTextArea.LoadFile(filename, RichTextBoxStreamType.RichText);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to load the file.", ex);
            }
        }

        public void Select(int start, int length)
        {
            rtbTextArea.Select(start, length);
        }

        private void LineNumbers_Paint(object sender, PaintEventArgs e)
        {
            var firstCharIndex = rtbTextArea.GetCharIndexFromPosition(new Point(0, 0));
            var firstLineIndex = rtbTextArea.GetLineFromCharIndex(firstCharIndex);
            var fontHeight = rtbTextArea.Font.Height;

            var lineNumber = firstLineIndex + 1;
            var currentY = 0;

            using (var brush = new SolidBrush(ForeColor))
            {
                while (currentY < rtbTextArea.ClientSize.Height)
                {
                    e.Graphics.DrawString(lineNumber.ToString(), rtbTextArea.Font, brush, new Point(5, currentY));
                    currentY += fontHeight;
                    lineNumber++;
                }
            }
        }

        private void TsmiCut_Click(object sender, EventArgs e)
        {
            rtbTextArea.Cut();
        }

        private void TsmiCopy_Click(object sender, EventArgs e)
        {
            rtbTextArea.Copy();
        }

        private void TsmiPaste_Click(object sender, EventArgs e)
        {
            rtbTextArea.Paste();
        }

        private void RTBWLN_FontChanged(object sender, EventArgs e)
        {
            rtbTextAreaUnseenAble.Font = Font;
        }
    }
}
