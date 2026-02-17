namespace Metal.NET;

public class MTL4RenderPipelineBinaryFunctionsDescriptor : IDisposable
{
    public MTL4RenderPipelineBinaryFunctionsDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4RenderPipelineBinaryFunctionsDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4RenderPipelineBinaryFunctionsDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4RenderPipelineBinaryFunctionsDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    public NSArray FragmentAdditionalBinaryFunctions
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.FragmentAdditionalBinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetFragmentAdditionalBinaryFunctions, value.NativePtr);
    }

    public NSArray MeshAdditionalBinaryFunctions
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.MeshAdditionalBinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetMeshAdditionalBinaryFunctions, value.NativePtr);
    }

    public NSArray ObjectAdditionalBinaryFunctions
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.ObjectAdditionalBinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetObjectAdditionalBinaryFunctions, value.NativePtr);
    }

    public NSArray TileAdditionalBinaryFunctions
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.TileAdditionalBinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetTileAdditionalBinaryFunctions, value.NativePtr);
    }

    public NSArray VertexAdditionalBinaryFunctions
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.VertexAdditionalBinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetVertexAdditionalBinaryFunctions, value.NativePtr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.Reset);
    }

}

file class MTL4RenderPipelineBinaryFunctionsDescriptorSelector
{
    public static readonly Selector FragmentAdditionalBinaryFunctions = Selector.Register("fragmentAdditionalBinaryFunctions");

    public static readonly Selector SetFragmentAdditionalBinaryFunctions = Selector.Register("setFragmentAdditionalBinaryFunctions:");

    public static readonly Selector MeshAdditionalBinaryFunctions = Selector.Register("meshAdditionalBinaryFunctions");

    public static readonly Selector SetMeshAdditionalBinaryFunctions = Selector.Register("setMeshAdditionalBinaryFunctions:");

    public static readonly Selector ObjectAdditionalBinaryFunctions = Selector.Register("objectAdditionalBinaryFunctions");

    public static readonly Selector SetObjectAdditionalBinaryFunctions = Selector.Register("setObjectAdditionalBinaryFunctions:");

    public static readonly Selector TileAdditionalBinaryFunctions = Selector.Register("tileAdditionalBinaryFunctions");

    public static readonly Selector SetTileAdditionalBinaryFunctions = Selector.Register("setTileAdditionalBinaryFunctions:");

    public static readonly Selector VertexAdditionalBinaryFunctions = Selector.Register("vertexAdditionalBinaryFunctions");

    public static readonly Selector SetVertexAdditionalBinaryFunctions = Selector.Register("setVertexAdditionalBinaryFunctions:");

    public static readonly Selector Reset = Selector.Register("reset");
}
