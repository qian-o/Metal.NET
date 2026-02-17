using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4CommandQueue_Selectors
{
    internal static readonly Selector addResidencySet_ = Selector.Register("addResidencySet:");
    internal static readonly Selector removeResidencySet_ = Selector.Register("removeResidencySet:");
    internal static readonly Selector signalDrawable_ = Selector.Register("signalDrawable:");
    internal static readonly Selector signalEvent_value_ = Selector.Register("signalEvent:value:");
    internal static readonly Selector wait_value_ = Selector.Register("wait:value:");
    internal static readonly Selector wait_ = Selector.Register("wait:");
}

public class MTL4CommandQueue : IDisposable
{
    public nint NativePtr { get; }

    public MTL4CommandQueue(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4CommandQueue o) => o.NativePtr;
    public static implicit operator MTL4CommandQueue(nint ptr) => new MTL4CommandQueue(ptr);

    ~MTL4CommandQueue() => Release();

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

    public void AddResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueue_Selectors.addResidencySet_, residencySet.NativePtr);
    }

    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueue_Selectors.removeResidencySet_, residencySet.NativePtr);
    }

    public void SignalDrawable(MTLDrawable drawable)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueue_Selectors.signalDrawable_, drawable.NativePtr);
    }

    public void SignalEvent(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueue_Selectors.signalEvent_value_, @event.NativePtr, (nint)value);
    }

    public void Wait(MTLEvent @event, nuint value)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueue_Selectors.wait_value_, @event.NativePtr, (nint)value);
    }

    public void Wait(MTLDrawable drawable)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueue_Selectors.wait_, drawable.NativePtr);
    }

}
