using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiColoringCommands
{
    public class RestoreTextColorCommand : IAnsiColoringCommand
    {
        public void Execute(IAnsiColoringCommandContext context)
        {
            context.ForeColor = context.LastUsedFontColor;
        }
    }
}
