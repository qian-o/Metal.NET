namespace Metal.NET;

file class MTL4MachineLearningPipelineReflectionSelector
{
}

public class MTL4MachineLearningPipelineReflection : IDisposable
{
    public MTL4MachineLearningPipelineReflection(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4MachineLearningPipelineReflection()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4MachineLearningPipelineReflection value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4MachineLearningPipelineReflection(nint value)
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
