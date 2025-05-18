using Mtf.Controls.Interfaces;
using System;

namespace Mtf.Controls.Commands.AnsiMovingCommands
{
    public class MoveCaretUp : IAnsiMovingCommand
    {
        private readonly int lines;
        public MoveCaretUp(string code) => lines = MoveCaretUp.TryParse(code, 1);

        public void Execute(IAnsiMovingCommandContext context)
        {
            var pos = context.GetLineFromCharIndex(context.SelectionStart);
            var newLine = Math.Max(0, pos - lines);
            var offset = context.SelectionStart - context.GetFirstCharIndexOfCurrentLine();
            var newPos = context.GetFirstCharIndexFromLine(newLine) + offset;
            context.SelectionStart = Math.Min(newPos, context.TextLength);
            context.ScrollToCaret();
        }

        private static int TryParse(string s, int def) => Int32.TryParse(s, out var n) ? n : def;
    }
}
