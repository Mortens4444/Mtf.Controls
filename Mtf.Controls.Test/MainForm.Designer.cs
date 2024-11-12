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
            components = new System.ComponentModel.Container();
            var listViewGroup3 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            var listViewGroup4 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            var listViewItem53 = new ListViewItem(new string[] { "Lorem", "1", "2020.10.21" }, -1);
            var listViewItem54 = new ListViewItem(new string[] { "Ipsum", "", "2020.10.21" }, -1);
            var listViewItem55 = new ListViewItem(new string[] { "Dolor", "2", "2020.10.21" }, -1);
            var listViewItem56 = new ListViewItem(new string[] { "Est", "", "" }, -1);
            var listViewItem57 = new ListViewItem(new string[] { "Sit", "", "2020.10.21" }, -1);
            var listViewItem58 = new ListViewItem(new string[] { "Amet", "5", "2020.10.21" }, -1);
            var treeNode11 = new TreeNode("Node0");
            var treeNode12 = new TreeNode("Node4");
            var treeNode13 = new TreeNode("Node5");
            var treeNode14 = new TreeNode("Node7");
            var treeNode15 = new TreeNode("Node8");
            var treeNode16 = new TreeNode("Node9");
            var treeNode17 = new TreeNode("Node6", new TreeNode[] { treeNode14, treeNode15, treeNode16 });
            var treeNode18 = new TreeNode("Node1", new TreeNode[] { treeNode12, treeNode13, treeNode17 });
            var treeNode19 = new TreeNode("Node2");
            var treeNode20 = new TreeNode("Node3");
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            var listViewItem59 = new ListViewItem(new string[] { "$AV_AVG", "Folder", "" }, "folder");
            var listViewItem60 = new ListViewItem(new string[] { "$Recycle.Bin", "Folder", "" }, "folder");
            var listViewItem61 = new ListViewItem(new string[] { "avi", "Folder", "" }, "folder");
            var listViewItem62 = new ListViewItem(new string[] { "BigFishCache", "Folder", "" }, "folder");
            var listViewItem63 = new ListViewItem(new string[] { "Code Browser", "Folder", "" }, "folder");
            var listViewItem64 = new ListViewItem(new string[] { "DesktopUpdater", "Folder", "" }, "folder");
            var listViewItem65 = new ListViewItem(new string[] { "dicomdir", "Folder", "" }, "folder");
            var listViewItem66 = new ListViewItem(new string[] { "Documents and Settings", "Folder", "" }, "folder");
            var listViewItem67 = new ListViewItem(new string[] { "ECGo", "Folder", "" }, "folder");
            var listViewItem68 = new ListViewItem(new string[] { "ffmpeg-master-latest-win64-gpl", "Folder", "" }, "folder");
            var listViewItem69 = new ListViewItem(new string[] { "gcc", "Folder", "" }, "folder");
            var listViewItem70 = new ListViewItem(new string[] { "gradle", "Folder", "" }, "folder");
            var listViewItem71 = new ListViewItem(new string[] { "Install", "Folder", "" }, "folder");
            var listViewItem72 = new ListViewItem(new string[] { "Intel", "Folder", "" }, "folder");
            var listViewItem73 = new ListViewItem(new string[] { "logs", "Folder", "" }, "folder");
            var listViewItem74 = new ListViewItem(new string[] { "Masm", "Folder", "" }, "folder");
            var listViewItem75 = new ListViewItem(new string[] { "Microsoft Shared", "Folder", "" }, "folder");
            var listViewItem76 = new ListViewItem(new string[] { "My Web Sites", "Folder", "" }, "folder");
            var listViewItem77 = new ListViewItem(new string[] { "NuGetTest", "Folder", "" }, "folder");
            var listViewItem78 = new ListViewItem(new string[] { "OneDriveTemp", "Folder", "" }, "folder");
            var listViewItem79 = new ListViewItem(new string[] { "PE-bear", "Folder", "" }, "folder");
            var listViewItem80 = new ListViewItem(new string[] { "PerfLogs", "Folder", "" }, "folder");
            var listViewItem81 = new ListViewItem(new string[] { "processing-4.0b4", "Folder", "" }, "folder");
            var listViewItem82 = new ListViewItem(new string[] { "Program Files", "Folder", "" }, "folder");
            var listViewItem83 = new ListViewItem(new string[] { "Program Files (x86)", "Folder", "" }, "folder");
            var listViewItem84 = new ListViewItem(new string[] { "ProgramData", "Folder", "" }, "folder");
            var listViewItem85 = new ListViewItem(new string[] { "Recovery", "Folder", "" }, "folder");
            var listViewItem86 = new ListViewItem(new string[] { "SQL2022", "Folder", "" }, "folder");
            var listViewItem87 = new ListViewItem(new string[] { "System Volume Information", "Folder", "" }, "folder");
            var listViewItem88 = new ListViewItem(new string[] { "TeamCity", "Folder", "" }, "folder");
            var listViewItem89 = new ListViewItem(new string[] { "temp", "Folder", "" }, "folder");
            var listViewItem90 = new ListViewItem(new string[] { "Users", "Folder", "" }, "folder");
            var listViewItem91 = new ListViewItem(new string[] { "VideoProjects", "Folder", "" }, "folder");
            var listViewItem92 = new ListViewItem(new string[] { "Windows", "Folder", "" }, "folder");
            var listViewItem93 = new ListViewItem(new string[] { "Work", "Folder", "" }, "folder");
            var listViewItem94 = new ListViewItem(new string[] { "$WINRE_BACKUP_PARTITION.MARKER", ".MARKER File", "0 KB" }, ".marker");
            var listViewItem95 = new ListViewItem(new string[] { "AMTAG.BIN", ".BIN File", "1 KB" }, ".bin");
            var listViewItem96 = new ListViewItem(new string[] { "appverifUI.dll", ".DLL File", "109 KB" }, ".dll");
            var listViewItem97 = new ListViewItem(new string[] { "bootTel.dat", ".DAT File", "0 KB" }, ".dat");
            var listViewItem98 = new ListViewItem(new string[] { "DumpStack.log", ".LOG File", "12 KB" }, ".log");
            var listViewItem99 = new ListViewItem(new string[] { "DumpStack.log.tmp", ".TMP File", "12 KB" }, ".tmp");
            var listViewItem100 = new ListViewItem(new string[] { "hiberfil.sys", ".SYS File", "6613936 KB" }, ".sys");
            var listViewItem101 = new ListViewItem(new string[] { "Not recognized checkmate.png", ".PNG File", "66 KB" }, ".png");
            var listViewItem102 = new ListViewItem(new string[] { "pagefile.sys", ".SYS File", "39043328 KB" }, ".sys");
            var listViewItem103 = new ListViewItem(new string[] { "swapfile.sys", ".SYS File", "278528 KB" }, ".sys");
            var listViewItem104 = new ListViewItem(new string[] { "vfcompat.dll", ".DLL File", "65 KB" }, ".dll");
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
            fileBrowserView1 = new FileBrowserView();
            passwordBox1 = new PasswordBox();
            button2 = new Button();
            textBox2 = new TextBox();
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
            listViewGroup3.Header = "ListViewGroup";
            listViewGroup3.Name = "listViewGroup1";
            listViewGroup4.Header = "ListViewGroup";
            listViewGroup4.Name = "listViewGroup2";
            mtfListView1.Groups.AddRange(new ListViewGroup[] { listViewGroup3, listViewGroup4 });
            mtfListView1.Items.AddRange(new ListViewItem[] { listViewItem53, listViewItem54, listViewItem55, listViewItem56, listViewItem57, listViewItem58 });
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
            treeNode11.Name = "Node0";
            treeNode11.Text = "Node0";
            treeNode12.Name = "Node4";
            treeNode12.Text = "Node4";
            treeNode13.Name = "Node5";
            treeNode13.Text = "Node5";
            treeNode14.Name = "Node7";
            treeNode14.Text = "Node7";
            treeNode15.Name = "Node8";
            treeNode15.Text = "Node8";
            treeNode16.Name = "Node9";
            treeNode16.Text = "Node9";
            treeNode17.Name = "Node6";
            treeNode17.Text = "Node6";
            treeNode18.Name = "Node1";
            treeNode18.Text = "Node1";
            treeNode19.Name = "Node2";
            treeNode19.Text = "Node2";
            treeNode20.Name = "Node3";
            treeNode20.Text = "Node3";
            mtfTreeView1.Nodes.AddRange(new TreeNode[] { treeNode11, treeNode18, treeNode19, treeNode20 });
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
            sourceCodeViewerRichTextBox1.Size = new Size(357, 417);
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
            // fileBrowserView1
            // 
            fileBrowserView1.FullRowSelect = true;
            fileBrowserView1.Items.AddRange(new ListViewItem[] { listViewItem59, listViewItem60, listViewItem61, listViewItem62, listViewItem63, listViewItem64, listViewItem65, listViewItem66, listViewItem67, listViewItem68, listViewItem69, listViewItem70, listViewItem71, listViewItem72, listViewItem73, listViewItem74, listViewItem75, listViewItem76, listViewItem77, listViewItem78, listViewItem79, listViewItem80, listViewItem81, listViewItem82, listViewItem83, listViewItem84, listViewItem85, listViewItem86, listViewItem87, listViewItem88, listViewItem89, listViewItem90, listViewItem91, listViewItem92, listViewItem93, listViewItem94, listViewItem95, listViewItem96, listViewItem97, listViewItem98, listViewItem99, listViewItem100, listViewItem101, listViewItem102, listViewItem103, listViewItem104 });
            fileBrowserView1.Location = new Point(1089, 7);
            fileBrowserView1.Name = "fileBrowserView1";
            fileBrowserView1.Size = new Size(413, 417);
            fileBrowserView1.TabIndex = 21;
            fileBrowserView1.UseCompatibleStateImageBehavior = false;
            fileBrowserView1.View = View.Details;
            fileBrowserView1.WorkingDirectory = "C:\\";
            // 
            // passwordBox1
            // 
            passwordBox1.Location = new Point(492, 322);
            passwordBox1.Name = "passwordBox1";
            passwordBox1.Password = "";
            passwordBox1.PasswordChar = '*';
            passwordBox1.ShowRealPasswordLength = false;
            passwordBox1.Size = new Size(100, 23);
            passwordBox1.TabIndex = 22;
            // 
            // button2
            // 
            button2.Location = new Point(598, 321);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 23;
            button2.Text = "Get password";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(492, 350);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(206, 23);
            textBox2.TabIndex = 24;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1594, 860);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(passwordBox1);
            Controls.Add(fileBrowserView1);
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
        private FileBrowserView fileBrowserView1;
        private PasswordBox passwordBox1;
        private Button button2;
        private TextBox textBox2;
    }
}
