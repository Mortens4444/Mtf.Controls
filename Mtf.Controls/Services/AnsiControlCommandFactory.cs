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
                case '\b': return new BackspaceCommand();
                case '\t': return new TabCommand();
                case '\v': return new VerticalTabCommand();
                case '\f': return new FormFeedCommand();
                case '\x7F': return new DeleteCommand();
                default: return null;
            }
        }
    }
}
