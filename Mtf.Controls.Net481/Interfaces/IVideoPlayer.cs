using System;

namespace Mtf.Controls.Net481.Interfaces
{
    public interface IVideoPlayer : IDisposable
    {
        void Start(string resource);

        void Stop();
    }
}
