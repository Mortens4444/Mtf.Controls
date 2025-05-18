using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiControlCommands
{
    public class BellCommand : IAnsiControlCommand
    {
        public void Execute(IAnsiControlCommandContext context)
        {
            context.Bell();
        }
    }
}
