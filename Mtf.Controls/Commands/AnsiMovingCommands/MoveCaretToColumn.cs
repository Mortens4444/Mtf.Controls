using Mtf.Controls.Interfaces;
using System;

namespace Mtf.Controls.Commands.AnsiMovingCommands
{
    public class MoveCaretToColumn : IAnsiMovingCommand
    {
        private readonly int column;

        public MoveCaretToColumn(int column)
        {
            this.column = column;
        }

        public void Execute(IAnsiMovingCommandContext context)
        {
            var lineIndex = context.GetLineIndexAtCaret();
            var start = context.GetFirstCharIndexFromLine(lineIndex);
            context.SelectionStart = start + Math.Min(column - 1, context.GetLineLength(lineIndex));
            context.ScrollToCaret();
        }
    }
}
