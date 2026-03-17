namespace Metal.NET;

/// <summary>
/// An object that configures new render pipeline state objects for tile shading.
/// </summary>
public class MTLTileRenderPipelineDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLTileRenderPipelineDescriptor>
{
    #region INativeObject
    public static new MTLTileRenderPipelineDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTileRenderPipelineDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLTileRenderPipelineDescriptor() : this(ObjectiveC.AllocInit(MTLTileRenderPipelineDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Identifying the render pipeline - Properties

    /// <summary>
    /// A string that identifies the tile pipeline descriptor.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.Label);
        set => SetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.SetLabel, value);
    }
    #endregion

    #region Specifying graphics functions and associated data - Properties

    /// <summary>
    /// The compute kernel or fragment function the pipeline calls.
    /// </summary>
    public MTLFunction TileFunction
    {
        get => GetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.TileFunction);
        set => SetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.SetTileFunction, value);
    }

    /// <summary>
    /// An array that contains the buffer mutability options for a render pipeline’s tile function.
    /// </summary>
    public MTLPipelineBufferDescriptorArray TileBuffers
    {
        get => GetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.TileBuffers);
    }

    /// <summary>
    /// The maximum call stack depth for indirect function calls in tile shaders.
    /// </summary>
    public nuint MaxCallStackDepth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTileRenderPipelineDescriptorBindings.MaxCallStackDepth);
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetMaxCallStackDepth, value);
    }
    #endregion

    #region Specifying rasterization and visibility state - Properties

    /// <summary>
    /// A Boolean value that indicates whether all threadgroups for this pipeline completely cover tiles.
    /// </summary>
    public Bool8 ThreadgroupSizeMatchesTileSize
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTileRenderPipelineDescriptorBindings.ThreadgroupSizeMatchesTileSize);
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetThreadgroupSizeMatchesTileSize, value);
    }

    /// <summary>
    /// The number of samples in each fragment.
    /// </summary>
    public nuint RasterSampleCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTileRenderPipelineDescriptorBindings.RasterSampleCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetRasterSampleCount, value);
    }
    #endregion

    #region Specifying rendering pipeline state - Properties

    /// <summary>
    /// An array of attachments that store color data.
    /// </summary>
    public MTLTileRenderPipelineColorAttachmentDescriptorArray ColorAttachments
    {
        get => GetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.ColorAttachments);
    }
    #endregion

    #region Specifying threads per threadgroup - Properties

    /// <summary>
    /// The maximum number of threads in a threadgroup when dispatching a command using the pipeline.
    /// </summary>
    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTileRenderPipelineDescriptorBindings.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetMaxTotalThreadsPerThreadgroup, value);
    }
    #endregion

    #region Specifying precompiled shader binaries - Properties

    /// <summary>
    /// A Boolean value that indicates whether you can use the pipeline to create new pipelines by adding binary functions to its callable functions list.
    /// </summary>
    public Bool8 SupportAddingBinaryFunctions
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTileRenderPipelineDescriptorBindings.SupportAddingBinaryFunctions);
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetSupportAddingBinaryFunctions, value);
    }

    /// <summary>
    /// An array of binary archives to search for precompiled versions of the shader.
    /// </summary>
    public MTLBinaryArchive[] BinaryArchives
    {
        get => GetArrayProperty<MTLBinaryArchive>(MTLTileRenderPipelineDescriptorBindings.BinaryArchives);
        set => SetArrayProperty(MTLTileRenderPipelineDescriptorBindings.SetBinaryArchives, value);
    }
    #endregion

    #region Specifying callable functions for the pipeline - Properties

    /// <summary>
    /// Functions that you can specify as function arguments for the tile shader when encoding commands that use the pipeline.
    /// </summary>
    public MTLLinkedFunctions LinkedFunctions
    {
        get => GetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.LinkedFunctions);
        set => SetProperty(ref field, MTLTileRenderPipelineDescriptorBindings.SetLinkedFunctions, value);
    }
    #endregion

    #region Specifying shader validation - Properties

    /// <summary>
    /// A value that enables or disables shader validation for the pipeline.
    /// </summary>
    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveC.MsgSendLong(NativePtr, MTLTileRenderPipelineDescriptorBindings.ShaderValidation);
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetShaderValidation, (nint)value);
    }
    #endregion

    #region Instance Properties - Properties

    public MTLDynamicLibrary[] PreloadedLibraries
    {
        get => GetArrayProperty<MTLDynamicLibrary>(MTLTileRenderPipelineDescriptorBindings.PreloadedLibraries);
        set => SetArrayProperty(MTLTileRenderPipelineDescriptorBindings.SetPreloadedLibraries, value);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLTileRenderPipelineDescriptorBindings.RequiredThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.SetRequiredThreadsPerThreadgroup, value);
    }
    #endregion

    #region Specifying rendering pipeline state - Methods

    /// <summary>
    /// Specifies the default rendering pipeline state values for the descriptor.
    /// </summary>
    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLTileRenderPipelineDescriptorBindings.Reset);
    }
    #endregion
}

file static class MTLTileRenderPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTileRenderPipelineDescriptor");

    public static readonly Selector BinaryArchives = "binaryArchives";

    public static readonly Selector ColorAttachments = "colorAttachments";

    public static readonly Selector Label = "label";

    public static readonly Selector LinkedFunctions = "linkedFunctions";

    public static readonly Selector MaxCallStackDepth = "maxCallStackDepth";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector PreloadedLibraries = "preloadedLibraries";

    public static readonly Selector RasterSampleCount = "rasterSampleCount";

    public static readonly Selector RequiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetBinaryArchives = "setBinaryArchives:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetLinkedFunctions = "setLinkedFunctions:";

    public static readonly Selector SetMaxCallStackDepth = "setMaxCallStackDepth:";

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";

    public static readonly Selector SetPreloadedLibraries = "setPreloadedLibraries:";

    public static readonly Selector SetRasterSampleCount = "setRasterSampleCount:";

    public static readonly Selector SetRequiredThreadsPerThreadgroup = "setRequiredThreadsPerThreadgroup:";

    public static readonly Selector SetShaderValidation = "setShaderValidation:";

    public static readonly Selector SetSupportAddingBinaryFunctions = "setSupportAddingBinaryFunctions:";

    public static readonly Selector SetThreadgroupSizeMatchesTileSize = "setThreadgroupSizeMatchesTileSize:";

    public static readonly Selector SetTileFunction = "setTileFunction:";

    public static readonly Selector ShaderValidation = "shaderValidation";

    public static readonly Selector SupportAddingBinaryFunctions = "supportAddingBinaryFunctions";

    public static readonly Selector ThreadgroupSizeMatchesTileSize = "threadgroupSizeMatchesTileSize";

    public static readonly Selector TileBuffers = "tileBuffers";

    public static readonly Selector TileFunction = "tileFunction";
}
