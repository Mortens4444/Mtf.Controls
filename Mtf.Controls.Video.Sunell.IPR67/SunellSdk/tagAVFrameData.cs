using System.Runtime.InteropServices;
using System;

namespace Mtf.Controls.Video.Sunell.IPR67.SunellSdk
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public unsafe struct tagAVFrameData
	{
		public AVStreamFormat nStreamFormat; // 1 indicates raw stream, 2 indicates TS multiplexed stream, 3 indicates raw encrypted stream, 4 indicates PS multiplexed stream.
		public ESStreamType nESStreamType;   // Raw stream type: 1 for video, 2 for audio.
		public EncoderType nEncoderType;     // Encoding format.
		public Int32 nCameraNo;              // Camera number, indicates which channel the data comes from.
		public UInt32 nSequenceId;           // Data frame sequence number.
		public FrameType nFrameType;         // Data frame type: 1 for I-frame, 2 for P-frame, 0 for unknown.
		public Int64 nAbsoluteTimeStamp;     // Absolute timestamp when data was captured (in microseconds).
		public Int64 nRelativeTimeStamp;     // Relative timestamp when data was captured (in microseconds).
		public char* pszData;                // Data.
		public UInt32 nDataLength;           // Valid data length.
		public Int32 nFrameRate;             // Frame rate.
		public Int32 nBitRate;               // Current bitrate.
		public Int32 nImageFormatId;         // Current image format.
		public Int32 nImageWidth;            // Video width.
		public Int32 nImageHeight;           // Video height.
		public VideoSystem nVideoSystem;     // Current video system.
		public UInt32 nFrameBufLen;          // Current buffer length.
		public Int32 nStreamId;              // Stream ID.
		public Int32 nTimezone;              // Time zone.
		public Int32 nDaylightSavingTime;    // Daylight saving time.
	}
}
