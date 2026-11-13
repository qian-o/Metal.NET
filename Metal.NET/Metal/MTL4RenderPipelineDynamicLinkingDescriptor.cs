namespace Metal.NET;

public readonly struct MTL4RenderPipelineDynamicLinkingDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4RenderPipelineDynamicLinkingDescriptor value) => new(value.NativePtr);

    public MTL4RenderPipelineDynamicLinkingDescriptor() : this(ObjectiveC.AllocInit(MTL4RenderPipelineDynamicLinkingDescriptorBindings.Class))
    {
    }

    public MTL4RenderPipelineDynamicLinkingDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTL4PipelineStageDynamicLinkingDescriptor VertexLinkingDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorBindings.VertexLinkingDescriptor));
    }

    public MTL4PipelineStageDynamicLinkingDescriptor FragmentLinkingDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorBindings.FragmentLinkingDescriptor));
    }

    public MTL4PipelineStageDynamicLinkingDescriptor TileLinkingDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorBindings.TileLinkingDescriptor));
    }

    public MTL4PipelineStageDynamicLinkingDescriptor ObjectLinkingDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorBindings.ObjectLinkingDescriptor));
    }

    public MTL4PipelineStageDynamicLinkingDescriptor MeshLinkingDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineDynamicLinkingDescriptorBindings.MeshLinkingDescriptor));
    }
}

file static class MTL4RenderPipelineDynamicLinkingDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4RenderPipelineDynamicLinkingDescriptor");

    public static readonly Selector FragmentLinkingDescriptor = "fragmentLinkingDescriptor";

    public static readonly Selector MeshLinkingDescriptor = "meshLinkingDescriptor";

    public static readonly Selector ObjectLinkingDescriptor = "objectLinkingDescriptor";

    public static readonly Selector TileLinkingDescriptor = "tileLinkingDescriptor";

    public static readonly Selector VertexLinkingDescriptor = "vertexLinkingDescriptor";
}
