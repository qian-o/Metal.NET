# Metal.NET — Auto-generated Metal Bindings for .NET

## Architecture

```
Metal.NET.slnx
├── Metal.NET/                          ← Main binding library
│   ├── Common/                         ← Utility types
│   │   ├── ObjectiveCRuntime.cs        ← P/Invoke to libobjc.dylib (objc_msgSend)
│   │   ├── Selector.cs                 ← ObjC selector wrapper
│   │   ├── Bool8.cs                    ← ObjC BOOL type
│   │   └── MTLStructs.cs              ← Value-type structs (MTLOrigin, MTLSize, etc.)
│   ├── Foundation/                     ← Foundation framework types
│   │   ├── NSString.cs                 ← Hand-written with convenience methods
│   │   ├── NSError.cs                  ← Hand-written with convenience methods
│   │   ├── NSArray.cs                  ← Hand-written with convenience methods
│   │   └── NSURL.g.cs                  ← Auto-generated
│   ├── Metal/                          ← Auto-generated Metal API bindings
│   │   ├── MTLDevice.g.cs
│   │   ├── MTLCommandQueue.g.cs
│   │   ├── MTLPixelFormat.g.cs
│   │   └── ... (322 files)
│   ├── QuartzCore/                     ← Auto-generated QuartzCore bindings
│   │   ├── CAMetalLayer.g.cs
│   │   └── CAMetalDrawable.g.cs
│   ├── MetalFX/                        ← Auto-generated MetalFX bindings
│   │   ├── MTLFXSpatialScaler.g.cs
│   │   └── ... (14 files)
│   └── Metal.NET.csproj
│
└── Metal.NET.Generator/                ← Offline code generator (console app)
    ├── Program.cs                      ← CLI entry point
    ├── CppAstParser.cs                 ← Parses C++ headers via CppAst (libclang)
    ├── MetalBindingsGenerator.cs       ← Generates C# classes from parsed definitions
    ├── Models.cs                       ← Shared definition models
    ├── metal-cpp/                      ← metal-cpp headers (code generation source)
    │   ├── Metal/
    │   ├── Foundation/
    │   ├── MetalFX/
    │   └── QuartzCore/
    └── stubs/                          ← Stub headers for cross-platform parsing
```

## How It Works

The Generator is an offline CLI tool that parses metal-cpp C++ headers using CppAst (libclang) and produces C# class bindings:

```
metal-cpp headers (.hpp)  →  CppAst (libclang)  →  C# bindings (.g.cs)  →  Metal/, Foundation/, QuartzCore/, MetalFX/
```

### Generated Code Pattern

All ObjC wrappers are generated as **classes with IDisposable** for automatic reference counting via the GC:

```csharp
public class MTLCommandQueue : IDisposable
{
    public nint NativePtr { get; }

    ~MTLCommandQueue() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    // ... properties and methods
}
```

### Free C Functions

Free C functions like `MTLCreateSystemDefaultDevice()` are wrapped as static `[LibraryImport]` methods in the corresponding class:

```csharp
MTLDevice device = MTLDevice.CreateSystemDefaultDevice();
NSArray allDevices = MTLDevice.CopyAllDevices();
```

## How to Update Bindings When Metal API Changes

### Step 1: Download latest metal-cpp

Go to **https://developer.apple.com/metal/cpp/** and download the latest archive.

### Step 2: Replace headers

Replace the contents of `Metal.NET.Generator/metal-cpp/` with the extracted `Metal/`, `Foundation/`, `MetalFX/`, and `QuartzCore/` directories.

### Step 3: Run the generator

```bash
dotnet run --project Metal.NET.Generator
```

Or with custom paths:

```bash
dotnet run --project Metal.NET.Generator -- <metal-cpp-dir> <output-dir> <stubs-dir>
```

The Generator will:
1. Parse all headers via CppAst (libclang) — enums, classes, methods, free functions
2. Map C++ types to C# types (nint, nuint, Bool8, wrapper classes, enums)
3. Generate binding files into Metal/, Foundation/, QuartzCore/, MetalFX/ subfolders
4. All generated wrappers use class + IDisposable for GC-based reference counting

### Step 4: Build

```bash
dotnet build Metal.NET
```

