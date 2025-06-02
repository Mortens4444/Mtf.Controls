namespace Mtf.Controls.Video.ActiveX.Services
{
    public static class PlayStatusInfoProvider
    {
        public static string GetPlayStatusInfo(int playStatus)
        {
            switch (playStatus)
            {
                case 1: return "Stopped";
                case 2: return "Play forward";
                case 3: return "Play reverse";
                case 4: return "Last recorder image";
                case 5: return "Fast forward";
                case 6: return "Fast rewind";
                case 7: return "Live video";
                default: return $"Unknown play status: {playStatus}";
            }
        }
    }
}
