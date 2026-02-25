namespace Metal.NET;

public class MTL4MachineLearningCommandEncoder(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : MTL4CommandEncoder(nativePtr, ownsReference, allowGCRelease), INativeObject<MTL4MachineLearningCommandEncoder>
{
    public static new MTL4MachineLearningCommandEncoder Null { get; } = new(0, false);

    public static new MTL4MachineLearningCommandEncoder Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public void DispatchNetwork(MTLHeap heap)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.DispatchNetwork, heap.NativePtr);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.SetArgumentTable, argumentTable.NativePtr);
    }

    public void SetPipelineState(MTL4MachineLearningPipelineState pipelineState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.SetPipelineState, pipelineState.NativePtr);
    }
}

file static class MTL4MachineLearningCommandEncoderBindings
{
    public static readonly Selector DispatchNetwork = "dispatchNetworkWithIntermediatesHeap:";

    public static readonly Selector SetArgumentTable = "setArgumentTable:";

    public static readonly Selector SetPipelineState = "setPipelineState:";
}
