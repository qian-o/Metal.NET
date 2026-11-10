# Metal.NET

[![NuGet Version](https://img.shields.io/nuget/v/Metal.NET)](https://nuget.org/packages/Metal.NET)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

Low-level C# bindings for Apple's **Metal** and **MetalFX** frameworks — auto-generated from the macOS 27.0 SDK via **Clang AST + Swift Symbol Graph** extraction.

## Features

- **Comprehensive coverage** — Metal, Metal 4 and MetalFX (257 generated files, including Objective-C interop), plus hand-written wrappers for CoreFoundation, CoreAnimation, CoreGraphics, GCD and SIMD types.
- **Clang AST + Swift Symbol Graph** — bindings are extracted from SDK headers, not a hand-maintained IDL. Swift names provide human-readable method & parameter names where Clang only exposes selectors.
- **Zero-overhead value-type wrappers** — All Objective-C and Metal objects are `readonly struct` handles wrapping a single `nint`, eliminating GC heap allocations, object headers, and finalizer queue pressure.
- **Hierarchy flattening & implicit upcasting** — Inherited properties and methods are flattened directly onto derived structs, with zero-cost `implicit operator` conversions along the Objective-C inheritance chain.
- **Zero-copy span marshalling** — Array-taking APIs accept `ReadOnlySpan<T>` and pin `unmanaged` wrapper structs directly without intermediate copying.
- **ObjC block support** — `NativeBlock` uses `UnmanagedCallersOnly` function pointers for zero-overhead callbacks.
- **Native AOT & trimming ready** — annotated with `IsAotCompatible` and `IsTrimmable`.

## Installation

```bash
dotnet add package Metal.NET
```

> **Requirements:** .NET 10+, macOS 15+

## Quick Start

```csharp
using Metal.NET;

// Obtain the default GPU device
MTLDevice device = MTLDevice.CreateSystemDefaultDevice();

// Create a command queue
using MTLCommandQueue queue = device.MakeCommandQueue();

// Load the default shader library
using MTLLibrary library = device.MakeDefaultLibrary();

// Look up a compute function and create a pipeline state
using NSString kernelName = new("myKernel");
using MTLFunction kernel = library.MakeFunction(kernelName);
using MTLComputePipelineState pso = device.MakeComputePipelineState(kernel, out NSError error);

// Create a buffer
using MTLBuffer buffer = device.MakeBuffer(1024, MTLResourceOptions.StorageModeShared);
```

## API Coverage

| Framework | Files | Highlights |
|-----------|:-----:|---|
| **Metal / Metal 4** | 238 | Devices, command queues & buffers, render / compute / blit encoders, pipeline states, acceleration structures, tensors with auxiliary planes, `MTL4*` APIs |
| **MetalFX** | 18 | Temporal & spatial scalers, frame interpolators, content offsets and distortion textures |

Hand-written wrappers are included for CoreFoundation (`NSObject`, `NSString`, `NSArray`, …), CoreAnimation (`CAMetalLayer`, `CAMetalDrawable`), CoreGraphics (`CGColorSpace`, `CGSize`), GCD (`DispatchQueue`, `DispatchData`) and SIMD types.

## Memory Management

All wrapper types are 8-byte `readonly struct` handles (`unmanaged`) with zero GC allocation overhead. Native object lifetimes follow standard Objective-C reference counting (`Retain()` / `Dispose()`):

| Origin | `Dispose()` | Typical Usage |
|--------|:-----------:|---|
| `new()` (`AllocInit`) / `Init*` | ✓ | Descriptors and explicitly allocated objects (`new MTLTextureDescriptor()`) |
| `Make*` / `New*` / `Copy*` | ✓ | Factory methods returning retained objects (`device.MakeBuffer(...)`, `device.MakeDefaultLibrary()`) |
| Property getters / `NextDrawable()` / transient encoders | — | Autoreleased or borrowed references managed by parent or `NSAutoreleasePool` |

```csharp
// Allocated object – dispose when done
using var desc = new MTLTextureDescriptor();

// Retained factory return – caller is responsible for disposal
using MTLLibrary library = device.MakeDefaultLibrary();

// Borrowed property – do not dispose
MTLDevice device = queue.Device;
```

## How It Works

```
                  ┌──────────────────┐
    macOS SDK     │  Xcode / Clang   │
                  └────────┬─────────┘
                           │
              ┌────────────┴────────────┐
              ▼                         ▼
     Clang AST (JSON)        Swift Symbol Graphs
              │                         │
              └────────────┬────────────┘
                           ▼
              parse_metal_ast.py (Python)
                           │
                           ▼
                    metal-ast.json
                           │
                           ▼
              Metal.NET.Generator (C#)
                           │
                           ▼
                  Generated bindings
```

The pipeline has four stages. The GitHub Actions workflow (`extract-metal-api.yml`) runs the first three on the `xcode-27` runner; C# bindings are then generated locally:

1. **Dump the Clang AST** — `clang -Xclang -ast-dump=json` produces a complete JSON representation of every declaration in the Metal / MetalFX headers.
2. **Extract Swift Symbol Graphs** — `swift-symbolgraph-extract` provides the human-readable Swift names for methods and properties.
3. **Merge into `metal-ast.json`** — A Python script merges both sources, applies Swift name propagation, resolves overload collisions, and outputs a compact JSON describing every enum, struct, protocol, class, property, method, free function and block typedef.
4. **Generate C# bindings** — The C# generator reads `metal-ast.json` and emits idiomatic wrappers that call the Objective-C runtime directly via `objc_msgSend`.

## Project Structure

```
Metal.NET.slnx
│
├─ Metal.NET/                            Runtime library (NuGet package)
│  ├─ Interop/                           Interop core (hand-written)
│  │  ├─ NativeBlock.cs                  ObjC block support (UnmanagedCallersOnly)
│  │  ├─ ObjectiveC.cs                   Auto-generated objc_msgSend overloads
│  │  ├─ Selector.cs                     Lazy selector handle
│  │  └─ Bool8.cs                        Boolean value type
│  ├─ CoreFoundation/                    Hand-written NS* wrappers
│  ├─ CoreAnimation/                     Hand-written CA* wrappers
│  ├─ CoreGraphics/                      Hand-written CG* wrappers
│  ├─ Dispatch/                          Hand-written Dispatch* wrappers
│  ├─ Simd/                              Hand-written SIMD value types
│  ├─ Metal/                             Auto-generated Metal & Metal 4 API
│  └─ MetalFX/                           Auto-generated MetalFX API
│
├─ Metal.NET.Generator/                  Code generator (not shipped)
│  ├─ AstJsonParser*.cs                  JSON → model (7 partial files)
│  ├─ CSharpEmitter*.cs                  Model → C# source (9 partial files)
│  ├─ TypeMapper.cs                      ObjC ↔ C# type mapping
│  ├─ Models.cs / AstModels.cs           Data models
│  ├─ GeneratorContext.cs                Shared state across stages
│  └─ metal-ast.json                     Extracted API snapshot (generated by CI)
│
└─ .github/
   ├─ workflows/extract-metal-api.yml    CI: extract AST → commit metal-ast.json
   └─ scripts/parse_metal_ast.py         Clang AST + Swift Symbol Graph → JSON
```

## Updating Bindings

1. Run the **Extract Metal API** workflow to regenerate `metal-ast.json` from the macOS SDK bundled with the `xcode-27` runner's default Xcode.
2. Regenerate and verify locally:

```bash
dotnet run --project Metal.NET.Generator
dotnet build Metal.NET
```

## License

[MIT](LICENSE)

## Disclaimer

> This library was built with AI assistance. It has undergone preliminary testing but has **not** been exhaustively validated in production scenarios. Please test thoroughly before production use.
