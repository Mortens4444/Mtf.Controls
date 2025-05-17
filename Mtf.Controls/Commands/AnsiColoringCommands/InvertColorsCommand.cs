using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiColoringCommands
{
    public class InvertColorsCommand : IAnsiColoringCommand
    {
        public void Execute(IAnsiColoringCommandContext context)
        {
            context.LastUsedFontColor = context.ForeColor;
            context.LastUsedBackColor = context.BackColor;
            var tmp = context.CurrentColor;
            context.CurrentColor = context.CurrentBackColor;
            context.CurrentBackColor = tmp;
        }
    }
}
