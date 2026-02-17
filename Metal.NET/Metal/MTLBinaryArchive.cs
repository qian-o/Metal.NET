namespace Metal.NET;

public class MTLBinaryArchive : IDisposable
{
    public MTLBinaryArchive(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLBinaryArchive()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLBinaryArchive value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLBinaryArchive(nint value)
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

    public Bool8 AddComputePipelineFunctions(MTLComputePipelineDescriptor descriptor, out NSError? error)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveSelector.AddComputePipelineFunctionsError, descriptor.NativePtr, out nint errorPtr) is not 0;

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public Bool8 AddFunction(MTLFunctionDescriptor descriptor, MTLLibrary library, out NSError? error)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveSelector.AddFunctionLibraryError, descriptor.NativePtr, library.NativePtr, out nint errorPtr) is not 0;

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public Bool8 AddLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError? error)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveSelector.AddLibraryError, descriptor.NativePtr, out nint errorPtr) is not 0;

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public Bool8 AddMeshRenderPipelineFunctions(MTLMeshRenderPipelineDescriptor descriptor, out NSError? error)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveSelector.AddMeshRenderPipelineFunctionsError, descriptor.NativePtr, out nint errorPtr) is not 0;

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public Bool8 AddRenderPipelineFunctions(MTLRenderPipelineDescriptor descriptor, out NSError? error)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveSelector.AddRenderPipelineFunctionsError, descriptor.NativePtr, out nint errorPtr) is not 0;

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public Bool8 AddTileRenderPipelineFunctions(MTLTileRenderPipelineDescriptor descriptor, out NSError? error)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveSelector.AddTileRenderPipelineFunctionsError, descriptor.NativePtr, out nint errorPtr) is not 0;

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public Bool8 SerializeToURL(NSURL url, out NSError? error)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveSelector.SerializeToURLError, url.NativePtr, out nint errorPtr) is not 0;

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBinaryArchiveSelector.SetLabel, label.NativePtr);
    }

}

file class MTLBinaryArchiveSelector
{
    public static readonly Selector AddComputePipelineFunctionsError = Selector.Register("addComputePipelineFunctions:error:");

    public static readonly Selector AddFunctionLibraryError = Selector.Register("addFunction:library:error:");

    public static readonly Selector AddLibraryError = Selector.Register("addLibrary:error:");

    public static readonly Selector AddMeshRenderPipelineFunctionsError = Selector.Register("addMeshRenderPipelineFunctions:error:");

    public static readonly Selector AddRenderPipelineFunctionsError = Selector.Register("addRenderPipelineFunctions:error:");

    public static readonly Selector AddTileRenderPipelineFunctionsError = Selector.Register("addTileRenderPipelineFunctions:error:");

    public static readonly Selector SerializeToURLError = Selector.Register("serializeToURL:error:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
