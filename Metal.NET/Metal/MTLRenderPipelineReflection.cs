namespace Metal.NET;

/// <summary>
/// Information about the arguments of a graphics function.
/// </summary>
public class MTLRenderPipelineReflection(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRenderPipelineReflection>
{
    #region INativeObject
    public static new MTLRenderPipelineReflection Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPipelineReflection New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLRenderPipelineReflection() : this(ObjectiveC.AllocInit(MTLRenderPipelineReflectionBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Inspecting a shader’s parameter - Properties

    /// <summary>
    /// An array of binding instances, each of which represents a parameter of the pipeline state’s fragment shader.
    /// </summary>
    public MTLBinding[] FragmentBindings
    {
        get => GetArrayProperty<MTLBinding>(MTLRenderPipelineReflectionBindings.FragmentBindings);
    }

    /// <summary>
    /// An array of binding instances, each of which represents a parameter of the pipeline state’s mesh shader.
    /// </summary>
    public MTLBinding[] MeshBindings
    {
        get => GetArrayProperty<MTLBinding>(MTLRenderPipelineReflectionBindings.MeshBindings);
    }

    /// <summary>
    /// An array of binding instances, each of which represents a parameter of the pipeline state’s object shader.
    /// </summary>
    public MTLBinding[] ObjectBindings
    {
        get => GetArrayProperty<MTLBinding>(MTLRenderPipelineReflectionBindings.ObjectBindings);
    }

    /// <summary>
    /// An array of binding instances, each of which represents a parameter of the pipeline state’s tile shader.
    /// </summary>
    public MTLBinding[] TileBindings
    {
        get => GetArrayProperty<MTLBinding>(MTLRenderPipelineReflectionBindings.TileBindings);
    }

    /// <summary>
    /// An array of binding instances, each of which represents a parameter of the pipeline state’s vertex shader.
    /// </summary>
    public MTLBinding[] VertexBindings
    {
        get => GetArrayProperty<MTLBinding>(MTLRenderPipelineReflectionBindings.VertexBindings);
    }
    #endregion

    #region Deprecated - Properties

    /// <summary>
    /// An array of argument instances, each of which represent a parameter of the pipeline state’s vertex shader.
    /// </summary>
    [Obsolete("Use vertexBindings instead.")]
    public MTLArgument[] VertexArguments
    {
        get => GetArrayProperty<MTLArgument>(MTLRenderPipelineReflectionBindings.VertexArguments);
    }

    /// <summary>
    /// An array of argument instances, each of which represent a parameter of the pipeline state’s fragment shader.
    /// </summary>
    [Obsolete("Use fragmentBindings instead.")]
    public MTLArgument[] FragmentArguments
    {
        get => GetArrayProperty<MTLArgument>(MTLRenderPipelineReflectionBindings.FragmentArguments);
    }

    /// <summary>
    /// An array of argument instances, each of which represent a parameter of the pipeline state’s tile shader.
    /// </summary>
    [Obsolete("Use tileBindings instead.")]
    public MTLArgument[] TileArguments
    {
        get => GetArrayProperty<MTLArgument>(MTLRenderPipelineReflectionBindings.TileArguments);
    }
    #endregion
}

file static class MTLRenderPipelineReflectionBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPipelineReflection");

    public static readonly Selector FragmentArguments = "fragmentArguments";

    public static readonly Selector FragmentBindings = "fragmentBindings";

    public static readonly Selector MeshBindings = "meshBindings";

    public static readonly Selector ObjectBindings = "objectBindings";

    public static readonly Selector TileArguments = "tileArguments";

    public static readonly Selector TileBindings = "tileBindings";

    public static readonly Selector VertexArguments = "vertexArguments";

    public static readonly Selector VertexBindings = "vertexBindings";
}
