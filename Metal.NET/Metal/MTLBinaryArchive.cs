namespace Metal.NET;

public partial class MTLBinaryArchive : NativeObject
{
    public MTLBinaryArchive(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveSelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBinaryArchiveSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public bool AddComputePipelineFunctions(MTLComputePipelineDescriptor descriptor, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddComputePipelineFunctions, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new(errorPtr) : null;
        return result;
    }

    public bool AddFunction(MTLFunctionDescriptor descriptor, MTLLibrary library, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddFunction, descriptor.NativePtr, library.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new(errorPtr) : null;
        return result;
    }

    public bool AddLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddLibrary, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new(errorPtr) : null;
        return result;
    }

    public bool AddMeshRenderPipelineFunctions(MTLMeshRenderPipelineDescriptor descriptor, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddMeshRenderPipelineFunctions, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new(errorPtr) : null;
        return result;
    }

    public bool AddRenderPipelineFunctions(MTLRenderPipelineDescriptor descriptor, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddRenderPipelineFunctions, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new(errorPtr) : null;
        return result;
    }

    public bool AddTileRenderPipelineFunctions(MTLTileRenderPipelineDescriptor descriptor, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddTileRenderPipelineFunctions, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new(errorPtr) : null;
        return result;
    }

    public bool SerializeToURL(NSURL url, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.SerializeToURL, url.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new(errorPtr) : null;
        return result;
    }
}

file static class MTLBinaryArchiveSelector
{
    public static readonly Selector AddComputePipelineFunctions = Selector.Register("addComputePipelineFunctions:::");

    public static readonly Selector AddFunction = Selector.Register("addFunction::::");

    public static readonly Selector AddLibrary = Selector.Register("addLibrary:::");

    public static readonly Selector AddMeshRenderPipelineFunctions = Selector.Register("addMeshRenderPipelineFunctions:::");

    public static readonly Selector AddRenderPipelineFunctions = Selector.Register("addRenderPipelineFunctions:::");

    public static readonly Selector AddTileRenderPipelineFunctions = Selector.Register("addTileRenderPipelineFunctions:::");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SerializeToURL = Selector.Register("serializeToURL:::");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
