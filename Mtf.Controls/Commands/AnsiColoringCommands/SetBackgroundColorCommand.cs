using Mtf.Controls.Interfaces;
using System.Drawing;

namespace Mtf.Controls.Commands.AnsiColoringCommands
{
    public class SetBackgroundColorCommand : IAnsiColoringCommand
    {
        private readonly Color color;

        public SetBackgroundColorCommand(Color color) => this.color = color;

        public void Execute(IAnsiColoringCommandContext context)
        {
            context.CurrentBackColor = color;
        }
    }
}
