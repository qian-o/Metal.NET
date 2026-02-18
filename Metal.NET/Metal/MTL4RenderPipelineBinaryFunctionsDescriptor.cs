namespace Metal.NET;

public class MTL4RenderPipelineBinaryFunctionsDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4RenderPipelineBinaryFunctionsDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4RenderPipelineBinaryFunctionsDescriptorSelector.Class))
    {
    }

    public NSArray? FragmentAdditionalBinaryFunctions
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.FragmentAdditionalBinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetFragmentAdditionalBinaryFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? MeshAdditionalBinaryFunctions
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.MeshAdditionalBinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetMeshAdditionalBinaryFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? ObjectAdditionalBinaryFunctions
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.ObjectAdditionalBinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetObjectAdditionalBinaryFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? TileAdditionalBinaryFunctions
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.TileAdditionalBinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetTileAdditionalBinaryFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? VertexAdditionalBinaryFunctions
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.VertexAdditionalBinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetVertexAdditionalBinaryFunctions, value?.NativePtr ?? 0);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.Reset);
    }
}

file static class MTL4RenderPipelineBinaryFunctionsDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineBinaryFunctionsDescriptor");

    public static readonly Selector FragmentAdditionalBinaryFunctions = Selector.Register("fragmentAdditionalBinaryFunctions");

    public static readonly Selector MeshAdditionalBinaryFunctions = Selector.Register("meshAdditionalBinaryFunctions");

    public static readonly Selector ObjectAdditionalBinaryFunctions = Selector.Register("objectAdditionalBinaryFunctions");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetFragmentAdditionalBinaryFunctions = Selector.Register("setFragmentAdditionalBinaryFunctions:");

    public static readonly Selector SetMeshAdditionalBinaryFunctions = Selector.Register("setMeshAdditionalBinaryFunctions:");

    public static readonly Selector SetObjectAdditionalBinaryFunctions = Selector.Register("setObjectAdditionalBinaryFunctions:");

    public static readonly Selector SetTileAdditionalBinaryFunctions = Selector.Register("setTileAdditionalBinaryFunctions:");

    public static readonly Selector SetVertexAdditionalBinaryFunctions = Selector.Register("setVertexAdditionalBinaryFunctions:");

    public static readonly Selector TileAdditionalBinaryFunctions = Selector.Register("tileAdditionalBinaryFunctions");

    public static readonly Selector VertexAdditionalBinaryFunctions = Selector.Register("vertexAdditionalBinaryFunctions");
}
