# FFmpegWindow and FFmpeg Classes Documentation

## Overview
The `FFmpegWindow` and `FFmpeg` classes provide an interface to display and stream video using FFmpeg within a Windows Forms application.

---

## FFmpegWindow Class

### Namespace:
`Mtf.Controls.Video.FFmpeg`

### Inherits From:
`PictureBox`

### Description:
A `PictureBox`-based control that utilizes FFmpeg to display video streams, with options for overlay text and customizable text properties.

### Properties:
| Property         | Type    | Description |
|-----------------|---------|-------------|
| `Codec`         | `Codec` | FFmpeg codec to use for video streaming. Default is `mjpeg`. |
| `OverlayText`   | `string` | Text to display over the video. |
| `OverlayFont`   | `Font`   | Font of the overlay text. Default: Arial, 32pt, Bold. |
| `OverlayBrush`  | `Brush`  | Color of the overlay text. Default: White. |
| `OverlayLocation` | `Point` | Position of the overlay text. Default: (10,10). |

### Methods:
| Method | Description |
|--------|-------------|
| `Start(string resource)` | Starts video streaming from the given resource (URI). |
| `Stop()` | Stops video streaming. |

### Events:
- `OnPaint(PaintEventArgs e)`: Draws the overlay text on the video.

### Constructor:
```csharp
public FFmpegWindow()
```
Initializes the control, setting the background image and creating an FFmpeg instance.

---

## FFmpeg Class

### Namespace:
`Mtf.Controls.Video.FFmpeg`

### Implements:
`IVideoPlayer`

### Description:
Handles video streaming using FFmpeg. It processes video frames and updates the `PictureBox`.

### Properties:
| Property | Type | Description |
|----------|------|-------------|
| `pictureBox` | `PictureBox` | The PictureBox to update with video frames. |

### Methods:
| Method | Description |
|--------|-------------|
| `Start(string url)` | Starts streaming video from the given URL. |
| `Task StartAsync(string url)` | Asynchronous version of `Start()`. |
| `Stop()` | Stops video streaming. |

### Constructor:
```csharp
public FFmpeg(PictureBox pictureBox, Codec codec)
```
Initializes the FFmpeg player with a target `PictureBox` and a specified codec.

### Internal Process:
- Uses an `ffmpeg.exe` process to capture video frames.
- Processes frames and updates the `PictureBox`.
- Uses a `CancellationTokenSource` to manage streaming.

### Disposal:
- Implements `DisposeManagedResources()` to clean up resources.

---

## Usage Example:
```csharp
var ffmpegWindow = new FFmpegWindow();
ffmpegWindow.Start("rtsp://example.com/stream");
```
This starts streaming a video into the `FFmpegWindow` control.

---

## Notes:
- Ensure `ffmpeg.exe` is available in the application directory.
- The class uses threading and must be properly disposed of to prevent memory leaks.
