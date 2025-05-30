﻿namespace Mtf.Controls.Enums
{
    public enum WindowMessagesParameter : int
    {
        /// <summary>Specifies the area of the window that represents the title bar.</summary>
        /// <remarks>Value: 2 (HtCaption)</remarks>
        HtCaption = 2,
        PrfNonClient = 2,

        /// <summary>Specifies the client area of the window.</summary>
        /// <remarks>Value: 4 (PrfClient)</remarks>
        PrfClient = 4,

        PrfEraseBackground = 8,

        PrfChildren = 16,

        /// <summary>Specifies the area of the window that represents the bottom-right corner resize handle.</summary>
        /// <remarks>Value: 17 (HtBottomRight)</remarks>
        HtBottomRight = 17,
    }
}
