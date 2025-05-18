using Mtf.Controls.Interfaces;
using System;

namespace Mtf.Controls.Commands.AnsiMovingCommands
{
    public class RestoreCaretPosition : IAnsiMovingCommand
    {
        public void Execute(IAnsiMovingCommandContext context)
        {
            context.SelectionStart = Math.Min(context.SavedCaretPosition, context.TextLength);
            context.ScrollToCaret();
        }
    }
}
