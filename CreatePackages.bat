nuget pack Mtf.Controls.nuspec
powershell.exe -ExecutionPolicy Bypass -File ".\Mtf.Controls.IncrementNugetPackageVersion.ps1"

nuget pack Mtf.Controls.Video.ActiveX.nuspec
powershell.exe -ExecutionPolicy Bypass -File ".\Mtf.Controls.Video.ActiveX.IncrementNugetPackageVersion.ps1"

nuget pack Mtf.Controls.Video.Chromium.nuspec
powershell.exe -ExecutionPolicy Bypass -File ".\Mtf.Controls.Video.Chromium.IncrementNugetPackageVersion.ps1"

nuget pack Mtf.Controls.Video.Legacy.nuspec
powershell.exe -ExecutionPolicy Bypass -File ".\Mtf.Controls.Video.Legacy.IncrementNugetPackageVersion.ps1"

nuget pack Mtf.Controls.Video.nuspec
powershell.exe -ExecutionPolicy Bypass -File ".\Mtf.Controls.Video.IncrementNugetPackageVersion.ps1"

nuget pack Mtf.Controls.Video.FFmpeg.nuspec
powershell.exe -ExecutionPolicy Bypass -File ".\Mtf.Controls.Video.FFmpeg.IncrementNugetPackageVersion.ps1"

nuget pack Mtf.Controls.Video.OpenCvSharp.nuspec
powershell.exe -ExecutionPolicy Bypass -File ".\Mtf.Controls.Video.OpenCvSharp.IncrementNugetPackageVersion.ps1"

nuget pack Mtf.Controls.Video.VLC.nuspec
powershell.exe -ExecutionPolicy Bypass -File ".\Mtf.Controls.Video.VLC.IncrementNugetPackageVersion.ps1"