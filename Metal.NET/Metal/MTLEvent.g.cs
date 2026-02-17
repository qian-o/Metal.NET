using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLEvent_Selectors
{
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

public class MTLEvent : IDisposable
{
    public nint NativePtr { get; }

    public MTLEvent(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLEvent o) => o.NativePtr;
    public static implicit operator MTLEvent(nint ptr) => new MTLEvent(ptr);

    ~MTLEvent() => Release();

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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLEvent_Selectors.setLabel_, label.NativePtr);
    }

}
