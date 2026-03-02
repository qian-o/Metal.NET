# Metal.NET — Roadmap & Design Specification

This document covers the remaining work items and architectural decisions for the Metal.NET binding library.

---

## Table of Contents

1. [Objective-C Block / Handler Support](#1-objective-c-block--handler-support)
2. [Enum Consolidation](#2-enum-consolidation)
3. [Missing Foundation Types & TypeMapper Unblocking](#3-missing-foundation-types--typemapper-unblocking)
4. [Folder Reorganization — Match Apple Framework Structure](#4-folder-reorganization--match-apple-framework-structure)
5. [Design Principles](#5-design-principles)

---

## 1. Objective-C Block / Handler Support

The generator currently skips every method whose signature includes an Objective-C Block (`^`) or `std::function` handler (~30 methods across 7 classes). This is the highest-priority missing feature.

### 1.1 Design — `[UnmanagedFunctionPointer]` Delegate Approach

Use the simple approach: generate `[UnmanagedFunctionPointer(CallingConvention.Cdecl)]` delegate types with **all `nint` parameters** (including the implicit `nint block` first parameter per ObjC block calling convention). The user is responsible for converting `nint` to/from Metal types (`new MTLCommandBuffer(ptr, NativeObjectOwnership.Borrowed)`, `.NativePtr`, etc.).

Since all parameters are `nint` (blittable), `[UnmanagedFunctionPointer]` works directly with no additional infrastructure.

#### Generated Delegate Types

The generator emits one delegate type per unique block type alias. Delegates are placed **above the `class` definition** in the same file, following the layout: `namespace` → delegate(s) → `class` → `file static class Bindings`.

Example file layout for `MTLCommandBuffer.cs`:

```csharp
namespace Metal.NET;

// Block delegate types — above the class
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLCommandBufferHandler(nint block, nint commandBuffer);

public class MTLCommandBuffer(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLCommandBuffer>
{
    // ... properties, methods (including block methods) ...

    public void AddCompletedHandler(MTLCommandBufferHandler handler)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferBindings.AddCompletedHandler, handler);
    }

    public void AddScheduledHandler(MTLCommandBufferHandler handler)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLCommandBufferBindings.AddScheduledHandler, handler);
    }
}

file static class MTLCommandBufferBindings
{
    // ... selectors ...
}
```

All delegate types used by the class's block methods are emitted together above the class. If the same delegate type is used by multiple methods (e.g., `MTLCommandBufferHandler` for both `AddCompletedHandler` and `AddScheduledHandler`), it is emitted only once.

#### All Delegate Types

```csharp
// void (^)(MTL::CommandBuffer*)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLCommandBufferHandler(nint block, nint commandBuffer);

// void (^)(MTL::Drawable*)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLDrawableHandler(nint block, nint drawable);

// void (^)(MTL::SharedEvent*, uint64_t)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLSharedEventHandler(nint block, nint sharedEvent, ulong value);

// void (^)(MTL::Library*, NS::Error*)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLNewLibraryCompletionHandler(nint block, nint library, nint error);

// void (^)(MTL::RenderPipelineState*, NS::Error*)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLNewRenderPipelineStateCompletionHandler(nint block, nint renderPipelineState, nint error);

// void (^)(MTL::ComputePipelineState*, NS::Error*)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLNewComputePipelineStateCompletionHandler(nint block, nint computePipelineState, nint error);

// void (^)(MTL::RenderPipelineState*, MTL::RenderPipelineReflection*, NS::Error*)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLNewRenderPipelineStateWithReflectionCompletionHandler(nint block, nint renderPipelineState, nint reflection, nint error);

// void (^)(MTL::ComputePipelineState*, MTL::ComputePipelineReflection*, NS::Error*)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLNewComputePipelineStateWithReflectionCompletionHandler(nint block, nint computePipelineState, nint reflection, nint error);

// void (^)(MTL::Function*, NS::Error*)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLNewFunctionCompletionHandler(nint block, nint function, nint error);

// void (^)(MTL::IOCommandBuffer*)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLIOCommandBufferHandler(nint block, nint ioCommandBuffer);

// void (^)(MTL::DynamicLibrary*, NS::Error*)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLNewDynamicLibraryCompletionHandler(nint block, nint dynamicLibrary, nint error);

// void (^)(MTL4::BinaryFunction*, NS::Error*)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTL4NewBinaryFunctionCompletionHandler(nint block, nint binaryFunction, nint error);

// void (^)(MTL4::MachineLearningPipelineState*, NS::Error*)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTL4NewMachineLearningPipelineStateCompletionHandler(nint block, nint machineLearningPipelineState, nint error);

// void (^)(MTL4::CommitFeedback*)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTL4CommitFeedbackHandler(nint block, nint commitFeedback);

// Deallocator: void (^)(void*, NSUInteger)
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLDeallocator(nint block, nint pointer, nuint length);
```

#### Delegate Naming Convention

The delegate name is derived from the C++ block type alias name with an `MTL` prefix:

| C++ Type Alias | C# Delegate Name |
|---|---|
| `CommandBufferHandler` | `MTLCommandBufferHandler` |
| `DrawablePresentedHandler` | `MTLDrawableHandler` |
| `SharedEventNotificationBlock` | `MTLSharedEventHandler` |
| `NewLibraryCompletionHandler` | `MTLNewLibraryCompletionHandler` |
| `NewDynamicLibraryCompletionHandler` | `MTLNewDynamicLibraryCompletionHandler` |
| `NewBinaryFunctionCompletionHandler` | `MTL4NewBinaryFunctionCompletionHandler` |
| `NewMachineLearningPipelineStateCompletionHandler` | `MTL4NewMachineLearningPipelineStateCompletionHandler` |
| `CommitFeedbackHandler` | `MTL4CommitFeedbackHandler` |
| (inline deallocator block) | `MTLDeallocator` |

#### First Parameter — `nint block`

Every ObjC block's invoke function receives the block pointer as its first argument. The generated delegates include this as `nint block`. Users can ignore it in their callback implementations.

#### User-Side Usage

```csharp
commandBuffer.AddCompletedHandler((nint block, nint cb) =>
{
    MTLCommandBuffer completedBuffer = new(cb, NativeObjectOwnership.Borrowed);
    Console.WriteLine($"Command buffer completed: {completedBuffer.Status}");
});
```

The user is responsible for wrapping `nint` parameters into the appropriate Metal types. This is consistent with the low-level nature of the binding.

#### Why This Design

| Concern | Solution |
|---|---|
| Reference types not blittable | All delegate params are `nint` — fully blittable |
| Simplicity | No trampolines or `GCHandle` management needed |
| Async callbacks | Marshalling layer handles block lifecycle — no manual copy/dispose needed |
| Different block signatures | Generator emits one delegate type per unique block type alias |
| User flexibility | Users convert `nint` ↔ Metal types themselves — full control |
| `std::function` overloads | Skip — these are metal-cpp convenience wrappers with no ObjC selector |

#### Generator Implementation

The generator pipeline must be enhanced:

1. **`CppParser.cs`** — Parse `using` declarations that define block type aliases (e.g., `using CommandBufferHandler = void (^)(MTL::CommandBuffer*)`). Extract the parameter list and store as `BlockTypeAlias` records.

2. **`CSharpEmitter.cs`** — For each method with a block parameter:
   - Emit the `[UnmanagedFunctionPointer(CallingConvention.Cdecl)]` delegate type **above the class definition** (once per unique block type alias per file).
   - Emit the public method that accepts the delegate and passes it to `objc_msgSend`.

3. **Deduplication** — Multiple methods may use the same block type alias (e.g., `CommandBufferHandler` is used by both `addCompletedHandler` and `addScheduledHandler`). Emit each delegate type only once.

### 1.2 Block/Handler Method Reference Table

All block methods that the generator must support (Block variants only — `std::function` skipped):

#### MTLCommandBuffer

| Method | Block Type |
|---|---|
| `addCompletedHandler` | `void (^)(MTL::CommandBuffer*)` |
| `addScheduledHandler` | `void (^)(MTL::CommandBuffer*)` |

#### MTLDrawable

| Method | Block Type |
|---|---|
| `addPresentedHandler` | `void (^)(MTL::Drawable*)` |

#### MTLSharedEvent

| Method | Block Type |
|---|---|
| `notifyListener` | `void (^)(MTL::SharedEvent*, uint64_t)` |

#### MTLIOCommandBuffer

| Method | Block Type |
|---|---|
| `addCompletedHandler` | `void (^)(MTL::IOCommandBuffer*)` |

#### MTLDevice

| Method | Block Type |
|---|---|
| `newBuffer(…, deallocator)` | `void (^)(void*, NS::UInteger)` — inline block (no type alias) |
| `newLibrary(source, CompletionHandler)` | `void (^)(MTL::Library*, NS::Error*)` |
| `newLibrary(stitched, CompletionHandler)` | `void (^)(MTL::Library*, NS::Error*)` |
| `newRenderPipelineState(…, CompletionHandler)` | `void (^)(MTL::RenderPipelineState*, NS::Error*)` |
| `newRenderPipelineState(…, reflection, CompletionHandler)` | `void (^)(MTL::RenderPipelineState*, MTL::RenderPipelineReflection*, NS::Error*)` |
| `newComputePipelineState(…, CompletionHandler)` | `void (^)(MTL::ComputePipelineState*, NS::Error*)` |
| `newComputePipelineState(…, reflection, CompletionHandler)` | `void (^)(MTL::ComputePipelineState*, MTL::ComputePipelineReflection*, NS::Error*)` |

#### MTLLibrary

| Method | Block Type |
|---|---|
| `newFunction(name, constants, CompletionHandler)` | `void (^)(MTL::Function*, NS::Error*)` |
| `newFunction(descriptor, CompletionHandler)` | `void (^)(MTL::Function*, NS::Error*)` |
| `newIntersectionFunction(descriptor, CompletionHandler)` | `void (^)(MTL::Function*, NS::Error*)` |

#### MTL4Compiler

| Method | Block Type |
|---|---|
| `newLibrary(descriptor, CompletionHandler)` | `void (^)(MTL::Library*, NS::Error*)` |
| `newRenderPipelineState(…, CompletionHandler)` | `void (^)(MTL::RenderPipelineState*, NS::Error*)` |
| `newRenderPipelineState(…, dynamicLinking, CompletionHandler)` | `void (^)(MTL::RenderPipelineState*, NS::Error*)` |
| `newRenderPipelineStateBySpecialization(…, CompletionHandler)` | `void (^)(MTL::RenderPipelineState*, NS::Error*)` |
| `newComputePipelineState(…, CompletionHandler)` | `void (^)(MTL::ComputePipelineState*, NS::Error*)` |
| `newComputePipelineState(…, dynamicLinking, CompletionHandler)` | `void (^)(MTL::ComputePipelineState*, NS::Error*)` |
| `newDynamicLibrary(library, CompletionHandler)` | `void (^)(MTL::DynamicLibrary*, NS::Error*)` |
| `newDynamicLibrary(url, CompletionHandler)` | `void (^)(MTL::DynamicLibrary*, NS::Error*)` |
| `newBinaryFunction(descriptor, CompletionHandler)` | `void (^)(MTL4::BinaryFunction*, NS::Error*)` |
| `newMachineLearningPipelineState(descriptor, CompletionHandler)` | `void (^)(MTL4::MachineLearningPipelineState*, NS::Error*)` |

#### MTL4CommitOptions

| Method | Block Type |
|---|---|
| `addFeedbackHandler` | `void (^)(MTL4::CommitFeedback*)` |

---

## 2. Enum Consolidation

Currently the generator emits **125 separate `.cs` files** for Metal enums (one file per enum). This is excessive — each file contains only a single small enum (typically 5–20 lines).

### Proposed Change

Consolidate all enums from the same C++ namespace into a **single file**, following the pattern already established by `MTLStructs.cs` (which groups all Metal structs into one file):

| C++ Namespace | Output File | Contents |
|---|---|---|
| `MTL` + `MTL4` | `Metal/MTLEnums.cs` | All MTL/MTL4 enums (~125 enums) |
| `NS` | `Foundation/NSEnums.cs` | All NS enums (~5 enums) |
| `MTLFX` + `MTL4FX` | `MetalFX/MTLFXEnums.cs` | All MTLFX/MTL4FX enums |

### Generator Change

In `CSharpEmitter.GenerateAll()`, instead of calling `GenerateEnum()` per enum (which creates a file per enum), group enums by output subdirectory and emit them all into one file:

```csharp
// Current (one file per enum):
foreach (EnumDef enumDef in context.Enums)
{
    GenerateEnum(enumDef);  // Creates Metal/MTLIndexType.cs, Metal/MTLPixelFormat.cs, etc.
}

// New (one file per namespace group):
var enumsBySubdir = context.Enums.GroupBy(e => TypeMapper.GetOutputSubdir(e.CppNamespace));
foreach (var group in enumsBySubdir)
{
    GenerateEnumFile(group.Key, group.ToList());  // Creates Metal/MTLEnums.cs, Foundation/NSEnums.cs, etc.
}
```

---

## 3. Missing Foundation Types & TypeMapper Unblocking

### 3.1 Foundation Types Needed

Foundation types are the **only** hand-written files in the project (they are in `SkipClasses` because they require custom marshalling logic). The following types are referenced by Metal API members but have no C# implementation:

| Type | Priority | Why Needed | Unblocks |
|---|---|---|---|
| `NSDictionary` | P0 | `MTLCompileOptions.preprocessorMacros`, `MTLFunction.functionConstantsDictionary`, `MTLLinkedFunctions.groups`, `MTL4StaticLinkingDescriptor.groups` | Multiple skipped get/set properties |
| `NSNumber` | P1 | `MTLRasterizationRateSampleArray.object` / `setObject` | Rasterization rate API |
| `NSData` | P1 | `MTLCounterSampleBuffer.resolveCounterRange`, `MTL4CounterHeap.resolveCounterRange`, `MTL4PipelineDataSetSerializer.serializeAsPipelinesScript` | Counter + pipeline serialization APIs |
| `NSBundle` | P1 | `MTLDevice.newDefaultLibrary(NS::Bundle*)` | Bundle-based library loading |
| `NSObject` | P2 | `MTLCaptureDescriptor.captureObject` (get/set) | Capture API |
| `NSValue` | P3 | Base type for NSNumber | Occasionally surfaces |
| `NSSet` | P3 | Some Metal API return types | Rarely needed |
| `NSEnumerator` | P3 | Iterating NSSet/NSDictionary | Rarely needed |
| `NSDate` | P3 | Timing/scheduling APIs | Rarely needed |
| `NSNotification` | P3 | Device added/removed events | macOS-specific |

### 3.2 TypeMapper Unblocking

`TypeMapper.IsUnmappableCppType()` currently blocks all the NS types listed above. When a Foundation type is implemented:

1. Add the hand-written `.cs` file to `Foundation/`
2. Remove the type from `IsUnmappableCppType()` in `TypeMapper.cs`
3. Re-run the generator — previously skipped members using that type will now be emitted

Currently blocked members:

| Class | Member | Blocked By |
|---|---|---|
| `MTLCompileOptions` | `preprocessorMacros` (get/set) | `NS::Dictionary` |
| `MTLFunction` | `functionConstantsDictionary` (get) | `NS::Dictionary` |
| `MTLLinkedFunctions` | `groups` (get/set) | `NS::Dictionary` |
| `MTL4StaticLinkingDescriptor` | `groups` (get/set) | `NS::Dictionary` |
| `MTLRasterizationRateSampleArray` | `object` / `setObject` | `NS::Number` |
| `MTLCounterSampleBuffer` | `resolveCounterRange` | `NS::Data` |
| `MTL4CounterHeap` | `resolveCounterRange` | `NS::Data` |
| `MTL4PipelineDataSetSerializer` | `serializeAsPipelinesScript` | `NS::Data` |
| `MTLDevice` | `newDefaultLibrary(NS::Bundle*)` | `NS::Bundle` |
| `MTLCaptureDescriptor` | `captureObject` (get/set) | `NS::Object` |
| `MTLDevice` | `newLibrary(dispatch_data_t, …)` | `dispatch_data_t` (non-ObjC, stays `nint`) |
| `MTLCaptureManager` | `startCapture(…, NS::Error**)` | `NS::Error**` (double pointer) |

---

## 4. Folder Reorganization — Match Apple Framework Structure

### Principle

The folder structure under `Metal.NET/` should mirror **Apple's framework names**. Each folder corresponds to an Apple framework (or system library). Infrastructure code that is not framework-specific stays in `Common/`.

### Current Structure

```
Metal.NET/
├── Common/
│   ├── Bool8.cs                  ← ObjC BOOL
│   ├── MTLStructs.cs             ← Metal-specific structs
│   ├── NativeObject.cs           ← Base class
│   ├── ObjectiveCRuntime.cs      ← libobjc P/Invoke
│   └── Selector.cs               ← ObjC selector
├── Foundation/                   ← Foundation.framework
├── Metal/                        ← Metal.framework (~353 files)
├── MetalFX/                      ← MetalFX.framework
└── QuartzCore/                   ← QuartzCore.framework
```

### Proposed Structure

```
Metal.NET/
├── Common/                       ← Internal infrastructure (NOT an Apple framework)
│   ├── NativeObject.cs           ← Base class, INativeObject<TSelf>, ownership model
│   ├── ObjectiveCRuntime.cs      ← libobjc P/Invoke, objc_msgSend, framework loading
│   ├── Selector.cs               ← ObjC selector type
│   └── Bool8.cs                  ← ObjC BOOL → byte
│
├── Foundation/                   ← Foundation.framework
│   ├── NSArray.cs                ← Hand-written
│   ├── NSAutoreleasePool.cs      ← Hand-written
│   ├── NSDictionary.cs           ← Hand-written (TO ADD)
│   ├── NSBundle.cs               ← Hand-written (TO ADD)
│   ├── NSData.cs                 ← Hand-written (TO ADD)
│   ├── NSNumber.cs               ← Hand-written (TO ADD)
│   ├── NSError.cs                ← Hand-written
│   ├── NSString.cs               ← Hand-written
│   ├── NSURL.cs                  ← Hand-written
│   └── NSEnums.cs                ← Auto-generated (ALL NS enums in one file)
│
├── Metal/                        ← Metal.framework (auto-generated)
│   ├── MTLStructs.cs             ← MOVED from Common/ (Metal-specific structs)
│   ├── MTLEnums.cs               ← Auto-generated (ALL MTL/MTL4 enums in one file)
│   └── … (~228 auto-generated class files)
│
├── MetalFX/                      ← MetalFX.framework (auto-generated)
│   ├── MTLFXEnums.cs             ← Auto-generated (ALL MTLFX/MTL4FX enums)
│   └── … (auto-generated class files)
│
└── QuartzCore/                   ← QuartzCore.framework (auto-generated)
    └── … (auto-generated files)
```

### Key Changes

| Item | From | To | Reason |
|---|---|---|---|
| `MTLStructs.cs` | `Common/` | `Metal/` | Metal-specific, not generic infrastructure |
| 125 enum files | `Metal/*.cs` (separate) | `Metal/MTLEnums.cs` (single) | Consolidation (Section 2) |
| NS enum files | `Foundation/*.cs` (separate) | `Foundation/NSEnums.cs` (single) | Consolidation |

### What Stays in `Common/`

`Common/` is for **internal infrastructure** that all Apple framework wrappers depend on — it's not an Apple framework:

- `NativeObject.cs` — base class / ownership model
- `ObjectiveCRuntime.cs` — libobjc P/Invoke (`objc_msgSend`, class/selector lookup)
- `Selector.cs` — ObjC selector type
- `Bool8.cs` — ObjC BOOL type

These are all implementation details of the Objective-C interop layer, used by every framework folder.

---

## 5. Design Principles

### 5.1 Everything Is Generator-Driven

All files in `Metal/`, `MetalFX/`, `QuartzCore/` are **auto-generated** by the generator pipeline (`CppParser` → `GeneratorContext` → `CSharpEmitter`). No hand-written `.cs` files may exist in these directories — they will be overwritten on the next generator run.

This includes:
- Class files (properties, methods)
- Enum files (consolidated)
- Block/handler methods and delegate types

The **only hand-written files** in the project are:
- `Common/` — infrastructure (`NativeObject`, `ObjectiveCRuntime`, `Selector`, `Bool8`)
- `Foundation/` — Foundation types that need custom marshalling (`NSString`, `NSError`, `NSArray`, `NSURL`, `NSAutoreleasePool`, and future `NSDictionary`, `NSBundle`, etc.)

### 5.2 Foundation Types Are Hand-Written

Foundation types like `NSString`, `NSError`, `NSDictionary` etc. are in `CSharpEmitter.SkipClasses` because the generator cannot auto-generate them from the C++ headers — they require custom marshalling, convenience methods, and special constructors.

After implementing a hand-written Foundation type:
1. The class stays in `SkipClasses` (generator never emits it)
2. Remove the type from `TypeMapper.IsUnmappableCppType()` and add a mapping entry
3. Re-run the generator — methods using that type will now be emitted with typed parameters

---

## Summary of Work Items

| # | Category | Effort | Priority |
|---|---|---|---|
| 1 | **Block/handler support** — generator emits `[UnmanagedFunctionPointer]` delegate types + handler methods per block type | Medium | P0 |
| 2 | **Enum consolidation** — change generator to emit all enums per namespace into single file | Low | P0 |
| 3 | **Move `MTLStructs.cs`** from `Common/` to `Metal/` | Trivial | P0 |
| 4 | **Implement `NSDictionary`** — hand-written Foundation type + unblock in TypeMapper | Medium | P0 |
| 5 | **Implement `NSNumber`, `NSData`, `NSBundle`** — hand-written Foundation types + unblock in TypeMapper | Medium | P1 |
| 6 | **Implement `NSObject`** — hand-written Foundation type for `CaptureDescriptor.captureObject` | Low | P2 |
| 7 | **Implement remaining Foundation types** (`NSSet`, `NSEnumerator`, `NSDate`, etc.) | Low | P3 |
