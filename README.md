# Metal.NET — Auto-generated Metal Bindings for .NET

## Architecture

```
Metal.NET.slnx
├── Metal.NET/                         ← Main binding library
│   ├── ObjectiveCRuntime.cs           ← P/Invoke to libobjc.dylib (objc_msgSend)
│   ├── Selector.cs                    ← ObjC selector wrapper
│   ├── Bool8.cs                       ← ObjC BOOL type
│   ├── NSString.cs / NSError.cs       ← Foundation types with convenience methods
│   ├── NSArray.cs                     ← Foundation array wrapper
│   ├── MTLStructs.cs                  ← Value-type structs (MTLOrigin, MTLSize, etc.)
│   ├── Generated/                     ← Auto-generated bindings (do not edit)
│   │   ├── MTLDevice.g.cs
│   │   ├── MTLCommandQueue.g.cs
│   │   ├── MTLPixelFormat.g.cs
│   │   └── ... (368 files)
│   └── Metal.NET.csproj
│
└── Metal.NET.Generator/               ← Offline code generator (console app)
    ├── Program.cs                     ← CLI entry point
    ├── MetalBindingsGenerator.cs      ← Reads .hpp → writes .g.cs files
    ├── HeaderClassParser.cs           ← Parses C++ class declarations + selectors + free functions
    ├── HeaderEnumParser.cs            ← Parses C++ enum definitions
    ├── HeaderTypeMapper.cs            ← C++ → C# type mapping
    ├── Models.cs                      ← Shared definition models
    └── metal-cpp/                     ← metal-cpp headers (code generation source)
        ├── Metal/
        ├── Foundation/
        ├── MetalFX/
        └── QuartzCore/
```

## How It Works

The Generator is an offline CLI tool that reads metal-cpp headers and produces C# bindings:

```
metal-cpp headers (.hpp)  →  dotnet run Generator  →  C# bindings (.g.cs)  →  Metal.NET/Generated/
```

### Free C Functions

Free C functions like `MTLCreateSystemDefaultDevice()` are detected via `extern "C"` declarations and wrapped as static P/Invoke methods in the corresponding class:

```csharp
// Generated in MTLDevice struct:
MTLDevice device = MTLDevice.CreateSystemDefaultDevice();
NSArray   allDevices = MTLDevice.CopyAllDevices();
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
dotnet run --project Metal.NET.Generator -- <metal-cpp-dir> <output-dir>
```

The Generator will:
1. Parse selector definitions from `*Private.hpp` files
2. Parse enum definitions from `MTL*.hpp` headers
3. Parse class/protocol declarations and match methods to selectors
4. Parse `extern "C"` free function declarations and map them to target classes
5. Write generated `.g.cs` files to `Metal.NET/Generated/`

### Step 4: Build

```bash
dotnet build Metal.NET
```

### Fix any issues

The parser handles ~90% of cases automatically. You may need to manually fix:
- Methods with complex parameter patterns
- Custom selector mappings that couldn't be resolved
- New value-struct types (add them to `MTLStructs.cs` and `HeaderTypeMapper.cs`)

## Why Not ClangSharp/CppAst?

Libraries like [ClangSharp](https://github.com/dotnet/ClangSharp) and [CppAst](https://github.com/xoofx/CppAst.NET) provide robust C++ parsing via libclang. Since the generator is now an offline console app (not a source generator), ClangSharp/CppAst could be adopted in the future for more accurate parsing of complex C++ constructs (templates, macros, preprocessor conditionals). For now, the regex-based approach is sufficient for metal-cpp's straightforward header style.
