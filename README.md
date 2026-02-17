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
│   ├── metal-cpp/                     ← metal-cpp headers (direct pipeline)
│   │   ├── Metal/
│   │   │   ├── MTLDevice.hpp
│   │   │   ├── MTLCommandQueue.hpp
│   │   │   └── ...
│   │   ├── Foundation/
│   │   └── QuartzCore/
│   ├── Definitions/                   ← JSON API definitions (legacy / manual overrides)
│   │   ├── enums.json                 ← All Metal enums
│   │   ├── MTLDevice.json             ← MTLDevice protocol binding
│   │   └── ...
│   └── Metal.NET.csproj               ← References the Source Generator
│
├── Metal.NET.Generator/               ← C# Source Generator (compile-time)
│   ├── MetalBindingsGenerator.cs      ← Reads .hpp or .json → produces .g.cs files
│   ├── HeaderClassParser.cs           ← Parses C++ class declarations + selectors
│   ├── HeaderEnumParser.cs            ← Parses C++ enum definitions
│   ├── HeaderTypeMapper.cs            ← C++ → C# type mapping
│   └── Models.cs                      ← Shared definition models
│
└── Metal.NET.HeaderParser/            ← CLI tool (legacy: parse headers → JSON)
    ├── Program.cs                     ← Entry point
    ├── EnumParser.cs                  ← Parses _MTL_ENUM/_MTL_OPTIONS
    ├── ClassParser.cs                 ← Parses class declarations + selectors
    ├── TypeMapper.cs                  ← C++ → C# type mapping
    └── Models.cs                      ← JSON output models
```

## How to Update Bindings When Metal API Changes

### Option A: Direct Pipeline (Recommended)

Place the metal-cpp headers directly in the project — the Source Generator parses them at compile time, no intermediate steps needed.

#### Step 1: Download latest metal-cpp

Go to **https://developer.apple.com/metal/cpp/** and download the latest archive.

#### Step 2: Copy headers into the project

Copy the extracted `Metal/`, `Foundation/`, and `QuartzCore/` directories into `Metal.NET/metal-cpp/`:

```
Metal.NET/metal-cpp/
├── Metal/
│   ├── MTLDevice.hpp
│   ├── MTLCommandQueue.hpp
│   ├── MTLTexture.hpp
│   ├── MTLDevicePrivate.hpp
│   └── ...
├── Foundation/
├── QuartzCore/
└── ...
```

#### Step 3: Build

```bash
dotnet build Metal.NET
```

The Source Generator will automatically:
1. Parse selector definitions from `*Private.hpp` files
2. Parse enum definitions from `MTL*.hpp` headers
3. Parse class/protocol declarations and match methods to selectors
4. Generate C# bindings directly — no JSON intermediate files needed

### Option B: JSON Pipeline (Legacy)

You can still use JSON definitions for fine-grained control or manual overrides. Both pipelines work simultaneously — JSON definitions take priority for types they define.

#### Step 1: Download latest metal-cpp

Go to **https://developer.apple.com/metal/cpp/** and download the latest archive.
Extract it to a local folder, e.g. `./metal-cpp/`.

#### Step 2: Run the header parser

```bash
dotnet run --project Metal.NET.HeaderParser -- ./metal-cpp ./Metal.NET/Definitions
```

This will:
1. Parse all `_MTL_PRIVATE_DEF_SEL` entries to build a selector map
2. Parse enum definitions from all `MTL*.hpp` headers
3. Parse class/protocol declarations and match methods to selectors
4. Write JSON definition files to `Metal.NET/Definitions/`

#### Step 3: Review and build

```bash
# Review the generated JSON files for any issues
# Then build — the Source Generator will produce C# bindings
dotnet build Metal.NET
```

### Fix any issues

The parser handles ~90% of cases automatically. You may need to manually fix:
- Methods with complex parameter patterns
- Custom selector mappings that couldn't be resolved
- New value-struct types (add them to `MTLStructs.cs` and `HeaderTypeMapper.cs`)

## JSON Definition Format

### Enums (`enums.json`)
```json
{
  "enums": [{
    "name": "MTLPixelFormat",
    "underlyingType": "uint",
    "isFlags": false,
    "members": [
      { "name": "Invalid", "value": "0" },
      { "name": "RGBA8Unorm", "value": "70" }
    ]
  }]
}
```

### Classes/Protocols (`MTLDevice.json`)
```json
{
  "name": "MTLDevice",
  "isClass": false,
  "properties": [
    { "name": "name", "type": "NSString", "readonly": true }
  ],
  "methods": [{
    "name": "newCommandQueue",
    "selector": "newCommandQueue",
    "returnType": "MTLCommandQueue"
  }],
  "staticMethods": []
}
```

- `isClass: true` → generates `Alloc()`, `Init()`, `New()` helpers
- `isClass: false` → protocol wrapper (no allocation)
- `hasErrorOut: true` → last param becomes `out NSError error`
- Properties with `readonly: false` generate both getter and setter
