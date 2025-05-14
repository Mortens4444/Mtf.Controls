using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mtf.Controls.Video.Legacy.Test
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //accordJpegVideoWindow1.Start("");
            //aForgeJpegVideoWindow1.Start("");
            accordMjpegVideoWindow1.Start("http://takemotopiano.aa1.netvolante.jp:8190/nphMotionJpeg?Resolution=640x480&Quality=Standard&Framerate=30");
            aForgeMjpegVideoWindow1.Start("http://takemotopiano.aa1.netvolante.jp:8190/nphMotionJpeg?Resolution=640x480&Quality=Standard&Framerate=30");
            accordScreenCaptureWindow1.Start();
            aForgeScreenCaptureWindow1.Start();
            aForgeVideoCaptureDeviceWindow1.Start("@device:pnp:\\\\?\\usb#vid_0408&pid_a061&mi_00#6&7b94699&0&0000#{65e8773d-8f56-11d0-a3b9-00a0c9223196}\\global");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //accordJpegVideoWindow1.Stop();
            //aForgeJpegVideoWindow1.Stop();
            accordMjpegVideoWindow1.Stop();
            aForgeMjpegVideoWindow1.Stop();
            accordScreenCaptureWindow1.Stop();
            aForgeScreenCaptureWindow1.Stop();
            aForgeVideoCaptureDeviceWindow1.Stop();
        }
    }
}
