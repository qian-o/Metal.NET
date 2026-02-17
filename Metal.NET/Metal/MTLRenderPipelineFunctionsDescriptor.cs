namespace Metal.NET;

public class MTLRenderPipelineFunctionsDescriptor : IDisposable
{
    public MTLRenderPipelineFunctionsDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLRenderPipelineFunctionsDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSArray FragmentAdditionalBinaryFunctions
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.FragmentAdditionalBinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.SetFragmentAdditionalBinaryFunctions, value.NativePtr);
    }

    public NSArray TileAdditionalBinaryFunctions
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.TileAdditionalBinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.SetTileAdditionalBinaryFunctions, value.NativePtr);
    }

    public NSArray VertexAdditionalBinaryFunctions
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.VertexAdditionalBinaryFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.SetVertexAdditionalBinaryFunctions, value.NativePtr);
    }

    public static implicit operator nint(MTLRenderPipelineFunctionsDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPipelineFunctionsDescriptor(nint value)
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

}

file class MTLRenderPipelineFunctionsDescriptorSelector
{
    public static readonly Selector FragmentAdditionalBinaryFunctions = Selector.Register("fragmentAdditionalBinaryFunctions");

    public static readonly Selector SetFragmentAdditionalBinaryFunctions = Selector.Register("setFragmentAdditionalBinaryFunctions:");

    public static readonly Selector TileAdditionalBinaryFunctions = Selector.Register("tileAdditionalBinaryFunctions");

    public static readonly Selector SetTileAdditionalBinaryFunctions = Selector.Register("setTileAdditionalBinaryFunctions:");

    public static readonly Selector VertexAdditionalBinaryFunctions = Selector.Register("vertexAdditionalBinaryFunctions");

    public static readonly Selector SetVertexAdditionalBinaryFunctions = Selector.Register("setVertexAdditionalBinaryFunctions:");
}
