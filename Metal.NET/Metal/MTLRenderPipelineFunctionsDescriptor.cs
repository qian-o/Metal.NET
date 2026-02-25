namespace Metal.NET;

public class MTLRenderPipelineFunctionsDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLRenderPipelineFunctionsDescriptor>
{
    public static MTLRenderPipelineFunctionsDescriptor Null => Create(0, false);
    public static MTLRenderPipelineFunctionsDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLRenderPipelineFunctionsDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineFunctionsDescriptorBindings.Class), true)
    {
    }

    public MTLFunction[] FragmentAdditionalBinaryFunctions
    {
        get => GetArrayProperty<MTLFunction>(MTLRenderPipelineFunctionsDescriptorBindings.FragmentAdditionalBinaryFunctions);
        set => SetArrayProperty(MTLRenderPipelineFunctionsDescriptorBindings.SetFragmentAdditionalBinaryFunctions, value);
    }

    public MTLFunction[] TileAdditionalBinaryFunctions
    {
        get => GetArrayProperty<MTLFunction>(MTLRenderPipelineFunctionsDescriptorBindings.TileAdditionalBinaryFunctions);
        set => SetArrayProperty(MTLRenderPipelineFunctionsDescriptorBindings.SetTileAdditionalBinaryFunctions, value);
    }

    public MTLFunction[] VertexAdditionalBinaryFunctions
    {
        get => GetArrayProperty<MTLFunction>(MTLRenderPipelineFunctionsDescriptorBindings.VertexAdditionalBinaryFunctions);
        set => SetArrayProperty(MTLRenderPipelineFunctionsDescriptorBindings.SetVertexAdditionalBinaryFunctions, value);
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
