using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFence_Selectors
{
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

public class MTLFence : IDisposable
{
    public nint NativePtr { get; }

    public MTLFence(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFence o) => o.NativePtr;
    public static implicit operator MTLFence(nint ptr) => new MTLFence(ptr);

    ~MTLFence() => Release();

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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFence_Selectors.setLabel_, label.NativePtr);
    }

}
