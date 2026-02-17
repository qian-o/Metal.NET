namespace Metal.NET;

file class MTL4CommandEncoderSelector
{
    public static readonly Selector BarrierAfterEncoderStages_beforeEncoderStages_visibilityOptions_ = Selector.Register("barrierAfterEncoderStages:beforeEncoderStages:visibilityOptions:");
    public static readonly Selector BarrierAfterQueueStages_beforeStages_visibilityOptions_ = Selector.Register("barrierAfterQueueStages:beforeStages:visibilityOptions:");
    public static readonly Selector BarrierAfterStages_beforeQueueStages_visibilityOptions_ = Selector.Register("barrierAfterStages:beforeQueueStages:visibilityOptions:");
    public static readonly Selector EndEncoding = Selector.Register("endEncoding");
    public static readonly Selector InsertDebugSignpost_ = Selector.Register("insertDebugSignpost:");
    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");
    public static readonly Selector PushDebugGroup_ = Selector.Register("pushDebugGroup:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector UpdateFence_afterEncoderStages_ = Selector.Register("updateFence:afterEncoderStages:");
    public static readonly Selector WaitForFence_beforeEncoderStages_ = Selector.Register("waitForFence:beforeEncoderStages:");
}

public class MTL4CommandEncoder : IDisposable
{
    public MTL4CommandEncoder(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4CommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4CommandEncoder value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CommandEncoder(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    public void BarrierAfterEncoderStages(nuint afterEncoderStages, nuint beforeEncoderStages, nuint visibilityOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoderSelector.BarrierAfterEncoderStages_beforeEncoderStages_visibilityOptions_, (nint)afterEncoderStages, (nint)beforeEncoderStages, (nint)visibilityOptions);
    }

    public void BarrierAfterQueueStages(nuint afterQueueStages, nuint beforeStages, nuint visibilityOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoderSelector.BarrierAfterQueueStages_beforeStages_visibilityOptions_, (nint)afterQueueStages, (nint)beforeStages, (nint)visibilityOptions);
    }

    public void BarrierAfterStages(nuint afterStages, nuint beforeQueueStages, nuint visibilityOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoderSelector.BarrierAfterStages_beforeQueueStages_visibilityOptions_, (nint)afterStages, (nint)beforeQueueStages, (nint)visibilityOptions);
    }

    public void EndEncoding()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoderSelector.EndEncoding);
    }

    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoderSelector.InsertDebugSignpost_, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoderSelector.PopDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoderSelector.PushDebugGroup_, @string.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoderSelector.SetLabel_, label.NativePtr);
    }

    public void UpdateFence(MTLFence fence, nuint afterEncoderStages)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoderSelector.UpdateFence_afterEncoderStages_, fence.NativePtr, (nint)afterEncoderStages);
    }

    public void WaitForFence(MTLFence fence, nuint beforeEncoderStages)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandEncoderSelector.WaitForFence_beforeEncoderStages_, fence.NativePtr, (nint)beforeEncoderStages);
    }

}
