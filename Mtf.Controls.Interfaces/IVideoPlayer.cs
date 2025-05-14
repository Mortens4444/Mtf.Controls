namespace Mtf.Controls.Interfaces
{
    public interface IVideoPlayer : IStopableVideoPlayer
    {
        void Start(string resource);
    }
}
