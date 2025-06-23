#pragma warning disable

using System;
using System.Runtime.InteropServices;

namespace Mtf.Controls.Video.Sunell.IPR67.SunellSdk
{
    public static class Sdk
    {
        private const string SdkDll = "Sdk_C_Sharp_Lib.dll";
        private const CallingConvention CallingConv = CallingConvention.Cdecl;

        [UnmanagedFunctionPointerAttribute(CallingConv)]
        public delegate void SDK_MICROPHONE_CB(IntPtr handle, IntPtr pData, ref Int32 dataLen, IntPtr pObj);

        [UnmanagedFunctionPointerAttribute(CallingConv)]
        public delegate void SDK_FACEBASE_CB(IntPtr handle, IntPtr pData, ref Int32 dataLen, ref IntPtr pResult, IntPtr pObj);

        [UnmanagedFunctionPointerAttribute(CallingConv)]
        public delegate void SDK_INTERCOM_DB_CB(UInt32 db, IntPtr pObj);

        [UnmanagedFunctionPointerAttribute(CallingConv)]
        public delegate void SDK_FACE_CB(IntPtr handle, Int32 pic_type, IntPtr pData, ref Int32 dataLen, ref IntPtr pResult, IntPtr pObj);

        [UnmanagedFunctionPointerAttribute(CallingConv)]
        public delegate void SDK_DETECT_CB(IntPtr handle, Int32 streamId, ref IntPtr pResult, IntPtr pData, IntPtr pObj);

        [UnmanagedFunctionPointerAttribute(CallingConv)]
        public delegate void SDK_STREAM_DATE_LEN(UInt32 len);

        [UnmanagedFunctionPointer(CallingConv)]
        public delegate void SDK_PLAY_TIME_CB(IntPtr handle, int streamId, IntPtr pObj, ref IntPtr pTime);

        //[UnmanagedFunctionPointerAttribute(CallingConv)]
        //public delegate void SDK_PLAY_TIME_CB(IntPtr handle, Int32 streamId, IntPtr pObj, ref IntPtr pTime);

        [UnmanagedFunctionPointerAttribute(CallingConv)]
        public delegate void SDK_CONNECT_CB(IntPtr handle, IntPtr pObj);

        [UnmanagedFunctionPointerAttribute(CallingConv)]
        public delegate void SDK_DISCONN_CB(IntPtr handle, IntPtr pObj, UInt32 type);

        [UnmanagedFunctionPointerAttribute(CallingConv)]
        public delegate void SDK_STREAM_CB(IntPtr handle, Int32 streamId, IntPtr pData, IntPtr pObj);

        [UnmanagedFunctionPointerAttribute(CallingConv)]
        public delegate void SDK_ALARM_CB(IntPtr handle, ref IntPtr pData, IntPtr pObj);

        [UnmanagedFunctionPointerAttribute(CallingConv)]
        public delegate void SDK_WIFI_CB(IntPtr handle, ref byte pData, IntPtr pObj);

        public delegate void SDK_MUTI_COMPARE_CB(IntPtr handle, IntPtr pPic1, Int32 dataLen1, IntPtr pPic2, Int32 dataLen2, IntPtr pResult, IntPtr pObj);

        public delegate void SDK_NVR_SNAP_MSG_CB(IntPtr handle, IntPtr pData, IntPtr pObj);

