namespace Metal.NET;

public class MTLBinaryArchive : IDisposable
{
    public MTLBinaryArchive(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLBinaryArchive()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveSelector.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBinaryArchiveSelector.SetLabel, value.NativePtr);
    }

    public Bool8 AddComputePipelineFunctions(MTLComputePipelineDescriptor descriptor, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddComputePipelineFunctionsError, descriptor.NativePtr, out nint errorPtr);

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public Bool8 AddFunction(MTLFunctionDescriptor descriptor, MTLLibrary library, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddFunctionLibraryError, descriptor.NativePtr, library.NativePtr, out nint errorPtr);

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public Bool8 AddLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddLibraryError, descriptor.NativePtr, out nint errorPtr);

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public Bool8 AddMeshRenderPipelineFunctions(MTLMeshRenderPipelineDescriptor descriptor, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddMeshRenderPipelineFunctionsError, descriptor.NativePtr, out nint errorPtr);

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public Bool8 AddRenderPipelineFunctions(MTLRenderPipelineDescriptor descriptor, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddRenderPipelineFunctionsError, descriptor.NativePtr, out nint errorPtr);

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public Bool8 AddTileRenderPipelineFunctions(MTLTileRenderPipelineDescriptor descriptor, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddTileRenderPipelineFunctionsError, descriptor.NativePtr, out nint errorPtr);

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public Bool8 SerializeToURL(NSURL url, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.SerializeToURLError, url.NativePtr, out nint errorPtr);

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

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
}

file class MTLBinaryArchiveSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector AddComputePipelineFunctionsError = Selector.Register("addComputePipelineFunctions:error:");

    public static readonly Selector AddFunctionLibraryError = Selector.Register("addFunction:library:error:");

    public static readonly Selector AddLibraryError = Selector.Register("addLibrary:error:");

    public static readonly Selector AddMeshRenderPipelineFunctionsError = Selector.Register("addMeshRenderPipelineFunctions:error:");

    public static readonly Selector AddRenderPipelineFunctionsError = Selector.Register("addRenderPipelineFunctions:error:");

    public static readonly Selector AddTileRenderPipelineFunctionsError = Selector.Register("addTileRenderPipelineFunctions:error:");

    public static readonly Selector SerializeToURLError = Selector.Register("serializeToURL:error:");
}
