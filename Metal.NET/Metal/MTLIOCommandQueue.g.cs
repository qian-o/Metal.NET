using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLIOCommandQueue_Selectors
{
    internal static readonly Selector enqueueBarrier = Selector.Register("enqueueBarrier");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

public class MTLIOCommandQueue : IDisposable
{
    public nint NativePtr { get; }

    public MTLIOCommandQueue(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLIOCommandQueue o) => o.NativePtr;
    public static implicit operator MTLIOCommandQueue(nint ptr) => new MTLIOCommandQueue(ptr);

    ~MTLIOCommandQueue() => Release();

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

    public void EnqueueBarrier()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueue_Selectors.enqueueBarrier);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueue_Selectors.setLabel_, label.NativePtr);
    }

}
