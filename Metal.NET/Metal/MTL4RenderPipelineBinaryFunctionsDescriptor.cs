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

    public MTL4BinaryFunction[] VertexAdditionalBinaryFunctions
    {
        get => GetArrayProperty<MTL4BinaryFunction>(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.VertexAdditionalBinaryFunctions);
        set => SetArrayProperty(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetVertexAdditionalBinaryFunctions, value);
    }

    public MTL4BinaryFunction[] FragmentAdditionalBinaryFunctions
    {
        get => GetArrayProperty<MTL4BinaryFunction>(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.FragmentAdditionalBinaryFunctions);
        set => SetArrayProperty(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetFragmentAdditionalBinaryFunctions, value);
    }

    public MTL4BinaryFunction[] TileAdditionalBinaryFunctions
    {
        get => GetArrayProperty<MTL4BinaryFunction>(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.TileAdditionalBinaryFunctions);
        set => SetArrayProperty(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetTileAdditionalBinaryFunctions, value);
    }

    public MTL4BinaryFunction[] ObjectAdditionalBinaryFunctions
    {
        get => GetArrayProperty<MTL4BinaryFunction>(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.ObjectAdditionalBinaryFunctions);
        set => SetArrayProperty(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetObjectAdditionalBinaryFunctions, value);
    }

    public MTL4BinaryFunction[] MeshAdditionalBinaryFunctions
    {
        get => GetArrayProperty<MTL4BinaryFunction>(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.MeshAdditionalBinaryFunctions);
        set => SetArrayProperty(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetMeshAdditionalBinaryFunctions, value);
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
