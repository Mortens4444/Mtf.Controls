using System;

namespace Mtf.Controls.Enums
{
    [Flags]
    public enum ResizeDirection
    {
        None = 0,
        East = 1,
        South = 2,
        SouthEast = East | South
    }
}
