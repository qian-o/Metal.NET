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

    public NSArray BinaryLinkedFunctions
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.BinaryLinkedFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.SetBinaryLinkedFunctions, value.NativePtr);
    }

    public nuint MaxCallStackDepth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.MaxCallStackDepth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.SetMaxCallStackDepth, value);
    }

    public NSArray PreloadedLibraries
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.PreloadedLibraries));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineStageDynamicLinkingDescriptorSelector.SetPreloadedLibraries, value.NativePtr);
    }

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
}

file class MTL4PipelineStageDynamicLinkingDescriptorSelector
{
    public static readonly Selector BinaryLinkedFunctions = Selector.Register("binaryLinkedFunctions");

    public static readonly Selector SetBinaryLinkedFunctions = Selector.Register("setBinaryLinkedFunctions:");

    public static readonly Selector MaxCallStackDepth = Selector.Register("maxCallStackDepth");

    public static readonly Selector SetMaxCallStackDepth = Selector.Register("setMaxCallStackDepth:");

    public static readonly Selector PreloadedLibraries = Selector.Register("preloadedLibraries");

    public static readonly Selector SetPreloadedLibraries = Selector.Register("setPreloadedLibraries:");
}
