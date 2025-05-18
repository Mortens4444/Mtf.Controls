using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiErasingCommands
{
    public class EraseFromStartOfScreen : IAnsiErasingCommand
    {
        public void Execute(IAnsiErasingCommandContext ansiErasingCommandContext)
        {
            ansiErasingCommandContext.EraseFromStartToCursor();
        }
    }
}
