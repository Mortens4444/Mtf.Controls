using Mtf.Controls.Services;
using System;
using System.CodeDom.Compiler;
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

            ansiColoringRichTextBox1.AppendText("\u001b[1;34mbin\u001b[0m      \u001b[1;34mcifs2\u001b[0m    \u001b[1;34mdev\u001b[0m      \u001b[1;34mjffs\u001b[0m     \u001b[1;34mmmc\u001b[0m      \u001b[1;34mproc\u001b[0m     \u001b[1;34msbin\u001b[0m     \u001b[1;34mtmp\u001b[0m      \u001b[1;34mwww\u001b[0m\r\n\u001b[1;34mbootfs\u001b[0m   \u001b[1;34mdata\u001b[0m     \u001b[1;36metc\u001b[0m      \u001b[1;34mlib\u001b[0m      \u001b[1;36mmnt\u001b[0m      \u001b[1;34mrom\u001b[0m      \u001b[1;34msys\u001b[0m      \u001b[1;34musr\u001b[0m\r\n\u001b[1;34mcifs1\u001b[0m    \u001b[1;36mdebug\u001b[0m    \u001b[1;36mhome\u001b[0m     \u001b[1;34mlib64\u001b[0m    \u001b[1;34mopt\u001b[0m      \u001b[1;36mroot\u001b[0m     \u001b[1;34msysroot\u001b[0m  \u001b[1;34mvar\u001b[0m\r\nuser@system:/home/user# ");
            ansiColoringRichTextBox1.AppendText("\u001b[1;34mbin\u001b[0m      \u001b[1;34mcifs2\u001b[0m    \u001b[1;34mdev\u001b[0m      \u001b[1;34mjffs\u001b[0m     \u001b[1;34mmmc\u001b[0m      \u001b[1;34mproc\u001b[0m     \u001b[1;34msbin\u001b[0m     \u001b[1;34mtmp\u001b[0m      \u001b[1;34mwww\u001b[0m\r\n\u001b[1;34mbootfs\u001b[0m   \u001b[1;34mdata\u001b[0m     \u001b[1;36metc\u001b[0m      \u001b[1;34mlib\u001b[0m      \u001b[1;36mmnt\u001b[0m      \u001b[1;34mrom\u001b[0m      \u001b[1;34msys\u001b[0m      \u001b[1;34musr\u001b[0m\r\n\u001b[1;34mcifs1\u001b[0m    \u001b[1;36mdebug\u001b[0m    \u001b[1;36mhome\u001b[0m     \u001b[1;34mlib64\u001b[0m    \u001b[1;34mopt\u001b[0m      \u001b[1;36mroot\u001b[0m     \u001b[1;34msysroot\u001b[0m  \u001b[1;34mvar\u001b[0m\r\nuser@system:/home/user# ");
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

        private void button3_Click(object sender, EventArgs e)
        {
            openCvSharp4VideoWindow1.Start("http://takemotopiano.aa1.netvolante.jp:8190/nphMotionJpeg?Resolution=640x480&Quality=Standard&Framerate=30");
            mortoGraphyWindow1.Start("http://takemotopiano.aa1.netvolante.jp:8190/nphMotionJpeg?Resolution=640x480&Quality=Standard&Framerate=30");
            vlcWindow1.Start("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4");
            fFmpegWindow1.Start("http://takemotopiano.aa1.netvolante.jp:8190/nphMotionJpeg?Resolution=640x480&Quality=Standard&Framerate=30");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openCvSharp4VideoWindow1.Stop();
            mortoGraphyWindow1.Stop();
            vlcWindow1.Stop();
            fFmpegWindow1.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mtfListView1.ExportItemsToCsv(@"C:\Work\Test.csv", ";");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mtfTreeView1.ExportNodesToCsv(@"C:\Work\Test.csv", ";");
        }
    }
}