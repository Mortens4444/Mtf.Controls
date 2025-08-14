using Mtf.Controls.Interfaces;
using Mtf.Controls.Video.Sunell.IPR67.Enums;
using Mtf.Controls.Video.Sunell.IPR67.SunellSdk;
using Mtf.MessageBoxes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mtf.Controls.Video.Sunell.IPR67
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(SunellVideoWindow), "Resources.VideoSource.png")]
    public class SunellVideoWindow : PictureBox, IVideoWindow
    {
        //private Sdk.SDK_PLAY_TIME_CB playTimeCallback;
        //private Sdk.SDK_DISCONN_CB disconnectCallback;

        private GCHandle? thisHandleGch;
        private Sdk.SDK_DISCONN_CB disconnDelegate;
        private Sdk.SDK_PLAY_TIME_CB playTimeDelegate;
        private IntPtr sdkHandler = IntPtr.Zero;
        private int streamId = -1;
        private int channel;
        private int rotateSpeed = 50;

        public const int NoSdkHandler = -3;
        public const int NoStream = -1;
        public const int NoPermission = -2;

        public SunellVideoWindow() : this(50) { }

        public SunellVideoWindow(int rotateSpeed)
        {
            this.rotateSpeed = rotateSpeed;

            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();

            //playTimeCallback = new Sdk.SDK_PLAY_TIME_CB(PlayTimeCallback);
            //disconnectCallback = new Sdk.SDK_DISCONN_CB(DisconnectCallback);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        Disconnect();
        //    }
        //    base.Dispose(disposing);
        //}

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Text to be displayed on the control.")]
        public string OverlayText { get; set; } = String.Empty;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Font type of the text to be displayed on the control.")]
        public Font OverlayFont { get; set; } = new Font("Arial", 32, FontStyle.Bold);

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color of the text to be displayed on the control.")]
        public Brush OverlayBrush { get; set; } = Brushes.White;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Background color of the text to be displayed on the control.")]
        public Color OverlayBackgroundColor { get; set; } = Color.White;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Location of the text to be displayed on the control.")]
        public Point OverlayLocation { get; set; } = new Point(10, 10);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsConnected { get; private set; }

        public static void SdkInit()
        {
            _ = Sdk.sdk_dev_init(null);
        }

        public static void SdkQuit()
        {
            Sdk.sdk_dev_quit();
        }

        public int Connect(string cameraIp = "192.168.0.120", ushort cameraPort = 30001, string username = "admin", string password = "admin", int streamId = 1, int channel = 1, StreamType streamType = StreamType.HighDensity, bool hardwareAcceleration = true)
        {
            disconnDelegate = OnSdkDisconnected;
            playTimeDelegate = OnPlayTime;
            thisHandleGch = GCHandle.Alloc(this, GCHandleType.Normal);
            var pObj = GCHandle.ToIntPtr(thisHandleGch.Value);
            if (!IsHandleCreated)
            {
                var _ = Handle; // force creation
            }

            this.channel = channel;
            //Invoke((Action)(() =>
            //{
            //    sdkHandler = Sdk.sdk_dev_conn(cameraIp, cameraPort, username, password, null, pObj);
            //    this.streamId = sdkHandler != IntPtr.Zero ? Sdk.sdk_md_live_start(sdkHandler, channel, streamType, Handle, hardwareAcceleration, null, pObj) : NoStream;
            //}));

            Invoke((Action)(() =>
            {
                //sdkHandler = Sdk.sdk_dev_conn(cameraIp, cameraPort, username, password, null, pObj);
                sdkHandler = Sdk.sdk_dev_conn(cameraIp, cameraPort, username, password, disconnDelegate, pObj);
                if (sdkHandler != IntPtr.Zero)
                {
                    this.streamId = Sdk.sdk_md_live_start(sdkHandler, channel, streamType, Handle, hardwareAcceleration, null, pObj);
                    //streamId = Sdk.sdk_md_live_start(sdkHandler, channel, streamType, Handle, hardwareAcceleration, playTimeDelegate, pObj);
                }
            }));

            if (sdkHandler == IntPtr.Zero)
            {
                FreeThisHandle();
                return NoSdkHandler;
            }

            //this.streamId = Sdk.sdk_dev_live_start(sdkHandler, channel, streamType, null, pObj);
            //_ = Sdk.sdk_dev_video_control(Handle, String.Empty);
            //this.streamId = Sdk.sdk_md_live_start(sdkHandler, channel, streamType, Handle, hardwareAcceleration, null, pObj);
            if (this.streamId < 0)
            {
                try { Sdk.sdk_dev_conn_close(sdkHandler); } catch { }
                sdkHandler = IntPtr.Zero;
                FreeThisHandle();
                return NoStream;
                //return this.streamId;
            }
            //if (this.streamId != streamId)
            //{
            //    _ = Sdk.sdk_md_chg_stream(sdkHandler, streamId, streamType);
            //    this.streamId = streamId;
            //}
            IsConnected = true;
            return this.streamId;
        }

        //private void PlayTimeCallback(IntPtr handle, int stream_id, IntPtr p_obj, ref IntPtr p_time)
        //{
        //    //Debug.WriteLine($"Handle: {handle}, Stream Id: {stream_id}, Obj: {p_obj}, Time: {p_time}");
        //}

        //private void DisconnectCallback(IntPtr handle, IntPtr p_obj, uint type)
        //{
        //    //Debug.WriteLine($"Handle: {handle}, Obj: {p_obj}, Type: {type}");
        //}

        public void PtzRotate(PtzRotateOperation operation)
        {
            var returnCode = Sdk.sdk_dev_ptz_rotate(sdkHandler, channel, (int)operation, rotateSpeed);
        }

        public void PtzStop()
        {
            var returnCode = Sdk.sdk_dev_ptz_stop(sdkHandler, channel);
        }

        public void PtzZoom(PtzZoomOperation operation)
        {
            var returnCode = Sdk.sdk_dev_ptz_zoom(sdkHandler, channel, (int)operation, rotateSpeed);
        }
        
        public void Disconnect()
        {
            try
            {
                if (IsConnected)
                {
                    if (streamId > 0)
                    {
                        _ = Sdk.sdk_md_live_stop(sdkHandler, streamId);
                        streamId = NoStream;
                    }

                    if (sdkHandler != IntPtr.Zero)
                    {
                        Sdk.sdk_dev_conn_close(sdkHandler);
                        sdkHandler = IntPtr.Zero;
                    }
                }
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
            finally
            {
                IsConnected = false;
                FreeThisHandle();
                Invoke((Action)(() => { BackgroundImage = Properties.Resources.NoSignal; }));
            }
        }

        private void FreeThisHandle()
        {
            if (thisHandleGch.HasValue && thisHandleGch.Value.IsAllocated)
            {
                thisHandleGch.Value.Free();
                thisHandleGch = null;
            }
            disconnDelegate = null;
            playTimeDelegate = null;
        }

        private void OnSdkDisconnected(IntPtr handle, IntPtr pObj, uint type)
        {
            // kezelés, logolás, UI update - INVOKE needed to touch controls
        }

        private void OnPlayTime(IntPtr handle, int streamId, IntPtr pObj, ref IntPtr pTime)
        {
            // játékidő callback
        }
    }
}
