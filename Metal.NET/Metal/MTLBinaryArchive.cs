namespace Metal.NET;

public class MTLBinaryArchive(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveBindings.Device);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLDevice(ptr);
            }

            return field;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveBindings.Label);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLBinaryArchiveBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public bool AddComputePipelineFunctions(MTLComputePipelineDescriptor descriptor, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddComputePipelineFunctions, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return result;
    }

    public bool AddFunction(MTLFunctionDescriptor descriptor, MTLLibrary library, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddFunction, descriptor.NativePtr, library.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return result;
    }

    public bool AddLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddLibrary, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return result;
    }

    public bool AddMeshRenderPipelineFunctions(MTLMeshRenderPipelineDescriptor descriptor, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddMeshRenderPipelineFunctions, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return result;
    }

    public bool AddRenderPipelineFunctions(MTLRenderPipelineDescriptor descriptor, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddRenderPipelineFunctions, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return result;
    }

    public bool AddTileRenderPipelineFunctions(MTLTileRenderPipelineDescriptor descriptor, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddTileRenderPipelineFunctions, descriptor.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return result;
    }

    public bool SerializeToURL(NSURL url, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.SerializeToURL, url.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;
        return result;
    }
}

file static class MTLBinaryArchiveBindings
{
    public static readonly Selector AddComputePipelineFunctions = Selector.Register("addComputePipelineFunctionsWithDescriptor:error:");

    public static readonly Selector AddFunction = Selector.Register("addFunctionWithDescriptor:library:error:");

    public static readonly Selector AddLibrary = Selector.Register("addLibraryWithDescriptor:error:");

    public static readonly Selector AddMeshRenderPipelineFunctions = Selector.Register("addMeshRenderPipelineFunctionsWithDescriptor:error:");

    public static readonly Selector AddRenderPipelineFunctions = Selector.Register("addRenderPipelineFunctionsWithDescriptor:error:");

    public static readonly Selector AddTileRenderPipelineFunctions = Selector.Register("addTileRenderPipelineFunctionsWithDescriptor:error:");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SerializeToURL = Selector.Register("serializeToURL:error:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
