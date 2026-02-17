namespace Metal.NET;

file class MTLComputePipelineReflectionSelector
{
}

public class MTLComputePipelineReflection : IDisposable
{
    public MTLComputePipelineReflection(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLComputePipelineReflection()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLComputePipelineReflection value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLComputePipelineReflection(nint value)
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
