using Mtf.Controls.Commands.AnsiErasingCommands;
using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Services
{
    public static class AnsiErasingCommandFactory
    {
        public static IAnsiErasingCommand Create(string ansiCode)
        {
            if (ansiCode == "\x1B[J" || ansiCode == "\x1B[0J")
            {
                return new EraseToEndOfScreen();
            }

            if (ansiCode == "\x1B[1J")
            {
                return new EraseFromStartOfScreen();
            }

            if (ansiCode == "\x1B[2J")
            {
                return new EraseEntireScreen();
            }

            if (ansiCode == "\x1B[3J")
            {
                return new EraseSavedLines();
            }

            if (ansiCode == "\x1B[K" || ansiCode == "\x1B[0K")
            {
                return new EraseToEndOfLine();
            }

            if (ansiCode == "\x1B[1K")
            {
                return new EraseFromStartOfLine();
            }

            if (ansiCode == "\x1B[2K")
            {
                return new EraseEntireLine();
            }

            return new NoOpCommand();
        }
    }
}
