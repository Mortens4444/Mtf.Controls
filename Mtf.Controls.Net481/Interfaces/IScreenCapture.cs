using System;

namespace Mtf.Controls.Net481.Interfaces
{
    public interface IScreenCapture : IDisposable
    {
        void Start();

        void Stop();
    }
}
