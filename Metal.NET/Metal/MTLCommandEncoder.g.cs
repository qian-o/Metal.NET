using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLCommandEncoder_Selectors
{
    internal static readonly Selector barrierAfterQueueStages_beforeStages_ = Selector.Register("barrierAfterQueueStages:beforeStages:");
    internal static readonly Selector endEncoding = Selector.Register("endEncoding");
    internal static readonly Selector insertDebugSignpost_ = Selector.Register("insertDebugSignpost:");
    internal static readonly Selector popDebugGroup = Selector.Register("popDebugGroup");
    internal static readonly Selector pushDebugGroup_ = Selector.Register("pushDebugGroup:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

public class MTLCommandEncoder : IDisposable
{
    public nint NativePtr { get; }

    public MTLCommandEncoder(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLCommandEncoder o) => o.NativePtr;
    public static implicit operator MTLCommandEncoder(nint ptr) => new MTLCommandEncoder(ptr);

    ~MTLCommandEncoder() => Release();

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

    public void BarrierAfterQueueStages(nuint afterQueueStages, nuint beforeStages)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandEncoder_Selectors.barrierAfterQueueStages_beforeStages_, (nint)afterQueueStages, (nint)beforeStages);
    }

    public void EndEncoding()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandEncoder_Selectors.endEncoding);
    }

    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandEncoder_Selectors.insertDebugSignpost_, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandEncoder_Selectors.popDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandEncoder_Selectors.pushDebugGroup_, @string.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandEncoder_Selectors.setLabel_, label.NativePtr);
    }

}
