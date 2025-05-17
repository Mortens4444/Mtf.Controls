using Mtf.Controls.Interfaces;
using System.Drawing;

namespace Mtf.Controls.Commands.AnsiColoringCommands
{
    public class SetStrikeoutCommand : IAnsiColoringCommand
    {
        public void Execute(IAnsiColoringCommandContext context)
        {
            context.CurrentFontStyle |= FontStyle.Strikeout;
        }
    }
}
