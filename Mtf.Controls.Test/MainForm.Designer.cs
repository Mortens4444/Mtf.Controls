using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Controls.Test
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var listViewGroup1 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            var listViewGroup2 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            var listViewItem1 = new ListViewItem(new string[] { "Lorem", "1", "2020.10.21" }, -1);
            var listViewItem2 = new ListViewItem(new string[] { "Ipsum", "", "2020.10.21" }, -1);
            var listViewItem3 = new ListViewItem(new string[] { "Dolor", "2", "2020.10.21" }, -1);
            var listViewItem4 = new ListViewItem(new string[] { "Est", "", "" }, -1);
            var listViewItem5 = new ListViewItem(new string[] { "Sit", "", "2020.10.21" }, -1);
            var listViewItem6 = new ListViewItem(new string[] { "Amet", "5", "2020.10.21" }, -1);
            var treeNode1 = new TreeNode("Node0");
            var treeNode2 = new TreeNode("Node4");
            var treeNode3 = new TreeNode("Node5");
            var treeNode4 = new TreeNode("Node7");
            var treeNode5 = new TreeNode("Node8");
            var treeNode6 = new TreeNode("Node9");
            var treeNode7 = new TreeNode("Node6", new TreeNode[] { treeNode4, treeNode5, treeNode6 });
            var treeNode8 = new TreeNode("Node1", new TreeNode[] { treeNode2, treeNode3, treeNode7 });
            var treeNode9 = new TreeNode("Node2");
            var treeNode10 = new TreeNode("Node3");
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            mtfListView1 = new MtfListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            mtfTreeView1 = new MtfTreeView();
            sourceCodeViewerRichTextBox1 = new SourceCodeViewerRichTextBox();
            mtfPictureBox1 = new MtfPictureBox();
            movablePanel1 = new MovablePanel();
            label2 = new Label();
            label1 = new Label();
            movableSizablePanel1 = new MovableSizablePanel();
            textBox1 = new TextBox();
            transparentPanel1 = new TransparentPanel();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            kbd300aSimulator1 = new Kbd300ASimulator();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)mtfPictureBox1).BeginInit();
            movablePanel1.SuspendLayout();
            movableSizablePanel1.SuspendLayout();
            transparentPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kbd300aSimulator1).BeginInit();
            SuspendLayout();
            // 
            // mtfListView1
            // 
            mtfListView1.AlternatingColorEven = Color.LightBlue;
            mtfListView1.AlternatingColorOdd = SystemColors.Window;
            mtfListView1.AlternatingColorsAreInUse = true;
            mtfListView1.AlternatingPairColorEven = Color.LightSeaGreen;
            mtfListView1.AlternatingPairColorOdd = Color.CadetBlue;
            mtfListView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            mtfListView1.CompactView = false;
            mtfListView1.EnsureLastItemIsVisible = false;
            mtfListView1.FirstItemIsGray = false;
            mtfListView1.FullRowSelect = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "listViewGroup2";
            mtfListView1.Groups.AddRange(new ListViewGroup[] { listViewGroup1, listViewGroup2 });
            mtfListView1.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4, listViewItem5, listViewItem6 });
            mtfListView1.Location = new Point(12, 7);
            mtfListView1.Name = "mtfListView1";
            mtfListView1.OwnerDraw = true;
            mtfListView1.ReadonlyCheckboxes = false;
            mtfListView1.SameItemsColorEven = Color.DarkOrange;
            mtfListView1.SameItemsColorOdd = Color.LightSalmon;
            mtfListView1.Size = new Size(244, 283);
            mtfListView1.TabIndex = 0;
            mtfListView1.UseCompatibleStateImageBehavior = false;
            mtfListView1.View = View.Details;
            // 
            // mtfTreeView1
            // 
            mtfTreeView1.CheckBoxBackground = SystemColors.Window;
            mtfTreeView1.DrawDefaultImageToNodes = true;
            mtfTreeView1.HideSelection = false;
            mtfTreeView1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            mtfTreeView1.Location = new Point(262, 7);
            mtfTreeView1.MultiSelect = false;
            mtfTreeView1.Name = "mtfTreeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Node0";
            treeNode2.Name = "Node4";
            treeNode2.Text = "Node4";
            treeNode3.Name = "Node5";
            treeNode3.Text = "Node5";
            treeNode4.Name = "Node7";
            treeNode4.Text = "Node7";
            treeNode5.Name = "Node8";
            treeNode5.Text = "Node8";
            treeNode6.Name = "Node9";
            treeNode6.Text = "Node9";
            treeNode7.Name = "Node6";
            treeNode7.Text = "Node6";
            treeNode8.Name = "Node1";
            treeNode8.Text = "Node1";
            treeNode9.Name = "Node2";
            treeNode9.Text = "Node2";
            treeNode10.Name = "Node3";
            treeNode10.Text = "Node3";
            mtfTreeView1.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode8, treeNode9, treeNode10 });
            mtfTreeView1.ShowPlusMinusOnRootNodes = true;
            mtfTreeView1.Size = new Size(224, 283);
            mtfTreeView1.StateImageOrCheckBoxOnLeft = false;
            mtfTreeView1.TabIndex = 1;
            mtfTreeView1.TickColor = Color.Green;
            // 
            // sourceCodeViewerRichTextBox1
            // 
            sourceCodeViewerRichTextBox1.AcceptsTab = true;
            sourceCodeViewerRichTextBox1.ColoringMethod = Enums.ColoringMethod.C_Sharp;
            sourceCodeViewerRichTextBox1.DetectUrls = false;
            sourceCodeViewerRichTextBox1.Location = new Point(726, 7);
            sourceCodeViewerRichTextBox1.Name = "sourceCodeViewerRichTextBox1";
            sourceCodeViewerRichTextBox1.ScroolToLastLine = false;
            sourceCodeViewerRichTextBox1.Size = new Size(625, 417);
            sourceCodeViewerRichTextBox1.TabIndex = 3;
            sourceCodeViewerRichTextBox1.Text = resources.GetString("sourceCodeViewerRichTextBox1.Text");
            // 
            // mtfPictureBox1
            // 
            mtfPictureBox1.BackColor = Color.FromArgb(192, 255, 255);
            mtfPictureBox1.BackgroundImageLayout = ImageLayout.Center;
            mtfPictureBox1.Location = new Point(8, 322);
            mtfPictureBox1.Name = "mtfPictureBox1";
            mtfPictureBox1.OriginalSize = new Size(100, 50);
            mtfPictureBox1.RepositioningAndResizingControlsOnResize = false;
            mtfPictureBox1.Size = new Size(171, 102);
            mtfPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            mtfPictureBox1.TabIndex = 4;
            mtfPictureBox1.TabStop = false;
            // 
            // movablePanel1
            // 
            movablePanel1.BackColor = Color.Red;
            movablePanel1.CanMove = true;
            movablePanel1.Controls.Add(label2);
            movablePanel1.Location = new Point(492, 12);
            movablePanel1.Name = "movablePanel1";
            movablePanel1.Size = new Size(228, 78);
            movablePanel1.TabIndex = 7;
            movablePanel1.TransparentColor = Color.Black;
            movablePanel1.UseTransparentColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 22);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 4;
            label2.Text = "Movable";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(114, 15);
            label1.TabIndex = 10;
            label1.Text = "Movable and sizable";
            // 
            // movableSizablePanel1
            // 
            movableSizablePanel1.BackColor = Color.FromArgb(128, 255, 128);
            movableSizablePanel1.CanMove = true;
            movableSizablePanel1.CanSize = true;
            movableSizablePanel1.Controls.Add(label1);
            movableSizablePanel1.Location = new Point(492, 190);
            movableSizablePanel1.Name = "movableSizablePanel1";
            movableSizablePanel1.Size = new Size(228, 100);
            movableSizablePanel1.TabIndex = 11;
            movableSizablePanel1.TransparentColor = Color.Black;
            movableSizablePanel1.UseTransparentColor = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(504, 111);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(194, 23);
            textBox1.TabIndex = 12;
            textBox1.Text = "This textbox seems readonly";
            // 
            // transparentPanel1
            // 
            transparentPanel1.BackColor = Color.White;
            transparentPanel1.BackgroundImageLayout = ImageLayout.Center;
            transparentPanel1.Controls.Add(label3);
            transparentPanel1.Location = new Point(492, 96);
            transparentPanel1.Name = "transparentPanel1";
            transparentPanel1.Size = new Size(228, 88);
            transparentPanel1.TabIndex = 13;
            transparentPanel1.TransparentColor = Color.White;
            transparentPanel1.UseTransparentColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 52);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 0;
            label3.Text = "Transparent panel";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(185, 322);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(171, 102);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 293);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 15;
            label4.Text = "MtfPictureBox";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(185, 293);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 16;
            label5.Text = "PictureBox";
            // 
            // button1
            // 
            button1.Location = new Point(113, 430);
            button1.Name = "button1";
            button1.Size = new Size(106, 23);
            button1.TabIndex = 17;
            button1.Text = "Start test";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.kertmester;
            pictureBox2.Location = new Point(12, 459);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(230, 225);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 18;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(248, 459);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(230, 225);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 19;
            pictureBox3.TabStop = false;
            // 
            // kbd300aSimulator1
            // 
            kbd300aSimulator1.Image = (Image)resources.GetObject("kbd300aSimulator1.Image");
            kbd300aSimulator1.Location = new Point(726, 430);
            kbd300aSimulator1.Name = "kbd300aSimulator1";
            kbd300aSimulator1.OriginalSize = new Size(675, 425);
            kbd300aSimulator1.PipeName = "testpipe";
            kbd300aSimulator1.RepositioningAndResizingControlsOnResize = true;
            kbd300aSimulator1.Shift = false;
            kbd300aSimulator1.Size = new Size(659, 421);
            kbd300aSimulator1.SizeMode = PictureBoxSizeMode.Zoom;
            kbd300aSimulator1.TabIndex = 0;
            kbd300aSimulator1.TabStop = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(504, 431);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(216, 417);
            richTextBox1.TabIndex = 20;
            richTextBox1.Text = "Press a key on KBD300A simulator\n\n";
            richTextBox1.TextChanged += RichTextBox1_TextChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1594, 860);
            Controls.Add(richTextBox1);
            Controls.Add(kbd300aSimulator1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(transparentPanel1);
            Controls.Add(textBox1);
            Controls.Add(movableSizablePanel1);
            Controls.Add(movablePanel1);
            Controls.Add(mtfPictureBox1);
            Controls.Add(sourceCodeViewerRichTextBox1);
            Controls.Add(mtfTreeView1);
            Controls.Add(mtfListView1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)mtfPictureBox1).EndInit();
            movablePanel1.ResumeLayout(false);
            movablePanel1.PerformLayout();
            movableSizablePanel1.ResumeLayout(false);
            movableSizablePanel1.PerformLayout();
            transparentPanel1.ResumeLayout(false);
            transparentPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)kbd300aSimulator1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MtfListView mtfListView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private MtfTreeView mtfTreeView1;
        private SourceCodeViewerRichTextBox sourceCodeViewerRichTextBox1;
        private MtfPictureBox mtfPictureBox1;
        private MovablePanel movablePanel1;
        private Label label2;
        private Label label1;
        private MovableSizablePanel movableSizablePanel1;
        private TextBox textBox1;
        private TransparentPanel transparentPanel1;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label4;
        private Label label5;
        private Button button1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Kbd300ASimulator kbd300aSimulator1;
        private RichTextBox richTextBox1;
    }
}
