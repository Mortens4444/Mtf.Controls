using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiMovingCommands
{
    public class NoOpCommand : IAnsiMovingCommand
    {
        public void Execute(IAnsiMovingCommandContext context) { }
    }
}
