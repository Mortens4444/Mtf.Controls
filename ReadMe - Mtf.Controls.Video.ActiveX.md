# 📺 **Mtf.Controls.Video.ActiveX.AxVideoPlayerWindow**

This `UserControl` encapsulates an ActiveX-based video player that contains an `AxVideoPicture` object and a custom `AxVideoPlayer` control. It also supports displaying custom text overlayed on the video.

## Key Features:

| Property          | Type             | Description                                      |
| ----------------- | ---------------- | ------------------------------------------------ |
| `AxVideoPicture`  | `AxVideoPicture` | The ActiveX control instance.                    |
| `AxVideoPlayer`   | `AxVideoPlayer`  | A custom video player control for easier usage.  |
| `OverlayText`     | `string`         | The text displayed over the video.               |
| `OverlayFont`     | `Font`           | Font used for rendering the overlay text.        |
| `OverlayBrush`    | `Brush`          | Brush used to color the overlay text.            |
| `OverlayLocation` | `Point`          | Location of the overlay text within the control. |

## Usage:

```csharp
var player = new AxVideoPlayerWindow
{
    OverlayText = "CAM 1",
    OverlayFont = new Font("Segoe UI", 24, FontStyle.Bold),
    OverlayBrush = Brushes.Red,
    OverlayLocation = new Point(20, 20)
};
```

The text is rendered using `Graphics.DrawString` inside the `pictureBox.Paint` event.

---

# 🧬 **Mtf.Controls.Video.ActiveX.Services.ShallowCopyHelper**

This helper class allows you to create a **shallow copy** of any object. It copies fields and accessible properties into a new instance.

## API:

```csharp
public static T ShallowCopy<T>(T source) where T : new()
```

## Example:

```csharp
var clone = ShallowCopyHelper.ShallowCopy(existingObject);
```

## Notes:

* This is **not** a deep copy — object references are copied as-is.
* Both private and public fields are copied.
* Read-only properties are ignored.
* Property copy operations are wrapped in a `try-catch` to avoid interruptions caused by exceptions from getters or setters.

---

# ⚠️ **Mtf.Controls.Video.ActiveX.Services.VideoServerErrorHandler**

A static class containing video server-related error codes and their human-readable messages.

## Usage:

```csharp
var message = VideoServerErrorHandler.GetMessage(errorCode);
```

## Supported Error Codes:

| Constant Name                   | Value | Meaning                               |
| ------------------------------- | ----- | ------------------------------------- |
| `Success`                       | 0     | Operation successful                  |
| `WrongCameraName`               | 3001  | Invalid camera name                   |
| `LowVirtualMemory`              | 3003  | Low virtual memory                    |
| `ConnectionLost`                | 3004  | Connection lost                       |
| `HardwareError`                 | 3009  | Hardware failure                      |
| `WrongCredentials`              | 3012  | Invalid authentication credentials    |
| `NetworkError`                  | 3018  | RPC network error                     |
| `ConnectionFailed`              | 3019  | Remote video server is not responding |
| `PermissionError`               | 3026  | Permission or version error           |
| `TimeoutErrorCode`              | 4000  | Connection timeout                    |
| `NoVideoServerCredentialsFound` | 4001  | Missing credentials                   |
| `UnknownErrorOccurred`          | 4002  | Unknown error                         |
| `NoResult`                      | 4003  | No result                             |
| *(other)*                       | -     | Unknown error (displays raw code)     |


# AxVideoPlayer

The `AxVideoPlayer` class is a C# wrapper for working with the `AxVideoPicture` ActiveX control, typically used for live video streaming, playback, and camera control in a Windows Forms environment.

---

## Namespace

```csharp
Mtf.Controls.Video.ActiveX
```

---

## Dependencies

```csharp
using AxVIDEOCONTROL4Lib;
using Mtf.MessageBoxes;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
```

---

## Constructor

### `AxVideoPlayer(AxVideoPlayerWindow axVideoPlayerWindow)`

