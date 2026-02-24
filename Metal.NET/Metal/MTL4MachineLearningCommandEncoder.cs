namespace Metal.NET;

public class MTL4MachineLearningCommandEncoder(nint nativePtr) : MTL4CommandEncoder(nativePtr), INativeObject<MTL4MachineLearningCommandEncoder>
{
    public static MTL4MachineLearningCommandEncoder Create(nint nativePtr) => new(nativePtr);

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
