$NuspecFile = ".nuspec"

if (-not (Test-Path $NuspecFile)) {
    Write-Host "Error: File not found: $NuspecFile." -ForegroundColor Red
    exit 1
}

Copy-Item -Path $NuspecFile -Destination "$NuspecFile.bak" -Force

$lines = Get-Content $NuspecFile
$updatedLines = @()

$versionPattern = '<version>(\d+)\.(\d+)\.(\d+)</version>'
$found = $false
foreach ($line in $lines) {
    if ($line -match $versionPattern) {
        $found = $true

        $major = [int]$matches[1]
        $minor = [int]$matches[2]
        $build = [int]$matches[3]

        $build++

        $newVersion = "$major.$minor.$build"

        $updatedLine = $line -replace $versionPattern, "<version>$newVersion</version>"
        $updatedLines += $updatedLine
    } else {
        $updatedLines += $line
    }
}

if (-not $found) {
    Write-Host "Error: <version> tag not found." -ForegroundColor Red
    exit 1
}

$updatedLines | Set-Content $NuspecFile -Encoding UTF8

Write-Host "Version updated." -ForegroundColor Green
