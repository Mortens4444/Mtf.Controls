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

            if (ansiCode == "\x1B7" || ansiCode == "\x1B[s")
            {
                return new SaveCaretPosition();
            }

            if (ansiCode == "\x1B8" || ansiCode == "\x1B[u")
            {
                return new RestoreCaretPosition();
            }

            if (ansiCode == "\x1BM")
            {
                return new MoveCaretLineUp(ParseCount(codesString));
            }

            if (!ansiCode.StartsWith("\x1B["))
            {
                return new NoOpCommand();
            }

            var lastChar = ansiCode[ansiCode.Length - 1];

            switch (lastChar)
            {
                case 'H':
                case 'f': return new MoveCaretToPosition(codesString);
                case 'A': return new MoveCaretUp(codesString);
                case 'B': return new MoveCaretDown(ParseCount(codesString));
                case 'C': return new MoveCaretRight(ParseCount(codesString));
                case 'D': return new MoveCaretLeft(ParseCount(codesString));
                case 'E': return new MoveCaretNextLine(ParseCount(codesString));
                case 'F': return new MoveCaretPrevLine(ParseCount(codesString));
                case 'G': return new MoveCaretToColumn(ParseCount(codesString));
                default: return new NoOpCommand();
            }
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
