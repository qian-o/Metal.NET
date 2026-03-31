namespace Metal.NET;

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

    public NSArray<MTLFunction> VertexAdditionalBinaryFunctions
    {
        get => GetProperty(ref field, MTLRenderPipelineFunctionsDescriptorBindings.VertexAdditionalBinaryFunctions);
        set => SetProperty(ref field, MTLRenderPipelineFunctionsDescriptorBindings.SetVertexAdditionalBinaryFunctions, value);
    }

    public NSArray<MTLFunction> FragmentAdditionalBinaryFunctions
    {
        get => GetProperty(ref field, MTLRenderPipelineFunctionsDescriptorBindings.FragmentAdditionalBinaryFunctions);
        set => SetProperty(ref field, MTLRenderPipelineFunctionsDescriptorBindings.SetFragmentAdditionalBinaryFunctions, value);
    }

    public NSArray<MTLFunction> TileAdditionalBinaryFunctions
    {
        get => GetProperty(ref field, MTLRenderPipelineFunctionsDescriptorBindings.TileAdditionalBinaryFunctions);
        set => SetProperty(ref field, MTLRenderPipelineFunctionsDescriptorBindings.SetTileAdditionalBinaryFunctions, value);
    }
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
