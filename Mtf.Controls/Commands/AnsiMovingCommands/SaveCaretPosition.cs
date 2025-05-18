using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiMovingCommands
{
    public class SaveCaretPosition : IAnsiMovingCommand
    {
        public void Execute(IAnsiMovingCommandContext context)
        {
            context.SavedCaretPosition = context.SelectionStart;
        }
    }
}
