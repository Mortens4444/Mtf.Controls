nuget pack Mtf.Controls.nuspec
powershell.exe -ExecutionPolicy Bypass -File ".\Mtf.Controls.IncrementNugetPackageVersion.ps1"
pause