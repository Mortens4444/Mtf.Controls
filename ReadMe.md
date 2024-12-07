# Mtf.Controls Documentation

## Overview

This documentation provides guidance on using the `Mtf.Controls` library in your project, which includes customizable controls like `ListView`, `TreeView`, and `Panel` elements.

To install the `Mtf.Controls` package, follow these steps:

1. **Add Package**:
   - Open the terminal in your project directory.
   - Run the following command:

     ```bash
     dotnet add package Mtf.Controls
     ```

   This will automatically download and reference the `Mtf.Controls` library in your project.

2. **Include the Namespace**:
   At the top of your code file, include the `Mtf.Controls` namespace:

   ```csharp
   using Mtf.Controls;
   ```

## Dependencies and Licensing

This package uses the following dependencies, each under their respective licenses:

- **[Mtf.MessageBoxes](https://www.nuget.org/packages/Mtf.MessageBoxes/)**: Version 2.0.29 (MIT License)
- **[LibVLCSharp](https://www.nuget.org/packages/LibVLCSharp/)**: Version 3.9.1 (LGPL-3.0)
- **[LibVLCSharp.WinForms](https://www.nuget.org/packages/LibVLCSharp.WinForms/)**: Version 3.9.1 (LGPL-3.0)
- **[OpenCvSharp4](https://www.nuget.org/packages/OpenCvSharp4/)**: Version 4.10.0.20241108 (Apache License 2.0)
- **[OpenCvSharp4.Extensions](https://www.nuget.org/packages/OpenCvSharp4.Extensions/)**: Version 4.10.0.20241108 (Apache License 2.0)
- **[OpenCvSharp4.runtime.win](https://www.nuget.org/packages/OpenCvSharp4.runtime.win/)**: Version 4.10.0.20241108 (Apache License 2.0)
- **[System.Net.Http](https://www.nuget.org/packages/System.Net.Http/)**: Version 4.3.4 (MIT License)
- **[VideoLAN.LibVLC.Windows](https://www.nuget.org/packages/VideoLAN.LibVLC.Windows/)**: Version 3.0.21 (LGPL-2.1)
- **[Accord](https://www.nuget.org/packages/Accord/)**: Version 3.8.0 (LGPL-3.0)
- **[Accord.Video](https://www.nuget.org/packages/Accord.Video/)**: Version 3.8.0 (LGPL-3.0)
- **[AForge](https://www.nuget.org/packages/AForge/)**: Version 2.2.5 (LGPL-3.0)
- **[AForge.Video](https://www.nuget.org/packages/AForge.Video/)**: Version 2.2.5 (LGPL-3.0)
- **[AForge.Video.DirectShow](https://www.nuget.org/packages/AForge.Video.DirectShow/)**: Version 2.2.5 (LGPL-3.0)

Each dependency's license applies independently to their respective code. This package complies with their license terms. If you use this package, ensure that you meet the requirements of each dependency's license.

## Using Custom Controls

### AnsiColoringRichTextBox

The `AnsiColoringRichTextBox` is a custom control that extends `RichTextBox` to display text with ANSI color codes, allowing for text formatting with color, bold, and underline styles based on ANSI escape sequences.

#### Properties

- **DisplayAnsiColors** (`bool`): 
  - Specifies whether ANSI color codes should be processed and displayed. 
  - When set to `true`, the control will automatically format text with ANSI colors.

#### Usage Example

```csharp
var ansiTextBox = new AnsiColoringRichTextBox
{
    DisplayAnsiColors = true,
    Text = "\x1B[0;31mThis is red text\x1B[0;32m and this is green text."
};
Controls.Add(ansiTextBox);
```

#### ANSI Color Codes Supported

The `AnsiColoringRichTextBox` recognizes a wide range of ANSI color codes, including:
- **Regular Colors**: Black, Red, Green, Yellow, Blue, Purple, Cyan, White.
- **Bold Colors**: Enhanced versions of regular colors.
- **High Intensity Colors**: Lighter or more intense shades.
- **Bold High Intensity Colors**: Bolder shades of high intensity colors.

#### Methods

- **ClearColoring**: Resets the text formatting to default colors and styles.

#### Events

- **OnTextChanged**: Automatically applies ANSI coloring if `DisplayAnsiColors` is enabled when the text changes.

### PasswordBox Control

The `PasswordBox` control in `Mtf.Controls` extends the standard `TextBox` to provide a secure way to handle password input. Unlike a regular `TextBox` with `PasswordChar`, the `PasswordBox` stores the password as a `SecureString` and handles input securely, preventing sensitive data from being stored in plain text.

#### Attributes
- `[ToolboxItem(true)]` – Ensures that the control is available in the Toolbox.
- `[ToolboxBitmap(typeof(PasswordBox), "Resources.PasswordBox.png")]` – Associates an icon for the control in the Toolbox.

#### Constructor

- **PasswordBox()**: Initializes a new `PasswordBox` with a default `PasswordChar` (`*`).

#### Properties

| Property              | Type           | Description                                      |
|-----------------------|----------------|--------------------------------------------------|
| `PasswordChar`        | `char`         | The character to display in place of the actual password characters. Default is `*`. |
| `UseSystemPasswordChar` | `bool`       | If `true`, the system-defined password character is used. Default is `false`. |

#### Methods

- **OnKeyPress(KeyPressEventArgs e)**: Handles key press events to update the `SecureString` (`password`) instead of storing characters in plain text. Prevents the actual character from being displayed.
- **OnTextChanged(EventArgs e)**: Clears the `SecureString` when the `Text` property is cleared.
- **OnKeyDown(KeyEventArgs e)**: Manages additional key events such as backspace or delete to ensure `password` remains consistent with displayed text.
- **Dispose()**: Overrides `Dispose()` to securely clear and release the `SecureString` when the control is disposed of.

#### SecureString Handling

The `PasswordBox` uses a `SecureString` to store the password securely. This ensures that sensitive data isn't held in memory in plain text, reducing the risk of exposure.

#### Example Usage

```csharp
using System;
using System.Security;
using System.Windows.Forms;
using Mtf.Controls;

public class LoginForm : Form
{
    private PasswordBox passwordBox;

    public LoginForm()
    {
        passwordBox = new PasswordBox
        {
            Location = new System.Drawing.Point(10, 10),
            Width = 200
        };
        Controls.Add(passwordBox);
    }

    public SecureString GetPassword()
    {
        return passwordBox.Password;  // Use this to retrieve the secure password input
    }
}
```

In this example, `LoginForm` creates a `PasswordBox` control to securely capture a password. The password can be retrieved as a `SecureString` by calling `GetPassword()`.

### ListView Control

# MtfListView Class Documentation

The `MtfListView` class is a custom `ListView` control that enhances the standard functionality with additional features such as alternating colors, compact view, and integrated thread safe behaviour. It is designed to improve the visual appearance and usability of list views in applications.

## Attributes

- **ToolboxItem**: Indicates that the control is a toolbox item.
- **ToolboxBitmap**: Provides a bitmap for the control in the toolbox.

## Constructor

### `MtfListView()`

Initializes a new instance of the `MtfListView` class, setting default values for its properties.

## Properties

| Property                     | Type        | Description                                                                                      |
|------------------------------|-------------|--------------------------------------------------------------------------------------------------|
| `ReadonlyCheckboxes`         | `bool`      | Indicates if the item checkboxes are readonly.                                                   |
| `EnsureLastItemIsVisible`    | `bool`      | Ensures that the last item is visible.                                                           |
| `AlternatingColorEven`       | `Color`     | Specifies color for even rows.                                                                   |
| `AlternatingColorOdd`        | `Color`     | Specifies color for odd rows.                                                                    |
| `AlternatingPairColorEven`   | `Color`     | Specifies color for paired even rows.                                                            |
| `AlternatingPairColorOdd`    | `Color`     | Specifies color for paired odd rows.                                                             |
| `SameItemsColorEven`         | `Color`     | Specifies color for same even rows.                                                              |
| `SameItemsColorOdd`          | `Color`     | Specifies color for same odd rows.                                                               |
| `CompactView`                | `bool`      | If `true`, identical items are displayed only once.                                              |
| `AlternatingColorsAreInUse`  | `bool`      | Enables/disables alternating colors.                                                             |
| `FirstItemIsGray`            | `bool`      | If `true`, the first item will be gray.                                                          |
| `AlwaysDifferentColumnIndexes`| `ReadOnlyCollection<int>` | Specifies columns to ignore for compact view creation, defaulting to an empty list.             |



## Example Usage

```csharp
[ToolboxItem(true)]
[ToolboxBitmap(typeof(MtfListView), "Resources.MtfListView.png")]
public class MtfListView : ListView
{
    private readonly List<int> alwaysDifferentColumnIndexes = new List<int>();

    public MtfListView()
    {
        EnsureLastItemIsVisible = false;
        AlternatingColorsAreInUse = true;
        FirstItemIsGray = false;
        OwnerDraw = AlternatingColorsAreInUse;
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.EnableNotifyMessage | ControlStyles.UserPaint, true);
        UpdateStyles();

        View = View.Details;
        FullRowSelect = true;
        AlternatingColorEven = Color.LightBlue;
        AlternatingColorOdd = BackColor;

        AlternatingPairColorEven = Color.LightSeaGreen;
        AlternatingPairColorOdd = Color.CadetBlue;
        SameItemsColorEven = Color.DarkOrange;
        SameItemsColorOdd = Color.LightSalmon;
        CompactView = false;
    }

    // Properties
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Description("Indicates that the item checkboxes are readonly or not.")]
    public bool ReadonlyCheckboxes { get; set; }

    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Description("Ensures that the last item is visible.")]
    public bool EnsureLastItemIsVisible { get; set; }

    // Additional properties...
}
```

### FileBrowserView class

#### Properties

| Property            | Type                          | Description                         |
|---------------------|-------------------------------|-------------------------------------|
| `WorkingDirectory`  | `string`                      | The current working directory.      |
| `SelectedElements`  | `IEnumerable<FileSystemInfo>` | Gets the seleted files and folders. |


### MtfTreeView Class

The `MtfTreeView` class extends TreeView with features like custom line styles, multiple selection support, custom checkbox appearance, and tick color.

#### Constants

| Constant          | Type      | Description                       |
|-------------------|-----------|-----------------------------------|
| `CheckboxSize`    | `short`   | Specifies the size of the checkbox. |
| `BigShift`        | `byte`    | Specifies the large shift value. |
| `SmallShift`      | `byte`    | Specifies the small shift value. |
| `MinShift`        | `byte`    | Specifies the minimum shift value.|

#### Properties

| Property                      | Type        | Description                                                                                      |
|-------------------------------|-------------|--------------------------------------------------------------------------------------------------|
| `StateImageOrCheckBoxOnLeft`  | `bool`      | If `true`, displays the state image on the left side.                                           |
| `LineStyle`                   | `DashStyle` | Sets the style of lines between nodes.                                                          |
| `ShowPlusMinusOnRootNodes`    | `bool`      | If `true`, displays a plus-minus icon on root nodes.                                            |
| `DrawDefaultImageToNodes`     | `bool`      | Uses `ImageIndex` of ListView to set node images.                                               |
| `TickColor`                   | `Color`     | Sets the color of checkbox ticks.                                                               |
| `CheckBoxBackground`          | `Color`     | Sets the background color for checkboxes.                                                       |
| `MultiSelect`                 | `bool`      | Enables/disables multiple node selection.                                                       |
| `SelectedNodes`               | `TreeNode[]`| Array of currently selected nodes.                                                              |

#### Usage Example

```csharp
var treeView = new MtfTreeView
{
    MultiSelect = true,
    TickColor = Color.Green,
    LineStyle = DashStyle.Dot
};
```

### SourceCodeViewerRichTextBox

`SourceCodeViewerRichTextBox` is a custom control derived from the `RichTextBox` class. It provides functionality for displaying source code with customizable syntax coloring and improved control over text rendering and updates. 

#### Features

- **Syntax Highlighting**: Supports multiple coloring methods, such as C++/CLI, C#, Java, Object Pascal, Visual Basic, and Visual C++.
- **Thread-Safe Text Manipulation**: Safe methods for appending and setting text in multithreaded applications.
- **Efficient Updates**: Supports batch updates without flickering, with options to begin and end updates manually.
- **Customizable Tab Size**: Dynamically calculates tab width based on font size.
- **Optional Auto-Scrolling**: Ensures the last line of text is visible on updates if configured.

#### Constructors

##### `SourceCodeViewerRichTextBox()`

Initializes the control, setting default options for:
- Disabling URL detection
- Accepting tabs
- No initial coloring

#### Properties

##### `ColoringMethod` (ColoringMethod)

Defines the syntax coloring mode.
- **Type**: `ColoringMethod`
- **Default**: `ColoringMethod.No_Coloring`
- **Usage**: Set to any of the supported programming languages to enable syntax highlighting for that language.

##### `ScroolToLastLine` (bool)

Determines whether the control automatically scrolls to the last line on each update.
- **Type**: `bool`
- **Default**: `false`
- **Description**: Set to `true` to enable auto-scrolling to the last line.

#### Methods

##### `GetTextThreadSafe()`
Returns the control’s text safely in a multithreaded environment.

##### `SetTextThreadSafe(string text)`
Sets the control’s text safely in a multithreaded environment.

##### `AppendTextThreadSafe(string text, Color? textColor = null)`
Appends text to the control safely in a multithreaded environment, with an optional text color.

##### `BeginUpdate()`
Disables control updates to prevent flickering during batch operations.

##### `EndUpdate()`
Re-enables control updates after a batch operation and redraws the control.

##### `StartUpdate(ref int scrollTo, ref int pos, ref int len)`
Starts a safe update process by caching the current scroll and cursor positions.

##### `StopUpdate(int scrollTo, int pos, int len)`
Ends the update process, restoring the control's scroll and cursor positions.

##### `ClearColoring()`
Resets all text colors to the default font color.

##### `ClearBackgroundColoring()`
Resets the background color of all text to the control’s background color.

##### `ApplyColoring()`
Applies syntax coloring based on the configured `ColoringMethod`.

#### Supported Coloring Methods

1. **No_Coloring** - Disables all syntax highlighting.
2. **CPP_CLI** - Syntax highlighting for C++/CLI.
3. **C_Sharp** - Syntax highlighting for C#.
4. **Java** - Syntax highlighting for Java.
5. **Object_Pascal** - Syntax highlighting for Object Pascal.
6. **Visual_Basic** - Syntax highlighting for Visual Basic.
7. **Visual_CPP** - Syntax highlighting for Visual C++.

#### Example Usage

```csharp
var codeViewer = new SourceCodeViewerRichTextBox
{
    ColoringMethod = ColoringMethod.C_Sharp,
    ScroolToLastLine = true
};
codeViewer.SetTextThreadSafe("public class HelloWorld { }");
```

### **MovablePanel**

`MovablePanel` is a transparent panel that can be moved by dragging it with the mouse. It is useful in scenarios where dynamic relocation of a window or panel is needed. The following attributes and events are available:

#### **Attributes**
- `[ToolboxItem(true)]` – Ensures the control is available in the Toolbox.
- `[ToolboxBitmap(typeof(MovablePanel), "Resources.MovablePanel.bmp")]` – Associates a custom icon for the panel in the Toolbox.

#### **Properties**
- `CanMove` (bool): Determines if the panel is movable. Default is `true`.

#### **Methods**
- `OnMouseDown(MouseEventArgs e)`: Initiates the panel's movement when the mouse button is pressed, if `CanMove` is set to `true`.
- `OnMouseUp(MouseEventArgs e)`: Stops moving the panel when the mouse button is released.
- `OnMouseMove(MouseEventArgs e)`: Updates the panel's position as the mouse is moved, as long as movement is allowed.

#### **Usage Example**
```csharp
var panel = new MovablePanel
{
    CanMove = true
};
```

### **MovableSizablePanel**

`MovableSizablePanel` extends `MovablePanel`, adding the capability to resize the panel in the East (right), South (bottom), and South-East (bottom-right) directions.

#### **Attributes**
- `[Browsable(true)]`, `[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]`, `[Description("Can change the size of the panel")]` – Allows the `CanSize` property to be visible and modifiable in the designer.

#### **Properties**
- `CanSize` (bool): Determines if the panel is resizable. Default is `true`.

#### **Methods**
- `InitializeResizeHandles()`: Creates resize handles on the panel's right, bottom, and bottom-right sides.
- `CheckSize()`: Ensures the panel does not shrink below a predefined minimum size (`Constants.MinSize`).
- `PbEast_MouseMove`, `PbSouth_MouseMove`, `PbSouthEast_MouseMove`: Logic for resizing in specific directions.

#### **Usage Example**
```csharp
var sizablePanel = new MovableSizablePanel
{
    CanMove = true,
    CanSize = true
};
```

### **MtfPictureBox**

`MtfPictureBox` is a custom PictureBox control that supports resizable and repositionable inner controls during resizing. It is particularly useful for displaying elements with relative positions that need to adapt dynamically to changes in size.

#### **Attributes**
- `[ToolboxItem(true)]` – Ensures the control is available in the Toolbox.
- `[ToolboxBitmap(typeof(MtfPictureBox), "Resources.MtfPictureBox.png")]` – Associates a custom icon for the PictureBox in the Toolbox.

#### **Properties**
- `RepositioningAndResizingControlsOnResize` (bool): Specifies whether controls added to the PictureBox should resize and reposition automatically.
- `OriginalSize` (Size): Stores the original size for scaling calculations.

#### **Methods**
- `OnControlAdded(ControlEventArgs e)`: Stores the position and size of a new control added to the PictureBox.
- `OnControlRemoved(ControlEventArgs e)`: Deletes position and size information of a control when it’s removed.
- `RefreshLocation(Control control)`: Updates the position of a given control.
- `RefreshSize(Control control)`: Updates the size of a given control.
- `RelocateControls()`: Relocates all controls based on the new scaling ratio.

#### **Usage Example**
```csharp
var pictureBox = new MtfPictureBox
{
    RepositioningAndResizingControlsOnResize = true,
    OriginalSize = new Size(800, 600)
};
```

### **Constants**

This project uses a `Constants` class to store shared values such as:
- `MinSize` (Size): Minimum size allowed for resizable panels, ensuring they do not shrink below this threshold.
- `Border` (int): Defines the size of the resize borders on the `MovableSizablePanel`.

Ensure the `Constants` class is defined appropriately for the panels to function as expected.

### **Notes**
- `MovablePanel` and `MovableSizablePanel` rely on the `Constants` class for settings like `MinSize` and `Border`.
- `MtfPictureBox` should be initialized with the `OriginalSize` property set to the initial dimensions, so it can calculate scaling accurately.
- The methods handling resizing (`PbEast_MouseMove`, `PbSouth_MouseMove`, and `PbSouthEast_MouseMove`) require careful handling of mouse events to avoid conflicts with other mouse-based controls on the form.


## Important Notes

- Ensure your project has .NET dependencies to support `Mtf.Controls`.
- For more details on using specific methods or properties, refer to the `Mtf.Controls` [GitHub Repository](https://github.com/Mortens4444/Mtf.Controls).
- If you have problems with the Visual Studio Toolbox, remove all files from C:\Users\morte\AppData\Local\Microsoft\VisualStudio\[vs_version_]\ComponentModelCache. After a rebuild, the toolbox should include these controls.

Feel free to reach out if further clarification is needed!