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

### Recommended Implementation Strategy

To support Block/Handler methods in C#, consider:

1. **Define C# delegate types** matching each block signature (e.g., `delegate void MTLCommandBufferHandler(MTLCommandBuffer commandBuffer)`).
2. **Use `ObjectiveCRuntime` P/Invoke** to call `objc_msgSend` with a function pointer obtained via `Marshal.GetFunctionPointerForDelegate` or the Objective-C block ABI.
3. **Alternatively**, use `ObjCBlockTrampolines` — build a small native helper that wraps a C function pointer into an Objective-C block, or use the well-known block struct layout (`Block_literal`) to create blocks from managed code.
4. For the `std::function` overloads in metal-cpp, these are convenience wrappers around the block variants; only the block variant needs a P/Invoke — the `std::function` overload can be a managed convenience that wraps a C# `Action`/`Func` into the delegate.

---

## 2. Missing libdispatch (GCD) P/Invokes

`dispatch_queue_t` and `dispatch_data_t` are currently mapped to raw `nint` with no creation or management APIs. The following P/Invokes (from `libSystem.B.dylib` or `libdispatch.dylib`) are needed:

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

### Recommended Implementation

Create a `DispatchQueue` wrapper class (or keep as a static helper class with P/Invoke methods) under a new `Dispatch/` folder or within `Common/Interop/`.

---

## 3. Missing Foundation Class Implementations

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

## 5. Missing CoreGraphics / IOSurface P/Invokes

Some Metal APIs use CoreGraphics and IOSurface types that are mapped to raw `nint` with no helper APIs:

| Type | Current Mapping | Used By | Needed P/Invokes |
|---|---|---|---|
| `CGColorSpaceRef` | `nint` | `CAMetalLayer.colorspace` | `CGColorSpaceCreateDeviceRGB()`, `CGColorSpaceCreateWithName(CFStringRef)`, `CGColorSpaceRelease(CGColorSpaceRef)`, `CGColorSpaceRetain(CGColorSpaceRef)` |
| `IOSurfaceRef` | `nint` | `MTLTexture.iosurface`, `MTLDevice.newTexture(…, IOSurfaceRef, …)` | `IOSurfaceCreate(CFDictionaryRef)`, `IOSurfaceGetWidth/Height/BytesPerRow(IOSurfaceRef)` |

### Recommended Implementation

- Create minimal wrapper types or static P/Invoke helper classes.
- Place them under a `CoreGraphics/` and `IOSurface/` folder respectively, or under `Common/Interop/`.

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
│   ├── DispatchQueue.cs             ← dispatch_queue_t wrapper or P/Invoke helpers
│   └── DispatchData.cs              ← dispatch_data_t wrapper or P/Invoke helpers
│
├── CoreGraphics/                    ← CoreGraphics interop (NEW)
│   └── CGColorSpace.cs              ← CGColorSpaceRef P/Invoke helpers
│
├── IOSurface/                       ← IOSurface interop (NEW)
│   └── IOSurface.cs                 ← IOSurfaceRef P/Invoke helpers
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

## Summary of Work Items

| # | Category | Estimated Effort | Priority |
|---|---|---|---|
| 1 | Implement ObjC Block support for C# delegates | High | P0 — Unblocks ~30 methods |
| 2 | Implement `NSDictionary` hand-written binding | Medium | P0 — Unblocks multiple properties |
| 3 | Implement libdispatch P/Invokes | Medium | P1 — Needed for `SharedEventListener`, `MTL4CommandQueue` |
| 4 | Implement `NSBundle`, `NSData`, `NSNumber` bindings | Medium | P1 — Unblocks `newDefaultLibrary(bundle:)` and data-based APIs |
| 5 | Implement CoreGraphics/IOSurface helpers | Low | P2 — Quality-of-life for `CAMetalLayer.colorspace` and texture IOSurface |
| 6 | Folder reorganization (Common → ObjCRuntime + Metal) | Low | P2 — Code organization improvement |
| 7 | Implement remaining Foundation types (`NSSet`, `NSEnumerator`, `NSDate`, etc.) | Low | P3 — Rarely needed |
