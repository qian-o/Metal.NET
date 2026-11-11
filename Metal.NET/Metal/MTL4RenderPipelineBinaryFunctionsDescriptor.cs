namespace Metal.NET;

public readonly struct MTL4RenderPipelineBinaryFunctionsDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4RenderPipelineBinaryFunctionsDescriptor value) => new(value.NativePtr);

    public MTL4RenderPipelineBinaryFunctionsDescriptor() : this(ObjectiveC.AllocInit(MTL4RenderPipelineBinaryFunctionsDescriptorBindings.Class))
    {
    }

    public MTL4RenderPipelineBinaryFunctionsDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public NSArray<MTL4BinaryFunction> VertexAdditionalBinaryFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.VertexAdditionalBinaryFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetVertexAdditionalBinaryFunctions, value.NativePtr);
    }

    public NSArray<MTL4BinaryFunction> FragmentAdditionalBinaryFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.FragmentAdditionalBinaryFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetFragmentAdditionalBinaryFunctions, value.NativePtr);
    }

    public NSArray<MTL4BinaryFunction> TileAdditionalBinaryFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.TileAdditionalBinaryFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetTileAdditionalBinaryFunctions, value.NativePtr);
    }

    public NSArray<MTL4BinaryFunction> ObjectAdditionalBinaryFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.ObjectAdditionalBinaryFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetObjectAdditionalBinaryFunctions, value.NativePtr);
    }

    public NSArray<MTL4BinaryFunction> MeshAdditionalBinaryFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.MeshAdditionalBinaryFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorBindings.SetMeshAdditionalBinaryFunctions, value.NativePtr);
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
