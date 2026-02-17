namespace Metal.NET;

file class MTL4MachineLearningCommandEncoderSelector
{
    public static readonly Selector DispatchNetwork_ = Selector.Register("dispatchNetwork:");
    public static readonly Selector SetArgumentTable_ = Selector.Register("setArgumentTable:");
    public static readonly Selector SetPipelineState_ = Selector.Register("setPipelineState:");
}

public class MTL4MachineLearningCommandEncoder : IDisposable
{
    public MTL4MachineLearningCommandEncoder(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningCommandEncoderSelector.DispatchNetwork_, heap.NativePtr);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningCommandEncoderSelector.SetArgumentTable_, argumentTable.NativePtr);
    }

    public void SetPipelineState(MTL4MachineLearningPipelineState pipelineState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningCommandEncoderSelector.SetPipelineState_, pipelineState.NativePtr);
    }

}
