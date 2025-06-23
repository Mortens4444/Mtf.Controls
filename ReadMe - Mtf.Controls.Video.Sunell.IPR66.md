# Sunell Video Player Documentation

## Overview

The `SunellVideoWindowLegacy` class provides a WinForms control for displaying and interacting with Sunell IP camera streams. It extends `PictureBox` to render video content and manage playback and PTZ (pan-tilt-zoom) features through proprietary APIs.

## Dependencies

* `System.Drawing`
* `System.Windows.Forms`
* `Mtf.Controls.Enums`
* `Mtf.Controls.Interfaces`
* `Mtf.Controls.Extensions`
* Sunell native SDK

---

# SunellVideoWindowLegacy Class

## Namespace

`Mtf.Controls.Video.Sunell.IPR66`

## Description

The `SunellVideoWindowLegacy` control manages connection, playback, and camera control for Sunell IP-based cameras. It integrates with the native SDK and uses Windows messages for event handling.

### Events

* `public event VideoSignalChangedEventHandler VideoSignalChanged`: Triggered when the video signal is acquired or lost.

### Properties

* `public string OverlayText { get; set; } = String.Empty`: Text overlayed on top of the video.
* `public Font OverlayFont { get; set; }`: Font of the overlay text.
* `public Color OverlayColor { get; set; }`: Foreground color of the overlay text.
* `public Color OverlayBackgroundColor { get; set; }`: Background color of the overlay text.
* `public Point OverlayLocation { get; set; }`: Location of the overlay text on the video.
* `public bool IsConnected { get; }`: Indicates whether the camera connection is currently established.

### Constructor

```csharp
public SunellVideoWindowLegacy()
```

Initializes a new instance of the control with default settings and no active connection.

### Methods

#### Connect

```csharp
public void Connect(string cameraIp = "192.168.0.120", ushort cameraPort = 30001, string username = "admin", string password = "admin", int streamId = 1, int cameraId = 1, bool autoConnect = true, int ipProtocolVersion = 1, int transferProtocol = 2)
```

Establishes a connection with the Sunell camera using the specified parameters.

#### Disconnect

```csharp
public void Disconnect()
```

Closes any active connection and stops the video stream.

---

## Sunell Control Functions

These methods configure playback and camera properties:

* `SetUseTimeStamp(bool useTimeStamp)`
* `SetStretchMode(bool stretch)`
* `SetAutoConnectFlag(bool autoConnect)`
* `SetContrast(int percent)`
* `SetBrightness(int percent)`
* `SetHue(int percent)`
* `SetSaturation(int percent)`
* `SetDefaultStreamId(int streamId)`

### Playback Control

* `PlaySound()`: Enables audio playback.
* `Pause()`: Pauses the current stream.
* `CreateSnapShot(string filePath)`: Captures a still image from the video stream.
* `StartRecording(string filePath)`: Begins saving the video stream to a file.
* `StopRecording()`: Ends video recording.

### PTZ Camera Control

* `PTZ_Open(int cameraId)`
* `PTZ_Close()`
* `PTZ_Stop()`
* `PTZ_RotateUp(int speed)`
* `PTZ_RotateDown(int speed)`
* `PTZ_RotateLeft(int speed)`
* `PTZ_RotateRight(int speed)`

### Display

* `RefreshImage()`: Forces a refresh of the displayed image, usually on resize or signal change.

---

## Windows Message Handling

### WndProc Override

```csharp
protected override void WndProc(ref Message m)
```

Handles internal Windows messages sent by the SDK, updating the display and raising `VideoSignalChanged` events.

### Resize Events

* `OnResize(EventArgs e)`
* `OnSizeChanged(EventArgs e)`

These override methods ensure the video and overlay text are updated properly when the control's size changes.

---

## Usage Example

```csharp
var videoWindow = new SunellVideoWindowLegacy();
videoWindow.Connect("192.168.1.100", 30001, "admin", "admin");
```

This example initializes a `SunellVideoWindowLegacy` control and connects it to a Sunell camera at the specified IP address.

---

## Notes

* The control assumes the presence of Sunell's proprietary SDK for underlying video/audio session handling.
* Overlay customization (text, color, font, position) is available at runtime.
* Video signal presence is tracked and exposed via event notifications.
* PTZ controls are available only if supported by the connected camera model.
* Designed for legacy support and integration with WinForms environments.
