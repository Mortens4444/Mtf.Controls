# Chromium Video Player Documentation

## Overview

The `ChromiumWindow` class provides a WinForms control for displaying video streams (e.g., MJPEG) in a Chromium-based browser using CefSharp. It implements the `IVideoPlayer` interface for unified playback control.

## Dependencies

* `CefSharp`
* `CefSharp.WinForms`
* `System.Windows.Forms`
* `System.Drawing`
* `Mtf.Controls.Interfaces`

---

# ChromiumWindow Class

## Namespace

`Mtf.Controls.Video.Chromium`

## Description

The `ChromiumWindow` class extends `ChromiumWebBrowser` and implements `IVideoPlayer`. It displays video content in a browser-like control and supports simple playback control using HTML rendering.

### Fields

* `private bool disposed`: Indicates whether the control has been disposed.

### Constructor

```csharp
public ChromiumWindow()
```

Initializes a new instance of `ChromiumWindow`, sets up default appearance, loads a "No Signal" image, and disables the default context menu.

### Methods

#### Start(string resource)

```csharp
public void Start(string resource)
```

Starts video playback by rendering an HTML page with the given image/video URI. The resource must be a valid URI (e.g., MJPEG stream or camera snapshot endpoint).

#### Stop()

```csharp
public void Stop()
```

Stops playback by navigating to `about:blank`.

#### Protected Dispose(bool disposing)

```csharp
protected override void Dispose(bool disposing)
```

Disposes the control and releases resources. Ensures `Stop()` is called and nullifies `MenuHandler`.

#### Private Methods

* `IsAlive()`: Returns `true` if the control is not disposed.

---

# IVideoPlayer Interface

## Namespace

`Mtf.Controls.Interfaces`

## Description

Defines the basic playback control contract for video players.

### Methods

* `void Start(string resource)`: Starts playback with the specified resource.
* `void Stop()`: Stops playback.
* `void Dispose()`: Releases resources.

---

# Usage Example

```csharp
var chromiumPlayer = new ChromiumWindow();
form.Controls.Add(chromiumPlayer);
chromiumPlayer.Start("http://example.com/mjpeg-stream");
```

This creates a `ChromiumWindow`, adds it to a form, and starts displaying an MJPEG stream.

---

## Notes

* The `ChromiumWindow` class is useful for simple streaming formats like MJPEG.
* It is not suitable for advanced playback features (seeking, pausing, audio).
* Overlay features or signal detection must be implemented separately.
* The `NoSignal` image is displayed initially to indicate an idle state.
