using System.Runtime.InteropServices;

namespace Mtf.Controls.Video.Sunell.IPR66.SunellSdk
{
    /// <summary>
    /// Represents data for audio and video frames.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ST_AVFrameData
    {
        /// <summary>
        /// The format of the stream: 1 for raw stream, 2 for TS multiplexed stream.
        /// </summary>
        public int nStreamFormat;

        /// <summary>
        /// The type of the raw stream: 1 for video, 2 for audio.
        /// </summary>
        public int nESStreamType;

        /// <summary>
        /// The encoding format.
        /// </summary>
        public int nEncoderType;

        /// <summary>
        /// The camera number indicating which camera the data originates from.
        /// </summary>
        public int nCameraNo;

        /// <summary>
        /// The sequence ID of the data frame.
        /// </summary>
        public int nSequenceId;

        /// <summary>
        /// The type of data frame: 1 for I-frame, 2 for P-frame, 0 for unknown type.
        /// </summary>
        public int nFrameType;

        /// <summary>
        /// The timestamp of data acquisition in milliseconds.
        /// </summary>
        public long nTimeStamp;

        /// <summary>
        /// The raw data.
        /// </summary>
        public string pszData;

        /// <summary>
        /// The valid length of the data.
        /// </summary>
        public int nDataLength;

        /// <summary>
        /// The frame rate of the video.
        /// </summary>
        public int nFrameRate;

        /// <summary>
        /// The current bitrate of the stream.
        /// </summary>
        public int nBitRate;

        /// <summary>
        /// The ID of the current image format.
        /// </summary>
        public int nImageFormatId;

        /// <summary>
        /// The width of the video.
        /// </summary>
        public int nImageWidth;

        /// <summary>
        /// The height of the video.
        /// </summary>
        public int nImageHeight;

        /// <summary>
        /// The video system standard in use.
        /// </summary>
        public int nVideoSystem;

        /// <summary>
        /// The current buffer length.
        /// </summary>
        public int nFrameBufLen;

        /// <summary>
        /// The stream ID.
        /// </summary>
        public int nStreamId;

        /// <summary>
        /// The timezone of the video.
        /// </summary>
        public int nTimezone;

        /// <summary>
        /// Indicates whether daylight saving time is active.
        /// </summary>
        public int nDaylightSavingTime;
    }
}
