using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mtf.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(MovablePanel), "Resources.Kbd300ASimulator.png")]

    public partial class Kbd300ASimulator : MtfPictureBox
    {
        public event EventHandler CameraWindowClosed;

        // 7 on, others off
        public Kbd300ASimulator()
        {
            InitializeComponent();

            move = tb_MoveValue.Value;
            number = new StringBuilder();
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Shift button.")]
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
#if NET462_OR_GREATER
                await client.ConnectAsync().ConfigureAwait(false);
#else
                client.Connect();
#endif
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
    }
}
