<#
.SYNOPSIS
    Downloads the latest metal-cpp headers and Apple documentation JSON files.

.DESCRIPTION
    1. Fetches the latest metal-cpp archive from developer.apple.com and replaces the local metal-cpp/ directory.
    2. Scans the downloaded headers to derive class names for each framework.
    3. Downloads the corresponding Apple documentation JSON into a temporary directory.
    4. Distills the JSON into a single metal-docs.json containing member ordering, grouping, and summaries.
    5. Writes a version.json with metadata about the download.

    The metal-docs.json file contains factual API names, their logical grouping order,
    and short documentation summaries suitable for generating XML doc comments.
    The full Apple documentation JSON files are downloaded to a temporary directory
    and cleaned up after distillation.

.EXAMPLE
    pwsh -File update-sources.ps1
    pwsh -File update-sources.ps1 -SkipMetalCpp   # only refresh documentation
#>

param(
    [switch]$SkipMetalCpp,
    [switch]$SkipDocs
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$scriptDir = $PSScriptRoot
$metalCppDir = Join-Path $scriptDir 'metal-cpp'
$apiOrderFile = Join-Path $scriptDir 'metal-docs.json'

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

#region Apple docs download & distillation

# Regex matching the C++ class declaration pattern used in metal-cpp headers:
#   class ClassName : public NS::Referencing<ClassName> or NS::Copying<ClassName>
$classPattern = [regex]'class\s+(\w+)\s*:\s*public\s+NS::(?:Referencing|Copying)\s*<'
# Regex matching enum/options declarations: _MTL_ENUM(type, Name) { ... } or _MTLFX_OPTIONS(type, Name) { ... }
$enumPattern = [regex]'_(\w+)_(ENUM|OPTIONS)\s*\(\s*[^,]+?\s*,\s*(\w+)\s*\)'
# Regex to find namespace declarations: namespace MTL { ... }
$nsPattern = [regex]'namespace\s+(\w+)\s*\{'

# Namespace -> ObjC prefix mapping (e.g., MTL::Device -> MTLDevice, CA::MetalLayer -> CAMetalLayer)
$nsPrefixMap = @{
    'MTL'    = 'MTL'
    'MTL4'   = 'MTL4'
    'MTLFX'  = 'MTLFX'
    'MTL4FX' = 'MTL4FX'
    'CA'     = 'CA'
    'NS'     = 'NS'
}

function Get-ClassNamesFromHeaders {
    $classes = [System.Collections.Generic.List[PSCustomObject]]::new()
    $seen = [System.Collections.Generic.HashSet[string]]::new()

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

            $content = Get-Content $file.FullName -Raw

            # Build namespace position map for this file
            $nsPositions = [System.Collections.Generic.List[PSCustomObject]]::new()
            foreach ($nm in $nsPattern.Matches($content)) {
                $nsPositions.Add([PSCustomObject]@{ Ns = $nm.Groups[1].Value; Pos = $nm.Index })
            }

            # Extract actual class names from the header content
            $classMatches = $classPattern.Matches($content)

            if ($classMatches.Count -eq 0) {
                # Fallback: use file name as slug (for non-class headers like MTLDataType.hpp)
                $slug = [System.IO.Path]::GetFileNameWithoutExtension($name).ToLowerInvariant()
                if ($seen.Add($slug)) {
                    $classes.Add([PSCustomObject]@{
                        Module    = $docModule
                        ClassName = $slug
                        FileName  = $name
                    })
                }
            }
            else {
                foreach ($cm in $classMatches) {
                    $rawClassName = $cm.Groups[1].Value

                    # Find the enclosing namespace for this class declaration
                    $ns = ''
                    for ($i = $nsPositions.Count - 1; $i -ge 0; $i--) {
                        if ($nsPositions[$i].Pos -lt $cm.Index) {
                            $ns = $nsPositions[$i].Ns
                            break
                        }
                    }

                    # Build the full ObjC-style class name: MTL + Device = MTLDevice
                    $prefix = if ($nsPrefixMap.ContainsKey($ns)) { $nsPrefixMap[$ns] } else { $ns }
                    $slug = ($prefix + $rawClassName).ToLowerInvariant()

                    if ($seen.Add($slug)) {
                        $classes.Add([PSCustomObject]@{
                            Module    = $docModule
                            ClassName = $slug
                            FileName  = $name
                        })
                    }
                }
            }

            # Extract enum/options declarations from the same header
            foreach ($em in $enumPattern.Matches($content)) {
                $enumName = $em.Groups[3].Value

                # Find the enclosing namespace for this enum declaration
                $ns = ''
                for ($i = $nsPositions.Count - 1; $i -ge 0; $i--) {
                    if ($nsPositions[$i].Pos -lt $em.Index) {
                        $ns = $nsPositions[$i].Ns
                        break
                    }
                }

                $prefix = if ($nsPrefixMap.ContainsKey($ns)) { $nsPrefixMap[$ns] } else { $ns }
                $slug = ($prefix + $enumName).ToLowerInvariant()

                if ($seen.Add($slug)) {
                    $classes.Add([PSCustomObject]@{
                        Module    = $docModule
                        ClassName = $slug
                        FileName  = $name
                    })
                }
            }
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

    # Ensure parent directory exists for nested slugs (e.g., "class/member")
    $outDir2 = [System.IO.Path]::GetDirectoryName($outFile)
    if (-not (Test-Path $outDir2)) { New-Item $outDir2 -ItemType Directory -Force | Out-Null }

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

function Format-Json {
    param([string]$Json)

    $sb = [System.Text.StringBuilder]::new()
    $indent = 0
    $inString = $false
    $escaped = $false
    $chars = $Json.ToCharArray()

    for ($i = 0; $i -lt $chars.Length; $i++) {
        $c = $chars[$i]

        if ($escaped) { [void]$sb.Append($c); $escaped = $false; continue }
        if ($c -eq '\' -and $inString) { [void]$sb.Append($c); $escaped = $true; continue }
        if ($c -eq '"') { [void]$sb.Append($c); $inString = !$inString; continue }
        if ($inString) { [void]$sb.Append($c); continue }

        switch ($c) {
            '{' { [void]$sb.Append($c).Append("`n"); $indent++; [void]$sb.Append(' ' * ($indent * 2)) }
            '[' { [void]$sb.Append($c).Append("`n"); $indent++; [void]$sb.Append(' ' * ($indent * 2)) }
            '}' { [void]$sb.Append("`n"); $indent--; [void]$sb.Append(' ' * ($indent * 2)).Append($c) }
            ']' { [void]$sb.Append("`n"); $indent--; [void]$sb.Append(' ' * ($indent * 2)).Append($c) }
            ',' { [void]$sb.Append($c).Append("`n").Append(' ' * ($indent * 2)) }
            ':' { [void]$sb.Append(': ') }
            default { if (-not [char]::IsWhiteSpace($c)) { [void]$sb.Append($c) } }
        }
    }

    return $sb.ToString()
}

function Get-SubPageIdentifiers {
    param([string]$JsonPath)

    $json = [System.IO.File]::ReadAllText($JsonPath, [System.Text.Encoding]::UTF8) | ConvertFrom-Json
    $result = [System.Collections.Generic.List[PSCustomObject]]::new()

    $sections = $json.PSObject.Properties['topicSections']
    if (-not $sections -or -not $sections.Value) { return $result }

    foreach ($section in $sections.Value) {
        foreach ($id in $section.identifiers) {
            # Sub-page identifiers are like: doc://com.apple.metal/documentation/Metal/device-inspection
            # They have only one path segment after the framework name, and use kebab-case.
            if ($id -match '/documentation/[^/]+/([^/]+)$') {
                $slug = $Matches[1]
                # Sub-page slugs use kebab-case; member or type identifiers use PascalCase
                if ($slug -cmatch '-') {
                    $result.Add([PSCustomObject]@{ Slug = $slug.ToLowerInvariant(); Title = $section.title })
                }
            }
        }
    }

    return $result
}

function Render-Abstract {
    param([object[]]$AbstractNodes)

    if (-not $AbstractNodes) { return $null }

    $parts = [System.Collections.Generic.List[string]]::new()
    foreach ($node in $AbstractNodes) {
        switch ($node.type) {
            'text'      { $parts.Add($node.text) }
            'codeVoice' { $parts.Add($node.code) }
            'reference' { if ($node.PSObject.Properties['title']) { $parts.Add($node.title) } }
            'emphasis'  { if ($node.PSObject.Properties['inlineContent']) { foreach ($ic in $node.inlineContent) { if ($ic.type -eq 'text') { $parts.Add($ic.text) } } } }
        }
    }

    $text = ($parts -join '').Trim()
    if ($text.Length -eq 0) { return $null }
    return $text
}

function Render-DeprecationSummary {
    param(
        [object[]]$Nodes,
        [object]$References = $null
    )

    if (-not $Nodes) { return $null }

    # deprecationSummary is an array of paragraph objects, each with inlineContent
    $parts = [System.Collections.Generic.List[string]]::new()
    foreach ($node in $Nodes) {
        if (-not $node.PSObject.Properties['inlineContent']) { continue }
        foreach ($ic in $node.inlineContent) {
            switch ($ic.type) {
                'text'      { $parts.Add($ic.text) }
                'codeVoice' { $parts.Add($ic.code) }
                'reference' {
                    # Resolve title from the page's references section
                    $title = $null
                    if ($References -and $ic.PSObject.Properties['identifier']) {
                        $refEntry = $References.PSObject.Properties[$ic.identifier]
                        if ($refEntry -and $refEntry.Value.PSObject.Properties['title']) {
                            $title = $refEntry.Value.title
                        }
                    }
                    if (-not $title -and $ic.PSObject.Properties['title']) {
                        $title = $ic.title
                    }
                    if ($title) { $parts.Add($title) }
                }
            }
        }
    }

    $text = ($parts -join '').Trim()
    if ($text.Length -eq 0) { return $null }
    return $text
}

function Extract-MemberOrder {
    param(
        [string]$JsonPath,
        [string]$Module = '',
        [string]$ModuleDir = ''
    )

    $json = [System.IO.File]::ReadAllText($JsonPath, [System.Text.Encoding]::UTF8) | ConvertFrom-Json
    $groups = [System.Collections.Generic.List[PSCustomObject]]::new()

    $sections = $json.PSObject.Properties['topicSections']
    if (-not $sections -or -not $sections.Value) { return $groups }

    # Build lookups from identifier -> summary text and identifier -> deprecated flag
    $refSummaries = @{}
    $refDeprecated = [System.Collections.Generic.HashSet[string]]::new()
    $refsProp = $json.PSObject.Properties['references']
    if ($refsProp -and $refsProp.Value) {
        foreach ($rp in $refsProp.Value.PSObject.Properties) {
            $absProp = $rp.Value.PSObject.Properties['abstract']
            if ($absProp -and $absProp.Value) {
                $summary = Render-Abstract $absProp.Value
                if ($summary) {
                    $refSummaries[$rp.Name] = $summary
                }
            }
            $depProp = $rp.Value.PSObject.Properties['deprecated']
            if ($depProp -and $depProp.Value -eq $true) {
                [void]$refDeprecated.Add($rp.Name)
            }
        }
    }

    foreach ($section in $sections.Value) {
        $members = [System.Collections.Generic.List[PSCustomObject]]::new()

        foreach ($id in $section.identifiers) {
            # Match member identifiers: .../ClassName/memberName or .../ClassName/memberName(_:)
            # These have at least 2 segments after the framework name
            if ($id -match '/documentation/[^/]+/[^/]+/([^/]+)$') {
                $memberName = $Matches[1]
                $summary = if ($refSummaries.ContainsKey($id)) { $refSummaries[$id] } else { $null }
                $isDeprecated = $refDeprecated.Contains($id)

                $deprecatedMessage = $null
                if ($isDeprecated -and $Module -and $ModuleDir) {
                    # Extract member slug from identifier: .../Module/Class/member -> class/member
                    if ($id -match '/documentation/[^/]+/([^/]+/[^/]+)$') {
                        $memberSlug = $Matches[1].ToLowerInvariant()
                        $memberFile = Download-DocJson -Module $Module -Slug $memberSlug -OutDir $ModuleDir
                        if (-not $memberFile) {
                            $memberFile = Join-Path $ModuleDir "$($memberSlug -replace '/', [System.IO.Path]::DirectorySeparatorChar).json"
                        }
                        if (Test-Path $memberFile) {
                            $memberJson = [System.IO.File]::ReadAllText($memberFile, [System.Text.Encoding]::UTF8) | ConvertFrom-Json
                            $dsProp = $memberJson.PSObject.Properties['deprecationSummary']
                            if ($dsProp -and $dsProp.Value) {
                                $memberRefs = $null
                                if ($memberJson.PSObject.Properties['references']) { $memberRefs = $memberJson.references }
                                $deprecatedMessage = Render-DeprecationSummary $dsProp.Value $memberRefs
                            }
                        }
                    }
                }

                $memberObj = [ordered]@{ name = $memberName }
                if ($summary) { $memberObj['summary'] = $summary }
                if ($isDeprecated) {
                    $memberObj['deprecated'] = $true
                    if ($deprecatedMessage) { $memberObj['deprecatedMessage'] = $deprecatedMessage }
                }
                $members.Add([PSCustomObject]$memberObj)
            }
        }

        if ($members.Count -gt 0) {
            $groups.Add([PSCustomObject]@{
                title   = $section.title
                members = @($members)
            })
        }
    }

    return $groups
}

function Extract-ClassSummary {
    param([string]$JsonPath)

    $json = [System.IO.File]::ReadAllText($JsonPath, [System.Text.Encoding]::UTF8) | ConvertFrom-Json
    $absProp = $json.PSObject.Properties['abstract']
    if (-not $absProp -or -not $absProp.Value) { return $null }
    return Render-Abstract $absProp.Value
}

function Extract-DeprecationSummary {
    param([string]$JsonPath)

    $json = [System.IO.File]::ReadAllText($JsonPath, [System.Text.Encoding]::UTF8) | ConvertFrom-Json
    $dsProp = $json.PSObject.Properties['deprecationSummary']
    if (-not $dsProp -or -not $dsProp.Value) { return $null }
    $refs = $null
    if ($json.PSObject.Properties['references']) { $refs = $json.references }
    return Render-DeprecationSummary $dsProp.Value $refs
}

function Update-ApiOrder {
    $tempDocsDir = Join-Path ([System.IO.Path]::GetTempPath()) 'metal-net-apple-docs'
    if (Test-Path $tempDocsDir) { Remove-Item $tempDocsDir -Recurse -Force }
    New-Item $tempDocsDir -ItemType Directory -Force | Out-Null

    $classes = Get-ClassNamesFromHeaders
    $total = $classes.Count
    $current = 0
    $apiOrder = [ordered]@{}

    Write-Progress -Id $idDocs -Activity 'Downloading Apple documentation' -Status "0 / $total" -PercentComplete 0

    foreach ($entry in $classes) {
        $current++
        $pct = [math]::Floor(($current / $total) * 100)
        Write-Progress -Id $idDocs -Activity 'Downloading Apple documentation' `
            -Status "$current / $total — $($entry.FileName)" -PercentComplete $pct

        $moduleDir = Join-Path $tempDocsDir $entry.Module
        if (-not (Test-Path $moduleDir)) { New-Item $moduleDir -ItemType Directory -Force | Out-Null }

        # Download the main class doc
        $mainFile = Download-DocJson -Module $entry.Module -Slug $entry.ClassName -OutDir $moduleDir
        if (-not $mainFile) {
            $mainFile = Join-Path $moduleDir "$($entry.ClassName).json"
        }
        if (-not (Test-Path $mainFile)) { continue }

        # Extract class-level summary and deprecation info
        $classSummary = Extract-ClassSummary -JsonPath $mainFile
        $classDeprecation = Extract-DeprecationSummary -JsonPath $mainFile

        # Collect member groups from the main page
        $allGroups = [System.Collections.Generic.List[PSCustomObject]]::new()
        $mainGroups = Extract-MemberOrder -JsonPath $mainFile -Module $entry.Module -ModuleDir $moduleDir
        foreach ($g in $mainGroups) { $allGroups.Add($g) }

        # Download and collect sub-pages
        $subPages = Get-SubPageIdentifiers -JsonPath $mainFile
        foreach ($sub in $subPages) {
            $subFile = Download-DocJson -Module $entry.Module -Slug $sub.Slug -OutDir $moduleDir
            if (-not $subFile) {
                $subFile = Join-Path $moduleDir "$($sub.Slug).json"
            }
            if (Test-Path $subFile) {
                $subGroups = Extract-MemberOrder -JsonPath $subFile -Module $entry.Module -ModuleDir $moduleDir
                foreach ($g in $subGroups) { $allGroups.Add($g) }
            }
        }

        if ($allGroups.Count -gt 0 -or $classSummary -or $classDeprecation) {
            $classEntry = [ordered]@{}
            if ($classSummary) { $classEntry['summary'] = $classSummary }
            if ($classDeprecation) {
                $classEntry['deprecated'] = $true
                $classEntry['deprecatedMessage'] = $classDeprecation
            }
            if ($allGroups.Count -gt 0) { $classEntry['groups'] = @($allGroups) }
            $apiOrder[$entry.ClassName] = [PSCustomObject]$classEntry
        }
    }

    Write-Progress -Id $idDocs -Activity 'Downloading Apple documentation' -Status 'Done' -PercentComplete 100 -Completed

    # Write the distilled metal-docs.json
    $compactJson = $apiOrder | ConvertTo-Json -Depth 6 -Compress
    $formattedJson = Format-Json $compactJson
    [System.IO.File]::WriteAllText($apiOrderFile, $formattedJson, [System.Text.UTF8Encoding]::new($false))

    # Cleanup temp docs
    Remove-Item $tempDocsDir -Recurse -Force -ErrorAction SilentlyContinue

    $classCount = $apiOrder.Count
    $groupCount = ($apiOrder.Values | ForEach-Object { if ($_.PSObject.Properties['groups']) { $_.groups.Count } else { 0 } } | Measure-Object -Sum).Sum
    Write-Host "  Distilled $classCount entries (classes + enums), $groupCount groups -> metal-docs.json" -ForegroundColor Green
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
    Update-ApiOrder
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
