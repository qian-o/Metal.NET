namespace Metal.NET;

file class MTLRenderPipelineFunctionsDescriptorSelector
{
    public static readonly Selector SetFragmentAdditionalBinaryFunctions_ = Selector.Register("setFragmentAdditionalBinaryFunctions:");
    public static readonly Selector SetTileAdditionalBinaryFunctions_ = Selector.Register("setTileAdditionalBinaryFunctions:");
    public static readonly Selector SetVertexAdditionalBinaryFunctions_ = Selector.Register("setVertexAdditionalBinaryFunctions:");
}

public class MTLRenderPipelineFunctionsDescriptor : IDisposable
{
    public MTLRenderPipelineFunctionsDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.SetFragmentAdditionalBinaryFunctions_, fragmentAdditionalBinaryFunctions.NativePtr);
    }

    public void SetTileAdditionalBinaryFunctions(NSArray tileAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.SetTileAdditionalBinaryFunctions_, tileAdditionalBinaryFunctions.NativePtr);
    }

    public void SetVertexAdditionalBinaryFunctions(NSArray vertexAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPipelineFunctionsDescriptorSelector.SetVertexAdditionalBinaryFunctions_, vertexAdditionalBinaryFunctions.NativePtr);
    }

}
