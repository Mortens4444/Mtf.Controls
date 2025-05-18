using Mtf.Controls.Services;
using Mtf.MessageBoxes;
using System;
using System.Collections.Generic;
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

            pbFontColor.BackColor = ansiColoringRichTextBox1.ForeColor;
            pbBackColor.BackColor = ansiColoringRichTextBox1.BackColor;

            colorDialog.CustomColors =
                new int[]
                {
                    ColorTranslator.ToOle(ansiColoringRichTextBox1.BlackColor),
                    ColorTranslator.ToOle(ansiColoringRichTextBox1.RedColor),
                    ColorTranslator.ToOle(ansiColoringRichTextBox1.GreenColor),
                    ColorTranslator.ToOle(ansiColoringRichTextBox1.YellowColor),
                    ColorTranslator.ToOle(ansiColoringRichTextBox1.BlueColor),
                    ColorTranslator.ToOle(ansiColoringRichTextBox1.PurpleColor),
                    ColorTranslator.ToOle(ansiColoringRichTextBox1.CyanColor),
                    ColorTranslator.ToOle(ansiColoringRichTextBox1.WhiteColor),

                    ColorTranslator.ToOle(ansiColoringRichTextBox1.BrightBlackColor),
                    ColorTranslator.ToOle(ansiColoringRichTextBox1.BrightRedColor),
                    ColorTranslator.ToOle(ansiColoringRichTextBox1.BrightGreenColor),
                    ColorTranslator.ToOle(ansiColoringRichTextBox1.BrightYellowColor),
                    ColorTranslator.ToOle(ansiColoringRichTextBox1.BrightBlueColor),
                    ColorTranslator.ToOle(ansiColoringRichTextBox1.BrightPurpleColor),
                    ColorTranslator.ToOle(ansiColoringRichTextBox1.BrightCyanColor),
                    ColorTranslator.ToOle(ansiColoringRichTextBox1.BrightWhiteColor)
                };

            ansiColoringRichTextBox1.AppendText("\u001b[1;34mbin\u001b[0m      \u001b[1;34mcifs2\u001b[0m    \u001b[1;34mdev\u001b[0m      \u001b[1;34mjffs\u001b[0m     \u001b[1;34mmmc\u001b[0m      \u001b[1;34mproc\u001b[0m     \u001b[1;34msbin\u001b[0m     \u001b[1;34mtmp\u001b[0m      \u001b[1;34mwww\u001b[0m\r\n\u001b[1;34mbootfs\u001b[0m   \u001b[1;34mdata\u001b[0m     \u001b[1;36metc\u001b[0m      \u001b[1;34mlib\u001b[0m      \u001b[1;36mmnt\u001b[0m      \u001b[1;34mrom\u001b[0m      \u001b[1;34msys\u001b[0m      \u001b[1;34musr\u001b[0m\r\n\u001b[1;34mcifs1\u001b[0m    \u001b[1;36mdebug\u001b[0m    \u001b[1;36mhome\u001b[0m     \u001b[1;34mlib64\u001b[0m    \u001b[1;34mopt\u001b[0m      \u001b[1;36mroot\u001b[0m     \u001b[1;34msysroot\u001b[0m  \u001b[1;34mvar\u001b[0m\r\nuser@system:/home/user# ");
            ansiColoringRichTextBox1.AppendText("\u001b[1;34mbin\u001b[0m      \u001b[1;34mcifs2\u001b[0m    \u001b[1;34mdev\u001b[0m      \u001b[1;34mjffs\u001b[0m     \u001b[1;34mmmc\u001b[0m      \u001b[1;34mproc\u001b[0m     \u001b[1;34msbin\u001b[0m     \u001b[1;34mtmp\u001b[0m      \u001b[1;34mwww\u001b[0m\r\n\u001b[1;34mbootfs\u001b[0m   \u001b[1;34mdata\u001b[0m     \u001b[1;36metc\u001b[0m      \u001b[1;34mlib\u001b[0m      \u001b[1;36mmnt\u001b[0m      \u001b[1;34mrom\u001b[0m      \u001b[1;34msys\u001b[0m      \u001b[1;34musr\u001b[0m\r\n\u001b[1;34mcifs1\u001b[0m    \u001b[1;36mdebug\u001b[0m    \u001b[1;36mhome\u001b[0m     \u001b[1;34mlib64\u001b[0m    \u001b[1;34mopt\u001b[0m      \u001b[1;36mroot\u001b[0m     \u001b[1;34msysroot\u001b[0m  \u001b[1;34mvar\u001b[0m\r\nuser@system:/home/user# ");

            // Teszt string 1: Alap színek és stílusok, reset kód
            ansiColoringRichTextBox1.AppendText(
                "\u001b[1mEz félkövér.\u001b[0m\r\n" +
                "\u001b[31mEz piros.\u001b[0m\r\n" +
                "\u001b[4mEz aláhúzott.\u001b[0m\r\n" +
                "\u001b[1;32mEz félkövér és zöld.\u001b[0m\r\n" +
                "\u001b[33;4mEz sárga és aláhúzott.\u001b[0m\r\n" +
                "Ez normál szöveg a reset után.\r\n"
            );

            // Teszt string 2: Specifikus stílus resetek
            ansiColoringRichTextBox1.AppendText(
                "\u001b[1;4;34mEz félkövér, aláhúzott és kék.\u001b[22mEz csak aláhúzott és kék (félkövér kikapcsolva).\u001b[24mEz csak kék (aláhúzás kikapcsolva).\u001b[0m\r\n" +
                "\u001b[35mEz magenta.\u001b[1mEz magenta és félkövér.\u001b[22mEz újra csak magenta.\u001b[0m\r\n"
            );

            // Teszt string 3: Élénk színek
            ansiColoringRichTextBox1.AppendText(
                "\u001b[91mEz élénk piros.\u001b[0m\r\n" +
                "\u001b[1;94mEz félkövér és élénk kék.\u001b[0m\r\n" +
                "\u001b[93;4mEz élénk sárga és aláhúzott.\u001b[0m\r\n"
            );

            // Teszt string 4: Több paraméter különböző sorrendben
            ansiColoringRichTextBox1.AppendText(
                "\u001b[32;1mEz zöld és félkövér (szín, majd stílus).\u001b[0m\r\n" +
                "\u001b[4;36mEz aláhúzott és cián (stílus, majd szín).\u001b[0m\r\n"
            );

            // Teszt string 5: Üres escape szekvenciák (ezeknek nincs hatásuk a standard szerint, de jó tesztelni)
            ansiColoringRichTextBox1.AppendText(
                "Normál \u001b[]m szöveg \u001b[;]m üres \u001b[;0;]m paraméterekkel.\u001b[0m\r\n"
            );

            // Teszt string 6: Áthúzott szöveg és háttérszínek
            ansiColoringRichTextBox1.AppendText(
                "Normál szöveg.\r\n" +
                "\u001b[9mEz áthúzott szöveg.\u001b[0m\r\n" + // Áthúzás be, majd minden reset
                "\u001b[31;43mEz piros szöveg sárga háttérrel.\u001b[0m\r\n" + // Piros előtér, sárga háttér, majd reset
                "\u001b[1;9;44mEz félkövér, áthúzott szöveg kék háttérrel.\u001b[0m\r\n" + // Félkövér, áthúzott, kék háttér, majd reset
                "\u001b[32;101mEz zöld szöveg élénk piros háttérrel.\u001b[0m\r\n" + // Zöld előtér, élénk piros háttér, majd reset
                "\u001b[9;34;46mEz áthúzott kék szöveg cián háttérrel.\u001b[29mEz most már nem áthúzott, csak kék szöveg cián háttérrel.\u001b[0m\r\n" + // Áthúzott kék cián háttérrel, majd csak az áthúzás resetelése (29), végül teljes reset
                "Vissza a normál szöveghez.\r\n"
            );

            mtfPictureBox2.Controls.Add(new TransparentPanel
            {
                Location = new Point(10, 10),
                Size = new Size(30, 30),
                BackColor = Color.Black
            });
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

        private void BtnShowPassword_Click(object sender, EventArgs e)
        {
            textBox2.Text = passwordBox1.Password;
        }

        private void BtnStartVideoWindows_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkOpenCvSharp4Video.Checked)
                {
                    openCvSharp4VideoWindow1.Start(String.IsNullOrEmpty(tbUrl.Text) ? "http://takemotopiano.aa1.netvolante.jp:8190/nphMotionJpeg?Resolution=640x480&Quality=Standard&Framerate=30" : tbUrl.Text);
                }
                if (chkMortoGraphyWindow.Checked)
                {
                    mortoGraphyWindow1.Start(String.IsNullOrEmpty(tbUrl.Text) ? "http://takemotopiano.aa1.netvolante.jp:8190/nphMotionJpeg?Resolution=640x480&Quality=Standard&Framerate=30" : tbUrl.Text);
                }
                if (chkFFMpegVideo.Checked)
                {
                    fFmpegWindow1.Start(String.IsNullOrEmpty(tbUrl.Text) ? "http://takemotopiano.aa1.netvolante.jp:8190/nphMotionJpeg?Resolution=640x480&Quality=Standard&Framerate=30" : tbUrl.Text);
                }
                if (chkVlcVideo.Checked)
                {
                    vlcWindow1.Start(String.IsNullOrEmpty(tbUrl.Text) ? "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4" : tbUrl.Text, demux: Enums.Demux.live555);
                }
            }
            catch (Exception ex)
            {
                ErrorBox.Show(ex);
            }
        }

        private void BtnStopVideoWindows_Click(object sender, EventArgs e)
        {
            openCvSharp4VideoWindow1.Stop();
            mortoGraphyWindow1.Stop();
            vlcWindow1.Stop();
            fFmpegWindow1.Stop();
        }

        private void BtnExportListView_Click(object sender, EventArgs e)
        {
            mtfListView1.ExportItemsToCsv(@"C:\Work\Test.csv", ";");
        }

        private void BtnExportTreeView_Click(object sender, EventArgs e)
        {
            mtfTreeView1.ExportNodesToCsv(@"C:\Work\Test.csv", ";");
        }

        private void PbFontColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pbFontColor.BackColor = colorDialog.Color;
                //ansiColoringRichTextBox1.ChangeMode(Enums.AnsiColoringMode.Reset);
            }
        }

        private void PbBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pbBackColor.BackColor = colorDialog.Color;
                //ansiColoringRichTextBox1.ChangeMode(Enums.AnsiColoringMode.Reset);
            }
        }

        private void BtnAppendToAnsiText_Click(object sender, EventArgs e)
        {
            var modes = new List<Enums.AnsiColoringMode>
            {
                ansiColoringRichTextBox1.ColorToAnsiColoringMode(pbFontColor.BackColor),
                ansiColoringRichTextBox1.ColorToAnsiColoringMode(pbBackColor.BackColor, true)
            };
            if (chkUnderline.Checked)
            {
                modes.Add(Enums.AnsiColoringMode.UnderlineFont);
            }
            if (chkItalic.Checked)
            {
                modes.Add(Enums.AnsiColoringMode.ItalicFont);
            }
            if (chkBold.Checked)
            {
                modes.Add(Enums.AnsiColoringMode.BoldFont);
            }
            if (chkStrikeout.Checked)
            {
                modes.Add(Enums.AnsiColoringMode.StrikeoutFont);
            }
            ansiColoringRichTextBox1.AppendText(tbAnsiText.Text, modes.ToArray());
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            ansiColoringRichTextBox1.AppendText("\x1B[H");
            ansiColoringRichTextBox1.Focus();
        }

        private void BtnMoveCaretToLeft_Click(object sender, EventArgs e)
        {
            ansiColoringRichTextBox1.AppendText("\x1B[1D");
            ansiColoringRichTextBox1.Focus();
        }

        private void BtnMoveCaretToUp_Click(object sender, EventArgs e)
        {
            ansiColoringRichTextBox1.AppendText("\x1B[1A");
            ansiColoringRichTextBox1.Focus();
        }

        private void BtnMoveCaretToRight_Click(object sender, EventArgs e)
        {
            ansiColoringRichTextBox1.AppendText("\x1B[1C");
            ansiColoringRichTextBox1.Focus();
        }

        private void BtnMoveCaretToDown_Click(object sender, EventArgs e)
        {
            ansiColoringRichTextBox1.AppendText("\x1B[1B");
            ansiColoringRichTextBox1.Focus();
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            //ansiColoringRichTextBox1.AppendText("\a"); // Test bell
            ansiColoringRichTextBox1.AppendText("\b"); // Test bell
            //ansiColoringRichTextBox1.AppendText("\x1B[2J"); // Test erase entire screen
            //ansiColoringRichTextBox1.AppendText("\x1B[2K"); // Test erase entire line
        }
    }
}