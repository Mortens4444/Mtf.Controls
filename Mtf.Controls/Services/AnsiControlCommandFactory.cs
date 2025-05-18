using Mtf.Controls.Commands.AnsiControlCommands;
using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Services
{
    public static class AnsiControlCommandFactory
    {
        public static IAnsiControlCommand Create(char controlChar)
        {
            switch (controlChar)
            {
                case '\a': return new BellCommand();
                //case '\b': return new BackspaceCommand();
                //case '\t': return new TabCommand();
                //case '\n': return new LineFeedCommand();
                //case '\v': return new VerticalTabCommand();
                //case '\f': return new FormFeedCommand();
                //case '\r': return new CarriageReturnCommand();
                //case '\x1B': return new EscapeCommand();
                //case '\x7F': return new DeleteCommand();
                default: return new NoOpCommand();
            }
        }
    }
}
