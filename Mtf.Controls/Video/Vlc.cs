using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using Mtf.Controls.Interfaces;
using System;

namespace Mtf.Controls.Video
{
    public class Vlc : BaseVideoPlayer, IVideoPlayer
    {
        public static readonly LibVLC LibVLC = new LibVLC("--verbose=2");

        public event Action<bool> SignalChanged;

        public VideoView VideoView { get; }

        private MediaPlayer mediaPlayer;

        public Vlc(VideoView videoView)
        {
            VideoView = videoView;
        }

        public void Start(string resource)
        {
            Start(resource, true, true, true, true, 100, 100);
        }

        public void Start(string resource, bool enableHardwareDecoding = true, bool mute = true, bool rtsp = true, bool udp = true, int networkCachingMs = 100, int liveCachingMs = 100)
        {
            StopMediaPlayer();
            var media = new Media(LibVLC, resource, FromType.FromLocation);
            media.AddOption($":network-caching={networkCachingMs}");
            media.AddOption($":live-caching={liveCachingMs}");
            if (rtsp)
            {
                media.AddOption(udp ? ":rtsp-udp" : ":rtsp-tcp");
            }
            mediaPlayer = new MediaPlayer(media)
            {
                EnableHardwareDecoding = enableHardwareDecoding,
                Mute = mute
            };

            VideoView.Invoke((Action)(() =>
            {
                VideoView.MediaPlayer = mediaPlayer;
            }));

            mediaPlayer.Playing += OnPlaying;
            mediaPlayer.Stopped += OnStopped;
            mediaPlayer.EncounteredError += OnError;
            mediaPlayer.EndReached += OnStopped;
            mediaPlayer.Play();
            media.Dispose();
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
            VideoView.Invoke((Action)(() => SignalChanged?.Invoke(true)));
        }

        private void OnStopped(object sender, EventArgs e)
        {
            VideoView.Invoke((Action)(() => SignalChanged?.Invoke(false)));
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
