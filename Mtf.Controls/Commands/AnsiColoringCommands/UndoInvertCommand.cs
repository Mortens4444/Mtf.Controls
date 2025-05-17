using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiColoringCommands
{
    public class UndoInvertCommand : IAnsiColoringCommand
    {
        public void Execute(IAnsiColoringCommandContext context)
        {
            context.CurrentColor = context.LastUsedFontColor;
            context.CurrentBackColor = context.LastUsedBackColor;
        }
    }
}
