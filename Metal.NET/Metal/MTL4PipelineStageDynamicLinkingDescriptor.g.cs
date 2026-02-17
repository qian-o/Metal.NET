namespace Metal.NET;

file class MTL4PipelineStageDynamicLinkingDescriptorSelector
{
    public static readonly Selector SetBinaryLinkedFunctions_ = Selector.Register("setBinaryLinkedFunctions:");
    public static readonly Selector SetMaxCallStackDepth_ = Selector.Register("setMaxCallStackDepth:");
    public static readonly Selector SetPreloadedLibraries_ = Selector.Register("setPreloadedLibraries:");
}

public class MTL4PipelineStageDynamicLinkingDescriptor : IDisposable
{
    public MTL4PipelineStageDynamicLinkingDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4PipelineStageDynamicLinkingDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4PipelineStageDynamicLinkingDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4PipelineStageDynamicLinkingDescriptor(nint value)
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

    public void SetBinaryLinkedFunctions(NSArray binaryLinkedFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.SetBinaryLinkedFunctions_, binaryLinkedFunctions.NativePtr);
    }

    public void SetMaxCallStackDepth(nuint maxCallStackDepth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.SetMaxCallStackDepth_, (nint)maxCallStackDepth);
    }

    public void SetPreloadedLibraries(NSArray preloadedLibraries)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.SetPreloadedLibraries_, preloadedLibraries.NativePtr);
    }

}
