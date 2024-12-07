//using CefSharp;
//using CefSharp.WinForms;
////using Mtf.Controls.Net481.Interfaces;
//using System.ComponentModel;
//using System.Drawing;
//using System.Windows.Forms;

//namespace Mtf.Controls.x86
//{
//    [ToolboxItem(true)]
//    [ToolboxBitmap(typeof(ChromiumWindow), "Resources.VideoSource.png")]
//    public class ChromiumWindow : ChromiumWebBrowser//, IVideoPlayer
//    {
//        private bool disposed;

//        public ChromiumWindow()
//        {
//            BackgroundImage = Properties.Resources.NoSignal;
//            BackgroundImageLayout = ImageLayout.Stretch;
//            BackColor = Color.Black;
//            Dock = DockStyle.Fill;
//            this.MenuHandler = new CustomContextMenuHandler();
//            this.DisposeDevToolsContext();
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposed)
//            {
//                return;
//            }

//            if (disposing)
//            {
//                MenuHandler = null;
//                Stop();
//                Dispose();
//            }
//            base.Dispose(disposing);
//            disposed = true;
//        }

//        /// <summary>
//        /// Starts the stream.
//        /// </summary>
//        /// <param name="resource">Resource is an URI.</param>
//        public void Start(string resource)
//        {
//            if (IsAlive())
//            {
//                var htmlContent = $@"<html><body style='margin:0;background-color: black !important;'><img src='{resource}' style='width:100vw;height:100vh;object-fit:cover;' /></body></html>";
//                this.LoadHtml(htmlContent);
//            }
//        }

//        public void Stop()
//        {
//            if (IsAlive())
//            {
//                LoadUrl("about:blank");
//            }
//        }

//        private bool IsAlive()
//        {
//            return !IsDisposed;
//        }
//    }

//    internal class CustomContextMenuHandler : IContextMenuHandler
//    {
//        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
//        {
//            model.Clear();
//        }

//        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
//        {
//            return false;
//        }

//        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
//        {
//        }

//        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
//        {
//            return false;
//        }
//    }
//}
