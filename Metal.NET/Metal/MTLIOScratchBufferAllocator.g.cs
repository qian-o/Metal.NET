using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLIOScratchBufferAllocator_Selectors
{
    internal static readonly Selector newScratchBuffer_ = Selector.Register("newScratchBuffer:");
}

public class MTLIOScratchBufferAllocator : IDisposable
{
    public nint NativePtr { get; }

    public MTLIOScratchBufferAllocator(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLIOScratchBufferAllocator o) => o.NativePtr;
    public static implicit operator MTLIOScratchBufferAllocator(nint ptr) => new MTLIOScratchBufferAllocator(ptr);

    ~MTLIOScratchBufferAllocator() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    public MTLIOScratchBuffer NewScratchBuffer(nuint minimumSize)
    {
        var __r = new MTLIOScratchBuffer(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLIOScratchBufferAllocator_Selectors.newScratchBuffer_, (nint)minimumSize));
        return __r;
    }

}
