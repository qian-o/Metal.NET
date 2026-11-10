namespace Metal.NET;

public readonly struct MTLBinaryArchive(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLBinaryArchive value) => new(value.NativePtr);

    public MTLBinaryArchive Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLBinaryArchiveBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLBinaryArchiveBindings.SetLabel, value.NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLBinaryArchiveBindings.Device));
    }

    public bool AddComputePipelineFunctions(MTLComputePipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddComputePipelineFunctionsWithDescriptor_Error, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return result;
    }

    public bool AddRenderPipelineFunctions(MTLRenderPipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddRenderPipelineFunctionsWithDescriptor_Error, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return result;
    }

    public bool AddTileRenderPipelineFunctions(MTLTileRenderPipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddTileRenderPipelineFunctionsWithDescriptor_Error, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return result;
    }

    public bool AddMeshRenderPipelineFunctions(MTLMeshRenderPipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddMeshRenderPipelineFunctionsWithDescriptor_Error, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return result;
    }

    public bool AddLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddLibraryWithDescriptor_Error, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return result;
    }

    public bool Serialize(NSURL url, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.SerializeToURL_Error, url.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return result;
    }

    public bool AddFunction(MTLFunctionDescriptor descriptor, MTLLibrary library, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddFunctionWithDescriptor_Library_Error, descriptor.NativePtr, library.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return result;
    }
}

file static class MTLBinaryArchiveBindings
{
    public static readonly Selector AddComputePipelineFunctionsWithDescriptor_Error = "addComputePipelineFunctionsWithDescriptor:error:";

    public static readonly Selector AddFunctionWithDescriptor_Library_Error = "addFunctionWithDescriptor:library:error:";

    public static readonly Selector AddLibraryWithDescriptor_Error = "addLibraryWithDescriptor:error:";

    public static readonly Selector AddMeshRenderPipelineFunctionsWithDescriptor_Error = "addMeshRenderPipelineFunctionsWithDescriptor:error:";

    public static readonly Selector AddRenderPipelineFunctionsWithDescriptor_Error = "addRenderPipelineFunctionsWithDescriptor:error:";

    public static readonly Selector AddTileRenderPipelineFunctionsWithDescriptor_Error = "addTileRenderPipelineFunctionsWithDescriptor:error:";

    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector SerializeToURL_Error = "serializeToURL:error:";

    public static readonly Selector SetLabel = "setLabel:";
}
