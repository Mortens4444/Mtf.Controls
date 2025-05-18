using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiControlCommands
{
    public class LineFeedCommand : IAnsiControlCommand
    {
        public void Execute(IAnsiControlCommandContext context)
        {
            context.LineFeed();
        }
    }
}
