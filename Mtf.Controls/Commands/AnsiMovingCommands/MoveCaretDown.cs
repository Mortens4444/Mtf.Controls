using Mtf.Controls.Interfaces;
using System;

namespace Mtf.Controls.Commands.AnsiMovingCommands
{
    public class MoveCaretDown : IAnsiMovingCommand
    {
        private readonly int count;

        public MoveCaretDown(int count)
        {
            this.count = count;
        }

        public void Execute(IAnsiMovingCommandContext context)
        {
            var lineIndex = context.GetLineIndexAtCaret();
            var col = context.GetColumnAtCaret();
            var newLine = Math.Min(lineIndex + count, context.GetLineCount() - 1);
            context.SelectionStart = context.GetCharIndexFromLineAndColumn(newLine, col);
            context.ScrollToCaret();
        }
    }
}
