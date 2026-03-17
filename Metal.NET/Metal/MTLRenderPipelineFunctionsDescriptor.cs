namespace Metal.NET;

/// <summary>
/// A collection of functions for updating a render pipeline.
/// </summary>
public class MTLRenderPipelineFunctionsDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRenderPipelineFunctionsDescriptor>
{
    #region INativeObject
    public static new MTLRenderPipelineFunctionsDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPipelineFunctionsDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLRenderPipelineFunctionsDescriptor() : this(ObjectiveC.AllocInit(MTLRenderPipelineFunctionsDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Configuring the descriptor’s functions - Properties

    /// <summary>
    /// The vertex functions to add to the render pipeline.
    /// </summary>
    public MTLFunction[] VertexAdditionalBinaryFunctions
    {
        get => GetArrayProperty<MTLFunction>(MTLRenderPipelineFunctionsDescriptorBindings.VertexAdditionalBinaryFunctions);
        set => SetArrayProperty(MTLRenderPipelineFunctionsDescriptorBindings.SetVertexAdditionalBinaryFunctions, value);
    }

    /// <summary>
    /// The fragment functions to add to the render pipeline.
    /// </summary>
    public MTLFunction[] FragmentAdditionalBinaryFunctions
    {
        get => GetArrayProperty<MTLFunction>(MTLRenderPipelineFunctionsDescriptorBindings.FragmentAdditionalBinaryFunctions);
        set => SetArrayProperty(MTLRenderPipelineFunctionsDescriptorBindings.SetFragmentAdditionalBinaryFunctions, value);
    }

    /// <summary>
    /// The tile functions to add to the render pipeline.
    /// </summary>
    public MTLFunction[] TileAdditionalBinaryFunctions
    {
        get => GetArrayProperty<MTLFunction>(MTLRenderPipelineFunctionsDescriptorBindings.TileAdditionalBinaryFunctions);
        set => SetArrayProperty(MTLRenderPipelineFunctionsDescriptorBindings.SetTileAdditionalBinaryFunctions, value);
    }
    #endregion
}

file static class MTLRenderPipelineFunctionsDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPipelineFunctionsDescriptor");

    public static readonly Selector FragmentAdditionalBinaryFunctions = "fragmentAdditionalBinaryFunctions";

    public static readonly Selector SetFragmentAdditionalBinaryFunctions = "setFragmentAdditionalBinaryFunctions:";

    public static readonly Selector SetTileAdditionalBinaryFunctions = "setTileAdditionalBinaryFunctions:";

    public static readonly Selector SetVertexAdditionalBinaryFunctions = "setVertexAdditionalBinaryFunctions:";

    public static readonly Selector TileAdditionalBinaryFunctions = "tileAdditionalBinaryFunctions";

    public static readonly Selector VertexAdditionalBinaryFunctions = "vertexAdditionalBinaryFunctions";
}
