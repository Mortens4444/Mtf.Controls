namespace Mtf.Controls.Enums
{
    public enum CameraType
    {
        Accord_JPEG,

        /// <summary>
        /// http://camera.buffalotrace.com/mjpg/video.mjpg
        /// </summary>
        Accord_MJPEG,

        /// <summary>
        /// null
        /// </summary>
        Accord_ScreenCapture,

        AForge_JPEG,

        /// <summary>
        /// http://takemotopiano.aa1.netvolante.jp:8190/nphMotionJpeg?Resolution=640x480&Quality=Standard&Framerate=30
        /// </summary>
        AForge_MJPEG,

        /// <summary>
        /// null
        /// </summary>
        AForge_ScreenCapture,

        /// <summary>
        /// @device:pnp:\\?\usb#vid_0408&pid_a061&mi_00#6&7b94699&0&0000#{65e8773d-8f56-11d0-a3b9-00a0c9223196}\global
        /// </summary>
        AForge_VideoCaptureDevice,

        AxVideoPicture,

        /// <summary>
        /// http://ceronit:99/avi.cgi?file=t5.avi?req_fps=25?start=200
        /// </summary>
        Chromium,

        /// <summary>
        /// http://takemotopiano.aa1.netvolante.jp:8190/nphMotionJpeg?Resolution=640x480&Quality=Standard&Framerate=30
        /// </summary>
        FFmpeg,

        /// <summary>
        /// http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4
        /// </summary>
        VLC,

        /// <summary>
        /// rtsp://62.109.19.230:554/iloveyou
        /// </summary>
        OpenCvSharp,

        /// <summary>
        /// Custom way to get a JPEG frame from a device
        /// http://camera.buffalotrace.com/mjpg/video.mjpg
        /// </summary>
        MortoGraphy
    }
}
