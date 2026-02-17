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

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.Reset);
    }

    public void SetFragmentAdditionalBinaryFunctions(NSArray fragmentAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetFragmentAdditionalBinaryFunctions, fragmentAdditionalBinaryFunctions.NativePtr);
    }

    public void SetMeshAdditionalBinaryFunctions(NSArray meshAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetMeshAdditionalBinaryFunctions, meshAdditionalBinaryFunctions.NativePtr);
    }

    public void SetObjectAdditionalBinaryFunctions(NSArray objectAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetObjectAdditionalBinaryFunctions, objectAdditionalBinaryFunctions.NativePtr);
    }

    public void SetTileAdditionalBinaryFunctions(NSArray tileAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetTileAdditionalBinaryFunctions, tileAdditionalBinaryFunctions.NativePtr);
    }

    public void SetVertexAdditionalBinaryFunctions(NSArray vertexAdditionalBinaryFunctions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4RenderPipelineBinaryFunctionsDescriptorSelector.SetVertexAdditionalBinaryFunctions, vertexAdditionalBinaryFunctions.NativePtr);
    }

}

file class MTL4RenderPipelineBinaryFunctionsDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetFragmentAdditionalBinaryFunctions = Selector.Register("setFragmentAdditionalBinaryFunctions:");
    public static readonly Selector SetMeshAdditionalBinaryFunctions = Selector.Register("setMeshAdditionalBinaryFunctions:");
    public static readonly Selector SetObjectAdditionalBinaryFunctions = Selector.Register("setObjectAdditionalBinaryFunctions:");
    public static readonly Selector SetTileAdditionalBinaryFunctions = Selector.Register("setTileAdditionalBinaryFunctions:");
    public static readonly Selector SetVertexAdditionalBinaryFunctions = Selector.Register("setVertexAdditionalBinaryFunctions:");
}
