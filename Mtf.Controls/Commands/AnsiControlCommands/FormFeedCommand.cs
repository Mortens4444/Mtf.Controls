using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiControlCommands
{
    public class FormFeedCommand : IAnsiControlCommand
    {
        public void Execute(IAnsiControlCommandContext context)
        {
            context.FormFeed();
        }
    }
}
