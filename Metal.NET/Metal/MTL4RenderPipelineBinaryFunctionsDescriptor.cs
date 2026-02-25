namespace Metal.NET;

public class MTL4RenderPipelineBinaryFunctionsDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4RenderPipelineBinaryFunctionsDescriptor>
{
    public static MTL4RenderPipelineBinaryFunctionsDescriptor Create(nint nativePtr) => new(nativePtr, true);

    public static MTL4RenderPipelineBinaryFunctionsDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTL4RenderPipelineBinaryFunctionsDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.Class), true)
    {
    }

    public NSArray FragmentAdditionalBinaryFunctions
    {
        get => GetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.FragmentAdditionalBinaryFunctions);
        set => SetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetFragmentAdditionalBinaryFunctions, value);
    }

    public NSArray MeshAdditionalBinaryFunctions
    {
        get => GetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.MeshAdditionalBinaryFunctions);
        set => SetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetMeshAdditionalBinaryFunctions, value);
    }

    public NSArray ObjectAdditionalBinaryFunctions
    {
        get => GetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.ObjectAdditionalBinaryFunctions);
        set => SetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetObjectAdditionalBinaryFunctions, value);
    }

    public NSArray TileAdditionalBinaryFunctions
    {
        get => GetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.TileAdditionalBinaryFunctions);
        set => SetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetTileAdditionalBinaryFunctions, value);
    }

    public NSArray VertexAdditionalBinaryFunctions
    {
        get => GetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.VertexAdditionalBinaryFunctions);
        set => SetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetVertexAdditionalBinaryFunctions, value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.Reset);
    }
}

file static class MTL4RenderPipelineBinaryFunctionsDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineBinaryFunctionsDescriptor");

    public static readonly Selector FragmentAdditionalBinaryFunctions = "fragmentAdditionalBinaryFunctions";

    public static readonly Selector MeshAdditionalBinaryFunctions = "meshAdditionalBinaryFunctions";

    public static readonly Selector ObjectAdditionalBinaryFunctions = "objectAdditionalBinaryFunctions";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetFragmentAdditionalBinaryFunctions = "setFragmentAdditionalBinaryFunctions:";

    public static readonly Selector SetMeshAdditionalBinaryFunctions = "setMeshAdditionalBinaryFunctions:";

    public static readonly Selector SetObjectAdditionalBinaryFunctions = "setObjectAdditionalBinaryFunctions:";

    public static readonly Selector SetTileAdditionalBinaryFunctions = "setTileAdditionalBinaryFunctions:";

    public static readonly Selector SetVertexAdditionalBinaryFunctions = "setVertexAdditionalBinaryFunctions:";

    public static readonly Selector TileAdditionalBinaryFunctions = "tileAdditionalBinaryFunctions";

    public static readonly Selector VertexAdditionalBinaryFunctions = "vertexAdditionalBinaryFunctions";
}
