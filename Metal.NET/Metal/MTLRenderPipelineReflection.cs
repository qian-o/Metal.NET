namespace Metal.NET;

public class MTLRenderPipelineReflection : IDisposable
{
    public MTLRenderPipelineReflection(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLRenderPipelineReflection()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRenderPipelineReflection value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPipelineReflection(nint value)
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

file class MTLRenderPipelineReflectionSelector
{
}
