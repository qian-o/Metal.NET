# Objective-C Block Wrapper Redesign

## Problem

Metal APIs expect **Objective-C block structs**, not raw C function pointers.
Passing `Marshal.GetFunctionPointerForDelegate(delegate)` directly to `objc_msgSend`
is incorrect — the runtime interprets the pointer as a block and tries to read
its `isa`, `flags`, `invoke` fields, causing undefined behavior.

## Solution

A base class `NativeBlock` allocates a proper native block struct on the unmanaged
heap. Each block handler in `MTLDelegates.cs` is a `sealed class` inheriting from it.

---

## Block ABI Layout

The native block struct mirrors the Objective-C block ABI:

```
Block {
    nint  Isa             // &_NSConcreteGlobalBlock
    int   Flags           // BLOCK_IS_GLOBAL (1 << 29)
    int   Reserved        // 0
    nint  Invoke          // unmanaged function pointer (the trampoline)
    nint  Descriptor      // → { nuint Reserved = 0, nuint Size = sizeof(Block) }
    nint  Context         // GCHandle → managed callback
}
```

The `Context` field is appended after the standard 5 fields.
`Descriptor.Size` tells the runtime the real struct size, so this is valid per the block ABI.

---

## Base Class: `NativeBlock`

`NativeBlock` inherits from `NativeObject` with `NativeObjectOwnership.Managed`,
reusing the existing `Dispose` / finalizer / `ReleaseNative` lifecycle.

```csharp
// Common/NativeBlock.cs
using System.Runtime.InteropServices;

namespace Metal.NET;

/// <summary>
/// Base class for Objective-C block wrappers. Allocates a native block struct
/// on the unmanaged heap that conforms to the Objective-C block ABI.
/// </summary>
public abstract unsafe class NativeBlock : NativeObject
{
    private static readonly nint isa;
    private static readonly nint descriptor;

    static NativeBlock()
    {
        isa = NativeLibrary.GetExport(NativeLibrary.Load("/usr/lib/libobjc.A.dylib"), "_NSConcreteGlobalBlock");

        // Block descriptor: { nuint Reserved = 0, nuint Size = sizeof(Block) }
        descriptor = (nint)NativeMemory.Alloc((uint)(sizeof(nuint) * 2));
        new nuint[] { 0, (nuint)sizeof(Block) }.CopyTo(new Span<nuint>((void*)descriptor, 2));
    }

    private readonly GCHandle handle;

    protected NativeBlock(nint invoke, object context) : base(AllocBlock(invoke, context, out GCHandle handle), NativeObjectOwnership.Managed)
    {
        this.handle = handle;
    }

    protected override void ReleaseNative()
    {
        NativeMemory.Free((void*)NativePtr);

        handle.Free();
    }

    /// <summary>
    /// Retrieves the managed callback from a block's context field.
    /// </summary>
    protected static T GetContext<T>(nint block) where T : class
    {
        return (T)GCHandle.FromIntPtr(((Block*)block)->Context).Target!;
    }

    private static nint AllocBlock(nint invoke, object context, out GCHandle handle)
    {
        Block* block = (Block*)NativeMemory.Alloc((nuint)sizeof(Block));
        block->Isa = isa;
        block->Flags = 1 << 29; // BLOCK_IS_GLOBAL
        block->Reserved = 0;
        block->Invoke = invoke;
        block->Descriptor = descriptor;
        block->Context = GCHandle.ToIntPtr(handle = GCHandle.Alloc(context));

        return (nint)block;
    }
}

/// <summary>
/// Native layout of an Objective-C block with an appended context field.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
file struct Block
{
    public nint Isa;

    public int Flags;

    public int Reserved;

    public nint Invoke;

    public nint Descriptor;

    public nint Context;
}
```

Key design notes:

- `AllocBlock` is a static helper so the result can be passed to `base(...)` in the
  constructor — matching the constructor-chain style used throughout the project.
- `ReleaseNative()` is the single cleanup point, called by the existing `NativeObject`
  `Dispose()` and finalizer logic. No custom `IDisposable` needed.
- `NativePtr` (inherited from `NativeObject`) points to the native block.

---

## Handler Pattern

Each handler in `MTLDelegates.cs` is a sealed class inheriting `NativeBlock`.
The pattern is identical for every handler — only the `Action<>` signature and
trampoline parameter list differ:

```csharp
public sealed unsafe class XxxHandler(Action<StrongTypedArgs...> callback)
    : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, /* arg types */, void>)&Trampoline, callback)
{
    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void Trampoline(nint block, /* nint arg1, ... */)
    {
        Action<StrongTypedArgs...> callback = GetContext<Action<StrongTypedArgs...>>(block);

        callback(new Arg1Type(arg1, NativeObjectOwnership.Borrowed), ...);
    }
}
```

### Example: `MTLCommandBufferHandler`

```csharp
public sealed unsafe class MTLCommandBufferHandler(Action<MTLCommandBuffer> callback)
    : NativeBlock((nint)(delegate* unmanaged[Cdecl]<nint, nint, void>)&Trampoline, callback)
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

## Usage

### Before (broken)

```csharp
// MTLDelegates.cs — bare delegate
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void MTLCommandBufferHandler(nint block, nint commandBuffer);

// ObjectiveC.cs — sends raw fptr, not a block
MsgSend(receiver, sel, Marshal.GetFunctionPointerForDelegate(handler));

// User code — raw nint, no Dispose
MTLCommandBufferHandler handler = (nint block, nint buffer) => { ... };
commandBuffer.AddCompletedHandler(handler);
```

### After (correct)

```csharp
// MTLDelegates.cs — proper block wrapper class
public sealed unsafe class MTLCommandBufferHandler : NativeBlock { ... }

// ObjectiveC.cs — handler.NativePtr is a proper block struct pointer
MsgSend(receiver, sel, handler.NativePtr);

// User code — strongly typed, IDisposable via NativeObject
using MTLCommandBufferHandler handler = new((MTLCommandBuffer buffer) =>
{
    // strongly typed, no raw nint
});
commandBuffer.AddCompletedHandler(handler);
```

---

## Impact on Generated Code

`MTLDelegates.cs`, `ObjectiveC.cs` overloads, and call-site wrapper classes are all
produced by the code generator. The generator changes:

1. **`MTLDelegates.cs`** — emit `sealed class : NativeBlock` (using the primary
   constructor pattern) instead of `[UnmanagedFunctionPointer] delegate`.

2. **`ObjectiveC.cs` MsgSend overloads** — remove all overloads that accept a delegate
   type. The handler's `NativePtr` (inherited from `NativeObject`) is passed as `nint`.

3. **Call-site methods** — parameter types keep the same name (e.g. `MTLCommandBufferHandler`),
   so method signatures are unchanged. At the `MsgSend` call, use `handler.NativePtr`
   instead of the delegate instance.

---

## File Ownership

| File | Authored |
|------|----------|
| `Common/NativeBlock.cs` | Hand-written |
| `Metal/MTLDelegates.cs` | Generated |
| `Common/ObjectiveC.cs` | Generated |
| Call-site wrapper classes | Generated |
