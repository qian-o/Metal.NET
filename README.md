# Metal.NET — Auto-generated Metal Bindings for .NET

## Architecture

```
Metal.NET.slnx
├── Metal.NET/                         ← Main binding library
│   ├── Runtime/                       ← Hand-written runtime infrastructure
│   │   ├── ObjectiveCRuntime.cs       ← P/Invoke to libobjc.dylib (objc_msgSend)
│   │   ├── Selector.cs               ← ObjC selector wrapper
│   │   ├── Bool8.cs                   ← ObjC BOOL type
│   │   ├── NSString.cs / NSError.cs   ← Foundation types
│   │   └── MTLStructs.cs             ← Value-type structs (MTLOrigin, MTLSize, etc.)
│   ├── metal-cpp/                     ← metal-cpp headers (code generation source)
│   │   ├── Metal/
│   │   │   ├── MTLDevice.hpp
│   │   │   ├── MTLCommandQueue.hpp
│   │   │   ├── MTLPrivate.hpp
│   │   │   └── ...
│   │   ├── Foundation/
│   │   └── QuartzCore/
│   └── Metal.NET.csproj               ← References the Source Generator
│
└── Metal.NET.Generator/               ← C# Source Generator (compile-time)
    ├── MetalBindingsGenerator.cs      ← Reads .hpp → produces .g.cs files
    ├── HeaderClassParser.cs           ← Parses C++ class declarations + selectors
    ├── HeaderEnumParser.cs            ← Parses C++ enum definitions
    ├── HeaderTypeMapper.cs            ← C++ → C# type mapping
    └── Models.cs                      ← Shared definition models
```

## How It Works

The metal-cpp headers are included directly in the project. At compile time, the Source Generator reads `.hpp` files and generates C# bindings automatically — no intermediate steps needed.

```
metal-cpp headers (.hpp)  →  Source Generator  →  C# bindings (.g.cs)
```

## How to Update Bindings When Metal API Changes

### Step 1: Download latest metal-cpp

Go to **https://developer.apple.com/metal/cpp/** and download the latest archive.

### Step 2: Replace headers in the project

Replace the contents of `Metal.NET/metal-cpp/` with the extracted `Metal/`, `Foundation/`, and `QuartzCore/` directories:

```
Metal.NET/metal-cpp/
├── Metal/
│   ├── MTLDevice.hpp
│   ├── MTLCommandQueue.hpp
│   ├── MTLTexture.hpp
│   ├── MTLPrivate.hpp
│   └── ...
├── Foundation/
├── QuartzCore/
└── ...
```

### Step 3: Build

```bash
dotnet build Metal.NET
```

The Source Generator will automatically:
1. Parse selector definitions from `*Private.hpp` files
2. Parse enum definitions from `MTL*.hpp` headers
3. Parse class/protocol declarations and match methods to selectors
4. Generate C# bindings directly

### Fix any issues

The parser handles ~90% of cases automatically. You may need to manually fix:
- Methods with complex parameter patterns
- Custom selector mappings that couldn't be resolved
- New value-struct types (add them to `MTLStructs.cs` and `HeaderTypeMapper.cs`)
