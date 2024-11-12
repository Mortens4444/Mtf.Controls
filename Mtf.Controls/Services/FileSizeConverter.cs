namespace Mtf.Controls.Services
{
    public static class FileSizeConverter
    {
        public static string ToReadableForm(long fileSizeInBytes)
        {
            if (fileSizeInBytes < 1024)
            {
                return $"{fileSizeInBytes} byte";
            }

            var fileSizeInKB = fileSizeInBytes / 1024.0;
            if (fileSizeInKB < 1024)
            {
                return $"{fileSizeInKB:0.#} KB";
            }

            var fileSizeInMB = fileSizeInKB / 1024.0;
            if (fileSizeInMB < 1024)
            {
                return $"{fileSizeInMB:0.#} MB";
            }

            var fileSizeInGB = fileSizeInMB / 1024.0;
            return $"{fileSizeInGB:0.#} GB";
        }
    }
}
