using AxVIDEOCONTROL4Lib;
using Mtf.Controls.x86.Extensions;
using Mtf.MessageBoxes;
using System;
using System.Threading;

namespace Mtf.Controls.x86
{
    public class AxVideoPlayer : IDisposable
    {
        private int disposed;
        //private static int numberOfControl = 1;
        private AxVideoPicture originalAxVideoPicture;
        private AxVideoPlayerWindow axVideoPlayerWindow;

        public AxVideoPicture AxVideoPicture { get; private set; }

        public event EventHandler FrameArrived;
        public event EventHandler Connected;
        public event EventHandler Disconnected;
        public event EventHandler<_DVideoPictureEvents_onConnectFailedEvent> ConnectFailed;
        public event EventHandler<_DVideoPictureEvents_onErrorEvent> ErrorOccurred;

        private string ipAddress;
        private string camera;
        private string username;
        private string password;

        public AxVideoPlayer(AxVideoPlayerWindow axVideoPlayerWindow)
        {
            //if (axVideoPlayerWindow == null)
            //{
            //    throw new ArgumentNullException(nameof(axVideoPlayerWindow));
            //}
            this.axVideoPlayerWindow = axVideoPlayerWindow ?? throw new ArgumentNullException(nameof(axVideoPlayerWindow));

            try
            {
                AxVideoPicture = axVideoPlayerWindow.AxVideoPicture;
                //originalAxVideoPicture = axVideoPlayerWindow.AxVideoPicture;//CreateAxVideoPicture();
                //AxVideoPicture = originalAxVideoPicture.Recreate();
                //axVideoPlayerWindow.Controls.Add(AxVideoPicture);
                //AxVideoPicture.Visible = true;
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        ~AxVideoPlayer()
        {
            Dispose(false);
        }

        //private AxVideoPicture CreateAxVideoPicture()
        //{
        //    var resources = new ComponentResourceManager(typeof(AxVideoPlayer));
        //    var result = new AxVideoPicture
        //    {
        //        Dock = DockStyle.Fill,
        //        Enabled = true,
        //        Location = new Point(0, 0),
        //        Name = String.Concat("axVideoPicture_", numberOfControl++),
        //        Tag = this,
        //        Visible = true
        //    };
        //    ((ISupportInitialize)result).BeginInit();
        //    axVideoPlayerWindow.Controls.Add(result);
        //    result.OcxState = ((AxHost.State)(resources.GetObject("axVideoPicture.OcxState")));
        //    ((ISupportInitialize)result).EndInit();
        //    return result;
        //}

        public void Start(string ipAddress, string camera, string username, string password)
        {
            this.ipAddress = ipAddress;
            this.camera = camera;
            this.username = username;
            this.password = password;

            SubscribeToEvents();
            _ = AxVideoPicture?.Connect(ipAddress, camera, username, password);
        }

        public void Stop()
        {
            try
            {
                UnsubscribeFromEvents();
                if (AxVideoPicture?.IsHandleCreated ?? false)
                {
                    if (AxVideoPicture.IsConnected())
                    {
                        _ = AxVideoPicture.Disconnect();
                    }
                }
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void SubscribeToEvents()
        {
            if (AxVideoPicture != null)
            {
                AxVideoPicture.onError += AxVideoPicture_onError;
                AxVideoPicture.onConnect += AxVideoPicture_onConnect;
                AxVideoPicture.onConnectFailed += AxVideoPicture_onConnectFailed;
                AxVideoPicture.onDisconnect += AxVideoPicture_onDisconnect;
                AxVideoPicture.NewPicture += AxVideoPicture_NewPicture;
            }
        }

        private void UnsubscribeFromEvents()
        {
            if (AxVideoPicture != null)
            {
                AxVideoPicture.onError -= AxVideoPicture_onError;
                AxVideoPicture.onConnect -= AxVideoPicture_onConnect;
                AxVideoPicture.onConnectFailed -= AxVideoPicture_onConnectFailed;
                AxVideoPicture.onDisconnect -= AxVideoPicture_onDisconnect;
                AxVideoPicture.NewPicture -= AxVideoPicture_NewPicture;
            }
        }

        private void AxVideoPicture_NewPicture(object sender, EventArgs e)
        {
            AxVideoPicture.Visible = true;
            OnFrameArrived();
        }

        private void AxVideoPicture_onDisconnect(object sender, EventArgs e)
        {
            AxVideoPicture.Visible = false;
            OnDisconnect();
        }

        private void AxVideoPicture_onConnectFailed(object sender, _DVideoPictureEvents_onConnectFailedEvent e)
        {
            AxVideoPicture.Visible = false;
            OnConnectFailed(e);
        }

        private void AxVideoPicture_onConnect(object sender, EventArgs e)
        {
            AxVideoPicture.Visible = true;
            OnConnect();
        }

        private void AxVideoPicture_onError(object sender, _DVideoPictureEvents_onErrorEvent e)
        {
            OnError(e);
        }

        protected virtual void OnFrameArrived()
        {
            FrameArrived?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDisconnect()
        {
            Disconnected?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnConnect()
        {
            Connected?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnConnectFailed(_DVideoPictureEvents_onConnectFailedEvent e)
        {
            ConnectFailed?.Invoke(this, e);
        }

        protected virtual void OnError(_DVideoPictureEvents_onErrorEvent e)
        {
            ErrorOccurred?.Invoke(this, e);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (Interlocked.Exchange(ref disposed, 1) != 0)
            {
                return;
            }

            if (disposing)
            {
                Stop();
                AxVideoPicture?.Dispose();
            }
        }
    }
}
