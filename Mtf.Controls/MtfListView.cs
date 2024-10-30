using Mtf.Controls.Enums;
using Mtf.Controls.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Mtf.Controls
{
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

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Indicates that the item checkboxes are readonly or not.")]
        public bool ReadonlyCheckboxes { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Ensures that the last item is visible.")]
        public bool EnsureLastItemIsVisible { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color for even rows.")]
        public Color AlternatingColorEven { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color for odd rows.")]
        public Color AlternatingColorOdd { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color for paired even rows.")]
        public Color AlternatingPairColorEven { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color for paired odd rows.")]
        public Color AlternatingPairColorOdd { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color for same even rows.")]
        public Color SameItemsColorEven { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Color for same odd rows.")]
        public Color SameItemsColorOdd { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Compact view - identical items will only be displayed once.")]
        public bool CompactView { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Indicates whether alternating colors are used.")]
        public bool AlternatingColorsAreInUse { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("If set to true, the first item will be gray.")]
        public bool FirstItemIsGray { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Columns that will not be evaluated when creating the compact view. Default is an empty list.")]
        public ReadOnlyCollection<int> AlwaysDifferentColumnIndexes => alwaysDifferentColumnIndexes.AsReadOnly();

        private static readonly int NmHdrOffset = IntPtr.Size * 2;
        private const uint LVN_FIRST = unchecked(0U - 100U);
        private const uint LVN_ITEMCHANGING = unchecked(LVN_FIRST - 0);
        //private const uint LVN_ITEMCHANGED = unchecked(LVN_FIRST - 1);

        public void AddColumnIndex(int index)
        {
            alwaysDifferentColumnIndexes.Add(index);
        }

        public bool RemoveColumnIndex(int index)
        {
            return alwaysDifferentColumnIndexes.Remove(index);
        }

        public bool HasCheckedItem()
        {
            foreach (ListViewItem item in Items)
            {
                if (item.Checked)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasNotCheckedItem()
        {
            foreach (ListViewItem item in Items)
            {
                if (!item.Checked)
                {
                    return true;
                }
            }
            return false;
        }

        public ListViewGroup AddListViewGroup(string groupHeader)
        {
            var group = new ListViewGroup(groupHeader);
            AddListViewGroup(group);
            return group;
        }

        public void AddListViewGroup(ListViewGroup group)
        {
            this.ExecuteThreadSafely(() =>
            {
                if (!Groups.Contains(group))
                {
                    _ = Groups.Add(group);
                }
            });
        }

        public void ImportContent(string filePath)
        {
            BeginUpdateThreadSafe();
            ClearItems();

            var xmlDocument = XDocument.Load(filePath);
            var rootElement = xmlDocument.Root;
            if (rootElement == null || rootElement.Name.LocalName != $"{nameof(MtfListView)}_Content")
            {
                throw new InvalidOperationException($"Invalid XML structure in file: {filePath}");
            }

            ListViewItem item = null;

            foreach (var itemElement in rootElement.Elements("Item"))
            {
                item = new ListViewItem();

                var firstSubItem = itemElement.Element("SubItem0");
                if (firstSubItem != null)
                {
                    item.Text = firstSubItem.Value;
                }

                foreach (var subItemElement in itemElement.Elements())
                {
                    if (subItemElement.Name.LocalName.StartsWith("SubItem", StringComparison.Ordinal))
                    {
                        _ = item.SubItems.Add(subItemElement.Value);
                    }
                }

                AddItem(item);
            }

            EndUpdateThreadSafe();
        }

        public void BeginUpdateThreadSafe()
        {
            this.ExecuteThreadSafely(BeginUpdate);
        }

        public void EndUpdateThreadSafe()
        {
            this.ExecuteThreadSafely(EndUpdate);
        }

        public Color GetListViewItemBackColor(int itemIndex)
        {
            return this.ExecuteThreadSafely(() => Items[itemIndex].BackColor, Color.Empty);
        }

        public void AddListViewItem(string itemText)
        {
            AddListViewItem(new ListViewItem(itemText));
        }

        public void AddListViewItem(ListViewItem item)
        {
            this.ExecuteThreadSafely(() => AddItem(item));
        }

        public void AddSubItemToListViewItem(int itemIndex, string subItem)
        {
            _ = this.ExecuteThreadSafely(() => Items[itemIndex].SubItems.Add(subItem));
        }

        public int Compare(ListViewItem x, ListViewItem y)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            if (y == null)
            {
                throw new ArgumentNullException(nameof(y));
            }

            if (x.SubItems.Count != y.SubItems.Count)
            {
                return x.SubItems.Count - y.SubItems.Count;
            }

            for (var i = 0; i < x.SubItems.Count; i++)
            {
                if ((AlwaysDifferentColumnIndexes != null) && AlwaysDifferentColumnIndexes.Contains(i))
                {
                    continue;
                }

                if (x.SubItems[i].Text != y.SubItems[i].Text)
                {
                    return String.CompareOrdinal(x.SubItems[i].Text, y.SubItems[i].Text);
                }
            }

            return 0;
        }

        public void SetVirtualListSize(int size)
        {
            _ = this.ExecuteThreadSafely(() => VirtualListSize = size);
        }

        public void AddListViewItemIfNotAddedSameYet(ListViewItem item)
        {
            this.ExecuteThreadSafely(() =>
            {
                var add = true;
                for (var i = 0; i < Items.Count; i++)
                {
                    if ((Items[i].Text != item.Text) || (Items[i].SubItems.Count != item.SubItems.Count))
                    {
                        continue;
                    }

                    var same = true;
                    for (var j = 0; j < Items[i].SubItems.Count; j++)
                    {
                        if (Items[i].SubItems[j].Text == item.SubItems[j].Text)
                        {
                            continue;
                        }

                        same = false;
                        break;
                    }
                    if (!same)
                    {
                        continue;
                    }

                    add = false;
                    break;
                }
                if (add)
                {
                    AddItem(item);
                }
            });
        }

        public void SelectItemsInListViewGroup(params int[] groupIndexes)
        {
            this.ExecuteThreadSafely(() =>
            {
                foreach (var groupIndex in groupIndexes)
                {
                    for (var i = 0; i < Groups[groupIndex].Items.Count; i++)
                    {
                        Groups[groupIndex].Items[i].Selected = true;
                    }
                }
            });
        }

        public void AddListViewItemToListViewGroup(ListViewItem item, ListViewGroup group)
        {
            this.ExecuteThreadSafely(() =>
            {
                item.Group = group;
                AddItem(item);
            });
        }

        public int GetListViewItemIndex(ListViewItem item)
        {
            return this.ExecuteThreadSafely(() => item != null ? Items.IndexOf(item) : Constants.NotFound);
        }

        public object GetListViewItemTag(int itemIndex)
        {
            return this.ExecuteThreadSafely(() => Items[itemIndex].Tag);
        }

        public ListViewItem GetListViewItem(int index)
        {
            return this.ExecuteThreadSafely(() =>
                (index >= 0 && index < SelectedItems.Count) ? Items[index] : null
            );
        }

        public ListViewItem GetSelectedListViewItem(int index)
        {
            return this.ExecuteThreadSafely(() =>
                (index >= 0 && index < SelectedItems.Count) ? SelectedItems[index] : null
            );
        }

        public string GetListViewItemSubitem(int itemIndex, int subitemIndex)
        {
            return this.ExecuteThreadSafely(() => Items[itemIndex].SubItems[subitemIndex].Text);
        }

        public void SetListViewItemSubitem(int itemIndex, int subitemIndex, string value)
        {
            this.ExecuteThreadSafely(() =>
            {
                Items[itemIndex].SubItems[subitemIndex].Text = value;
            });
        }

        public void SelectFirstIfExists()
        {
            this.ExecuteThreadSafely(() =>
            {
                if (Items.Count > 0)
                {
                    SelectItems(0);
                }
            });
        }

        /// <summary>
        /// Select the items with indexes. DO NOT USE IN CONSTRUCTOR (Executes two times)!
        /// </summary>
        /// <param name="indexes">ListViewItem indexes</param>
        public void SelectItems(params int[] indexes)
        {
            this.ExecuteThreadSafely(() =>
            {
                if ((indexes != null) && (indexes.Length > 0))
                {
                    if ((!MultiSelect) && (indexes.Length > 1))
                    {
                        throw new NotSupportedException();
                    }

                    foreach (var index in indexes)
                    {
                        Items[index].Selected = true;
                    }
                }
            });
        }

        public void ListViewUpdate(bool updateBegin)
        {
            this.ExecuteThreadSafely(() =>
            {
                if (updateBegin)
                {
                    BeginUpdate();
                }
                else
                {
                    EndUpdate();
                }
            });
        }

        public void AddListViewItemAtBegining(ListViewItem item)
        {
            _ = this.ExecuteThreadSafely(() => Items.Insert(0, item));
        }

        public void AddListViewItemAtBeginingWithMaximum(ListViewItem item, int maximum)
        {
            this.ExecuteThreadSafely(() =>
            {
                if (Items.Count < maximum)
                {
                    _ = Items.Insert(0, item);
                    while (Items.Count > maximum)
                    {
                        Items.RemoveAt(maximum);
                    }
                }
            });
        }

        public void AddListViewItemWithMaximum(ListViewItem item, int maximum)
        {
            this.ExecuteThreadSafely(() =>
            {
                if (Items.Count < maximum)
                {
                    AddItem(item);
                }
            });
        }

        public void ClearItems()
        {
            this.ExecuteThreadSafely(Items.Clear);
        }

        public void ClearGroups()
        {
            this.ExecuteThreadSafely(Groups.Clear);
        }

        public void ClearItemsAndGroups()
        {
            this.ExecuteThreadSafely(() =>
            {
                Groups.Clear();
                Items.Clear();
            });
        }

        public void ClearSelectedItems()
        {
            this.ExecuteThreadSafely(SelectedItems.Clear);
        }

        public void RemoveSelectedListviewItems()
        {
            this.ExecuteThreadSafely(() =>
            {
                while (SelectedItems.Count > 0)
                {
                    Items.Remove(SelectedItems[0]);
                }
            });
        }

        public void RemoveListViewItemAt(int index)
        {
            this.ExecuteThreadSafely(() => Items.RemoveAt(index));
        }

        public void RemoveListViewItem(ListViewItem item)
        {
            if (item == null)
            {
                return;
            }
            this.ExecuteThreadSafely(() => Items.Remove(item));
        }

        public int GetItemsCount()
        {
            return this.ExecuteThreadSafely(() => Items.Count);
        }

        public int GetSelectedItemsCount()
        {
            return this.ExecuteThreadSafely(() => SelectedItems.Count, -1);
        }

        public bool IsListViewItemTagsContainsObject(object tagObject)
        {
            return this.ExecuteThreadSafely(() =>
            {
                var items = new ListViewItem[Items.Count];
                Items.CopyTo(items, 0);
                foreach (var item in items)
                {
                    if (tagObject.Equals(item.Tag))
                    {
                        return true;
                    }
                }
                return false;
            }, false);
        }

        public void GetContent(string filename, string columnSeparator)
        {
            GetContent(filename, columnSeparator, false);
        }

        public void GetContent(string filename, string columnSeparator, bool firstRowToColumnNames)
        {
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var sr = new StreamReader(fs, Encoding.Default))
                {
                    string line;
                    if (firstRowToColumnNames && (line = sr.ReadLine()) != null)
                    {
                        var columns = line.Split(new[] { columnSeparator }, StringSplitOptions.None);
                        if (columns.Length != Columns.Count)
                        {
                            throw new ArgumentException($"Arrays size must be the same {columns.Length} != {Columns.Count} in file {filename}");
                        }

                        for (var i = 0; i < columns.Length; i++)
                        {
                            Columns[i].Text = columns[i];
                        }
                    }

                    while ((line = sr.ReadLine()) != null)
                    {
                        var columns = line.Split(new[] { columnSeparator }, StringSplitOptions.None);
                        var item = new ListViewItem(columns[0]);
                        for (var i = 1; i < columns.Length; i++)
                        {
                            _ = item.SubItems.Add(columns[i]);
                        }

                        AddListViewItem(item);
                    }
                }
            }
        }

        public void GetContent(IEnumerable<object> objs)
        {
            if (objs == null)
            {
                return;
            }

            foreach (var obj in objs)
            {
                var item = obj is ArrayList arrayList ? CreateListViewItem(arrayList) :
                    obj is Array array ? CreateListViewItem(array) :
                    new ListViewItem(obj.ToString());

                AddListViewItem(item);
            }
        }

        protected void AddItem(ListViewItem item)
        {
            if (item == null)
            {
                return;
            }

            this.ExecuteThreadSafely(() =>
            {
                var addedItem = Items.Add(item);
                if (EnsureLastItemIsVisible)
                {
                    EnsureVisible(addedItem.Index);
                }
            });
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)WindowMessage.WM_NOTIFY)
            {
                var nmhdrCode = (uint)Marshal.ReadInt32(m.LParam, NmHdrOffset);
                if (nmhdrCode == LVN_ITEMCHANGING)
                {
                    return;
                }
            }
            base.WndProc(ref m);
        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            base.OnDrawColumnHeader(e);
            e.DrawDefault = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            if (GetStyle(ControlStyles.UserPaint))
            {
                var message = new Message
                {
                    HWnd = Handle,
                    Msg = (int)WindowMessage.WM_PRINTCLIENT,
                    WParam = e.Graphics.GetHdc(),
                    LParam = (IntPtr)WindowMessagesParameter.PrfCclient
                };
                DefWndProc(ref message);
                e.Graphics.ReleaseHdc(message.WParam);
            }
            base.OnPaint(e);
        }

        public virtual Color GetBackColorOfItem(int index)
        {
            return (index % 2) == 0 ? AlternatingColorEven : AlternatingColorOdd;
        }

        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            var index = Constants.NotFound;

            foreach (ListViewGroup group in Groups)
            {
                if ((index = group.Items.IndexOf(e.Item)) != Constants.NotFound)
                {
                    break;
                }
            }

            if (index == Constants.NotFound)
            {
                index = e.ItemIndex;
            }

            if (AlternatingColorsAreInUse)
            {
                if ((index == 0) && FirstItemIsGray)
                {
                    e.Item.BackColor = Color.LightGray;
                    e.Item.ForeColor = Color.Gray;
                }
                else
                {
                    e.Item.BackColor = GetBackColorOfItem(index);
                }
            }
            else
            {
                base.OnDrawItem(e);
            }

            e.DrawDefault = true;
        }

        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != (int)WindowMessage.WM_ERASEBKGND)
            {
                base.OnNotifyMessage(m);
            }
        }

        protected override void OnItemCheck(ItemCheckEventArgs ice)
        {
            if (ice == null)
            {
                return;
            }

            if (!ReadonlyCheckboxes)
            {
                base.OnItemCheck(ice);
            }
            else
            {
                ice.NewValue = ice.CurrentValue;
            }
        }

        protected override void OnItemChecked(ItemCheckedEventArgs e)
        {
            if (!ReadonlyCheckboxes)
            {
                base.OnItemChecked(e);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!ReadonlyCheckboxes)
            {
                base.OnMouseDown(e);
            }
        }

        private static ListViewItem CreateListViewItem(IList items)
        {
            var item = new ListViewItem(items[0]?.ToString());
            for (var i = 1; i < items.Count; i++)
            {
                _ = item.SubItems.Add(items[i]?.ToString());
            }

            return item;
        }
    }
}
