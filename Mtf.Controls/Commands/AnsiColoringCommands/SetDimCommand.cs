using Mtf.Controls.Interfaces;
using System.Drawing;

namespace Mtf.Controls.Commands.AnsiColoringCommands
{
    class SetDimCommand : IAnsiColoringCommand
    {
        public void Execute(IAnsiColoringCommandContext context)
        {
            context.CurrentColor = Color.FromArgb(128, context.CurrentColor);
        }
    }
}
