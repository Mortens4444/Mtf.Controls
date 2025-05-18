using Mtf.Controls.Interfaces;
using System;

namespace Mtf.Controls.Commands.AnsiMovingCommands
{
    public class MoveCaretLineUp : IAnsiMovingCommand
    {
        private readonly int count;

        public MoveCaretLineUp(int count)
        {
            this.count = count;
        }

        public void Execute(IAnsiMovingCommandContext context)
        {
            var line = context.GetLineIndexAtCaret();
            var col = context.GetColumnAtCaret();
            var newLine = Math.Max(line - count, 0);
            context.SelectionStart = context.GetCharIndexFromLineAndColumn(newLine, col);
            context.ScrollToCaret();
        }
    }
}
