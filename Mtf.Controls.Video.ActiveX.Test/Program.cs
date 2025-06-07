using System;
using System.Windows.Forms;

namespace Mtf.Controls.Video.ActiveX.Test
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AxVideoPictureForm());
            //Application.Run(new MainForm());
        }
    }
}