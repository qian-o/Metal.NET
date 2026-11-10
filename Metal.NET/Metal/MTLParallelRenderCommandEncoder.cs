namespace Metal.NET;

public readonly struct MTLParallelRenderCommandEncoder(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLCommandEncoder(MTLParallelRenderCommandEncoder value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLParallelRenderCommandEncoder value) => new(value.NativePtr);

    public MTLParallelRenderCommandEncoder Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLParallelRenderCommandEncoderBindings.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLParallelRenderCommandEncoderBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetLabel, value.NativePtr);
    }

    public MTLRenderCommandEncoder MakeRenderCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLParallelRenderCommandEncoderBindings.RenderCommandEncoder);

        return new(nativePtr);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetColorStoreAction_AtIndex, (nuint)storeAction, colorAttachmentIndex);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetDepthStoreAction, (nuint)storeAction);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetStencilStoreAction, (nuint)storeAction);
    }

    /// <summary>
    /// Deprecated: Store action options have no effect on Apple Silicon
    /// </summary>
    [Obsolete("Store action options have no effect on Apple Silicon")]
    public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, nuint colorAttachmentIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetColorStoreActionOptions_AtIndex, (nuint)storeActionOptions, colorAttachmentIndex);
    }

    /// <summary>
    /// Deprecated: Store action options have no effect on Apple Silicon
    /// </summary>
    [Obsolete("Store action options have no effect on Apple Silicon")]
    public void SetDepthStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetDepthStoreActionOptions, (nuint)storeActionOptions);
    }

    /// <summary>
    /// Deprecated: Store action options have no effect on Apple Silicon
    /// </summary>
    [Obsolete("Store action options have no effect on Apple Silicon")]
    public void SetStencilStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetStencilStoreActionOptions, (nuint)storeActionOptions);
    }

    public void EndEncoding()
    {
        ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.EndEncoding);
    }

    public void Barrier(MTLStages afterQueueStages, MTLStages beforeStages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.BarrierAfterQueueStages_BeforeStages, (nuint)afterQueueStages, (nuint)beforeStages);
    }

    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.InsertDebugSignpost, @string.NativePtr);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.PushDebugGroup, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.PopDebugGroup);
    }
}

file static class MTLParallelRenderCommandEncoderBindings
{
    public static readonly Selector BarrierAfterQueueStages_BeforeStages = "barrierAfterQueueStages:beforeStages:";

    public static readonly Selector Device = "device";

    public static readonly Selector EndEncoding = "endEncoding";

    public static readonly Selector InsertDebugSignpost = "insertDebugSignpost:";

    public static readonly Selector Label = "label";

    public static readonly Selector PopDebugGroup = "popDebugGroup";

    public static readonly Selector PushDebugGroup = "pushDebugGroup:";

    public static readonly Selector RenderCommandEncoder = "renderCommandEncoder";

    public static readonly Selector SetColorStoreAction_AtIndex = "setColorStoreAction:atIndex:";

    public static readonly Selector SetColorStoreActionOptions_AtIndex = "setColorStoreActionOptions:atIndex:";

    public static readonly Selector SetDepthStoreAction = "setDepthStoreAction:";

    public static readonly Selector SetDepthStoreActionOptions = "setDepthStoreActionOptions:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetStencilStoreAction = "setStencilStoreAction:";

    public static readonly Selector SetStencilStoreActionOptions = "setStencilStoreActionOptions:";
}
