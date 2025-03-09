# OpenCvSharpWrapper

## Overview
The `OpenCvSharpWrapper` class is a wrapper around OpenCV's `VideoCapture`, allowing video streaming and display using a `PictureBox` in a Windows Forms application.

## Namespace
`Mtf.Controls.Video.OpenCvSharp`

## Dependencies
- `Mtf.Controls.Extensions`
- `Mtf.Controls.Interfaces`
- `Mtf.MessageBoxes`
- `OpenCvSharp`
- `OpenCvSharp.Extensions`
- `System`
- `System.Threading`
- `System.Threading.Tasks`
- `System.Windows.Forms`

## Properties
- **sync** (`object`): Synchronization lock for thread safety.
- **pictureBox** (`PictureBox`): The UI element to display video frames.
- **videoCapture** (`VideoCapture`): Handles video stream capture.
- **cancellationTokenSource** (`CancellationTokenSource`): Controls task cancellation.

## Methods
### Constructor
```csharp
public OpenCvSharpWrapper(PictureBox pictureBox)
```
Initializes the wrapper with a `PictureBox`.

### Start
```csharp
public void Start(string url)
```
Starts streaming synchronously.

### StartAsync
```csharp
public async Task StartAsync(string url)
```
Starts streaming asynchronously.

### Stop
```csharp
public void Stop()
```
Stops the video stream.

### DisposeManagedResources
```csharp
protected override void DisposeManagedResources()
```
Releases managed resources.

---

# OpenCvSharpVideoWindow

## Overview
A `PictureBox`-based video player control that integrates OpenCV for video streaming.

## Properties
- `OverlayText` (`string`): Text overlay.
- `OverlayFont` (`Font`): Font for overlay text.
- `OverlayBrush` (`Brush`): Brush color for overlay text.
- `OverlayLocation` (`Point`): Position of overlay text.

## Methods
### Constructor
```csharp
public OpenCvSharpVideoWindow()
```
Initializes the control with a default image.

### Start
```csharp
public void Start(string resource)
```
Starts video playback.

### Stop
```csharp
public void Stop()
```
Stops video playback.

### OnPaint
```csharp
protected override void OnPaint(PaintEventArgs e)
```
Renders the overlay text.

---

# OpenCvSharp4VideoWindow

## Overview
An enhanced version of `OpenCvSharpVideoWindow` with direct `VideoCapture` handling.

## Properties
Same as `OpenCvSharpVideoWindow`.

## Methods
### Constructor
```csharp
public OpenCvSharp4VideoWindow()
```
Initializes the control.

### Start
```csharp
public void Start(string resource)
```
Starts video streaming.

### Stop
```csharp
public void Stop()
```
Stops the video playback.

### OnPaint
```csharp
protected override void OnPaint(PaintEventArgs e)
```
Draws overlay text.

### LoadFrame
```csharp
private void LoadFrame()
```
Loads and processes video frames from the `VideoCapture`.

### DrawOverlay
```csharp
private void DrawOverlay(Graphics graphics)
```
Draws the overlay text on the video frames.

### DisposeManagedResources
```csharp
protected override void DisposeManagedResources()
```
Cleans up resources properly to prevent memory leaks.

