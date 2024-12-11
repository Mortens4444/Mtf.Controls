using System;
using System.Drawing;

namespace Mtf.Controls.CustomEventArgs
{
    public class FrameArrivedEventArgs : EventArgs
    {
        public FrameArrivedEventArgs(Image frame)
        {
            Frame = frame;
        }

        public Image Frame { get; private set; }
    }
}
