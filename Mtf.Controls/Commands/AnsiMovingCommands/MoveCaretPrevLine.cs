using Mtf.Controls.Interfaces;
using System;

namespace Mtf.Controls.Commands.AnsiMovingCommands
{
    public class MoveCaretPrevLine : IAnsiMovingCommand
    {
        private readonly int count;

        public MoveCaretPrevLine(int count)
        {
            this.count = count;
        }

        public void Execute(IAnsiMovingCommandContext context)
        {
            var line = context.GetLineIndexAtCaret();
            var newLine = Math.Max(line - count, 0);
            var col = 0;
            context.SelectionStart = context.GetCharIndexFromLineAndColumn(newLine, col);
            context.ScrollToCaret();
        }
    }
}
