using LibVLCSharp.Shared;
using Mtf.Controls.Enums;
using Mtf.Controls.Extensions;
using Mtf.Controls.Interfaces;
using System;
using System.Drawing;

namespace Mtf.Controls.Video
{
    /// <summary>
    /// https://wiki.videolan.org/VLC_command-line_help/
    /// </summary>
    public class Vlc : BaseVideoPlayer, IVideoPlayer
    {
        public static readonly LibVLC LibVLC = new LibVLC("--verbose=2");

        public event Action<bool> SignalChanged;

        public VlcWindow VlcWindow { get; }

        private MediaPlayer mediaPlayer;

        public Vlc(VlcWindow vlcWindow)
        {
            VlcWindow = vlcWindow;
        }

        public void Start(string resource)
        {
            Start(resource, true, true, true, 100, 100, Demux.live555);
        }

        public void Start(string resource, bool enableHardwareDecoding = true, bool mute = true, bool rtpOverRtsp = false, int networkCachingMs = 100, int liveCachingMs = 100, Demux demux = Demux.live555)
        {
            networkCachingMs = Math.Max(Math.Min(networkCachingMs, 60000), 0);
            liveCachingMs = Math.Max(Math.Min(liveCachingMs, 60000), 0);

            StopMediaPlayer();
            var media = new Media(LibVLC, resource, FromType.FromLocation);
            media.AddOption($"--network-caching={networkCachingMs}");
            media.AddOption($"--live-caching={liveCachingMs}");
            media.AddOption($"--demux={demux}");
            media.AddOption($"--rtsp-http");
            media.AddOption($"--rtsp-reconnect");
            media.AddOption($"--http-continuous");

            if (rtpOverRtsp)
            {
                media.AddOption("--rtsp-tcp");
            }
            mediaPlayer = new MediaPlayer(media)
            {
                EnableHardwareDecoding = enableHardwareDecoding,
                Mute = mute
            };

            VlcWindow.Invoke((Action)(() =>
            {
                VlcWindow.MediaPlayer = mediaPlayer;
            }));

            mediaPlayer.Playing += OnPlaying;
            mediaPlayer.Stopped += OnStopped;
            mediaPlayer.EncounteredError += OnError;
            mediaPlayer.EndReached += OnStopped;
            mediaPlayer.Play();

            mediaPlayer.SetMarqueeString(VideoMarqueeOption.Text, VlcWindow.OverlayText);
            mediaPlayer.SetMarqueeInt(VideoMarqueeOption.Enable, 1);
            mediaPlayer.SetMarqueeInt(VideoMarqueeOption.Position, 5);
            mediaPlayer.SetMarqueeInt(VideoMarqueeOption.Size, (int)VlcWindow.OverlayFont.SizeInPoints * 4);
            mediaPlayer.SetMarqueeInt(VideoMarqueeOption.Color, ConvertColorToVlcInt(VlcWindow.OverlayBrush.ToColor()));

            //VideoView.Paint
            media.Dispose();
        }

        private int ConvertColorToVlcInt(Color color)
        {
            return (color.A << 24) | (color.R << 16) | (color.G << 8) | color.B;
        }

        //public static bool Test(string url)
        //{
        //    bool result;

        //    using (var media = new Media(LibVLC, url, FromType.FromLocation))
        //    using (var mediaPlayer = new MediaPlayer(media))
        //    {
        //        mediaPlayer.EnableHardwareDecoding = true;
        //        mediaPlayer.Mute = true;
        //        mediaPlayer.Play();

        //        result = mediaPlayer.IsPlaying;
        //        mediaPlayer.Stop();
        //    }

        //    return result;
        //}

        private void OnPlaying(object sender, EventArgs e)
        {
            VlcWindow.Invoke((Action)(() => SignalChanged?.Invoke(true)));
        }

        private void OnStopped(object sender, EventArgs e)
        {
            VlcWindow.Invoke((Action)(() => SignalChanged?.Invoke(false)));
        }

        private void OnError(object sender, EventArgs e)
        {
            //VideoView.Invoke((Action)(() => SignalChanged?.Invoke(false)));
        }

        public void Stop()
        {
            StopMediaPlayer();
        }

        protected override void DisposeManagedResources()
        {
            StopMediaPlayer();
            //VideoView.Dispose();
        }

        private void UnsubscribeEvents()
        {
            if (mediaPlayer != null)
            {
                mediaPlayer.Playing -= OnPlaying;
                mediaPlayer.Stopped -= OnStopped;
                mediaPlayer.EncounteredError -= OnError;
                mediaPlayer.EndReached -= OnStopped;
            }
        }

        private void StopMediaPlayer()
        {
            if (mediaPlayer != null)
            {
                UnsubscribeEvents();
                if (mediaPlayer.IsPlaying)
                {
                    mediaPlayer.Stop();
                }
                mediaPlayer.Dispose();
                mediaPlayer = null;
            }
        }
    }
}
