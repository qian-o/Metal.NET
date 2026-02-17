using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLCommandQueue_Selectors
{
    internal static readonly Selector addResidencySet_ = Selector.Register("addResidencySet:");
    internal static readonly Selector insertDebugCaptureBoundary = Selector.Register("insertDebugCaptureBoundary");
    internal static readonly Selector removeResidencySet_ = Selector.Register("removeResidencySet:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

public class MTLCommandQueue : IDisposable
{
    public nint NativePtr { get; }

    public MTLCommandQueue(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLCommandQueue o) => o.NativePtr;
    public static implicit operator MTLCommandQueue(nint ptr) => new MTLCommandQueue(ptr);

    ~MTLCommandQueue() => Release();

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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandQueue_Selectors.addResidencySet_, residencySet.NativePtr);
    }

    public void InsertDebugCaptureBoundary()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandQueue_Selectors.insertDebugCaptureBoundary);
    }

    public void RemoveResidencySet(MTLResidencySet residencySet)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandQueue_Selectors.removeResidencySet_, residencySet.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandQueue_Selectors.setLabel_, label.NativePtr);
    }

}
