namespace Metal.NET;

public readonly struct MTLRenderPipelineFunctionsDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLRenderPipelineFunctionsDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineFunctionsDescriptorBindings.Class))
    {
    }

    public NSArray? FragmentAdditionalBinaryFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineFunctionsDescriptorBindings.FragmentAdditionalBinaryFunctions);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorBindings.SetFragmentAdditionalBinaryFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? TileAdditionalBinaryFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineFunctionsDescriptorBindings.TileAdditionalBinaryFunctions);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorBindings.SetTileAdditionalBinaryFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? VertexAdditionalBinaryFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineFunctionsDescriptorBindings.VertexAdditionalBinaryFunctions);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorBindings.SetVertexAdditionalBinaryFunctions, value?.NativePtr ?? 0);
    }
}

file static class MTLRenderPipelineFunctionsDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPipelineFunctionsDescriptor");

    public static readonly Selector FragmentAdditionalBinaryFunctions = Selector.Register("fragmentAdditionalBinaryFunctions");

    public static readonly Selector SetFragmentAdditionalBinaryFunctions = Selector.Register("setFragmentAdditionalBinaryFunctions:");

    public static readonly Selector SetTileAdditionalBinaryFunctions = Selector.Register("setTileAdditionalBinaryFunctions:");

    public static readonly Selector SetVertexAdditionalBinaryFunctions = Selector.Register("setVertexAdditionalBinaryFunctions:");

    public static readonly Selector TileAdditionalBinaryFunctions = Selector.Register("tileAdditionalBinaryFunctions");

    public static readonly Selector VertexAdditionalBinaryFunctions = Selector.Register("vertexAdditionalBinaryFunctions");
}
