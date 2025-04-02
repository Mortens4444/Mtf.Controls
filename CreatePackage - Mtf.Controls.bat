nuget pack Mtf.Controls.nuspec
REM dotnet pack --include-symbols --include-source
powershell.exe -ExecutionPolicy Bypass -File ".\Mtf.Controls.IncrementNugetPackageVersion.ps1"
pause