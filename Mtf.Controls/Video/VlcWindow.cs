using LibVLCSharp.WinForms;
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
        [Description("Use RTSP.")]
        public bool Rtsp { get; private set; } = true;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Use RTSP over UDP instead of TCP.")]
        public bool Udp { get; private set; } = true;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Network caching in milliseconds.")]
        public int NetworkCachingMs { get; private set; } = 100;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Live streaming caching in milliseconds.")]
        public int LiveCachingMs { get; private set; } = 100;

        public VlcWindow()
        {
            BackgroundImage = Properties.Resources.NoSignal;
            BackgroundImageLayout = ImageLayout.Stretch;
            vlc = new Vlc(this);
            vlc.SignalChanged += Vlc_SignalChanged;
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
        public void Start(string resource, bool enableHardwareDecoding = true, bool mute = true, bool rtsp = true, bool udp = true, int networkCachingMs = 100, int liveCachingMs = 100)
        {
            Resource = resource;
            EnableHardwareDecoding = enableHardwareDecoding;
            Mute = mute;
            Rtsp = rtsp;
            Udp = udp;
            NetworkCachingMs = networkCachingMs;
            LiveCachingMs = liveCachingMs;
            Start();
        }

        private void Start()
        {
            vlc.Start(Resource, EnableHardwareDecoding, Mute, Rtsp, Udp, NetworkCachingMs, LiveCachingMs);
        }

        public void Stop()
        {
            vlc.Stop();
        }
    }
}
