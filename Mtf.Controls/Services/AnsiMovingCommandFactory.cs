using Mtf.Controls.Commands.AnsiMovingCommands;
using Mtf.Controls.Interfaces;
using System;

namespace Mtf.Controls.Services
{
    public static class AnsiMovingCommandFactory
    {
        public static IAnsiMovingCommand Create(string ansiCode, string codesString, AnsiColoringRichTextBox ansiColoringRichTextBox)
        {
            if (Int32.TryParse(codesString, out int code))
            {
            }
            else
            {
                if (ansiCode.EndsWith("H", StringComparison.InvariantCulture))
                {
                    return new MoveCaretToHome();
                }
            }

            return new NoOpCommand();
        }
    }
}
