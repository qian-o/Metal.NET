namespace Metal.NET;

public class MTL4MachineLearningCommandEncoder(nint nativePtr) : MTL4CommandEncoder(nativePtr)
{
    public static implicit operator nint(MTL4MachineLearningCommandEncoder value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4MachineLearningCommandEncoder(nint value)
    {
        return new(value);
    }

    public void DispatchNetwork(MTLHeap heap)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderSelector.DispatchNetworkWithIntermediatesHeap, heap.NativePtr);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderSelector.SetArgumentTable, argumentTable.NativePtr);
    }

    public void SetPipelineState(MTL4MachineLearningPipelineState pipelineState)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderSelector.SetPipelineState, pipelineState.NativePtr);
    }
}

file class MTL4MachineLearningCommandEncoderSelector
{
    public static readonly Selector DispatchNetworkWithIntermediatesHeap = Selector.Register("dispatchNetworkWithIntermediatesHeap:");

    public static readonly Selector SetArgumentTable = Selector.Register("setArgumentTable:");

    public static readonly Selector SetPipelineState = Selector.Register("setPipelineState:");
}
