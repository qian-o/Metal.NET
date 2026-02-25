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

## Memory Management

### Owned vs Borrowed References

Every `NativeObject` wrapper tracks whether it **owns** its native reference via `bool ownsReference`:

- **Owned** (`true`) — the wrapper sends `release` on `Dispose()` or GC finalization. Used for objects returned by `alloc`, `new`, `copy`, or `mutableCopy` selectors.
- **Borrowed** (`false`) — the wrapper never sends `release`. Used for property getters, `objectAtIndex:`, and `out NSError` parameters.

```csharp
// Owned — selector begins with "new", caller must release
using MTLLibrary library = device.NewDefaultLibrary();

// Borrowed — property getter, retained by the parent object
MTLDevice device = commandQueue.Device;
```

### GC-Safe Dispose

`NativeObject` implements the full dispose pattern with a finalizer. `Release()` uses `Interlocked.Exchange` to guarantee exactly-once semantics, making double-`Dispose()` and GC finalization safe:

```csharp
public abstract class NativeObject(nint nativePtr, bool ownsReference) : IDisposable
{
    ~NativeObject() => Release();

    public void Dispose() { Release(); GC.SuppressFinalize(this); }

    private void Release()
    {
        if (Interlocked.Exchange(ref disposed, 1) is not 0) return;
        if (OwnsReference) ObjectiveCRuntime.Release(NativePtr);
    }
}
```

## Generated Code Patterns

### INativeObject\<TSelf\>

All ObjC wrappers implement `INativeObject<TSelf>`, a static abstract factory interface:

```csharp
public interface INativeObject<TSelf> where TSelf : NativeObject, INativeObject<TSelf>
{
    static abstract TSelf Create(nint nativePtr, bool ownsReference);
}
```

This enables `GetProperty<T>` and `NSArray.ToArray<T>` to construct typed wrappers through `T.Create(nativePtr, false)` without reflection.

### Classes

All ObjC wrappers use C# 14.0 primary constructors with the `field` keyword for cached properties:

```csharp
public class MTLCommandQueue(nint nativePtr, bool ownsReference)
    : NativeObject(nativePtr, ownsReference), INativeObject<MTLCommandQueue>
{
    public static MTLCommandQueue Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    // Borrowed — property getter returns a cached wrapper
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLCommandQueueBindings.Device);
    }

    // Borrowed — commandBuffer is not a new/alloc/copy selector
    public MTLCommandBuffer CommandBuffer()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCommandQueueBindings.CommandBuffer);

        return new(nativePtr, false);
    }
}
```

### Bool Properties

ObjC `BOOL` properties are exposed as `Bool8` to avoid implicit conversion overhead:

```csharp
public Bool8 IsHeadless
{
    get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDeviceBindings.IsHeadless);
}
```

### Array Properties

NSArray properties are marshalled as idiomatic C# arrays (`T[]`):

```csharp
public MTLBinaryArchive[] BinaryArchives
{
    get => GetArrayProperty<MTLBinaryArchive>(MTLComputePipelineDescriptorBindings.BinaryArchives);
    set => SetArrayProperty(MTLComputePipelineDescriptorBindings.SetBinaryArchives, value);
}
```

### Indexers

ObjC `objectAtIndexedSubscript:` / `setObject:atIndexedSubscript:` pairs are emitted as C# indexers:

```csharp
public MTLRenderPipelineColorAttachmentDescriptor this[nuint attachmentIndex]
{
    get
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, Bindings.Object, attachmentIndex);

        return new(nativePtr, false);
    }
    set
    {
        ObjectiveCRuntime.MsgSend(NativePtr, Bindings.SetObject, value.NativePtr, attachmentIndex);
    }
}
```

### Free C Functions

C functions are placed as static methods in their corresponding class:

```csharp
using MTLDevice device = MTLDevice.CreateSystemDefaultDevice();

MTLDevice[] allDevices = MTLDevice.CopyAllDevices();
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
