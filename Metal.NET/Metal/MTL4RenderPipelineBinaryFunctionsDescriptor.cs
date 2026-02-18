namespace Metal.NET;

public partial class MTL4RenderPipelineBinaryFunctionsDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4RenderPipelineBinaryFunctionsDescriptor");

    public MTL4RenderPipelineBinaryFunctionsDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? FragmentAdditionalBinaryFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.FragmentAdditionalBinaryFunctions);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetFragmentAdditionalBinaryFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? MeshAdditionalBinaryFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.MeshAdditionalBinaryFunctions);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetMeshAdditionalBinaryFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? ObjectAdditionalBinaryFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.ObjectAdditionalBinaryFunctions);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetObjectAdditionalBinaryFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? TileAdditionalBinaryFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.TileAdditionalBinaryFunctions);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetTileAdditionalBinaryFunctions, value?.NativePtr ?? 0);
    }

    public NSArray? VertexAdditionalBinaryFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.VertexAdditionalBinaryFunctions);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetVertexAdditionalBinaryFunctions, value?.NativePtr ?? 0);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.Reset);
    }
}

file static class MTL4RenderPipelineBinaryFunctionsDescriptorSelector
{
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
