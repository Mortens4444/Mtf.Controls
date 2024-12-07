using System.Windows.Forms;

namespace Mtf.Controls
{
    partial class RichTextBoxWithLineNumbers
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cmsMenu = new ContextMenuStrip(components);
            tsmiCut = new ToolStripMenuItem();
            tsmiCopy = new ToolStripMenuItem();
            tsmiPaste = new ToolStripMenuItem();
            pMain = new TransparentPanel();
            rtbTextAreaUnseenAble = new SourceCodeViewerRichTextBox();
            rtbTextArea = new SourceCodeViewerRichTextBox();
            splitter = new Splitter();
            pLineNumbers = new TransparentPanel();
            cmsMenu.SuspendLayout();
            pMain.SuspendLayout();
            SuspendLayout();
            // 
            // cmsMenu
            // 
            cmsMenu.Items.AddRange(new ToolStripItem[] { tsmiCut, tsmiCopy, tsmiPaste });
            cmsMenu.Name = "contextMenuStrip1";
            cmsMenu.Size = new System.Drawing.Size(103, 70);
            // 
            // tsmiCut
            // 
            tsmiCut.Name = "tsmiCut";
            tsmiCut.Size = new System.Drawing.Size(102, 22);
            tsmiCut.Text = "Cut";
            tsmiCut.Click += TsmiCut_Click;
            // 
            // tsmiCopy
            // 
            tsmiCopy.Name = "tsmiCopy";
            tsmiCopy.Size = new System.Drawing.Size(102, 22);
            tsmiCopy.Text = "Copy";
            tsmiCopy.Click += TsmiCopy_Click;
            // 
            // tsmiPaste
            // 
            tsmiPaste.Name = "tsmiPaste";
            tsmiPaste.Size = new System.Drawing.Size(102, 22);
            tsmiPaste.Text = "Paste";
            tsmiPaste.Click += TsmiPaste_Click;
            // 
            // pMain
            // 
            pMain.Controls.Add(rtbTextAreaUnseenAble);
            pMain.Controls.Add(rtbTextArea);
            pMain.Controls.Add(splitter);
            pMain.Controls.Add(pLineNumbers);
            pMain.Dock = DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(612, 366);
            pMain.TabIndex = 0;
            pMain.TransparentColor = System.Drawing.Color.Black;
            pMain.UseTransparentColor = false;
            // 
            // rtbTextAreaUnseenAble
            // 
            rtbTextAreaUnseenAble.AcceptsTab = true;
            rtbTextAreaUnseenAble.BorderStyle = BorderStyle.None;
            rtbTextAreaUnseenAble.ColoringMethod = Enums.ColoringMethod.No_Coloring;
            rtbTextAreaUnseenAble.DetectUrls = false;
            rtbTextAreaUnseenAble.Dock = DockStyle.Fill;
            rtbTextAreaUnseenAble.Location = new System.Drawing.Point(64, 0);
            rtbTextAreaUnseenAble.Margin = new Padding(4, 3, 4, 3);
            rtbTextAreaUnseenAble.Name = "rtbTextAreaUnseenAble";
            rtbTextAreaUnseenAble.ScroolToLastLine = false;
            rtbTextAreaUnseenAble.Size = new System.Drawing.Size(548, 366);
            rtbTextAreaUnseenAble.TabIndex = 3;
            rtbTextAreaUnseenAble.Text = "";
            rtbTextAreaUnseenAble.Visible = false;
            // 
            // rtbTextArea
            // 
            rtbTextArea.AcceptsTab = true;
            rtbTextArea.BorderStyle = BorderStyle.None;
            rtbTextArea.ColoringMethod = Enums.ColoringMethod.No_Coloring;
            rtbTextArea.DetectUrls = false;
            rtbTextArea.Dock = DockStyle.Fill;
            rtbTextArea.Location = new System.Drawing.Point(64, 0);
            rtbTextArea.Margin = new Padding(4, 3, 4, 3);
            rtbTextArea.Name = "rtbTextArea";
            rtbTextArea.ScroolToLastLine = false;
            rtbTextArea.Size = new System.Drawing.Size(548, 366);
            rtbTextArea.TabIndex = 2;
            rtbTextArea.Text = "";
            rtbTextArea.VScroll += RtbTextArea_VScroll;
            rtbTextArea.ClientSizeChanged += RtbTextArea_ClientSizeChanged;
            rtbTextArea.TextChanged += RtbTextArea_TextChanged;
            // 
            // splitter
            // 
            splitter.Location = new System.Drawing.Point(63, 0);
            splitter.Margin = new Padding(4, 3, 4, 3);
            splitter.Name = "splitter";
            splitter.Size = new System.Drawing.Size(1, 366);
            splitter.TabIndex = 1;
            splitter.TabStop = false;
            // 
            // pLineNumbers
            // 
            pLineNumbers.Dock = DockStyle.Left;
            pLineNumbers.Location = new System.Drawing.Point(0, 0);
            pLineNumbers.Margin = new Padding(4, 3, 4, 3);
            pLineNumbers.Name = "pLineNumbers";
            pLineNumbers.Size = new System.Drawing.Size(63, 366);
            pLineNumbers.TabIndex = 0;
            pLineNumbers.TransparentColor = System.Drawing.Color.Black;
            pLineNumbers.UseTransparentColor = false;
            pLineNumbers.Paint += LineNumbers_Paint;
            // 
            // RichTextBoxWithLineNumbers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pMain);
            Margin = new Padding(4, 3, 4, 3);
            Name = "RichTextBoxWithLineNumbers";
            Size = new System.Drawing.Size(612, 366);
            FontChanged += RTBWLN_FontChanged;
            cmsMenu.ResumeLayout(false);
            pMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TransparentPanel pMain;
        private SourceCodeViewerRichTextBox rtbTextArea;
        private System.Windows.Forms.Splitter splitter;
        private TransparentPanel pLineNumbers;
        private ContextMenuStrip cmsMenu;
        private ToolStripMenuItem tsmiCut;
        private ToolStripMenuItem tsmiCopy;
        private ToolStripMenuItem tsmiPaste;
        private SourceCodeViewerRichTextBox rtbTextAreaUnseenAble;
    }
}
