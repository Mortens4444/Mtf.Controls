param(
    [string]$CsprojFile
)

if (-not (Test-Path $CsprojFile)) {
    Write-Host "Error: File not found: $CsprojFile." -ForegroundColor Red
    exit 1
}

$lines = Get-Content $CsprojFile
$updatedLines = @()

$versionPattern = '<Version>(\d+)\.(\d+)\.(\d+)</Version>'
$found = $false
foreach ($line in $lines) {
    if ($line -match $versionPattern) {
        $found = $true

        $major = [int]$matches[1]
        $minor = [int]$matches[2]
        $build = [int]$matches[3]

        $build++

        $newVersion = "$major.$minor.$build"

        $updatedLine = $line -replace $versionPattern, "<Version>$newVersion</Version>"
        $updatedLines += $updatedLine
    } else {
        $updatedLines += $line
    }
}

if (-not $found) {
    Write-Host "Error: <Version> tag not found." -ForegroundColor Red
    exit 1
}

$updatedLines | Set-Content $CsprojFile -Encoding UTF8

Write-Host "Version updated to $newVersion in $CsprojFile" -ForegroundColor Green
