namespace Mtf.Controls.Enums
{
    public enum ExtendedWindowStyle : uint
    {
        /// <summary>Specifies that a window created with this style accepts drag-and-drop files.</summary>
        /// <remarks>WS_EX_ACCEPTFILES</remarks>
        WS_EX_ACCEPTFILES = 0x00000010,

        /// <summary>Forces a top-level window onto the taskbar when the window is visible.</summary>
        /// <remarks>WS_EX_APPWINDOW</remarks>
        WS_EX_APPWINDOW = 0x00040000,

        /// <summary>Specifies that a window has a 3D look — that is, a border with a sunken edge.</summary>
        /// <remarks>WS_EX_CLIENTEDGE</remarks>
        WS_EX_CLIENTEDGE = 0x00000200,

        /// <summary>Includes a question mark in the title bar of the window. When the user clicks the question mark, the cursor changes to a question mark with a pointer. If the user then clicks a child window, the child receives a WM_HELP message.</summary>
        /// <remarks>WS_EX_CONTEXTHELP</remarks>
        WS_EX_CONTEXTHELP = 0x00000400,

        /// <summary>Allows the user to navigate among the child windows of the window by using the TAB key.</summary>
        /// <remarks>WS_EX_CONTROLPARENT</remarks>
        WS_EX_CONTROLPARENT = 0x00010000,

        /// <summary>Designates a window with a double border that may (optionally) be created with a title bar when you specify the WS_CAPTION style flag in the dwStyle parameter.</summary>
        /// <remarks>WS_EX_DLGMODALFRAME</remarks>
        WS_EX_DLGMODALFRAME = 0x00000001,

        /// <summary>WS_EX_LAYERED.</summary>
        /// <remarks>WS_EX_LAYERED</remarks>
        WS_EX_LAYERED = 0x00080000,

        /// <summary>WS_EX_LAYOUTRTL.</summary>
        /// <remarks>WS_EX_LAYOUTRTL</remarks>
        WS_EX_LAYOUTRTL = 0x00400000,

        /// <summary>Gives window generic left-aligned properties. This is the default.</summary>
        /// <remarks>WS_EX_LEFT</remarks>
        WS_EX_LEFT = 0x00000000,

        /// <summary>Places a vertical scroll bar to the left of the client area.</summary>
        /// <remarks>WS_EX_LEFTSCROLLBAR</remarks>
        WS_EX_LEFTSCROLLBAR = 0x00004000,

        /// <summary>Displays the window text using left-to-right reading order properties. This is the default.</summary>
        /// <remarks>WS_EX_LTRREADING</remarks>
        WS_EX_LTRREADING = 0x00000000,

        /// <summary>Creates an MDI child window.</summary>
        /// <remarks>WS_EX_MDICHILD</remarks>
        WS_EX_MDICHILD = 0x00000040,

        /// <summary>WS_EX_NOACTIVATE.</summary>
        /// <remarks>WS_EX_NOACTIVATE</remarks>
        WS_EX_NOACTIVATE = 0x08000000,

        /// <summary>WS_EX_NOINHERITLAYOUT.</summary>
        /// <remarks>WS_EX_NOINHERITLAYOUT</remarks>
        WS_EX_NOINHERITLAYOUT = 0x00100000,

        /// <summary>Specifies that a child window created with this style will not send the WM_PARENTNOTIFY message to its parent window when the child window is created or destroyed.</summary>
        /// <remarks>WS_EX_NOPARENTNOTIFY</remarks>
        WS_EX_NOPARENTNOTIFY = 0x00000004,

        /// <summary>Combines the WS_EX_CLIENTEDGE and WS_EX_WINDOWEDGE styles.</summary>
        /// <remarks>WS_EX_OVERLAPPEDWINDOW</remarks>
        WS_EX_OVERLAPPEDWINDOW = 0x00000100 | 0x00000200,

        /// <summary>Combines the WS_EX_WINDOWEDGE and WS_EX_TOPMOST styles.</summary>
        /// <remarks>WS_EX_PALETTEWINDOW</remarks>
        WS_EX_PALETTEWINDOW = 0x00000100 | 0x00000080 | 0x00000008,

        /// <summary>Gives a window generic right-aligned properties. This depends on the window class.</summary>
        /// <remarks>WS_EX_RIGHT</remarks>
        WS_EX_RIGHT = 0x00001000,

        /// <summary>Places a vertical scroll bar (if present) to the right of the client area. This is the default.</summary>
        /// <remarks>WS_EX_RIGHTSCROLLBAR</remarks>
        WS_EX_RIGHTSCROLLBAR = 0x00000000,

        /// <summary>Displays the window text using right-to-left reading order properties.</summary>
        /// <remarks>WS_EX_RTLREADING</remarks>
        WS_EX_RTLREADING = 0x00002000,

        ///<summary>Creates a window with a three-dimensional border style intended to be used for items that do not accept user input.</summary>
        /// <remarks>WS_EX_STATICEDGE</remarks>
        WS_EX_STATICEDGE = 0x00020000,

        /// <summary>Creates a tool window, which is a window intended to be used as a floating toolbar. A tool window has a title bar that is shorter than a normal title bar, and the window title is drawn using a smaller font. A tool window does not appear in the task bar or in the window that appears when the user presses ALT+TAB.</summary>
        /// <remarks>WS_EX_TOOLWINDOW</remarks>
        WS_EX_TOOLWINDOW = (int)0x00000080,

        /// <summary>Specifies that a window created with this style should be placed above all nontopmost windows and stay above them even when the window is deactivated. An application can use the SetWindowPos member function to add or remove this attribute.</summary>
        /// <remarks>WS_EX_TOPMOST</remarks>
        WS_EX_TOPMOST = 0x00000008,

        /// <summary>Specifies that a window created with this style is to be transparent. That is, any windows that are beneath the window are not obscured by the window. A window created with this style receives WM_PAINT messages only after all sibling windows beneath it have been updated.</summary>
        /// <remarks>WS_EX_TRANSPARENT</remarks>
        WS_EX_TRANSPARENT = 0x00000020,

        /// <summary>Specifies that a window has a border with a raised edge.</summary>
        /// <remarks>WS_EX_WINDOWEDGE</remarks>
        WS_EX_WINDOWEDGE = 0x00000100
    }
}
