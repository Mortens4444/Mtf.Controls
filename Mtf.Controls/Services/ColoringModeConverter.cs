using Mtf.Controls.Enums;
using System;
using System.Drawing;

namespace Mtf.Controls.Services
{
    public static class ColoringModeConverter
    {
        public static AnsiColoringMode ColorToAnsiColoringMode(AnsiColoringRichTextBox ansiColoringRichTextBox, Color color, bool backColor)
        {
            if (color == ansiColoringRichTextBox.BlackColor)
            {
                return backColor ? AnsiColoringMode.BlackBackColor : AnsiColoringMode.BlackFontColor;
            }
            if (color == ansiColoringRichTextBox.RedColor)
            {
                return backColor ? AnsiColoringMode.RedBackColor : AnsiColoringMode.RedFontColor;
            }
            if (color == ansiColoringRichTextBox.GreenColor)
            {
                return backColor ? AnsiColoringMode.GreenBackColor : AnsiColoringMode.GreenFontColor;
            }
            if (color == ansiColoringRichTextBox.YellowColor)
            {
                return backColor ? AnsiColoringMode.YellowBackColor : AnsiColoringMode.YellowFontColor;
            }

            if (color == ansiColoringRichTextBox.BlueColor)
            {
                return backColor ? AnsiColoringMode.BlueBackColor : AnsiColoringMode.BlueFontColor;
            }
            if (color == ansiColoringRichTextBox.PurpleColor)
            {
                return backColor ? AnsiColoringMode.PurpleBackColor : AnsiColoringMode.PurpleFontColor;
            }
            if (color == ansiColoringRichTextBox.CyanColor)
            {
                return backColor ? AnsiColoringMode.CyanBackColor : AnsiColoringMode.CyanFontColor;
            }
            if (color == ansiColoringRichTextBox.WhiteColor)
            {
                return backColor ? AnsiColoringMode.WhiteBackColor : AnsiColoringMode.WhiteFontColor;
            }

            if (color == ansiColoringRichTextBox.BrightBlackColor)
            {
                return backColor ? AnsiColoringMode.BrightBlackBackColor : AnsiColoringMode.BrightBlueFontColor;
            }
            if (color == ansiColoringRichTextBox.BrightRedColor)
            {
                return backColor ? AnsiColoringMode.BrightRedBackColor : AnsiColoringMode.BrightRedFontColor;
            }
            if (color == ansiColoringRichTextBox.BrightGreenColor)
            {
                return backColor ? AnsiColoringMode.BrightGreenBackColor : AnsiColoringMode.BrightGreenFontColor;
            }
            if (color == ansiColoringRichTextBox.BrightYellowColor)
            {
                return backColor ? AnsiColoringMode.BrightYellowBackColor : AnsiColoringMode.BrightYellowFontColor;
            }

            if (color == ansiColoringRichTextBox.BrightBlueColor)
            {
                return backColor ? AnsiColoringMode.BrightBlueBackColor : AnsiColoringMode.BrightBlueFontColor;
            }
            if (color == ansiColoringRichTextBox.BrightPurpleColor)
            {
                return backColor ? AnsiColoringMode.BrightPurpleBackColor : AnsiColoringMode.BrightPurpleFontColor;
            }
            if (color == ansiColoringRichTextBox.BrightCyanColor)
            {
                return backColor ? AnsiColoringMode.BrightCyanBackColor : AnsiColoringMode.BrightCyanFontColor;
            }
            if (color == ansiColoringRichTextBox.WhiteColor)
            {
                return backColor ? AnsiColoringMode.BrightWhiteBackColor : AnsiColoringMode.BrightWhiteFontColor;
            }

            throw new NotSupportedException("This color is not supported.");
        }
    }
}
