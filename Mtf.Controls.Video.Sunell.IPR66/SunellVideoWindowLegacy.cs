using Mtf.Controls.Video.Sunell.IPR66.CustomEventArgs;
using Mtf.Controls.Video.Sunell.IPR66.SunellSdk;
using Mtf.MessageBoxes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Mtf.Controls.Video.Sunell.IPR66
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(SunellVideoWindowLegacy), "Resources.VideoSource.png")]
    public class SunellVideoWindowLegacy : PictureBox
    {
        private IntPtr nvdHandle = IntPtr.Zero;

        private const int WM_USER = 0x400;
        private const int WM_LIVEPLAY_MESSAGE = WM_USER + 1000;

        public const int EventIdCreateVideoSessionSuccess = 1;
        public const int EventIdCreateAudioSessionSuccess = 2;
        public const int EventIdCreateVideoSessionFailed = 3;
        public const int EventIdCreateAudioSessionFailed = 4;
        public const int EventIdVideoSessionClosedSuccess = 5;
        public const int EventIdAudioSessionClosedSuccess = 6;
        public const int EventIdLoginUserNameWrong = 7;
        public const int EventIdLoginPasswordWrong = 8;
        public const int EventIdReceiveVideoError = 9;
        public const int EventIdReceiveAudioError = 10;
        public const int EventIdDeviceNotSupportVideo = 11;
        public const int EventIdDeviceNotSupportAudio = 12;
        public const int EventIdDeviceNoPrivilege = 13;
        public const int EventIdDeviceMaxConnection = 14;
        public const int EventIdFilePlaybackEnd = 15;
        public const int EventIdLoginUserRepeated = 16;
        public const int EventIdLoginUserLocked = 17;

        public delegate void VideoSignalChangedEventHandler(object sender, VideoSignalChangedEventArgs e);

        public event VideoSignalChangedEventHandler VideoSignalChanged;

        public SunellVideoWindowLegacy()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();

            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            SizeMode = PictureBoxSizeMode.StretchImage;
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
        [Description("Color of the background text to be displayed on the control.")]
        public Color OverlayBackgroundColor { get; set; } = Color.Black;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Location of the text to be displayed on the control.")]
        public Point OverlayLocation { get; set; } = new Point(10, 10);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsConnected => nvdHandle != IntPtr.Zero;

        public void Connect(string cameraIp = "192.168.0.120", ushort cameraPort = 30001, string username = "admin", string password = "admin", int streamId = 1, int cameraId = 1, bool autoConnect = true, int ipProtocolVersion = 1, int transferProtocol = 2)
        {
            var deviceInfo = new ST_DeviceInfo
            {
                UserID = username,
                Password = password,
                InetAddr = new ST_InetAddr
                {
                    HostIP = cameraIp,
                    Port = cameraPort,
                    IPProtocolVersion = ipProtocolVersion
                }
            };

            var returnCode = NvdcDll.Remote_Nvd_Init(ref nvdHandle, ref deviceInfo, transferProtocol);
            CheckForError(returnCode);

            if (NvdcDll.NvdSdk_Is_Handle_Valid(nvdHandle))
            {
                SetAutoConnectFlag(autoConnect);
                SetDefaultStreamId(streamId);
                SetVideoWindow();

                returnCode = NvdcDll.Remote_LivePlayer2_SetNotifyWindow(nvdHandle, Handle, WM_LIVEPLAY_MESSAGE, IntPtr.Zero);
                CheckForError(returnCode);

                returnCode = NvdcDll.Remote_LivePlayer2_Open(nvdHandle, cameraId);
                CheckForError(returnCode);

                returnCode = NvdcDll.Remote_LivePlayer2_Play(nvdHandle);
                CheckForError(returnCode);

                //BackgroundImage = null;
            }
            else
            {
                throw new InvalidOperationException("The handle is not valid.");
            }
        }

        public void Disconnect()
        {
            if (IsConnected)
            {
                _ = NvdcDll.Remote_LivePlayer2_Close(nvdHandle);
                _ = NvdcDll.Remote_Nvd_UnInit(nvdHandle);
            }

            BackgroundImage = Properties.Resources.NoSignal;
            //Invoke((Action)(() => { Invalidate(); }));
        }

        #region Sunell Functions

        private bool SetVideoWindow()
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_LivePlayer2_SetVideoWindow(nvdHandle, Handle, 0, 0, Width, Height);
                CheckForError(returnCode);
                return true;
            }

            return false;
        }

        public void SetUseTimeStamp(bool useTimeStamp)
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_LivePlayer2_SetUseTimeStamp(nvdHandle, useTimeStamp);
                CheckForError(returnCode);
            }
        }

        public void SetStretchMode(bool stretch)
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_LivePlayer2_SetStretchMode(nvdHandle, stretch);
                CheckForError(returnCode);
            }
        }

        public void SetAutoConnectFlag(bool autoConnect)
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_LivePlayer2_SetAutoConnectFlag(nvdHandle, autoConnect);
                CheckForError(returnCode);
            }
        }

        public void SetContrast(int percent)
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_LivePlayer2_SetCurrentContrast(nvdHandle, percent);
                CheckForError(returnCode);
            }
        }

        public void SetDefaultStreamId(int streamId)
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_LivePlayer2_SetDefaultStreamId(nvdHandle, streamId);
                CheckForError(returnCode);
            }
        }

        public void SetBrightness(int percent)
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_LivePlayer2_SetCurrentBrightness(nvdHandle, percent);
                CheckForError(returnCode);
            }
        }

        public void SetHue(int percent)
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_LivePlayer2_SetCurrentHue(nvdHandle, percent);
                CheckForError(returnCode);
            }
        }

        public void SetSaturation(int percent)
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_LivePlayer2_SetCurrentSaturation(nvdHandle, percent);
                CheckForError(returnCode);
            }
        }

        public void PlaySound()
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_LivePlayer2_PlaySound(nvdHandle);
                CheckForError(returnCode);
            }
        }

        public void Pause()
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_LivePlayer2_Pause(nvdHandle);
                CheckForError(returnCode);
            }
        }

        public void CreateSnapShot(string filePath)
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_LivePlayer2_SnapShot(nvdHandle, filePath);
                CheckForError(returnCode);
            }
        }

        public void StartRecording(string filePath)
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_LivePlayer2_SetRecorderFile(nvdHandle, filePath);
                CheckForError(returnCode);

                returnCode = NvdcDll.Remote_LivePlayer2_StartRecord(nvdHandle);
                CheckForError(returnCode);
            }
        }

        public void StopRecording()
        {
            if (IsConnected)
            {
                int recorderStatus = 0;
                var returnCode = NvdcDll.Remote_LivePlayer2_GetRecorderStatus(nvdHandle, ref recorderStatus);
                CheckForError(returnCode);
            
                if (recorderStatus == 1)
                {
                    returnCode = NvdcDll.Remote_LivePlayer2_StopRecord(nvdHandle);
                    CheckForError(returnCode);
                }
            }
        }

        #pragma warning disable CA1707

        public void PTZ_Open(int cameraId)
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_PTZEx_Open(nvdHandle, cameraId);
                CheckForError(returnCode);
            }
        }

        public void PTZ_Close()
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_PTZEx_Close(nvdHandle);
                CheckForError(returnCode);
            }
        }

        public void PTZ_Stop()
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_PTZEx_Stop(nvdHandle);
                CheckForError(returnCode);
            }
        }

        public void PTZ_RotateUp(int speed)
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_PTZEx_RotateUp(nvdHandle, speed);
                CheckForError(returnCode);
            }
        }

        public void PTZ_RotateDown(int speed)
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_PTZEx_RotateDown(nvdHandle, speed);
                CheckForError(returnCode);
            }
        }

        public void PTZ_RotateRight(int speed)
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_PTZEx_RotateRight(nvdHandle, speed);
                CheckForError(returnCode);
            }
        }

        public void PTZ_RotateLeft(int speed)
        {
            if (IsConnected)
            {
                var returnCode = NvdcDll.Remote_PTZEx_RotateLeft(nvdHandle, speed);
                CheckForError(returnCode);
            }
        }
        #pragma warning restore CA1707

        #endregion

        public void RefreshImage()
        {
            if (SetVideoWindow())
            {
                Invoke((Action)(() => Invalidate()));
            }
        }

        protected override void OnResize(EventArgs e)
        {
            RefreshImage();
            base.OnResize(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            RefreshImage();
            base.OnSizeChanged(e);
        }

        protected override void WndProc(ref Message m)
        {
            switch ((int)m.WParam)
            {
                case EventIdCreateVideoSessionSuccess:
                    Invoke((Action)(() => { BackgroundImage = null; }));
                    VideoSignalChanged?.Invoke(this, new VideoSignalChangedEventArgs(true));
                    base.WndProc(ref m);
                    break;
                case EventIdCreateVideoSessionFailed:
                case EventIdVideoSessionClosedSuccess:
                case EventIdReceiveVideoError:
                case EventIdDeviceNotSupportVideo:
                    Invoke((Action)(() => { BackgroundImage = Properties.Resources.NoSignal; }));
                    VideoSignalChanged?.Invoke(this, new VideoSignalChangedEventArgs(false));
                    base.WndProc(ref m);
                    break;
                case EventIdCreateAudioSessionSuccess:
                case EventIdCreateAudioSessionFailed:
                case EventIdAudioSessionClosedSuccess:
                case EventIdLoginUserNameWrong:
                case EventIdLoginPasswordWrong:
                case EventIdReceiveAudioError:
                case EventIdDeviceNotSupportAudio:
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    if (!String.IsNullOrEmpty(OverlayText))
        //    {
        //        var graphics = e.Graphics;
        //        //_ = graphics.MeasureString(OverlayText, OverlayFont);
        //        graphics.DrawString(OverlayText, OverlayFont, OverlayBrush, OverlayLocation);
        //    }
        //}

        private static void CheckForError(int errorCode, [CallerMemberName] string callerFunction = "", [CallerFilePath] string callerFile = "", [CallerLineNumber] int callerLine = 0)
        {
            if (errorCode != 0)
            {
                try
                {
                    throw new InvalidOperationException($"ErrorCode: {errorCode}, {callerFunction} in {callerFile}, line {callerLine}{Environment.NewLine}Message: {NvdcDll.GetErrorMessage(errorCode)}");
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }
        }
    }
}
