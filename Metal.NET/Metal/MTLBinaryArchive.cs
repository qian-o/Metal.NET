namespace Metal.NET;

/// <summary>
/// A container for pipeline state descriptors and their associated compiled shader code.
/// </summary>
public class MTLBinaryArchive(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLBinaryArchive>
{
    #region INativeObject
    public static new MTLBinaryArchive Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLBinaryArchive New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Identifying the archive - Properties

    /// <summary>
    /// The Metal device object that created the binary archive.
    /// </summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLBinaryArchiveBindings.Device);
    }

    /// <summary>
    /// A string that identifies the library.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLBinaryArchiveBindings.Label);
        set => SetProperty(ref field, MTLBinaryArchiveBindings.SetLabel, value);
    }
    #endregion

    #region Adding pipeline descriptors - Methods

    /// <summary>
    /// Adds a description of a compute pipeline to the archive.
    /// </summary>
    public bool AddComputePipelineFunctions(MTLComputePipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddComputePipelineFunctions, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    /// <summary>
    /// Adds a description of a render pipeline to the archive.
    /// </summary>
    public bool AddRenderPipelineFunctions(MTLRenderPipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddRenderPipelineFunctions, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    /// <summary>
    /// Adds a description of a tile renderer pipeline to the archive.
    /// </summary>
    public bool AddTileRenderPipelineFunctions(MTLTileRenderPipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddTileRenderPipelineFunctions, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    /// <summary>
    /// Adds a description of a function to the archive.
    /// </summary>
    public bool AddFunction(MTLFunctionDescriptor descriptor, MTLLibrary library, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddFunction, descriptor.NativePtr, library.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }
    #endregion

    #region Serializing archives - Methods

    /// <summary>
    /// Writes the contents of the archive to a file.
    /// </summary>
    public bool SerializeToURL(NSURL url, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.SerializeToURL, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }
    #endregion

    #region Instance Methods - Methods

    public bool AddLibrary(MTLStitchedLibraryDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddLibrary, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public bool AddMeshRenderPipelineFunctions(MTLMeshRenderPipelineDescriptor descriptor, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTLBinaryArchiveBindings.AddMeshRenderPipelineFunctions, descriptor.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }
    #endregion
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
