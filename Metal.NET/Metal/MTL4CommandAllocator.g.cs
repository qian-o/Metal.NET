using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4CommandAllocator_Selectors
{
    internal static readonly Selector reset = Selector.Register("reset");
}

public class MTL4CommandAllocator : IDisposable
{
    public nint NativePtr { get; }

    public MTL4CommandAllocator(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4CommandAllocator o) => o.NativePtr;
    public static implicit operator MTL4CommandAllocator(nint ptr) => new MTL4CommandAllocator(ptr);

    ~MTL4CommandAllocator() => Release();

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

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandAllocator_Selectors.reset);
    }

}
