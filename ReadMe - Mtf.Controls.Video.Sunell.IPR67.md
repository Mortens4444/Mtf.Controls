# Sunell IP Camera Control (IPR67 Model)

## Overview
**SunellVideoWindow** is an enhanced Windows Forms control for Sunell IP cameras (model IPR67) that provides comprehensive video streaming and camera control capabilities through Sunell's native SDK.

## Features
- High-performance video streaming (supports multiple stream types)
- Full PTZ (Pan-Tilt-Zoom) control with adjustable speed
- Hardware acceleration support
- Customizable video overlays
- Thread-safe connection management
- Automatic resource cleanup

## Component: SunellVideoWindow
Inherits from `System.Windows.Forms.PictureBox` with Sunell-specific enhancements.

### Properties

#### Overlay Configuration
| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `OverlayText` | string | `""` | Text overlay content |
| `OverlayFont` | Font | Arial 32pt Bold | Overlay text style |
| `OverlayColor` | Color | White | Text color |
| `OverlayBackgroundColor` | Color | White | Text background color |
| `OverlayLocation` | Point | (10, 10) | Overlay position |

#### Status Properties
| Property | Type | Description |
|----------|------|-------------|
| `IsConnected` | bool | Connection status (read-only) |

### Methods

#### Connection Management
```csharp
int Connect(
    string cameraIp = "192.168.0.120",
    ushort cameraPort = 30001,
    string username = "admin",
    string password = "admin",
    int streamId = 1,
    int channel = 1,
    StreamType streamType = StreamType.Mjpeg,
    bool hardwareAcceleration = true)
```
Establishes camera connection with configurable parameters. Returns stream ID or error code (`NoStream = -1`, `NoPermission = -2`).

```csharp
void Disconnect()
```
Safely terminates connection and releases resources.

#### PTZ Controls
```csharp
void PtzRotate(PtzRotateOperation operation)
// Starts camera movement (Up/Down/Left/Right)

void PtzStop()
// Stops all PTZ movement

void PtzZoom(PtzZoomOperation operation)
// Controls zoom (In/Out)
```

### Enumerations
```csharp
public enum PtzRotateOperation
{
	Stop = 0,
	Up = 1,
	Down = 2,
	Left = 3,
	Right = 4
}

public enum PtzZoomOperation
{
	Stop = 0,
	In = 1,
	Out = 2
}

public enum StreamType
{
	Jpeg,
	Mjpeg
}
```

## Usage Example

```csharp
var camera = new SunellVideoWindow()
{
    OverlayText = "Security Camera 1",
    OverlayFont = new Font("Tahoma", 10),
    OverlayColor = Color.Yellow,
    OverlayLocation = new Point(20, 20)
};

// Connect to camera
int streamId = camera.Connect(
    cameraIp: "192.168.1.100",
    username: "admin",
    password: "secure123",
    streamType: StreamType.HighDensity,
    hardwareAcceleration: true);

// PTZ Control
camera.PtzRotate(PtzRotateOperation.Right);  // Pan right
camera.PtzZoom(PtzZoomOperation.In);         // Zoom in

// Disconnect when done
camera.Disconnect();
```

## Technical Details

### Dependencies
- `LiveView.Core.Services` (for configuration)
- `Mtf.Controls.Sunell.IPR67.SunellSdk` (native SDK wrapper)
- `System.ComponentModel`
- `System.Drawing`
- `System.Windows.Forms`

### Resource Management
- Implements proper disposal pattern
- Automatic connection cleanup
- Thread-safe UI updates via `Invoke`

## Error Handling
The control returns specific error codes:
- `NoStream (-1)`: Stream initialization failed
- `NoPermission (-2)`: Authentication failure

## Best Practices
1. Always call `Disconnect()` when done
2. Use hardware acceleration for better performance
3. Configure appropriate stream type based on network conditions
4. Handle PTZ operations in UI thread
