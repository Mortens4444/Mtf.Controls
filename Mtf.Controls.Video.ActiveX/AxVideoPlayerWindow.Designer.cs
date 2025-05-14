namespace Mtf.Controls.Video.ActiveX
{
    partial class AxVideoPlayerWindow
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AxVideoPlayerWindow));
            pictureBox = new System.Windows.Forms.PictureBox();
            axVideoPicture = new AxVIDEOCONTROL4Lib.AxVideoPicture();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axVideoPicture).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.BackgroundImage = Properties.Resources.NoSignal;
            pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox.Location = new System.Drawing.Point(0, 0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(425, 297);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            // 
            // axVideoPicture
            // 
            axVideoPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            axVideoPicture.Enabled = true;
            axVideoPicture.Location = new System.Drawing.Point(0, 0);
            axVideoPicture.Name = "axVideoPicture";
            axVideoPicture.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("axVideoPicture.OcxState");
            axVideoPicture.Size = new System.Drawing.Size(425, 297);
            axVideoPicture.TabIndex = 2;
            // 
            // AxVideoPlayerWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Controls.Add(axVideoPicture);
            Controls.Add(pictureBox);
            Name = "AxVideoPlayerWindow";
            Size = new System.Drawing.Size(425, 297);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)axVideoPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox;
        private AxVIDEOCONTROL4Lib.AxVideoPicture axVideoPicture;
    }
}
