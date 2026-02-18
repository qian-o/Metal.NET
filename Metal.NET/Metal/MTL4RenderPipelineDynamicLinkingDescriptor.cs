namespace Metal.NET;

public class MTL4RenderPipelineDynamicLinkingDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4RenderPipelineDynamicLinkingDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4RenderPipelineDynamicLinkingDescriptorSelector.Class))
    {
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? FragmentLinkingDescriptor
    {
        get => GetNullableObject<MTL4PipelineStageDynamicLinkingDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorSelector.FragmentLinkingDescriptor));
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? MeshLinkingDescriptor
    {
        get => GetNullableObject<MTL4PipelineStageDynamicLinkingDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorSelector.MeshLinkingDescriptor));
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? ObjectLinkingDescriptor
    {
        get => GetNullableObject<MTL4PipelineStageDynamicLinkingDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorSelector.ObjectLinkingDescriptor));
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? TileLinkingDescriptor
    {
        get => GetNullableObject<MTL4PipelineStageDynamicLinkingDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorSelector.TileLinkingDescriptor));
    }

    public MTL4PipelineStageDynamicLinkingDescriptor? VertexLinkingDescriptor
    {
        get => GetNullableObject<MTL4PipelineStageDynamicLinkingDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorSelector.VertexLinkingDescriptor));
    }
}

file static class MTL4RenderPipelineDynamicLinkingDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineDynamicLinkingDescriptor");

    public static readonly Selector FragmentLinkingDescriptor = Selector.Register("fragmentLinkingDescriptor");

    public static readonly Selector MeshLinkingDescriptor = Selector.Register("meshLinkingDescriptor");

    public static readonly Selector ObjectLinkingDescriptor = Selector.Register("objectLinkingDescriptor");

    public static readonly Selector TileLinkingDescriptor = Selector.Register("tileLinkingDescriptor");

    public static readonly Selector VertexLinkingDescriptor = Selector.Register("vertexLinkingDescriptor");
}
