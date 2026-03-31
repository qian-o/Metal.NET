namespace Metal.NET;

public class MTLRenderPipelineReflection(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRenderPipelineReflection>
{
    #region INativeObject
    public static new MTLRenderPipelineReflection Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPipelineReflection New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSArray<MTLBinding> VertexBindings
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.VertexBindings);
    }

    public NSArray<MTLBinding> FragmentBindings
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.FragmentBindings);
    }

    public NSArray<MTLBinding> TileBindings
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.TileBindings);
    }

    public NSArray<MTLBinding> ObjectBindings
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.ObjectBindings);
    }

    public NSArray<MTLBinding> MeshBindings
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.MeshBindings);
    }

    /// <summary>
    /// Deprecated: Use vertexBindings instead
    /// </summary>
    [Obsolete("Use vertexBindings instead")]
    public NSArray<MTLArgument> VertexArguments
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.VertexArguments);
    }

    /// <summary>
    /// Deprecated: Use fragmentBindings instead
    /// </summary>
    [Obsolete("Use fragmentBindings instead")]
    public NSArray<MTLArgument> FragmentArguments
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.FragmentArguments);
    }

    /// <summary>
    /// Deprecated: Use tileBindings instead
    /// </summary>
    [Obsolete("Use tileBindings instead")]
    public NSArray<MTLArgument> TileArguments
    {
        get => GetProperty(ref field, MTLRenderPipelineReflectionBindings.TileArguments);
    }
}

file static class MTLRenderPipelineReflectionBindings
{
    public static readonly Selector FragmentArguments = "fragmentArguments";

    public static readonly Selector FragmentBindings = "fragmentBindings";

    public static readonly Selector MeshBindings = "meshBindings";

    public static readonly Selector ObjectBindings = "objectBindings";

    public static readonly Selector TileArguments = "tileArguments";

    public static readonly Selector TileBindings = "tileBindings";

    public static readonly Selector VertexArguments = "vertexArguments";

    public static readonly Selector VertexBindings = "vertexBindings";
}