Initializes a new instance of the `AxVideoPlayer` class using the specified `AxVideoPlayerWindow` that contains the `AxVideoPicture` control.

---

## Events

* `FrameArrived`: Raised when a new video frame is available.
* `Connected`: Raised when the video successfully connects.
* `Disconnected`: Raised when the video disconnects.
* `ConnectFailed`: Raised when the connection to the video fails.
* `ErrorOccurred`: Raised when an error occurs in the video control.

---

## Properties

| Property         | Type             | Description                            |
| ---------------- | ---------------- | -------------------------------------- |
| `AxVideoPicture` | `AxVideoPicture` | Underlying ActiveX control instance.   |
| `IpAddress`      | `string`         | IP address of the video source.        |
| `Camera`         | `string`         | Camera ID or name.                     |
| `Username`       | `string`         | Username for authentication.           |
| `Password`       | `string`         | Password for authentication.           |
| `Light`          | `short?`         | Light level setting.                   |
| `Millisec`       | `short?`         | Millisecond part of timestamp.         |
| `Motion`         | `short?`         | Motion detection sensitivity.          |
| `OSD`            | `bool?`          | On-screen display toggle.              |
| `PlayStatus`     | `short?`         | Current playback status.               |
| `Image`          | `Image`          | Captured image from the video.         |
| `DisplayImage`   | `bool?`          | Whether to display the captured image. |
| `ShowDateTime`   | `bool?`          | Whether to overlay date/time on video. |
| `Speed`          | `short?`         | Playback speed.                        |
| `Time`           | `DateTime?`      | Current time of the video frame.       |

---

## Methods

### Initialization & Control

* `Start(...)`: Starts the connection to the video stream.
* `StartAsync(...)`: Asynchronously starts the connection.
* `Stop()`: Stops the video connection.
* `StopAxVideoPicture()`: Stops the internal video control.
* `EnableDeblock(bool enable)`: Enables or disables deblocking.
* `EnableThreading(bool enable)`: Enables or disables internal threading.

### Video Playback

* `LiveVideo(int layer = 0, int frameRate = 25)`: Starts live streaming.
* `Play()`: Starts video playback.
* `PlayReverse()`: Starts reverse playback.
* `Next()`, `Prev()`, `First()`, `Last()`: Navigation controls.
* `Find(DateTime dateTime)`: Finds a specific timestamp in the video.

### Camera Controls

* `CameraMove(...)`, `CameraZoom(...)`, `CameraFocus(...)`, etc.: Control PTZ (Pan-Tilt-Zoom) functionality.
* `CameraStop()`: Stops all camera movements.
* `CameraGoToPreset(...)`: Moves the camera to a preset position.
* `CameraRunPattern(...)`: Runs a camera movement pattern.

### Status & Info

* `IsConnected()`: Checks if the video is connected.
* `IsVideoSignal()`: Checks if a video signal is present.
* `IsCameraControl()`: Checks if camera control is supported.
* `WaitForConnect(...)`, `WaitForDisconnect(...)`: Waits for connection state change.
* `GetOcxVersion()`: Returns version of the ActiveX control.
* `InitAudio(...)`: Initializes audio playback.

### Export & Capture

* `SaveAsBitmap(...)`: Saves the current frame as a bitmap.
* `SaveAsJpeg(...)`: Saves the current frame as a JPEG image.

---

## Resource Management

* `Dispose()`: Disposes the object and releases resources.
* `Dispose(bool disposing)`: Protected method for cleanup.
* Finalizer `~AxVideoPlayer()` is defined.

---

## Protected Methods

* `OnFrameArrived()`
* `OnDisconnect()`
* `OnConnect()`
* `OnConnectFailed(...)`
* `OnError(...)`

These methods are intended to be overridden in derived classes to customize event handling behavior.

---

## Notes

* The control expects a valid `AxVideoPlayerWindow` that contains the `AxVideoPicture`.
* Some methods rely on specific ActiveX features and may throw if the control is misconfigured or unavailable.
* Always dispose the instance when finished to avoid resource leaks.
