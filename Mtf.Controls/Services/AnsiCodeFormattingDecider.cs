using System;

namespace Mtf.Controls.Services
{
    public static class AnsiCodeFormattingDecider
    {
        public static bool IsColoringCode(string ansiCode)
        {
            return ansiCode.EndsWith("m", StringComparison.InvariantCulture);
        }

        public static bool IsMovingCode(string ansiCode)
        {
            return ansiCode.EndsWith("H", StringComparison.InvariantCulture) || ansiCode.EndsWith("f", StringComparison.InvariantCulture);
        }
    }
}
