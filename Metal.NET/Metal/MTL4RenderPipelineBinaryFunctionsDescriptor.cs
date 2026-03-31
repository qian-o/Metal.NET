namespace Metal.NET;

public class MTL4RenderPipelineBinaryFunctionsDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4RenderPipelineBinaryFunctionsDescriptor>
{
    #region INativeObject
    public static new MTL4RenderPipelineBinaryFunctionsDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4RenderPipelineBinaryFunctionsDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4RenderPipelineBinaryFunctionsDescriptor() : this(ObjectiveC.AllocInit(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public NSArray<MTL4BinaryFunction> VertexAdditionalBinaryFunctions
    {
        get => GetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.VertexAdditionalBinaryFunctions);
        set => SetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetVertexAdditionalBinaryFunctions, value);
    }

    public NSArray<MTL4BinaryFunction> FragmentAdditionalBinaryFunctions
    {
        get => GetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.FragmentAdditionalBinaryFunctions);
        set => SetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetFragmentAdditionalBinaryFunctions, value);
    }

    public NSArray<MTL4BinaryFunction> TileAdditionalBinaryFunctions
    {
        get => GetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.TileAdditionalBinaryFunctions);
        set => SetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetTileAdditionalBinaryFunctions, value);
    }

    public NSArray<MTL4BinaryFunction> ObjectAdditionalBinaryFunctions
    {
        get => GetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.ObjectAdditionalBinaryFunctions);
        set => SetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetObjectAdditionalBinaryFunctions, value);
    }

    public NSArray<MTL4BinaryFunction> MeshAdditionalBinaryFunctions
    {
        get => GetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.MeshAdditionalBinaryFunctions);
        set => SetProperty(ref field, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetMeshAdditionalBinaryFunctions, value);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.Reset);
    }
}

file static class MTL4RenderPipelineBinaryFunctionsDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4RenderPipelineBinaryFunctionsDescriptor");

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
