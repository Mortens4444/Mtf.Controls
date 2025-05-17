using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiMovingCommands
{
    public class MoveCaretToHome : IAnsiMovingCommand
    {
        public void Execute(IAnsiMovingCommandContext context)
        {
            context.SelectionStart = 0;
            context.ScrollToCaret();
        }
    }
}
