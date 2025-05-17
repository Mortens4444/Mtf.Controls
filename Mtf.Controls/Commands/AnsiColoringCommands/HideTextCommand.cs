using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiColoringCommands
{
    public class HideTextCommand : IAnsiColoringCommand
    {
        public void Execute(IAnsiColoringCommandContext context)
        {
            context.LastUsedFontColor = context.ForeColor;
            context.ForeColor = context.BackColor;
        }
    }
}
