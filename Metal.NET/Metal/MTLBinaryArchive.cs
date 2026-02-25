namespace Metal.NET;

public class MTLBinaryArchive(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLBinaryArchive>
{
    public static MTLBinaryArchive Create(nint nativePtr) => new(nativePtr);

    public static MTLBinaryArchive CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLBinaryArchiveBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLBinaryArchiveBindings.Label);
        set => SetProperty(ref field, MTLBinaryArchiveBindings.SetLabel, value);
    }

    public bool AddComputePipelineFunctions(MTLComputePipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddComputePipelineFunctions, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, ownsReference: false);

        return result;
    }

    public bool AddFunction(MTLFunctionDescriptor descriptor, MTLLibrary library, out NSError error)
    {
        bool result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddFunction, descriptor.NativePtr, library.NativePtr, out nint errorPtr);

        error = new(errorPtr, ownsReference: false);

        return result;
    }

    public bool AddLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddLibrary, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, ownsReference: false);

        return result;
    }

    public bool AddMeshRenderPipelineFunctions(MTLMeshRenderPipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddMeshRenderPipelineFunctions, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, ownsReference: false);

        return result;
    }

    public bool AddRenderPipelineFunctions(MTLRenderPipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddRenderPipelineFunctions, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, ownsReference: false);

        return result;
    }

    public bool AddTileRenderPipelineFunctions(MTLTileRenderPipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddTileRenderPipelineFunctions, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, ownsReference: false);

        return result;
    }

    public bool SerializeToURL(NSURL url, out NSError error)
    {
        bool result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.SerializeToURL, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, ownsReference: false);

        return result;
    }
}

file static class MTLBinaryArchiveBindings
{
    public static readonly Selector AddComputePipelineFunctions = "addComputePipelineFunctionsWithDescriptor:error:";

    public static readonly Selector AddFunction = "addFunctionWithDescriptor:library:error:";

    public static readonly Selector AddLibrary = "addLibraryWithDescriptor:error:";

    public static readonly Selector AddMeshRenderPipelineFunctions = "addMeshRenderPipelineFunctionsWithDescriptor:error:";

    public static readonly Selector AddRenderPipelineFunctions = "addRenderPipelineFunctionsWithDescriptor:error:";

    public static readonly Selector AddTileRenderPipelineFunctions = "addTileRenderPipelineFunctionsWithDescriptor:error:";

    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector SerializeToURL = "serializeToURL:error:";

    public static readonly Selector SetLabel = "setLabel:";
}
