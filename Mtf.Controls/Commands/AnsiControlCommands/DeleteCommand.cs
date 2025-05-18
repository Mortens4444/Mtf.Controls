using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiControlCommands
{
    public class DeleteCommand : IAnsiControlCommand
    {
        public void Execute(IAnsiControlCommandContext context)
        {
            context.Delete();
        }
    }
}
