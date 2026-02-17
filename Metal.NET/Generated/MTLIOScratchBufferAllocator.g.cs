using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLIOScratchBufferAllocator_Selectors
{
    internal static readonly Selector newScratchBuffer_ = Selector.Register("newScratchBuffer:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLIOScratchBufferAllocator
{
    public readonly nint NativePtr;

    public MTLIOScratchBufferAllocator(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLIOScratchBufferAllocator o) => o.NativePtr;
    public static implicit operator MTLIOScratchBufferAllocator(nint ptr) => new MTLIOScratchBufferAllocator(ptr);

    public MTLIOScratchBuffer NewScratchBuffer(nuint minimumSize)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLIOScratchBufferAllocator_Selectors.newScratchBuffer_, (nint)minimumSize);
        return new MTLIOScratchBuffer(__result);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
