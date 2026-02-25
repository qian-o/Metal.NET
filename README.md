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

// Create a Metal device
MTLDevice device = MTLDevice.CreateSystemDefaultDevice();

// Create a command queue
using MTLCommandQueue queue = device.NewCommandQueue();

// Create a library from default.metallib
using MTLLibrary library = device.NewDefaultLibrary();
```

## Memory Management

### Ownership Model

Every `NativeObject` wrapper has a [`NativeObjectOwnership`](Metal.NET/Common/NativeObject.cs) that controls its lifetime:

| Ownership | `Dispose()` releases | Finalizer releases | Usage |
|-----------|:--------------------:|:------------------:|-------|
| `Borrowed` | ✗ | ✗ | Property getters, `objectAtIndex:` |
| `Owned` | ✓ | ✗ | Method return values, `out NSError` |
| `Managed` | ✓ | ✓ | Objects created via parameterless constructor (`AllocInit`) |

```csharp
// Managed — fully C#-created, GC can release as safety net
var desc = new MTLTextureDescriptor();

// Owned — method return, only explicit Dispose releases
using MTLLibrary library = device.NewDefaultLibrary();

// Borrowed — property getter, retained by parent object
MTLDevice device = commandQueue.Device;
```

### Finalization

The GC finalizer only releases `Managed` instances. `Owned` wrappers (method returns) must be explicitly disposed. `Borrowed` wrappers never release:

```csharp
public enum NativeObjectOwnership { Borrowed, Owned, Managed }

public abstract class NativeObject(nint nativePtr, NativeObjectOwnership ownership) : IDisposable
{
    ~NativeObject()
    {
        if (Ownership is NativeObjectOwnership.Managed) Release();
    }

    public void Dispose() { Release(); GC.SuppressFinalize(this); }
}
```

## Project Structure

```
Metal.NET.slnx
├── Metal.NET/                            ← Binding library (targets .NET 10, macOS 15+)
│   ├── Common/
│   │   ├── NativeObject.cs               ← NativeObjectOwnership enum + INativeObject<TSelf> + base class
│   │   ├── ObjectiveCRuntime.cs          ← P/Invoke to libobjc.dylib (objc_msgSend)
│   │   ├── Selector.cs                   ← ObjC selector with implicit string conversion
│   │   ├── Bool8.cs                      ← ObjC BOOL mapped to a single byte
│   │   └── MTLStructs.cs                ← Blittable structs (MTLOrigin, MTLSize, etc.)
│   ├── Foundation/                       ← Hand-written Foundation types
│   │   ├── NSString.cs                   ← Bidirectional string conversion
│   │   ├── NSError.cs                    ← Error wrapper with LocalizedDescription
│   │   ├── NSArray.cs                    ← NSArray ↔ T[] conversion utilities
│   │   ├── NSURL.cs                      ← File URL creation
│   │   └── NSAutoreleasePool.cs          ← Autorelease pool management
│   ├── Metal/                            ← Auto-generated Metal API (352 files)
│   ├── MetalFX/                          ← Auto-generated MetalFX (18 files)
│   └── QuartzCore/                       ← Auto-generated QuartzCore (2 files)
│
└── Metal.NET.Generator/                  ← Offline code generator
    ├── Program.cs                        ← Entry point
    ├── Generator.cs                      ← Orchestrator (parser → emitter pipeline)
    ├── CppParser.cs                      ← Regex-based metal-cpp header parser
    ├── CSharpEmitter.cs                  ← C# source code emitter
    ├── TypeMapper.cs                     ← C++ → C# type mapping and naming
    ├── GeneratorContext.cs               ← Shared state between parser and emitter
    ├── Models.cs                         ← Data models (EnumDef, ClassDef, MethodInfo, etc.)
    └── metal-cpp/                        ← metal-cpp headers (generation source)
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

If you are looking for more mature or alternative Metal bindings for .NET, consider:

- [SharpMetal](https://github.com/IsaacMarovitz/SharpMetal) — A community-maintained C# Metal binding library.
- **.NET `net-macos` / `net-ios` TFM** — Apple platform targets shipped with .NET that include official Metal API bindings via [dotnet/macios](https://github.com/dotnet/macios).

## License

This project is licensed under the [MIT License](LICENSE).

## Trademarks

"Metal" is a trademark of Apple Inc. This project is not affiliated with or endorsed by Apple Inc.

## Third-Party Notices

See [THIRD-PARTY-NOTICES.md](THIRD-PARTY-NOTICES.md) for details on third-party components used in this project.
