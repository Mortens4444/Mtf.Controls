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

## Using Custom Controls

### ListView Control

The `ListView` control enables efficient display and management of lists in your project.

```csharp
var listView = new ListView();
listView.Add("Item 1");
listView.Add("Item 2");
```

- **Properties**:
  - `Items`: Collection of items within the list view.
  - `SelectedIndex`: The index of the currently selected item.
- **Methods**:
  - `Add(string item)`: Adds a new item to the list.
  - `Remove(string item)`: Removes the specified item from the list.

### TreeView Control

The `TreeView` control allows hierarchical display of items, ideal for representing tree structures such as file directories.

```csharp
var treeView = new TreeView();
var root = treeView.AddRoot("Root Node");
root.AddChild("Child Node");
```

- **Properties**:
  - `Root`: The root node of the tree.
  - `Nodes`: Collection of nodes within the tree view.
- **Methods**:
  - `AddRoot(string text)`: Adds a root node.
  - `AddChild(string text)`: Adds a child node to the selected node.

### Panel Control

The `Panel` control provides a container for other controls, enabling structured layout and organization.

```csharp
var panel = new Panel();
panel.AddControl(new ListView());
panel.AddControl(new TreeView());
```

- **Properties**:
  - `Controls`: Collection of child controls within the panel.
- **Methods**:
  - `AddControl(Control control)`: Adds a new control to the panel.

## Important Notes

- Ensure your project has .NET dependencies to support `Mtf.Controls`.
- For more details on using specific methods or properties, refer to the `Mtf.Controls` [GitHub Repository](https://github.com/Mortens4444/Mtf.Controls).

Feel free to reach out if further clarification is needed!