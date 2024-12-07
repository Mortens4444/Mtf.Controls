using Mtf.MessageBoxes;
using System;
using System.IO;

namespace Mtf.Controls.Services
{
    public static class DirectoryUtils
    {
        public static void CopyDirectory(string sourceDir, string targetDir)
        {
            _ = Directory.CreateDirectory(targetDir);

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                var destFile = Path.Combine(targetDir, Path.GetFileName(file));
                File.Copy(file, destFile);
            }

            foreach (var directory in Directory.GetDirectories(sourceDir))
            {
                var destDir = Path.Combine(targetDir, Path.GetFileName(directory));
                CopyDirectory(directory, destDir);
            }
        }

        public static long CalculateDirectorySize(string directoryPath)
        {
            long size = 0;
            var files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);

            Exception firstException = null;

            foreach (var file in files)
            {
                try
                {
                    var fileInfo = new FileInfo(file);
                    size += fileInfo.Length;
                }
                catch (Exception ex)
                {
                    if (firstException == null)
                    {
                        firstException = ex;
                    }
                }
            }

            if (firstException != null)
            {
                _ = ErrorBox.Show("Size calculation error", $"There were errors while calculating directory size: {firstException.Message}");
            }

            return size;
        }
    }
}