        public delegate void SDK_MUTI_OBJ_DOWNLOAD_CB(IntPtr handle, IntPtr pPic1, Int32 dataLen1, ref byte key1, IntPtr pPic2, Int32 dataLen2, ref byte key2, IntPtr pObj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern IntPtr sdk_dev_conn([MarshalAs(UnmanagedType.LPStr)] string p_ip, UInt16 port, [MarshalAs(UnmanagedType.LPStr)] string p_user, [MarshalAs(UnmanagedType.LPStr)] string p_passwd, [MarshalAs(UnmanagedType.FunctionPtr)] SDK_DISCONN_CB disconn_cb_func, IntPtr pObj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_live_start(IntPtr handle, Int32 chn, StreamType streamType, IntPtr p_wnd, bool is_hw_dec, [MarshalAs(UnmanagedType.FunctionPtr)] SDK_PLAY_TIME_CB play_cb, IntPtr pObj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_live_stop(IntPtr handle, Int32 streamId);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_chg_stream(IntPtr handle, Int32 streamId, StreamType streamType);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_pb_start(IntPtr handle, Int32 chn, Int32 newStreamType, [MarshalAs(UnmanagedType.LPStr)] string s_time, IntPtr p_wnd, bool is_hw_dec, [MarshalAs(UnmanagedType.FunctionPtr)] SDK_PLAY_TIME_CB play_cb, IntPtr pObj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_pb_seek(IntPtr handle, Int32 streamId, [MarshalAs(UnmanagedType.LPStr)] string time);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_pb_pause(IntPtr handle, Int32 streamId);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_pb_resume(IntPtr handle, Int32 streamId);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_pb_stop(IntPtr handle, Int32 streamId);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_set_pb_speed(IntPtr handle, Int32 streamId, Int32 rate);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_rec_start(IntPtr handle, Int32 streamId, [MarshalAs(UnmanagedType.LPStr)] string p_path, [MarshalAs(UnmanagedType.LPStr)] string p_filename);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_rec_start_width_time(IntPtr handle, Int32 streamId, [MarshalAs(UnmanagedType.LPStr)] string s_time, [MarshalAs(UnmanagedType.LPStr)] string e_time, [MarshalAs(UnmanagedType.LPStr)] string p_path, [MarshalAs(UnmanagedType.LPStr)] string p_filename);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_rec_stop(IntPtr handle, Int32 streamId);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_rec_percent(IntPtr handle, Int32 streamId);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_rec_download_start(IntPtr handle, Int32 chn, Int32 streamType, [MarshalAs(UnmanagedType.LPStr)] string s_time, [MarshalAs(UnmanagedType.LPStr)] string e_time, [MarshalAs(UnmanagedType.LPStr)] string p_path, [MarshalAs(UnmanagedType.LPStr)] string p_filename);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_rec_download_stop(IntPtr handle, Int32 streamId);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_capture(IntPtr handle, Int32 streamId, [MarshalAs(UnmanagedType.LPStr)] string p_path);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_audio_start(IntPtr handle, Int32 streamId);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_audio_stop(IntPtr handle, Int32 streamId);
        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_talk_start(IntPtr handle, Int32 chn, SDK_INTERCOM_DB_CB intercom_db_cb, IntPtr obj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_md_talk_stop(IntPtr handle, Int32 chn);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_view_zoomin(IntPtr handle, Int32 streamId, Int32 x, Int32 y, Int32 w, Int32 h);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_view_zoominout_centern(IntPtr handle, Int32 streamId, Int32 scale);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_init([MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern void sdk_dev_quit();

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern void sdk_free_result(IntPtr pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern UInt32 sdk_dev_conn_ssl([MarshalAs(UnmanagedType.LPStr)] string p_ip, UInt16 port, [MarshalAs(UnmanagedType.LPStr)] string p_user, [MarshalAs(UnmanagedType.LPStr)] string p_passwd, [MarshalAs(UnmanagedType.FunctionPtr)] SDK_DISCONN_CB disconn_cb_func, IntPtr pObj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_con_sta(UInt32 handle);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_conn_async([MarshalAs(UnmanagedType.LPStr)] string p_ip, UInt16 port, [MarshalAs(UnmanagedType.LPStr)] string p_user, [MarshalAs(UnmanagedType.LPStr)] string p_passwd, [MarshalAs(UnmanagedType.FunctionPtr)] SDK_DISCONN_CB disconn_cb, [MarshalAs(UnmanagedType.FunctionPtr)] SDK_CONNECT_CB conn_cb, IntPtr pObj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern void sdk_dev_conn_close(UInt32 handle);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_addr_req(IntPtr handle, Int32 ipprotover, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_live_start(IntPtr handle, Int32 chn, Int32 streamType, [MarshalAs(UnmanagedType.FunctionPtr)] SDK_STREAM_CB stream_cb, IntPtr pObj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_live_stop(IntPtr handle, Int32 streamId);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_chg_stream(IntPtr handle, Int32 streamId, Int32 newStreamType);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_video_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_video_param(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pVideoParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_video_control(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pAudioParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_audio_start(IntPtr handle, Int32 streamId);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_audio_stop(IntPtr handle, Int32 streamId);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_open_snap(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pSnapParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_close_snap(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pSnapParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_snap_data(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pSnapParam, ref byte pBuf, ref int len);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_snap_picture(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pSnapParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_open_picture_edit(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pSnapParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_pb_date_list(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string s_date, [MarshalAs(UnmanagedType.LPStr)] string e_date, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_pb_chns_in_date(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_date, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_pb_get_rec_list(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string p_date, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_pb_start(IntPtr handle, Int32 chn, Int32 streamType, [MarshalAs(UnmanagedType.LPStr)] string s_time, [MarshalAs(UnmanagedType.LPStr)] string e_time, [MarshalAs(UnmanagedType.FunctionPtr)] SDK_STREAM_CB stream_cb, IntPtr pObj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_pb_seek(IntPtr handle, Int32 streamId, [MarshalAs(UnmanagedType.LPStr)] string time);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_pb_pause(IntPtr handle, Int32 streamId);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_pb_resume(IntPtr handle, Int32 streamId);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_pb_stop(IntPtr handle, Int32 streamId);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_pb_video_param(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_pb_video_speed(IntPtr handle, Int32 streamId, Int32 rate);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_open_rec([MarshalAs(UnmanagedType.LPStr)] string p_path, [MarshalAs(UnmanagedType.LPStr)] string p_filename);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_record(Int32 record_id, ref tagAVFrameData p_frame);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_stop_rec(Int32 record_id);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_start_alarm(IntPtr handle, [MarshalAs(UnmanagedType.FunctionPtr)] SDK_ALARM_CB alarm_cb, IntPtr pObj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_stop_alarm(UInt32 handle);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_io_alarm_event(IntPtr handle, Int32 chn, Int32 alarm_source_id, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_set_io_alarm_para(IntPtr handle, ref _io_alarm_event_para_list_ p_io_alarm_para);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_json_set_io_alarm_para(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_io_alarm_para);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_json_set_disk_alarm_para(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_disk_alarm_para);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_set_disk_alarm_para(IntPtr handle, ref _disk_alarm_event_para_list_ p_disk_alarm_list);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_disk_alarm_para(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_match_alarm_date_list(IntPtr handle, ref _qry_info_list_ p_qry_info, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_json_get_match_alarm_date_list(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_qry_info, [MarshalAs(UnmanagedType.LPStr)] string s_time, [MarshalAs(UnmanagedType.LPStr)] string e_time, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_alarm_camera_info_list(IntPtr handle, ref _alarm_info_qry_ p_qry_info, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_json_get_alarm_camera_info_list(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string s_time, [MarshalAs(UnmanagedType.LPStr)] string e_time, [MarshalAs(UnmanagedType.LPStr)] string p_alarm_info_qry, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_alarm_list(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string s_time, [MarshalAs(UnmanagedType.LPStr)] string e_time, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_manual_alarmout(IntPtr handle, Int32 chn, Int32 alarmout_id, Int32 control_flag);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_record_policy(IntPtr handle, Int32 chn, Int32 record_mode, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_set_record_policy(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string p_record_para);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_record_state(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_last_record_time(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string s_time, [MarshalAs(UnmanagedType.LPStr)] string e_time, [MarshalAs(UnmanagedType.LPStr)] string p_qry_info, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_open_wifi_push(IntPtr handle, [MarshalAs(UnmanagedType.FunctionPtr)] SDK_WIFI_CB wifi_cb, IntPtr pObj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_close_wifi_push(UInt32 handle);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_open_ptz(UInt32 handle);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_close_ptz(UInt32 handle);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_ptz_stop(IntPtr handle, Int32 chn);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_ptz_rotate(IntPtr handle, Int32 chn, Int32 operation, Int32 speed);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_ptz_zoom(IntPtr handle, Int32 chn, Int32 operation, Int32 speed);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_ptz_focus(IntPtr handle, Int32 chn, Int32 operation);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_ptz_iris(IntPtr handle, Int32 chn, Int32 operation);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_ptz_preset(IntPtr handle, Int32 chn, Int32 id, Int32 operation);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_ptz_track(IntPtr handle, Int32 chn, Int32 id, Int32 operation);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_ptz_scan(IntPtr handle, Int32 chn, Int32 id, Int32 operation);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_ptz_tour(IntPtr handle, Int32 chn, Int32 id, Int32 operation, Int32 speed, Int32 time);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_ptz_keeper(IntPtr handle, Int32 chn, Int32 operation, Int32 enable, Int32 type, Int32 id, Int32 time);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_ptz_threeDimensionalPos(IntPtr handle, Int32 chn, Int32 nX, Int32 nY, Int32 nZoomaTate);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_ptz_brush(IntPtr handle, Int32 chn, Int32 operation, Int32 mode, Int32 waittime);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_ptz_light(IntPtr handle, Int32 chn, Int32 operation);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_ptz_defog(IntPtr handle, Int32 chn, Int32 operation);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_ptz_postion(IntPtr handle, Int32 chn, Int32 operation, Int32 type, Int32 p_nPan, Int32 p_nTilt, Int32 p_nZoom);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_ptz_req(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_ptz_postion(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_set_ptz_speed(IntPtr handle, Int32 chn, Int32 speed);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_ptz_configue(IntPtr handle, Int32 chn, Int32 operation, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_ptz_timer(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_set_ptz_timer(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_json_get_hw_cap(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_json_get_sw_cap(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_nw_cap(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_video_cap(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_nvr_cap(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_language_cap(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_time_zone_cap(IntPtr handle, Int32 chn, Int32 language_id, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_json_get_audio_cap(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_ptz_cap(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_osd_cap(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_json_get_general_info(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_json_get_dev_name(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_json_set_dev_name(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_dev_name);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_json_get_dev_time(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_json_set_dev_time(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pDevTime);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_json_get_dev_ntp(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_json_set_dev_ntp(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_ntpParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_dev_id(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_set_dev_id(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string p_dev_id);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_json_get_dev_port(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_json_set_dev_port(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_dev_port);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_dev_language(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_set_dev_language(IntPtr handle, Int32 chn, Int32 language_id);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_dev_time_zone(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_dev_time_zone(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pDevTime);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_chn_info(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_p2p_para(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_set_alarm_push_para(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pAlarmPushParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_delete_alarm_push_para(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pAlarmPushParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_security_para(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_set_security_para(IntPtr handle, Int32 webMode, byte encryptEnable);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_nvr_channel_name(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_net_param(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_set_net_param(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pNetParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_ddns(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_set_ddns(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pNetDdns);

        //[DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        // public static extern Int32 sdk_dev_ddns_test(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)]string pNetDdns);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_ddns_provider(IntPtr handle, Int32 chn, ref byte pResult);

        //FTP参数
        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_ftp(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_set_ftp(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pNetFtp);

        //[DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        //  public static extern Int32 sdk_dev_ftp_test(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)]string p_ftp_para);
        //SMTP参数
        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_smtp(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_set_smtp(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pNetSmtp);

        //  [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        // public static extern Int32 sdk_dev_smtp_test(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)]string p_smtp);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_mtu(IntPtr handle, ref Int32 pMtu);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_set_mtu(IntPtr handle, Int32 pMtu);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_osd_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_osd_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pOsdParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_blind_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_blind_param(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_blind_param);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_svc_stream_para(IntPtr handle, Int32 chn, Int32 streamId, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_roi_param(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_roi_param(IntPtr handle, Int32 chn, Int32 stream, [MarshalAs(UnmanagedType.LPStr)] string p_roi_param);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_mot_param(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_mot_param(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_mot_param);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ip_filter_param(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_ip_filter_param(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_ipParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_dev_list(ref byte p_json_out);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_protocol_security_param(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_protocol_security_param(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_protocol_security_param);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_modify_password_param(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_system_user_param);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_create_login_password_param(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_creat_login_password_param);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_operator_privilege_user(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string p_user_list, ref byte pResult);


        //sensor
        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_reset_sensor_param(IntPtr handle, Int32 chn);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_save_sensor_param(IntPtr handle, Int32 chn);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_reset_sensor_to_last_param(IntPtr handle, Int32 chn);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_sensor_param(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_sensor_para);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_sensor_param(IntPtr handle, Int32 chn, ref byte pResult);

        // [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        //   public static extern Int32 sdk_dev_abb_add_user_info(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)]string p_abb_user_info);

        //  [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        //  public static extern Int32 sdk_dev_abb_delete_user_info(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)]string p_abb_user_info);

        //  [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        //public static extern Int32 sdk_dev_abb_modify_user_info(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)]string p_abb_user_info);

        //[DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        // public static extern Int32 sdk_dev_abb_check_user_info(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)]string p_abb_user_info);

        //[DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        //  public static extern Int32 sdk_dev_abb_update_param(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)]string p_abb_user_info);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_reboot(IntPtr handle, Int32 chn);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_reset(IntPtr handle, Int32 chn, Int32 type);

        //热成像

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_thermal_cap(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_thermal_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string p_abb_user_info);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_thermal_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_thermal_area_temperature_measure(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_thermal_area_temperature_measure(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pParam, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_thermal_area_feature_temperature(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pParam, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_thermal_one_point_temperature(IntPtr handle, Int32 chn, Int32 x, Int32 y, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_thermal_any_point_temperature(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_map_relation(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_map_relation(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_temperature_calibration(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_temperature_calibration(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_thermal_version(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_test_thermal_bad_point_correct(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_thermal_bad_point_correct(IntPtr handle, Int32 chn);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_reset_thermal_bad_point_correct(IntPtr handle, Int32 chn);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_thermal_alarm_linkage_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_thermal_alarm_linkage_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_thermal_measurement_parameter(IntPtr handle, int channel, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_thermal_measurement_parameter(IntPtr handle, int channel, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_thermal_live_start(IntPtr handle, Int32 chn, Int32 streamType, [MarshalAs(UnmanagedType.FunctionPtr)] SDK_DETECT_CB detect_cb, IntPtr pObj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_thermal_live_stop(IntPtr handle, Int32 streamId);



        //人脸接口
        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_face_detect_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_face_detect_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_face_detect_start(IntPtr handle, Int32 chn, Int32 streamType, Int32 type, [MarshalAs(UnmanagedType.FunctionPtr)] SDK_DETECT_CB detect_cb, IntPtr pObj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_face_detect_stop(IntPtr handle, Int32 streamId);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_face_get_group_num(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_face_get_member(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_face_check_data(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_face_get_statis(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_face_get_attendance_data(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam, [MarshalAs(UnmanagedType.LPStr)] string path_file);


        //[DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        // public static extern Int32 sdk_start_database(IntPtr handle, [MarshalAs(UnmanagedType.FunctionPtr)]SDK_FACEBASE_CB facebase_cb_func, IntPtr pObj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_database_index(IntPtr handle, Int32 chn, byte[] face_data, Int32 size, [MarshalAs(UnmanagedType.LPStr)] string param, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_get_database_info(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        //[DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        //public static extern Int32 sdk_stopDatabase(UInt32 handle);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_start_face(IntPtr handle, [MarshalAs(UnmanagedType.FunctionPtr)] SDK_FACE_CB face_cb, IntPtr pObj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_stop_face(UInt32 handle);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_face_get_group(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_face_add_group(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_db_info);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_face_del_group(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_db_info);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_face_rename_group(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_db_info);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_face_get_group_type(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_face_add_group_type(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_db_info);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_face_del_group_type(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_db_info);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_face_all_node(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pParam, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_face_by_node(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_info);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_channel_type(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_channel_type(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_lpr_detect_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_lpr_detect_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_lpr_link_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_lpr_link_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_lpr_ipfilter_list_add(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_lpr_ipfilter_list_delete(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_lpr_ipfilter_list_modify(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_lpr_ipfilter_list_num(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_lpr_ipfilter_list(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_lpr_ipfilter_list_search_open(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_lpr_ipfilter_list_search_get(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_lpr_ipfilter_list_search_close(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        // [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        //  public static extern Int32 sdk_lpr_ipfilter_list_file_upload(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)]string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_lpr_ipfilter_list_file_download(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ai_multi_object_detect_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_ai_multi_object_detect_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ai_multi_object_detect_ability(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_device_log(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pParam, ref IntPtr pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_version(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_perimeter_ability(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_svf_ability(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_dvf_ability(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_loiter_ability(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_multi_loiter_ability(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_object_left_ability(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_object_removed_ability(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_abnormal_speed_ability(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_converse_ability(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_legal_parking_ability(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_signal_bad_ability(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_advanced_ability(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_perimeter_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_ia_perimeter_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_svf_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_ia_svf_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_dvf_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_ia_dvf_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_loiter_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_ia_loiter_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_multi_loiter_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_ia_multi_loiter_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_object_left_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_ia_object_left_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_object_removed_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_ia_object_removed_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_abnormal_speed_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_ia_abnormal_speed_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_converse_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_ia_converse_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_legal_parking_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_ia_legal_parking_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_signal_bad_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_ia_signal_bad_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_ia_advanced_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_ia_advanced_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_fisheye_ability(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_fisheye_param(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_fisheye_param(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_fisheye_video_layout(IntPtr handle, Int32 chn, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_open_microphone(IntPtr handle, [MarshalAs(UnmanagedType.FunctionPtr)] SDK_MICROPHONE_CB microphone_cb, IntPtr pObj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_dev_send_audio_data(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pParam, Int32 audio_len);
        // public static extern Int32 sdk_dev_send_audio_data(IntPtr handle, IntPtr  pParam, Int32 audio_len);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_close_microphone(IntPtr handle, Int32 audio_id);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_wifi_conn_hots(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_disk_format(IntPtr handle, Int32 chn, Int32 diskid);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 format(Int32 chn);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_update_ipc(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_path);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_update_nvr(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string p_path);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_mutil_object_downlow_pic_open(IntPtr handle, [MarshalAs(UnmanagedType.FunctionPtr)] SDK_MUTI_OBJ_DOWNLOAD_CB cb, IntPtr pObj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_nvr_realtime_compare_start(IntPtr handle, Int32 chn, [MarshalAs(UnmanagedType.LPStr)] string pParam, [MarshalAs(UnmanagedType.FunctionPtr)] SDK_MUTI_COMPARE_CB detect_cb, IntPtr pObj);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_group_compare_alarm_strategy_param(IntPtr handle, Int32 stratege_type, [MarshalAs(UnmanagedType.LPStr)] string pParam, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_group_compare_alarm_strategy_param(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_person_temperature_strategy(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_person_temperature_strategy(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_get_mask_detect_strategy(IntPtr handle, ref byte pResult);

        [DllImport(SdkDll, CharSet = CharSet.Ansi, CallingConvention = CallingConv)]
        public static extern Int32 sdk_set_mask_detect_strategy(IntPtr handle, [MarshalAs(UnmanagedType.LPStr)] string pParam);

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _time_struct_
        {
            public Int32 time_zone;              //时区
            public UInt16 day_light_saving_time;   //夏令营时
            public UInt16 year;                    //年
            public UInt16 month;                   //月[1,12]
            public UInt16 day;                 //日[1,31]
            public UInt16 day_of_week;             //星期几[0,6]
            public UInt16 hour;                    //时[0,23]
            public UInt16 minute;              //分[0,59]
            public UInt16 second;              //秒[0,59]
            public Int32 milli_seconds;          //微妙[0,1000000]
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _alarm_info_qry_
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string dev_ip;                    //设备IP
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
            public string dev_id;
            public Int32 source_id;  //报警源Id
            public Int32 select_mode;    //查询模式 :SELECT_MODE_ALL
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string source_name; //源名称
            public Int32 major_type; //报警主类型
            public Int32 minor_type; //报警子类型
            public UInt32 alarm_begin_time; //查询开始时间
            public _time_struct_ alarm_begin_time_struct;
            public UInt32 alarm_end_time;   //查询结束时间
            public _time_struct_ alarm_end_time_struct;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _alarm_action_
        {
            public Int32 action_type;    //报警源类型
            public Int32 action_id;      //报警源ID
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string action_name;     //报警源名称
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _schedule_time_
        {
            public Int32 week_day;
            public UInt32 start_time;
            public UInt32 end_time;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _schedule_time_list_
        {
            public Int32 schedule_time_count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public _schedule_time_[] time_list;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _io_alarm_insource_para_
        {
            public _alarm_action_ alarm_act;
            public Byte enable_flag;  //开启标记
            public Int32 alarm_inval;    //报警间隔
            public Int32 valid_level;    //有效电平
            public _schedule_time_list_ schedule_para;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _alarm_link_t_
        {
            public Int32 action_type;
            public Int32 action_id;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _ptz_action_param_
        {
            public Int32 ptz_action_type;    //操作类型（预置位、轨迹等）
            public Int32 ptz_action_id;      //操作ID（用户之前设置的预置位ID、轨迹ID等）
            public Int32 ptz_channel_id;     //PTZ通道ID
            public _alarm_action_ alarm_act;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _alarm_out_param_
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
            public string dev_id;       //设备id
            public Int32 alarm_out_id;   //报警输出端口的ID号
            public Int32 alarm_out_flag; //报警输出标志          
            public Int32 event_type_id;  //报警事件类型
            public Int32 alarm_time;     //报警输出时间
            public _alarm_action_ alarm_act;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _record_act_param_
        {
            public Byte pre_record_flag; //是否开启预录
            public Int32 delay_record_time;  //延录制时长
            public _alarm_action_ alarm_act;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _io_alarm_event_para_
        {
            public _io_alarm_insource_para_ insource_para;
            public Int32 linkage_param_count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public _alarm_link_t_[] link_param_list;
            public Int32 ptz_action_action_param_list_count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public _ptz_action_param_[] ptz_param_list;
            public Int32 alarm_out_count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public _alarm_out_param_[] alarm_out_list;
            public Int32 record_action_param_list_count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public _record_act_param_[] record_action_list;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _io_alarm_event_para_list_
        {
            public Int32 alarm_event_list_count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public _io_alarm_event_para_[] alarm_event_list;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _disk_alarm_source_para_
        {
            public _alarm_action_ alarm_act;
            public UInt16 enable_flag;   //是否启动磁盘报警(false：不启动， true：启动)
            public Int32 alarm_inval;    //上报间隔，单位为秒，最小间隔为10秒，最大为86400秒(1天)
            public Int32 alarm_thresold; //报警阈值, 单位为百分比
            public UInt16 disk_full_enable_flag;
            public UInt16 disk_error_enable_flag;
            public UInt16 no_disk_enable_flag;
            public _schedule_time_list_ schedule_para;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _disk_alarm_event_para_
        {
            public _disk_alarm_source_para_ disk_alarm_source;
            public Int32 linkage_param_count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public _alarm_link_t_[] link_param_list;
            public Int32 ptz_action_action_param_list_count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public _ptz_action_param_[] ptz_param_list;
            public Int32 alarm_out_count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public _alarm_out_param_[] alarm_out_list;
            public Int32 record_action_param_list_count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public _record_act_param_[] record_action_list;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _disk_alarm_event_para_list_
        {
            public Int32 disk_alarm_event_count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public _disk_alarm_event_para_[] disk_alarm_event_list;
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _qry_info_
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
            public string dev_id;       //设备ID
            public Int32 channel_id;    //通道号
            public Int32 record_mode;   //查询模式(录像查询or快照查询)
            public Int32 select_mode;   //查询模式(0:所有；1：按类型查询；2：按时间查询)
            public Int32 major_type;    //主类型
            public Int32 minor_type;    //次类型
            public Int32 precision;     //精度
            public Int32 record_segment_interval;        //查询段时间长度（每段最长时间跨度）
            public _time_struct_ begin_time;             //开始时间
            public _time_struct_ end_time;               //结束时间
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct _qry_info_list_
        {
            public Int32 qry_info_count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public _qry_info_[] qry_info_list;
        }
    }
}

#pragma warning restore