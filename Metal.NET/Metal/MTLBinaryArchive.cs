namespace Metal.NET;

public class MTLBinaryArchive(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLBinaryArchive>
{
    #region INativeObject
    public static new MTLBinaryArchive Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLBinaryArchive New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Label
    {
        get => GetProperty(ref field, MTLBinaryArchiveBindings.Label);
        set => SetProperty(ref field, MTLBinaryArchiveBindings.SetLabel, value);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLBinaryArchiveBindings.Device);
    }

    public bool AddComputePipelineFunctionsWithDescriptorError(MTLComputePipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddComputePipelineFunctionsWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool AddComputePipelineFunctions(MTLComputePipelineDescriptor descriptor, out NSError error)
    {
        return AddComputePipelineFunctionsWithDescriptorError(descriptor, out error);
    }

    public bool AddRenderPipelineFunctionsWithDescriptorError(MTLRenderPipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddRenderPipelineFunctionsWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool AddRenderPipelineFunctions(MTLRenderPipelineDescriptor descriptor, out NSError error)
    {
        return AddRenderPipelineFunctionsWithDescriptorError(descriptor, out error);
    }

    public bool AddTileRenderPipelineFunctionsWithDescriptorError(MTLTileRenderPipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddTileRenderPipelineFunctionsWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool AddTileRenderPipelineFunctions(MTLTileRenderPipelineDescriptor descriptor, out NSError error)
    {
        return AddTileRenderPipelineFunctionsWithDescriptorError(descriptor, out error);
    }

    public bool AddMeshRenderPipelineFunctionsWithDescriptorError(MTLMeshRenderPipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddMeshRenderPipelineFunctionsWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool AddMeshRenderPipelineFunctions(MTLMeshRenderPipelineDescriptor descriptor, out NSError error)
    {
        return AddMeshRenderPipelineFunctionsWithDescriptorError(descriptor, out error);
    }

    public bool AddLibraryWithDescriptorError(MTLStitchedLibraryDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddLibraryWithDescriptor, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool AddLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError error)
    {
        return AddLibraryWithDescriptorError(descriptor, out error);
    }

    public bool SerializeToURLError(NSURL url, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.SerializeToURL, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool SerializeToURL(NSURL url, out NSError error)
    {
        return SerializeToURLError(url, out error);
    }

    public bool AddFunctionWithDescriptorLibraryError(MTLFunctionDescriptor descriptor, MTLLibrary library, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddFunctionWithDescriptor, descriptor.NativePtr, library.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool AddFunction(MTLFunctionDescriptor descriptor, MTLLibrary library, out NSError error)
    {
        return AddFunctionWithDescriptorLibraryError(descriptor, library, out error);
    }
}

file static class MTLBinaryArchiveBindings
{
    public static readonly Selector AddComputePipelineFunctionsWithDescriptor = "addComputePipelineFunctionsWithDescriptor:error:";

    public static readonly Selector AddFunctionWithDescriptor = "addFunctionWithDescriptor:library:error:";

    public static readonly Selector AddLibraryWithDescriptor = "addLibraryWithDescriptor:error:";

    public static readonly Selector AddMeshRenderPipelineFunctionsWithDescriptor = "addMeshRenderPipelineFunctionsWithDescriptor:error:";

    public static readonly Selector AddRenderPipelineFunctionsWithDescriptor = "addRenderPipelineFunctionsWithDescriptor:error:";

    public static readonly Selector AddTileRenderPipelineFunctionsWithDescriptor = "addTileRenderPipelineFunctionsWithDescriptor:error:";

    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector SerializeToURL = "serializeToURL:error:";

    public static readonly Selector SetLabel = "setLabel:";
}
