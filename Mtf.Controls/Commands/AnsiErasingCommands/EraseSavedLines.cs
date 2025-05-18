using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiErasingCommands
{
    public class EraseSavedLines : IAnsiErasingCommand
    {
        public void Execute(IAnsiErasingCommandContext ansiErasingCommandContext)
        {
            ansiErasingCommandContext.EraseSavedLines();
        }
    }
}
