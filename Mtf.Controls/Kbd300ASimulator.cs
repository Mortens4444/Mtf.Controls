using Mtf.Controls.Services;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mtf.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MovablePanel), "Resources.Kbd300ASimulator.png")]

    public class Kbd300ASimulator : MtfPictureBox
    {
        private readonly TrackBar tb_MoveValue;
        private readonly Panel p_LED;
        private readonly Button btn_ZoomOut;
        private readonly Button btn_ZoomIn;
        private readonly Button btn_RigthDown;
        private readonly Button btn_LeftDown;
        private readonly Button btn_RightUp;
        private readonly Button btn_LeftUp;
        private readonly Button btn_Down;
        private readonly Button btn_Up;
        private readonly Button btn_Right;
        private readonly Button btn_Left;
        private readonly Button btn_Close;
        private readonly Button btn_Open;
        private readonly Button btn_Far;
        private readonly Button btn_Near;
        private readonly Button btn_AuxOff;
        private readonly Button btn_AuxOn;
        private readonly Button btn_F3_Mom;
        private readonly Button btn_F2_Off;
        private readonly Button btn_F1_Latch;
        private readonly Button btn_Shift;
        private readonly Button btn_Pgm;
        private readonly Button btn_Macro;
        private readonly Button btn_Preset;
        private readonly Button btn_Pattern;
        private readonly Button btn_Hold;
        private readonly Button btn_Next;
        private readonly Button btn_Prev;
        private readonly Button btn_Ack;
        private readonly Button btn_Mon;
        private readonly Button btn_Clear;
        private readonly Button btn_0;
        private readonly Button btn_Cam;
        private readonly Button btn_9;
        private readonly Button btn_8;
        private readonly Button btn_7;
        private readonly Button btn_6;
        private readonly Button btn_5;
        private readonly Button btn_4;
        private readonly Button btn_3;
        private readonly Button btn_2;
        private readonly Button btn_1;
        private int move;
        private ImageList il_Images;
        private IContainer components;
        private StringBuilder number;

        protected bool disposed;

        public event EventHandler CameraWindowClosed;

        // 7 on, others off
        public Kbd300ASimulator()
        {
            InitializeComponent();

            tb_MoveValue = new TrackBar();
            p_LED = new Panel();
            btn_ZoomOut = new Button();
            btn_ZoomIn = new Button();
            btn_RigthDown = new Button();
            btn_LeftDown = new Button();
            btn_RightUp = new Button();
            btn_LeftUp = new Button();
            btn_Down = new Button();
            btn_Up = new Button();
            btn_Right = new Button();
            btn_Left = new Button();
            btn_Close = new Button();
            btn_Open = new Button();
            btn_Far = new Button();
            btn_Near = new Button();
            btn_AuxOff = new Button();
            btn_AuxOn = new Button();
            btn_F3_Mom = new Button();
            btn_F2_Off = new Button();
            btn_F1_Latch = new Button();
            btn_Shift = new Button();
            btn_Pgm = new Button();
            btn_Macro = new Button();
            btn_Preset = new Button();
            btn_Pattern = new Button();
            btn_Hold = new Button();
            btn_Next = new Button();
            btn_Prev = new Button();
            btn_Ack = new Button();
            btn_Mon = new Button();
            btn_Clear = new Button();
            btn_0 = new Button();
            btn_Cam = new Button();
            btn_9 = new Button();
            btn_8 = new Button();
            btn_7 = new Button();
            btn_6 = new Button();
            btn_5 = new Button();
            btn_4 = new Button();
            btn_3 = new Button();
            btn_2 = new Button();
            btn_1 = new Button();
            // 
            // tb_MoveValue
            // 
            tb_MoveValue.BackColor = Color.White;
            tb_MoveValue.Location = new Point(487, 304);
            tb_MoveValue.Maximum = 63;
            tb_MoveValue.Minimum = 1;
            tb_MoveValue.Name = "tb_MoveValue";
            tb_MoveValue.Size = new Size(112, 42);
            tb_MoveValue.TabIndex = 86;
            tb_MoveValue.Value = 40;
            tb_MoveValue.Scroll += Tb_MoveValue_Scroll;
            // 
            // p_LED
            // 
            p_LED.BackColor = Color.White;
            p_LED.Location = new Point(78, 51);
            p_LED.Name = "p_LED";
            p_LED.BackgroundImageLayout = ImageLayout.Zoom;
            p_LED.BackgroundImage = il_Images.Images[0];
            p_LED.Size = new Size(48, 38);
            p_LED.TabIndex = 71;
            // 
            // btn_ZoomOut
            // 
            btn_ZoomOut.BackColor = Color.White;
            btn_ZoomOut.FlatStyle = FlatStyle.Popup;
            btn_ZoomOut.Location = new Point(518, 232);
            btn_ZoomOut.Name = "Btn_ZoomOut";
            btn_ZoomOut.Size = new Size(19, 19);
            btn_ZoomOut.TabIndex = 85;
            btn_ZoomOut.Text = "-";
            btn_ZoomOut.UseVisualStyleBackColor = false;
            btn_ZoomOut.MouseDown += Btn_ZoomOut_MouseDown;
            btn_ZoomOut.MouseUp += Btn_ZoomOut_MouseUp;
            // 
            // btn_ZoomIn
            // 
            btn_ZoomIn.BackColor = Color.White;
            btn_ZoomIn.FlatStyle = FlatStyle.Popup;
            btn_ZoomIn.Location = new Point(549, 232);
            btn_ZoomIn.Name = "Btn_ZoomIn";
            btn_ZoomIn.Size = new Size(19, 19);
            btn_ZoomIn.TabIndex = 84;
            btn_ZoomIn.Text = "+";
            btn_ZoomIn.UseVisualStyleBackColor = false;
            btn_ZoomIn.MouseDown += Btn_ZoomIn_MouseDown;
            btn_ZoomIn.MouseUp += Btn_ZoomIn_MouseUp;
            // 
            // btn_RigthDown
            // 
            btn_RigthDown.BackColor = Color.White;
            btn_RigthDown.FlatStyle = FlatStyle.Popup;
            btn_RigthDown.Location = new Point(567, 263);
            btn_RigthDown.Name = "Btn_RigthDown";
            btn_RigthDown.Size = new Size(19, 19);
            btn_RigthDown.TabIndex = 83;
            btn_RigthDown.UseVisualStyleBackColor = false;
            btn_RigthDown.MouseDown += Btn_RigthDown_MouseDown;
            btn_RigthDown.MouseUp += Btn_RigthDown_MouseUp;
            // 
            // btn_LeftDown
            // 
            btn_LeftDown.BackColor = Color.White;
            btn_LeftDown.FlatStyle = FlatStyle.Popup;
            btn_LeftDown.Location = new Point(498, 263);
            btn_LeftDown.Name = "Btn_LeftDown";
            btn_LeftDown.Size = new Size(19, 19);
            btn_LeftDown.TabIndex = 82;
            btn_LeftDown.UseVisualStyleBackColor = false;
            btn_LeftDown.MouseDown += Btn_LeftDown_MouseDown;
            btn_LeftDown.MouseUp += Btn_LeftDown_MouseUp;
            // 
            // btn_RightUp
            // 
            btn_RightUp.BackColor = Color.White;
            btn_RightUp.FlatStyle = FlatStyle.Popup;
            btn_RightUp.Location = new Point(567, 200);
            btn_RightUp.Name = "Btn_RightUp";
            btn_RightUp.Size = new Size(19, 19);
            btn_RightUp.TabIndex = 81;
            btn_RightUp.UseVisualStyleBackColor = false;
            btn_RightUp.MouseDown += Btn_RightUp_MouseDown;
            btn_RightUp.MouseUp += Btn_RightUp_MouseUp;
            // 
            // btn_LeftUp
            // 
            btn_LeftUp.BackColor = Color.White;
            btn_LeftUp.FlatStyle = FlatStyle.Popup;
            btn_LeftUp.Location = new Point(498, 200);
            btn_LeftUp.Name = "Btn_LeftUp";
            btn_LeftUp.Size = new Size(19, 19);
            btn_LeftUp.TabIndex = 80;
            btn_LeftUp.UseVisualStyleBackColor = false;
            btn_LeftUp.MouseDown += Btn_LeftUp_MouseDown;
            btn_LeftUp.MouseUp += Btn_LeftUp_MouseUp;
            // 
            // btn_Down
            // 
            btn_Down.BackColor = Color.White;
            btn_Down.FlatStyle = FlatStyle.Popup;
            btn_Down.Location = new Point(534, 280);
            btn_Down.Name = "Btn_Down";
            btn_Down.Size = new Size(19, 19);
            btn_Down.TabIndex = 79;
            btn_Down.UseVisualStyleBackColor = false;
            btn_Down.MouseDown += Btn_Down_MouseDown;
            btn_Down.MouseUp += Btn_Down_MouseUp;
            // 
            // btn_Up
            // 
            btn_Up.BackColor = Color.White;
            btn_Up.FlatStyle = FlatStyle.Popup;
            btn_Up.Location = new Point(534, 186);
            btn_Up.Name = "Btn_Up";
            btn_Up.Size = new Size(19, 19);
            btn_Up.TabIndex = 78;
            btn_Up.UseVisualStyleBackColor = false;
            btn_Up.MouseDown += Btn_Up_MouseDown;
            btn_Up.MouseUp += Btn_Up_MouseUp;
            // 
            // btn_Right
            // 
            btn_Right.BackColor = Color.White;
            btn_Right.FlatStyle = FlatStyle.Popup;
            btn_Right.Location = new Point(581, 232);
            btn_Right.Name = "Btn_Right";
            btn_Right.Size = new Size(19, 19);
            btn_Right.TabIndex = 77;
            btn_Right.UseVisualStyleBackColor = false;
            btn_Right.MouseDown += Btn_Right_MouseDown;
            btn_Right.MouseUp += Btn_Right_MouseUp;
            // 
            // btn_Left
            // 
            btn_Left.BackColor = Color.White;
            btn_Left.FlatStyle = FlatStyle.Popup;
            btn_Left.Location = new Point(487, 232);
            btn_Left.Name = "Btn_Left";
            btn_Left.Size = new Size(19, 19);
            btn_Left.TabIndex = 76;
            btn_Left.UseVisualStyleBackColor = false;
            btn_Left.MouseDown += Btn_Left_MouseDown;
            btn_Left.MouseUp += Btn_Left_MouseUp;
            // 
            // btn_Close
            // 
            btn_Close.BackColor = Color.White;
            btn_Close.FlatStyle = FlatStyle.Popup;
            btn_Close.Location = new Point(321, 240);
            btn_Close.Name = "Btn_Close";
            btn_Close.Size = new Size(37, 23);
            btn_Close.TabIndex = 75;
            btn_Close.UseVisualStyleBackColor = false;
            btn_Close.MouseDown += Btn_Close_MouseDown;
            btn_Close.MouseUp += Btn_Close_MouseUp;
            // 
            // btn_Open
            // 
            btn_Open.BackColor = Color.White;
            btn_Open.FlatStyle = FlatStyle.Popup;
            btn_Open.Location = new Point(262, 240);
            btn_Open.Name = "Btn_Open";
            btn_Open.Size = new Size(37, 23);
            btn_Open.TabIndex = 74;
            btn_Open.UseVisualStyleBackColor = false;
            btn_Open.MouseDown += Btn_Open_MouseDown;
            btn_Open.MouseUp += Btn_Open_MouseUp;
            // 
            // btn_Far
            // 
            btn_Far.BackColor = Color.White;
            btn_Far.FlatStyle = FlatStyle.Popup;
            btn_Far.Location = new Point(321, 191);
            btn_Far.Name = "Btn_Far";
            btn_Far.Size = new Size(37, 23);
            btn_Far.TabIndex = 73;
            btn_Far.UseVisualStyleBackColor = false;
            btn_Far.MouseDown += Btn_Far_MouseDown;
            btn_Far.MouseUp += Btn_Far_MouseUp;
            // 
            // btn_Near
            // 
            btn_Near.BackColor = Color.White;
            btn_Near.FlatStyle = FlatStyle.Popup;
            btn_Near.Location = new Point(262, 191);
            btn_Near.Name = "Btn_Near";
            btn_Near.Size = new Size(37, 23);
            btn_Near.TabIndex = 72;
            btn_Near.UseVisualStyleBackColor = false;
            btn_Near.MouseDown += Btn_Near_MouseDown;
            btn_Near.MouseUp += Btn_Near_MouseUp;
            // 
            // btn_AuxOff
            // 
            btn_AuxOff.BackColor = Color.White;
            btn_AuxOff.Location = new Point(458, 44);
            btn_AuxOff.Name = "Btn_AuxOff";
            btn_AuxOff.Size = new Size(52, 33);
            btn_AuxOff.TabIndex = 70;
            btn_AuxOff.UseVisualStyleBackColor = false;
            btn_AuxOff.Click += Btn_NotImplemented_Click;
            // 
            // btn_AuxOn
            // 
            btn_AuxOn.BackColor = Color.White;
            btn_AuxOn.Location = new Point(399, 44);
            btn_AuxOn.Name = "Btn_AuxOn";
            btn_AuxOn.Size = new Size(52, 33);
            btn_AuxOn.TabIndex = 69;
            btn_AuxOn.UseVisualStyleBackColor = false;
            btn_AuxOn.Click += Btn_NotImplemented_Click;
            // 
            // btn_F3_Mom
            // 
            btn_F3_Mom.BackColor = Color.White;
            btn_F3_Mom.Location = new Point(339, 44);
            btn_F3_Mom.Name = "Btn_F3_Mom";
            btn_F3_Mom.Size = new Size(52, 33);
            btn_F3_Mom.TabIndex = 68;
            btn_F3_Mom.UseVisualStyleBackColor = false;
            btn_F3_Mom.Click += Btn_NotImplemented_Click;
            // 
            // btn_F2_Off
            // 
            btn_F2_Off.BackColor = Color.White;
            btn_F2_Off.Location = new Point(279, 44);
            btn_F2_Off.Name = "Btn_F2_Off";
            btn_F2_Off.Size = new Size(52, 33);
            btn_F2_Off.TabIndex = 67;
            btn_F2_Off.UseVisualStyleBackColor = false;
            btn_F2_Off.Click += Btn_NotImplemented_Click;
            // 
            // btn_F1_Latch
            // 
            btn_F1_Latch.BackColor = Color.White;
            btn_F1_Latch.Location = new Point(218, 44);
            btn_F1_Latch.Name = "Btn_F1_Latch";
            btn_F1_Latch.Size = new Size(52, 33);
            btn_F1_Latch.TabIndex = 66;
            btn_F1_Latch.UseVisualStyleBackColor = false;
            btn_F1_Latch.Click += Btn_NotImplemented_Click;
            // 
            // btn_Shift
            // 
            btn_Shift.BackColor = Color.White;
            btn_Shift.Location = new Point(158, 44);
            btn_Shift.Name = "Btn_Shift";
            btn_Shift.Size = new Size(52, 33);
            btn_Shift.TabIndex = 65;
            btn_Shift.UseVisualStyleBackColor = false;
            btn_Shift.Click += Btn_Shift_Click;
            // 
            // btn_Pgm
            // 
            btn_Pgm.BackColor = Color.White;
            btn_Pgm.Location = new Point(484, 109);
            btn_Pgm.Name = "Btn_Pgm";
            btn_Pgm.Size = new Size(34, 33);
            btn_Pgm.TabIndex = 64;
            btn_Pgm.UseVisualStyleBackColor = false;
            btn_Pgm.Click += Btn_NotImplemented_Click;
            // 
            // btn_Macro
            // 
            btn_Macro.BackColor = Color.White;
            btn_Macro.Location = new Point(436, 109);
            btn_Macro.Name = "Btn_Macro";
            btn_Macro.Size = new Size(34, 33);
            btn_Macro.TabIndex = 63;
            btn_Macro.UseVisualStyleBackColor = false;
            btn_Macro.Click += Btn_NotImplemented_Click;
            // 
            // btn_Preset
            // 
            btn_Preset.BackColor = Color.White;
            btn_Preset.Location = new Point(388, 109);
            btn_Preset.Name = "Btn_Preset";
            btn_Preset.Size = new Size(34, 33);
            btn_Preset.TabIndex = 62;
            btn_Preset.UseVisualStyleBackColor = false;
            btn_Preset.Click += Btn_NotImplemented_Click;
            // 
            // btn_Pattern
            // 
            btn_Pattern.BackColor = Color.White;
            btn_Pattern.Location = new Point(340, 109);
            btn_Pattern.Name = "Btn_Pattern";
            btn_Pattern.Size = new Size(34, 33);
            btn_Pattern.TabIndex = 61;
            btn_Pattern.UseVisualStyleBackColor = false;
            btn_Pattern.Click += Btn_NotImplemented_Click;
            // 
            // btn_Hold
            // 
            btn_Hold.BackColor = Color.White;
            btn_Hold.Location = new Point(292, 109);
            btn_Hold.Name = "Btn_Hold";
            btn_Hold.Size = new Size(34, 33);
            btn_Hold.TabIndex = 60;
            btn_Hold.UseVisualStyleBackColor = false;
            btn_Hold.Click += Btn_NotImplemented_Click;
            // 
            // btn_Next
            // 
            btn_Next.BackColor = Color.White;
            btn_Next.Location = new Point(244, 109);
            btn_Next.Name = "Btn_Next";
            btn_Next.Size = new Size(34, 33);
            btn_Next.TabIndex = 59;
            btn_Next.UseVisualStyleBackColor = false;
            btn_Next.Click += Btn_NotImplemented_Click;
            // 
            // btn_Prev
            // 
            btn_Prev.BackColor = Color.White;
            btn_Prev.Location = new Point(196, 109);
            btn_Prev.Name = "Btn_Prev";
            btn_Prev.Size = new Size(34, 33);
            btn_Prev.TabIndex = 58;
            btn_Prev.UseVisualStyleBackColor = false;
            btn_Prev.Click += Btn_NotImplemented_Click;
            // 
            // btn_Ack
            // 
            btn_Ack.BackColor = Color.White;
            btn_Ack.Location = new Point(150, 109);
            btn_Ack.Name = "Btn_Ack";
            btn_Ack.Size = new Size(34, 33);
            btn_Ack.TabIndex = 57;
            btn_Ack.UseVisualStyleBackColor = false;
            btn_Ack.Click += Btn_NotImplemented_Click;
            // 
            // btn_Mon
            // 
            btn_Mon.BackColor = Color.White;
            btn_Mon.Location = new Point(84, 109);
            btn_Mon.Name = "Btn_Mon";
            btn_Mon.Size = new Size(34, 33);
            btn_Mon.TabIndex = 56;
            btn_Mon.UseVisualStyleBackColor = false;
            btn_Mon.Click += Btn_Mon_Click;
            // 
            // btn_Clear
            // 
            btn_Clear.BackColor = Color.White;
            btn_Clear.Location = new Point(181, 331);
            btn_Clear.Name = "Btn_Clear";
            btn_Clear.Size = new Size(34, 32);
            btn_Clear.TabIndex = 55;
            btn_Clear.UseVisualStyleBackColor = false;
            btn_Clear.Click += Btn_NotImplemented_Click;
            // 
            // btn_0
            // 
            btn_0.BackColor = Color.White;
            btn_0.Location = new Point(133, 331);
            btn_0.Name = "Btn_0";
            btn_0.Size = new Size(34, 32);
            btn_0.TabIndex = 54;
            btn_0.UseVisualStyleBackColor = false;
            btn_0.Click += Btn_0_Click;
            // 
            // btn_Cam
            // 
            btn_Cam.BackColor = Color.White;
            btn_Cam.Location = new Point(85, 331);
            btn_Cam.Name = "Btn_Cam";
            btn_Cam.Size = new Size(34, 32);
            btn_Cam.TabIndex = 53;
            btn_Cam.UseVisualStyleBackColor = false;
            btn_Cam.Click += Btn_Cam_Click;
            // 
            // btn_9
            // 
            btn_9.BackColor = Color.White;
            btn_9.Location = new Point(181, 283);
            btn_9.Name = "Btn_9";
            btn_9.Size = new Size(34, 32);
            btn_9.TabIndex = 52;
            btn_9.UseVisualStyleBackColor = false;
            btn_9.Click += Btn_9_Click;
            // 
            // btn_8
            // 
            btn_8.BackColor = Color.White;
            btn_8.Location = new Point(133, 283);
            btn_8.Name = "Btn_8";
            btn_8.Size = new Size(34, 32);
            btn_8.TabIndex = 51;
            btn_8.UseVisualStyleBackColor = false;
            btn_8.Click += Btn_8_Click;
            // 
            // btn_7
            // 
            btn_7.BackColor = Color.White;
            btn_7.Location = new Point(85, 283);
            btn_7.Name = "Btn_7";
            btn_7.Size = new Size(34, 32);
            btn_7.TabIndex = 50;
            btn_7.UseVisualStyleBackColor = false;
            btn_7.Click += Btn_7_Click;
            // 
            // btn_6
            // 
            btn_6.BackColor = Color.White;
            btn_6.Location = new Point(181, 234);
            btn_6.Name = "Btn_6";
            btn_6.Size = new Size(34, 32);
            btn_6.TabIndex = 49;
            btn_6.UseVisualStyleBackColor = false;
            btn_6.Click += Btn_6_Click;
            // 
            // btn_5
            // 
            btn_5.BackColor = Color.White;
            btn_5.Location = new Point(133, 234);
            btn_5.Name = "Btn_5";
            btn_5.Size = new Size(34, 32);
            btn_5.TabIndex = 48;
            btn_5.UseVisualStyleBackColor = false;
            btn_5.Click += Btn_5_Click;
            // 
            // btn_4
            // 
            btn_4.BackColor = Color.White;
            btn_4.Location = new Point(84, 234);
            btn_4.Name = "Btn_4";
            btn_4.Size = new Size(34, 32);
            btn_4.TabIndex = 47;
            btn_4.UseVisualStyleBackColor = false;
            btn_4.Click += Btn_4_Click;
            // 
            // btn_3
            // 
            btn_3.BackColor = Color.White;
            btn_3.Location = new Point(181, 187);
            btn_3.Name = "Btn_3";
            btn_3.Size = new Size(34, 32);
            btn_3.TabIndex = 46;
            btn_3.UseVisualStyleBackColor = false;
            btn_3.Click += Btn_3_Click;
            // 
            // btn_2
            // 
            btn_2.BackColor = Color.White;
            btn_2.Location = new Point(132, 186);
            btn_2.Name = "Btn_2";
            btn_2.Size = new Size(34, 32);
            btn_2.TabIndex = 45;
            btn_2.UseVisualStyleBackColor = false;
            btn_2.Click += Btn_2_Click;
            // 
            // btn_1
            // 
            btn_1.BackColor = Color.White;
            btn_1.Location = new Point(84, 186);
            btn_1.Name = "Btn_1";
            btn_1.Size = new Size(34, 32);
            btn_1.TabIndex = 44;
            btn_1.UseVisualStyleBackColor = false;
            btn_1.Click += Btn_1_Click;

            Image = ResourceHelper.GetEmbeddedResourceByName(GetType().Assembly, "Mtf.Controls.Resources.KBD300A.png");
            Location = new Point(0, 0);
            OriginalSize = new Size(675, 425);
            RepositioningAndResizingControlsOnResize = true;
            Size = new Size(675, 425);
            SizeMode = PictureBoxSizeMode.Zoom;
            TabIndex = 0;
            TabStop = false;

            Shift = false;
            move = tb_MoveValue.Value;
            number = new StringBuilder();

            Controls.Add(tb_MoveValue);
            Controls.Add(p_LED);
            Controls.Add(btn_ZoomOut);
            Controls.Add(btn_ZoomIn);
            Controls.Add(btn_RigthDown);
            Controls.Add(btn_LeftDown);
            Controls.Add(btn_RightUp);
            Controls.Add(btn_LeftUp);
            Controls.Add(btn_Down);
            Controls.Add(btn_Up);
            Controls.Add(btn_Right);
            Controls.Add(btn_Left);
            Controls.Add(btn_Close);
            Controls.Add(btn_Open);
            Controls.Add(btn_Far);
            Controls.Add(btn_Near);
            Controls.Add(btn_AuxOff);
            Controls.Add(btn_AuxOn);
            Controls.Add(btn_F3_Mom);
            Controls.Add(btn_F2_Off);
            Controls.Add(btn_F1_Latch);
            Controls.Add(btn_Shift);
            Controls.Add(btn_Pgm);
            Controls.Add(btn_Macro);
            Controls.Add(btn_Preset);
            Controls.Add(btn_Pattern);
            Controls.Add(btn_Hold);
            Controls.Add(btn_Next);
            Controls.Add(btn_Prev);
            Controls.Add(btn_Ack);
            Controls.Add(btn_Mon);
            Controls.Add(btn_Clear);
            Controls.Add(btn_0);
            Controls.Add(btn_Cam);
            Controls.Add(btn_9);
            Controls.Add(btn_8);
            Controls.Add(btn_7);
            Controls.Add(btn_6);
            Controls.Add(btn_5);
            Controls.Add(btn_4);
            Controls.Add(btn_3);
            Controls.Add(btn_2);
            Controls.Add(btn_1);
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Shift button (currently has no effect).")]

        public bool Shift { get; set; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The server will wait on this named pipe to process the incoming commands.")]
        public string PipeName { get; set; }

        private async void Btn_NotImplemented_Click(object sender, EventArgs e)
        {
            await SendAsync("Not implemented...").ConfigureAwait(false);
        }

        private void Btn_Shift_Click(object sender, EventArgs e)
        {
            Shift = !Shift;
        }

        private async Task SendAsync(string command)
        {
            var message = $"{command}\r\n";
            var data = Encoding.ASCII.GetBytes(message);
            using (var client = new NamedPipeClientStream(".", PipeName, PipeDirection.Out))
            {
                await client.ConnectAsync().ConfigureAwait(false);
                await client.WriteAsync(data, 0, data.Length).ConfigureAwait(false);
                await client.FlushAsync().ConfigureAwait(false);
            }
        }

        private async void Btn_Left_MouseDown(object sender, MouseEventArgs e)
        {
            await StartMoveLeftAsync().ConfigureAwait(false);
        }

        public Task StartMoveLeftAsync()
        {
            return SendAsync($"{move}La");
        }

        private async void Btn_Left_MouseUp(object sender, MouseEventArgs e)
        {
            await StopMoveLeftAsync().ConfigureAwait(false);
        }

        public Task StopMoveLeftAsync()
        {
            return SendAsync("~La");
        }

        public void SetMoveSpeed(byte speed)
        {
            tb_MoveValue.Value = speed;
            move = speed;
        }

        private async void Btn_Right_MouseDown(object sender, MouseEventArgs e)
        {
            await StartMoveRightAsync().ConfigureAwait(false);
        }

        public Task StartMoveRightAsync()
        {
            return SendAsync($"{move}Ra");
        }

        private async void Btn_Right_MouseUp(object sender, MouseEventArgs e)
        {
            await StopMoveRightAsync().ConfigureAwait(false); ;
        }

        public Task StopMoveRightAsync()
        {
            return SendAsync("~Ra");
        }

        private async void Btn_Up_MouseDown(object sender, MouseEventArgs e)
        {
            await StartMoveUpAsync().ConfigureAwait(false);
        }

        public Task StartMoveUpAsync()
        {
            return SendAsync($"{move}Ua");
        }

        private async void Btn_Up_MouseUp(object sender, MouseEventArgs e)
        {
            await StopMoveUpAsync().ConfigureAwait(false);
        }

        public Task StopMoveUpAsync()
        {
            return SendAsync("~Ua");
        }

        private async void Btn_Down_MouseDown(object sender, MouseEventArgs e)
        {
            await StartMoveDownAsync().ConfigureAwait(false);
        }

        public Task StartMoveDownAsync()
        {
            return SendAsync($"{move}Da");
        }

        private async void Btn_Down_MouseUp(object sender, MouseEventArgs e)
        {
            await StopMoveDownAsync().ConfigureAwait(false);
        }

        public Task StopMoveDownAsync()
        {
            return SendAsync("~Da");
        }

        private void Tb_MoveValue_Scroll(object sender, EventArgs e)
        {
            move = tb_MoveValue.Value;
        }

        private async void Btn_LeftUp_MouseDown(object sender, MouseEventArgs e)
        {
            await StartMoveLeftUpAsync().ConfigureAwait(false);
        }

        public Task StartMoveLeftUpAsync()
        {
            return Task.WhenAll(SendAsync($"{move}La"), SendAsync($"{move}Ua"));
        }

        private async void Btn_LeftUp_MouseUp(object sender, MouseEventArgs e)
        {
            await StopAllMovementAsync().ConfigureAwait(false);
        }

        public Task StopAllMovementAsync()
        {
            return SendAsync("sa");
        }

        private async void Btn_RightUp_MouseDown(object sender, MouseEventArgs e)
        {
            await StartMoveRightUpAsync().ConfigureAwait(false);
        }

        public Task StartMoveRightUpAsync()
        {
            return Task.WhenAll(SendAsync($"{move}Ra"), SendAsync($"{move}Ua"));
        }

        private async void Btn_RightUp_MouseUp(object sender, MouseEventArgs e)
        {
            await StopAllMovementAsync().ConfigureAwait(false);
        }

        private async void Btn_RigthDown_MouseDown(object sender, MouseEventArgs e)
        {
            await StartMoveRightDownAsync().ConfigureAwait(false);
        }

        public Task StartMoveRightDownAsync()
        {
            return Task.WhenAll(SendAsync($"{move}Ra"), SendAsync($"{move}Da"));
        }

        private async void Btn_RigthDown_MouseUp(object sender, MouseEventArgs e)
        {
            await StopAllMovementAsync().ConfigureAwait(false);
        }

        private async void Btn_LeftDown_MouseDown(object sender, MouseEventArgs e)
        {
            await StartMoveLeftDownAsync().ConfigureAwait(false);
        }

        public Task StartMoveLeftDownAsync()
        {
            return Task.WhenAll(SendAsync($"{move}La"), SendAsync($"{move}Da"));
        }

        private async void Btn_LeftDown_MouseUp(object sender, MouseEventArgs e)
        {
            await StopAllMovementAsync().ConfigureAwait(false);
        }

        private async void Btn_ZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            await StartZoomInAsync().ConfigureAwait(false);
        }

        public Task StartZoomInAsync()
        {
            return SendAsync("Ta");
        }

        private async void Btn_ZoomIn_MouseUp(object sender, MouseEventArgs e)
        {
            await StopZoomInAsync().ConfigureAwait(false);
        }

        public Task StopZoomInAsync()
        {
            return SendAsync("~Ta");
        }

        private async void Btn_ZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            await StartZoomOutAsync().ConfigureAwait(false);
        }

        public Task StartZoomOutAsync()
        {
            return SendAsync("Wa");
        }

        private async void Btn_ZoomOut_MouseUp(object sender, MouseEventArgs e)
        {
            await StopZoomOutAsync().ConfigureAwait(false);
        }

        public Task StopZoomOutAsync()
        {
            return SendAsync("~Wa");
        }

        private async void Btn_Near_MouseDown(object sender, MouseEventArgs e)
        {
            await SendAsync("Na").ConfigureAwait(false);
        }

        private async void Btn_Near_MouseUp(object sender, MouseEventArgs e)
        {
            await SendAsync("~Na").ConfigureAwait(false);
        }

        private async void Btn_Far_MouseDown(object sender, MouseEventArgs e)
        {
            await SendAsync("Fa").ConfigureAwait(false);
        }

        private async void Btn_Far_MouseUp(object sender, MouseEventArgs e)
        {
            await SendAsync("~Fa").ConfigureAwait(false);
        }

        private async void Btn_Open_MouseDown(object sender, MouseEventArgs e)
        {
            await SendAsync("Oa").ConfigureAwait(false);
        }

        private async void Btn_Open_MouseUp(object sender, MouseEventArgs e)
        {
            await SendAsync("~Oa").ConfigureAwait(false);
        }

        private async void Btn_Close_MouseDown(object sender, MouseEventArgs e)
        {
            await SendAsync("Ca").ConfigureAwait(false);
        }

        private async void Btn_Close_MouseUp(object sender, MouseEventArgs e)
        {
            await SendAsync("~Ca").ConfigureAwait(false);
        }

        private void Btn_1_Click(object sender, EventArgs e)
        {
            _ = number.Append(Shift ? 'A' : '1');
        }

        private void Btn_2_Click(object sender, EventArgs e)
        {
            _ = number.Append(Shift ? 'B' : '2');
        }

        private void Btn_3_Click(object sender, EventArgs e)
        {
            _ = number.Append(Shift ? 'C' : '3');
        }

        private void Btn_4_Click(object sender, EventArgs e)
        {
            _ = number.Append(Shift ? 'D' : '4');
        }

        private void Btn_5_Click(object sender, EventArgs e)
        {
            _ = number.Append(Shift ? 'E' : '5');
        }

        private void Btn_6_Click(object sender, EventArgs e)
        {
            _ = number.Append(Shift ? 'F' : '6');
        }

        private void Btn_7_Click(object sender, EventArgs e)
        {
            _ = number.Append(Shift ? 'G' : '7');
        }

        private void Btn_8_Click(object sender, EventArgs e)
        {
            _ = number.Append(Shift ? 'H' : '8');
        }

        private void Btn_9_Click(object sender, EventArgs e)
        {
            _ = number.Append(Shift ? 'I' : '9');
        }

        private void Btn_0_Click(object sender, EventArgs e)
        {
            _ = number.Append(Shift ? ' ' : '0');
        }

        private async void Btn_Cam_Click(object sender, EventArgs e)
        {
            await SendAsync($"{number}#a").ConfigureAwait(false);
            number = new StringBuilder();
        }

        private async void Btn_Mon_Click(object sender, EventArgs e)
        {
            await SendAsync($"{number}Ma").ConfigureAwait(false);
            number = new StringBuilder();
        }

        private void InitializeComponent()
        {
            components = new Container();
            var resources = new ComponentResourceManager(typeof(Kbd300ASimulator));
            il_Images = new ImageList(components);
            ((ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // il_Images
            // 
            il_Images.ImageStream = (ImageListStreamer)resources.GetObject("il_Images.ImageStream", CultureInfo.InvariantCulture);
            il_Images.TransparentColor = Color.Transparent;
            il_Images.Images.SetKeyName(0, "OK.bmp");
            il_Images.Images.SetKeyName(1, "Error.bmp");
            ((ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }
    }
}
