using Mtf.Controls.Enums;
using System;
using System.Drawing;

namespace Mtf.Controls.Services
{
    public static class ColoringModeConverter
    {
        public static AnsiColoringMode ColorToAnsiColoringMode(AnsiColoringRichTextBox ansiColoringRichTextBox, Color color, bool backColor)
        {
            if (color.ToArgb() == ansiColoringRichTextBox.BlackColor.ToArgb())
            {
                return backColor ? AnsiColoringMode.BlackBackColor : AnsiColoringMode.BlackFontColor;
            }
            if (color.ToArgb() == ansiColoringRichTextBox.RedColor.ToArgb())
            {
                return backColor ? AnsiColoringMode.RedBackColor : AnsiColoringMode.RedFontColor;
            }
            if (color.ToArgb() == ansiColoringRichTextBox.GreenColor.ToArgb())
            {
                return backColor ? AnsiColoringMode.GreenBackColor : AnsiColoringMode.GreenFontColor;
            }
            if (color.ToArgb() == ansiColoringRichTextBox.YellowColor.ToArgb())
            {
                return backColor ? AnsiColoringMode.YellowBackColor : AnsiColoringMode.YellowFontColor;
            }

            if (color.ToArgb() == ansiColoringRichTextBox.BlueColor.ToArgb())
            {
                return backColor ? AnsiColoringMode.BlueBackColor : AnsiColoringMode.BlueFontColor;
            }
            if (color.ToArgb() == ansiColoringRichTextBox.PurpleColor.ToArgb())
            {
                return backColor ? AnsiColoringMode.PurpleBackColor : AnsiColoringMode.PurpleFontColor;
            }
            if (color.ToArgb() == ansiColoringRichTextBox.CyanColor.ToArgb())
            {
                return backColor ? AnsiColoringMode.CyanBackColor : AnsiColoringMode.CyanFontColor;
            }
            if (color.ToArgb() == ansiColoringRichTextBox.WhiteColor.ToArgb())
            {
                return backColor ? AnsiColoringMode.WhiteBackColor : AnsiColoringMode.WhiteFontColor;
            }

            if (color.ToArgb() == ansiColoringRichTextBox.BrightBlackColor.ToArgb())
            {
                return backColor ? AnsiColoringMode.BrightBlackBackColor : AnsiColoringMode.BrightBlueFontColor;
            }
            if (color.ToArgb() == ansiColoringRichTextBox.BrightRedColor.ToArgb())
            {
                return backColor ? AnsiColoringMode.BrightRedBackColor : AnsiColoringMode.BrightRedFontColor;
            }
            if (color.ToArgb() == ansiColoringRichTextBox.BrightGreenColor.ToArgb())
            {
                return backColor ? AnsiColoringMode.BrightGreenBackColor : AnsiColoringMode.BrightGreenFontColor;
            }
            if (color.ToArgb() == ansiColoringRichTextBox.BrightYellowColor.ToArgb())
            {
                return backColor ? AnsiColoringMode.BrightYellowBackColor : AnsiColoringMode.BrightYellowFontColor;
            }

            if (color.ToArgb() == ansiColoringRichTextBox.BrightBlueColor.ToArgb())
            {
                return backColor ? AnsiColoringMode.BrightBlueBackColor : AnsiColoringMode.BrightBlueFontColor;
            }
            if (color.ToArgb() == ansiColoringRichTextBox.BrightPurpleColor.ToArgb())
            {
                return backColor ? AnsiColoringMode.BrightPurpleBackColor : AnsiColoringMode.BrightPurpleFontColor;
            }
            if (color.ToArgb() == ansiColoringRichTextBox.BrightCyanColor.ToArgb())
            {
                return backColor ? AnsiColoringMode.BrightCyanBackColor : AnsiColoringMode.BrightCyanFontColor;
            }
            if (color.ToArgb() == ansiColoringRichTextBox.WhiteColor.ToArgb())
            {
                return backColor ? AnsiColoringMode.BrightWhiteBackColor : AnsiColoringMode.BrightWhiteFontColor;
            }

            throw new NotSupportedException("This color is not supported.");
        }
    }
}
