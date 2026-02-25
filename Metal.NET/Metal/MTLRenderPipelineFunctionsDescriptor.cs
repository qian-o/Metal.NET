namespace Metal.NET;

public class MTLRenderPipelineFunctionsDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLRenderPipelineFunctionsDescriptor>
{
    public static MTLRenderPipelineFunctionsDescriptor Create(nint nativePtr) => new(nativePtr, true);

    public static MTLRenderPipelineFunctionsDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLRenderPipelineFunctionsDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineFunctionsDescriptorBindings.Class), true)
    {
    }

    public NSArray FragmentAdditionalBinaryFunctions
    {
        get => GetProperty(ref field, MTLRenderPipelineFunctionsDescriptorBindings.FragmentAdditionalBinaryFunctions);
        set => SetProperty(ref field, MTLRenderPipelineFunctionsDescriptorBindings.SetFragmentAdditionalBinaryFunctions, value);
    }

    public NSArray TileAdditionalBinaryFunctions
    {
        get => GetProperty(ref field, MTLRenderPipelineFunctionsDescriptorBindings.TileAdditionalBinaryFunctions);
        set => SetProperty(ref field, MTLRenderPipelineFunctionsDescriptorBindings.SetTileAdditionalBinaryFunctions, value);
    }

    public NSArray VertexAdditionalBinaryFunctions
    {
        get => GetProperty(ref field, MTLRenderPipelineFunctionsDescriptorBindings.VertexAdditionalBinaryFunctions);
        set => SetProperty(ref field, MTLRenderPipelineFunctionsDescriptorBindings.SetVertexAdditionalBinaryFunctions, value);
    }
}

file static class MTLRenderPipelineFunctionsDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPipelineFunctionsDescriptor");

    public static readonly Selector FragmentAdditionalBinaryFunctions = "fragmentAdditionalBinaryFunctions";

    public static readonly Selector SetFragmentAdditionalBinaryFunctions = "setFragmentAdditionalBinaryFunctions:";

    public static readonly Selector SetTileAdditionalBinaryFunctions = "setTileAdditionalBinaryFunctions:";

    public static readonly Selector SetVertexAdditionalBinaryFunctions = "setVertexAdditionalBinaryFunctions:";

    public static readonly Selector TileAdditionalBinaryFunctions = "tileAdditionalBinaryFunctions";

    public static readonly Selector VertexAdditionalBinaryFunctions = "vertexAdditionalBinaryFunctions";
}
