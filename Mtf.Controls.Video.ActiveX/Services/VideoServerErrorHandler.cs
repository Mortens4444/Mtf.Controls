namespace Mtf.Controls.Video.ActiveX.Services
{
    public static class VideoServerErrorHandler
    {
        public const int Success = 0;
        public const int TimeoutErrorCode = 4000;
        public const int NoVideoServerCredentialsFound = 4001;
        public const int UnknownErrorOccurred = 4002;
        public const int NoResult = 4003;

        /// <summary>
        /// Unknown state. When connecting to two identical cameras, one connects successfully while the other returns error -14.
        /// </summary>
        public const int LimitedConnectionCount = -14;
        public const int UnknownState = -12;
        public const int CameraNameNotSupported = -7;
        public const int RpcNotConnected = -6;
        public const int RpcServerConnectionError = -5;
        public const int InvalidRpcParameters = -4;
        public const int InvalidRpcConnection = -3;
        public const int RpcExceptionOccurred = -2;
        public const int RpcFailedOrCallUnsuccessful = -1;

        public const int RecorderBase = 1000;
        public const int InvalidRegistry = 1001;
        public const int InvalidDriverName = 1002;
        public const int HardwareDriverConnectError = 1003;
        public const int DriverConnectError = 1004;
        public const int DriverError = 1005;
        public const int DirectShowDriverNotFound = 1010;
        public const int DirectShowSetVideoStandard = 1011;
        public const int DirectShowSetVideoFormat = 1012;
        public const int DirectShowGetVideoFormat = 1013;
        public const int DirectShowCaptureTimeout = 1014;
        public const int DirectShowActiveMovie = 1015;
        public const int DirectShowInvalidVideoSignal = 1016;
        public const int DirectShowDigitalSignalProcessorCapturedDataRegisterError = 1017;
        public const int ChannelBase = 2000;
        public const int ChannelInvalidRegistry = 2001;
        public const int ChannelQueueError = 2002;
        public const int ChannelFileOpenError = 2003;
        public const int ChannelHardwareError = 2004;
        public const int ChannelImageProcessError = 2005;
        public const int ChannelWriteHardwareError = 2006;
        public const int ChannelWriteError = 2007;
        public const int ChannelCameraLicense = 2008;
        public const int ChannelVideoSignalLost = 2009;
        public const int ChannelException = 2010;
        public const int ChannelSystemTimeChanged = 2011;
        public const int ChannelCameraMoved = 2012;
        public const int ChannelCameraStop = 2013;
        public const int ChannelCameraLowDetail = 2014;
        public const int RemoteProcedureCallServerBase = 3000;
        public const int WrongCameraName = 3001;

        /// <summary>
        /// Invalid output filename.
        /// </summary>
        public const int RemoteProcedureCallInvalidFileName = 3002;
        //public const int RemoteProcedureCallInvalidException = 3003;

        /// <summary>
        /// Invalid operation exception occurred.
        /// </summary>
        public const int LowVirtualMemory = 3003;
        public const int ConnectionLost = 3004;
        public const int RemoteProcedureCallInvalidFunctionCall = 3005;
        public const int RemoteProcedureCallFileOpenFailed = 3006;
        public const int RemoteProcedureCallInvalidFilePointer = 3007;
        public const int RemoteProcedureCallEndOfFile = 3008;
        public const int HardwareError = 3009;
        public const int RemoteProcedureCallInvalidConnection = 3010;
        public const int RemoteProcedureCallInvalidCameraIndex = 3011;
        public const int WrongCredentials = 3012;
        public const int RemoteProcedureCallNotImplemented = 3013;
        public const int RemoteProcedureCallEndOfFrame = 3014;
        public const int RemoteProcedureCallEndOfTimeline = 3015;
        public const int RemoteProcedureCallInvalidHardLock = 3016;
        public const int RemoteProcedureCallUserAbort = 3017;
        public const int NetworkError = 3018;
        public const int ConnectionFailed = 3019;
        public const int RemoteProcedureCallInvalidServerProtocolVersion = 3020;
        public const int RemoteProcedureCallErrorNotImplemented = 3021;
        public const int RemoteProcedureCallErrorAccessDenied = 3022;
        public const int RemoteProcedureCallErrorInvalidTrack = 3023;
        public const int RemoteProcedureCallErrorInvalidCall = 3024;
        public const int RemoteProcedureCallErrorCallFailed = 3025;
        public const int RemoteProcedureCallErrorInvalidVersion = 3026;
        //public const int PermissionError = 3026;
        public const int RemoteProcedureCallErrorPreviewUnavailable = 3027;
        public const int RemoteProcedureCallConnectSocketFailed = 3100;
        public const int RemoteProcedureCallCreateSocketFailed = 3101;
        public const int RemoteProcedureCallSocketReceiveTimeout = 3102;
        public const int RemoteProcedureCallForceCloseSocket = 3103;
        //public const int VideoPlayerBase = 4000;
        public const int TapeFileErrorBase = 6000;
        public const int TapeFileInvalidPosition = 6001;
        public const int AbortBase = 7000;
        public const int KeyFrameTransfer = 7001;
        public const int InvalidKeyFrame = 7002;
        public const int InvalidImage = 7003;
        public const int InvalidDataLength = 7004;
        public const int TransferFailed = 7005;
        public const int InvalidException = 7006;
        public const int DecompressFailed = 7007;
        public const int LockViolation = 7008;
        public const int EndOfTask = 7009;
        public const int UserAbort = 7010;
        public const int RemoteProcedureCallError = 7011;
        public const int CameraControlBase = 8000;
        public const int CameraControlSystemBase = 8500;
        public const int CameraControlSystemInvalidConnection = 8501;
        public const int CameraControlSystemAccessDenied = 8502;
        public const int CameraControlSystemConnectionLost = 8503;
        public const int CameraControlSystemInterfaceMissing = 8504;

        public static string GetMessage(int errorCode)
        {
            switch (errorCode)
            {
                case Success: return "Operation successful";
                case WrongCameraName: return "Wrong camera name";
                case LowVirtualMemory: return "Virtual memory is too low";
                case ConnectionLost: return "Connection has been lost";
                case HardwareError: return "Hardware error";
                case WrongCredentials: return "Wrong username or password";
                case NetworkError: return "Network (RPC) error";
                case ConnectionFailed: return "Remote Video Server application is not responding";
                case RemoteProcedureCallErrorInvalidVersion: return "Invalid version";
                case TimeoutErrorCode: return "Connection timed out";
                case NoVideoServerCredentialsFound: return "No video server credentials found";
                case UnknownErrorOccurred: return "Unknown error occurred during connection";
                case NoResult: return "No result";

                case LimitedConnectionCount: return "Limited connection count";
                case UnknownState: return "Unknown state";
                case CameraNameNotSupported: return "Connection with camera name is not supported, use id instead";
                case RpcNotConnected: return "RPC: Not connected";
                case RpcServerConnectionError: return "RPC server connection error";
                case InvalidRpcParameters: return "Invalid RPC parameters";
                case InvalidRpcConnection: return "Invalid RPC connection";
                case RpcExceptionOccurred: return "RPC exception occurred";
                case RpcFailedOrCallUnsuccessful: return "RPC failed / RPC call unsuccessful";

                case RecorderBase: return "An error occurred in the recorder module";
                case InvalidRegistry: return "Invalid registry configuration detected";
                case InvalidDriverName: return "The specified driver name is invalid";
                case HardwareDriverConnectError: return "Failed to connect to the hardware driver";
                case DriverConnectError: return "General driver connection error";
                case DriverError: return "A generic driver error occurred";

                case DirectShowDriverNotFound: return "DirectShow driver was not found";
                case DirectShowSetVideoStandard: return "Failed to set DirectShow video standard";
                case DirectShowSetVideoFormat: return "Failed to set DirectShow video format";
                case DirectShowGetVideoFormat: return "Failed to get video format from DirectShow";
                case DirectShowCaptureTimeout: return "DirectShow capture operation timed out";
                case DirectShowActiveMovie: return "ActiveMovie error occurred during playback";
                case DirectShowInvalidVideoSignal: return "Invalid video signal detected in DirectShow";
                case DirectShowDigitalSignalProcessorCapturedDataRegisterError: return "DSP register error during video data capture";

                case ChannelBase: return "Base channel error occurred";
                case ChannelInvalidRegistry: return "Channel configuration registry is invalid";
                case ChannelQueueError: return "Error in the channel processing queue";
                case ChannelFileOpenError: return "Failed to open channel output file";
                case ChannelHardwareError: return "Hardware error in video channel";
                case ChannelImageProcessError: return "Image processing error in video channel";
                case ChannelWriteHardwareError: return "Failed to write to channel hardware";
                case ChannelWriteError: return "Error while writing channel data to output";
                case ChannelCameraLicense: return "Camera license validation failed";
                case ChannelVideoSignalLost: return "Video signal lost on channel";
                case ChannelException: return "An unexpected error occurred in the video channel";
                case ChannelSystemTimeChanged: return "System time change detected – channel recording may be affected";
                case ChannelCameraMoved: return "Camera movement detected on channel";
                case ChannelCameraStop: return "Camera feed has stopped on channel";
                case ChannelCameraLowDetail: return "Low detail level detected in camera image";

                case RemoteProcedureCallServerBase: return "Base RPC server error occurred";
                case RemoteProcedureCallInvalidFileName: return "RPC failed: Invalid file name";
                case RemoteProcedureCallInvalidFunctionCall: return "RPC failed: Invalid function call";
                case RemoteProcedureCallFileOpenFailed: return "RPC failed: Could not open file";
                case RemoteProcedureCallInvalidFilePointer: return "RPC failed: Invalid file pointer";
                case RemoteProcedureCallEndOfFile: return "RPC reached end of file";
                case RemoteProcedureCallInvalidConnection: return "RPC failed: Invalid connection";
                case RemoteProcedureCallInvalidCameraIndex: return "RPC failed: Invalid camera index";
                case RemoteProcedureCallNotImplemented: return "RPC call is not implemented";
                case RemoteProcedureCallEndOfFrame: return "RPC reached end of video frame";
                case RemoteProcedureCallEndOfTimeline: return "RPC reached end of timeline";
                case RemoteProcedureCallInvalidHardLock: return "RPC failed due to invalid hard lock";
                case RemoteProcedureCallUserAbort: return "RPC was aborted by user";
                case RemoteProcedureCallInvalidServerProtocolVersion: return "RPC failed due to protocol version mismatch";

                case RemoteProcedureCallErrorNotImplemented: return "RPC error: Function not implemented";
                case RemoteProcedureCallErrorAccessDenied: return "RPC error: Access denied";
                case RemoteProcedureCallErrorInvalidTrack: return "RPC error: Invalid track selected";
                case RemoteProcedureCallErrorInvalidCall: return "RPC error: Invalid call attempt";
                case RemoteProcedureCallErrorCallFailed: return "RPC call failed";
                case RemoteProcedureCallErrorPreviewUnavailable: return "RPC error: Preview unavailable";

                case RemoteProcedureCallConnectSocketFailed: return "Failed to connect RPC socket";
                case RemoteProcedureCallCreateSocketFailed: return "Failed to create RPC socket";
                case RemoteProcedureCallSocketReceiveTimeout: return "RPC socket receive timeout";
                case RemoteProcedureCallForceCloseSocket: return "RPC socket was forcibly closed";

                // case VideoPlayerBase: return "Base error in video player module";
                case TapeFileErrorBase: return "Base error related to tape file operations";
                case TapeFileInvalidPosition: return "Invalid position encountered in tape file";
                case AbortBase: return "Operation aborted unexpectedly";
                case KeyFrameTransfer: return "Failed to transfer keyframe data";
                case InvalidKeyFrame: return "Keyframe data is invalid or corrupted";
                case InvalidImage: return "Invalid image data received";
                case InvalidDataLength: return "Unexpected data length encountered";
                case TransferFailed: return "Data transfer operation failed";
                case InvalidException: return "An invalid exception was thrown";
                case DecompressFailed: return "Failed to decompress video or image data";
                case LockViolation: return "Resource lock violation occurred";
                case EndOfTask: return "The task ended prematurely or was terminated";
                case UserAbort: return "Operation aborted by the user";
                case RemoteProcedureCallError: return "General RPC error occurred";
                case CameraControlBase: return "Base error in camera control module";
                case CameraControlSystemBase: return "Base system-level error in camera control";
                case CameraControlSystemInvalidConnection: return "Invalid connection to camera control system";
                case CameraControlSystemAccessDenied: return "Access to camera control system was denied";
                case CameraControlSystemConnectionLost: return "Lost connection to camera control system";
                case CameraControlSystemInterfaceMissing: return "Camera control system interface is missing or unavailable";

                default:
                    return $"Unknown error: {errorCode}";
            }
        }
    }
}
