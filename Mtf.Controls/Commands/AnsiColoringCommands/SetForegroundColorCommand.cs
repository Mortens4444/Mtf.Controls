using Mtf.Controls.Interfaces;
using System.Drawing;

namespace Mtf.Controls.Commands.AnsiColoringCommands
{
    public class SetForegroundColorCommand : IAnsiColoringCommand
    {
        private readonly Color color;

        public SetForegroundColorCommand(Color color) => this.color = color;

        public void Execute(IAnsiColoringCommandContext context)
        {
            context.CurrentColor = color;
        }
    }
}
