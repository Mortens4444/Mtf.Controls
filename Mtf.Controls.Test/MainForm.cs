using Mtf.Controls.Services;
using System;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mtf.Controls.Test
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource cancellationTokenSource;
        private bool firstImage;
        private readonly Image image1, image2;

        public MainForm()
        {
            StartPipeServer();
            InitializeComponent();
            image1 = ResourceHelper.GetEmbeddedResourceByName(GetType().Assembly, "Mtf.Controls.Test.Resources.kertmester.png");
            image2 = ResourceHelper.GetEmbeddedResourceByName(GetType().Assembly, "Mtf.Controls.Test.Resources.hack_with_me.png");

        }

        private async void StartPipeServer()
        {
            while (true)
            {
                using (var server = new NamedPipeServerStream("testpipe", PipeDirection.In))
                {
                    await server.WaitForConnectionAsync().ConfigureAwait(false);
                    using (var reader = new StreamReader(server))
                    {
                        string message;
                        while ((message = await reader.ReadLineAsync().ConfigureAwait(false)) != null)
                        {
                            AppendMessageToRichTextBox(message);
                        }
                    }
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!(cancellationTokenSource?.Token.IsCancellationRequested ?? true))
            {
                cancellationTokenSource.Cancel();
                button1.Text = "Start test";
            }
            else
            {
                cancellationTokenSource = new CancellationTokenSource();
                _ = Task.Run(() =>
                {
                    try
                    {
                        while (!cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            firstImage = !firstImage;
                            var image = firstImage ? image1 : image2;

                            Invoke((Action)(() =>
                            {
                                pictureBox1.Image = image;
                                pictureBox1.Invalidate();
                            }));

                            mtfPictureBox1.SetImage(image);
                            mtfPictureBox1.Invalidate();

                            Thread.Sleep(10);
                        }
                    }
                    catch (OperationCanceledException) { }
                }, cancellationTokenSource.Token);
                button1.Text = "Stop test";
            }
        }

        private void AppendMessageToRichTextBox(string message)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action(() => AppendMessageToRichTextBox(message)));
            }
            else
            {
                richTextBox1.AppendText(message + Environment.NewLine);
            }
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Select(richTextBox1.Text.Length - 1, 0);
            richTextBox1.ScrollToCaret();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = passwordBox1.Password;
        }
    }
}
