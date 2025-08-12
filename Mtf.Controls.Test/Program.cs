using Mtf.Controls.Video.Sunell.IPR67;
using System;
using System.Windows.Forms;

namespace Mtf.Controls.Test
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
#if NETFRAMEWORK
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#else
            ApplicationConfiguration.Initialize();
#endif
            SunellVideoWindow.SdkInit();

            using (var mainForm = new MainForm())
            {
                Application.Run(mainForm);
            }

            SunellVideoWindow.SdkQuit();
        }
    }
}