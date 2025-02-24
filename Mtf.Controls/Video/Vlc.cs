 using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Video
{
    public class Vlc : BaseVideoPlayer, IVideoPlayer
    {
        public static readonly LibVLC LibVLC = new LibVLC();

        public VideoView VideoView { get; }

        private MediaPlayer mediaPlayer;

        public Vlc(VideoView videoView)
        {
            VideoView = videoView;
        }

        public void Start(string resource)
        {
            StopMediaPlayer();

            var media = new Media(LibVLC, resource, FromType.FromLocation);
            media.AddOption(":network-caching=100");
            media.AddOption(":rtsp-udp");
            //media.AddOption(":rtsp-tcp");
            mediaPlayer = new MediaPlayer(media)
            {
                EnableHardwareDecoding = true,
                Mute = true
            };
            VideoView.MediaPlayer = mediaPlayer;

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

        public void Stop()
        {
            StopMediaPlayer();
        }

        protected override void DisposeManagedResources()
        {
            StopMediaPlayer();
            //VideoView.Dispose();
        }

        private void StopMediaPlayer()
        {
            if (mediaPlayer != null)
            {
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
