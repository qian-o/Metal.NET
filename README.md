# Metal.NET

[![NuGet Version](https://img.shields.io/nuget/v/Metal.NET)](https://nuget.org/packages/Metal.NET)

C# bindings for Apple's Metal graphics API, auto-generated from [metal-cpp](https://developer.apple.com/metal/cpp/) headers.

## Project Structure

```
Metal.NET.slnx
├── Metal.NET/                            ← Binding library (targets .NET 10, macOS 15+)
│   ├── Common/
│   │   ├── NativeObject.cs               ← INativeObject<TSelf> interface + abstract base wrapper
│   │   ├── ObjectiveCRuntime.cs          ← P/Invoke to libobjc.dylib (objc_msgSend)
│   │   ├── Selector.cs                   ← ObjC selector with implicit string conversion
│   │   ├── Bool8.cs                      ← ObjC BOOL mapped to a single byte
│   │   └── MTLStructs.cs                ← Blittable structs (MTLOrigin, MTLSize, etc.)
│   ├── Foundation/                       ← Hand-written Foundation types
│   │   ├── NSString.cs                   ← Bidirectional string conversion
│   │   ├── NSError.cs                    ← Error wrapper with LocalizedDescription
│   │   ├── NSArray.cs                    ← Generic array access via ObjectAtIndex<T>
│   │   └── NSURL.cs                      ← File URL creation
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

## Generated Code Patterns

### INativeObject\<TSelf\>

All ObjC wrappers implement `INativeObject<TSelf>`, a static abstract factory interface that enables generic construction from raw pointers:

```csharp
public interface INativeObject<TSelf> where TSelf : NativeObject, INativeObject<TSelf>
{
    static abstract TSelf Create(nint nativePtr);
}
```

This allows `NativeObject.GetProperty<T>` and `NSArray.ObjectAtIndex<T>` to create wrapper instances through the `T.Create(nativePtr)` factory call, eliminating nullable returns for property accessors.

### Classes

All ObjC wrappers inherit from `NativeObject`, which holds a raw Objective-C pointer and decrements its reference count (`release`) on dispose.
Classes use C# 14.0 primary constructors and the `field` keyword for cached properties:

```csharp
public class MTLCommandQueue(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLCommandQueue>
{
    public static MTLCommandQueue Create(nint nativePtr) => new(nativePtr);

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLCommandQueueBindings.Device);
    }

    public MTLCommandBuffer CommandBuffer()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueBindings.CommandBuffer);

        return new(nativePtr);
    }
}
```

### Free C Functions

C functions are placed as static methods in their corresponding class:

```csharp
using MTLDevice device = MTLDevice.CreateSystemDefaultDevice();
```

## Updating Bindings

1. Download the latest [metal-cpp](https://developer.apple.com/metal/cpp/) archive
2. Replace `Metal.NET.Generator/metal-cpp/` contents
3. Run the generator:

```bash
dotnet run --project Metal.NET.Generator
```

4. Build:

```bash
dotnet build Metal.NET
```

## Disclaimer

> **This library was built with AI assistance.** It has undergone preliminary testing to verify basic usability, but has **not** been exhaustively validated in production scenarios. If you plan to use it in a real project, please ensure it meets your requirements through thorough testing.

## Alternatives

If you are looking for more mature or alternative Metal bindings for .NET, consider:

- [SharpMetal](https://github.com/IsaacMarovitz/SharpMetal) — A community-maintained C# Metal binding library.
- **.NET `net-macos` / `net-ios` TFM** — Apple platform targets shipped with .NET that include official Metal API bindings via [dotnet/macios](https://github.com/dotnet/macios).

## Trademarks

"Metal" is a trademark of Apple Inc. This project is not affiliated with or endorsed by Apple Inc.

## Third-Party Notices

See [THIRD-PARTY-NOTICES.md](THIRD-PARTY-NOTICES.md) for details on third-party components used in this project.
