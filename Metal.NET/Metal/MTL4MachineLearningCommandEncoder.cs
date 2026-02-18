namespace Metal.NET;

public partial class MTL4MachineLearningCommandEncoder : NativeObject
{
    public MTL4MachineLearningCommandEncoder(nint nativePtr) : base(nativePtr)
    {
    }

    public void DispatchNetwork(MTLHeap heap)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningCommandEncoderSelector.DispatchNetwork, heap.NativePtr);
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

file static class MTL4MachineLearningCommandEncoderSelector
{
    public static readonly Selector DispatchNetwork = Selector.Register("dispatchNetwork:");

    public static readonly Selector SetArgumentTable = Selector.Register("setArgumentTable:");

    public static readonly Selector SetPipelineState = Selector.Register("setPipelineState:");
}
