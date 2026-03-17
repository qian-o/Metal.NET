namespace Metal.NET;

/// <summary>
/// Groups together properties that provide linking properties for render pipelines.
/// </summary>
public class MTL4RenderPipelineDynamicLinkingDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4RenderPipelineDynamicLinkingDescriptor>
{
    #region INativeObject
    public static new MTL4RenderPipelineDynamicLinkingDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4RenderPipelineDynamicLinkingDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4RenderPipelineDynamicLinkingDescriptor() : this(ObjectiveC.AllocInit(MTL4RenderPipelineDynamicLinkingDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// Controls properties for linking the fragment stage of the render pipeline.
    /// </summary>
    public MTL4PipelineStageDynamicLinkingDescriptor FragmentLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDynamicLinkingDescriptorBindings.FragmentLinkingDescriptor);
    }

    /// <summary>
    /// Controls properties for linking the mesh stage of the render pipeline.
    /// </summary>
    public MTL4PipelineStageDynamicLinkingDescriptor MeshLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDynamicLinkingDescriptorBindings.MeshLinkingDescriptor);
    }

    /// <summary>
    /// Controls properties for link the object stage of the render pipeline.
    /// </summary>
    public MTL4PipelineStageDynamicLinkingDescriptor ObjectLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDynamicLinkingDescriptorBindings.ObjectLinkingDescriptor);
    }

    /// <summary>
    /// Controls properties for linking the tile stage of the render pipeline.
    /// </summary>
    public MTL4PipelineStageDynamicLinkingDescriptor TileLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDynamicLinkingDescriptorBindings.TileLinkingDescriptor);
    }

    /// <summary>
    /// Controls properties for linking the vertex stage of the render pipeline.
    /// </summary>
    public MTL4PipelineStageDynamicLinkingDescriptor VertexLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4RenderPipelineDynamicLinkingDescriptorBindings.VertexLinkingDescriptor);
    }
    #endregion
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
