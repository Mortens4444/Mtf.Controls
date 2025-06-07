using System;
using System.Windows.Forms;
using AxVIDEOCONTROL4Lib;
using Mtf.Controls.Video.ActiveX.Services;
using Mtf.MessageBoxes;

namespace Mtf.Controls.Video.ActiveX
{
    public partial class AxVideoPictureForm : Form
    {
        public AxVideoPictureForm()
        {
            InitializeComponent();
        }

        private void AxVideoPictureForm_Load(object sender, EventArgs e)
        {
            var videoServerIp = "192.168.0.60";
            var camera = "{41AECFF0-E49B-4882-B077-2269FC19C4FC}";
            var username = "1";
            var password = "1";

            axVideoPicture1.onConnectFailed += AxVideoPlayer_ConnectFailed;
            axVideoPicture1.onDisconnect += AxVideoPlayer_Disconnected;
            axVideoPicture1.onConnect += AxVideoPlayer_Connected;
            axVideoPicture1.onError += AxVideoPlayer_ErrorOccurred;
            axVideoPicture1.Connect(videoServerIp, camera, username, password);
        }

        private void AxVideoPlayer_ErrorOccurred(object sender, _DVideoPictureEvents_onErrorEvent e)
        {
            ErrorBox.Show("Error occurred", $"{e.osErrorCode} {e.errorCode}");
        }

        private void AxVideoPlayer_Connected(object sender, EventArgs e)
        {
            InfoBox.Show("Connected", "Successfully connected");
        }

        private void AxVideoPlayer_Disconnected(object sender, EventArgs e)
        {
            InfoBox.Show("Disconnected", "Successfully disconnected");
        }

        private void AxVideoPlayer_ConnectFailed(object sender, _DVideoPictureEvents_onConnectFailedEvent e)
        {
            ErrorBox.Show("Connection failed", VideoServerErrorHandler.GetMessage(e.errorCode));
        }
    }
}
