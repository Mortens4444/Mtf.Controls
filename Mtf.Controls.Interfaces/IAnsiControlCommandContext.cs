namespace Mtf.Controls.Interfaces
{
    public interface IAnsiControlCommandContext
    {
        void Bell();

        void Backspace();

        void HorizontalTab();

        void LineFeed();

        void VerticalTab();

        void FormFeed();

        void CarriageReturn();

        void Delete();
    }
}
