nuget pack .nuspec
powershell.exe -ExecutionPolicy Bypass -File ".\IncrementNugetPackageVersion.ps1"
pause