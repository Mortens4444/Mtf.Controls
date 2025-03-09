# VLC Video Player Documentation

## Overview
The `Vlc` class provides an interface for playing video streams using LibVLCSharp, while the `VlcWindow` class extends `VideoView` to create a WinForms control for displaying video content.

## Dependencies
- `LibVLCSharp.Shared`
- `LibVLCSharp.WinForms`
- `Mtf.Controls.Enums`
- `Mtf.Controls.Extensions`
- `Mtf.Controls.Interfaces`
- `System.Drawing`
- `System.Windows.Forms`

---

# Vlc Class

## Namespace
`Mtf.Controls.Video.VLC`

## Description
The `Vlc` class extends `BaseVideoPlayer` and implements `IVideoPlayer`. It is responsible for managing video playback using the LibVLC engine.

### Fields
- `public static readonly LibVLC LibVLC`: Initializes the LibVLC instance with a verbosity level of 2.
- `public event Action<bool> SignalChanged`: Raised when the video signal status changes.
- `public VlcWindow VlcWindow { get; }`: The associated `VlcWindow` instance.
- `private MediaPlayer mediaPlayer`: The media player instance.

### Constructor
```csharp
public Vlc(VlcWindow vlcWindow)
```
Initializes a new `Vlc` instance and associates it with a `VlcWindow`.

### Methods

#### Start(string resource)
```csharp
public void Start(string resource)
```
Starts video playback with default parameters.

#### Start(string resource, bool enableHardwareDecoding, bool mute, bool rtpOverRtsp, int networkCachingMs, int liveCachingMs, Demux demux)
```csharp
public void Start(string resource, bool enableHardwareDecoding = true, bool mute = true, bool rtpOverRtsp = false, int networkCachingMs = 100, int liveCachingMs = 100, Demux demux = Demux.live555)
```
Starts video playback with custom parameters.

#### Stop()
```csharp
public void Stop()
```
Stops video playback.

#### DisposeManagedResources()
```csharp
protected override void DisposeManagedResources()
```
Releases managed resources.

#### Private Methods
- `UnsubscribeEvents()`: Unsubscribes event handlers.
- `StopMediaPlayer()`: Stops and disposes the media player.
- `ConvertColorToVlcInt(Color color)`: Converts a `Color` to VLC integer format.

---

# VlcWindow Class

## Namespace
`Mtf.Controls.Video.VLC`

## Description
The `VlcWindow` class extends `VideoView` to create a WinForms control for displaying video content using VLC.

### Fields
- `private bool disposed`: Indicates whether the control is disposed.
- `private readonly Vlc vlc`: The `Vlc` instance used for playback.

### Properties
- `public string Resource { get; private set; }`
- `public bool EnableHardwareDecoding { get; private set; } = true`
- `public bool Mute { get; private set; } = true`
- `public bool RtpOverRtsp { get; private set; } = false`
- `public int NetworkCachingMs { get; private set; } = 100`
- `public int LiveCachingMs { get; private set; } = 100`
- `public Demux Demux { get; private set; } = Demux.live555`
- `public string OverlayText { get; set; } = String.Empty`
- `public Font OverlayFont { get; set; } = new Font("Arial", 32, FontStyle.Bold)`
- `public Brush OverlayBrush { get; set; } = Brushes.White`
- `public Point OverlayLocation { get; set; } = new Point(10, 10)`

### Constructor
```csharp
public VlcWindow()
```
Initializes a `VlcWindow` instance and sets default values.

### Methods

#### Start(string resource, bool enableHardwareDecoding, bool mute, bool rtpOverRtsp, int networkCachingMs, int liveCachingMs, Demux demux)
```csharp
public void Start(string resource, bool enableHardwareDecoding = true, bool mute = true, bool rtpOverRtsp = false, int networkCachingMs = 100, int liveCachingMs = 100, Demux demux = Demux.live555)
```
Starts video playback with specified parameters.

#### Stop()
```csharp
public void Stop()
```
Stops video playback.

#### Protected Methods
- `OnPaint(PaintEventArgs e)`: Draws overlay text.
- `Dispose(bool disposing)`: Disposes resources.

### Events
- `private void Vlc_SignalChanged(bool signal)`: Handles signal changes.

---

# Usage Example
```csharp
var vlcWindow = new VlcWindow();
vlcWindow.Start("rtsp://example.com/stream");
```
This initializes a `VlcWindow` and starts video streaming from an RTSP source.

---

## Notes
- The `Vlc` class uses `LibVLCSharp` for playback.
- The `VlcWindow` provides an easy-to-use WinForms control for video display.
- Overlay text can be customized via properties.
- Network and live caching values should be within the range [0, 60000] milliseconds.