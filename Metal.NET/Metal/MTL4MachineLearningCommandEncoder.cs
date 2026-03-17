namespace Metal.NET;

public class MTL4MachineLearningCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTL4CommandEncoder(nativePtr, ownership), INativeObject<MTL4MachineLearningCommandEncoder>
{
    #region INativeObject
    public static new MTL4MachineLearningCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4MachineLearningCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public void SetPipelineState(MTL4MachineLearningPipelineState pipelineState)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.SetPipelineState, pipelineState.NativePtr);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.SetArgumentTable, argumentTable.NativePtr);
    }

    public void DispatchNetworkWithIntermediatesHeap(MTLHeap heap)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderBindings.DispatchNetworkWithIntermediatesHeap, heap.NativePtr);
    }

    public void DispatchNetwork(MTLHeap heap)
    {
        DispatchNetworkWithIntermediatesHeap(heap);
    }
}

file static class MTL4MachineLearningCommandEncoderBindings
{
    public static readonly Selector DispatchNetworkWithIntermediatesHeap = "dispatchNetworkWithIntermediatesHeap:";

    public static readonly Selector SetArgumentTable = "setArgumentTable:";

    public static readonly Selector SetPipelineState = "setPipelineState:";
}
