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

    public bool AddComputePipelineFunctions(MTLComputePipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddComputePipelineFunctionsWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool AddRenderPipelineFunctions(MTLRenderPipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddRenderPipelineFunctionsWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool AddTileRenderPipelineFunctions(MTLTileRenderPipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddTileRenderPipelineFunctionsWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool AddMeshRenderPipelineFunctions(MTLMeshRenderPipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddMeshRenderPipelineFunctionsWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool AddLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddLibraryWithDescriptorError, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool Serialize(NSURL url, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.SerializeToURLError, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool AddFunction(MTLFunctionDescriptor descriptor, MTLLibrary library, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddFunctionWithDescriptorLibraryError, descriptor.NativePtr, library.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }
}

file static class MTLBinaryArchiveBindings
{
    public static readonly Selector AddComputePipelineFunctionsWithDescriptorError = "addComputePipelineFunctionsWithDescriptor:error:";

    public static readonly Selector AddFunctionWithDescriptorLibraryError = "addFunctionWithDescriptor:library:error:";

    public static readonly Selector AddLibraryWithDescriptorError = "addLibraryWithDescriptor:error:";

    public static readonly Selector AddMeshRenderPipelineFunctionsWithDescriptorError = "addMeshRenderPipelineFunctionsWithDescriptor:error:";

    public static readonly Selector AddRenderPipelineFunctionsWithDescriptorError = "addRenderPipelineFunctionsWithDescriptor:error:";

    public static readonly Selector AddTileRenderPipelineFunctionsWithDescriptorError = "addTileRenderPipelineFunctionsWithDescriptor:error:";

    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector SerializeToURLError = "serializeToURL:error:";

    public static readonly Selector SetLabel = "setLabel:";
}
