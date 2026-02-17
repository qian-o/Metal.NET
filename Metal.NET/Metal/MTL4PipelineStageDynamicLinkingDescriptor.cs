namespace Metal.NET;

public class MTL4PipelineStageDynamicLinkingDescriptor : IDisposable
{
    public MTL4PipelineStageDynamicLinkingDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.SetBinaryLinkedFunctions, binaryLinkedFunctions.NativePtr);
    }

    public void SetMaxCallStackDepth(uint maxCallStackDepth)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.SetMaxCallStackDepth, (nint)maxCallStackDepth);
    }

    public void SetPreloadedLibraries(NSArray preloadedLibraries)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.SetPreloadedLibraries, preloadedLibraries.NativePtr);
    }

}

file class MTL4PipelineStageDynamicLinkingDescriptorSelector
{
    public static readonly Selector SetBinaryLinkedFunctions = Selector.Register("setBinaryLinkedFunctions:");

    public static readonly Selector SetMaxCallStackDepth = Selector.Register("setMaxCallStackDepth:");

    public static readonly Selector SetPreloadedLibraries = Selector.Register("setPreloadedLibraries:");
}
