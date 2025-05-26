using System;
using System.Text.RegularExpressions;

namespace Mtf.Controls.Services
{
    public static class AnsiCodeFormattingDecider
    {
        public static bool IsControlCode(string ansiCode)
        {
            return (ansiCode == "\a") || (ansiCode == "\b") || (ansiCode == "\t") ||
                (ansiCode == "\v") || (ansiCode == "\f") || (ansiCode == "\x7F");
        }

        public static bool IsColoringCode(string ansiCode)
        {
            return ansiCode.EndsWith("m", StringComparison.InvariantCulture);
        }

        public static bool IsMovingCode(string ansiCode, out Match match)
        {
            var codeRegex = new Regex(@"\x1B\[(\d*(;\d+)*)[A-Hf]");
            match = codeRegex.Match(ansiCode);
            return match.Success;
        }

        public static bool IsErasingCode(string ansiCode)
        {
            return ansiCode.StartsWith("\x1B[") && (ansiCode.EndsWith("J") || ansiCode.EndsWith("K"));
        }
    }
}
