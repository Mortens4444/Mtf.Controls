using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiErasingCommands
{
    public class EraseEntireLine : IAnsiErasingCommand
    {
        public void Execute(IAnsiErasingCommandContext ansiErasingCommandContext)
        {
            if (ansiErasingCommandContext.DeleteNewLineCharactersWhenEraseLineCalled)
            {
                ansiErasingCommandContext.EraseLineWithNewLine();
            }
            else
            {
                ansiErasingCommandContext.EraseLine();
            }
        }
    }
}
