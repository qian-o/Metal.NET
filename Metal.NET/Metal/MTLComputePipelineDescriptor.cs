namespace Metal.NET;

/// <summary>An instance describing the desired GPU state for a kernel call in a compute pass.</summary>
public class MTLComputePipelineDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLComputePipelineDescriptor>
{
    #region INativeObject
    public static new MTLComputePipelineDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLComputePipelineDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLComputePipelineDescriptor() : this(ObjectiveC.AllocInit(MTLComputePipelineDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Configuring the compute execution environment - Properties

    /// <summary>The compute kernel the pipeline calls.</summary>
    public MTLFunction ComputeFunction
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.ComputeFunction);
        set => SetProperty(ref field, MTLComputePipelineDescriptorBindings.SetComputeFunction, value);
    }

    /// <summary>A Boolean value that indicates whether the threadgroup size is always a multiple of the thread execution width.</summary>
    public Bool8 ThreadGroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLComputePipelineDescriptorBindings.ThreadGroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetThreadGroupSizeIsMultipleOfThreadExecutionWidth, value);
    }

    /// <summary>A property that limits the number of threads you can dispatch in a threadgroup for the compute function.</summary>
    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineDescriptorBindings.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetMaxTotalThreadsPerThreadgroup, value);
    }

    /// <summary>The maximum call stack depth for indirect function calls in compute shaders.</summary>
    public nuint MaxCallStackDepth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineDescriptorBindings.MaxCallStackDepth);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetMaxCallStackDepth, value);
    }
    #endregion

    #region Configuring compute pass inputs - Properties

    /// <summary>The organization of input and output data for the next kernel call.</summary>
    public MTLStageInputOutputDescriptor StageInputDescriptor
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.StageInputDescriptor);
        set => SetProperty(ref field, MTLComputePipelineDescriptorBindings.SetStageInputDescriptor, value);
    }
    #endregion

    #region Configuring buffer mutability - Properties

    /// <summary>The buffer mutability options to apply to the next kernel call.</summary>
    public MTLPipelineBufferDescriptorArray Buffers
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.Buffers);
    }
    #endregion

    #region Identifying the pipeline state object - Properties

    /// <summary>A string that identifies the instance.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.Label);
        set => SetProperty(ref field, MTLComputePipelineDescriptorBindings.SetLabel, value);
    }
    #endregion

    #region Configuring indirect command buffers - Properties

    /// <summary>A Boolean value that indicates whether you can encode commands that reference the pipeline state object into an indirect command buffer.</summary>
    public Bool8 SupportIndirectCommandBuffers
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLComputePipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetSupportIndirectCommandBuffers, value);
    }
    #endregion

    #region Configuring shader validation - Properties

    /// <summary>A value that enables or disables shader validation for the pipeline.</summary>
    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveC.MsgSendLong(NativePtr, MTLComputePipelineDescriptorBindings.ShaderValidation);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetShaderValidation, (nint)value);
    }
    #endregion

    #region Loading dynamic libraries to link at runtime - Properties

    /// <summary>The dynamic libraries that contain precompiled shader functions you want to link.</summary>
    public MTLDynamicLibrary[] PreloadedLibraries
    {
        get => GetArrayProperty<MTLDynamicLibrary>(MTLComputePipelineDescriptorBindings.PreloadedLibraries);
        set => SetArrayProperty(MTLComputePipelineDescriptorBindings.SetPreloadedLibraries, value);
    }

    /// <summary>The dynamic libraries that contain precompiled shader functions you want to link.</summary>
    [Obsolete("Use the preloadedLibraries property instead.")]
    public MTLDynamicLibrary[] InsertLibraries
    {
        get => GetArrayProperty<MTLDynamicLibrary>(MTLComputePipelineDescriptorBindings.InsertLibraries);
        set => SetArrayProperty(MTLComputePipelineDescriptorBindings.SetInsertLibraries, value);
    }
    #endregion

    #region Setting callable functions - Properties

    /// <summary>The functions with available function pointers for the next kernel call.</summary>
    public MTLLinkedFunctions LinkedFunctions
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.LinkedFunctions);
        set => SetProperty(ref field, MTLComputePipelineDescriptorBindings.SetLinkedFunctions, value);
    }
    #endregion

    #region Loading binary archives - Properties

    /// <summary>A Boolean value that indicates whether you can use the pipeline to create new pipelines by adding binary functions to its callable functions list.</summary>
    public Bool8 SupportAddingBinaryFunctions
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLComputePipelineDescriptorBindings.SupportAddingBinaryFunctions);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetSupportAddingBinaryFunctions, value);
    }

    /// <summary>The binary archives that contain any precompiled shader functions to link.</summary>
    public MTLBinaryArchive[] BinaryArchives
    {
        get => GetArrayProperty<MTLBinaryArchive>(MTLComputePipelineDescriptorBindings.BinaryArchives);
        set => SetArrayProperty(MTLComputePipelineDescriptorBindings.SetBinaryArchives, value);
    }
    #endregion

    #region Instance Properties - Properties

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLComputePipelineDescriptorBindings.RequiredThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetRequiredThreadsPerThreadgroup, value);
    }
    #endregion

    #region Reset to defaults - Methods

    /// <summary>Resets all compute pipeline descriptor properties to their default values.</summary>
    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.Reset);
    }
    #endregion
}

file static class MTLComputePipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLComputePipelineDescriptor");

    public static readonly Selector BinaryArchives = "binaryArchives";

    public static readonly Selector Buffers = "buffers";

    public static readonly Selector ComputeFunction = "computeFunction";

    public static readonly Selector InsertLibraries = "insertLibraries";

    public static readonly Selector Label = "label";

    public static readonly Selector LinkedFunctions = "linkedFunctions";

    public static readonly Selector MaxCallStackDepth = "maxCallStackDepth";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector PreloadedLibraries = "preloadedLibraries";

    public static readonly Selector RequiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetBinaryArchives = "setBinaryArchives:";

    public static readonly Selector SetComputeFunction = "setComputeFunction:";

    public static readonly Selector SetInsertLibraries = "setInsertLibraries:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetLinkedFunctions = "setLinkedFunctions:";

    public static readonly Selector SetMaxCallStackDepth = "setMaxCallStackDepth:";

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";

    public static readonly Selector SetPreloadedLibraries = "setPreloadedLibraries:";

    public static readonly Selector SetRequiredThreadsPerThreadgroup = "setRequiredThreadsPerThreadgroup:";

    public static readonly Selector SetShaderValidation = "setShaderValidation:";

    public static readonly Selector SetStageInputDescriptor = "setStageInputDescriptor:";

    public static readonly Selector SetSupportAddingBinaryFunctions = "setSupportAddingBinaryFunctions:";

    public static readonly Selector SetSupportIndirectCommandBuffers = "setSupportIndirectCommandBuffers:";

    public static readonly Selector SetThreadGroupSizeIsMultipleOfThreadExecutionWidth = "setThreadGroupSizeIsMultipleOfThreadExecutionWidth:";

    public static readonly Selector ShaderValidation = "shaderValidation";

    public static readonly Selector StageInputDescriptor = "stageInputDescriptor";

    public static readonly Selector SupportAddingBinaryFunctions = "supportAddingBinaryFunctions";

    public static readonly Selector SupportIndirectCommandBuffers = "supportIndirectCommandBuffers";

    public static readonly Selector ThreadGroupSizeIsMultipleOfThreadExecutionWidth = "threadGroupSizeIsMultipleOfThreadExecutionWidth";
}
