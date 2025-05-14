
namespace Mtf.Controls.Video.ActiveX.Test
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            axVideoPlayerWindow1 = new AxVideoPlayerWindow();
            SuspendLayout();
            // 
            // axVideoPlayerWindow1
            // 
            axVideoPlayerWindow1.BackgroundImageLayout = ImageLayout.Stretch;
            axVideoPlayerWindow1.Dock = DockStyle.Fill;
            axVideoPlayerWindow1.Location = new Point(0, 0);
            axVideoPlayerWindow1.Name = "axVideoPlayerWindow1";
            axVideoPlayerWindow1.Size = new Size(800, 450);
            axVideoPlayerWindow1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(axVideoPlayerWindow1);
            Name = "MainForm";
            Text = "MainForm";
            FormClosing += this.MainForm_FormClosing;
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private AxVideoPlayerWindow axVideoPlayerWindow1;
    }
}
