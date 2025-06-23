using System;

namespace Mtf.Controls.Video.Sunell.IPR66.CustomEventArgs
{
    public class VideoSignalChangedEventArgs : EventArgs
    {
        public VideoSignalChangedEventArgs(bool hasSignal)
        {
            HasSignal = hasSignal;
        }

        public bool HasSignal { get; private set; }
    }
}
