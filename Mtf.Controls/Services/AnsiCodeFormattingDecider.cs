using System;
using System.Text.RegularExpressions;

namespace Mtf.Controls.Services
{
    public static class AnsiCodeFormattingDecider
    {
        public static bool IsColoringCode(string ansiCode)
        {
            return ansiCode.EndsWith("m", StringComparison.InvariantCulture);
        }

        public static bool IsMovingCode(string ansiCode, out Match match)
        {
            var codeRegex = new Regex(@"\x1b\[(\d*(;\d+)*)[A-Hf]");
            match = codeRegex.Match(ansiCode);
            return match.Success;
        }
    }
}
