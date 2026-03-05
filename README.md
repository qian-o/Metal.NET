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
// Managed
var desc = new MTLTextureDescriptor();

// Owned
using MTLLibrary library = device.NewDefaultLibrary();

// Borrowed
MTLDevice device = commandQueue.Device;
```

## Project Structure

```
Metal.NET.slnx
├── Metal.NET/
│   ├── Common/
│   │   ├── NativeObject.cs
│   │   ├── ObjectiveC.cs              ← Auto-generated P/Invoke to libobjc (objc_msgSend)
│   │   ├── Selector.cs
│   │   └── Bool8.cs
│   ├── CoreGraphics/
│   │   └── CGColorSpace.cs
│   ├── Foundation/
│   │   ├── NSObject.cs
│   │   ├── NSString.cs
│   │   ├── NSError.cs
│   │   ├── NSArray.cs
│   │   ├── NSURL.cs
│   │   ├── NSDictionary.cs
│   │   ├── NSNumber.cs
│   │   ├── NSData.cs
│   │   ├── NSBundle.cs
│   │   ├── NSAutoreleasePool.cs
│   │   └── NSEnums.cs                 ← Auto-generated
│   ├── GCD/
│   │   ├── DispatchObject.cs
│   │   ├── DispatchData.cs
│   │   └── DispatchQueue.cs
│   ├── Metal/                          ← Auto-generated (231 files)
│   ├── MetalFX/                        ← Auto-generated (18 files)
│   └── QuartzCore/                     ← Auto-generated (2 files)
│
└── Metal.NET.Generator/
    ├── Program.cs
    ├── Generator.cs
    ├── CppParser.cs
    ├── CSharpEmitter.cs
    ├── TypeMapper.cs
    ├── GeneratorContext.cs
    ├── Models.cs
    └── metal-cpp/
```

## Updating Bindings

1. Download the latest [metal-cpp](https://developer.apple.com/metal/cpp/) archive.
2. Replace the contents of `Metal.NET.Generator/metal-cpp/`.
3. Run the generator:

   ```bash
   dotnet run --project Metal.NET.Generator
   ```

4. Build and verify:

   ```bash
   dotnet build Metal.NET
   ```

## Disclaimer

> **This library was built with AI assistance.** It has undergone preliminary testing to verify basic usability, but has **not** been exhaustively validated in production scenarios. If you plan to use it in a real project, please ensure it meets your requirements through thorough testing.

## Alternatives

- [SharpMetal](https://github.com/IsaacMarovitz/SharpMetal)
- [dotnet/macios](https://github.com/dotnet/macios)

## License

This project is licensed under the [MIT License](LICENSE).

## Trademarks

"Metal" is a trademark of Apple Inc. This project is not affiliated with or endorsed by Apple Inc.

## Third-Party Notices

See [THIRD-PARTY-NOTICES.md](THIRD-PARTY-NOTICES.md).
