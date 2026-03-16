# Metal.NET

[![NuGet Version](https://img.shields.io/nuget/v/Metal.NET)](https://nuget.org/packages/Metal.NET)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

C# bindings for Apple's Metal graphics API, auto-generated from [metal-cpp](https://developer.apple.com/metal/cpp/) headers.

## Installation

```bash
dotnet add package Metal.NET
```

> **Requirements:** .NET 10+, macOS 15+

## Quick Start

```csharp
using Metal.NET;

MTLDevice device = MTLDevice.CreateSystemDefaultDevice();

using MTLCommandQueue queue = device.NewCommandQueue();

using MTLLibrary library = device.NewDefaultLibrary();
```

## Memory Management

Every `NativeObject` wrapper has a `NativeObjectOwnership` that controls its lifetime:

| Ownership | `Dispose()` releases | Finalizer releases | Usage |
|-----------|:--------------------:|:------------------:|-------|
| `Borrowed` | ✗ | ✗ | Property getters, `objectAtIndex:` |
| `Owned` | ✓ | ✗ | Method return values, `out NSError` |
| `Managed` | ✓ | ✓ | Objects created via parameterless constructor (`AllocInit`) |

```csharp
// Managed – finalizer will release if not disposed
var desc = new MTLTextureDescriptor();

// Owned – caller is responsible for disposal
using MTLLibrary library = device.NewDefaultLibrary();

// Borrowed – do not dispose
MTLDevice device = commandQueue.Device;
```

## Project Structure

```
Metal.NET.slnx
├── Metal.NET/                          ← Runtime library
│   ├── Common/                         ← Hand-written interop core
│   │   ├── NativeObject.cs             ← Base class for all ObjC wrappers
│   │   ├── NativeBlock.cs              ← Base class for ObjC block wrappers
│   │   ├── ObjectiveC.cs               ← Auto-generated objc_msgSend overloads
│   │   └── ...
│   ├── Foundation/                     ← Hand-written NS* wrappers
│   ├── Metal/                          ← Auto-generated Metal API (231 files)
│   │   ├── MTLDelegates.cs             ← Auto-generated block handler classes
│   │   └── ...
│   ├── MetalFX/                        ← Auto-generated MetalFX API (18 files)
│   └── QuartzCore/                     ← Auto-generated QuartzCore API (2 files)
│
└── Metal.NET.Generator/                ← Code generator
    ├── CppParser.cs                    ← Parses metal-cpp headers
    ├── CSharpEmitter.cs                ← Emits C# source files
    ├── TypeMapper.cs                   ← C++ → C# type mapping
    ├── update-sources.ps1              ← Downloads metal-cpp & Apple docs
    ├── metal-cpp/                      ← Upstream metal-cpp headers
    └── apple-docs/                     ← Apple documentation JSON (generated)
```

## Updating Bindings

Run the update script to fetch the latest metal-cpp headers and Apple documentation JSON, then regenerate:

```bash
pwsh -File Metal.NET.Generator/update-sources.ps1
dotnet run --project Metal.NET.Generator
dotnet build Metal.NET
```

You can also update them independently:

```bash
pwsh -File Metal.NET.Generator/update-sources.ps1 -SkipDocs       # only update metal-cpp
pwsh -File Metal.NET.Generator/update-sources.ps1 -SkipMetalCpp   # only refresh documentation JSON
```

## Disclaimer

> **This library was built with AI assistance.** It has undergone preliminary testing but has **not** been exhaustively validated in production scenarios. Please test thoroughly before production use.

## Alternatives

- [SharpMetal](https://github.com/IsaacMarovitz/SharpMetal)
- [dotnet/macios](https://github.com/dotnet/macios)

## License

[MIT License](LICENSE) · "Metal" is a trademark of Apple Inc. · See [THIRD-PARTY-NOTICES.md](THIRD-PARTY-NOTICES.md).
