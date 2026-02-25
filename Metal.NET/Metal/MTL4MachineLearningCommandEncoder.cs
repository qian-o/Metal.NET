namespace Metal.NET;

public class MTL4MachineLearningCommandEncoder(nint nativePtr, bool ownsReference) : MTL4CommandEncoder(nativePtr, ownsReference), INativeObject<MTL4MachineLearningCommandEncoder>
{
    public static new MTL4MachineLearningCommandEncoder Create(nint nativePtr) => new(nativePtr, true);

    public static new MTL4MachineLearningCommandEncoder CreateBorrowed(nint nativePtr) => new(nativePtr, false);

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
