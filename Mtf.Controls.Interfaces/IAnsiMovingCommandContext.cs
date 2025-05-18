namespace Mtf.Controls.Interfaces
{
    public interface IAnsiMovingCommandContext
    {
        int SavedCaretPosition { get; set; }

        int SelectionStart { get; set; }
        
        int TextLength { get; }

        string[] Lines { get; }

        void ScrollToCaret();

        int GetLineLength(int lineIndex);

        int GetLineIndexAtCaret();

        int GetColumnAtCaret();

        int GetLineCount();

        int GetCharIndexFromLineAndColumn(int newLine, int col);

        int GetLineFromCharIndex(int selectionStart);

        int GetFirstCharIndexOfCurrentLine();

        int GetFirstCharIndexFromLine(int newLine);
    }
}
