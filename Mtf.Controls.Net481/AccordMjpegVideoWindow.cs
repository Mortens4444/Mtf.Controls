﻿using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Net481
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(AccordMjpegVideoWindow), "Resources.VideoSource.png")]
    public partial class AccordMjpegVideoWindow : PictureBox
    {
        private AccordMjpeg accordMjpeg;

        public AccordMjpegVideoWindow()
        {
            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;
            accordMjpeg = new AccordMjpeg(this);
        }

        /// <summary>
        /// Starts the stream.
        /// </summary>
        /// <param name="resource">Resource is an URI.</param>
        public void Start(string resource)
        {
            accordMjpeg.Start(resource);
        }

        public void SetCredentials(string userName, string password)
        {
            accordMjpeg?.SetCredentials(userName, password);
        }

        public void Stop()
        {
            accordMjpeg.Stop();
        }
    }
}