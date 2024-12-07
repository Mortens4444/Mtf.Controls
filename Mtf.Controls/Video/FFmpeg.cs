using Mtf.Controls.Extensions;
using Mtf.Controls.Interfaces;
using Mtf.MessageBoxes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mtf.Controls.Video
{
    public class FFmpeg : BaseVideoPlayer, IVideoPlayer
    {
        private readonly object sync = new object();

        private readonly string codec;
        private readonly PictureBox pictureBox;
        private CancellationTokenSource cancellationTokenSource;

        public FFmpeg(PictureBox pictureBox, string codec)
        {
            this.codec = codec;
            this.pictureBox = pictureBox;
        }

        public void Start(string url)
        {
            _ = StartAsync(url);
        }

        public async Task StartAsync(string url)
        {
            Stop();

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "ffmpeg.exe",
                    Arguments = $"-i {url} -f image2pipe -vcodec {codec} -",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }

            await Task.Run(() =>
            {
                try
                {
                    using (var reader = new BinaryReader(process.StandardOutput.BaseStream))
                    {
                        var buffer = new List<byte>();
                        cancellationTokenSource = new CancellationTokenSource();
                        while (!cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            var byteData = reader.ReadByte();
                            buffer.Add(byteData);

                            if (buffer.Count >= 2 && buffer[buffer.Count - 2] == 0xFF && buffer[buffer.Count - 1] == 0xD9)
                            {
                                using (var ms = new MemoryStream(buffer.ToArray()))
                                {
                                    var image = Image.FromStream(ms);
                                    pictureBox.InvokeAction(() =>
                                    {
                                        pictureBox.ThreadSafeSetImage(image, sync);
                                    });
                                }

                                buffer.Clear();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }).ContinueWith((t) =>
            {
                try
                {
                    pictureBox.InvokeAction(() =>
                    {
                        pictureBox.ThreadSafeClearImage(sync);
                    });
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            });
        }

        public void Stop()
        {
            cancellationTokenSource?.Cancel();
        }

        protected override void DisposeManagedResources()
        {
            cancellationTokenSource?.Dispose();
        }
    }
}
