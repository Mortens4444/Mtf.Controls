using System;

namespace Mtf.Controls.Interfaces
{
    public interface IAnsiErasingCommandContext
    {
        bool DeleteNewLineCharactersWhenEraseLineCalled { get; }

        void EraseFromCursorToEndOfLine();

        void EraseFromCursorToEndOfScreen();
        
        void EraseFromStartOfLineToCursor();
        
        void EraseFromStartToCursor();
        
        void EraseLine();

        void EraseLineWithNewLine();

        void EraseSavedLines();

        void EraseScreen();
    }
}
