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
            var listViewGroup1 = new ListViewGroup("A", HorizontalAlignment.Left);
            var listViewGroup2 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            var listViewItem1 = new ListViewItem(new string[] { "Lorem", "1", "2020.10.21" }, -1);
            var listViewItem2 = new ListViewItem(new string[] { "Ipsum", "", "2020.10.21" }, -1);
            var listViewItem3 = new ListViewItem(new string[] { "Dolor", "2", "2020.10.21" }, -1);
            var listViewItem4 = new ListViewItem(new string[] { "Est", "", "" }, -1);
            var listViewItem5 = new ListViewItem(new string[] { "Sit", "", "2020.10.21" }, -1);
            var listViewItem6 = new ListViewItem(new string[] { "Amet", "5", "2020.10.21" }, -1);
            var treeNode1 = new TreeNode("a", 0, -2);
            var treeNode2 = new TreeNode("b", 0, 0);
            var treeNode3 = new TreeNode("Node5", 0, 0);
            var treeNode4 = new TreeNode("c", 1, 1);
            var treeNode5 = new TreeNode("Node8", 1, 1);
            var treeNode6 = new TreeNode("Node9", 1, 1);
            var treeNode7 = new TreeNode("Node6", 0, 0, new TreeNode[] { treeNode4, treeNode5, treeNode6 });
            var treeNode8 = new TreeNode("Node1", 0, -2, new TreeNode[] { treeNode2, treeNode3, treeNode7 });
            var treeNode9 = new TreeNode("Node2", -2, -2);
            var treeNode10 = new TreeNode("Node3", -2, -2);
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            var listViewItem7 = new ListViewItem(new string[] { "..", "Parent Directory" }, "up");
            var listViewItem8 = new ListViewItem(new string[] { "mfxlib.log", ".LOG File", "12,4 MB" }, ".log");
            var listViewItem9 = new ListViewItem(new string[] { "rvs.txt", ".TXT File", "167,2 kB" }, ".txt");
            var listViewGroup3 = new ListViewGroup("1. Group", HorizontalAlignment.Left);
            var listViewGroup4 = new ListViewGroup("2. Group", HorizontalAlignment.Left);
            var listViewItem10 = new ListViewItem("1");
            var listViewItem11 = new ListViewItem("2");
            var listViewItem12 = new ListViewItem("3");
            mtfListView1 = new MtfListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            mtfTreeView1 = new MtfTreeView();
            imageList = new ImageList(components);
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
            richTextBox1 = new RichTextBox();
            fileBrowserView1 = new FileBrowserView();
            passwordBox1 = new PasswordBox();
            button2 = new Button();
            textBox2 = new TextBox();
            ansiColoringRichTextBox1 = new AnsiColoringRichTextBox();
            textBoxWithRegEx1 = new TextBoxWithRegEx();
            richTextBoxWithLineNumbers1 = new RichTextBoxWithLineNumbers();
            rotatableImagePanel1 = new RotatableImagePanel();
            editableComboBox1 = new EditableComboBox();
            button3 = new Button();
            openCvSharp4VideoWindow1 = new Mtf.Controls.Video.OpenCvSharp.OpenCvSharp4VideoWindow();
            button7 = new Button();
            vlcWindow1 = new Mtf.Controls.Video.VLC.VlcWindow();
            fFmpegWindow1 = new Mtf.Controls.Video.FFmpeg.FFmpegWindow();
            mortoGraphyWindow1 = new Mtf.Controls.Video.MortoGraphyWindow();
            mtfListView2 = new MtfListView();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            btnExport = new Button();
            button5 = new Button();
            mtfPictureBox2 = new MtfPictureBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            tabPage7 = new TabPage();
            tabPage8 = new TabPage();
            btnTest = new Button();
            btnMoveCaretToDown = new Button();
            btnMoveCaretToRight = new Button();
            btnMoveCaretToUp = new Button();
            btnMoveCaretToLeft = new Button();
            btnHome = new Button();
            btnAppendToAnsiText = new Button();
            tbAnsiText = new TextBox();
            chkStrikeout = new CheckBox();
            chkBold = new CheckBox();
            chkItalic = new CheckBox();
            chkUnderline = new CheckBox();
            lblBackColor = new Label();
            pbBackColor = new PictureBox();
            lblFontColor = new Label();
            pbFontColor = new PictureBox();
            tabPage9 = new TabPage();
            tabPage10 = new TabPage();
            tabPage11 = new TabPage();
            tbSunellIpr67Ip = new TextBox();
            lblSunellIpr67Ip = new Label();
            lblSunellPassword = new Label();
            lblSunellUsername = new Label();
            lblSunellIpr66Ip = new Label();
            tbSunellPassword = new TextBox();
            tbSunellUsername = new TextBox();
            tbSunellIpr66Ip = new TextBox();
            chkSunellIpr67 = new CheckBox();
            chkSunellIpr66 = new CheckBox();
            sunellVideoWindowLegacy1 = new Mtf.Controls.Video.Sunell.IPR66.SunellVideoWindowLegacy();
            chkMortoGraphyWindow = new CheckBox();
            chkOpenCvSharp4Video = new CheckBox();
            chkFFMpegVideo = new CheckBox();
            chkVlcVideo = new CheckBox();
            tbUrl = new TextBox();
            tabPage12 = new TabPage();
            kbd300aSimulator1 = new Kbd300ASimulator();
            colorDialog = new ColorDialog();
            sunellVideoWindow1 = new Mtf.Controls.Video.Sunell.IPR67.SunellVideoWindow();
            ((System.ComponentModel.ISupportInitialize)mtfPictureBox1).BeginInit();
            movablePanel1.SuspendLayout();
            movableSizablePanel1.SuspendLayout();
            transparentPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)openCvSharp4VideoWindow1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vlcWindow1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fFmpegWindow1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mortoGraphyWindow1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mtfPictureBox2).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            tabPage6.SuspendLayout();
            tabPage7.SuspendLayout();
            tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBackColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFontColor).BeginInit();
            tabPage9.SuspendLayout();
            tabPage10.SuspendLayout();
            tabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sunellVideoWindowLegacy1).BeginInit();
            tabPage12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)kbd300aSimulator1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sunellVideoWindow1).BeginInit();
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
            listViewGroup1.Header = "A";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "listViewGroup2";
            mtfListView1.Groups.AddRange(new ListViewGroup[] { listViewGroup1, listViewGroup2 });
            listViewItem5.Group = listViewGroup2;
            listViewItem6.Group = listViewGroup1;
            mtfListView1.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4, listViewItem5, listViewItem6 });
            mtfListView1.Location = new Point(3, 6);
            mtfListView1.Name = "mtfListView1";
            mtfListView1.OwnerDraw = true;
            mtfListView1.ReadonlyCheckboxes = false;
            mtfListView1.SameItemsColorEven = Color.DarkOrange;
            mtfListView1.SameItemsColorOdd = Color.LightSalmon;
            mtfListView1.Size = new Size(387, 293);
            mtfListView1.TabIndex = 0;
            mtfListView1.UseCompatibleStateImageBehavior = false;
            mtfListView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "H1";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "H2";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "H3";
            // 
            // mtfTreeView1
            // 
            mtfTreeView1.CheckBoxBackground = SystemColors.Window;
            mtfTreeView1.DrawDefaultImageToNodes = true;
            mtfTreeView1.HideSelection = false;
            mtfTreeView1.ImageIndex = 0;
            mtfTreeView1.ImageList = imageList;
            mtfTreeView1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            mtfTreeView1.Location = new Point(6, 6);
            mtfTreeView1.MultiSelect = false;
            mtfTreeView1.Name = "mtfTreeView1";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "Node0";
            treeNode1.SelectedImageIndex = -2;
            treeNode1.Text = "a";
            treeNode2.ImageIndex = 0;
            treeNode2.Name = "Node4";
            treeNode2.SelectedImageIndex = 0;
            treeNode2.Text = "b";
            treeNode3.ImageIndex = 0;
            treeNode3.Name = "Node5";
            treeNode3.SelectedImageIndex = 0;
            treeNode3.Text = "Node5";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "Node7";
            treeNode4.SelectedImageIndex = 1;
            treeNode4.Text = "c";
            treeNode5.ImageIndex = 1;
            treeNode5.Name = "Node8";
            treeNode5.SelectedImageIndex = 1;
            treeNode5.Text = "Node8";
            treeNode6.ImageIndex = 1;
            treeNode6.Name = "Node9";
            treeNode6.SelectedImageIndex = 1;
            treeNode6.Text = "Node9";
            treeNode7.ImageIndex = 0;
            treeNode7.Name = "Node6";
            treeNode7.SelectedImageIndex = 0;
            treeNode7.Text = "Node6";
            treeNode8.ImageIndex = 0;
            treeNode8.Name = "Node1";
            treeNode8.SelectedImageIndex = -2;
            treeNode8.Text = "Node1";
            treeNode9.ImageIndex = -2;
            treeNode9.Name = "Node2";
            treeNode9.SelectedImageIndex = -2;
            treeNode9.Text = "Node2";
            treeNode10.ImageIndex = -2;
            treeNode10.Name = "Node3";
            treeNode10.SelectedImageIndex = -2;
            treeNode10.Text = "Node3";
            mtfTreeView1.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode8, treeNode9, treeNode10 });
            mtfTreeView1.SelectedImageIndex = 0;
            mtfTreeView1.ShowPlusMinusOnRootNodes = true;
            mtfTreeView1.Size = new Size(224, 201);
            mtfTreeView1.StateImageOrCheckBoxOnLeft = false;
            mtfTreeView1.TabIndex = 1;
            mtfTreeView1.TickColor = Color.Green;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageStream = (ImageListStreamer)resources.GetObject("imageList.ImageStream");
            imageList.TransparentColor = Color.Transparent;
            imageList.Images.SetKeyName(0, "add_group.ico");
            imageList.Images.SetKeyName(1, "add_user.ico");
            // 
            // sourceCodeViewerRichTextBox1
            // 
            sourceCodeViewerRichTextBox1.AcceptsTab = true;
            sourceCodeViewerRichTextBox1.ColoringMethod = Enums.ColoringMethod.C_Sharp;
            sourceCodeViewerRichTextBox1.DetectUrls = false;
            sourceCodeViewerRichTextBox1.Dock = DockStyle.Fill;
            sourceCodeViewerRichTextBox1.Location = new Point(0, 0);
            sourceCodeViewerRichTextBox1.Name = "sourceCodeViewerRichTextBox1";
            sourceCodeViewerRichTextBox1.ScroolToLastLine = false;
            sourceCodeViewerRichTextBox1.Size = new Size(1586, 832);
            sourceCodeViewerRichTextBox1.TabIndex = 3;
            sourceCodeViewerRichTextBox1.Text = resources.GetString("sourceCodeViewerRichTextBox1.Text");
            // 
            // mtfPictureBox1
            // 
            mtfPictureBox1.BackColor = Color.FromArgb(192, 255, 255);
            mtfPictureBox1.BackgroundImageLayout = ImageLayout.Center;
            mtfPictureBox1.BackgroundPaintDebounceIntervalInMs = 0;
            mtfPictureBox1.Location = new Point(185, 16);
            mtfPictureBox1.Name = "mtfPictureBox1";
            mtfPictureBox1.OriginalSize = new Size(171, 102);
            mtfPictureBox1.PaintDebounceIntervalInMs = 0;
            mtfPictureBox1.RepositioningAndResizingControlsOnResize = false;
            mtfPictureBox1.ResizeDebounceIntervalInMs = 200;
            mtfPictureBox1.ShowPaintErrors = false;
            mtfPictureBox1.ShowResizeErrors = false;
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
            movablePanel1.Location = new Point(16, 13);
            movablePanel1.Name = "movablePanel1";
            movablePanel1.Size = new Size(228, 78);
            movablePanel1.TabIndex = 7;
            movablePanel1.TransparentColor = Color.Black;
            movablePanel1.UseTransparentColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 19);
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
            movableSizablePanel1.Location = new Point(16, 191);
            movableSizablePanel1.Name = "movableSizablePanel1";
            movableSizablePanel1.Size = new Size(228, 100);
            movableSizablePanel1.TabIndex = 11;
            movableSizablePanel1.TransparentColor = Color.Black;
            movableSizablePanel1.UseTransparentColor = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(28, 112);
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
            transparentPanel1.Location = new Point(16, 97);
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
            pictureBox1.Location = new Point(8, 16);
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
            button1.Location = new Point(113, 124);
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
            pictureBox2.Location = new Point(1087, 106);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(230, 225);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 18;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.hack_with_me;
            pictureBox3.Location = new Point(1323, 106);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(230, 225);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 19;
            pictureBox3.TabStop = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(8, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(230, 383);
            richTextBox1.TabIndex = 20;
            richTextBox1.Text = "Press a key on KBD300A simulator\n\n";
            richTextBox1.TextChanged += RichTextBox1_TextChanged;
            // 
            // fileBrowserView1
            // 
            fileBrowserView1.Dock = DockStyle.Fill;
            fileBrowserView1.FullRowSelect = true;
            listViewItem7.Tag = "up";
            fileBrowserView1.Items.AddRange(new ListViewItem[] { listViewItem7, listViewItem8, listViewItem9 });
            fileBrowserView1.Location = new Point(0, 0);
            fileBrowserView1.Name = "fileBrowserView1";
            fileBrowserView1.Size = new Size(1586, 832);
            fileBrowserView1.TabIndex = 21;
            fileBrowserView1.UseCompatibleStateImageBehavior = false;
            fileBrowserView1.View = View.Details;
            fileBrowserView1.WorkingDirectory = "C:\\Temp";
            // 
            // passwordBox1
            // 
            passwordBox1.Location = new Point(19, 22);
            passwordBox1.Name = "passwordBox1";
            passwordBox1.Password = "";
            passwordBox1.PasswordChar = '*';
            passwordBox1.ShowRealPasswordLength = false;
            passwordBox1.Size = new Size(100, 23);
            passwordBox1.TabIndex = 22;
            // 
            // button2
            // 
            button2.Location = new Point(125, 22);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 23;
            button2.Text = "Get password";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BtnShowPassword_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(19, 51);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(206, 23);
            textBox2.TabIndex = 24;
            // 
            // ansiColoringRichTextBox1
            // 
            ansiColoringRichTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ansiColoringRichTextBox1.BackColor = Color.Black;
            ansiColoringRichTextBox1.BlackColor = Color.Black;
            ansiColoringRichTextBox1.BlueColor = Color.Blue;
            ansiColoringRichTextBox1.BrightBlackColor = Color.DarkGray;
            ansiColoringRichTextBox1.BrightBlueColor = Color.LightBlue;
            ansiColoringRichTextBox1.BrightCyanColor = Color.LightCyan;
            ansiColoringRichTextBox1.BrightGreenColor = Color.LightGreen;
            ansiColoringRichTextBox1.BrightPurpleColor = Color.Plum;
            ansiColoringRichTextBox1.BrightRedColor = Color.LightCoral;
            ansiColoringRichTextBox1.BrightWhiteColor = Color.Wheat;
            ansiColoringRichTextBox1.BrightYellowColor = Color.LightYellow;
            ansiColoringRichTextBox1.ClearScreenOnThemeChange = false;
            ansiColoringRichTextBox1.CyanColor = Color.Cyan;
            ansiColoringRichTextBox1.DeleteNewLineCharactersWhenEraseLineCalled = false;
            ansiColoringRichTextBox1.ForeColor = Color.White;
            ansiColoringRichTextBox1.GreenColor = Color.Green;
            ansiColoringRichTextBox1.LineSeparators = new string[]
    {
    "\r",
    "\n"
    };
            ansiColoringRichTextBox1.Location = new Point(0, 43);
            ansiColoringRichTextBox1.Name = "ansiColoringRichTextBox1";
            ansiColoringRichTextBox1.PurpleColor = Color.Purple;
            ansiColoringRichTextBox1.RedColor = Color.Red;
            ansiColoringRichTextBox1.Size = new Size(1586, 789);
            ansiColoringRichTextBox1.StringSplitOptions = System.StringSplitOptions.RemoveEmptyEntries;
            ansiColoringRichTextBox1.TabIndex = 25;
            ansiColoringRichTextBox1.Text = "";
            ansiColoringRichTextBox1.Theme = Enums.Theme.Dark;
            ansiColoringRichTextBox1.WhiteColor = Color.White;
            ansiColoringRichTextBox1.YellowColor = Color.Yellow;
            // 
            // textBoxWithRegEx1
            // 
            textBoxWithRegEx1.AcceptColor = Color.LightGreen;
            textBoxWithRegEx1.DisplayErrorOnLeft = false;
            textBoxWithRegEx1.ErrorMessage = "The given text not macthing the regex.";
            textBoxWithRegEx1.Location = new Point(8, 202);
            textBoxWithRegEx1.Name = "textBoxWithRegEx1";
            textBoxWithRegEx1.RegularExpression = "\\b((25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)\\b";
            textBoxWithRegEx1.RejectionColor = Color.LightSalmon;
            textBoxWithRegEx1.Size = new Size(214, 23);
            textBoxWithRegEx1.TabIndex = 26;
            // 
            // richTextBoxWithLineNumbers1
            // 
            richTextBoxWithLineNumbers1.ColoringMethod = Enums.ColoringMethod.No_Coloring;
            richTextBoxWithLineNumbers1.CopyText = "Copy";
            richTextBoxWithLineNumbers1.CutText = "Cut";
            richTextBoxWithLineNumbers1.Dock = DockStyle.Fill;
            richTextBoxWithLineNumbers1.EmbeddedContextMenuStrip = true;
            richTextBoxWithLineNumbers1.Location = new Point(0, 0);
            richTextBoxWithLineNumbers1.Margin = new Padding(4, 3, 4, 3);
            richTextBoxWithLineNumbers1.Name = "richTextBoxWithLineNumbers1";
            richTextBoxWithLineNumbers1.PasteText = "Paste";
            richTextBoxWithLineNumbers1.ReadOnly = false;
            richTextBoxWithLineNumbers1.RichTextBoxBackColor = SystemColors.Window;
            richTextBoxWithLineNumbers1.RichTextBoxForeColor = SystemColors.WindowText;
            richTextBoxWithLineNumbers1.SelectionColor = Color.Black;
            richTextBoxWithLineNumbers1.SelectionLength = 0;
            richTextBoxWithLineNumbers1.SelectionStart = 0;
            richTextBoxWithLineNumbers1.ShowLineNumbers = true;
            richTextBoxWithLineNumbers1.Size = new Size(1586, 832);
            richTextBoxWithLineNumbers1.TabIndex = 27;
            richTextBoxWithLineNumbers1.WrapLines = false;
            // 
            // rotatableImagePanel1
            // 
            rotatableImagePanel1.BackgroundImage = Properties.Resources.kertmester;
            rotatableImagePanel1.BackgroundImageLayout = ImageLayout.Stretch;
            rotatableImagePanel1.CanMove = true;
            rotatableImagePanel1.CanSize = true;
            rotatableImagePanel1.Location = new Point(377, 16);
            rotatableImagePanel1.Name = "rotatableImagePanel1";
            rotatableImagePanel1.RotatingMouseButton = MouseButtons.Middle;
            rotatableImagePanel1.Rotation = null;
            rotatableImagePanel1.Size = new Size(132, 102);
            rotatableImagePanel1.TabIndex = 28;
            rotatableImagePanel1.TransparentColor = Color.Black;
            rotatableImagePanel1.UseTransparentColor = false;
            // 
            // editableComboBox1
            // 
            editableComboBox1.FormattingEnabled = true;
            editableComboBox1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7" });
            editableComboBox1.Location = new Point(8, 130);
            editableComboBox1.Name = "editableComboBox1";
            editableComboBox1.Size = new Size(217, 23);
            editableComboBox1.TabIndex = 29;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.Control;
            button3.Location = new Point(20, 342);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 31;
            button3.Text = "Start";
            button3.UseVisualStyleBackColor = false;
            button3.Click += BtnStartVideoWindows_Click;
            // 
            // openCvSharp4VideoWindow1
            // 
            openCvSharp4VideoWindow1.BackgroundImage = (Image)resources.GetObject("openCvSharp4VideoWindow1.BackgroundImage");
            openCvSharp4VideoWindow1.BackgroundImageLayout = ImageLayout.Stretch;
            openCvSharp4VideoWindow1.Location = new Point(20, 196);
            openCvSharp4VideoWindow1.Name = "openCvSharp4VideoWindow1";
            openCvSharp4VideoWindow1.OverlayFont = new Font("Arial", 32F, FontStyle.Bold);
            openCvSharp4VideoWindow1.OverlayLocation = new Point(10, 10);
            openCvSharp4VideoWindow1.OverlayText = "Open CV Sharp 4";
            openCvSharp4VideoWindow1.Size = new Size(218, 135);
            openCvSharp4VideoWindow1.SizeMode = PictureBoxSizeMode.StretchImage;
            openCvSharp4VideoWindow1.TabIndex = 32;
            openCvSharp4VideoWindow1.TabStop = false;
            // 
            // button7
            // 
            button7.Location = new Point(101, 342);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 36;
            button7.Text = "Stop";
            button7.UseVisualStyleBackColor = true;
            button7.Click += BtnStopVideoWindows_Click;
            // 
            // vlcWindow1
            // 
            vlcWindow1.BackColor = Color.Black;
            vlcWindow1.BackgroundImage = (Image)resources.GetObject("vlcWindow1.BackgroundImage");
            vlcWindow1.BackgroundImageLayout = ImageLayout.Stretch;
            vlcWindow1.Location = new Point(20, 35);
            vlcWindow1.MediaPlayer = null;
            vlcWindow1.Name = "vlcWindow1";
            vlcWindow1.OverlayFont = new Font("Arial", 32F, FontStyle.Bold);
            vlcWindow1.OverlayLocation = new Point(10, 10);
            vlcWindow1.OverlayText = "VLC";
            vlcWindow1.Size = new Size(218, 138);
            vlcWindow1.TabIndex = 38;
            vlcWindow1.Text = "vlcWindow1";
            // 
            // fFmpegWindow1
            // 
            fFmpegWindow1.BackColor = Color.Black;
            fFmpegWindow1.BackgroundImage = (Image)resources.GetObject("fFmpegWindow1.BackgroundImage");
            fFmpegWindow1.BackgroundImageLayout = ImageLayout.Stretch;
            fFmpegWindow1.Codec = Enums.Codec.mjpeg;
            fFmpegWindow1.Location = new Point(244, 32);
            fFmpegWindow1.Name = "fFmpegWindow1";
            fFmpegWindow1.OverlayFont = new Font("Arial", 32F, FontStyle.Bold);
            fFmpegWindow1.OverlayLocation = new Point(10, 10);
            fFmpegWindow1.OverlayText = "FFMpeg";
            fFmpegWindow1.Size = new Size(218, 138);
            fFmpegWindow1.SizeMode = PictureBoxSizeMode.StretchImage;
            fFmpegWindow1.TabIndex = 39;
            fFmpegWindow1.TabStop = false;
            // 
            // mortoGraphyWindow1
            // 
            mortoGraphyWindow1.BackgroundImage = (Image)resources.GetObject("mortoGraphyWindow1.BackgroundImage");
            mortoGraphyWindow1.BackgroundImageLayout = ImageLayout.Stretch;
            mortoGraphyWindow1.BufferSize = 409600;
            mortoGraphyWindow1.Location = new Point(244, 196);
            mortoGraphyWindow1.Name = "mortoGraphyWindow1";
            mortoGraphyWindow1.OverlayFont = new Font("Arial", 32F, FontStyle.Bold);
            mortoGraphyWindow1.OverlayLocation = new Point(10, 10);
            mortoGraphyWindow1.OverlayText = "MortoGraphy";
            mortoGraphyWindow1.Password = null;
            mortoGraphyWindow1.Size = new Size(218, 135);
            mortoGraphyWindow1.SizeMode = PictureBoxSizeMode.StretchImage;
            mortoGraphyWindow1.StreamType = Enums.StreamType.Mjpeg;
            mortoGraphyWindow1.TabIndex = 40;
            mortoGraphyWindow1.TabStop = false;
            mortoGraphyWindow1.Username = null;
            // 
            // mtfListView2
            // 
            mtfListView2.AlternatingColorEven = Color.LightBlue;
            mtfListView2.AlternatingColorOdd = SystemColors.Window;
            mtfListView2.AlternatingColorsAreInUse = true;
            mtfListView2.AlternatingPairColorEven = Color.LightSeaGreen;
            mtfListView2.AlternatingPairColorOdd = Color.CadetBlue;
            mtfListView2.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader5 });
            mtfListView2.CompactView = false;
            mtfListView2.EnsureLastItemIsVisible = false;
            mtfListView2.FirstItemIsGray = false;
            mtfListView2.FullRowSelect = true;
            listViewGroup3.Header = "1. Group";
            listViewGroup3.Name = "listViewGroup1";
            listViewGroup4.Header = "2. Group";
            listViewGroup4.Name = "listViewGroup2";
            mtfListView2.Groups.AddRange(new ListViewGroup[] { listViewGroup3, listViewGroup4 });
            listViewItem10.Group = listViewGroup3;
            listViewItem11.Group = listViewGroup4;
            listViewItem12.Group = listViewGroup4;
            mtfListView2.Items.AddRange(new ListViewItem[] { listViewItem10, listViewItem11, listViewItem12 });
            mtfListView2.Location = new Point(707, 11);
            mtfListView2.Name = "mtfListView2";
            mtfListView2.OwnerDraw = true;
            mtfListView2.ReadonlyCheckboxes = false;
            mtfListView2.SameItemsColorEven = Color.DarkOrange;
            mtfListView2.SameItemsColorOdd = Color.LightSalmon;
            mtfListView2.Size = new Size(231, 266);
            mtfListView2.TabIndex = 41;
            mtfListView2.UseCompatibleStateImageBehavior = false;
            mtfListView2.View = View.Details;
            // 
            // columnHeader4
            // 
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Width = 100;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(15, 328);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(75, 23);
            btnExport.TabIndex = 42;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += BtnExportListView_Click;
            // 
            // button5
            // 
            button5.Location = new Point(15, 223);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 43;
            button5.Text = "Export";
            button5.UseVisualStyleBackColor = true;
            button5.Click += BtnExportTreeView_Click;
            // 
            // mtfPictureBox2
            // 
            mtfPictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            mtfPictureBox2.BackgroundPaintDebounceIntervalInMs = 0;
            mtfPictureBox2.Dock = DockStyle.Fill;
            mtfPictureBox2.Image = Properties.Resources.hack_with_me;
            mtfPictureBox2.Location = new Point(3, 3);
            mtfPictureBox2.Name = "mtfPictureBox2";
            mtfPictureBox2.OriginalSize = new Size(1024, 1024);
            mtfPictureBox2.PaintDebounceIntervalInMs = 0;
            mtfPictureBox2.RepositioningAndResizingControlsOnResize = true;
            mtfPictureBox2.ResizeDebounceIntervalInMs = 0;
            mtfPictureBox2.ShowPaintErrors = false;
            mtfPictureBox2.ShowResizeErrors = false;
            mtfPictureBox2.Size = new Size(1580, 826);
            mtfPictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            mtfPictureBox2.TabIndex = 44;
            mtfPictureBox2.TabStop = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Controls.Add(tabPage7);
            tabControl1.Controls.Add(tabPage8);
            tabControl1.Controls.Add(tabPage9);
            tabControl1.Controls.Add(tabPage10);
            tabControl1.Controls.Add(tabPage11);
            tabControl1.Controls.Add(tabPage12);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1594, 860);
            tabControl1.TabIndex = 45;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(mtfListView1);
            tabPage1.Controls.Add(mtfListView2);
            tabPage1.Controls.Add(btnExport);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1586, 832);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "MtfListView";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(mtfTreeView1);
            tabPage2.Controls.Add(button5);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1586, 832);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "MtfTreeView";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(mtfPictureBox2);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1586, 832);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "MtfPictureBox";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(mtfPictureBox1);
            tabPage4.Controls.Add(pictureBox1);
            tabPage4.Controls.Add(button1);
            tabPage4.Controls.Add(rotatableImagePanel1);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1586, 832);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "PictureBox vs MtfPictureBox RotateablePictureBox";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(passwordBox1);
            tabPage5.Controls.Add(button2);
            tabPage5.Controls.Add(textBox2);
            tabPage5.Controls.Add(editableComboBox1);
            tabPage5.Controls.Add(textBoxWithRegEx1);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1586, 832);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "ComboBox & TextBox";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(movablePanel1);
            tabPage6.Controls.Add(movableSizablePanel1);
            tabPage6.Controls.Add(textBox1);
            tabPage6.Controls.Add(transparentPanel1);
            tabPage6.Location = new Point(4, 24);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1586, 832);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Panels";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            tabPage7.Controls.Add(sourceCodeViewerRichTextBox1);
            tabPage7.Location = new Point(4, 24);
            tabPage7.Name = "tabPage7";
            tabPage7.Size = new Size(1586, 832);
            tabPage7.TabIndex = 6;
            tabPage7.Text = "SourceCodeViewerRichTextBox";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            tabPage8.Controls.Add(btnTest);
            tabPage8.Controls.Add(btnMoveCaretToDown);
            tabPage8.Controls.Add(btnMoveCaretToRight);
            tabPage8.Controls.Add(btnMoveCaretToUp);
            tabPage8.Controls.Add(btnMoveCaretToLeft);
            tabPage8.Controls.Add(btnHome);
            tabPage8.Controls.Add(btnAppendToAnsiText);
            tabPage8.Controls.Add(tbAnsiText);
            tabPage8.Controls.Add(chkStrikeout);
            tabPage8.Controls.Add(chkBold);
            tabPage8.Controls.Add(chkItalic);
            tabPage8.Controls.Add(chkUnderline);
            tabPage8.Controls.Add(lblBackColor);
            tabPage8.Controls.Add(pbBackColor);
            tabPage8.Controls.Add(lblFontColor);
            tabPage8.Controls.Add(pbFontColor);
            tabPage8.Controls.Add(ansiColoringRichTextBox1);
            tabPage8.Location = new Point(4, 24);
            tabPage8.Name = "tabPage8";
            tabPage8.Size = new Size(1586, 832);
            tabPage8.TabIndex = 7;
            tabPage8.Text = "AnsiColoringRichTextBox";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            btnTest.Location = new Point(1536, 9);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(42, 23);
            btnTest.TabIndex = 41;
            btnTest.Text = "Test";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += BtnTest_Click;
            // 
            // btnMoveCaretToDown
            // 
            btnMoveCaretToDown.Location = new Point(1455, 9);
            btnMoveCaretToDown.Name = "btnMoveCaretToDown";
            btnMoveCaretToDown.Size = new Size(75, 23);
            btnMoveCaretToDown.TabIndex = 40;
            btnMoveCaretToDown.Text = "To down";
            btnMoveCaretToDown.UseVisualStyleBackColor = true;
            btnMoveCaretToDown.Click += BtnMoveCaretToDown_Click;
            // 
            // btnMoveCaretToRight
            // 
            btnMoveCaretToRight.Location = new Point(1374, 9);
            btnMoveCaretToRight.Name = "btnMoveCaretToRight";
            btnMoveCaretToRight.Size = new Size(75, 23);
            btnMoveCaretToRight.TabIndex = 39;
            btnMoveCaretToRight.Text = "To right";
            btnMoveCaretToRight.UseVisualStyleBackColor = true;
            btnMoveCaretToRight.Click += BtnMoveCaretToRight_Click;
            // 
            // btnMoveCaretToUp
            // 
            btnMoveCaretToUp.Location = new Point(1293, 9);
            btnMoveCaretToUp.Name = "btnMoveCaretToUp";
            btnMoveCaretToUp.Size = new Size(75, 23);
            btnMoveCaretToUp.TabIndex = 38;
            btnMoveCaretToUp.Text = "To up";
            btnMoveCaretToUp.UseVisualStyleBackColor = true;
            btnMoveCaretToUp.Click += BtnMoveCaretToUp_Click;
            // 
            // btnMoveCaretToLeft
            // 
            btnMoveCaretToLeft.Location = new Point(1212, 9);
            btnMoveCaretToLeft.Name = "btnMoveCaretToLeft";
            btnMoveCaretToLeft.Size = new Size(75, 23);
            btnMoveCaretToLeft.TabIndex = 37;
            btnMoveCaretToLeft.Text = "To left";
            btnMoveCaretToLeft.UseVisualStyleBackColor = true;
            btnMoveCaretToLeft.Click += BtnMoveCaretToLeft_Click;
            // 
            // btnHome
            // 
            btnHome.Location = new Point(1131, 9);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(75, 23);
            btnHome.TabIndex = 36;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += BtnHome_Click;
            // 
            // btnAppendToAnsiText
            // 
            btnAppendToAnsiText.Location = new Point(1050, 9);
            btnAppendToAnsiText.Name = "btnAppendToAnsiText";
            btnAppendToAnsiText.Size = new Size(75, 23);
            btnAppendToAnsiText.TabIndex = 35;
            btnAppendToAnsiText.Text = "Append";
            btnAppendToAnsiText.UseVisualStyleBackColor = true;
            btnAppendToAnsiText.Click += BtnAppendToAnsiText_Click;
            // 
            // tbAnsiText
            // 
            tbAnsiText.Location = new Point(593, 11);
            tbAnsiText.Name = "tbAnsiText";
            tbAnsiText.Size = new Size(451, 23);
            tbAnsiText.TabIndex = 34;
            // 
            // chkStrikeout
            // 
            chkStrikeout.AutoSize = true;
            chkStrikeout.Location = new Point(477, 13);
            chkStrikeout.Name = "chkStrikeout";
            chkStrikeout.Size = new Size(73, 19);
            chkStrikeout.TabIndex = 33;
            chkStrikeout.Text = "Strikeout";
            chkStrikeout.UseVisualStyleBackColor = true;
            // 
            // chkBold
            // 
            chkBold.AutoSize = true;
            chkBold.Location = new Point(421, 13);
            chkBold.Name = "chkBold";
            chkBold.Size = new Size(50, 19);
            chkBold.TabIndex = 32;
            chkBold.Text = "Bold";
            chkBold.UseVisualStyleBackColor = true;
            // 
            // chkItalic
            // 
            chkItalic.AutoSize = true;
            chkItalic.Location = new Point(364, 13);
            chkItalic.Name = "chkItalic";
            chkItalic.Size = new Size(51, 19);
            chkItalic.TabIndex = 31;
            chkItalic.Text = "Italic";
            chkItalic.UseVisualStyleBackColor = true;
            // 
            // chkUnderline
            // 
            chkUnderline.AutoSize = true;
            chkUnderline.Location = new Point(281, 13);
            chkUnderline.Name = "chkUnderline";
            chkUnderline.Size = new Size(77, 19);
            chkUnderline.TabIndex = 30;
            chkUnderline.Text = "Underline";
            chkUnderline.UseVisualStyleBackColor = true;
            // 
            // lblBackColor
            // 
            lblBackColor.AutoSize = true;
            lblBackColor.Location = new Point(171, 14);
            lblBackColor.Name = "lblBackColor";
            lblBackColor.Size = new Size(62, 15);
            lblBackColor.TabIndex = 29;
            lblBackColor.Text = "Back color";
            // 
            // pbBackColor
            // 
            pbBackColor.Location = new Point(140, 9);
            pbBackColor.Name = "pbBackColor";
            pbBackColor.Size = new Size(25, 25);
            pbBackColor.TabIndex = 28;
            pbBackColor.TabStop = false;
            pbBackColor.Click += PbBackColor_Click;
            // 
            // lblFontColor
            // 
            lblFontColor.AutoSize = true;
            lblFontColor.Location = new Point(39, 14);
            lblFontColor.Name = "lblFontColor";
            lblFontColor.Size = new Size(61, 15);
            lblFontColor.TabIndex = 27;
            lblFontColor.Text = "Font color";
            // 
            // pbFontColor
            // 
            pbFontColor.Location = new Point(8, 9);
            pbFontColor.Name = "pbFontColor";
            pbFontColor.Size = new Size(25, 25);
            pbFontColor.TabIndex = 26;
            pbFontColor.TabStop = false;
            pbFontColor.Click += PbFontColor_Click;
            // 
            // tabPage9
            // 
            tabPage9.Controls.Add(richTextBoxWithLineNumbers1);
            tabPage9.Location = new Point(4, 24);
            tabPage9.Name = "tabPage9";
            tabPage9.Size = new Size(1586, 832);
            tabPage9.TabIndex = 8;
            tabPage9.Text = "RichTextBoxWithLineNumbers";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            tabPage10.Controls.Add(fileBrowserView1);
            tabPage10.Location = new Point(4, 24);
            tabPage10.Name = "tabPage10";
            tabPage10.Size = new Size(1586, 832);
            tabPage10.TabIndex = 9;
            tabPage10.Text = "FileBrowserView";
            tabPage10.UseVisualStyleBackColor = true;
            // 
            // tabPage11
            // 
            tabPage11.Controls.Add(sunellVideoWindow1);
            tabPage11.Controls.Add(tbSunellIpr67Ip);
            tabPage11.Controls.Add(lblSunellIpr67Ip);
            tabPage11.Controls.Add(lblSunellPassword);
            tabPage11.Controls.Add(lblSunellUsername);
            tabPage11.Controls.Add(lblSunellIpr66Ip);
            tabPage11.Controls.Add(tbSunellPassword);
            tabPage11.Controls.Add(tbSunellUsername);
            tabPage11.Controls.Add(tbSunellIpr66Ip);
            tabPage11.Controls.Add(chkSunellIpr67);
            tabPage11.Controls.Add(chkSunellIpr66);
            tabPage11.Controls.Add(sunellVideoWindowLegacy1);
            tabPage11.Controls.Add(chkMortoGraphyWindow);
            tabPage11.Controls.Add(chkOpenCvSharp4Video);
            tabPage11.Controls.Add(chkFFMpegVideo);
            tabPage11.Controls.Add(chkVlcVideo);
            tabPage11.Controls.Add(tbUrl);
            tabPage11.Controls.Add(openCvSharp4VideoWindow1);
            tabPage11.Controls.Add(pictureBox3);
            tabPage11.Controls.Add(button3);
            tabPage11.Controls.Add(pictureBox2);
            tabPage11.Controls.Add(fFmpegWindow1);
            tabPage11.Controls.Add(mortoGraphyWindow1);
            tabPage11.Controls.Add(vlcWindow1);
            tabPage11.Controls.Add(button7);
            tabPage11.Location = new Point(4, 24);
            tabPage11.Name = "tabPage11";
            tabPage11.Size = new Size(1586, 832);
            tabPage11.TabIndex = 10;
            tabPage11.Text = "Video";
            tabPage11.UseVisualStyleBackColor = true;
            // 
            // tbSunellIpr67Ip
            // 
            tbSunellIpr67Ip.Location = new Point(703, 82);
            tbSunellIpr67Ip.Name = "tbSunellIpr67Ip";
            tbSunellIpr67Ip.Size = new Size(100, 23);
            tbSunellIpr67Ip.TabIndex = 61;
            tbSunellIpr67Ip.Text = "192.168.0.202";
            // 
            // lblSunellIpr67Ip
            // 
            lblSunellIpr67Ip.AutoSize = true;
            lblSunellIpr67Ip.Location = new Point(703, 64);
            lblSunellIpr67Ip.Name = "lblSunellIpr67Ip";
            lblSunellIpr67Ip.Size = new Size(84, 15);
            lblSunellIpr67Ip.TabIndex = 60;
            lblSunellIpr67Ip.Text = "Sunell IPR67 IP";
            // 
            // lblSunellPassword
            // 
            lblSunellPassword.AutoSize = true;
            lblSunellPassword.Location = new Point(703, 166);
            lblSunellPassword.Name = "lblSunellPassword";
            lblSunellPassword.Size = new Size(92, 15);
            lblSunellPassword.TabIndex = 59;
            lblSunellPassword.Text = "Sunell password";
            // 
            // lblSunellUsername
            // 
            lblSunellUsername.AutoSize = true;
            lblSunellUsername.Location = new Point(703, 113);
            lblSunellUsername.Name = "lblSunellUsername";
            lblSunellUsername.Size = new Size(94, 15);
            lblSunellUsername.TabIndex = 58;
            lblSunellUsername.Text = "Sunell username";
            // 
            // lblSunellIpr66Ip
            // 
            lblSunellIpr66Ip.AutoSize = true;
            lblSunellIpr66Ip.Location = new Point(703, 14);
            lblSunellIpr66Ip.Name = "lblSunellIpr66Ip";
            lblSunellIpr66Ip.Size = new Size(84, 15);
            lblSunellIpr66Ip.TabIndex = 57;
            lblSunellIpr66Ip.Text = "Sunell IPR66 IP";
            // 
            // tbSunellPassword
            // 
            tbSunellPassword.Location = new Point(703, 188);
            tbSunellPassword.Name = "tbSunellPassword";
            tbSunellPassword.Size = new Size(100, 23);
            tbSunellPassword.TabIndex = 56;
            tbSunellPassword.Text = "Tibi2025";
            // 
            // tbSunellUsername
            // 
            tbSunellUsername.Location = new Point(703, 131);
            tbSunellUsername.Name = "tbSunellUsername";
            tbSunellUsername.Size = new Size(100, 23);
            tbSunellUsername.TabIndex = 55;
            tbSunellUsername.Text = "admin";
            // 
            // tbSunellIpr66Ip
            // 
            tbSunellIpr66Ip.Location = new Point(703, 35);
            tbSunellIpr66Ip.Name = "tbSunellIpr66Ip";
            tbSunellIpr66Ip.Size = new Size(100, 23);
            tbSunellIpr66Ip.TabIndex = 54;
            tbSunellIpr66Ip.Text = "192.168.0.201";
            // 
            // chkSunellIpr67
            // 
            chkSunellIpr67.AutoSize = true;
            chkSunellIpr67.Checked = true;
            chkSunellIpr67.CheckState = CheckState.Checked;
            chkSunellIpr67.Location = new Point(468, 174);
            chkSunellIpr67.Name = "chkSunellIpr67";
            chkSunellIpr67.Size = new Size(90, 19);
            chkSunellIpr67.TabIndex = 53;
            chkSunellIpr67.Text = "Sunell IPR67";
            chkSunellIpr67.UseVisualStyleBackColor = true;
            // 
            // chkSunellIpr66
            // 
            chkSunellIpr66.AutoSize = true;
            chkSunellIpr66.Checked = true;
            chkSunellIpr66.CheckState = CheckState.Checked;
            chkSunellIpr66.Location = new Point(468, 10);
            chkSunellIpr66.Name = "chkSunellIpr66";
            chkSunellIpr66.Size = new Size(90, 19);
            chkSunellIpr66.TabIndex = 51;
            chkSunellIpr66.Text = "Sunell IPR66";
            chkSunellIpr66.UseVisualStyleBackColor = true;
            // 
            // sunellVideoWindowLegacy1
            // 
            sunellVideoWindowLegacy1.BackgroundImageLayout = ImageLayout.Stretch;
            sunellVideoWindowLegacy1.Image = (Image)resources.GetObject("sunellVideoWindowLegacy1.Image");
            sunellVideoWindowLegacy1.Location = new Point(468, 30);
            sunellVideoWindowLegacy1.Name = "sunellVideoWindowLegacy1";
            sunellVideoWindowLegacy1.OverlayBackgroundColor = Color.Black;
            sunellVideoWindowLegacy1.OverlayFont = new Font("Arial", 32F, FontStyle.Bold);
            sunellVideoWindowLegacy1.OverlayLocation = new Point(10, 10);
            sunellVideoWindowLegacy1.OverlayText = "Sunell IPR66";
            sunellVideoWindowLegacy1.Size = new Size(218, 138);
            sunellVideoWindowLegacy1.SizeMode = PictureBoxSizeMode.StretchImage;
            sunellVideoWindowLegacy1.TabIndex = 46;
            sunellVideoWindowLegacy1.TabStop = false;
            // 
            // chkMortoGraphyWindow
            // 
            chkMortoGraphyWindow.AutoSize = true;
            chkMortoGraphyWindow.Location = new Point(244, 174);
            chkMortoGraphyWindow.Name = "chkMortoGraphyWindow";
            chkMortoGraphyWindow.Size = new Size(97, 19);
            chkMortoGraphyWindow.TabIndex = 45;
            chkMortoGraphyWindow.Text = "MortoGraphy";
            chkMortoGraphyWindow.UseVisualStyleBackColor = true;
            // 
            // chkOpenCvSharp4Video
            // 
            chkOpenCvSharp4Video.AutoSize = true;
            chkOpenCvSharp4Video.Location = new Point(20, 174);
            chkOpenCvSharp4Video.Name = "chkOpenCvSharp4Video";
            chkOpenCvSharp4Video.Size = new Size(111, 19);
            chkOpenCvSharp4Video.TabIndex = 44;
            chkOpenCvSharp4Video.Text = "Open Cv Sharp4";
            chkOpenCvSharp4Video.UseVisualStyleBackColor = true;
            // 
            // chkFFMpegVideo
            // 
            chkFFMpegVideo.AutoSize = true;
            chkFFMpegVideo.Location = new Point(244, 10);
            chkFFMpegVideo.Name = "chkFFMpegVideo";
            chkFFMpegVideo.Size = new Size(69, 19);
            chkFFMpegVideo.TabIndex = 43;
            chkFFMpegVideo.Text = "FFMpeg";
            chkFFMpegVideo.UseVisualStyleBackColor = true;
            // 
            // chkVlcVideo
            // 
            chkVlcVideo.AutoSize = true;
            chkVlcVideo.Location = new Point(20, 10);
            chkVlcVideo.Name = "chkVlcVideo";
            chkVlcVideo.Size = new Size(47, 19);
            chkVlcVideo.TabIndex = 42;
            chkVlcVideo.Text = "VLC";
            chkVlcVideo.UseVisualStyleBackColor = true;
            // 
            // tbUrl
            // 
            tbUrl.Location = new Point(20, 371);
            tbUrl.Name = "tbUrl";
            tbUrl.Size = new Size(442, 23);
            tbUrl.TabIndex = 41;
            tbUrl.Text = "http://admin:Tibi2025@192.168.0.17/videostream.cgi";
            // 
            // tabPage12
            // 
            tabPage12.Controls.Add(kbd300aSimulator1);
            tabPage12.Controls.Add(richTextBox1);
            tabPage12.Location = new Point(4, 24);
            tabPage12.Name = "tabPage12";
            tabPage12.Size = new Size(1586, 832);
            tabPage12.TabIndex = 11;
            tabPage12.Text = "KDB300 Simulator";
            tabPage12.UseVisualStyleBackColor = true;
            // 
            // kbd300aSimulator1
            // 
            kbd300aSimulator1.BackgroundPaintDebounceIntervalInMs = 0;
            kbd300aSimulator1.Dock = DockStyle.Fill;
            kbd300aSimulator1.Image = (Image)resources.GetObject("kbd300aSimulator1.Image");
            kbd300aSimulator1.Location = new Point(0, 0);
            kbd300aSimulator1.Name = "kbd300aSimulator1";
            kbd300aSimulator1.OriginalSize = new Size(675, 425);
            kbd300aSimulator1.PaintDebounceIntervalInMs = 0;
            kbd300aSimulator1.PipeName = null;
            kbd300aSimulator1.RepositioningAndResizingControlsOnResize = true;
            kbd300aSimulator1.ResizeDebounceIntervalInMs = 200;
            kbd300aSimulator1.Shift = false;
            kbd300aSimulator1.ShowPaintErrors = false;
            kbd300aSimulator1.ShowResizeErrors = false;
            kbd300aSimulator1.Size = new Size(1586, 832);
            kbd300aSimulator1.SizeMode = PictureBoxSizeMode.Zoom;
            kbd300aSimulator1.TabIndex = 0;
            kbd300aSimulator1.TabStop = false;
            // 
            // colorDialog
            // 
            colorDialog.AllowFullOpen = false;
            // 
            // sunellVideoWindow1
            // 
            sunellVideoWindow1.BackgroundImage = (Image)resources.GetObject("sunellVideoWindow1.BackgroundImage");
            sunellVideoWindow1.BackgroundImageLayout = ImageLayout.Stretch;
            sunellVideoWindow1.Location = new Point(468, 196);
            sunellVideoWindow1.Name = "sunellVideoWindow1";
            sunellVideoWindow1.OverlayBackgroundColor = Color.White;
            sunellVideoWindow1.OverlayFont = new Font("Arial", 32F, FontStyle.Bold);
            sunellVideoWindow1.OverlayLocation = new Point(10, 10);
            sunellVideoWindow1.OverlayText = "";
            sunellVideoWindow1.Size = new Size(218, 135);
            sunellVideoWindow1.SizeMode = PictureBoxSizeMode.StretchImage;
            sunellVideoWindow1.TabIndex = 62;
            sunellVideoWindow1.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(1594, 860);
            Controls.Add(tabControl1);
            Controls.Add(label5);
            Controls.Add(label4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            FormClosing += MainForm_FormClosing;
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
            ((System.ComponentModel.ISupportInitialize)openCvSharp4VideoWindow1).EndInit();
            ((System.ComponentModel.ISupportInitialize)vlcWindow1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fFmpegWindow1).EndInit();
            ((System.ComponentModel.ISupportInitialize)mortoGraphyWindow1).EndInit();
            ((System.ComponentModel.ISupportInitialize)mtfPictureBox2).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            tabPage6.ResumeLayout(false);
            tabPage6.PerformLayout();
            tabPage7.ResumeLayout(false);
            tabPage8.ResumeLayout(false);
            tabPage8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbBackColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFontColor).EndInit();
            tabPage9.ResumeLayout(false);
            tabPage10.ResumeLayout(false);
            tabPage11.ResumeLayout(false);
            tabPage11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sunellVideoWindowLegacy1).EndInit();
            tabPage12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)kbd300aSimulator1).EndInit();
            ((System.ComponentModel.ISupportInitialize)sunellVideoWindow1).EndInit();
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
        private AnsiColoringRichTextBox ansiColoringRichTextBox1;
        private ImageList imageList;
        private TextBoxWithRegEx textBoxWithRegEx1;
        private RichTextBoxWithLineNumbers richTextBoxWithLineNumbers1;
        private RotatableImagePanel rotatableImagePanel1;
        private EditableComboBox editableComboBox1;
        private Button button3;
        private Video.OpenCvSharp.OpenCvSharp4VideoWindow openCvSharp4VideoWindow1;
        private Button button7;
        private Video.VLC.VlcWindow vlcWindow1;
        private Video.FFmpeg.FFmpegWindow fFmpegWindow1;
        private Video.MortoGraphyWindow mortoGraphyWindow1;
        private MtfListView mtfListView2;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button btnExport;
        private Button button5;
        private MtfPictureBox mtfPictureBox2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private TabPage tabPage10;
        private TabPage tabPage11;
        private TabPage tabPage12;
        private TextBox tbUrl;
        private CheckBox chkMortoGraphyWindow;
        private CheckBox chkOpenCvSharp4Video;
        private CheckBox chkFFMpegVideo;
        private CheckBox chkVlcVideo;
        private CheckBox chkStrikeout;
        private CheckBox chkBold;
        private CheckBox chkItalic;
        private CheckBox chkUnderline;
        private Label lblBackColor;
        private PictureBox pbBackColor;
        private Label lblFontColor;
        private PictureBox pbFontColor;
        private ColorDialog colorDialog;
        private TextBox tbAnsiText;
        private Button btnAppendToAnsiText;
        private Button btnHome;
        private Button btnMoveCaretToLeft;
        private Button btnMoveCaretToDown;
        private Button btnMoveCaretToRight;
        private Button btnMoveCaretToUp;
        private Button btnTest;
        private Video.Sunell.IPR66.SunellVideoWindowLegacy sunellVideoWindowLegacy1;
        private CheckBox chkSunellIpr67;
        private CheckBox chkSunellIpr66;
        private TextBox textBox3;
        private TextBox tbSunellIpr66Ip;
        private Label lblSunellUsername;
        private Label lblSunellPassword;
        private Label lblSunellIpr66Ip;
        private TextBox tbSunellUsername;
        private TextBox tbSunellPassword;
        private TextBox tbSunellIpr67Ip;
        private Label lblSunellIpr67Ip;
        private Video.Sunell.IPR67.SunellVideoWindow sunellVideoWindow1;
    }
}
