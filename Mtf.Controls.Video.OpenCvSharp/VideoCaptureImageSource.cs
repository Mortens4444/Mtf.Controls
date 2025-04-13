using Mtf.Network.Interfaces;
using OpenCvSharp;
using System.Threading;
using System.Threading.Tasks;

namespace Mtf.Controls.Video.OpenCvSharp
{
    public class VideoCaptureImageSource : IImageSource
    {
        private readonly VideoCapture videoCapture;

        public VideoCaptureImageSource(VideoCapture videoCapture)
        {
            this.videoCapture = videoCapture;
        }

        public Task<byte[]> CaptureAsync(CancellationToken token)
        {
            using (var frame = new Mat())
            {
                if (videoCapture.Read(frame) && !frame.Empty())
                {
                    //var imageBytes = frame.ToBytes(".png");
                    //return Task.FromResult(imageBytes);
                    return Task.FromResult(frame.ToBytes(".png",
                        new ImageEncodingParam(ImwriteFlags.PngCompression, 9),
                        new ImageEncodingParam(ImwriteFlags.PngStrategy, (int)ImwritePNGFlags.StrategyRLE)
                    ));
                }
                else
                {
                    videoCapture.PosFrames = 0;
                }
            }
            return Task.FromResult<byte[]>(null);
        }
    }
}
