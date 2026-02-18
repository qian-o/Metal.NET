namespace Metal.NET;

public class MTLBinaryArchive(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveSelector.Device));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBinaryArchiveSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLBinaryArchiveSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public bool AddComputePipelineFunctions(MTLComputePipelineDescriptor descriptor, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddComputePipelineFunctions, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return result;
    }

    public bool AddFunction(MTLFunctionDescriptor descriptor, MTLLibrary library, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddFunction, descriptor.NativePtr, library.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return result;
    }

    public bool AddLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddLibrary, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return result;
    }

    public bool AddMeshRenderPipelineFunctions(MTLMeshRenderPipelineDescriptor descriptor, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddMeshRenderPipelineFunctions, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return result;
    }

    public bool AddRenderPipelineFunctions(MTLRenderPipelineDescriptor descriptor, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddRenderPipelineFunctions, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return result;
    }

    public bool AddTileRenderPipelineFunctions(MTLTileRenderPipelineDescriptor descriptor, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.AddTileRenderPipelineFunctions, descriptor.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return result;
    }

    public bool SerializeToURL(NSURL url, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBinaryArchiveSelector.SerializeToURL, url.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return result;
    }
}

file static class MTLBinaryArchiveSelector
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
