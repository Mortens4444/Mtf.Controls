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
            var treeNode1 = new TreeNode("Node0", -2, -2);
            var treeNode2 = new TreeNode("Node4", 0, 0);
            var treeNode3 = new TreeNode("Node5", 0, 0);
            var treeNode4 = new TreeNode("Node7", 1, 1);
            var treeNode5 = new TreeNode("Node8", 1, 1);
            var treeNode6 = new TreeNode("Node9", 1, 1);
            var treeNode7 = new TreeNode("Node6", 0, 0, new TreeNode[] { treeNode4, treeNode5, treeNode6 });
            var treeNode8 = new TreeNode("Node1", -2, -2, new TreeNode[] { treeNode2, treeNode3, treeNode7 });
            var treeNode9 = new TreeNode("Node2", -2, -2);
            var treeNode10 = new TreeNode("Node3", -2, -2);
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            var listViewItem7 = new ListViewItem(new string[] { "..", "Parent Directory" }, "up");
            var listViewGroup3 = new ListViewGroup("1. Group", HorizontalAlignment.Left);
            var listViewGroup4 = new ListViewGroup("2. Group", HorizontalAlignment.Left);
            var listViewItem8 = new ListViewItem("1");
            var listViewItem9 = new ListViewItem("2");
            var listViewItem10 = new ListViewItem("3");
            mtfListView1 = new MtfListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            mtfTreeView1 = new MtfTreeView();
            imageList1 = new ImageList(components);
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
            openCvSharp4VideoWindow1 = new Mtf.Controls.Video.OpenCvSharp4VideoWindow();
            button7 = new Button();
            vlcWindow1 = new Mtf.Controls.Video.VlcWindow();
            fFmpegWindow1 = new Mtf.Controls.Video.FFmpegWindow();
            mortoGraphyWindow1 = new Mtf.Controls.Video.MortoGraphyWindow();
            mtfListView2 = new MtfListView();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            button4 = new Button();
            button5 = new Button();
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
            mtfTreeView1.ImageList = imageList1;
            mtfTreeView1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            mtfTreeView1.Location = new Point(262, 7);
            mtfTreeView1.MultiSelect = false;
            mtfTreeView1.Name = "mtfTreeView1";
            treeNode1.ImageIndex = -2;
            treeNode1.Name = "Node0";
            treeNode1.SelectedImageIndex = -2;
            treeNode1.Text = "Node0";
            treeNode2.ImageIndex = 0;
            treeNode2.Name = "Node4";
            treeNode2.SelectedImageIndex = 0;
            treeNode2.Text = "Node4";
            treeNode3.ImageIndex = 0;
            treeNode3.Name = "Node5";
            treeNode3.SelectedImageIndex = 0;
            treeNode3.Text = "Node5";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "Node7";
            treeNode4.SelectedImageIndex = 1;
            treeNode4.Text = "Node7";
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
            treeNode8.ImageIndex = -2;
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
            mtfTreeView1.Size = new Size(224, 283);
            mtfTreeView1.StateImageOrCheckBoxOnLeft = false;
            mtfTreeView1.TabIndex = 1;
            mtfTreeView1.TickColor = Color.Green;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "add_group.ico");
            imageList1.Images.SetKeyName(1, "add_user.ico");
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
            pictureBox3.Image = Properties.Resources.hack_with_me;
            pictureBox3.Location = new Point(248, 459);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(230, 225);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 19;
            pictureBox3.TabStop = false;
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
            listViewItem7.Tag = "up";
            fileBrowserView1.Items.AddRange(new ListViewItem[] { listViewItem7 });
            fileBrowserView1.Location = new Point(1089, 7);
            fileBrowserView1.Name = "fileBrowserView1";
            fileBrowserView1.Size = new Size(413, 115);
            fileBrowserView1.TabIndex = 21;
            fileBrowserView1.UseCompatibleStateImageBehavior = false;
            fileBrowserView1.View = View.Details;
            fileBrowserView1.WorkingDirectory = "C:\\Temp";
            // 
            // passwordBox1
            // 
            passwordBox1.Location = new Point(492, 321);
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
            // ansiColoringRichTextBox1
            // 
            ansiColoringRichTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ansiColoringRichTextBox1.DisplayAnsiColors = true;
            ansiColoringRichTextBox1.Location = new Point(1391, 430);
            ansiColoringRichTextBox1.Name = "ansiColoringRichTextBox1";
            ansiColoringRichTextBox1.Size = new Size(200, 418);
            ansiColoringRichTextBox1.TabIndex = 25;
            ansiColoringRichTextBox1.Text = "";
            // 
            // textBoxWithRegEx1
            // 
            textBoxWithRegEx1.AcceptColor = Color.LightGreen;
            textBoxWithRegEx1.DisplayErrorOnLeft = false;
            textBoxWithRegEx1.ErrorMessage = "The given text not macthing the regex.";
            textBoxWithRegEx1.Location = new Point(1230, 340);
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
            richTextBoxWithLineNumbers1.EmbeddedContextMenuStrip = true;
            richTextBoxWithLineNumbers1.Location = new Point(1090, 128);
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
            richTextBoxWithLineNumbers1.Size = new Size(412, 162);
            richTextBoxWithLineNumbers1.TabIndex = 27;
            richTextBoxWithLineNumbers1.WrapLines = false;
            // 
            // rotatableImagePanel1
            // 
            rotatableImagePanel1.BackgroundImage = Properties.Resources.kertmester;
            rotatableImagePanel1.BackgroundImageLayout = ImageLayout.Stretch;
            rotatableImagePanel1.CanMove = true;
            rotatableImagePanel1.CanSize = true;
            rotatableImagePanel1.Location = new Point(1090, 296);
            rotatableImagePanel1.Name = "rotatableImagePanel1";
            rotatableImagePanel1.RotatingMouseButton = MouseButtons.Middle;
            rotatableImagePanel1.Rotation = null;
            rotatableImagePanel1.Size = new Size(69, 67);
            rotatableImagePanel1.TabIndex = 28;
            rotatableImagePanel1.TransparentColor = Color.Black;
            rotatableImagePanel1.UseTransparentColor = false;
            // 
            // editableComboBox1
            // 
            editableComboBox1.FormattingEnabled = true;
            editableComboBox1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7" });
            editableComboBox1.Location = new Point(1230, 302);
            editableComboBox1.Name = "editableComboBox1";
            editableComboBox1.Size = new Size(121, 23);
            editableComboBox1.TabIndex = 29;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.Control;
            button3.Location = new Point(12, 828);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 31;
            button3.Text = "Start";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // openCvSharp4VideoWindow1
            // 
            openCvSharp4VideoWindow1.BackgroundImage = (Image)resources.GetObject("openCvSharp4VideoWindow1.BackgroundImage");
            openCvSharp4VideoWindow1.BackgroundImageLayout = ImageLayout.Stretch;
            openCvSharp4VideoWindow1.Location = new Point(12, 690);
            openCvSharp4VideoWindow1.Name = "openCvSharp4VideoWindow1";
            openCvSharp4VideoWindow1.Size = new Size(230, 135);
            openCvSharp4VideoWindow1.SizeMode = PictureBoxSizeMode.StretchImage;
            openCvSharp4VideoWindow1.TabIndex = 32;
            openCvSharp4VideoWindow1.TabStop = false;
            // 
            // button7
            // 
            button7.Location = new Point(93, 828);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 36;
            button7.Text = "Stop";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // vlcWindow1
            // 
            vlcWindow1.BackColor = Color.Black;
            vlcWindow1.BackgroundImage = (Image)resources.GetObject("vlcWindow1.BackgroundImage");
            vlcWindow1.BackgroundImageLayout = ImageLayout.Stretch;
            vlcWindow1.Location = new Point(747, 446);
            vlcWindow1.MediaPlayer = null;
            vlcWindow1.Name = "vlcWindow1";
            vlcWindow1.Size = new Size(218, 138);
            vlcWindow1.TabIndex = 38;
            vlcWindow1.Text = "vlcWindow1";
            // 
            // fFmpegWindow1
            // 
            fFmpegWindow1.BackColor = Color.Black;
            fFmpegWindow1.BackgroundImage = (Image)resources.GetObject("fFmpegWindow1.BackgroundImage");
            fFmpegWindow1.BackgroundImageLayout = ImageLayout.Stretch;
            fFmpegWindow1.Codec = "mjpeg";
            fFmpegWindow1.Location = new Point(747, 590);
            fFmpegWindow1.Name = "fFmpegWindow1";
            fFmpegWindow1.Size = new Size(218, 138);
            fFmpegWindow1.SizeMode = PictureBoxSizeMode.StretchImage;
            fFmpegWindow1.TabIndex = 39;
            fFmpegWindow1.TabStop = false;
            // 
            // mortoGraphyWindow1
            // 
            mortoGraphyWindow1.BackgroundImage = (Image)resources.GetObject("mortoGraphyWindow1.BackgroundImage");
            mortoGraphyWindow1.BackgroundImageLayout = ImageLayout.Stretch;
            mortoGraphyWindow1.Location = new Point(248, 690);
            mortoGraphyWindow1.Name = "mortoGraphyWindow1";
            mortoGraphyWindow1.Password = null;
            mortoGraphyWindow1.Size = new Size(230, 135);
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
            listViewItem8.Group = listViewGroup3;
            listViewItem9.Group = listViewGroup4;
            listViewItem10.Group = listViewGroup4;
            mtfListView2.Items.AddRange(new ListViewItem[] { listViewItem8, listViewItem9, listViewItem10 });
            mtfListView2.Location = new Point(1002, 526);
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
            // button4
            // 
            button4.Location = new Point(19, 258);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 42;
            button4.Text = "Export";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(272, 258);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 43;
            button5.Text = "Export";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(1594, 860);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(mtfListView2);
            Controls.Add(mortoGraphyWindow1);
            Controls.Add(fFmpegWindow1);
            Controls.Add(vlcWindow1);
            Controls.Add(button7);
            Controls.Add(openCvSharp4VideoWindow1);
            Controls.Add(button3);
            Controls.Add(editableComboBox1);
            Controls.Add(rotatableImagePanel1);
            Controls.Add(richTextBoxWithLineNumbers1);
            Controls.Add(textBoxWithRegEx1);
            Controls.Add(ansiColoringRichTextBox1);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(passwordBox1);
            Controls.Add(fileBrowserView1);
            Controls.Add(richTextBox1);
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
            ((System.ComponentModel.ISupportInitialize)openCvSharp4VideoWindow1).EndInit();
            ((System.ComponentModel.ISupportInitialize)vlcWindow1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fFmpegWindow1).EndInit();
            ((System.ComponentModel.ISupportInitialize)mortoGraphyWindow1).EndInit();
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
        private ImageList imageList1;
        private TextBoxWithRegEx textBoxWithRegEx1;
        private RichTextBoxWithLineNumbers richTextBoxWithLineNumbers1;
        private RotatableImagePanel rotatableImagePanel1;
        private EditableComboBox editableComboBox1;
        private Button button3;
        private Video.OpenCvSharp4VideoWindow openCvSharp4VideoWindow1;
        private Button button7;
        private Video.VlcWindow vlcWindow1;
        private Video.FFmpegWindow fFmpegWindow1;
        private Video.MortoGraphyWindow mortoGraphyWindow1;
        private MtfListView mtfListView2;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button button4;
        private Button button5;
    }
}
