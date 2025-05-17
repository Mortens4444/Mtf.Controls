using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiColoringCommands
{
    public class NoOpCommand : IAnsiColoringCommand
    {
        public void Execute(IAnsiColoringCommandContext context) { }
    }
}
