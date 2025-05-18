using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiErasingCommands
{
    public class EraseEntireScreen : IAnsiErasingCommand
    {
        public void Execute(IAnsiErasingCommandContext ansiErasingCommandContext)
        {
            ansiErasingCommandContext.EraseScreen();
        }
    }
}
