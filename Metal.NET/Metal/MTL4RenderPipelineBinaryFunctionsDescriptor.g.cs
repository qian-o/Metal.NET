namespace Metal.NET;

file class MTL4RenderPipelineBinaryFunctionsDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetFragmentAdditionalBinaryFunctions_ = Selector.Register("setFragmentAdditionalBinaryFunctions:");
    public static readonly Selector SetMeshAdditionalBinaryFunctions_ = Selector.Register("setMeshAdditionalBinaryFunctions:");
    public static readonly Selector SetObjectAdditionalBinaryFunctions_ = Selector.Register("setObjectAdditionalBinaryFunctions:");
    public static readonly Selector SetTileAdditionalBinaryFunctions_ = Selector.Register("setTileAdditionalBinaryFunctions:");
    public static readonly Selector SetVertexAdditionalBinaryFunctions_ = Selector.Register("setVertexAdditionalBinaryFunctions:");
}

public class MTL4RenderPipelineBinaryFunctionsDescriptor : IDisposable
{
    public MTL4RenderPipelineBinaryFunctionsDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.Reset);
    }

    public void SetFragmentAdditionalBinaryFunctions(NSArray fragmentAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetFragmentAdditionalBinaryFunctions_, fragmentAdditionalBinaryFunctions.NativePtr);
    }

    public void SetMeshAdditionalBinaryFunctions(NSArray meshAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetMeshAdditionalBinaryFunctions_, meshAdditionalBinaryFunctions.NativePtr);
    }

    public void SetObjectAdditionalBinaryFunctions(NSArray objectAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetObjectAdditionalBinaryFunctions_, objectAdditionalBinaryFunctions.NativePtr);
    }

    public void SetTileAdditionalBinaryFunctions(NSArray tileAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetTileAdditionalBinaryFunctions_, tileAdditionalBinaryFunctions.NativePtr);
    }

    public void SetVertexAdditionalBinaryFunctions(NSArray vertexAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetVertexAdditionalBinaryFunctions_, vertexAdditionalBinaryFunctions.NativePtr);
    }

}
