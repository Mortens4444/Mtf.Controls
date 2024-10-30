using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mtf.Controls.Test
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource cancellationTokenSource;
        private Task task;
        private bool firstImage;
        private readonly Image image1, image2;

        public MainForm()
        {
            InitializeComponent();
            image1 = GetEmbeddedResourceByName("Mtf.Controls.Test.Resources.kertmester.png");
            image2 = GetEmbeddedResourceByName("Mtf.Controls.Test.Resources.hack_with_me.png");
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
                task = Task.Run(() =>
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

        public static Image GetEmbeddedResourceByName(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                return stream == null ? throw new FileNotFoundException($"Resource '{resourceName}' not found.") : Image.FromStream(stream);
            }
        }
    }
}
