namespace Metal.NET;

public class MTL4RenderPipelineDynamicLinkingDescriptor : IDisposable
{
    public MTL4RenderPipelineDynamicLinkingDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4RenderPipelineDynamicLinkingDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4RenderPipelineDynamicLinkingDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4RenderPipelineDynamicLinkingDescriptor(nint value)
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

file class MTL4RenderPipelineDynamicLinkingDescriptorSelector
{
}
