using Mtf.Controls.Interfaces;
using System.Drawing;

namespace Mtf.Controls.Commands.AnsiColoringCommands
{
    public class ResetCommand : IAnsiColoringCommand
    {
        public void Execute(IAnsiColoringCommandContext context)
        {
            context.CurrentColor = context.DefaultFontColor;
            context.CurrentBackColor = context.DefaultBackgroundColor;
            context.CurrentFontStyle = FontStyle.Regular;
        }
    }
}
