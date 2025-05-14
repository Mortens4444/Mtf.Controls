using AxVIDEOCONTROL4Lib;
using Mtf.MessageBoxes;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Mtf.Controls.Video.ActiveX
{
    public class AxVideoPlayer : IDisposable
    {
        private int disposed;
        //private static int numberOfControl = 1;
        //private AxVideoPicture originalAxVideoPicture;
        private readonly AxVideoPlayerWindow axVideoPlayerWindow;

        public event EventHandler FrameArrived;
        public event EventHandler Connected;
        public event EventHandler Disconnected;
        public event EventHandler<_DVideoPictureEvents_onConnectFailedEvent> ConnectFailed;
        public event EventHandler<_DVideoPictureEvents_onErrorEvent> ErrorOccurred;

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
                throw;
            }
        }

        public AxVideoPicture AxVideoPicture { get; private set; }

        public string IpAddress { get; private set; }

        public string Camera { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public short? Light
        {
            get
            {
                return AxVideoPicture?.Light;
            }
            set
            {
                if (AxVideoPicture != null && value.HasValue)
                {
                    AxVideoPicture.Light = value.Value;
                }
            }
        }

        public short? Millisec
        {
            get
            {
                return AxVideoPicture?.Millisec;
            }
            set
            {
                if (AxVideoPicture != null && value.HasValue)
                {
                    AxVideoPicture.Millisec = value.Value;
                }
            }
        }

        public short? Motion
        {
            get
            {
                return AxVideoPicture?.Motion;
            }
            set
            {
                if (AxVideoPicture != null && value.HasValue)
                {
                    AxVideoPicture.Motion = value.Value;
                }
            }
        }

        public bool? OSD
        {
            get
            {
                return AxVideoPicture?.OSD;
            }
            set
            {
                if (AxVideoPicture != null && value.HasValue)
                {
                    AxVideoPicture.OSD = value.Value;
                }
            }
        }

        public short? PlayStatus
        {
            get
            {
                return AxVideoPicture?.PlayStatus;
            }
            set
            {
                if (AxVideoPicture != null && value.HasValue)
                {
                    AxVideoPicture.PlayStatus = value.Value;
                }
            }
        }

        public Image Image
        {
            get
            {
                return AxVideoPicture?.Picture;
            }
            set
            {
                if (AxVideoPicture != null)
                {
                    AxVideoPicture.Picture = value;
                }
            }
        }

        public bool? DisplayImage
        {
            get
            {
                return AxVideoPicture?.DisplayPicture;
            }
            set
            {
                if (AxVideoPicture != null && value.HasValue)
                {
                    AxVideoPicture.DisplayPicture = value.Value;
                }
            }
        }

        public bool? ShowDateTime
        {
            get
            {
                return AxVideoPicture?.ShowDateTime;
            }
            set
            {
                if (AxVideoPicture != null && value.HasValue)
                {
                    AxVideoPicture.ShowDateTime = value.Value;
                }
            }
        }

        public short? Speed
        {
            get
            {
                return AxVideoPicture?.Speed;
            }
            set
            {
                if (AxVideoPicture != null && value.HasValue)
                {
                    AxVideoPicture.Speed = value.Value;
                }
            }
        }

        public DateTime? Time
        {
            get
            {
                if (AxVideoPicture == null)
                {
                    return null;
                }

                var time = AxVideoPicture.Time;
                return new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, AxVideoPicture.Millisec, time.Kind);
            }
            set
            {
                if (AxVideoPicture != null && value.HasValue)
                {
                    AxVideoPicture.Time = value.Value;
                }
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
            InitStart(ipAddress, camera, username, password);
            _ = AxVideoPicture?.Connect(ipAddress, camera, username, password);
        }

        public async void StartAsync(string ipAddress, string camera, string username, string password, CancellationToken cancellationToken)
        {
            InitStart(ipAddress, camera, username, password);
            try
            {
                await Task.Run(() => AxVideoPicture?.Connect(ipAddress, camera, username, password), cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException) { }
        }

        public int? CameraFocus(short focusSpeed)
        {
            return AxVideoPicture?.CameraFocus(focusSpeed);
        }

        public int? CameraGoToPreset(int presetNumber)
        {
            return AxVideoPicture?.CameraGoToPreset(presetNumber);
        }

        public int? CameraIris(short irisSpeed)
        {
            return AxVideoPicture?.CameraIris(irisSpeed);
        }

        public int? CameraMove(short upDown, short leftRight)
        {
            return AxVideoPicture?.CameraMove(upDown, leftRight);
        }

        public int? CameraRunPattern(short patternNumber, short repeat)
        {
            return AxVideoPicture?.CameraRunPattern(patternNumber, repeat);
        }

        public int? CameraStop()
        {
            return AxVideoPicture?.CameraStop();
        }

        public int? CameraZoom(short zoomSpeed)
        {
            return AxVideoPicture?.CameraZoom(zoomSpeed);
        }

        public void EnableDeblock(bool enable)
        {
            AxVideoPicture?.EnableDeblock(enable);
        }

        public void EnableThreading(bool enable)
        {
            AxVideoPicture?.EnableThreading(enable);
        }

        public int? Find(DateTime dateTime)
        {
            return AxVideoPicture?.Find(dateTime, (short)dateTime.Millisecond);
        }

        public bool First()
        {
            return AxVideoPicture?.First() ?? false;
        }

        public int? GetOcxVersion()
        {
            return AxVideoPicture?.GetOcxVersion();
        }

        public int? InitAudio(int windowHandle)
        {
            return AxVideoPicture?.InitAudio(windowHandle);
        }

        public bool? IsCameraControl()
        {
            return AxVideoPicture?.IsCameraControl();
        }

        public bool? IsConnected()
        {
            return AxVideoPicture?.IsConnected();
        }

        public bool? IsVideoSignal()
        {
            return AxVideoPicture?.IsVideoSignal();
        }

        public bool? Last()
        {
            return AxVideoPicture?.Last();
        }

        public bool? LiveVideo(int layer = 0, int frameRate = 25)
        {
            return AxVideoPicture?.LiveVideo(layer, frameRate);
        }

        public bool? Next()
        {
            return AxVideoPicture?.Next();
        }

        public bool? Play()
        {
            return AxVideoPicture?.Play();
        }

        public bool? PlayReverse()
        {
            return AxVideoPicture?.PlayReverse();
        }

        public bool? Prev()
        {
            return AxVideoPicture?.Prev();
        }

        public int? SaveAsBitmap(string filename, short width, short height, short mode, short osd = 1)
        {
            return AxVideoPicture?.SaveAsBMP(filename, width, height, mode, osd);
        }

        public int? SaveAsJpeg(string filename, short width, short height, short mode, short osd = 1, short quality = 100)
        {
            return AxVideoPicture?.SaveAsJPG(filename, width, height, mode, osd, quality);
        }

        public bool? StopAxVideoPicture()
        {
            return AxVideoPicture?.Stop();
        }

        public bool? WaitForConnect(int waitTimeInMs)
        {
            return AxVideoPicture?.WaitForConnect(waitTimeInMs);
        }

        public bool? WaitForDisconnect(int waitTimeInMs)
        {
            return AxVideoPicture?.WaitForDisconnect(waitTimeInMs);
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
                throw;
            }
        }

        private void InitStart(string ipAddress, string camera, string username, string password)
        {
            IpAddress = ipAddress;
            Camera = camera;
            Username = username;
            Password = password;

            SubscribeToEvents();
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

        protected virtual void Dispose(bool disposing)
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
