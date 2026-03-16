<#
.SYNOPSIS
    Downloads the latest metal-cpp headers and Apple documentation JSON files.

.DESCRIPTION
    1. Fetches the latest metal-cpp archive from developer.apple.com and replaces the local metal-cpp/ directory.
    2. Scans the downloaded headers to derive class names for each framework.
    3. Downloads the corresponding Apple documentation JSON for every class into apple-docs/.
    4. Recursively downloads sub-page JSON when a class's topicSections contains non-member identifiers.
    5. Writes a version.json with metadata about the download.

.EXAMPLE
    pwsh -File update-sources.ps1
    pwsh -File update-sources.ps1 -SkipMetalCpp   # only refresh documentation JSON
#>

param(
    [switch]$SkipMetalCpp,
    [switch]$SkipDocs
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$scriptDir = $PSScriptRoot
$metalCppDir = Join-Path $scriptDir 'metal-cpp'
$appleDocsDir = Join-Path $scriptDir 'apple-docs'

# Framework subdirectory -> Apple documentation module name
$frameworkMap = @{
    'Metal'      = 'metal'
    'MetalFX'    = 'metalfx'
    'QuartzCore' = 'quartzcore'
}

# Header file name patterns to skip (same filters as CppParser.cs)
$skipPatterns = @('Private', 'HeaderBridge', 'Defines', 'Version', 'GPUAddress', 'IOCompressor', 'Types')
$skipExact = @('Metal.hpp', 'Foundation.hpp', 'QuartzCore.hpp', 'MetalFX.hpp')

# Progress bar activity IDs
$idMetalCpp = 1
$idDocs = 2

#region metal-cpp update

function Update-MetalCpp {
    Write-Progress -Id $idMetalCpp -Activity 'Updating metal-cpp' -Status 'Fetching download page...' -PercentComplete 0

    $page = Invoke-WebRequest -Uri 'https://developer.apple.com/metal/cpp/' -UseBasicParsing
    $zipHref = $page.Links |
        Where-Object { $_.href -match 'metal-cpp.*\.zip$' } |
        Select-Object -First 1 -ExpandProperty href

    if (-not $zipHref) {
        throw 'Could not find metal-cpp zip link on the download page.'
    }

    $zipUrl = "https://developer.apple.com$zipHref"
    $zipName = [System.IO.Path]::GetFileNameWithoutExtension($zipHref)

    Write-Progress -Id $idMetalCpp -Activity 'Updating metal-cpp' -Status "Downloading $zipName ..." -PercentComplete 20

    $tempZip = Join-Path ([System.IO.Path]::GetTempPath()) 'metal-cpp-latest.zip'
    $tempExtract = Join-Path ([System.IO.Path]::GetTempPath()) 'metal-cpp-extract'

    Invoke-WebRequest -Uri $zipUrl -OutFile $tempZip -UseBasicParsing

    Write-Progress -Id $idMetalCpp -Activity 'Updating metal-cpp' -Status 'Extracting archive...' -PercentComplete 60

    if (Test-Path $tempExtract) { Remove-Item $tempExtract -Recurse -Force }
    Expand-Archive -Path $tempZip -DestinationPath $tempExtract -Force

    # The archive typically contains a root folder (e.g., metal-cpp_26/)
    $extractedRoot = Get-ChildItem $tempExtract -Directory | Select-Object -First 1
    if (-not $extractedRoot) {
        throw 'Unexpected archive structure: no root directory found.'
    }

    Write-Progress -Id $idMetalCpp -Activity 'Updating metal-cpp' -Status 'Replacing local files...' -PercentComplete 80

    if (Test-Path $metalCppDir) { Remove-Item $metalCppDir -Recurse -Force }
    Copy-Item -Path $extractedRoot.FullName -Destination $metalCppDir -Recurse

    # Cleanup temp files
    Remove-Item $tempZip -Force -ErrorAction SilentlyContinue
    Remove-Item $tempExtract -Recurse -Force -ErrorAction SilentlyContinue

    Write-Progress -Id $idMetalCpp -Activity 'Updating metal-cpp' -Status "Updated to $zipName" -PercentComplete 100 -Completed
    Write-Host "  metal-cpp updated to $zipName" -ForegroundColor Green
    return $zipName
}

#endregion

#region Apple docs download

function Get-ClassNamesFromHeaders {
    $classes = [System.Collections.Generic.List[PSCustomObject]]::new()

    foreach ($subdir in $frameworkMap.Keys) {
        $hdrDir = Join-Path $metalCppDir $subdir
        if (-not (Test-Path $hdrDir)) { continue }

        $docModule = $frameworkMap[$subdir]

        foreach ($file in Get-ChildItem $hdrDir -Filter '*.hpp') {
            $name = $file.Name

            # Apply the same skip filters as CppParser.cs
            if ($skipExact -contains $name) { continue }

            $skip = $false
            foreach ($p in $skipPatterns) {
                if ($name.Contains($p)) { $skip = $true; break }
            }
            if ($skip) { continue }

            # Derive the class name: MTLDevice.hpp -> mtldevice
            $className = [System.IO.Path]::GetFileNameWithoutExtension($name).ToLowerInvariant()
            $classes.Add([PSCustomObject]@{
                Module    = $docModule
                ClassName = $className
                FileName  = $name
            })
        }
    }

    return $classes
}

function Download-DocJson {
    param(
        [string]$Module,
        [string]$Slug,
        [string]$OutDir
    )

    $url = "https://developer.apple.com/tutorials/data/documentation/$Module/$Slug.json"
    $outFile = Join-Path $OutDir "$Slug.json"

    if (Test-Path $outFile) { return $null }

    try {
        Invoke-WebRequest -Uri $url -OutFile $outFile -UseBasicParsing -ErrorAction Stop
        return $outFile
    }
    catch {
        Write-Warning "    Failed to download: $url"
        return $null
    }
}

function Get-SubPageSlugs {
    param([string]$JsonPath, [string]$ClassName)

    $json = Get-Content $JsonPath -Raw | ConvertFrom-Json
    $slugs = [System.Collections.Generic.List[string]]::new()

    $sections = $json.PSObject.Properties['topicSections']
    if (-not $sections -or -not $sections.Value) { return $slugs }

    foreach ($section in $sections.Value) {
        foreach ($id in $section.identifiers) {
            # Identifiers that belong to the class look like:
            #   doc://com.apple.metal/documentation/Metal/MTLDevice/name
            # Sub-page identifiers look like:
            #   doc://com.apple.metal/documentation/Metal/device-inspection
            # We want the latter (no class name segment).

            if ($id -match '/documentation/[^/]+/([^/]+)$') {
                $slug = $Matches[1].ToLowerInvariant()

                # Skip if it looks like a member of the current class
                if ($id -match "/$ClassName/") { continue }

                # Skip if it looks like a related type (contains uppercase = type name, not a sub-page slug)
                # Sub-page slugs use kebab-case (e.g., device-inspection, work-submission)
                if ($slug -match '-') {
                    $slugs.Add($slug)
                }
            }
        }
    }

    return $slugs
}

function Update-AppleDocs {
    $classes = Get-ClassNamesFromHeaders
    $total = $classes.Count
    $current = 0
    $subPageCount = 0

    Write-Progress -Id $idDocs -Activity 'Downloading Apple documentation' -Status "0 / $total classes" -PercentComplete 0

    foreach ($entry in $classes) {
        $current++
        $pct = [math]::Floor(($current / $total) * 100)
        Write-Progress -Id $idDocs -Activity 'Downloading Apple documentation' `
            -Status "$current / $total — $($entry.FileName)" -PercentComplete $pct

        $moduleDir = Join-Path $appleDocsDir $entry.Module
        if (-not (Test-Path $moduleDir)) { New-Item $moduleDir -ItemType Directory -Force | Out-Null }

        $mainFile = Download-DocJson -Module $entry.Module -Slug $entry.ClassName -OutDir $moduleDir

        if (-not $mainFile) {
            $mainFile = Join-Path $moduleDir "$($entry.ClassName).json"
        }

        # Download sub-pages if the main JSON exists
        if (Test-Path $mainFile) {
            $subSlugs = Get-SubPageSlugs -JsonPath $mainFile -ClassName $entry.ClassName
            foreach ($slug in $subSlugs) {
                $result = Download-DocJson -Module $entry.Module -Slug $slug -OutDir $moduleDir
                if ($result) { $subPageCount++ }
            }
        }
    }

    Write-Progress -Id $idDocs -Activity 'Downloading Apple documentation' -Status 'Done' -PercentComplete 100 -Completed
    Write-Host "  Downloaded docs for $total classes + $subPageCount sub-pages." -ForegroundColor Green
}

#endregion

#region Main

$metalCppVersion = $null

if (-not $SkipMetalCpp) {
    Update-MetalCpp | ForEach-Object { $metalCppVersion = $_ }
}
else {
    Write-Host 'Skipping metal-cpp update.' -ForegroundColor Yellow
}

if (-not $SkipDocs) {
    Update-AppleDocs
}
else {
    Write-Host 'Skipping documentation download.' -ForegroundColor Yellow
}

# Write version metadata
$versionFile = Join-Path $scriptDir 'version.json'
$versionData = @{
    updatedAt      = (Get-Date -Format 'o')
    metalCppSource = if ($metalCppVersion) { $metalCppVersion } else { 'unchanged' }
}
$versionData | ConvertTo-Json | Set-Content $versionFile -Encoding UTF8

Write-Host ''
Write-Host 'Done! You can now run the generator:' -ForegroundColor Green
Write-Host '  dotnet run --project Metal.NET.Generator'

#endregion
