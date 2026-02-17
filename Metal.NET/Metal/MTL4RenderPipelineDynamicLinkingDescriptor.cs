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

    public MTL4PipelineStageDynamicLinkingDescriptor FragmentLinkingDescriptor
    {
        get => new MTL4PipelineStageDynamicLinkingDescriptor(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorSelector.FragmentLinkingDescriptor));
    }

    public MTL4PipelineStageDynamicLinkingDescriptor MeshLinkingDescriptor
    {
        get => new MTL4PipelineStageDynamicLinkingDescriptor(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorSelector.MeshLinkingDescriptor));
    }

    public MTL4PipelineStageDynamicLinkingDescriptor ObjectLinkingDescriptor
    {
        get => new MTL4PipelineStageDynamicLinkingDescriptor(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorSelector.ObjectLinkingDescriptor));
    }

    public MTL4PipelineStageDynamicLinkingDescriptor TileLinkingDescriptor
    {
        get => new MTL4PipelineStageDynamicLinkingDescriptor(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorSelector.TileLinkingDescriptor));
    }

    public MTL4PipelineStageDynamicLinkingDescriptor VertexLinkingDescriptor
    {
        get => new MTL4PipelineStageDynamicLinkingDescriptor(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorSelector.VertexLinkingDescriptor));
    }

}

file class MTL4RenderPipelineDynamicLinkingDescriptorSelector
{
    public static readonly Selector FragmentLinkingDescriptor = Selector.Register("fragmentLinkingDescriptor");

    public static readonly Selector MeshLinkingDescriptor = Selector.Register("meshLinkingDescriptor");

    public static readonly Selector ObjectLinkingDescriptor = Selector.Register("objectLinkingDescriptor");

    public static readonly Selector TileLinkingDescriptor = Selector.Register("tileLinkingDescriptor");

    public static readonly Selector VertexLinkingDescriptor = Selector.Register("vertexLinkingDescriptor");
}
