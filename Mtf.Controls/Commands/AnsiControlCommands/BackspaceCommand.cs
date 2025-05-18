using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiControlCommands
{
    public class BackspaceCommand : IAnsiControlCommand
    {
        public void Execute(IAnsiControlCommandContext context)
        {
            context.Backspace();
        }
    }
}
