# MortoGraphy Video Streaming Control

## Overview
**MortoGraphy** is a custom video streaming control built using Windows Forms. It allows embedding and displaying MJPEG or JPEG video streams within an application using the `MortoGraphyWindow` component.

## Features
- Supports MJPEG and JPEG video streams.
- Provides overlay text support with configurable font, color, and position.
- Implements a secure authentication mechanism for video streams.
- Offers a `Start` and `Stop` method to manage streaming.
- Handles thread-safe image updates to avoid UI thread issues.

## Components
### MortoGraphyWindow
A `PictureBox`-derived control that provides an interface for displaying video streams. It includes properties for configuring authentication, overlay text, and stream type.

#### Properties:
- `StreamType` (StreamType): Defines the type of stream (MJPEG/JPEG).
- `Username` (string): Username for authentication.
- `Password` (string): Password for authentication.
- `OverlayText` (string): Text displayed over the video feed.
- `OverlayFont` (Font): Font used for overlay text.
- `OverlayBrush` (Brush): Color of the overlay text.
- `OverlayLocation` (Point): Position of the overlay text.

#### Methods:
- `Start(string resource)`: Starts the video stream from the specified URI.
- `Stop()`: Stops the video stream.

### MortoGraphy
Handles video stream retrieval and processing. This class fetches frames and updates the `MortoGraphyWindow` control.

#### Events:
- `FrameArrived`: Triggered when a new frame is available.

#### Methods:
- `Start(string url)`: Initiates video streaming from the given URL.
- `Stop()`: Stops the video stream.

## Usage
1. Add `MortoGraphyWindow` to your form.
2. Set the necessary properties (`StreamType`, `Username`, `Password`, etc.).
3. Call `Start("http://your-stream-url")` to begin streaming.
4. Call `Stop()` when finished.

```csharp
var videoWindow = new MortoGraphyWindow
{
    Username = "admin",
    Password = "password",
    StreamType = StreamType.Mjpeg,
    OverlayText = "Live Stream",
    OverlayFont = new Font("Arial", 16, FontStyle.Bold),
    OverlayBrush = Brushes.Red,
    OverlayLocation = new Point(20, 20)
};
videoWindow.Start("http://camera-stream-url");
```

## Dependencies
- `System.Drawing`
- `System.Net.Http`
- `System.Windows.Forms`

## License
This project is licensed under the MIT License.

