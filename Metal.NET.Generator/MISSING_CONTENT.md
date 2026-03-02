# Metal.NET — Missing Content & Reorganization Plan

This document catalogs all known gaps in the Metal.NET C# bindings and proposes a folder reorganization to cleanly separate Apple-specific runtime plumbing from generic infrastructure.

---

## Table of Contents

1. [Missing Objective-C Block / Handler Methods](#1-missing-objective-c-block--handler-methods)
2. [Missing libdispatch (GCD) P/Invokes](#2-missing-libdispatch-gcd-pinvokes)
3. [Missing Foundation Class Implementations](#3-missing-foundation-class-implementations)
4. [Skipped Members Due to Unmappable NS Types](#4-skipped-members-due-to-unmappable-ns-types)
5. [Missing CoreGraphics / IOSurface P/Invokes](#5-missing-coregraphics--iosurface-pinvokes)
6. [Folder Reorganization Plan](#6-folder-reorganization-plan)
7. [Design Principles — Generator-Driven & OOP Wrappers](#7-design-principles--generator-driven--oop-wrappers)

---

## 1. Missing Objective-C Block / Handler Methods

The generator currently skips every method whose signature includes an Objective-C Block (`^`) or `std::function` handler because there is no automatic mapping from C++ block types to C# delegates. Each entry below lists the C++ header, class, method name, and the block/handler type involved.

### MTLCommandBuffer

| Method | Block / Handler Type | Header |
|---|---|---|
| `addCompletedHandler(CommandBufferHandler)` | `void (^)(MTL::CommandBuffer*)` | `MTLCommandBuffer.hpp` |
| `addCompletedHandler(CommandBufferHandlerFunction)` | `std::function<void(MTL::CommandBuffer*)>` | `MTLCommandBuffer.hpp` |
| `addScheduledHandler(CommandBufferHandler)` | `void (^)(MTL::CommandBuffer*)` | `MTLCommandBuffer.hpp` |
| `addScheduledHandler(CommandBufferHandlerFunction)` | `std::function<void(MTL::CommandBuffer*)>` | `MTLCommandBuffer.hpp` |

### MTLDrawable

| Method | Block / Handler Type | Header |
|---|---|---|
| `addPresentedHandler(DrawablePresentedHandler)` | `void (^)(MTL::Drawable*)` | `MTLDrawable.hpp` |
| `addPresentedHandler(DrawablePresentedHandlerFunction)` | `std::function<void(MTL::Drawable*)>` | `MTLDrawable.hpp` |

### MTLSharedEvent

| Method | Block / Handler Type | Header |
|---|---|---|
| `notifyListener(SharedEventListener*, uint64_t, SharedEventNotificationBlock)` | `void (^)(MTL::SharedEvent*, uint64_t)` | `MTLEvent.hpp` |

### MTLIOCommandBuffer

| Method | Block / Handler Type | Header |
|---|---|---|
| `addCompletedHandler(IOCommandBufferHandler)` | `void (^)(MTL::IOCommandBuffer*)` | `MTLIOCommandBuffer.hpp` |
| `addCompletedHandler(IOCommandBufferHandlerFunction)` | `std::function<void(MTL::IOCommandBuffer*)>` | `MTLIOCommandBuffer.hpp` |

### MTLDevice

| Method | Block / Handler Type | Header |
|---|---|---|
| `newBuffer(void*, NS::UInteger, ..., DeallocFunction)` | Deallocator block | `MTLDevice.hpp` |
| `newLibrary(NS::String*, CompletionHandler)` | `void (^)(MTL::Library*, NS::Error*)` | `MTLDevice.hpp` |
| `newLibrary(NS::String*, CompletionHandlerFunction)` | `std::function<void(MTL::Library*, NS::Error*)>` | `MTLDevice.hpp` |
| `newLibrary(StitchedLibraryDescriptor*, CompletionHandler)` | `void (^)(MTL::Library*, NS::Error*)` | `MTLDevice.hpp` |
| `newLibrary(StitchedLibraryDescriptor*, CompletionHandlerFunction)` | `std::function<void(MTL::Library*, NS::Error*)>` | `MTLDevice.hpp` |
| `newRenderPipelineState(..., CompletionHandler)` | `void (^)(MTL::RenderPipelineState*, NS::Error*)` | `MTLDevice.hpp` |
| `newRenderPipelineState(..., CompletionHandlerFunction)` | `std::function<void(MTL::RenderPipelineState*, NS::Error*)>` | `MTLDevice.hpp` |
| `newRenderPipelineState(..., reflection, CompletionHandler)` | `void (^)(MTL::RenderPipelineState*, MTL::RenderPipelineReflection*, NS::Error*)` | `MTLDevice.hpp` |
| `newRenderPipelineState(..., reflection, CompletionHandlerFunction)` | `std::function<...>` | `MTLDevice.hpp` |
| `newComputePipelineState(..., CompletionHandler)` | `void (^)(MTL::ComputePipelineState*, NS::Error*)` | `MTLDevice.hpp` |
| `newComputePipelineState(..., CompletionHandlerFunction)` | `std::function<...>` | `MTLDevice.hpp` |
| `newComputePipelineState(..., reflection, CompletionHandler)` | `void (^)(MTL::ComputePipelineState*, MTL::ComputePipelineReflection*, NS::Error*)` | `MTLDevice.hpp` |
| `newComputePipelineState(..., reflection, CompletionHandlerFunction)` | `std::function<...>` | `MTLDevice.hpp` |

### MTLLibrary

| Method | Block / Handler Type | Header |
|---|---|---|
| `newFunction(NS::String*, MTL::FunctionConstantValues*, CompletionHandler)` | `void (^)(MTL::Function*, NS::Error*)` | `MTLLibrary.hpp` |
| `newFunction(NS::String*, MTL::FunctionConstantValues*, CompletionHandlerFunction)` | `std::function<void(MTL::Function*, NS::Error*)>` | `MTLLibrary.hpp` |
| `newFunction(FunctionDescriptor*, CompletionHandler)` | `void (^)(MTL::Function*, NS::Error*)` | `MTLLibrary.hpp` |
| `newFunction(FunctionDescriptor*, CompletionHandlerFunction)` | `std::function<void(MTL::Function*, NS::Error*)>` | `MTLLibrary.hpp` |
| `newIntersectionFunction(IntersectionFunctionDescriptor*, CompletionHandler)` | `void (^)(MTL::Function*, NS::Error*)` | `MTLLibrary.hpp` |
| `newIntersectionFunction(IntersectionFunctionDescriptor*, CompletionHandlerFunction)` | `std::function<void(MTL::Function*, NS::Error*)>` | `MTLLibrary.hpp` |

### MTL4Compiler

| Method | Block / Handler Type | Header |
|---|---|---|
| `compileLibrary(MTL4CompileOptions*, CompletionHandler)` | `void (^)(MTL::Library*, NS::Error*)` | `MTL4Compiler.hpp` |
| `compileLibrary(MTL4CompileOptions*, CompletionHandlerFunction)` | `std::function<...>` | `MTL4Compiler.hpp` |
| `compilePipelineState(Render, CompletionHandler)` | various | `MTL4Compiler.hpp` |
| `compilePipelineState(Compute, CompletionHandler)` | various | `MTL4Compiler.hpp` |
| `compilePipelineState(Mesh, CompletionHandler)` | various | `MTL4Compiler.hpp` |
| `compilePipelineState(Tile, CompletionHandler)` | various | `MTL4Compiler.hpp` |
| Plus `std::function` variants for each of the above | | `MTL4Compiler.hpp` |

### Required Implementation Strategy — Generator-Driven

> **CRITICAL RULE:** Block/handler methods MUST be implemented in the **generator pipeline** (`CppParser.cs` → `TypeMapper.cs` → `CSharpEmitter.cs`), NOT as hand-written `.Handlers.cs` files. No hand-written `.cs` files should exist in `Metal.NET/Metal/`, `Metal.NET/MetalFX/`, or `Metal.NET/QuartzCore/` — those directories contain exclusively auto-generated code.

The generator must be enhanced to:

1. **Parse Block/handler type aliases** in `CppParser.cs` — recognize `using CommandBufferHandler = void (^)(MTL::CommandBuffer*)` and similar `using` declarations that define Objective-C Block types.
2. **Emit C# delegate types** in `CSharpEmitter.cs` — for each parsed Block alias, generate a corresponding `delegate void MTLCommandBufferHandler(MTLCommandBuffer commandBuffer)` in the same file or a shared delegates file.
3. **Emit handler methods** in `CSharpEmitter.cs` — for each method that takes a Block parameter, generate the full method body including `BlockLiteral` construction, `[UnmanagedCallersOnly]` trampoline, `GCHandle` capture, and `objc_msgSend` call.
4. **Skip `std::function` overloads** — these are metal-cpp convenience wrappers around the Block variants and have no Objective-C selector. Only the Block variant needs to be emitted.
5. **Always emit `partial`** — all generated classes must use the `partial` keyword (see Section 7.3 Issue 3).

All existing hand-written `.Handlers.cs` files and `BlockDelegates.cs` must be **deleted** — they will be replaced by generator output.

---

## 2. Missing libdispatch (GCD) Wrapper Classes

`dispatch_queue_t` and `dispatch_data_t` are currently mapped to raw `nint` with no creation or management APIs. These need **proper OOP wrapper classes** (not bare static P/Invoke helpers). The following native functions (from `libSystem.B.dylib`) are needed as the backing P/Invokes inside the wrapper classes:

| Function | Signature | Purpose |
|---|---|---|
| `dispatch_queue_create` | `dispatch_queue_t dispatch_queue_create(const char* label, dispatch_queue_attr_t attr)` | Create a serial or concurrent dispatch queue |
| `dispatch_get_global_queue` | `dispatch_queue_t dispatch_get_global_queue(long identifier, unsigned long flags)` | Get a global concurrent queue by QoS class |
| `dispatch_get_main_queue` | `dispatch_queue_t dispatch_get_main_queue(void)` | Get the main thread queue (macro, actually `_dispatch_main_q`) |
| `dispatch_release` | `void dispatch_release(dispatch_object_t object)` | Release a dispatch object |
| `dispatch_retain` | `void dispatch_retain(dispatch_object_t object)` | Retain a dispatch object |
| `dispatch_data_create` | `dispatch_data_t dispatch_data_create(const void* buffer, size_t size, dispatch_queue_t queue, dispatch_block_t destructor)` | Create a dispatch data object from a buffer |
| `dispatch_data_get_size` | `size_t dispatch_data_get_size(dispatch_data_t data)` | Get the size of a dispatch data object |

### Where These Are Needed

- `MTLSharedEventListener` — constructor accepts `dispatch_queue_t` to specify the notification queue.
- `MTL4CommandQueueDescriptor.feedbackQueue` — property typed as `dispatch_queue_t`.
- `MTLIOCommandQueueDescriptor` — may reference `dispatch_queue_t`.
- `MTLDevice.newBuffer(…, deallocator)` — deallocator may be dispatched.
- `dispatch_data_t` is used in `MTLDevice.newLibrary(dispatch_data_t, …)`.

### Required Implementation (OOP Wrapper Classes)

Do **NOT** implement these as bare `static partial class` with raw `nint` P/Invokes. Instead, create proper wrapper classes under `Metal.NET/Dispatch/`:

- **`DispatchQueue`** — a class (or struct) that wraps the native `dispatch_queue_t` handle, with static factory methods (`Create(string label, ...)`, `GetGlobalQueue(...)`, `MainQueue`), and proper `Retain`/`Release` lifecycle (ideally via `IDisposable` or the existing `NativeObject` ownership pattern).
- **`DispatchData`** — a class that wraps the native `dispatch_data_t` handle, with a static `Create(...)` factory, a `Size` property, and proper lifecycle management.

These classes should follow the same OOP design as `NSString`, `NSError`, etc. — users should never need to deal with raw `nint` handles directly.

Also, once these wrapper classes exist, update `TypeMapper.cs` to map `dispatch_queue_t` → `DispatchQueue` and `dispatch_data_t` → `DispatchData` (instead of `nint`), so the generator emits typed parameters/returns throughout the Metal API.

---

## 3. Missing Foundation Class Implementations

> **Important:** Foundation types like `NSDictionary`, `NSBundle`, `NSData`, `NSNumber` etc. should be implemented as **hand-written files** in `Metal.NET/Foundation/` (same pattern as existing `NSString.cs`, `NSError.cs`, `NSArray.cs`). They are in `CSharpEmitter.SkipClasses` specifically because the generator cannot auto-generate them from the C++ headers — they require custom marshalling logic, convenience methods, and special constructors.
>
> Once a hand-written implementation exists, the class stays in `SkipClasses` (the generator will never emit it), but the type becomes available for the generator to reference in method signatures. The key step is to also **remove the type from `IsUnmappableCppType()` in `TypeMapper.cs`** and add a mapping entry so the generator can emit methods that use these types.

The following classes appear in `CSharpEmitter.SkipClasses` because they need hand-written implementations, but **no hand-written C# file exists for them yet**:

| Class | Why It's Needed |
|---|---|
| `NSDictionary` | Used by `MTLCompileOptions.preprocessorMacros`, `MTLFunction.functionConstantsDictionary`, and other properties. Most impactful missing type. |
| `NSBundle` | Used by `MTLDevice.newDefaultLibrary(NS::Bundle*)` to load a Metal library from a specific bundle. |
| `NSData` | Used in some `newLibrary` overloads and serialization paths. |
| `NSNumber` | Used as dictionary values and in some property types. |
| `NSSet` | Used in a few Metal API return types. |
| `NSEnumerator` | Used for iterating `NSSet`/`NSDictionary`. |
| `NSValue` | Base type for `NSNumber`; occasionally surfaces in API. |
| `NSDate` | Used in some timing/scheduling APIs. |
| `NSObject` | Base ObjC class; rarely needed directly but referenced. |
| `NSNotification` / `NSNotificationCenter` | Used for Metal device notifications (e.g., device added/removed on macOS). |

### Priority

1. **`NSDictionary`** — Unblocks multiple skipped properties across `MTLCompileOptions`, `MTLFunction`, etc.
2. **`NSBundle`** — Unblocks `newDefaultLibrary(bundle:)` on `MTLDevice`.
3. **`NSData`** — Unblocks data-based library creation.
4. **`NSNumber`** / **`NSValue`** — Required for `NSDictionary` value types.
5. Remaining types are lower priority.

---

## 4. Skipped Members Due to Unmappable NS Types

These properties and methods are skipped by `TypeMapper.IsUnmappableCppType()` because their parameter or return types reference Foundation classes that have no C# mapping:

| Class | Member | Unmappable Type | Header |
|---|---|---|---|
| `MTLCompileOptions` | `preprocessorMacros` (get/set) | `NS::Dictionary*` | `MTLCompileOptions.hpp` |
| `MTLFunction` | `functionConstantsDictionary` (get) | `NS::Dictionary*` | `MTLLibrary.hpp` |
| `MTLDevice` | `newDefaultLibrary(NS::Bundle*)` | `NS::Bundle*` | `MTLDevice.hpp` |
| `MTLDevice` | `newLibrary(dispatch_data_t, …)` | `dispatch_data_t` (partially mapped) | `MTLDevice.hpp` |
| `MTLRenderPipelineReflection` | Various | `NS::Array*` elements may be unmappable | `MTLRenderPipeline.hpp` |
| `MTL4PipelineReflection` | Various | May reference unmappable types | `MTL4PipelineReflection.hpp` |
| `MTLCaptureManager` | `startCapture(MTLCaptureDescriptor*, NS::Error**)` | `NS::Error**` (double pointer) | `MTLCaptureManager.hpp` |

### Resolution

Implement the Foundation classes listed in [Section 3](#3-missing-foundation-class-implementations), then remove them from `IsUnmappableCppType()` in `TypeMapper.cs`.

---

## 5. Missing CoreGraphics / IOSurface Wrapper Classes

Some Metal APIs use CoreGraphics and IOSurface types that are mapped to raw `nint` with no helper APIs:

| Type | Current Mapping | Used By | Needed Native Functions |
|---|---|---|---|
| `CGColorSpaceRef` | `nint` | `CAMetalLayer.colorspace` | `CGColorSpaceCreateDeviceRGB()`, `CGColorSpaceCreateWithName(CFStringRef)`, `CGColorSpaceRelease(CGColorSpaceRef)`, `CGColorSpaceRetain(CGColorSpaceRef)` |
| `IOSurfaceRef` | `nint` | `MTLTexture.iosurface`, `MTLDevice.newTexture(…, IOSurfaceRef, …)` | `IOSurfaceCreate(CFDictionaryRef)`, `IOSurfaceGetWidth/Height/BytesPerRow(IOSurfaceRef)` |

### Required Implementation (OOP Wrapper Classes)

Do **NOT** implement these as bare `static partial class` with raw `nint` P/Invokes. Instead, create proper wrapper classes:

- **`CGColorSpace`** — a class under `Metal.NET/CoreGraphics/` that wraps the native `CGColorSpaceRef` handle, with static factory methods (`CreateDeviceRGB()`, `CreateWithName(...)`) and proper `Retain`/`Release` lifecycle. The P/Invoke declarations should be `private` internal details of the class, not the public API.
- **`IOSurface`** — a class under `Metal.NET/IOSurface/` that wraps the native `IOSurfaceRef` handle, with properties like `Width`, `Height`, `BytesPerRow` and a static `Create(...)` factory.

These classes should follow the same OOP patterns as `NSString`, `NSDictionary`, etc. Once they exist, update `TypeMapper.cs` to map `CGColorSpaceRef` → `CGColorSpace` and `IOSurfaceRef` → `IOSurface` (instead of `nint`), so the generator emits typed parameters/returns.

---

## 6. Folder Reorganization Plan

### Current Structure (Problems)

The `Common/` folder mixes **Apple-specific Objective-C runtime interop** with **generic infrastructure** that is framework-agnostic:

```
Metal.NET/
├── Common/
│   ├── Bool8.cs                  ← Apple-specific (ObjC BOOL → byte)
│   ├── MTLStructs.cs             ← Metal-specific (MTLOrigin, MTLSize, MTLRegion, …)
│   ├── NativeObject.cs           ← Generic (base class, ownership model)
│   ├── ObjectiveCRuntime.cs      ← Apple-specific (libobjc P/Invoke, framework loading)
│   └── Selector.cs               ← Apple-specific (ObjC selector type)
├── Foundation/
│   ├── NSArray.cs                ← Hand-written
│   ├── NSAutoreleasePool.cs      ← Hand-written
│   ├── NSComparisonResult.cs     ← Auto-generated enum
│   ├── NSError.cs                ← Hand-written
│   ├── NSProcessInfoThermalState.cs ← Auto-generated enum
│   ├── NSString.cs               ← Hand-written
│   ├── NSStringCompareOptions.cs ← Auto-generated enum
│   ├── NSStringEncoding.cs       ← Auto-generated enum
│   ├── NSURL.cs                  ← Hand-written
│   └── NSActivityOptions.cs      ← Auto-generated enum
├── Metal/
│   └── … (~280 auto-generated files)
├── MetalFX/
│   └── … (~16 auto-generated files)
└── QuartzCore/
    └── … (2 auto-generated files)
```

### Proposed Structure

```
Metal.NET/
├── Common/                          ← Generic, framework-agnostic infrastructure
│   ├── NativeObject.cs              ← Base class, INativeObject<TSelf>, ownership model
│   └── (future: any truly generic helpers)
│
├── ObjCRuntime/                     ← Apple Objective-C runtime interop
│   ├── ObjectiveCRuntime.cs         ← libobjc P/Invoke, objc_msgSend, framework loading
│   ├── Selector.cs                  ← ObjC selector type with implicit string conversion
│   └── Bool8.cs                     ← ObjC BOOL mapped to byte
│
├── Dispatch/                        ← libdispatch (GCD) interop (NEW)
│   ├── DispatchQueue.cs             ← dispatch_queue_t OOP wrapper class (NativeObject-based)
│   └── DispatchData.cs              ← dispatch_data_t OOP wrapper class (NativeObject-based)
│
├── CoreGraphics/                    ← CoreGraphics interop (NEW)
│   └── CGColorSpace.cs              ← CGColorSpaceRef OOP wrapper class (NativeObject-based)
│
├── IOSurface/                       ← IOSurface interop (NEW)
│   └── IOSurface.cs                 ← IOSurfaceRef OOP wrapper class (NativeObject-based)
│
├── Foundation/                      ← Apple Foundation framework types
│   ├── NSArray.cs                   ← Hand-written
│   ├── NSAutoreleasePool.cs         ← Hand-written
│   ├── NSDictionary.cs              ← Hand-written (TO ADD)
│   ├── NSBundle.cs                  ← Hand-written (TO ADD)
│   ├── NSData.cs                    ← Hand-written (TO ADD)
│   ├── NSNumber.cs                  ← Hand-written (TO ADD)
│   ├── NSError.cs                   ← Hand-written
│   ├── NSString.cs                  ← Hand-written
│   ├── NSURL.cs                     ← Hand-written
│   ├── NSComparisonResult.cs        ← Auto-generated enum
│   ├── NSProcessInfoThermalState.cs ← Auto-generated enum
│   ├── NSStringCompareOptions.cs    ← Auto-generated enum
│   ├── NSStringEncoding.cs          ← Auto-generated enum
│   └── NSActivityOptions.cs         ← Auto-generated enum
│
├── Metal/                           ← Auto-generated Metal bindings
│   ├── MTLStructs.cs                ← MOVED from Common/ (Metal-specific structs)
│   └── … (~280 auto-generated files)
│
├── MetalFX/
│   └── … (~16 auto-generated files)
│
└── QuartzCore/
    └── … (2 auto-generated files)
```

### Key Changes

| File | From | To | Reason |
|---|---|---|---|
| `NativeObject.cs` | `Common/` | `Common/` (stays) | Truly generic — defines ownership model, base class, factory interface |
| `ObjectiveCRuntime.cs` | `Common/` | `ObjCRuntime/` | Apple-specific libobjc interop, not generic infrastructure |
| `Selector.cs` | `Common/` | `ObjCRuntime/` | Apple-specific ObjC selector concept |
| `Bool8.cs` | `Common/` | `ObjCRuntime/` | Apple-specific ObjC BOOL type |
| `MTLStructs.cs` | `Common/` | `Metal/` | Metal-specific blittable structs (MTLOrigin, MTLSize, etc.) |

### Namespace Considerations

- `Common/` → `Metal.NET` (root namespace, since `NativeObject` is the base for everything)
- `ObjCRuntime/` → `Metal.NET.ObjCRuntime`
- `Dispatch/` → `Metal.NET.Dispatch`
- `CoreGraphics/` → `Metal.NET.CoreGraphics`
- `IOSurface/` → `Metal.NET.IOSurface`
- `Foundation/` → `Metal.NET.Foundation` (unchanged)
- `Metal/` → `Metal.NET.Metal` (unchanged)

### Impact on Generator

The `CSharpEmitter` currently emits files into folders based on the metal-cpp subdirectory name. Moving `MTLStructs.cs` to `Metal/` is straightforward since the structs are Metal-specific. The generator does not produce `Common/` or `ObjCRuntime/` files, so those moves are purely manual reorganization of hand-written code. After moving files, update `namespace` declarations and `using` directives across the project.

---

## 7. Design Principles — Generator-Driven & OOP Wrappers

This section clarifies two critical architectural rules that **must** be followed for all work items above.

### 7.1 All Metal/MetalFX/QuartzCore Bindings Must Be Generator-Driven — NO Exceptions

> **ABSOLUTE RULE:** No hand-written `.cs` files may exist in `Metal.NET/Metal/`, `Metal.NET/MetalFX/`, or `Metal.NET/QuartzCore/`. Every file in those directories is **auto-generated** by the generator pipeline and will be **overwritten** on the next generator run. This includes Block/handler methods — they must be generated, not hand-written.

The Metal.NET binding library is built on a **code generation pipeline**: `CppParser` → `GeneratorContext` → `CSharpEmitter`. ALL Metal API bindings (classes, enums, properties, methods, **delegate types**, **handler methods**) are auto-generated from the metal-cpp C++ headers.

When implementing missing content:

- **NEVER** hand-write any `.cs` file in `Metal.NET/Metal/`, `Metal.NET/MetalFX/`, or `Metal.NET/QuartzCore/`. Not even as `partial class` extensions in separate files (e.g., `.Handlers.cs`). Those directories are exclusively generator output.
- **Instead**, enhance the **generator** (`CppParser.cs`, `TypeMapper.cs`, `CSharpEmitter.cs`) so it can parse and emit the missing methods automatically.
- For Block/handler methods (e.g., `addCompletedHandler` on `MTLCommandBuffer`), add Block type parsing to `CppParser.cs`, delegate type emission and handler method emission to `CSharpEmitter.cs`. See Section 1 "Required Implementation Strategy" for details.
- Foundation types (`NSDictionary`, `NSBundle`, `NSData`, etc.) are the **only exception** — they are hand-written in `Metal.NET/Foundation/` because they require custom marshalling logic. But even for these, after implementing the hand-written class, you must update `TypeMapper.cs` (remove from `IsUnmappableCppType()`, add type mapping) so the **generator** can reference them in auto-generated method signatures.

### 7.2 Native Handle Types Must Be Proper OOP Wrapper Classes

Types like `dispatch_queue_t`, `dispatch_data_t`, `CGColorSpaceRef`, and `IOSurfaceRef` are currently mapped to raw `nint`. This is wrong from an OOP perspective.

**Do NOT** implement these as bare `static partial class` with `[LibraryImport]` P/Invokes that accept/return raw `nint`. This forces users to manage native handles manually.

**Instead**, create proper wrapper classes that:

1. **Wrap the native handle** internally (either inheriting from `NativeObject` or using a similar pattern with `IDisposable`).
2. **Expose static factory methods** (e.g., `DispatchQueue.Create("myQueue")`, `CGColorSpace.CreateDeviceRGB()`).
3. **Expose instance properties/methods** (e.g., `dispatchData.Size`, `cgColorSpace.NumberOfComponents`).
4. **Manage lifecycle** (retain/release or CFRetain/CFRelease) automatically.
5. **Keep P/Invoke declarations private** — they are implementation details, not the public API.

Once these wrapper classes exist, update `TypeMapper.cs` to map the C types to the wrapper class names (e.g., `dispatch_queue_t` → `DispatchQueue`, `CGColorSpaceRef` → `CGColorSpace`) so the generator emits typed parameters/returns throughout the Metal API instead of `nint`.

### 7.3 Complete Audit of Previous Agent's Mistakes

After a thorough code review of the `copilot/implement-missing-bindings` branch, the following issues were identified:

#### Issue 1: Static P/Invoke Classes Instead of OOP Wrappers

The following files were implemented as bare `static partial class` with raw `nint` P/Invokes. They must be **rewritten** as proper `NativeObject`-based wrapper classes:

- `Metal.NET/Dispatch/DispatchQueue.cs` — static class, exposes all P/Invokes as public, returns raw `nint`
- `Metal.NET/Dispatch/DispatchData.cs` — static class, exposes all P/Invokes as public, returns raw `nint`
- `Metal.NET/CoreGraphics/CGColorSpace.cs` — static class, exposes all P/Invokes as public, returns raw `nint`
- `Metal.NET/IOSurface/IOSurface.cs` — static class, exposes all P/Invokes as public, returns raw `nint`

#### Issue 2: Handler Methods Hand-Written in Auto-Generated Directory — MUST DELETE

The following `.Handlers.cs` files were hand-written in `Metal.NET/Metal/`:

- `MTLCommandBuffer.Handlers.cs`
- `MTLDrawable.Handlers.cs`
- `MTLSharedEvent.Handlers.cs`
- `MTLIOCommandBuffer.Handlers.cs`
- `MTLDevice.Handlers.cs`
- `MTLLibrary.Handlers.cs`
- `MTL4Compiler.Handlers.cs`

**Problem:** These files use `partial class` to extend auto-generated classes, but the **generator** was not modified to emit Block/handler methods. The agent manually wrote these methods instead of enhancing the generator pipeline (`CppParser.cs` → `TypeMapper.cs` → `CSharpEmitter.cs`) to recognize and emit them automatically.

**This is fundamentally wrong.** No hand-written `.cs` files should exist in `Metal.NET/Metal/`. ALL content in that directory must be auto-generated by the generator. These files **MUST be deleted**. Block/handler method support must be implemented by enhancing the generator — see Section 1 "Required Implementation Strategy".

Additionally, `Metal.NET/ObjCRuntime/BlockDelegates.cs` (which hand-writes delegate types) must also be **deleted** — the generator should emit delegate types alongside the handler methods.

#### Issue 3: Generator Not Updated to Emit `partial` Keyword

The agent manually inserted the `partial` keyword into auto-generated `.cs` files:

- `MTLDrawable.cs` — has `partial` but no free functions (the generator only emits `partial` when `hasFreeFunctions` is true)
- `MTLSharedEvent.cs` — same problem
- `MTLIOCommandBuffer.cs` — same problem
- `MTLLibrary.cs` — same problem
- `MTL4Compiler.cs` — same problem

**Problem:** On the next generator run, all these files will be regenerated **without** the `partial` keyword. The fix is to modify `CSharpEmitter.cs` line 281:

```csharp
// Current (wrong):
string partialKeyword = hasFreeFunctions ? "partial " : "";

// Should be:
string partialKeyword = "partial ";
```

All generated classes should always use `partial`. This is required for the generator's own Block/handler method emission (the generator may emit handler methods in separate partial files or inline, but `partial` is still needed for extensibility).

#### Issue 4: TypeMapper.cs Not Updated — Generator Never Re-Run

`NSDictionary`, `NSBundle`, `NSData`, `NSNumber` were implemented as hand-written classes (correct), but:

1. `TypeMapper.IsUnmappableCppType()` was **NOT** updated — it still blocks `NS::Dictionary*` and `NS::Bundle*` (these types were removed, but `NS::Data`, `NS::Number` are not explicitly blocked — they fall through to the namespace mapping). However, `NS::Dictionary` and `NS::Bundle` ARE still blocked because:
   - `NS::Dictionary` is not in the explicit block list but IS in `SkipClasses`, so the generator would skip auto-generating the class but would still try to use the type in method signatures — except `IsUnmappableCppType` checks for the **raw C++ type string**, not the C# class name.

2. The generator was **never re-run** after adding these Foundation types. Evidence:
   - `MTLCompileOptions.cs` still has **no** `PreprocessorMacros` property (should use `NSDictionary`)
   - `MTLFunction.cs` still has **no** `FunctionConstantsDictionary` property (should use `NSDictionary`)
   - `MTLDevice.cs` still has **no** `NewDefaultLibrary(NSBundle)` overload (should use `NSBundle`)

**Fix:** Remove `NS::Dictionary` and `NS::Bundle` from `IsUnmappableCppType()`, then re-run the generator.

#### Issue 5: Incomplete & Wrong Handler Methods (Moot — Files Must Be Deleted)

Issues 5, 6, and 7 from the original audit are **moot** because all `.Handlers.cs` files and `BlockDelegates.cs` must be deleted (Issue 2). For reference, the hand-written files had:

- `MTLDevice.Handlers.cs` — only 3 of ~13 overloads implemented
- `MTL4Compiler.Handlers.cs` — 1 method with wrong API signature (`NSString` instead of `MTL4CompileOptions`)
- `BlockDelegates.cs` — defines unused delegate types

All of these will be replaced by generator-emitted code once the generator supports Block/handler parsing.

#### Issue 8: Incorrect Ownership Semantics in NSNumber

```csharp
// Current:
public static NSNumber FromInteger(nint value)
{
    nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NSNumberBindings.Class, NSNumberBindings.NumberWithInteger, value);
    return new(nativePtr, NativeObjectOwnership.Owned);
}
```

**Problem:** `[NSNumber numberWithInteger:]` is a convenience class method that returns an **autoreleased** object, not a +1 retained object. Using `NativeObjectOwnership.Owned` here will over-release. Should either:
- Use `NativeObjectOwnership.Borrowed`, or
- Use `alloc` + `initWithInteger:` pattern (which returns a +1 retained object) and keep `Owned`

The same issue applies to `FromUnsignedInteger`, `FromFloat`, `FromDouble`, `FromBool`.

#### Issue 9: BlockDescriptor Safety Concern

In `BlockLiteral.cs`, the `SharedDescriptor` property returns a pointer to a `file`-scoped static struct via `fixed`:

```csharp
public static BlockDescriptor* SharedDescriptor
{
    get
    {
        fixed (BlockDescriptor* p = &s_shared)
        {
            return p;
        }
    }
}
```

**Problem:** The `fixed` block only pins the object during its scope. Returning the pointer outside `fixed` is undefined behavior for managed heap objects. Since `s_shared` is a static field of a struct type (value type), it is stored on the managed heap as a static field and **can be relocated by GC**. This should use `GCHandle.Alloc(..., GCHandleType.Pinned)` at startup, or allocate the descriptor in unmanaged memory via `NativeMemory.Alloc`.

---

## Summary of Work Items

| # | Category | Estimated Effort | Priority |
|---|---|---|---|
| 1 | **DELETE all `.Handlers.cs` files** and `BlockDelegates.cs` — these are incorrectly hand-written; all Metal API content must be generator-driven | Low | P0 — Wrong architecture |
| 2 | **Implement ObjC Block support in the generator** (`CppParser` → `TypeMapper` → `CSharpEmitter`) so handler/Block methods are auto-generated from C++ headers | High | P0 — Core missing feature |
| 3 | **Fix generator** to always emit `partial` keyword for all classes | Low | P0 — Required for extensibility |
| 4 | **Fix `TypeMapper.IsUnmappableCppType()`** to allow `NS::Dictionary`, `NS::Bundle`, `NS::Data`, `NS::Number` + **re-run generator** | Low | P0 — Unblocks multiple properties |
| 5 | **Fix `NSNumber` ownership** — use `alloc`/`init` pattern or `Borrowed` ownership | Low | P0 — Runtime crash risk |
| 6 | **Fix `BlockDescriptor` pinning** — use unmanaged memory for the shared descriptor | Low | P0 — Undefined behavior |
| 7 | **Rewrite** `DispatchQueue`, `DispatchData`, `CGColorSpace`, `IOSurface` as OOP wrapper classes + update `TypeMapper.cs` type mappings | Medium | P1 — OOP design |
| 8 | Implement remaining Foundation types (`NSSet`, `NSEnumerator`, `NSDate`, etc.) | Low | P3 — Rarely needed |
