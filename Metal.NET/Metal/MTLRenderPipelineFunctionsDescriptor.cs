namespace Metal.NET;

public class MTLRenderPipelineFunctionsDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRenderPipelineFunctionsDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPipelineFunctionsDescriptorSelector.Class))
    {
    }

    public NSArray? FragmentAdditionalBinaryFunctions
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.FragmentAdditionalBinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.SetFragmentAdditionalBinaryFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? TileAdditionalBinaryFunctions
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.TileAdditionalBinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.SetTileAdditionalBinaryFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? VertexAdditionalBinaryFunctions
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.VertexAdditionalBinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.SetVertexAdditionalBinaryFunctions, value?.NativePtr ?? 0);
    }
}

file static class MTLRenderPipelineFunctionsDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPipelineFunctionsDescriptor");

    public static readonly Selector FragmentAdditionalBinaryFunctions = Selector.Register("fragmentAdditionalBinaryFunctions");

    public static readonly Selector SetFragmentAdditionalBinaryFunctions = Selector.Register("setFragmentAdditionalBinaryFunctions:");

    public static readonly Selector SetTileAdditionalBinaryFunctions = Selector.Register("setTileAdditionalBinaryFunctions:");

    public static readonly Selector SetVertexAdditionalBinaryFunctions = Selector.Register("setVertexAdditionalBinaryFunctions:");

    public static readonly Selector TileAdditionalBinaryFunctions = Selector.Register("tileAdditionalBinaryFunctions");

    public static readonly Selector VertexAdditionalBinaryFunctions = Selector.Register("vertexAdditionalBinaryFunctions");
}
