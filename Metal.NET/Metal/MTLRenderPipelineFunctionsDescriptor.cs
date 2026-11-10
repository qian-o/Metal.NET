namespace Metal.NET;

public readonly struct MTLRenderPipelineFunctionsDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLRenderPipelineFunctionsDescriptor value) => new(value.NativePtr);

    public MTLRenderPipelineFunctionsDescriptor() : this(ObjectiveC.AllocInit(MTLRenderPipelineFunctionsDescriptorBindings.Class))
    {
    }

    public MTLRenderPipelineFunctionsDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSArray<MTLFunction> VertexAdditionalBinaryFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineFunctionsDescriptorBindings.VertexAdditionalBinaryFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorBindings.SetVertexAdditionalBinaryFunctions, value.NativePtr);
    }

    public NSArray<MTLFunction> FragmentAdditionalBinaryFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineFunctionsDescriptorBindings.FragmentAdditionalBinaryFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorBindings.SetFragmentAdditionalBinaryFunctions, value.NativePtr);
    }

    public NSArray<MTLFunction> TileAdditionalBinaryFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPipelineFunctionsDescriptorBindings.TileAdditionalBinaryFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorBindings.SetTileAdditionalBinaryFunctions, value.NativePtr);
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
