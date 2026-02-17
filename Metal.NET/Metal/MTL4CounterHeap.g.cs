using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4CounterHeap_Selectors
{
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

public class MTL4CounterHeap : IDisposable
{
    public nint NativePtr { get; }

    public MTL4CounterHeap(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4CounterHeap o) => o.NativePtr;
    public static implicit operator MTL4CounterHeap(nint ptr) => new MTL4CounterHeap(ptr);

    ~MTL4CounterHeap() => Release();

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

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CounterHeap_Selectors.setLabel_, label.NativePtr);
    }

}
