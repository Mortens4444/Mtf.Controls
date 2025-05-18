namespace Mtf.Controls.Interfaces
{
    public interface IAnsiErasingCommandContext
    {
        void EraseFromCursorToEndOfLine();
        void EraseFromCursorToEndOfScreen();
        void EraseFromStartOfLineToCursor();
        void EraseFromStartToCursor();
        void EraseLine();
        void EraseSavedLines();

        void EraseScreen();
    }
}
