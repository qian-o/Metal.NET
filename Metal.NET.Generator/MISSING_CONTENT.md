# Metal.NET — Coverage Analysis & Remaining Work

This document summarizes what the Metal.NET binding covers from metal-cpp, what is still missing, and what work remains.

---

## Table of Contents

1. [Coverage Summary](#1-coverage-summary)
2. [Skipped Methods — Unmappable C++ Types](#2-skipped-methods--unmappable-c-types)
3. [Foundation Types — Hand-Written Status](#3-foundation-types--hand-written-status)
4. [Unmapped Structs](#4-unmapped-structs)
5. [Skipped Free Functions](#5-skipped-free-functions)

---

## 1. Coverage Summary

### Overall Statistics

| Metric | Count |
|---|---|
| C++ classes parsed from metal-cpp | ~248 |
| C# class files generated (Metal) | 228 |
| C# class files generated (MetalFX) | 17 |
| C# class files generated (QuartzCore) | 2 |
| C# class files hand-written (Foundation) | 9 |
| Enums generated | 130 (124 Metal + 5 Foundation + 1 MetalFX) |
| Structs defined (MTLStructs.cs) | 34 |
| Block delegate types generated | 18 |
| Free functions (P/Invoke) | 3 |
| Methods in headers | ~3435 |
| Methods generated | ~3318 (96.6%) |
| Methods skipped (unmappable types) | ~117 (3.4%) |

### Metal Framework — Full Coverage ✓

All 96 Metal header files (`MTL*.hpp`, `MTL4*.hpp`) have corresponding auto-generated C# class files. This includes all MTL4 classes introduced in the latest metal-cpp headers.

### MetalFX Framework — Full Coverage ✓

All MetalFX classes (8 `MTLFX` + 4 `MTL4FX` + descriptors/bases) are generated.

### QuartzCore Framework — Full Coverage ✓

Both `CAMetalDrawable` and `CAMetalLayer` are generated.

---

## 2. Skipped Methods — Unmappable C++ Types

117 methods (~3.4%) are silently skipped because they use C++ constructs that cannot be mapped to `objc_msgSend` calls. The generator's `TypeMapper.IsUnmappableCppType()` blocks these patterns:

| Pattern | Methods Skipped | Example |
|---|---|---|
| Pointer-to-const arrays (`* const`) | ~77 | `CommandBuffer::useResidencySets(const ResidencySet* const[])` |
| C++ references (`&`) | ~26 | `CommitOptions::addFeedbackHandler(const CommitFeedbackHandlerFunction&)` |
| Template types (`<`, `>`) | ~7 | `Array::objectEnumerator() → Enumerator<Object>*` |
| Autoreleased return types | ~6 | `Device::newRenderPipelineState(…, AutoreleasedRenderPipelineReflection*)` |
| Kernel types | ~1 | `Resource::setOwner() → kern_return_t` |

### Notes

- **Pointer-to-const arrays** (`const T* const[]`) are the largest gap. These are methods that accept arrays of Metal objects (residency sets, command buffers, etc.). Supporting them would require `fixed` pointer or `Span<nint>` marshalling.
- **C++ references** are `std::function` convenience overloads in metal-cpp. The ObjC block-based versions of the same methods ARE generated — the `std::function` variants have no ObjC selector and are C++-only wrappers.
- **Autoreleased types** are methods returning reflection objects with `MTL::AutoreleasedXxxReflection*` out-parameters. These need ARC bridging.
- **Template types** are `NS::Enumerator<T>` returns — not needed since the underlying `NSArray`/`NSDictionary` iteration is handled by the hand-written Foundation types.

---

## 3. Foundation Types — Hand-Written Status

Foundation types are hand-written (in `CSharpEmitter.SkipClasses`) because they need custom marshalling. The generator skips their class definitions but generates references to them in other classes.

| Foundation Type | C# File | Status |
|---|---|---|
| `NSString` | ✓ `NSString.cs` | Implemented |
| `NSError` | ✓ `NSError.cs` | Implemented |
| `NSArray` | ✓ `NSArray.cs` | Implemented |
| `NSURL` | ✓ `NSURL.cs` | Implemented |
| `NSAutoreleasePool` | ✓ `NSAutoreleasePool.cs` | Implemented |
| `NSDictionary` | ✓ `NSDictionary.cs` | Implemented |
| `NSNumber` | ✓ `NSNumber.cs` | Implemented |
| `NSData` | ✓ `NSData.cs` | Implemented |
| `NSBundle` | ✓ `NSBundle.cs` | Implemented |
| `NSObject` | ✗ | In SkipClasses, not yet written |
| `NSValue` | ✗ | In SkipClasses, not yet written |
| `NSDate` | ✗ | In SkipClasses, not yet written |
| `NSSet` | ✗ | In SkipClasses, not yet written |
| `NSEnumerator` | ✗ | In SkipClasses, not yet written |
| `NSNotification` | ✗ | In SkipClasses, not yet written |
| `NSNotificationCenter` | ✗ | In SkipClasses, not yet written |
| `NSProcessInfo` | ✗ | In SkipClasses, not yet written |

### Not Mapped (Not Relevant to Metal)

These Foundation types/protocols exist in metal-cpp headers but are not needed for Metal API usage:

- `NSLocking`, `NSCondition` — threading primitives (use .NET equivalents)
- `NSCopying`, `NSSecureCoding` — ObjC protocols (handled by NativeObject base)
- `NSFastEnumeration` — ObjC iteration protocol (not needed with typed arrays)
- `NSSharedPtr` — C++ smart pointer template (metal-cpp internal)

### NS::Object Mapping

`NS::Object*` parameters/returns in Metal APIs are mapped to `nint` in the generated C# code. This is because `NativeObject` (the C# base class) doesn't implement `INativeObject<NativeObject>` (required by the `GetProperty`/`SetProperty` helpers). Affected members:

- `MTLCaptureDescriptor.CaptureObject` → typed as `nint`
- `MTLDevice.RemoveDeviceObserver` → takes `nint` parameter

---

## 4. Unmapped Structs

The following structs from metal-cpp headers are **not** mapped in `MTLStructs.cs`:

### Foundation

| Struct | Reason |
|---|---|
| `NS::OperatingSystemVersion` | Only used by `NSProcessInfo` (not yet implemented) |

---

## 5. Skipped Free Functions

### IOCompressor Functions (`MTLIOCompressor.hpp`)

The IOCompressor header defines 4 C-level functions loaded via `MTL_DEF_FUNC` macros (not `extern "C"`):

| Function | Status |
|---|---|
| `MTLIOCompressionContextDefaultChunkSize()` | Not generated |
| `MTLIOCreateCompressionContext(path, type, chunkSize)` | Not generated |
| `MTLIOCompressionContextAppendData(ctx, data, size)` | Not generated |
| `MTLIOFlushAndDestroyCompressionContext(ctx)` | Not generated |

These are function-pointer-based APIs loaded at runtime by metal-cpp. The header is excluded from parsing.

### Device Observer

| Function | Status |
|---|---|
| `MTLCopyAllDevicesWithObserver(NS::Object**, DeviceNotificationHandlerBlock)` | Skipped — requires `NS::Object**` + block parameter |

The other 3 free functions (`MTLCreateSystemDefaultDevice`, `MTLCopyAllDevices`, `MTLRemoveDeviceObserver`) are all generated as P/Invoke declarations in `MTLDevice.cs`.
