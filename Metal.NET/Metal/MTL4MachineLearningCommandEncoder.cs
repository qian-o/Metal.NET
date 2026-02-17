namespace Metal.NET;

public class MTL4MachineLearningCommandEncoder : IDisposable
{
    public MTL4MachineLearningCommandEncoder(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4MachineLearningCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4MachineLearningCommandEncoder value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4MachineLearningCommandEncoder(nint value)
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

file class MTL4MachineLearningCommandEncoderSelector
{
    public static readonly Selector DispatchNetwork = Selector.Register("dispatchNetwork:");

    public static readonly Selector SetArgumentTable = Selector.Register("setArgumentTable:");

    public static readonly Selector SetPipelineState = Selector.Register("setPipelineState:");
}
