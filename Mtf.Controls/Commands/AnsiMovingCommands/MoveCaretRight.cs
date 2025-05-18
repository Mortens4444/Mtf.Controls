using Mtf.Controls.Interfaces;
using System;

namespace Mtf.Controls.Commands.AnsiMovingCommands
{
    public class MoveCaretRight : IAnsiMovingCommand
    {
        private readonly int count;

        public MoveCaretRight(int count)
        {
            this.count = count;
        }

        public void Execute(IAnsiMovingCommandContext context)
        {
            context.SelectionStart = Math.Min(context.SelectionStart + count, context.TextLength);
            context.ScrollToCaret();
        }
    }
}
