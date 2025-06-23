using Mtf.Controls.Video.Sunell.IPR67.Enums;
using Mtf.Controls.Video.Sunell.IPR67.SunellSdk;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Video.Sunell.IPR67
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(SunellVideoWindow), "Resources.VideoSource.png")]
    public class SunellVideoWindow : PictureBox
    {
        //private Sdk.SDK_PLAY_TIME_CB playTimeCallback;
        //private Sdk.SDK_DISCONN_CB disconnectCallback;

        private IntPtr sdkHandler;
        private int streamId;
        private int channel;
        private int rotateSpeed = 50;

        public const int NoStream = -1;
        public const int NoPermission = -2;

        public SunellVideoWindow(int rotateSpeed = 50)
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();

            this.rotateSpeed = rotateSpeed;//AppConfig.GetInt32(LiveView.Core.Constants.SunellCameraWindowRotateSpeed, 50);

            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;

            //playTimeCallback = new Sdk.SDK_PLAY_TIME_CB(PlayTimeCallback);
            //disconnectCallback = new Sdk.SDK_DISCONN_CB(DisconnectCallback);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Disconnect();
            }
            base.Dispose(disposing);
        }

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
        public Color OverlayColor { get; set; } = Color.White;

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

        public int Connect(string cameraIp = "192.168.0.120", ushort cameraPort = 30001, string username = "admin", string password = "admin", int streamId = 1, int channel = 1, StreamType streamType = StreamType.HighDensity, bool hardwareAcceleration = true)
        {
            var pObj = IntPtr.Zero;
            this.channel = channel;
            Invoke((Action)(() =>
            {
                sdkHandler = Sdk.sdk_dev_conn(cameraIp, cameraPort, username, password, null, pObj);
                this.streamId = sdkHandler != IntPtr.Zero ? Sdk.sdk_md_live_start(sdkHandler, channel, streamType, Handle, hardwareAcceleration, null, pObj) : NoStream;
            }));
             
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
                    _ = Sdk.sdk_md_live_stop(sdkHandler, streamId);
                }
            }
            finally
            {
                IsConnected = false;
            }
        }
    }
}
