using Mtf.Controls.Enums;
using Mtf.Windows.Forms.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Mtf.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MtfTreeView), "Resources.MtfTreeView.png")]
    public class MtfTreeView : TreeView
    {
        public const short CheckboxSize = 10;
        public const byte BigShift = 3;
        public const byte SmallShift = 2;
        public const byte MinShift = 1;
        private static readonly Pen GrayPen = new Pen(Color.Gray);
        private static readonly Pen BlackPen = new Pen(Color.Black, 2);

        private static readonly StringFormat NoWrapStringFormat_Center = new StringFormat(StringFormatFlags.NoWrap);
        private static readonly StringFormat NoWrapStringFormat_Near = new StringFormat(StringFormatFlags.NoWrap);

        private static SolidBrush BackColorBrush, ForeColorBrush, HighlightBrush, HighlightText;

        private RectangleF selectionRectangle;
        private Point? mouseSelectStart, mouseSelectEnd;
        private bool cancelExpandOrCollapse;

        private bool multiSelect;
        private readonly List<TreeNode> selectedNodes;
        private TreeNode ShiftStartTreeNode;

        public MtfTreeView()
        {
            ForeColorBrush = new SolidBrush(ForeColor);
            HighlightBrush = new SolidBrush(SystemColors.Highlight);
            HighlightText = new SolidBrush(SystemColors.HighlightText);
            BackColorBrush = new SolidBrush(BackColor);

            NoWrapStringFormat_Center.Alignment = StringAlignment.Center;
            NoWrapStringFormat_Center.LineAlignment = StringAlignment.Center;
            NoWrapStringFormat_Near.Alignment = StringAlignment.Near;
            NoWrapStringFormat_Near.LineAlignment = StringAlignment.Center;

            selectedNodes = new List<TreeNode>();
            MultiSelect = false;
            TickColor = Color.Green;
            CheckBoxBackground = SystemColors.Window;
            LineStyle = DashStyle.Dot;
            StateImageOrCheckBoxOnLeft = false;
            ShowPlusMinusOnRootNodes = true;
            HideSelection = false;
            DrawDefaultImageToNodes = true;
            SetStyle(ControlStyles.UserPaint | ControlStyles.EnableNotifyMessage | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            DoubleBuffered = true;
            UpdateStyles();
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Displays the state image or checkbox on the left side when set to true.")]
        public bool StateImageOrCheckBoxOnLeft { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Specifies the line style for tree node connections.")]
        public DashStyle LineStyle { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Indicates whether root nodes should display a plus-minus sign for expansion.")]
        public bool ShowPlusMinusOnRootNodes { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Uses the ListView ImageIndex to define the default image for each node.")]
        public bool DrawDefaultImageToNodes { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Sets the color of the checkmark inside checkboxes.")]
        public Color TickColor { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Sets the background color of checkboxes.")]
        public Color CheckBoxBackground { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Enables multiple node selection within the TreeView.")]
        public bool MultiSelect
        {
            get => multiSelect;
            set
            {
                if (!value)
                {
                    selectedNodes.Clear();
                }

                multiSelect = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Array of nodes currently selected in the TreeView.")]
        public TreeNode[] SelectedNodes
        {
            get
            {
                if (!MultiSelect)
                {
#if NET462_OR_GREATER
                    return SelectedNode == null ? Array.Empty<TreeNode>() : (new TreeNode[] { SelectedNode });
#else
                    return SelectedNode == null ? new TreeNode[] { } : (new TreeNode[] { SelectedNode });
#endif
                }

                _ = selectedNodes.RemoveAll(OrphanNode);
                return selectedNodes.ToArray();
            }
            set
            {
                selectedNodes.Clear();
                SelectedNode = null;

                for (var i = 0; i < value.Length; i++)
                {
                    if (i == 0)
                    {
                        SelectedNode = value[i];
                        ShiftStartTreeNode = value[i];
                    }
                    else
                    {
                        AddToSelectedNodes(value[i]);
                    }
                }
                base.OnAfterSelect(new TreeViewEventArgs(SelectedNode));
            }
        }

        private static bool OrphanNode(TreeNode node)
        {
            return node.TreeView == null;
        }

        private void AddToSelectedNodes(TreeNode node)
        {
            if ((node != null) && (!selectedNodes.Contains(node)))
            {
                selectedNodes.Add(node);
            }
        }

        private void RemoveFromSelectedNodes(TreeNode node)
        {
            if ((node != null) && selectedNodes.Contains(node))
            {
                _ = selectedNodes.Remove(node);
            }
        }

        private void AddFromShiftStartToPreviousSelection(TreeNode node)
        {
            if (ShiftStartTreeNode == null)
            {
                AddToSelectedNodes(node);
            }
            else
            {
                var direction = MtfTreeView.ComparePosition(ShiftStartTreeNode, node);
                var temp_node = ShiftStartTreeNode;
                while (temp_node != node)
                {
                    AddToSelectedNodes(temp_node);
                    temp_node = direction > 0 ? temp_node.NextVisibleNode : temp_node.PrevVisibleNode;
                }
                AddToSelectedNodes(temp_node);
            }
        }

        /// <summary>
        /// Compares the viewposition of nodes
        /// -1 y is before x
        ///  0 y is x
        /// +1 x is after y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static int ComparePosition(TreeNode x, TreeNode y)
        {
            if (x == y)
            {
                return 0;
            }

            int result;
            if (y.Level > x.Level)
            {
                result = ComparePosition(x, y.Parent);
                return result == 0 ? 1 : result;
            }
            if (x.Level > y.Level)
            {
                result = ComparePosition(x.Parent, y);
                return result == 0 ? -1 : result;
            }

            if (x.Parent != y.Parent)
            {
                return ComparePosition(x.Parent, y.Parent);
            }

            return x.Index < y.Index ? 1 : -1;
        }

        private void SelectionWithoutStrgAndShift()
        {
            SuspendLayout();
            selectedNodes.Clear();
            AddToSelectedNodes(SelectedNode);
            ShiftStartTreeNode = SelectedNode;
            ResumeLayout();
        }

        private void SelectionWithShiftWithoutStrg()
        {
            SuspendLayout();
            selectedNodes.Clear();
            AddFromShiftStartToPreviousSelection(SelectedNode);
            ResumeLayout();
        }

        private void SelectionWithStrgToUnselected()
        {
            SuspendLayout();
            AddToSelectedNodes(SelectedNode);
            ShiftStartTreeNode = SelectedNode;
            ResumeLayout();
        }

        private void SelectionWithStrgToSelected()
        {
            SuspendLayout();
            RemoveFromSelectedNodes(SelectedNode);
            ShiftStartTreeNode = SelectedNode;
            SelectedNode = null;
            ResumeLayout();
        }

        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            if (MultiSelect)
            {
                if (Control.ModifierKeys == Keys.Control)
                {
                    if (selectedNodes.Contains(SelectedNode))
                    {
                        SelectionWithStrgToSelected();
                    }
                    else
                    {
                        SelectionWithStrgToUnselected();
                    }
                }
                else if (Control.ModifierKeys == Keys.Shift)
                {
                    SelectionWithShiftWithoutStrg();
                }
                else
                {
                    SelectionWithoutStrgAndShift();
                }
            }

            base.OnAfterSelect(e);
            Invalidate();
        }

        protected override void OnBeforeCollapse(TreeViewCancelEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            e.Cancel = cancelExpandOrCollapse;
            if (e.Node == Nodes[0])
            {
                e.Cancel = true;
            }
            else
            {
                cancelExpandOrCollapse = false;
            }
        }

        protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            e.Cancel = cancelExpandOrCollapse;
            cancelExpandOrCollapse = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                mouseSelectEnd = new Point(e.X, e.Y);

                if (!selectionRectangle.Contains(mouseSelectEnd.Value))
                {
                    AddToSelectedNodes(GetNodeAt(mouseSelectEnd.Value));
                }
                else
                {
                    if ((selectionRectangle.X != 0) && (selectionRectangle.Y != 0) && (selectionRectangle.Width != 0) && (selectionRectangle.Height != 0))
                    {
                        for (var i = 0; i < selectedNodes.Count; i++)
                        {
                            var bounds = new RectangleF(0, selectedNodes[i].Bounds.Y, Width, Height);
                            if (!selectionRectangle.IntersectsWith(bounds))
                            {
                                RemoveFromSelectedNodes(selectedNodes[i]);
                            }
                        }
                    }
                }

                Invalidate();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (mouseSelectStart != null)
            {
                mouseSelectStart = null;
                mouseSelectEnd = null;
                Invalidate();
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                mouseSelectStart = new Point(e.X, e.Y);
                mouseSelectEnd = new Point(e.X, e.Y);
            }

            var treeviewHitTestInfo = HitTest(e.Location);
            cancelExpandOrCollapse = (treeviewHitTestInfo.Location != TreeViewHitTestLocations.PlusMinus) || (e.Clicks > 1);
            base.OnMouseDown(e);

            if (FullRowSelect)
            {
                switch (e.Button)
                {
                    case MouseButtons.Right:
                        if (treeviewHitTestInfo.Location == TreeViewHitTestLocations.Label)
                        {
                            if (!selectedNodes.Contains(treeviewHitTestInfo.Node))
                            {
                                selectedNodes.Clear();
                                SelectedNode = treeviewHitTestInfo.Node;
                            }
                        }
                        break;
                    case MouseButtons.Left:
                    case MouseButtons.None:
                    case MouseButtons.Middle:
                    case MouseButtons.XButton1:
                    case MouseButtons.XButton2:
                    default:
                        break;
                }
            }
            else
            {
                switch (e.Button)
                {
                    case MouseButtons.Right:
                        if (treeviewHitTestInfo.Location == TreeViewHitTestLocations.Label || treeviewHitTestInfo.Location == TreeViewHitTestLocations.RightOfLabel)
                        {
                            if (!selectedNodes.Contains(treeviewHitTestInfo.Node))
                            {
                                selectedNodes.Clear();
                                SelectedNode = treeviewHitTestInfo.Node;
                            }
                        }
                        break;

                    case MouseButtons.Left:
                        if (treeviewHitTestInfo.Location == TreeViewHitTestLocations.RightOfLabel)
                        {
                            SelectedNode = treeviewHitTestInfo.Node;
                        }
                        break;
                    case MouseButtons.None:
                    case MouseButtons.Middle:
                    case MouseButtons.XButton1:
                    case MouseButtons.XButton2:
                    default:
                        break;
                }
            }
        }

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            var treeviewHitTestInfo = HitTest(e.Location);
            var node = GetNodeAt(e.Location);
            if (node != null)
            {
                if ((treeviewHitTestInfo.Location == TreeViewHitTestLocations.PlusMinus) && (base.HitTest(e.Location).Location != TreeViewHitTestLocations.PlusMinus))
                {
                    node.Toggle();
                }
            }
        }

        protected override void OnNodeMouseDoubleClick(TreeNodeMouseClickEventArgs e)
        {
            var treeviewHitTestInfo = HitTest(e.Location);
            if ((treeviewHitTestInfo.Location == TreeViewHitTestLocations.Image) || (treeviewHitTestInfo.Location == TreeViewHitTestLocations.StateImage) || (treeviewHitTestInfo.Location == TreeViewHitTestLocations.Label))
            {
                base.OnNodeMouseDoubleClick(e);
            }
        }

        private void DrawStateImage(TreeNode node, ref int left, Graphics g)
        {
            if (node.StateImageIndex >= 0)
            {
                left += StateImageList.Images[node.StateImageIndex].Width + SmallShift;
                var point = new Point(left, node.Bounds.Top);
                g.DrawImage(StateImageList.Images[node.StateImageIndex], point);
            }
        }

        private void DrawImage(TreeNode node, ref int left, Graphics g, int image_index)
        {
            if ((ImageList != null) && (ImageList.Images.Count > image_index))
            {
                if (DrawDefaultImageToNodes && (node.ImageIndex >= 0))
                {
                    left += node.Bounds.Height + SmallShift;
                    var point = new Point(left, node.Bounds.Top);
                    g.DrawImage(ImageList.Images[image_index], point);
                }
            }
        }

        private void DrawCheckBoxes(TreeNode node, ref int left, Graphics g)
        {
            if (CheckBoxes)
            {
                left += node.Bounds.Height + SmallShift;
                var rect = new Rectangle(left + SmallShift, node.Bounds.Y + SmallShift, node.Bounds.Height - 4, node.Bounds.Height - 4);
                g.DrawRectangle(BlackPen, rect);
                using (var solidBrush = new SolidBrush(CheckBoxBackground))
                {
                    g.FillRectangle(solidBrush, rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2);
                    if (node.Checked)
                    {
                        int k1, k2, k3, k4, k5, k6;
                        k1 = 2; // left + k1
                        k2 = 6; // bottom - k2

                        k3 = 4; // left + k3
                        k4 = 4; // bottom - k4

                        k5 = 3; // right - k5
                        k6 = 3; // top + k6

                        using (var tick_pen = new Pen(TickColor))
                        {
                            g.DrawLine(tick_pen, rect.Left + k1, rect.Bottom - k2, rect.Left + k3, rect.Bottom - k4);
                            g.DrawLine(tick_pen, rect.Left + k1, rect.Bottom - (k2 - 1), rect.Left + k3, rect.Bottom - (k4 - 1));
                            g.DrawLine(tick_pen, rect.Left + k1, rect.Bottom - (k2 + 1), rect.Left + k3, rect.Bottom - (k4 + 1));

                            g.DrawLine(tick_pen, rect.Left + k3, rect.Bottom - k4, rect.Right - k5, rect.Top + k6);
                            g.DrawLine(tick_pen, rect.Left + k3, rect.Bottom - (k4 - 1), rect.Right - k5, rect.Top + k6 + 1);
                            g.DrawLine(tick_pen, rect.Left + k3, rect.Bottom - (k4 + 1), rect.Right - k5, rect.Top + (k6 - 1));
                        }
                    }
                }
            }
        }

        private new void DrawNode(TreeNode node, Graphics g)
        {
            try
            {
                if (node.IsExpanded && (!Disposing))
                {
                    foreach (TreeNode child_node in node.Nodes)
                    {
                        DrawNode(child_node, g);
                    }
                }
            }
            catch (ObjectDisposedException)
            {
            }

            var imageindex = Constants.NotFound;
            if (node.ImageIndex >= 0)
            {
                imageindex = node.ImageIndex;
            }
            else if (DrawDefaultImageToNodes)
            {
                imageindex = ImageIndex;
            }

            var left = node.Level * node.Bounds.Height;

            // + vagy - rajzolása
            if (ShowPlusMinus && (node.Nodes.Count > 0))
            {
                if (ShowPlusMinusOnRootNodes || (!ShowPlusMinusOnRootNodes && (node.Parent != null)))
                {
                    var rect = new Rectangle(left - MinShift, node.Bounds.Y - MinShift, node.Bounds.Height, node.Bounds.Height);
                    var plusOrMinus = "+";
                    if (node.IsExpanded)
                    {
                        plusOrMinus = "-";
                    }

                    g.DrawString(plusOrMinus, Font, ForeColorBrush, rect, NoWrapStringFormat_Center);

                    // Négyzet rajzolása
                    rect = new Rectangle(left + BigShift, node.Bounds.Y + BigShift, CheckboxSize, CheckboxSize);
                    g.DrawRectangle(GrayPen, rect);
                }
                else
                {
                    //Ha nem rajzolunk plus-minust, kinyitjuk
                    node.Expand();
                }
            }

            if (ShowLines)
            {
                var last_parent = node.Parent;
                if (last_parent != null)
                {
                    using (var pen = new Pen(LineColor))
                    {
                        pen.DashStyle = LineStyle;
                        while (last_parent.Parent != null)
                        {
                            last_parent = last_parent.Parent;
                        }

                        //Függőleges vonalak rajozása
                        var x = left + (node.Bounds.Height / 2);
                        var y = node.Bounds.Top + (node.Bounds.Height / 2);
                        var py = node.Parent.Bounds.Top + node.Parent.Bounds.Height;

                        if (node.Nodes.Count > 0)
                        {
                            y = node.Bounds.Top + 2;
                        }

                        TreeNode brother_node = null;
                        var i = 0;
                        while (i < node.Parent.Nodes.Count)
                        {
                            if (node.Parent.Nodes[i] != node)
                            {
                                brother_node = node.Parent.Nodes[i];
                                if (brother_node.Nodes.Count > 0)
                                {
                                    py = brother_node.Bounds.Top + brother_node.Bounds.Height;
                                }
                                else
                                {
                                    py = brother_node.Bounds.Top + (brother_node.Bounds.Height / 2);
                                }
                            }
                            else
                            {
                                break;
                            }

                            i++;
                        }
                        g.DrawLine(pen, x, py, x, y);

                        // Draw horizontal lines
                        y = node.Bounds.Top + (node.Bounds.Height / 2);
                        if (node.Nodes.Count > 0)
                        {
                            x = left + node.Bounds.Height - 2;
                            g.DrawLine(pen, x, y, left + node.Bounds.Height + 2, y);
                        }
                        else
                        {
                            x = left + (node.Bounds.Height / 2);
                            g.DrawLine(pen, x, y, left + node.Bounds.Height, y);
                        }
                    }
                }
            }

            if (StateImageOrCheckBoxOnLeft)
            {
                if (StateImageList != null)
                {
                    DrawStateImage(node, ref left, g);
                }
                else
                {
                    DrawCheckBoxes(node, ref left, g);
                }

                DrawImage(node, ref left, g, imageindex);
            }
            else
            {
                DrawImage(node, ref left, g, imageindex);
                if (StateImageList != null)
                {
                    DrawStateImage(node, ref left, g);
                }
                else
                {
                    DrawCheckBoxes(node, ref left, g);
                }
            }

            var rectf = (RectangleF)node.Bounds;
            rectf.X = (float)left + node.Bounds.Height;
            rectf.Width = g.MeasureString(node.Text, Font, ClientSize.Width, NoWrapStringFormat_Near).Width;

            if ((node.IsSelected && (!MultiSelect)) || (selectedNodes.Contains(node) && MultiSelect))
            {
                g.FillRectangle(HighlightBrush, rectf);
                g.DrawString(node.Text, Font, HighlightText, rectf, NoWrapStringFormat_Near);
            }
            else
            {
                g.DrawString(node.Text, Font, ForeColorBrush, rectf, NoWrapStringFormat_Near);
            }
        }

        public new TreeViewHitTestInfo HitTest(Point pt)
        {
            var node = GetNodeAt(pt);
            if (node == null)
            {
                return new TreeViewHitTestInfo(null, TreeViewHitTestLocations.None);
            }

            if (pt.X < ClientRectangle.Left)
            {
                return new TreeViewHitTestInfo(node, TreeViewHitTestLocations.LeftOfClientArea);
            }

            if (pt.X > ClientRectangle.Right)
            {
                return new TreeViewHitTestInfo(node, TreeViewHitTestLocations.RightOfLabel);
            }

            if (pt.Y > ClientRectangle.Bottom)
            {
                return new TreeViewHitTestInfo(node, TreeViewHitTestLocations.BelowClientArea);
            }

            if (pt.Y < ClientRectangle.Top)
            {
                return new TreeViewHitTestInfo(node, TreeViewHitTestLocations.AboveClientArea);
            }

            var left = node.Level * node.Bounds.Height;
            if (node.StateImageIndex >= 0)
            {
                left += StateImageList.Images[node.StateImageIndex].Width + SmallShift;
            }
            else if (CheckBoxes)
            {
                left += node.Bounds.Height + SmallShift;
            }

            if (node.ImageIndex >= 0)
            {
                left += node.Bounds.Height + SmallShift;
            }

            var plusMinusOnRootNodes = false;
            foreach (TreeNode rootNode in Nodes)
            {
                if (rootNode.Nodes.Count > 0)
                {
                    plusMinusOnRootNodes = true;
                    break;
                }
            }

            if ((ShowPlusMinus && (node.Nodes.Count > 0)) || ((node.Level == 0) && plusMinusOnRootNodes))
            {
                left += node.Bounds.Height;
            }

            var bounds = new RectangleF(left, node.Bounds.Y, TextRenderer.MeasureText(node.Text, Font, ClientSize, TextFormatFlags.SingleLine).Width, node.Bounds.Height);
            if (bounds.Contains(pt))
            {
                return new TreeViewHitTestInfo(node, TreeViewHitTestLocations.Label);
            }

            float x;
            if (StateImageOrCheckBoxOnLeft)
            {
                if (ImageList != null)
                {
                    if (node.ImageIndex >= 0)
                    {
                        x = ImageList.Images[node.ImageIndex].Width + SmallShift;
                        bounds = new RectangleF(bounds.X - x, bounds.Y, ImageList.Images[node.ImageIndex].Width, ImageList.Images[node.ImageIndex].Height);
                        if (bounds.Contains(pt))
                        {
                            return new TreeViewHitTestInfo(node, TreeViewHitTestLocations.Image);
                        }
                    }
                }
                if (StateImageList != null)
                {
                    if (node.StateImageIndex >= 0)
                    {
                        x = StateImageList.Images[node.StateImageIndex].Width + SmallShift;
                        bounds = new RectangleF(bounds.X - x, bounds.Y, StateImageList.Images[node.StateImageIndex].Width, StateImageList.Images[node.StateImageIndex].Height);
                        if (bounds.Contains(pt))
                        {
                            return new TreeViewHitTestInfo(node, TreeViewHitTestLocations.StateImage);
                        }
                    }
                }
            }
            else
            {
                if (StateImageList != null)
                {
                    if (node.StateImageIndex >= 0)
                    {
                        x = StateImageList.Images[node.StateImageIndex].Width + SmallShift;
                        bounds = new RectangleF(bounds.X - x, bounds.Y, StateImageList.Images[node.StateImageIndex].Width, StateImageList.Images[node.StateImageIndex].Height);
                        if (bounds.Contains(pt))
                        {
                            return new TreeViewHitTestInfo(node, TreeViewHitTestLocations.StateImage);
                        }
                    }
                }
                if (ImageList != null)
                {
                    if (node.ImageIndex >= 0)
                    {
                        x = ImageList.Images[node.ImageIndex].Width + SmallShift;
                        bounds = new RectangleF(bounds.X - x, bounds.Y, ImageList.Images[node.ImageIndex].Width, ImageList.Images[node.ImageIndex].Height);
                        if (bounds.Contains(pt))
                        {
                            return new TreeViewHitTestInfo(node, TreeViewHitTestLocations.Image);
                        }
                    }
                }
            }
            if (ShowPlusMinus && (node.Nodes.Count > 0))
            {
                x = CheckboxSize + (2 * SmallShift);
                bounds = new RectangleF(bounds.X - x, bounds.Y + BigShift, CheckboxSize, CheckboxSize);
                if (bounds.Contains(pt))
                {
                    return new TreeViewHitTestInfo(node, TreeViewHitTestLocations.PlusMinus);
                }
            }

            return new TreeViewHitTestInfo(node, pt.X < bounds.X ? TreeViewHitTestLocations.Indent : TreeViewHitTestLocations.RightOfLabel);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            ForeColorBrush?.Dispose();
            ForeColorBrush = new SolidBrush(ForeColor);
            base.OnForeColorChanged(e);
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            BackColorBrush?.Dispose();
            BackColorBrush = new SolidBrush(BackColor);
            base.OnBackColorChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (e == null || e.Graphics == null)
            {
                return;
            }

            try
            {
                if (!Disposing)
                {
                    e.Graphics.FillRectangle(BackColorBrush, ClientRectangle);
                    foreach (TreeNode node in Nodes)
                    {
                        DrawNode(node, e.Graphics);
                    }

                    if ((mouseSelectStart != null) && multiSelect)
                    {
                        var point = mouseSelectStart.Value;
                        var size = new Size(mouseSelectEnd.Value.X - mouseSelectStart.Value.X, mouseSelectEnd.Value.Y - mouseSelectStart.Value.Y);
                        if ((size.Width != 0) && (size.Height != 0))
                        {
                            if (size.Width < 0)
                            {
                                size.Width = -size.Width;
                                point.X -= size.Width;
                            }
                            if (size.Height < 0)
                            {
                                size.Height = -size.Height;
                                point.Y -= size.Height;
                            }

                            var rect = new Rectangle(point, size);
                            selectionRectangle = rect;
                            using (var pen = new Pen(Color.Gray))
                            {
                                pen.DashStyle = DashStyle.DashDotDot;
                                e.Graphics.DrawRectangle(pen, rect);
                            }
                        }
                        else
                        {
                            selectionRectangle = new Rectangle(0, 0, 0, 0);
                        }
                    }
                    else
                    {
                        selectionRectangle = new Rectangle(0, 0, 0, 0);
                    }
                }
            }
            catch (ObjectDisposedException) { }
        }

        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != (int)WindowMessage.WM_ERASEBKGND)
            {
                base.OnNotifyMessage(m);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            Invalidate();
        }

        public TreeNode GetSelectedTreeNode()
        {
            return this.ExecuteThreadSafely(() => SelectedNode);
        }

        public TreeNode[] GetSelectedTreeNodes()
        {
            return this.ExecuteThreadSafely(() => SelectedNodes);
        }

        public void AddTreeNode(TreeNode treeNode, params int[] parentIndexes)
        {
            this.ExecuteThreadSafely(() =>
            {
                var tnc = GetTreeNodeCollection(parentIndexes);
                _ = tnc.Add(treeNode);
            });
        }

        public void ClearTreeNodes(params int[] parentIndexes)
        {
            this.ExecuteThreadSafely(() =>
            {
                var tnc = GetTreeNodeCollection(parentIndexes);
                tnc.Clear();
            });
        }

        public void ExpandAllThreadSafe()
        {
            this.ExecuteThreadSafely(ExpandAll);
        }

        public void RemoveTreeNode(TreeNode treeNode)
        {
            if (treeNode != null)
            {
                this.ExecuteThreadSafely(treeNode.Remove);
            }
        }

        private static void ChangeNodeTextAndImageIndexes(TreeNode oldTreeNode, TreeNode newTreeNode)
        {
            if (oldTreeNode.Text != newTreeNode.Text)
            {
                oldTreeNode.Text = newTreeNode.Text;
            }

            if (oldTreeNode.ImageIndex != newTreeNode.ImageIndex)
            {
                oldTreeNode.ImageIndex = newTreeNode.ImageIndex;
                oldTreeNode.SelectedImageIndex = newTreeNode.SelectedImageIndex;
            }
        }

        public void ChangeTreeNodes(TreeNode oldTreeNode, TreeNode newTreeNode)
        {
            this.ExecuteThreadSafely(() =>
            {
                for (var i = 0; i < oldTreeNode.Nodes.Count; i++)
                {
                    ChangeTreeNodes(oldTreeNode.Nodes[i], newTreeNode.Nodes[i]);
                }

                ChangeNodeTextAndImageIndexes(oldTreeNode, newTreeNode);
            });
        }

        public TreeNode GetRootNode()
        {
            return this.ExecuteThreadSafely(() => Nodes[0]);
        }

        public static TreeNode GetRootParent(TreeNode treeNode)
        {
            if (treeNode != null)
            {
                while (treeNode.Parent != null)
                {
                    treeNode = treeNode.Parent;
                }
            }
            return treeNode;
        }

        public bool IsTreeNodeSelectedWithTag(object obj)
        {
            return this.ExecuteThreadSafely(() => (SelectedNodes.Length == 1) && obj.Equals(SelectedNodes[0].Tag));
        }

        public void ExportNodesToCsv(string filePath, string delimiter = ",")
        {
            var csvBuilder = new StringBuilder();
            //_ = csvBuilder.AppendLine($"{"Level".PadRight(10)}{delimiter}Node Text{delimiter}Node Tag");

            foreach (TreeNode rootNode in Nodes)
            {
                ExportNode(csvBuilder, delimiter, rootNode, -1);
            }

            File.WriteAllText(filePath, csvBuilder.ToString(), Encoding.UTF8);
        }

        private void ExportNode(StringBuilder csvBuilder, string delimiter, TreeNode node, int level)
        {
            var indent = level > -1 ? $"{new string('\t', level)}{delimiter}" : String.Empty;
            _ = csvBuilder.AppendLine($"{indent}{EscapeCsvValue(node.Text)}{delimiter}{EscapeCsvValue(node.Tag?.ToString() ?? String.Empty)}");

            foreach (TreeNode childNode in node.Nodes)
            {
                ExportNode(csvBuilder, delimiter, childNode, level + 1);
            }
        }

        private static string EscapeCsvValue(string value)
        {
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            {
                value = $"\"{value.Replace("\"", "\"\"")}\"";
            }
            return value;
        }

        private TreeNode GetTreeNodeWithTag(object obj, TreeNode node = null)
        {
            return this.ExecuteThreadSafely(() =>
            {
                TreeNode result = null;
                if (obj != null)
                {
                    var nodeCollection = (node == null) ? Nodes : node.Nodes;
                    for (var i = 0; i < nodeCollection.Count; i++)
                    {
                        if (obj.Equals(nodeCollection[i].Tag))
                        {
                            result = nodeCollection[i];
                            break;
                        }
                        result = GetTreeNodeWithTag(obj, nodeCollection[i]);
                        if (result != null)
                        {
                            break;
                        }
                    }
                }
                return result;
            });
        }

        public TreeNode GetTreeNodeWithTag(object obj, params int[] parentIndexes)
        {
            return this.ExecuteThreadSafely(() =>
            {
                var tnc = GetTreeNodeCollection(parentIndexes);
                for (var i = 0; i < tnc.Count; i++)
                {
                    if (obj.Equals(tnc[i].Tag))
                    {
                        return tnc[i];
                    }
                }
                return null;
            });
        }

        public TreeNodeCollection GetTreeNodeCollection(params int[] parentIndexes)
        {
            return this.ExecuteThreadSafely(() =>
            {
                var tnc = Nodes;
                if (parentIndexes != null)
                {
                    for (var i = 0; i < parentIndexes.Length; i++)
                    {
                        tnc = tnc[parentIndexes[i]].Nodes;
                    }
                }

                return tnc;
            });
        }

        public TreeNode GetTreeNode(params int[] parentIndexesAndNodeIndex)
        {
            return this.ExecuteThreadSafely(() =>
            {
                var tnc = Nodes;
                for (var i = 0; i < parentIndexesAndNodeIndex.Length - 1; i++)
                {
                    tnc = tnc[parentIndexesAndNodeIndex[i]].Nodes;
                }

                return tnc[parentIndexesAndNodeIndex.Length - 1];
            });
        }

        public TreeNode GetTreeNode(string nodeName, params int[] parentIndexes)
        {
            return this.ExecuteThreadSafely(() =>
            {
                var tnc = Nodes;
                for (var i = 0; i < parentIndexes.Length; i++)
                {
                    tnc = tnc[parentIndexes[i]].Nodes;
                }

                return tnc[nodeName];
            });
        }

        public void SetTreeNodeStateImage(int stateimageIndex, params int[] parentIndexesAndNodeIndex)
        {
            this.ExecuteThreadSafely(() =>
            {
                var node = GetTreeNode(parentIndexesAndNodeIndex);
                if (node.StateImageIndex != stateimageIndex)
                {
                    node.StateImageIndex = stateimageIndex;
                }
            });
        }

        public void SetTreeNodeChildsStateImage(int stateImageIndex, TreeNode parentNode)
        {
            this.ExecuteThreadSafely(() =>
            {
                foreach (TreeNode node in parentNode.Nodes)
                {
                    if (node.StateImageIndex != stateImageIndex)
                    {
                        node.StateImageIndex = stateImageIndex;
                    }
                }
            });
        }

        private static TreeNodeCollection GetNextCollectionByIndex(TreeNodeCollection nc, int index)
        {
            return nc[index].Nodes;
        }

        private static TreeNodeCollection GetNextCollectionByTag(TreeNodeCollection nc, object tag)
        {
            for (var i = 0; i < nc.Count; i++)
            {
                if (tag.Equals(nc[i].Tag))
                {
                    return nc[i].Nodes;
                }
            }
            return null;
        }

        private static TreeNode GetNextNodeByIndex(TreeNodeCollection nc, int index)
        {
            return nc[index];
        }

        private static TreeNode GetNextNodeByTag(TreeNodeCollection nc, object tag)
        {
            for (var i = 0; i < nc.Count; i++)
            {
                if (tag.Equals(nc[i].Tag))
                {
                    return nc[i];
                }
            }
            return null;
        }

        private TreeNode FindTreeNodeByIndex(params int[] indices)
        {
            var tnc = Nodes;
            for (var i = 0; i < indices.Length - 1; i++)
            {
                tnc = GetNextCollectionByIndex(tnc, indices[i]);
            }
            return GetNextNodeByIndex(tnc, indices[indices.Length - 1]);
        }

        private TreeNode FindTreeNodeByTag(params object[] tags)
        {
            var tnc = Nodes;
            for (var i = 0; i < tags.Length - 1; i++)
            {
                tnc = GetNextCollectionByTag(tnc, tags[i]);
            }
            return GetNextNodeByTag(tnc, tags[tags.Length - 1]);
        }

        public void SetTreeNodeStateImageByIndex(int stateImageIndex, params int[] indices)
        {
            this.ExecuteThreadSafely(() =>
            {
                var node = FindTreeNodeByIndex(indices);
                if (node.StateImageIndex != stateImageIndex)
                {
                    node.StateImageIndex = stateImageIndex;
                }
            });
        }

        public void SetTreeNodeStateImageByTag(int stateImageIndex, params object[] tags)
        {
            this.ExecuteThreadSafely(() =>
            {
                var node = FindTreeNodeByTag(tags);
                if (node.StateImageIndex != stateImageIndex)
                {
                    node.StateImageIndex = stateImageIndex;
                }
            });
        }

        public void SetTreeNodeImageByIndex(int imageIndex, params int[] indices)
        {
            this.ExecuteThreadSafely(() =>
            {
                var node = FindTreeNodeByIndex(indices);
                if (node.ImageIndex != imageIndex)
                {
                    node.ImageIndex = imageIndex;
                    node.SelectedImageIndex = imageIndex;
                }
            });
        }

        public void SetTreeNodeImageByTag(int imageIndex, params object[] tags)
        {
            this.ExecuteThreadSafely(() =>
            {
                var node = FindTreeNodeByTag(tags);
                if (node.ImageIndex != imageIndex)
                {
                    node.ImageIndex = imageIndex;
                    node.SelectedImageIndex = imageIndex;
                }
            });
        }

        public void SetTreeNodeChildsStateImageByIndex(int stateImageIndex, params int[] indices)
        {
            this.ExecuteThreadSafely(() =>
            {
                var parentNode = FindTreeNodeByIndex(indices);
                foreach (TreeNode node in parentNode.Nodes)
                {
                    if (node.StateImageIndex != stateImageIndex)
                    {
                        node.StateImageIndex = stateImageIndex;
                    }
                }
            });
        }

        public void SetTreeNodeChildsStateImageByTag(int stateImageIndex, params object[] tags)
        {
            this.ExecuteThreadSafely(() =>
            {
                var parentNode = FindTreeNodeByTag(tags);
                foreach (TreeNode node in parentNode.Nodes)
                {
                    if (node.StateImageIndex != stateImageIndex)
                    {
                        node.StateImageIndex = stateImageIndex;
                    }
                }
            });
        }

        public void SetTreeNodeChildsImageByIndex(int imageIndex, params int[] indices)
        {
            this.ExecuteThreadSafely(() =>
            {
                var parentNode = FindTreeNodeByIndex(indices);
                foreach (TreeNode node in parentNode.Nodes)
                {
                    if (node.ImageIndex != imageIndex)
                    {
                        node.ImageIndex = imageIndex;
                        node.SelectedImageIndex = imageIndex;
                    }
                }
            });
        }

        public void SetTreeNodeChildsImageByTag(int imageIndex, params object[] tags)
        {
            this.ExecuteThreadSafely(() =>
            {
                var parentNode = FindTreeNodeByTag(tags);
                foreach (TreeNode node in parentNode.Nodes)
                {
                    if (node.ImageIndex != imageIndex)
                    {
                        node.ImageIndex = imageIndex;
                        node.SelectedImageIndex = imageIndex;
                    }
                }
            });
        }

        public void SetTreeNodeTagByIndex(object tag, params int[] indices)
        {
            this.ExecuteThreadSafely(() =>
            {
                var node = FindTreeNodeByIndex(indices);
                if (!node.Tag.Equals(tag))
                {
                    node.Tag = tag;
                }
            });
        }

        public void SetTreeNodeTagByTag(object tag, params object[] tags)
        {
            this.ExecuteThreadSafely(() =>
            {
                var node = FindTreeNodeByTag(tags);
                if (!node.Tag.Equals(tag))
                {
                    node.Tag = tag;
                }
            });
        }

        public void SetTreeNodeTextByIndex(string text, params int[] indices)
        {
            this.ExecuteThreadSafely(() =>
            {
                var node = FindTreeNodeByIndex(indices);
                if (node.Text != text)
                {
                    node.Text = text;
                }
            });
        }

        public void SetTreeNodeTextByTag(string text, params object[] tags)
        {
            this.ExecuteThreadSafely(() =>
            {
                var node = FindTreeNodeByTag(tags);
                if (node.Text != text)
                {
                    node.Text = text;
                }
            });
        }

        public void SetTreeNodeTooltipByIndex(string tooltip, params int[] indices)
        {
            this.ExecuteThreadSafely(() =>
            {
                var node = FindTreeNodeByIndex(indices);
                if (node.ToolTipText != tooltip)
                {
                    node.ToolTipText = tooltip;
                }
            });
        }

        public void SetTreeNodeTooltipByTag(string tooltip, params object[] tags)
        {
            this.ExecuteThreadSafely(() =>
            {
                var node = FindTreeNodeByTag(tags);
                if (node.ToolTipText != tooltip)
                {
                    node.ToolTipText = tooltip;
                }
            });
        }
    }
}
