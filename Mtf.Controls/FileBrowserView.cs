using Enums;
using MessageBoxes;
using Mtf.Controls.Enums;
using Mtf.Controls.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mtf.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(FileBrowserView), "Resources.FileBrowserView.png")]
    public class FileBrowserView : ListView
    {
        private OrderStrategy currentOrderStrategy = OrderStrategy.Name;
        private bool ascendingOrder = true;

        private string workingDirectory;
        private readonly Dictionary<string, Icon> extensionIcons = new Dictionary<string, Icon>();
        private readonly ContextMenuStrip contextMenu;
        private readonly List<FileSystemInfo> cutItems = new List<FileSystemInfo>();
        private readonly List<FileSystemInfo> copiedItems = new List<FileSystemInfo>();

        public FileBrowserView()
        {
            _ = Columns.Add("Name", 200);
            _ = Columns.Add("Type", 100);
            _ = Columns.Add("Size", 80, HorizontalAlignment.Right);
            ColumnClick += FileBrowserView_ColumnClick;

            var folderImage = ResourceHelper.GetEmbeddedResourceByName(GetType().Assembly, "Mtf.Controls.Resources.Folder.png");
            SmallImageList = new ImageList();
            SmallImageList.Images.Add("folder", folderImage);
            SmallImageList.Images.Add("file", SystemIcons.Application);
            SmallImageList.Images.Add("up", folderImage);

            WorkingDirectory = @"C:\";
            RefreshItems();

            contextMenu = new ContextMenuStrip();
            _ = contextMenu.Items.Add(new ToolStripMenuItem("New folder", null, NewFolderItem_Click, "New folder"));
            _ = contextMenu.Items.Add(new ToolStripMenuItem("Cut", null, CutItem_Click, "Cut"));
            _ = contextMenu.Items.Add(new ToolStripMenuItem("Copy", null, CopyItem_Click, "Copy"));
            _ = contextMenu.Items.Add(new ToolStripMenuItem("Paste", null, PasteItem_Click, "Paste"));
            _ = contextMenu.Items.Add(new ToolStripMenuItem("Rename", null, RenameItem_Click, "Rename"));
            _ = contextMenu.Items.Add(new ToolStripMenuItem("Delete", null, DeleteItem_Click, "Delete"));
            contextMenu.Opening += ContextMenu_Opening;

            MouseDoubleClick += FileBrowserView_MouseDoubleClick;
            KeyDown += FileBrowserView_KeyDown;
            MouseUp += FileBrowserView_MouseUp;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("A directory to display in the FileBrowserView.")]
        public string WorkingDirectory
        {
            get => workingDirectory;
            set
            {
                if (Directory.Exists(value))
                {
                    workingDirectory = value;
                    RefreshItems();
                }
                else
                {
                    throw new DirectoryNotFoundException($"The directory '{value}' does not exist.");
                }
            }
        }

        public IEnumerable<FileSystemInfo> SelectedElements
        {
            get
            {
                foreach (ListViewItem selectedItem in SelectedItems)
                {
                    if (selectedItem.Tag is FileSystemInfo item)
                    {
                        yield return item;
                    }
                }
            }
        }

        private void FileBrowserView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            switch (e.Column)
            {
                case 0:
                    currentOrderStrategy = OrderStrategy.Name;
                    break;
                case 1:
                    currentOrderStrategy = OrderStrategy.Type;
                    break;
                case 2:
                    currentOrderStrategy = OrderStrategy.Size;
                    break;
                default:
                    break;
            };

            ascendingOrder = !ascendingOrder;
            ListViewItemSorter = new FileBrowserViewComparer(currentOrderStrategy, ascendingOrder);
            Sort();
        }

        private void ContextMenu_Opening(object sender, CancelEventArgs e)
        {
            var hasSelection = SelectedItems.Count > 0;
            contextMenu.Items["New folder"].Enabled = true;
            contextMenu.Items["Cut"].Enabled = hasSelection;
            contextMenu.Items["Copy"].Enabled = hasSelection;
            contextMenu.Items["Paste"].Enabled = cutItems.Count > 0 || copiedItems.Count > 0;
            contextMenu.Items["Rename"].Enabled = hasSelection;
            contextMenu.Items["Delete"].Enabled = hasSelection;
        }

        private void RefreshItems()
        {
            Items.Clear();

            if (Directory.GetParent(workingDirectory) != null)
            {
                var upItem = new ListViewItem("..")
                {
                    Tag = "up",
                    ImageKey = "up"
                };
                _ = upItem.SubItems.Add("Parent Directory");
                _ = Items.Add(upItem);
            }

            foreach (var directory in Directory.GetDirectories(workingDirectory))
            {
                var dirInfo = new DirectoryInfo(directory);
                var item = new ListViewItem(dirInfo.Name)
                {
                    Tag = dirInfo,
                    ImageKey = "folder"
                };
                _ = item.SubItems.Add("Folder");
                _ = item.SubItems.Add(String.Empty);
                _ = Items.Add(item);
            }

            foreach (var file in Directory.GetFiles(workingDirectory))
            {
                var fileInfo = new FileInfo(file);
                var fileExtension = fileInfo.Extension.ToLower();

                if (!extensionIcons.ContainsKey(fileExtension))
                {
                    var icon = Icon.ExtractAssociatedIcon(fileInfo.FullName);
                    if (icon != null)
                    {
                        SmallImageList.Images.Add(fileExtension, icon);
                        extensionIcons[fileExtension] = icon;
                    }
                    else
                    {
                        extensionIcons[fileExtension] = SystemIcons.Application;
                    }
                }

                var item = new ListViewItem(fileInfo.Name)
                {
                    Tag = fileInfo,
                    ImageKey = fileExtension
                };
                _ = item.SubItems.Add(fileInfo.Extension.ToUpper() + " File");
                _ = item.SubItems.Add(FileSizeConverter.ToReadableForm(fileInfo.Length));
                _ = Items.Add(item);
            }
        }

        private void FileBrowserView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItems.Count == 0)
            {
                return;
            }

            var selectedItem = SelectedItems[0];
            if (selectedItem.Tag is DirectoryInfo directory)
            {
                WorkingDirectory = directory.FullName;
            }
            else if (selectedItem.Tag is FileInfo file)
            {
                try
                {
                    _ = Process.Start(new ProcessStartInfo
                    {
                        FileName = file.FullName,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    _ = ErrorBox.Show("File open error", $"Failed to open file: {ex.Message}");
                }
            }
            else if (selectedItem.Tag is string tag && tag == "up")
            {
                var parentDirectory = Directory.GetParent(workingDirectory);
                if (parentDirectory != null)
                {
                    WorkingDirectory = parentDirectory.FullName;
                }
            }
        }

        private void FileBrowserView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in SelectedItems)
                {
                    if (selectedItem.Tag is DirectoryInfo directory)
                    {
                        _ = Task.Run(() =>
                        {
                            var folderSize = DirectoryUtils.CalculateDirectorySize(directory.FullName);
                            Invoke((Action)(() => { selectedItem.SubItems[2].Text = FileSizeConverter.ToReadableForm(folderSize); }));
                        });
                    }
                }
            }
        }

        private void NewFolderItem_Click(object sender, EventArgs e)
        {
            var newFolderName = InputBox.Show("New folder", $"Enter the name for the new folder:", String.Empty);
            if (!String.IsNullOrWhiteSpace(newFolderName))
            {
                try
                {
                    _ = Directory.CreateDirectory(Path.Combine(workingDirectory, newFolderName));
                    RefreshItems();
                }
                catch (Exception ex)
                {
                    _ = ErrorBox.Show("Create folder error", $"Failed to create new folder: {ex.Message}");
                }
            }
        }

        private void CutItem_Click(object sender, EventArgs e)
        {
            cutItems.Clear();
            foreach (ListViewItem selectedItem in SelectedItems)
            {
                if (selectedItem.Tag is FileSystemInfo file)
                {
                    cutItems.Add(file);
                }
            }
        }

        private void CopyItem_Click(object sender, EventArgs e)
        {
            copiedItems.Clear();
            foreach (ListViewItem selectedItem in SelectedItems)
            {
                if (selectedItem.Tag is FileSystemInfo item)
                {
                    copiedItems.Add(item);
                }
            }
        }

        private void PasteItem_Click(object sender, EventArgs e)
        {
            if (copiedItems.Count > 0 || cutItems.Count > 0)
            {
                var isCutOperation = cutItems.Count > 0;
                var itemsToPaste = isCutOperation ? cutItems : copiedItems;

                try
                {
                    foreach (var item in itemsToPaste)
                    {
                        var destinationPath = Path.Combine(workingDirectory, item.Name);

                        // Check for recursive copy/move
                        if (IsRecursivePath(item, destinationPath))
                        {
                            ErrorBox.Show("Paste error", "Cannot paste an item into itself or a subdirectory.");
                            return;
                        }

                        if (item is DirectoryInfo dirInfo)
                        {
                            if (isCutOperation)
                            {
                                Directory.Move(dirInfo.FullName, destinationPath);
                            }
                            else
                            {
                                DirectoryUtils.CopyDirectory(dirInfo.FullName, destinationPath);
                            }
                        }
                        else if (item is FileInfo fileInfo)
                        {
                            if (isCutOperation)
                            {
                                File.Move(fileInfo.FullName, destinationPath);
                            }
                            else
                            {
                                File.Copy(fileInfo.FullName, destinationPath);
                            }
                        }
                    }

                    if (isCutOperation)
                    {
                        cutItems.Clear();
                    }

                    RefreshItems();
                }
                catch (Exception ex)
                {
                    _ = ErrorBox.Show("Paste error", $"Failed to paste the items: {ex.Message}");
                }
            }
        }

        private bool IsRecursivePath(FileSystemInfo item, string destinationPath)
        {
            if (item is DirectoryInfo dirInfo)
            {
                var fullPath = Path.GetFullPath(destinationPath).TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
                return fullPath.StartsWith(dirInfo.FullName, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (ConfirmBox.Show("Delete confirmation", "Are you sure, you want to delete selected item(s)?", Decide.No) == DialogResult.Yes)
            {
                cutItems.Clear();
                copiedItems.Clear();
                try
                {
                    foreach (ListViewItem selectedItem in SelectedItems)
                    {
                        if (selectedItem.Tag is FileInfo file)
                        {
                            File.Delete(file.FullName);
                        }
                        else if (selectedItem.Tag is DirectoryInfo directory)
                        {
                            Directory.Delete(directory.FullName, true);
                        }
                    }
                    RefreshItems();
                }
                catch (Exception ex)
                {
                    _ = ErrorBox.Show("Delete error", $"Failed to delete an item: {ex.Message}");
                }
            }
        }

        private void RenameItem_Click(object sender, EventArgs e)
        {
            if (SelectedItems.Count == 1 && SelectedItems[0].Tag is FileSystemInfo item)
            {
                var newName = InputBox.Show("Rename", $"Enter new name for '{item.Name}':", item.Name);
                if (!String.IsNullOrWhiteSpace(newName))
                {
                    var newPath = Path.Combine(workingDirectory, newName);
                    try
                    {
                        if (item is DirectoryInfo dirInfo)
                        {
                            Directory.Move(dirInfo.FullName, newPath);
                        }
                        else if (item is FileInfo fileInfo)
                        {
                            File.Move(fileInfo.FullName, newPath);
                        }
                        RefreshItems();
                    }
                    catch (Exception ex)
                    {
                        _ = ErrorBox.Show("Rename error", $"Failed to rename the item: {ex.Message}");
                    }
                }
            }
        }

        private void FileBrowserView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenu.Show(this, e.Location);
            }
        }
    }
}
