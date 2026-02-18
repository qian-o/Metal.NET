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
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddComputePipelineFunctionsWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public Bool8 AddLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddLibraryWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public Bool8 AddMeshRenderPipelineFunctions(MTLMeshRenderPipelineDescriptor descriptor, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddMeshRenderPipelineFunctionsWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public Bool8 AddRenderPipelineFunctions(MTLRenderPipelineDescriptor descriptor, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddRenderPipelineFunctionsWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public Bool8 AddTileRenderPipelineFunctions(MTLTileRenderPipelineDescriptor descriptor, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddTileRenderPipelineFunctionsWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

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

    public static readonly Selector AddComputePipelineFunctionsWithDescriptorError = Selector.Register("addComputePipelineFunctionsWithDescriptor:error:");

    public static readonly Selector AddLibraryWithDescriptorError = Selector.Register("addLibraryWithDescriptor:error:");

    public static readonly Selector AddMeshRenderPipelineFunctionsWithDescriptorError = Selector.Register("addMeshRenderPipelineFunctionsWithDescriptor:error:");

    public static readonly Selector AddRenderPipelineFunctionsWithDescriptorError = Selector.Register("addRenderPipelineFunctionsWithDescriptor:error:");

    public static readonly Selector AddTileRenderPipelineFunctionsWithDescriptorError = Selector.Register("addTileRenderPipelineFunctionsWithDescriptor:error:");

    public static readonly Selector SerializeToURLError = Selector.Register("serializeToURL:error:");
}
