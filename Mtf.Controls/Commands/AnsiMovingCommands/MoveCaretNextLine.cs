using Mtf.Controls.Interfaces;
using System;

namespace Mtf.Controls.Commands.AnsiMovingCommands
{
    public class MoveCaretNextLine : IAnsiMovingCommand
    {
        private readonly int count;

        public MoveCaretNextLine(int count)
        {
            this.count = count;
        }

        public void Execute(IAnsiMovingCommandContext context)
        {
            var line = context.GetLineIndexAtCaret();
            var newLine = Math.Min(line + count, context.GetLineCount() - 1);
            var col = 0;
            context.SelectionStart = context.GetCharIndexFromLineAndColumn(newLine, col);
            context.ScrollToCaret();
        }
    }
}
