using Mtf.Controls.Interfaces;
using System;

namespace Mtf.Controls.Commands.AnsiMovingCommands
{
    public class MoveCaretToPosition : IAnsiMovingCommand
    {
        private readonly int line;
        private readonly int column;

        public MoveCaretToPosition(string code)
        {
            var parts = code.Split(';');
            line = parts.Length > 0 && Int32.TryParse(parts[0], out var l) ? l : 1;
            column = parts.Length > 1 && Int32.TryParse(parts[1], out var c) ? c : 1;
        }

        public void Execute(IAnsiMovingCommandContext context)
        {
            var lines = context.Lines;
            if (line - 1 < lines.Length)
            {
                var pos = 0;
                for (var i = 0; i < line - 1; i++)
                {
                    pos += lines[i].Length + 1;
                }

                pos += Math.Min(column - 1, lines[line - 1].Length);
                context.SelectionStart = Math.Min(pos, context.TextLength);
                context.ScrollToCaret();
            }
        }
    }
}
