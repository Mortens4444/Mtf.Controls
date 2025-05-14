# Video Controls Legacy Documentation

## Overview
This documentation describes a set of legacy WinForms controls based on Accord.NET and AForge.NET libraries for handling various video sources, including JPEG/MJPEG streams, screen capture, and video capture devices. These controls extend the `System.Windows.Forms.PictureBox` and provide methods for starting and stopping video streams.

## Dependencies
- `System.Drawing`
- `System.Windows.Forms`
- Accord.NET libraries (Specific dependencies depend on the control)
- AForge.NET libraries (Specific dependencies depend on the control)

---

# AccordJpegVideoWindow Class

## Namespace
`Mtf.Controls.Video.Legacy`

## Description
A WinForms control extending `PictureBox` for displaying JPEG video streams using Accord.NET.

### Constructor
```csharp
public AccordJpegVideoWindow()
````

Initializes a new instance of the `AccordJpegVideoWindow` class.

### Methods

#### Start(string resource)

```csharp
public void Start(string resource)
```

Starts the JPEG video stream.

  - `resource`: The URI of the JPEG video stream.

#### SetCredentials(string userName, string password)

```csharp
public void SetCredentials(string userName, string password)
```

Sets credentials for authenticating with the video source.

  - `userName`: The username.
  - `password`: The password.

#### Stop()

```csharp
public void Stop()
```

Stops the video stream.

#### Protected Methods

#### Dispose(bool disposing)

```csharp
protected override void Dispose(bool disposing)
```

Disposes of the resources used by the control.

-----

# AccordMjpegVideoWindow Class

## Namespace

`Mtf.Controls.Video.Legacy`

## Description

A WinForms control extending `PictureBox` for displaying MJPEG video streams using Accord.NET.

### Constructor

```csharp
public AccordMjpegVideoWindow()
```

Initializes a new instance of the `AccordMjpegVideoWindow` class.

### Methods

#### Start(string resource)

```csharp
public void Start(string resource)
```

Starts the MJPEG video stream.

  - `resource`: The URI of the MJPEG video stream.

#### SetCredentials(string userName, string password)

```csharp
public void SetCredentials(string userName, string password)
```

Sets credentials for authenticating with the video source.

  - `userName`: The username.
  - `password`: The password.

#### Stop()

```csharp
public void Stop()
```

Stops the video stream.

#### Protected Methods

#### Dispose(bool disposing)

```csharp
protected override void Dispose(bool disposing)
```

Disposes of the resources used by the control.

-----

# AccordScreenCaptureWindow Class

## Namespace

`Mtf.Controls.Video.Legacy`

## Description

A WinForms control extending `PictureBox` for displaying screen captures using Accord.NET.

### Properties

#### RecordingArea

```csharp
public Rectangle RecordingArea { get; set; }
```

Gets or sets the rectangular area of the screen to capture. Defaults to the primary screen's bounds.

### Constructor

```csharp
public AccordScreenCaptureWindow()
```

Initializes a new instance of the `AccordScreenCaptureWindow` class.

### Methods

#### Start()

```csharp
public void Start()
```

Starts capturing the screen area defined by `RecordingArea`.

#### Stop()

```csharp
public void Stop()
```

Stops the screen capture.

#### Protected Methods

#### Dispose(bool disposing)

```csharp
protected override void Dispose(bool disposing)
```

Disposes of the resources used by the control.

-----

# AForgeJpegVideoWindow Class

## Namespace

`Mtf.Controls.Video.Legacy`

## Description

A WinForms control extending `PictureBox` for displaying JPEG video streams using AForge.NET.

### Constructor

```csharp
public AForgeJpegVideoWindow()
```

Initializes a new instance of the `AForgeJpegVideoWindow` class.

### Methods

#### Start(string resource)

```csharp
public void Start(string resource)
```

Starts the JPEG video stream.

  - `resource`: The URI of the JPEG video stream.

#### SetCredentials(string userName, string password)

```csharp
public void SetCredentials(string userName, string password)
```

Sets credentials for authenticating with the video source.

  - `userName`: The username.
  - `password`: The password.

#### Stop()

```csharp
public void Stop()
```

Stops the video stream.

#### Protected Methods

#### Dispose(bool disposing)

```csharp
protected override void Dispose(bool disposing)
```

Disposes of the resources used by the control.

-----

# AForgeMjpegVideoWindow Class

## Namespace

`Mtf.Controls.Video.Legacy`

## Description

A WinForms control extending `PictureBox` for displaying MJPEG video streams using AForge.NET.

### Constructor

```csharp
public AForgeMjpegVideoWindow()
```

Initializes a new instance of the `AForgeMjpegVideoWindow` class.

### Methods

#### Start(string resource)

```csharp
public void Start(string resource)
```

Starts the MJPEG video stream.

  - `resource`: The URI of the MJPEG video stream.

#### SetCredentials(string userName, string password)

```csharp
public void SetCredentials(string userName, string password)
```

Sets credentials for authenticating with the video source.

  - `userName`: The username.
  - `password`: The password.

#### Stop()

```csharp
public void Stop()
```

Stops the video stream.

#### Protected Methods

#### Dispose(bool disposing)

```csharp
protected override void Dispose(bool disposing)
```

Disposes of the resources used by the control.

-----

# AForgeScreenCaptureWindow Class

## Namespace

`Mtf.Controls.Video.Legacy`

## Description

A WinForms control extending `PictureBox` for displaying screen captures using AForge.NET.

### Properties

#### RecordingArea

```csharp
public Rectangle RecordingArea { get; set; }
```

Gets or sets the rectangular area of the screen to capture. Defaults to the primary screen's bounds.

### Constructor

```csharp
public AForgeScreenCaptureWindow()
```

Initializes a new instance of the `AForgeScreenCaptureWindow` class.

### Methods

#### Start()

```csharp
public void Start()
```

Starts capturing the screen area defined by `RecordingArea`.

#### Stop()

```csharp
public void Stop()
```

Stops the screen capture.

#### Protected Methods

#### Dispose(bool disposing)

```csharp
protected override void Dispose(bool disposing)
```

Disposes of the resources used by the control.

-----

# AForgeVideoCaptureDeviceWindow Class

## Namespace

`Mtf.Controls.Video.Legacy`

## Description

A WinForms control extending `PictureBox` for displaying video from a capture device using AForge.NET.

### Constructor

```csharp
public AForgeVideoCaptureDeviceWindow()
```

Initializes a new instance of the `AForgeVideoCaptureDeviceWindow` class.

### Methods

#### Start(string resource)

```csharp
public void Start(string resource)
```

Starts the video stream from a capture device.

  - `resource`: The moniker string of the video capture device.

#### Stop()

```csharp
public void Stop()
```

Stops the video stream.

#### Protected Methods

#### Dispose(bool disposing)

```csharp
protected override void Dispose(bool disposing)
```

Disposes of the resources used by the control.

-----

# PictureBoxExtensions Class

## Namespace

`Mtf.Controls.Video.Legacy.Extensions`

## Description

Provides extension methods for the `System.Windows.Forms.PictureBox` control, primarily for thread-safe image manipulation.

### Static Methods

#### InvokeAction(this PictureBox pictureBox, Action action)

```csharp
public static void InvokeAction(this PictureBox pictureBox, Action action)
```

Invokes an action on the thread that owns the PictureBox's underlying window handle.

  - `pictureBox`: The PictureBox instance.
  - `action`: The action to invoke.

#### ThreadSafeSetImageWithCloning(this PictureBox pictureBox, Image originalImage, object sync)

```csharp
public static void ThreadSafeSetImageWithCloning(this PictureBox pictureBox, Image originalImage, object sync)
```

Sets the PictureBox's image in a thread-safe manner by creating a clone of the original image.

  - `pictureBox`: The PictureBox instance.
  - `originalImage`: The image to set.
  - `sync`: An object used for locking to ensure thread safety.

#### ThreadSafeSetImage(this PictureBox pictureBox, Image image, object sync)

```csharp
public static void ThreadSafeSetImage(this PictureBox pictureBox, Image image, object sync)
```

Sets the PictureBox's image in a thread-safe manner.

  - `pictureBox`: The PictureBox instance.
  - `image`: The image to set.
  - `sync`: An object used for locking to ensure thread safety.

#### ThreadSafeClearImage(this PictureBox pictureBox, object sync)

```csharp
public static void ThreadSafeClearImage(this PictureBox pictureBox, object sync)
```

Clears the PictureBox's image in a thread-safe manner.

  - `pictureBox`: The PictureBox instance.
  - `sync`: An object used for locking to ensure thread safety.

#### SetImage(this PictureBox pictureBox, Image image)

```csharp
public static void SetImage(this PictureBox pictureBox, Image image)
```

Sets the PictureBox's image directly (use with caution from threads other than the UI thread).

  - `pictureBox`: The PictureBox instance.
  - `image`: The image to set.

-----

## Notes

  - These controls are based on legacy libraries (Accord.NET and AForge.NET).
  - They provide basic functionality for displaying various video sources within a WinForms application.
  - Thread-safe methods are provided for updating the PictureBox's image from background threads.
