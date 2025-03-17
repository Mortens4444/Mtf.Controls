nuget pack Mtf.Controls.nuspec
dotnet pack --include-symbols --include-source
powershell.exe -ExecutionPolicy Bypass -File ".\Mtf.Controls.IncrementNugetPackageVersion.ps1"
pause