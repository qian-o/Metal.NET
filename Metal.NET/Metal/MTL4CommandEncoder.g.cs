using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4CommandEncoder_Selectors
{
    internal static readonly Selector barrierAfterEncoderStages_beforeEncoderStages_visibilityOptions_ = Selector.Register("barrierAfterEncoderStages:beforeEncoderStages:visibilityOptions:");
    internal static readonly Selector barrierAfterQueueStages_beforeStages_visibilityOptions_ = Selector.Register("barrierAfterQueueStages:beforeStages:visibilityOptions:");
    internal static readonly Selector barrierAfterStages_beforeQueueStages_visibilityOptions_ = Selector.Register("barrierAfterStages:beforeQueueStages:visibilityOptions:");
    internal static readonly Selector endEncoding = Selector.Register("endEncoding");
    internal static readonly Selector insertDebugSignpost_ = Selector.Register("insertDebugSignpost:");
    internal static readonly Selector popDebugGroup = Selector.Register("popDebugGroup");
    internal static readonly Selector pushDebugGroup_ = Selector.Register("pushDebugGroup:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
    internal static readonly Selector updateFence_afterEncoderStages_ = Selector.Register("updateFence:afterEncoderStages:");
    internal static readonly Selector waitForFence_beforeEncoderStages_ = Selector.Register("waitForFence:beforeEncoderStages:");
}

public class MTL4CommandEncoder : IDisposable
{
    public nint NativePtr { get; }

    public MTL4CommandEncoder(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4CommandEncoder o) => o.NativePtr;
    public static implicit operator MTL4CommandEncoder(nint ptr) => new MTL4CommandEncoder(ptr);

    ~MTL4CommandEncoder() => Release();

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

    public void BarrierAfterEncoderStages(nuint afterEncoderStages, nuint beforeEncoderStages, nuint visibilityOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoder_Selectors.barrierAfterEncoderStages_beforeEncoderStages_visibilityOptions_, (nint)afterEncoderStages, (nint)beforeEncoderStages, (nint)visibilityOptions);
    }

    public void BarrierAfterQueueStages(nuint afterQueueStages, nuint beforeStages, nuint visibilityOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoder_Selectors.barrierAfterQueueStages_beforeStages_visibilityOptions_, (nint)afterQueueStages, (nint)beforeStages, (nint)visibilityOptions);
    }

    public void BarrierAfterStages(nuint afterStages, nuint beforeQueueStages, nuint visibilityOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoder_Selectors.barrierAfterStages_beforeQueueStages_visibilityOptions_, (nint)afterStages, (nint)beforeQueueStages, (nint)visibilityOptions);
    }

    public void EndEncoding()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoder_Selectors.endEncoding);
    }

    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoder_Selectors.insertDebugSignpost_, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoder_Selectors.popDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoder_Selectors.pushDebugGroup_, @string.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoder_Selectors.setLabel_, label.NativePtr);
    }

    public void UpdateFence(MTLFence fence, nuint afterEncoderStages)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoder_Selectors.updateFence_afterEncoderStages_, fence.NativePtr, (nint)afterEncoderStages);
    }

    public void WaitForFence(MTLFence fence, nuint beforeEncoderStages)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoder_Selectors.waitForFence_beforeEncoderStages_, fence.NativePtr, (nint)beforeEncoderStages);
    }

}
