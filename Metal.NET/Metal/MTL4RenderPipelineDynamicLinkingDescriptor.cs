namespace Metal.NET;

public readonly struct MTL4RenderPipelineDynamicLinkingDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4RenderPipelineDynamicLinkingDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4RenderPipelineDynamicLinkingDescriptorBindings.Class))
    {
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? FragmentLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorBindings.FragmentLinkingDescriptor);
            return ptr is not 0 ? new MTL4PipelineStageDynamicLinkingDescriptor(ptr) : default;
        }
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? MeshLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorBindings.MeshLinkingDescriptor);
            return ptr is not 0 ? new MTL4PipelineStageDynamicLinkingDescriptor(ptr) : default;
        }
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? ObjectLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorBindings.ObjectLinkingDescriptor);
            return ptr is not 0 ? new MTL4PipelineStageDynamicLinkingDescriptor(ptr) : default;
        }
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? TileLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorBindings.TileLinkingDescriptor);
            return ptr is not 0 ? new MTL4PipelineStageDynamicLinkingDescriptor(ptr) : default;
        }
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? VertexLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorBindings.VertexLinkingDescriptor);
            return ptr is not 0 ? new MTL4PipelineStageDynamicLinkingDescriptor(ptr) : default;
        }
    }
}

file static class MTL4RenderPipelineDynamicLinkingDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineDynamicLinkingDescriptor");

    public static readonly Selector FragmentLinkingDescriptor = Selector.Register("fragmentLinkingDescriptor");

    public static readonly Selector MeshLinkingDescriptor = Selector.Register("meshLinkingDescriptor");

    public static readonly Selector ObjectLinkingDescriptor = Selector.Register("objectLinkingDescriptor");

    public static readonly Selector TileLinkingDescriptor = Selector.Register("tileLinkingDescriptor");

    public static readonly Selector VertexLinkingDescriptor = Selector.Register("vertexLinkingDescriptor");
}
