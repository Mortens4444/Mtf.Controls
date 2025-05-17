using Mtf.Controls.Commands.AnsiColoringCommands;
using Mtf.Controls.Interfaces;

namespace Mtf.Controls.Services
{
    public static class AnsiColoringCommandFactory
    {
        public static IAnsiColoringCommand Create(int code, AnsiColoringRichTextBox ansiColoringRichTextBox)
        {
            switch (code)
            {
                case 0: return new ResetCommand();
                case 1: return new SetBoldCommand();
                case 2: return new SetDimCommand();
                case 3: return new SetItalicCommand();
                case 4: return new SetUnderlineCommand();
                case 5: return new NoOpCommand(); // SetBlinkingCommand
                case 7: return new InvertColorsCommand();
                case 8: return new HideTextCommand();
                case 9: return new SetStrikeoutCommand();
                case 22: return new ResetBoldCommand();
                case 23: return new ResetItalicCommand();
                case 24: return new ResetUnderlineCommand();
                case 25: return new NoOpCommand(); // ResetBlinkingCommand
                case 27: return new UndoInvertCommand();
                case 28: return new RestoreTextColorCommand();
                case 29: return new ResetStrikeoutCommand();

                case 30: return new SetForegroundColorCommand(ansiColoringRichTextBox.BlackColor);
                case 31: return new SetForegroundColorCommand(ansiColoringRichTextBox.RedColor);
                case 32: return new SetForegroundColorCommand(ansiColoringRichTextBox.GreenColor);
                case 33: return new SetForegroundColorCommand(ansiColoringRichTextBox.YellowColor);
                case 34: return new SetForegroundColorCommand(ansiColoringRichTextBox.BlueColor);
                case 35: return new SetForegroundColorCommand(ansiColoringRichTextBox.PurpleColor);
                case 36: return new SetForegroundColorCommand(ansiColoringRichTextBox.CyanColor);
                case 37: return new SetForegroundColorCommand(ansiColoringRichTextBox.WhiteColor);

                case 40: return new SetBackgroundColorCommand(ansiColoringRichTextBox.BlackColor);
                case 41: return new SetBackgroundColorCommand(ansiColoringRichTextBox.RedColor);
                case 42: return new SetBackgroundColorCommand(ansiColoringRichTextBox.GreenColor);
                case 43: return new SetBackgroundColorCommand(ansiColoringRichTextBox.YellowColor);
                case 44: return new SetBackgroundColorCommand(ansiColoringRichTextBox.BlueColor);
                case 45: return new SetBackgroundColorCommand(ansiColoringRichTextBox.PurpleColor);
                case 46: return new SetBackgroundColorCommand(ansiColoringRichTextBox.CyanColor);
                case 47: return new SetBackgroundColorCommand(ansiColoringRichTextBox.WhiteColor);

                case 90: return new SetForegroundColorCommand(ansiColoringRichTextBox.BrightBlackColor);
                case 91: return new SetForegroundColorCommand(ansiColoringRichTextBox.BrightRedColor);
                case 92: return new SetForegroundColorCommand(ansiColoringRichTextBox.BrightGreenColor);
                case 93: return new SetForegroundColorCommand(ansiColoringRichTextBox.BrightYellowColor);
                case 94: return new SetForegroundColorCommand(ansiColoringRichTextBox.BrightBlueColor);
                case 95: return new SetForegroundColorCommand(ansiColoringRichTextBox.BrightPurpleColor);
                case 96: return new SetForegroundColorCommand(ansiColoringRichTextBox.BrightCyanColor);
                case 97: return new SetForegroundColorCommand(ansiColoringRichTextBox.BrightWhiteColor);

                case 100: return new SetBackgroundColorCommand(ansiColoringRichTextBox.BrightBlackColor);
                case 101: return new SetBackgroundColorCommand(ansiColoringRichTextBox.BrightRedColor);
                case 102: return new SetBackgroundColorCommand(ansiColoringRichTextBox.BrightGreenColor);
                case 103: return new SetBackgroundColorCommand(ansiColoringRichTextBox.BrightYellowColor);
                case 104: return new SetBackgroundColorCommand(ansiColoringRichTextBox.BrightBlueColor);
                case 105: return new SetBackgroundColorCommand(ansiColoringRichTextBox.BrightPurpleColor);
                case 106: return new SetBackgroundColorCommand(ansiColoringRichTextBox.BrightCyanColor);
                case 107: return new SetBackgroundColorCommand(ansiColoringRichTextBox.BrightWhiteColor);
            }

            return new NoOpCommand();
        }
    }
}
