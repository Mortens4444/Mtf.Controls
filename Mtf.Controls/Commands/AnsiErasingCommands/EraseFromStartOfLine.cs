using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiErasingCommands
{
    public class EraseFromStartOfLine : IAnsiErasingCommand
    {
        public void Execute(IAnsiErasingCommandContext ansiErasingCommandContext)
        {
            ansiErasingCommandContext.EraseFromStartOfLineToCursor();
        }
    }
}
