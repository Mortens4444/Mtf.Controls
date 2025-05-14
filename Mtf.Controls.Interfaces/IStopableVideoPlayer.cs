using System;

namespace Mtf.Controls.Interfaces
{
    public interface IStopableVideoPlayer : IDisposable
    {
        void Stop();
    }
}
