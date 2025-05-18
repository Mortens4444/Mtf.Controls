using Mtf.Controls.Interfaces;
using System;

namespace Mtf.Controls.Commands.AnsiMovingCommands
{
    public class MoveCaretLeft : IAnsiMovingCommand
    {
        private readonly int count;

        public MoveCaretLeft(int count)
        {
            this.count = count;
        }

        public void Execute(IAnsiMovingCommandContext context)
        {
            context.SelectionStart = Math.Max(context.SelectionStart - count, 0);
            context.ScrollToCaret();
        }
    }
}
