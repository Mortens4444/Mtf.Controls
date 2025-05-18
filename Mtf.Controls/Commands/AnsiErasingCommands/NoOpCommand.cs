using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Commands.AnsiErasingCommands
{
    public class NoOpCommand : IAnsiErasingCommand
    {
        public void Execute(IAnsiErasingCommandContext ansiErasingCommandContext) { }
    }
}
