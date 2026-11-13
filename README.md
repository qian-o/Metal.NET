# Metal.NET

[![NuGet Version](https://img.shields.io/nuget/v/Metal.NET)](https://nuget.org/packages/Metal.NET)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

Low-level, zero-overhead C# bindings for Apple's **Metal**, **Metal 4**, and **MetalFX** frameworks, auto-generated from the macOS SDK via Clang AST and Swift Symbol Graph extraction.

## Features

- **Comprehensive Coverage** — Full bindings for Metal, Metal 4, and MetalFX, plus essential types from Foundation (`NSObject`, `NSString`, `NSArray`, `NSError`), CoreAnimation (`CAMetalLayer`, `CAMetalDrawable`), CoreGraphics, GCD, and SIMD.
- **Zero-Overhead `readonly struct` Handles** — Every Objective-C wrapper is an 8-byte `unmanaged` struct wrapping `nint`, eliminating GC allocations, object headers, and finalizer pressure.
- **Flattened Hierarchy & Implicit Upcasting** — Inherited members are emitted directly on derived types with zero-cost `implicit operator` conversions across the inheritance chain.
- **Zero-Copy Span & Block Interop** — Array APIs accept `ReadOnlySpan<T>` by pinning `unmanaged` handles directly; Objective-C blocks use `UnmanagedCallersOnly` callbacks via `NativeBlock`.
- **Native AOT & Trimming Ready** — Fully annotated with `IsAotCompatible` and `IsTrimmable`.

## Installation

```bash
dotnet add package Metal.NET
```

> **Requirements:** .NET 10+, macOS 15+

## Quick Start

```csharp
using Metal.NET;

MTLDevice device = MTLDevice.CreateSystemDefaultDevice();
using MTLCommandQueue queue = device.MakeCommandQueue();
using MTLLibrary library = device.MakeDefaultLibrary();

using NSString kernelName = new("myKernel");
using MTLFunction kernel = library.MakeFunction(kernelName);
using MTLComputePipelineState pso = device.MakeComputePipelineState(kernel, out NSError error);

using MTLBuffer buffer = device.MakeBuffer(1024, MTLResourceOptions.StorageModeShared);
```

## Memory Management

All wrapper types are 8-byte `readonly struct` handles (`unmanaged`) that follow standard Objective-C reference counting (`Retain()` / `Release()` / `Dispose()`):

| Origin | Caller Must `Dispose()` / `Release()` | Examples |
|--------|:-------------------------------------:|----------|
| `new()` / `Init*` | Yes | `new MTLTextureDescriptor()`, `new NSString("...")` |
| `Make*` / `New*` / `Copy*` | Yes | `device.MakeBuffer(...)`, `device.MakeDefaultLibrary()` |
| Properties / `NextDrawable()` / Encoders | No | `queue.Device`, `layer.NextDrawable()` (autoreleased / borrowed) |

```csharp
// Allocated or factory-created objects — caller owns and disposes
using var desc = new MTLTextureDescriptor();
using MTLLibrary library = device.MakeDefaultLibrary();

// Borrowed property — do not dispose
MTLDevice device = queue.Device;
```

## Building & Regenerating Bindings

Bindings are generated from `Metal.NET.Generator/metal-ast.json` (extracted in CI via `.github/workflows/extract-metal-api.yml`):

```bash
dotnet run --project Metal.NET.Generator
dotnet build Metal.NET
```

## License

[MIT](LICENSE)
