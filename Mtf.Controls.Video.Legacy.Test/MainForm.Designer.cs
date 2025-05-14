using System;

namespace Mtf.Controls.Video.Legacy.Test
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.accordJpegVideoWindow1 = new Mtf.Controls.Video.Legacy.AccordJpegVideoWindow();
            this.accordMjpegVideoWindow1 = new Mtf.Controls.Video.Legacy.AccordMjpegVideoWindow();
            this.accordScreenCaptureWindow1 = new Mtf.Controls.Video.Legacy.AccordScreenCaptureWindow();
            this.aForgeJpegVideoWindow1 = new Mtf.Controls.Video.Legacy.AForgeJpegVideoWindow();
            this.aForgeMjpegVideoWindow1 = new Mtf.Controls.Video.Legacy.AForgeMjpegVideoWindow();
            this.aForgeScreenCaptureWindow1 = new Mtf.Controls.Video.Legacy.AForgeScreenCaptureWindow();
            this.aForgeVideoCaptureDeviceWindow1 = new Mtf.Controls.Video.Legacy.AForgeVideoCaptureDeviceWindow();
            ((System.ComponentModel.ISupportInitialize)(this.accordJpegVideoWindow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordMjpegVideoWindow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordScreenCaptureWindow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aForgeJpegVideoWindow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aForgeMjpegVideoWindow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aForgeScreenCaptureWindow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aForgeVideoCaptureDeviceWindow1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 278);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // accordJpegVideoWindow1
            // 
            this.accordJpegVideoWindow1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("accordJpegVideoWindow1.BackgroundImage")));
            this.accordJpegVideoWindow1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.accordJpegVideoWindow1.Location = new System.Drawing.Point(12, 12);
            this.accordJpegVideoWindow1.Name = "accordJpegVideoWindow1";
            this.accordJpegVideoWindow1.Size = new System.Drawing.Size(206, 113);
            this.accordJpegVideoWindow1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.accordJpegVideoWindow1.TabIndex = 3;
            this.accordJpegVideoWindow1.TabStop = false;
            // 
            // accordMjpegVideoWindow1
            // 
            this.accordMjpegVideoWindow1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("accordMjpegVideoWindow1.BackgroundImage")));
            this.accordMjpegVideoWindow1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.accordMjpegVideoWindow1.Location = new System.Drawing.Point(489, -2);
            this.accordMjpegVideoWindow1.Name = "accordMjpegVideoWindow1";
            this.accordMjpegVideoWindow1.Size = new System.Drawing.Size(172, 83);
            this.accordMjpegVideoWindow1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.accordMjpegVideoWindow1.TabIndex = 4;
            this.accordMjpegVideoWindow1.TabStop = false;
            // 
            // accordScreenCaptureWindow1
            // 
            this.accordScreenCaptureWindow1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("accordScreenCaptureWindow1.BackgroundImage")));
            this.accordScreenCaptureWindow1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.accordScreenCaptureWindow1.Location = new System.Drawing.Point(475, 87);
            this.accordScreenCaptureWindow1.Name = "accordScreenCaptureWindow1";
            this.accordScreenCaptureWindow1.RecordingArea = new System.Drawing.Rectangle(0, 0, 2560, 1080);
            this.accordScreenCaptureWindow1.Size = new System.Drawing.Size(206, 92);
            this.accordScreenCaptureWindow1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.accordScreenCaptureWindow1.TabIndex = 5;
            this.accordScreenCaptureWindow1.TabStop = false;
            // 
            // aForgeJpegVideoWindow1
            // 
            this.aForgeJpegVideoWindow1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("aForgeJpegVideoWindow1.BackgroundImage")));
            this.aForgeJpegVideoWindow1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.aForgeJpegVideoWindow1.Location = new System.Drawing.Point(263, 87);
            this.aForgeJpegVideoWindow1.Name = "aForgeJpegVideoWindow1";
            this.aForgeJpegVideoWindow1.Size = new System.Drawing.Size(206, 92);
            this.aForgeJpegVideoWindow1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.aForgeJpegVideoWindow1.TabIndex = 6;
            this.aForgeJpegVideoWindow1.TabStop = false;
            // 
            // aForgeMjpegVideoWindow1
            // 
            this.aForgeMjpegVideoWindow1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("aForgeMjpegVideoWindow1.BackgroundImage")));
            this.aForgeMjpegVideoWindow1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.aForgeMjpegVideoWindow1.Location = new System.Drawing.Point(12, 156);
            this.aForgeMjpegVideoWindow1.Name = "aForgeMjpegVideoWindow1";
            this.aForgeMjpegVideoWindow1.Size = new System.Drawing.Size(206, 116);
            this.aForgeMjpegVideoWindow1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.aForgeMjpegVideoWindow1.TabIndex = 7;
            this.aForgeMjpegVideoWindow1.TabStop = false;
            // 
            // aForgeScreenCaptureWindow1
            // 
            this.aForgeScreenCaptureWindow1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("aForgeScreenCaptureWindow1.BackgroundImage")));
            this.aForgeScreenCaptureWindow1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.aForgeScreenCaptureWindow1.Location = new System.Drawing.Point(263, 185);
            this.aForgeScreenCaptureWindow1.Name = "aForgeScreenCaptureWindow1";
            this.aForgeScreenCaptureWindow1.RecordingArea = new System.Drawing.Rectangle(0, 0, 2560, 1080);
            this.aForgeScreenCaptureWindow1.Size = new System.Drawing.Size(206, 116);
            this.aForgeScreenCaptureWindow1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.aForgeScreenCaptureWindow1.TabIndex = 8;
            this.aForgeScreenCaptureWindow1.TabStop = false;
            // 
            // aForgeVideoCaptureDeviceWindow1
            // 
            this.aForgeVideoCaptureDeviceWindow1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("aForgeVideoCaptureDeviceWindow1.BackgroundImage")));
            this.aForgeVideoCaptureDeviceWindow1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.aForgeVideoCaptureDeviceWindow1.Location = new System.Drawing.Point(475, 185);
            this.aForgeVideoCaptureDeviceWindow1.Name = "aForgeVideoCaptureDeviceWindow1";
            this.aForgeVideoCaptureDeviceWindow1.Size = new System.Drawing.Size(206, 116);
            this.aForgeVideoCaptureDeviceWindow1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.aForgeVideoCaptureDeviceWindow1.TabIndex = 9;
            this.aForgeVideoCaptureDeviceWindow1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 313);
            this.Controls.Add(this.aForgeVideoCaptureDeviceWindow1);
            this.Controls.Add(this.aForgeScreenCaptureWindow1);
            this.Controls.Add(this.aForgeMjpegVideoWindow1);
            this.Controls.Add(this.aForgeJpegVideoWindow1);
            this.Controls.Add(this.accordScreenCaptureWindow1);
            this.Controls.Add(this.accordMjpegVideoWindow1);
            this.Controls.Add(this.accordJpegVideoWindow1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.accordJpegVideoWindow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordMjpegVideoWindow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordScreenCaptureWindow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aForgeJpegVideoWindow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aForgeMjpegVideoWindow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aForgeScreenCaptureWindow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aForgeVideoCaptureDeviceWindow1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private AccordJpegVideoWindow accordJpegVideoWindow1;
        private AccordMjpegVideoWindow accordMjpegVideoWindow1;
        private AccordScreenCaptureWindow accordScreenCaptureWindow1;
        private AForgeJpegVideoWindow aForgeJpegVideoWindow1;
        private AForgeMjpegVideoWindow aForgeMjpegVideoWindow1;
        private AForgeScreenCaptureWindow aForgeScreenCaptureWindow1;
        private AForgeVideoCaptureDeviceWindow aForgeVideoCaptureDeviceWindow1;
    }
}

