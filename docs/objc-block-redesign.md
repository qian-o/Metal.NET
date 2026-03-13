# Objective-C Block Wrapper Redesign

## Problem

Metal APIs expect **Objective-C block structs**, not raw C function pointers.
The current implementation passes `Marshal.GetFunctionPointerForDelegate(delegate)` directly
to `objc_msgSend`, which is incorrect — the Objective-C runtime will interpret the pointer
as a block and try to read its `isa`, `flags`, `invoke` fields, causing undefined behavior.

## Solution

Introduce a base class `NativeBlock` that allocates a proper native block struct on the
unmanaged heap, and convert each existing `[UnmanagedFunctionPointer] delegate` in
`MTLDelegates.cs` into a `sealed class` inheriting from it.

---

## New File: `Common/NativeBlock.cs`

### Native Structs

Two sequential structs that mirror the Objective-C block ABI:

```
BlockDescriptor { nuint Reserved, nuint Size }

BlockLiteral {
    nint  Isa             // &_NSConcreteGlobalBlock (resolved from libobjc)
    int   Flags           // BLOCK_IS_GLOBAL (1 << 29)
    int   Reserved        // 0
    nint  Invoke          // unmanaged function pointer (the trampoline)
    BlockDescriptor* Desc
    nint  Context         // GCHandle → managed callback
}
```

The `Context` field is a captured variable appended after the standard 5 fields.
This is valid per the block ABI — `Descriptor.Size` tells the runtime the real struct size.

### Base Class Pseudocode

Follow the same inheritance style as `DispatchObject` → `NativeObject`.
`NativeBlock` inherits from `NativeObject` with `NativeObjectOwnership.Managed`,
so the existing `Dispose` / finalizer / `ReleaseNative` lifecycle is reused as-is.

```csharp
// Common/NativeBlock.cs
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Metal.NET;

[StructLayout(LayoutKind.Sequential)]
internal struct BlockDescriptor
{
    public nuint Reserved;

    public nuint Size;
}

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct BlockLiteral
{
    public nint Isa;

    public int Flags;

    public int Reserved;

    public nint Invoke;

    public BlockDescriptor* Descriptor;

    public nint Context;
}

public abstract unsafe partial class NativeBlock : NativeObject
{
    private static readonly nint isa;

    private static readonly unsafe BlockDescriptor* descriptor;

    static NativeBlock()
    {
        nint libobjc = NativeLibrary.Load("/usr/lib/libobjc.A.dylib");

        isa = NativeLibrary.GetExport(libobjc, "_NSConcreteGlobalBlock");

        descriptor = (BlockDescriptor*)NativeMemory.Alloc((nuint)sizeof(BlockDescriptor));
        descriptor->Reserved = 0;
        descriptor->Size = (nuint)sizeof(BlockLiteral);
    }

    private readonly GCHandle contextHandle;

    protected NativeBlock(nint invoke, object context) : base(AllocBlock(invoke, context, out GCHandle handle), NativeObjectOwnership.Managed)
    {
        contextHandle = handle;
    }

    protected override void ReleaseNative()
    {
        NativeMemory.Free((void*)NativePtr);

        if (contextHandle.IsAllocated)
        {
            contextHandle.Free();
        }
    }

    protected static T GetContext<T>(nint blockPtr) where T : class
    {
        BlockLiteral* block = (BlockLiteral*)blockPtr;
        GCHandle handle = GCHandle.FromIntPtr(block->Context);

        return (T)handle.Target!;
    }

    private static nint AllocBlock(nint invoke, object context, out GCHandle handle)
    {
        handle = GCHandle.Alloc(context);

        BlockLiteral* block = (BlockLiteral*)NativeMemory.AllocZeroed((nuint)sizeof(BlockLiteral));
        block->Isa = isa;
        block->Flags = 1 << 29; // BLOCK_IS_GLOBAL
        block->Invoke = invoke;
        block->Descriptor = descriptor;
        block->Context = GCHandle.ToIntPtr(handle);

        return (nint)block;
    }
}
```

Key design notes:

- `AllocBlock` is a static helper so the result can be passed to `base(...)` in the
  constructor — matching the primary-constructor-chain style used throughout the project.
- `ReleaseNative()` is the single cleanup point, called by the existing `NativeObject`
  `Dispose()` and finalizer logic. No custom `IDisposable` needed.
- `NativePtr` (inherited from `NativeObject`) is the pointer to the native `BlockLiteral`.

---

## Handler Class Template

Each handler in `MTLDelegates.cs` is converted from a delegate to a sealed class.
The pattern is identical for every handler — only the `Action<>` signature and trampoline
parameter list differ:

```csharp
public sealed unsafe class XxxHandler(Action<StrongTypedArgs...> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, /* arg types */, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, /* nint arg1, ... */)
    {
        Action<StrongTypedArgs...> callback = GetContext<Action<StrongTypedArgs...>>(block);

        callback(new Arg1Type(arg1, NativeObjectOwnership.Borrowed), ...);
    }
}
```

### Example — `MTLCommandBufferHandler`

```csharp
public sealed unsafe class MTLCommandBufferHandler(Action<MTLCommandBuffer> callback) : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, nint commandBuffer)
    {
        Action<MTLCommandBuffer> callback = GetContext<Action<MTLCommandBuffer>>(block);

        callback(new MTLCommandBuffer(commandBuffer, NativeObjectOwnership.Borrowed));
    }
}
```

---

## Expected Calling Convention

### Before (broken)

```csharp
// MTLDelegates.cs — bare delegate
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLCommandBufferHandler(nint block, nint commandBuffer);

// ObjectiveC.cs — sends raw fptr, not a block
MsgSend(receiver, sel, Marshal.GetFunctionPointerForDelegate(handler));

// Usage — user must deal with raw nint, no Dispose
MTLCommandBufferHandler handler = (nint block, nint buffer) => { ... };
commandBuffer.AddCompletedHandler(handler);
```

### After (correct)

```csharp
// MTLDelegates.cs — proper block wrapper class
public sealed unsafe class MTLCommandBufferHandler : NativeBlock { ... }

// ObjectiveC.cs — handler.NativePtr is a proper block struct pointer
MsgSend(receiver, sel, handler.NativePtr);

// Usage — strongly typed, IDisposable via NativeObject
using MTLCommandBufferHandler handler = new((MTLCommandBuffer buffer) =>
{
    // strongly typed, no raw nint
});
commandBuffer.AddCompletedHandler(handler);
```

---

## Impact on Generated Code

Since `MTLDelegates.cs`, `ObjectiveC.cs` overloads, and the call-site wrapper classes
are **all produced by the code generator**, the generator needs these changes:

emit `sealed class : NativeBlock` (using the primary
   constructor pattern) instead of `[UnmanagedFunctionPointer] delegate`. Each class
   follows the template above.

2. **`ObjectiveC.cs` MsgSend overloads** — delete all overloads that accept a delegate
   type and call `Marshal.GetFunctionPointerForDelegate`. The handler's `NativePtr`
   (inherited from `NativeObject`) allows it to be passed as `nint` at call sites.

3. **Call-site methods** — parameter types keep the same name (e.g. `MTLCommandBufferHandler`),
   so method signatures remain unchanged. The only difference is that the type is now a class
   instead of a delegate. At the `MsgSend` call, use `handler.NativePtr` instead of the
   delegate instance directly.

## Manually Authored File

Only `Common/NativeBlock.cs` (the base class + native structs) is hand-written.
Everything else is generated.
