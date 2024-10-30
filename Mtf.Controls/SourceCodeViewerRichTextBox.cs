using Mtf.Controls.Enums;
using Mtf.Controls.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mtf.Controls
{
    [ToolboxItem(true)]
    public class SourceCodeViewerRichTextBox : RichTextBox
    {
        [DllImport("User32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, int[] lParam);

        public static readonly string[] cReservedWords = { "auto", "break", "case", "char", "const", "continue", "default", "do", "double", "else", "enum", "extern", "float", "for", "goto", "if", "int", "long", "register", "return", "short", "signed", "sizeof", "static", "struct", "switch", "typedef", "union", "unsigned", "void", "volatile", "while" };
        public static readonly string[] cppReservedWords = { "asm", "bool", "catch", "class", "const_cast", "delete", "dynamic_cast", "explicit", "false", "friend", "inline", "mutable", "namespace", "new", "operator", "private", "public", "protected", "reinterpret_cast", "static_cast", "template", "this", "throw", "true", "try", "typeid", "typename", "using", "virtual", "wchar_t", "auto", "break", "case", "char", "const", "continue", "default", "do", "double", "else", "enum", "extern", "float", "for", "goto", "if", "int", "long", "register", "return", "short", "signed", "sizeof", "static", "struct", "switch", "typedef", "union", "unsigned", "void", "volatile", "while" };
        public static readonly string[] predefinedIdentifiers = { "cin", "cout", "endl", "include", "INT_MIN", "INT_MAX", "iomanip", "iostream", "main", "MAX_RAND", "npos", "NULL", "std", "string" };
        public static readonly string[] pascalReservedWords = { "absolute", "and", "array", "asm", "begin", "case", "const", "constructor", "destructor", "div", "do", "downto", "else", "end", "file", "for", "function", "goto", "if", "implementation", "in", "inherited", "inline", "interface", "label", "mod", "nil", "not", "object", "of", "on", "operator", "or", "packed", "procedure", "program", "record", "reintroduce", "repeat", "self", "set", "shl", "shr", "string", "then", "to", "type", "unit", "until", "uses", "var", "while", "with", "xor" };
        public static readonly string[] cSharpReservedWords = { "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "const_cast", "reinterpret_cast", "continue", "decimal", "default", "delegate", "DllImport", "dynamic_cast", "static_cast", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while" };
        public static readonly string[] javaReservedWords = { "abstract", "boolean", "break", "byte", "case", "catch", "char", "class", "const", "continue", "default", "do", "double", "else", "extends", "false", "final", "finally", "float", "for", "goto", "assert", "if", "implements", "import", "instanceof", "int", "interface", "long", "native", "new", "null", "package", "private", "protected", "public", "return", "short", "static", "strictfp", "super", "switch", "syncronized", "this", "throw", "throws", "transient", "true", "try", "void", "volatile", "while" };
        public static readonly string[] cPreprocessorDirectives = { "#if", "#else", "#elif", "#endif", "#define", "#undef", "#warning", "#error", "#line", "#region", "#endregion", "#import", "#include", "#using", "#ifdef", "#ifndef", "#pragma" };
        public static readonly string[] visualBasicReservedWords = { "AddHandler", "AddressOf", "Alias", "And", "AndAlso", "Ansi", "Append", "As", "Assembly", "Auto", "Binary", "Boolean", "ByRef", "Byte", "ByVal", "Call", "Case", "Catch", "CBool", "CByte", "CChar", "CDate", "CDec", "CDbl", "Char", "CInt", "Class", "CLng", "CObj", "Compare", "CShort", "CSng", "CStr", "CType", "Date", "Decimal", "Declare", "Default", "Delegate", "Dim", "DllImport", "Do", "Double", "Each", "Else", "ElseIf", "End", "EndIf", "Enum", "Erase", "Error", "Event", "Explicit", "False", "For", "Finally", "Friend", "Function", "Get", "GetType", "GoTo", "Handles", "If", "Implements", "Imports", "In", "Inherits", "Input", "Integer", "Interface", "Is", "Let", "Lib", "Like", "Lock", "Long", "Loop", "Me", "Mid", "Mod", "Module", "MustInherit", "MustOverride", "MyBase", "MyClass", "Namespace", "New", "Next", "Not", "Nothing", "NotInheritable", "NotOverridable", "Object", "Off", "On", "Option", "Optional", "Or", "OrElse", "Output", "Overloads", "Overridable", "Overrides", "ParamArray", "Preserve", "Private", "Property", "Protected", "Public", "RaiseEvent", "Random", "Read", "ReadOnly", "ReDim", "Rem", "RemoveHandler", "Resume", "Return", "Seek", "Select", "Set", "Shadows", "Shared", "Short", "Single", "Static", "Step", "Stop", "String", "Structure", "Sub", "SyncLock", "Text", "Then", "Throw", "To", "True", "Try", "TypeOf", "Unicode", "Until", "Variant", "When", "While", "With", "WithEvents", "WriteOnly", "Xor" };

        public static readonly string[] objectPascalControls = { "TMainMenu", "TPopupMenu", "TButton", "TLabel", "TEdit", "TMemo", "TToggleBox", "TCheckBox", "TRadioButton", "TListBox", "TComboBox", "TScroolBar", "TGroupBox", "TRadioGroup", "TCheckGroup", "TPanel", "TFrame", "TActionList", "TBitBtn", "TSpeedButton", "TStaticText", "TImage", "TShape", "TBevel", "TPaintBox", "TNotebook", "TLabeledEdit", "TSplitter", "TTrayIcon", "TMaskEdit", "TCheckListBox", "TScrollBox", "TApplicationProperties", "TstringGrid", "TDrawGrid", "TPairSplitter", "TColorBox", "TColorListBox", "TTrackBar", "TProgressBar", "TTreeView", "TListView", "TStatusBar", "TToolBar", "TUpDown", "TPageControl", "TTabControl", "TheaderControl", "TImageList", "TPopupNotifier", "TOpenDialog", "TSaveDialog", "TSelectDirectoryDialog", "TColorDialog", "TFontDialog", "TFindDialog", "TReplaceDialog", "TOpenPictureDialog", "TSavePictureDialog", "TCalendarDialog", "TCalculatorDialog", "TPrinterSetupDialog", "TPrintDialog", "TPageSetupDialog", "TColorButton", "TSpinEdit", "TFloatSpinEdit", "TArrow", "TCalendar", "TEditButton", "TFileNameEdit", "TDirectoyEdit", "TDateEdit", "TCalcEdit", "TFileListBox", "TFilterComboBox", "TXMLPropStorage", "TIniPropStorage", "TBarChart", "TButtonPanel", "TShellTreeView", "TShellListView", "TIDEDialogLayoutStorage", "TDBNavigator", "TDBText", "TDBEdit", "TDBMemo", "TDBImage", "TDBListBox", "TDBLookupListBox", "TDBComboBox", "TDBLookupComboBox", "TDBCheckBox", "TDBRadioGroup", "TDBCalendar", "TDBGroupBox", "TDBGrid", "TDatasource", "TMemDataset", "TSdfDataset", "TFixedFormatDataSet", "TDbf", "TTimer", "TIdleTimer", "TLazComponentQueue", "THTMLHelpDatabase", "THTMLBrowserHelpViewer", "TAsyncProcess", "TProcessUTF8", "TProcess", "TSimpleIPCClient", "TSimpleIPCServer", "TXMLConfig", "TEventLog", "TSynEdit", "TSynAutoComplete", "TSynExporterHTML", "TSynMacroRecorder", "TSynMemo", "TSynPassSyn", "TSynFreePascalSyn", "TSynCppSyn", "TSynJavaSyn", "TSynPerlSyn", "TSynHTMLSyn", "TSynXMLSyn", "TSynLFMSyn", "TSynUNIXShellScriptSyn", "TSynCssSyn", "TSynPHPSyn", "TSynTeXSyn", "TSynSQLSyn", "TSynPythonSyn", "TSynVBSyn", "TSynAnySyn", "TSynMultiSyn", "TTIEdit", "TTIComboBox", "TTIButton", "TTICheckBox", "TTILabel", "TTIGroupBox", "TTIRadioGroup", "TTICheckGroup", "TTICheckListBox", "TTIListBox", "TTIMemo", "TTICalendar", "TTIImage", "TTIFloatSpinEdit", "TTISpinEditTrackBarProgressBar", "TTIMaskEdit", "TTIColorButton", "TMultiPropertyLink", "TTIPropertyGrid", "TTIGrid", "TIpFileDataProvider", "TIpHtmlPanel", "TChart", "TListChartSource", "TRandomChartSource", "TUserDefinedChartSource", "TDbChartSource", "TSQLQuery", "TSQLTransaction", "TSQLScript", "TSQLConnector", "TPQConnection", "TOracleConnection", "TODBCConnection", "TMySQL40Connection", "TMySQL41Connection", "TSQLite3Connection", "TMySQL50Connection", "TIBConnection" };
        public static readonly string[] objectPascalReservedWords = { "absolute", "and", "array", "asm", "begin", "case", "const", "constructor", "destructor", "div", "do", "downto", "else", "end", "file", "for", "function", "goto", "if", "implementation", "in", "inherited", "inline", "interface", "label", "mod", "nil", "not", "object", "of", "on", "operator", "or", "packed", "procedure", "program", "record", "reintroduce", "repeat", "self", "set", "shl", "shr", "string", "then", "to", "type", "unit", "until", "uses", "var", "while", "with", "xor", "as", "class", "dispinterface", "except", "exports", "finalization", "finally", "initialization", "inline", "is", "library", "on", "out", "property", "raise", "resourcestring", "threadvar", "try" };

        public static readonly string[] cliControls = { "Control", "Form", "MessageBox", "BackgroundWorker", "BindingNavigator", "BindingSource", "Button", "CheckBox", "CheckedListBox", "ColorDialog", "ComboBox", "ContextMenuStrip", "DataGridView", "DataSet", "DateTimePicker", "DirectoryEntry", "DirectorySearcher", "DomainUpDown", "ErrorProvider", "EventLog", "FileSystemWatcher", "FlowLayoutPanel", "FolderBrowserDialog", "FontDialog", "GroupBox", "HelpProvider", "HScroolBar", "ImageList", "Label", "LinkLabel", "ListBox", "ListView", "MaskedTextBox", "MenuStrip", "MessageQueue", "MonthCalendar", "NotifyIcon", "NumericUpDown", "OpenFileDialog", "PageSetupDialog", "Panel", "PerformanceCounter", "PictureBox", "PrintDialog", "PrintDocument", "PrintPreviewControl", "PrintPreviewDialog", "Process", "ProgressBar", "PropertyGrid", "RadioButton", "RichTextBox", "SaveFileDialog", "SerialPort", "ServiceController", "SplitContainer", "Splitter", "StatusStrip", "TabControl", "TableLayoutPanel", "TextBox", "Timer", "ToolStrip", "ToolStripContainer", "ToolTip", "TrackBar", "TreeView", "VScroolBar", "WebBrowser" };
        public static readonly string[] cppCliReservedWords = { "array", "asm", "auto", "bool", "break", "case", "catch", "char", "class", "const", "const_cast", "continue", "default", "delegate", "delete", "DllImport", "dynamic_cast", "static_cast", "do", "double", "dynamic_cast", "else", "enum", "explicit", "export", "extern", "false", "finally", "float", "for", "for each", "friend", "gcnew", "goto", "if", "inline", "int", "literal", "long", "mutable", "namespace", "new", "nullptr", "operator", "pin_ptr", "private", "protected", "public", "register", "reinterpret_cast", "restrict", "return", "safe_cast", "short", "signed", "sizeof", "static", "static_cast", "struct", "switch", "template", "this", "throw", "true", "try", "typedef", "typeid", "typename", "_typeof", "union", "unsigned", "using", "virtual", "void", "volatile", "wchar_t", "while", "ref", "__super", "override", "event", "initonly" };
        public static readonly string[] cliTypes = { "Object", "Boolean", "Char", "SByte", "Byte", "Int16", "UInt16", "Int32", "UInt32", "Int64", "UInt64", "Single", "Double", "Decimal", "DateTime", "string", "__int8", "__int16", "__int32", "__int64", "Thread", "File", "StringBuilder", "StreamReader", "StreamWriter", "IntPtr", "String" };
        public static readonly string[] windowsDataTypes = { "ATOM", "BOOL", "BOOLEAN", "BYTE", "CALLBACK", "CHAR", "COLORREF", "CONST", "DWORD", "DWORDLONG", "DWORD_PTR", "DWORD32", "DWORD64", "FLOAT", "HACCEL", "HALF_PTR", "HANDLE", "HBITMAP", "HBRUSH", "HCOLORSPACE", "HCONV", "HCONVLIST", "HCURSOR", "HDC", "HDDEDATA", "HDESK", "HDROP", "HDWP", "HENHMETAFILE", "HFILE", "HFONT", "HGDIOBJ", "HGLOBAL", "HHOOK", "HICON", "HINSTANCE", "HKEY", "HKL", "HLOCAL", "HMENU", "HMETAFILE", "HMODULE", "HMONITOR", "HPALETTE", "HPEN", "HRESULT", "HRGN", "HRSRC", "HSZ", "HWINSTA", "HWND", "INT", "INT_PTR", "INT32", "INT64", "LANGID", "LCID", "LCTYPE", "LGRPID", "LONG", "LONGLONG", "LONG_PTR", "LONG32", "LONG64", "LPARAM", "LPBOOL", "LPBYTE", "LPCOLORREF", "LPCSTR", "LPCTSTR", "LPCVOID", "LPCWSTR", "LPDWORD", "LPHANDLE", "LPINT", "LPLONG", "LPSTR", "LPTSTR", "LPVOID", "LPWORD", "LPWSTR", "LRESULT", "PBOOL", "PBOOLEAN", "PBYTE", "PCHAR", "PCSTR", "PCTSTR", "PCWSTR", "PDWORD", "PDWORDLONG", "PDWORD_PTR", "PDWORD32", "PDWORD64", "PFLOAT", "PHALF_PTR", "PHANDLE", "PHKEY", "PINT", "PINT_PTR", "PINT32", "PINT64", "PLONG", "PLONGLONG", "PLONG_PTR", "PLONG32", "PLONG64", "POINTER_32", "POINTER_64", "POINTER_SIGNED", "POINTER_UNSIGNED", "PSHORT", "PSIZE_T", "PSSIZE_T", "PSTR", "PTBYTE", "PTCHAR", "PTSTR", "PUCHAR", "PUHALF_PTR", "PUINT", "PUINT_PTR", "PUINT32", "PUINT64", "PULONG", "PULONGLONG", "PULONG_PTR", "PULONG32", "PULONG64", "PUSHORT", "PVOID", "PWCHAR", "PWORD", "PWSTR", "SC_HANDLE", "SC_LOCK", "SERVICE_STATUS_HANDLE", "SHORT", "SIZE_T", "SSIZE_T", "TBYTE", "TCHAR", "UCHAR", "UHALF_PTR", "UINT", "UINT_PTR", "UINT32", "UINT64", "ULONG", "ULONGLONG", "ULONG_PTR", "ULONG32", "ULONG64", "UNICODE_STRING", "USHORT", "USN", "VOID", "WCHAR", "WINAPI", "WORD", "WPARAM" };
        public static readonly string[] cliNamespaces = { "Activation", "API", "Application", "Assemblies", "Assert", "Binary", "Channels", "CodeAnalysis", "CodeDom", "Collections", "Com2Interop", "Common", "Compiler", "CompilerServices", "ComponentModel", "Compression", "ComTypes", "Configuration", "ConstrainedExecution", "Contexts", "CSharp", "Data", "Deployment", "Design", "Diagnostics", "Drawing", "Drawing2D", "Formatters", "Forms", "Generic", "Hosting", "Install", "Internal", "InteropServices", "Imaging", "IO", "IsolatedStorage", "Isolation", "Lifetime", "Media", "Messaging", "Metadata", "Microsoft", "ObjectModel", "Odbc", "OleDb", "Ports", "Printing", "PropertyGridInternal", "ProviderBase", "Proxies", "Remoting", "Runtime", "SafeHandles", "Serialization", "Server", "Services", "Specialized", "Sql", "SqlClient", "SqlServer", "SqlTypes", "Sziltech", "SymbolStore", "System", "Threading", "Text", "Timers", "Versioning", "VisualBasic", "W3cXsd2001", "Win32", "Windows" };

        public static readonly string[] cNamespaces = { "std" };
        private int scrollTo, pos, len;

        public SourceCodeViewerRichTextBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
            ColoringMethod = ColoringMethod.No_Coloring;
            DetectUrls = false;
            AcceptsTab = true;
            SetTabSize();
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Specifies the color application mode for the control.")]
        public ColoringMethod ColoringMethod { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Automatically scrolls to ensure the last line is visible.")]
        public bool ScroolToLastLine { get; set; }

        public string GetTextThreadSafe()
        {
            return this.ExecuteThreadSafely(() => Text);
        }

        public void SetTextThreadSafe(string text)
        {
            _ = this.ExecuteThreadSafely(() => Text = text);
        }

        public void AppendTextThreadSafe(string text, Color? textColor = null)
        {
            this.ExecuteThreadSafely(() =>
            {
                AppendText(text);
                if (textColor.HasValue)
                {
                    var selectionStart = TextLength - text.Length;
                    Select(selectionStart, text.Length);
                    SelectionColor = textColor.Value;
                    SelectionLength = 0;
                }
            });
        }

        private void SetTabSize()
        {
            using (var gr = CreateGraphics())
            {
                var tabSize = gr.MeasureString("M", Font).ToSize().Width;
                _ = SendMessage(Handle, (int)WindowMessage.EM_SETTABSTOPS, 1, new[] { tabSize });
            }
        }

        public void BeginUpdate()
        {
            _ = SendMessage(Handle, 0x000B, 0, Array.Empty<int>());
        }

        public void EndUpdate()
        {
            _ = SendMessage(Handle, 0x000B, 1, Array.Empty<int>());
            Invalidate();
        }

        public void StartUpdate(ref int scrollTo, ref int pos, ref int len)
        {
            BeginUpdate();
            scrollTo = GetCharIndexFromPosition(new Point(1, 1));
            pos = SelectionStart;
            len = SelectionLength;
        }

        public void StopUpdate(int scrollTo, int pos, int len)
        {
            SelectionStart = scrollTo;
            ScrollToCaret();
            SelectionStart = pos;
            SelectionLength = len;
            EndUpdate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (ScroolToLastLine)
            {
                if (TextLength != 0)
                {
                    Select(TextLength - 1, TextLength - 1);
                }

                ScrollToCaret();
            }
            else
            {
                StartUpdate(ref scrollTo, ref pos, ref len);

                if (ColoringMethod != ColoringMethod.No_Coloring)
                {
                    ApplyColoring();
                }

                base.OnTextChanged(e);
                StopUpdate(scrollTo, pos, len);
            }
        }

        public void ClearColoring()
        {
            SelectAll();
            SelectionFont = Font;
            SelectionColor = ForeColor;
        }

        public void ClearBackgroundColoring()
        {
            SelectAll();
            SelectionBackColor = BackColor;
        }

        private void ApplyColoring()
        {
            var matchCase = true;

            ClearColoring();

            string[] reservedWords = null, preprocessorDirectives = null, types = null, namespaces = null, controls = null;

            switch (ColoringMethod)
            {
                case ColoringMethod.CPP_CLI: // C++/CLI
                    reservedWords = cppCliReservedWords;
                    preprocessorDirectives = cPreprocessorDirectives;
                    types = cliTypes;
                    namespaces = cliNamespaces;
                    controls = cliControls;
                    break;
                case ColoringMethod.C_Sharp: // C#
                    reservedWords = cSharpReservedWords;
                    preprocessorDirectives = cPreprocessorDirectives;
                    types = cliTypes;
                    namespaces = cliNamespaces;
                    controls = cliControls;
                    break;
                case ColoringMethod.Java: // Java
                    reservedWords = javaReservedWords;
                    break;
                case ColoringMethod.Object_Pascal: // Object Pascal
                    reservedWords = objectPascalReservedWords;
                    controls = objectPascalControls;
                    matchCase = false;
                    break;
                case ColoringMethod.Visual_Basic: // Visual Basic
                    types = cliTypes;
                    namespaces = cliNamespaces;
                    controls = cliControls;
                    reservedWords = visualBasicReservedWords;
                    matchCase = false;
                    break;
                case ColoringMethod.Visual_CPP: // Visual C++
                    namespaces = cNamespaces;
                    reservedWords = cppReservedWords;
                    preprocessorDirectives = cPreprocessorDirectives;
                    break;
                case ColoringMethod.No_Coloring:
                    return; // Exit early if no coloring is applied
                default:
                    break;
            }

            using (var boldFont = new Font(Font.FontFamily, Font.Size, FontStyle.Bold))
            using (var regularFont = new Font(Font.FontFamily, Font.Size, FontStyle.Regular))
            using (var italicFont = new Font(Font.FontFamily, Font.Size, FontStyle.Italic))
            {
                ColorWithArray(reservedWords, boldFont, Color.Blue, matchCase);
                ColorWithArray(controls, boldFont, Color.DarkGreen, matchCase);
                ColorWithArray(namespaces, boldFont, Color.DarkBlue, matchCase);
                ColorWithArray(types, boldFont, Color.DarkBlue, matchCase);
                ColorWithArray(windowsDataTypes, boldFont, Color.DarkBlue, matchCase);

                ColorWithArray(preprocessorDirectives, boldFont, Color.Purple, Color.DarkRed, matchCase);

                // String and character
                ColorWithString("\"", "\"", regularFont, Color.DarkRed);

                if (ColoringMethod != ColoringMethod.Visual_Basic)
                {
                    ColorWithString("'", "'", regularFont, Color.SteelBlue);
                }

                // Comments
                switch (ColoringMethod)
                {
                    case ColoringMethod.Object_Pascal:
                        ColorWithString("{", "}", italicFont, Color.Green);
                        break;
                    case ColoringMethod.Visual_Basic:
                        ColorWithString("'", null, italicFont, Color.Green);
                        break;
                    case ColoringMethod.No_Coloring:
                        break;
                    case ColoringMethod.CPP_CLI:
                    case ColoringMethod.C_Sharp:
                    case ColoringMethod.Java:
                    case ColoringMethod.Visual_CPP:
                        ColorWithString("//", null, italicFont, Color.Green);
                        ColorWithString("/*", "*/", italicFont, Color.Green);
                        break;
                    default:
                        break;
                }
            }
        }

        private void ColorWithArray(IEnumerable<string> keywords, Font keywordFont, Color color, bool matchCase)
        {
            if (keywords == null)
            {
                return;
            }

            var searchOptions = matchCase ? RichTextBoxFinds.MatchCase : RichTextBoxFinds.None;

            foreach (var keyword in keywords)
            {
                var index = Constants.NotFound;
                while ((index = Find(keyword, index + 1, searchOptions)) != Constants.NotFound)
                {
                    if ((index == 0 || !Char.IsLetterOrDigit(Text[index - 1])) &&
                        (index + keyword.Length >= Text.Length || !Char.IsLetterOrDigit(Text[index + keyword.Length])))
                    {
                        Select(index, keyword.Length);
                        SelectionFont = keywordFont;
                        SelectionColor = color;
                    }
                }
            }
        }

        private void ColorWithArray(string[] keywords, Font keyword_font, Color color, Color color2, bool match_case)
        {
            var fm = match_case ? RichTextBoxFinds.MatchCase : RichTextBoxFinds.None;

            if (keywords == null)
            {
                return;
            }

            for (var i = 0; i < keywords.Length; i++)
            {
                var index = Constants.NotFound;
                while ((index = Find(keywords[i], index + 1, fm)) != Constants.NotFound)
                {
                    if ((index == 0) || ((index > 0) && (!Char.IsLetterOrDigit(Text[index - 1]))))
                    {
                        if ((Text.Length == index + keywords[i].Length) || ((Text.Length > index + keywords[i].Length) && (!Char.IsLetterOrDigit(this.Text[index + keywords[i].Length]))))
                        {
                            Select(index, keywords[i].Length);
                            SelectionFont = keyword_font;
                            SelectionColor = color;

                            var nli = Text.IndexOf(Constants.LineFeed, index + keywords[i].Length, StringComparison.InvariantCulture);
                            if (nli > Constants.NotFound)
                            {
                                Select(index + keywords[i].Length, nli - index - keywords[i].Length);
                            }
                            else
                            {
                                Select(index + keywords[i].Length, Text.Length - index - keywords[i].Length);
                            }

                            SelectionFont = keyword_font;
                            SelectionColor = color2;
                        }
                    }
                }
            }
        }

        public void Coloring(int startIndex, int length, Font font, Color forecolor)
        {
            Coloring(startIndex, length, font, forecolor, BackColor);
        }

        public void Coloring(int startIndex, int length, Font font, Color forecolor, Color backcolor)
        {
            Select(startIndex, length);
            SelectionFont = font;
            SelectionColor = forecolor;
            SelectionBackColor = backcolor;
        }

        private void ColorWithString(string startPattern, string endPattern, Font font, Color color)
        {
            int startIndex, endIndex = Constants.NotFound;

            do
            {
                startIndex = endIndex + 1;
                startIndex = Text.IndexOf(startPattern, startIndex, StringComparison.InvariantCulture);

                if (startIndex == Constants.NotFound)
                {
                    continue;
                }

                endIndex = Text.IndexOf(endPattern ?? Constants.LineFeed, startIndex + 1, StringComparison.InvariantCulture);
                if (endIndex == Constants.NotFound)
                {
                    endIndex = Text.Length;
                }

                if (endPattern != null)
                {
                    Select(startIndex, endIndex - startIndex + endPattern.Length);
                }
                else
                {
                    Select(startIndex, endIndex - startIndex);
                }

                SelectionFont = font;
                SelectionColor = color;
            }
            while ((startIndex != Constants.NotFound) && (endIndex + 1 < Text.Length));
        }
    }
}
