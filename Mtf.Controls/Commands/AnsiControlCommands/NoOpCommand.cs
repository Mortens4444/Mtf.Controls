using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiControlCommands
{
    public class NoOpCommand : IAnsiControlCommand
    {
        public void Execute(IAnsiControlCommandContext ansiControlCommandContext) { }
    }
}
