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

    public void SetFragmentAdditionalBinaryFunctions(NSArray fragmentAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.SetFragmentAdditionalBinaryFunctions, fragmentAdditionalBinaryFunctions.NativePtr);
    }

    public void SetTileAdditionalBinaryFunctions(NSArray tileAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.SetTileAdditionalBinaryFunctions, tileAdditionalBinaryFunctions.NativePtr);
    }

    public void SetVertexAdditionalBinaryFunctions(NSArray vertexAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.SetVertexAdditionalBinaryFunctions, vertexAdditionalBinaryFunctions.NativePtr);
    }

}

file class MTLRenderPipelineFunctionsDescriptorSelector
{
    public static readonly Selector SetFragmentAdditionalBinaryFunctions = Selector.Register("setFragmentAdditionalBinaryFunctions:");

    public static readonly Selector SetTileAdditionalBinaryFunctions = Selector.Register("setTileAdditionalBinaryFunctions:");

    public static readonly Selector SetVertexAdditionalBinaryFunctions = Selector.Register("setVertexAdditionalBinaryFunctions:");
}
