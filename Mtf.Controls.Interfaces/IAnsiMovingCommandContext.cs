namespace Mtf.Controls.Interfaces
{
    public interface IAnsiMovingCommandContext
    {
        int SelectionStart { get; set; }

        void ScrollToCaret();
    }
}
