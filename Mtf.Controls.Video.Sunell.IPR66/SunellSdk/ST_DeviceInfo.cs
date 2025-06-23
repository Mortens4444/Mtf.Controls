using System.Runtime.InteropServices;

namespace Mtf.Controls.Video.Sunell.IPR66.SunellSdk
{
    /// <summary>
    /// Represents device information.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ST_DeviceInfo
    {
        /// <summary>
        /// Network address of the device.
        /// </summary>
        public ST_InetAddr InetAddr;

        /// <summary>
        /// User ID for logging into the device.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string UserID;

        /// <summary>
        /// Password for logging into the device.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string Password;

        /// <summary>
        /// Device ID.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string DeviceID;

        /// <summary>
        /// Device name.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string DeviceName;

        /// <summary>
        /// Device type identifier.
        /// </summary>
        public int DeviceType;
    }
}
