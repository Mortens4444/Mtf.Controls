namespace Mtf.Controls.Interfaces
{
    public interface IAnsiControlCommandContext
    {
        void Bell(); // \a vagy ^G

        void Backspace(); // \b vagy ^H

        void HorizontalTab(); // \t vagy ^I

        void LineFeed(); // \n vagy ^J

        void VerticalTab(); // \v vagy ^K

        void FormFeed(); // \f vagy ^L

        void CarriageReturn(); // \r vagy ^M

        void Escape(); // \e vagy ^[

        void Delete(); // 0x7F
    }
}
