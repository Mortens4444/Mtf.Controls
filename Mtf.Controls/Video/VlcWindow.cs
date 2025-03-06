using LibVLCSharp.WinForms;
using Mtf.Controls.Enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mtf.Controls.Video
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(VlcWindow), "Resources.VideoSource.png")]
    public class VlcWindow : VideoView
    {
        private bool disposed;
        private readonly Vlc vlc;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Resource to open.")]
        public string Resource { get; private set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Enable or disable hardware encoding.")]
        public bool EnableHardwareDecoding { get; private set; } = true;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Indicate if audio should be connected or not.")]
        public bool Mute { get; private set; } = true;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Use RTP over RTSP (TCP).")]
        public bool RtpOverRtsp { get; private set; } = false;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Network caching in milliseconds.")]
        public int NetworkCachingMs { get; private set; } = 100;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Live streaming caching in milliseconds.")]
        public int LiveCachingMs { get; private set; } = 100;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Demuxer.")]
        public Demux Demux { get; private set; } = Demux.live555;

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
        [Description("Location of the text to be displayed on the control.")]
        public Point OverlayLocation { get; set; } = new Point(10, 10);

        public VlcWindow()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            vlc = new Vlc(this);
            vlc.SignalChanged += Vlc_SignalChanged;
        }

        /// <summary>
        /// Starts the stream.
        /// </summary>
        /// <param name="resource">Resource is an URI.</param>
        /// <param name="enableHardwareDecoding"></param>
        /// <param name="mute"></param>
        /// <param name="rtsp"></param>
        /// <param name="udp"></param>
        /// <param name="networkCachingMs"></param>
        /// <param name="liveCachingMs"></param>
        public void Start(string resource, bool enableHardwareDecoding = true, bool mute = true, bool rtpOverRtsp = false, int networkCachingMs = 100, int liveCachingMs = 100, Demux demux = Demux.live555)
        {
            Resource = resource;
            EnableHardwareDecoding = enableHardwareDecoding;
            Mute = mute;
            RtpOverRtsp = rtpOverRtsp;
            NetworkCachingMs = networkCachingMs;
            LiveCachingMs = liveCachingMs;
            Demux = demux;
            Start();
        }

        public void Stop()
        {
            vlc.Stop();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!String.IsNullOrEmpty(OverlayText))
            {
                var graphics = e.Graphics;
                //_ = graphics.MeasureString(OverlayText, OverlayFont);
                graphics.DrawString(OverlayText, OverlayFont, OverlayBrush, OverlayLocation);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                vlc.Dispose();
            }
            base.Dispose(disposing);
            disposed = true;
        }

        private void Vlc_SignalChanged(bool signal)
        {
            if (!signal)
            {
                Task.Run(async () =>
                {
                    await Task.Delay(100).ConfigureAwait(false);
                    Start();
                });
            }
        }

        private void Start()
        {
            vlc.Start(Resource, EnableHardwareDecoding, Mute, RtpOverRtsp, NetworkCachingMs, LiveCachingMs, Demux);
        }
    }
}
