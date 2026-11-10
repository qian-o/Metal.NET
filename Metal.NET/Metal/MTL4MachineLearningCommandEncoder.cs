namespace Metal.NET;

public readonly struct MTL4MachineLearningCommandEncoder(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTL4CommandEncoder(MTL4MachineLearningCommandEncoder value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4MachineLearningCommandEncoder value) => new(value.NativePtr);

    public MTL4MachineLearningCommandEncoder Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4MachineLearningCommandEncoderBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.SetLabel, value.NativePtr);
    }

    public MTL4CommandBuffer CommandBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4MachineLearningCommandEncoderBindings.CommandBuffer));
    }

    public void SetPipelineState(MTL4MachineLearningPipelineState pipelineState)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.SetPipelineState, pipelineState.NativePtr);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.SetArgumentTable, argumentTable.NativePtr);
    }

    public void DispatchNetwork(MTLHeap heap)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.DispatchNetworkWithIntermediatesHeap, heap.NativePtr);
    }

    public void BarrierAfterQueueStages(MTLStages afterQueueStages, MTLStages beforeStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.BarrierAfterQueueStages_BeforeStages_VisibilityOptions, (nuint)afterQueueStages, (nuint)beforeStages, (nuint)visibilityOptions);
    }

    public void BarrierAfterStages(MTLStages afterStages, MTLStages beforeQueueStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.BarrierAfterStages_BeforeQueueStages_VisibilityOptions, (nuint)afterStages, (nuint)beforeQueueStages, (nuint)visibilityOptions);
    }

    public void BarrierAfterEncoderStages(MTLStages afterEncoderStages, MTLStages beforeEncoderStages, MTL4VisibilityOptions visibilityOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.BarrierAfterEncoderStages_BeforeEncoderStages_VisibilityOptions, (nuint)afterEncoderStages, (nuint)beforeEncoderStages, (nuint)visibilityOptions);
    }

    public void UpdateFence(MTLFence fence, MTLStages afterEncoderStages)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.UpdateFence_AfterEncoderStages, fence.NativePtr, (nuint)afterEncoderStages);
    }

    public void WaitForFence(MTLFence fence, MTLStages beforeEncoderStages)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.WaitForFence_BeforeEncoderStages, fence.NativePtr, (nuint)beforeEncoderStages);
    }

    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.InsertDebugSignpost, @string.NativePtr);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.PushDebugGroup, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.PopDebugGroup);
    }

    public void EndEncoding()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.EndEncoding);
    }
}

file static class MTL4MachineLearningCommandEncoderBindings
{
    public static readonly Selector BarrierAfterEncoderStages_BeforeEncoderStages_VisibilityOptions = "barrierAfterEncoderStages:beforeEncoderStages:visibilityOptions:";

    public static readonly Selector BarrierAfterQueueStages_BeforeStages_VisibilityOptions = "barrierAfterQueueStages:beforeStages:visibilityOptions:";

    public static readonly Selector BarrierAfterStages_BeforeQueueStages_VisibilityOptions = "barrierAfterStages:beforeQueueStages:visibilityOptions:";

    public static readonly Selector CommandBuffer = "commandBuffer";

    public static readonly Selector DispatchNetworkWithIntermediatesHeap = "dispatchNetworkWithIntermediatesHeap:";

    public static readonly Selector EndEncoding = "endEncoding";

    public static readonly Selector InsertDebugSignpost = "insertDebugSignpost:";

    public static readonly Selector Label = "label";

    public static readonly Selector PopDebugGroup = "popDebugGroup";

    public static readonly Selector PushDebugGroup = "pushDebugGroup:";

    public static readonly Selector SetArgumentTable = "setArgumentTable:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetPipelineState = "setPipelineState:";

    public static readonly Selector UpdateFence_AfterEncoderStages = "updateFence:afterEncoderStages:";

    public static readonly Selector WaitForFence_BeforeEncoderStages = "waitForFence:beforeEncoderStages:";
}
