namespace Metal.NET;

public partial class MTL4RenderPipelineDynamicLinkingDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineDynamicLinkingDescriptor");

    public MTL4RenderPipelineDynamicLinkingDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? FragmentLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorSelector.FragmentLinkingDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? MeshLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorSelector.MeshLinkingDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? ObjectLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorSelector.ObjectLinkingDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? TileLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorSelector.TileLinkingDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? VertexLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorSelector.VertexLinkingDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTL4RenderPipelineDynamicLinkingDescriptorSelector
{
    public static readonly Selector FragmentLinkingDescriptor = Selector.Register("fragmentLinkingDescriptor");

    public static readonly Selector MeshLinkingDescriptor = Selector.Register("meshLinkingDescriptor");

    public static readonly Selector ObjectLinkingDescriptor = Selector.Register("objectLinkingDescriptor");

    public static readonly Selector TileLinkingDescriptor = Selector.Register("tileLinkingDescriptor");

    public static readonly Selector VertexLinkingDescriptor = Selector.Register("vertexLinkingDescriptor");
}
