using System.Runtime.InteropServices;

namespace Mtf.Controls.Video.Sunell.IPR66.SunellSdk
{
    /// <summary>
    /// Represents an IP address.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ST_InetAddr
    {
        /// <summary>
        /// IP address in dot-decimal notation.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 49)]
        public string HostIP;

        /// <summary>
        /// Port number.
        /// </summary>
        public ushort Port;

        /// <summary>
        /// IP protocol version (1: IPv4, 2: IPv6).
        /// </summary>
        public int IPProtocolVersion;
    }
}
