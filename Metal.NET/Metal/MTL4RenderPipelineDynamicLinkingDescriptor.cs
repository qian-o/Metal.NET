namespace Metal.NET;

public class MTL4RenderPipelineDynamicLinkingDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4RenderPipelineDynamicLinkingDescriptor>
{
    public static MTL4RenderPipelineDynamicLinkingDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTL4RenderPipelineDynamicLinkingDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4RenderPipelineDynamicLinkingDescriptorBindings.Class), true)
    {
    }

    public MTL4PipelineStageDynamicLinkingDescriptor FragmentLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDynamicLinkingDescriptorBindings.FragmentLinkingDescriptor);
    }

    public MTL4PipelineStageDynamicLinkingDescriptor MeshLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDynamicLinkingDescriptorBindings.MeshLinkingDescriptor);
    }

    public MTL4PipelineStageDynamicLinkingDescriptor ObjectLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDynamicLinkingDescriptorBindings.ObjectLinkingDescriptor);
    }

    public MTL4PipelineStageDynamicLinkingDescriptor TileLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDynamicLinkingDescriptorBindings.TileLinkingDescriptor);
    }

    public MTL4PipelineStageDynamicLinkingDescriptor VertexLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDynamicLinkingDescriptorBindings.VertexLinkingDescriptor);
    }
}

file static class MTL4RenderPipelineDynamicLinkingDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineDynamicLinkingDescriptor");

    public static readonly Selector FragmentLinkingDescriptor = "fragmentLinkingDescriptor";

    public static readonly Selector MeshLinkingDescriptor = "meshLinkingDescriptor";

    public static readonly Selector ObjectLinkingDescriptor = "objectLinkingDescriptor";

    public static readonly Selector TileLinkingDescriptor = "tileLinkingDescriptor";

    public static readonly Selector VertexLinkingDescriptor = "vertexLinkingDescriptor";
}
