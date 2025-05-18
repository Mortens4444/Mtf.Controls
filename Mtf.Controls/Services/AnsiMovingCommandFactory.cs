using Mtf.Controls.Commands.AnsiMovingCommands;
using Mtf.Controls.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace Mtf.Controls.Services
{
    public static class AnsiMovingCommandFactory
    {
        public static IAnsiMovingCommand Create(string ansiCode, string codesString, Match match)
        {
            if (ansiCode == "\x1B[H")
            {
                return new MoveCaretToHome();
            }

            if (ansiCode.StartsWith("\x1B[") && ansiCode.EndsWith("H"))
            {
                return new MoveCaretToPosition(codesString);
            }

            if (ansiCode.StartsWith("\x1B[") && ansiCode.EndsWith("f"))
            {
                return new MoveCaretToPosition(codesString);
            }

            if (ansiCode.StartsWith("\x1B[") && ansiCode.EndsWith("A"))
            {
                return new MoveCaretUp(codesString);
            }

            if (ansiCode.StartsWith("\x1B[") && ansiCode.EndsWith("B"))
            {
                return new MoveCaretDown(ParseCount(codesString));
            }

            if (ansiCode.StartsWith("\x1B[") && ansiCode.EndsWith("C"))
            {
                return new MoveCaretRight(ParseCount(codesString));
            }

            if (ansiCode.StartsWith("\x1B[") && ansiCode.EndsWith("D"))
            {
                return new MoveCaretLeft(ParseCount(codesString));
            }

            if (ansiCode.StartsWith("\x1B[") && ansiCode.EndsWith("E"))
            {
                return new MoveCaretNextLine(ParseCount(codesString));
            }

            if (ansiCode.StartsWith("\x1B[") && ansiCode.EndsWith("F"))
            {
                return new MoveCaretPrevLine(ParseCount(codesString));
            }

            if (ansiCode.StartsWith("\x1B[") && ansiCode.EndsWith("G"))
            {
                return new MoveCaretToColumn(ParseCount(codesString));
            }

            if (ansiCode == "\x1BM") // ESC M
            {
                return new MoveCaretLineUp(ParseCount(codesString));
            }

            if (ansiCode == "\x1B7" || ansiCode == "\x1B[s")
            {
                return new SaveCaretPosition();
            }

            if (ansiCode == "\x1B8" || ansiCode == "\x1B[u")
            {
                return new RestoreCaretPosition();
            }

            return new NoOpCommand();
        }

        private static int ParseCount(string value)
        {
            if (Int32.TryParse(value, out var result))
            {
                return result;
            }

            return 1;
        }
    }
}
