namespace Mtf.Controls.Video.ActiveX.Services
{
    public static class VideoServerErrorHandler
    {
        public const int Success = 0;
        public const int WrongCameraName = 3001;
        public const int LowVirtualMemory = 3003;
        public const int ConnectionLost = 3004;
        public const int HardwareError = 3009;
        public const int WrongCredentials = 3012;
        public const int NetworkError = 3018;
        public const int ConnectionFailed = 3019;
        public const int PermissionError = 3026;

        public const int TimeoutErrorCode = 4000;
        public const int NoVideoServerCredentialsFound = 4001;
        public const int UnknownErrorOccurred = 4002;
        public const int NoResult = 4003;

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
                case ConnectionFailed: return "Remote Video Server appplication is not responding";
                case PermissionError: return "Security permission error / Invalid version";
                case TimeoutErrorCode: return "Connection timed out";
                case NoVideoServerCredentialsFound: return "No video server credentials found";
                case UnknownErrorOccurred: return "Unknown error occurred during connection";
                case NoResult: return "No result";
                default: return $"{"Unknown error"}: {errorCode}";
            }
        }
    }
}
