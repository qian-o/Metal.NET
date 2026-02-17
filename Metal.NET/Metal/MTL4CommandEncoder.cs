namespace Metal.NET;

public class MTL4CommandEncoder : IDisposable
{
    public MTL4CommandEncoder(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4CommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTL4CommandBuffer CommandBuffer => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandEncoderSelector.CommandBuffer));

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandEncoderSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.SetLabel, value.NativePtr);
    }

    public void BarrierAfterEncoderStages(uint afterEncoderStages, uint beforeEncoderStages, uint visibilityOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.BarrierAfterEncoderStagesBeforeEncoderStagesVisibilityOptions, (nuint)afterEncoderStages, (nuint)beforeEncoderStages, (nuint)visibilityOptions);
    }

    public void BarrierAfterQueueStages(uint afterQueueStages, uint beforeStages, uint visibilityOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.BarrierAfterQueueStagesBeforeStagesVisibilityOptions, (nuint)afterQueueStages, (nuint)beforeStages, (nuint)visibilityOptions);
    }

    public void BarrierAfterStages(uint afterStages, uint beforeQueueStages, uint visibilityOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.BarrierAfterStagesBeforeQueueStagesVisibilityOptions, (nuint)afterStages, (nuint)beforeQueueStages, (nuint)visibilityOptions);
    }

    public void EndEncoding()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.EndEncoding);
    }

    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.InsertDebugSignpost, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.PopDebugGroup);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.PushDebugGroup, @string.NativePtr);
    }

    public void UpdateFence(MTLFence fence, uint afterEncoderStages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.UpdateFenceAfterEncoderStages, fence.NativePtr, (nuint)afterEncoderStages);
    }

    public void WaitForFence(MTLFence fence, uint beforeEncoderStages)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandEncoderSelector.WaitForFenceBeforeEncoderStages, fence.NativePtr, (nuint)beforeEncoderStages);
    }

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

}

file class MTL4CommandEncoderSelector
{
    public static readonly Selector CommandBuffer = Selector.Register("commandBuffer");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector BarrierAfterEncoderStagesBeforeEncoderStagesVisibilityOptions = Selector.Register("barrierAfterEncoderStages:beforeEncoderStages:visibilityOptions:");

    public static readonly Selector BarrierAfterQueueStagesBeforeStagesVisibilityOptions = Selector.Register("barrierAfterQueueStages:beforeStages:visibilityOptions:");

    public static readonly Selector BarrierAfterStagesBeforeQueueStagesVisibilityOptions = Selector.Register("barrierAfterStages:beforeQueueStages:visibilityOptions:");

    public static readonly Selector EndEncoding = Selector.Register("endEncoding");

    public static readonly Selector InsertDebugSignpost = Selector.Register("insertDebugSignpost:");

    public static readonly Selector PopDebugGroup = Selector.Register("popDebugGroup");

    public static readonly Selector PushDebugGroup = Selector.Register("pushDebugGroup:");

    public static readonly Selector UpdateFenceAfterEncoderStages = Selector.Register("updateFence:afterEncoderStages:");

    public static readonly Selector WaitForFenceBeforeEncoderStages = Selector.Register("waitForFence:beforeEncoderStages:");
}
