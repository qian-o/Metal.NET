# Metal.NET

[![NuGet Version](https://img.shields.io/nuget/v/Metal.NET)](https://nuget.org/packages/Metal.NET)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

Low-level C# bindings for Apple's **Metal** and **MetalFX** frameworks — auto-generated from the macOS SDK via **Clang AST + Swift Symbol Graph** extraction.

## Features

- **Comprehensive coverage** — Metal, Metal 4 and MetalFX (252 generated files), plus hand-written wrappers for CoreFoundation, CoreAnimation, CoreGraphics, GCD and SIMD types.
- **Clang AST + Swift Symbol Graph** — bindings are extracted from SDK headers, not a hand-maintained IDL. Swift names provide human-readable method & parameter names where Clang only exposes selectors.
- **Three ownership modes** — `Borrowed`, `Owned` and `Managed`, with deterministic `Dispose()` and an optional finalizer safety net.
- **ObjC block support** — `NativeBlock<T>` uses `UnmanagedCallersOnly` function pointers for zero-overhead callbacks.
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
using MTLFunction kernel = library.MakeFunction("myKernel");
using MTLComputePipelineState pso = device.MakeComputePipelineState(kernel, out NSError error);

// Create a buffer
using MTLBuffer buffer = device.MakeBuffer(1024, MTLResourceOptions.StorageModeShared);
```

## API Coverage

| Framework | Files | Highlights |
|-----------|:-----:|---|
| **Metal / Metal 4** | 233 | Devices, command queues & buffers, render / compute / blit encoders, pipeline states, acceleration structures, `MTL4*` APIs |
| **MetalFX** | 18 | Temporal & spatial scalers, frame interpolators |

Hand-written wrappers are included for CoreFoundation (`NSObject`, `NSString`, `NSArray`, …), CoreAnimation (`CAMetalLayer`, `CAMetalDrawable`), CoreGraphics (`CGColorSpace`, `CGSize`), GCD (`DispatchQueue`, `DispatchData`) and SIMD types.

## Memory Management

| Ownership | `Dispose()` | Finalizer | Typical Usage |
|-----------|:-----------:|:---------:|---|
| `Borrowed` | — | — | Property getters, indexed subscript |
| `Owned` | ✓ | — | Method return values, `out NSError` |
| `Managed` | ✓ | ✓ | `new` via `AllocInit` |

```csharp
// Managed – finalizer will release if not disposed
var desc = new MTLTextureDescriptor();

// Owned – caller is responsible for disposal
using MTLLibrary library = device.MakeDefaultLibrary();

// Borrowed – do not dispose
MTLDevice device = commandQueue.Device;
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

A GitHub Actions workflow (`extract-metal-api.yml`) runs on a macOS runner to:

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
│  │  ├─ NativeObject.cs                 Base class for all ObjC wrappers
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

1. Run the **Extract Metal API** workflow to regenerate `metal-ast.json` from the latest Xcode SDK.
2. Regenerate and verify locally:

```bash
dotnet run --project Metal.NET.Generator
dotnet build Metal.NET
```

## License

[MIT](LICENSE)

## Disclaimer

> This library was built with AI assistance. It has undergone preliminary testing but has **not** been exhaustively validated in production scenarios. Please test thoroughly before production use.
