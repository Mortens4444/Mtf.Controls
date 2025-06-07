namespace Mtf.Controls.Video.ActiveX
{
    partial class AxVideoPictureForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AxVideoPictureForm));
            this.axVideoPicture1 = new AxVIDEOCONTROL4Lib.AxVideoPicture();
            ((System.ComponentModel.ISupportInitialize)(this.axVideoPicture1)).BeginInit();
            this.SuspendLayout();
            // 
            // axVideoPicture1
            // 
            this.axVideoPicture1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axVideoPicture1.Enabled = true;
            this.axVideoPicture1.Location = new System.Drawing.Point(0, 0);
            this.axVideoPicture1.Name = "axVideoPicture1";
            this.axVideoPicture1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVideoPicture1.OcxState")));
            this.axVideoPicture1.Size = new System.Drawing.Size(800, 450);
            this.axVideoPicture1.TabIndex = 0;
            // 
            // AxVideoPictureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axVideoPicture1);
            this.Name = "AxVideoPictureForm";
            this.Text = "AxVideoPictureForm";
            this.Load += new System.EventHandler(this.AxVideoPictureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axVideoPicture1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxVIDEOCONTROL4Lib.AxVideoPicture axVideoPicture1;
    }
}