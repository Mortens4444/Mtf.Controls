using System;
using System.Collections.Generic;
using System.Globalization;

namespace Mtf.Controls.Services
{
    public static class FileSizeConverter
    {
        private const string Byte = "B";
        private const string KiloByte = "kB";
        private const string MegaByte = "MB";
        private const string GigaByte = "GB";
        private const string TeraByte = "TB";
        private const string PetaByte = "PB";
        private const string ExaByte = "EB";
        private const string ZettaByte = "ZB";
        private const string YottaByte = "YB";

        private static readonly List<string> Units = new List<string> { Byte, KiloByte, MegaByte, GigaByte, TeraByte, PetaByte, ExaByte, ZettaByte, YottaByte };

        public static string ToReadableForm(long fileSizeInBytes)
        {
            double size = fileSizeInBytes;
            var unitIndex = 0;

            while (size >= 1024 && unitIndex < Units.Count - 1)
            {
                size /= 1024;
                unitIndex++;
            }

            return $"{size:0.#} {Units[unitIndex]}";
        }

        public static long FromReadableForm(string fileSize)
        {
            if (String.IsNullOrWhiteSpace(fileSize))
            {
                return 0;
            }

            string valueText = null;
            var multiplier = 1;
            foreach (var unit in Units)
            {
                if (!fileSize.EndsWith($" {unit}", StringComparison.OrdinalIgnoreCase))
                {
                    multiplier *= 1024;
                }
                else
                {
                    valueText = fileSize.Substring(0, fileSize.Length - (unit.Length + 1));
                    break;
                }
            }

            if (valueText == null)
            {
                return 0;
            }

            valueText = valueText.Replace(",", ".");
            return !Double.TryParse(valueText, NumberStyles.Any, CultureInfo.InvariantCulture, out var value) ? 0 : (long)(value * multiplier);
        }
    }
}
