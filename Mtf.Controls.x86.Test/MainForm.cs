using AxVIDEOCONTROL4Lib;
using Mtf.Controls.x86.Services;
using Mtf.MessageBoxes;
using System.Net;

namespace Mtf.Controls.x86.Test
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            axVideoPlayerWindow1.AxVideoPlayer.ConnectFailed += AxVideoPlayer_ConnectFailed;
            axVideoPlayerWindow1.AxVideoPlayer.Disconnected += AxVideoPlayer_Disconnected;
            axVideoPlayerWindow1.AxVideoPlayer.Connected += AxVideoPlayer_Connected;
            axVideoPlayerWindow1.AxVideoPlayer.ErrorOccurred += AxVideoPlayer_ErrorOccurred;
            axVideoPlayerWindow1.AxVideoPlayer.Start("127.0.0.1", "Kamera 1", "admin", "admin");
            axVideoPlayerWindow1.OverlayText = $"{"127.0.0.1"} - {"Kamera 1"}";
        }

        private void AxVideoPlayer_ErrorOccurred(object? sender, _DVideoPictureEvents_onErrorEvent e)
        {
            //ErrorBox.Show("Error occurred", $"{e.osErrorCode} {e.errorCode}");
        }

        private void AxVideoPlayer_Connected(object? sender, EventArgs e)
        {
            //InfoBox.Show("Connected", "Successfully connected");
        }

        private void AxVideoPlayer_Disconnected(object? sender, EventArgs e)
        {
            //InfoBox.Show("Disconnected", "Successfully disconnected");
        }

        private void AxVideoPlayer_ConnectFailed(object? sender, _DVideoPictureEvents_onConnectFailedEvent e)
        {
            //ErrorBox.Show("Connection failed", VideoServerErrorHandler.GetMessage(e.errorCode));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            axVideoPlayerWindow1.AxVideoPlayer.Stop();
        }
    }
}
