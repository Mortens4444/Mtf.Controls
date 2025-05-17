using Mtf.Controls.Interfaces;
using System.Drawing;
using System;

namespace Mtf.Controls.Commands.AnsiColoringCommands
{
    public class ResetBoldCommand : IAnsiColoringCommand
    {
        public void Execute(IAnsiColoringCommandContext context)
        {
            context.CurrentFontStyle &= ~FontStyle.Bold;
            context.CurrentColor = Color.FromArgb(Byte.MaxValue, context.CurrentColor);
        }
    }
}
