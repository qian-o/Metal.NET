namespace Metal.NET;

file class MTL4MachineLearningPipelineStateSelector
{
}

public class MTL4MachineLearningPipelineState : IDisposable
{
    public MTL4MachineLearningPipelineState(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4MachineLearningPipelineState()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4MachineLearningPipelineState value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4MachineLearningPipelineState(nint value)
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

}
