namespace Metal.NET;

public class MTL4RenderPipelineBinaryFunctionsDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4RenderPipelineBinaryFunctionsDescriptor>
{
    public static MTL4RenderPipelineBinaryFunctionsDescriptor Null { get; } = new(0, false);

    public static MTL4RenderPipelineBinaryFunctionsDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTL4RenderPipelineBinaryFunctionsDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.Class), true)
    {
        IsFullyManaged = true;
    }

    public MTLFunction[] FragmentAdditionalBinaryFunctions
    {
        get => GetArrayProperty<MTLFunction>(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.FragmentAdditionalBinaryFunctions);
        set => SetArrayProperty(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetFragmentAdditionalBinaryFunctions, value);
    }

    public MTLFunction[] MeshAdditionalBinaryFunctions
    {
        get => GetArrayProperty<MTLFunction>(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.MeshAdditionalBinaryFunctions);
        set => SetArrayProperty(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetMeshAdditionalBinaryFunctions, value);
    }

    public MTLFunction[] ObjectAdditionalBinaryFunctions
    {
        get => GetArrayProperty<MTLFunction>(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.ObjectAdditionalBinaryFunctions);
        set => SetArrayProperty(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetObjectAdditionalBinaryFunctions, value);
    }

    public MTLFunction[] TileAdditionalBinaryFunctions
    {
        get => GetArrayProperty<MTLFunction>(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.TileAdditionalBinaryFunctions);
        set => SetArrayProperty(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetTileAdditionalBinaryFunctions, value);
    }

    public MTLFunction[] VertexAdditionalBinaryFunctions
    {
        get => GetArrayProperty<MTLFunction>(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.VertexAdditionalBinaryFunctions);
        set => SetArrayProperty(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetVertexAdditionalBinaryFunctions, value);
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
