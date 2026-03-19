namespace Metal.NET;

public partial class MTLRenderPipelineReflection(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRenderPipelineReflection>
{
    #region INativeObject
    public static new MTLRenderPipelineReflection Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPipelineReflection New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLBinding[] VertexBindings
    {
        get => GetArrayProperty<MTLBinding>(MTLRenderPipelineReflectionBindings.VertexBindings);
    }

    public MTLBinding[] FragmentBindings
    {
        get => GetArrayProperty<MTLBinding>(MTLRenderPipelineReflectionBindings.FragmentBindings);
    }

    public MTLBinding[] TileBindings
    {
        get => GetArrayProperty<MTLBinding>(MTLRenderPipelineReflectionBindings.TileBindings);
    }

    public MTLBinding[] ObjectBindings
    {
        get => GetArrayProperty<MTLBinding>(MTLRenderPipelineReflectionBindings.ObjectBindings);
    }

    public MTLBinding[] MeshBindings
    {
        get => GetArrayProperty<MTLBinding>(MTLRenderPipelineReflectionBindings.MeshBindings);
    }

    /// <summary>
    /// Deprecated: Use vertexBindings instead
    /// </summary>
    [Obsolete("Use vertexBindings instead")]
    public MTLArgument[] VertexArguments
    {
        get => GetArrayProperty<MTLArgument>(MTLRenderPipelineReflectionBindings.VertexArguments);
    }

    /// <summary>
    /// Deprecated: Use fragmentBindings instead
    /// </summary>
    [Obsolete("Use fragmentBindings instead")]
    public MTLArgument[] FragmentArguments
    {
        get => GetArrayProperty<MTLArgument>(MTLRenderPipelineReflectionBindings.FragmentArguments);
    }

    /// <summary>
    /// Deprecated: Use tileBindings instead
    /// </summary>
    [Obsolete("Use tileBindings instead")]
    public MTLArgument[] TileArguments
    {
        get => GetArrayProperty<MTLArgument>(MTLRenderPipelineReflectionBindings.TileArguments);
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
