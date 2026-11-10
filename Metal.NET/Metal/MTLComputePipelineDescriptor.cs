namespace Metal.NET;

public readonly struct MTLComputePipelineDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLComputePipelineDescriptor value) => new(value.NativePtr);

    public MTLComputePipelineDescriptor() : this(ObjectiveC.AllocInit(MTLComputePipelineDescriptorBindings.Class))
    {
    }

    public MTLComputePipelineDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTLFunction ComputeFunction
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineDescriptorBindings.ComputeFunction));
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetComputeFunction, value.NativePtr);
    }

    public Bool8 ThreadGroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLComputePipelineDescriptorBindings.ThreadGroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetThreadGroupSizeIsMultipleOfThreadExecutionWidth, value);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineDescriptorBindings.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetMaxTotalThreadsPerThreadgroup, value);
    }

    public MTLStageInputOutputDescriptor StageInputDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineDescriptorBindings.StageInputDescriptor));
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetStageInputDescriptor, value.NativePtr);
    }

    public MTLPipelineBufferDescriptorArray Buffers
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineDescriptorBindings.Buffers));
    }

    public Bool8 SupportIndirectCommandBuffers
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLComputePipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetSupportIndirectCommandBuffers, value);
    }

    /// <summary>
    /// Deprecated: Use preloadedLibraries instead
    /// </summary>
    [Obsolete("Use preloadedLibraries instead")]
    public NSArray<MTLDynamicLibrary> InsertLibraries
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineDescriptorBindings.InsertLibraries));
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetInsertLibraries, value.NativePtr);
    }

    public NSArray<MTLDynamicLibrary> PreloadedLibraries
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineDescriptorBindings.PreloadedLibraries));
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetPreloadedLibraries, value.NativePtr);
    }

    public NSArray<MTLBinaryArchive> BinaryArchives
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineDescriptorBindings.BinaryArchives));
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetBinaryArchives, value.NativePtr);
    }

    public MTLLinkedFunctions LinkedFunctions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineDescriptorBindings.LinkedFunctions));
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetLinkedFunctions, value.NativePtr);
    }

    public Bool8 SupportAddingBinaryFunctions
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLComputePipelineDescriptorBindings.SupportAddingBinaryFunctions);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetSupportAddingBinaryFunctions, value);
    }

    public nuint MaxCallStackDepth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineDescriptorBindings.MaxCallStackDepth);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetMaxCallStackDepth, value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveC.MsgSendLong(NativePtr, MTLComputePipelineDescriptorBindings.ShaderValidation);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetShaderValidation, (nint)value);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLComputePipelineDescriptorBindings.RequiredThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetRequiredThreadsPerThreadgroup, value);
    }

    public MTLForwardProgressUsage ForwardProgressUsage
    {
        get => (MTLForwardProgressUsage)ObjectiveC.MsgSendLong(NativePtr, MTLComputePipelineDescriptorBindings.ForwardProgressUsage);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetForwardProgressUsage, (nint)value);
    }

    public MTLContentionRelief ContentionRelief
    {
        get => (MTLContentionRelief)ObjectiveC.MsgSendLong(NativePtr, MTLComputePipelineDescriptorBindings.ContentionRelief);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetContentionRelief, (nint)value);
    }

    public Bool8 OptimizeForPersistentKernel
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLComputePipelineDescriptorBindings.OptimizeForPersistentKernel);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetOptimizeForPersistentKernel, value);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.Reset);
    }
}

file static class MTLComputePipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLComputePipelineDescriptor");

    public static readonly Selector BinaryArchives = "binaryArchives";

    public static readonly Selector Buffers = "buffers";

    public static readonly Selector ComputeFunction = "computeFunction";

    public static readonly Selector ContentionRelief = "contentionRelief";

    public static readonly Selector ForwardProgressUsage = "forwardProgressUsage";

    public static readonly Selector InsertLibraries = "insertLibraries";

    public static readonly Selector Label = "label";

    public static readonly Selector LinkedFunctions = "linkedFunctions";

    public static readonly Selector MaxCallStackDepth = "maxCallStackDepth";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector OptimizeForPersistentKernel = "optimizeForPersistentKernel";

    public static readonly Selector PreloadedLibraries = "preloadedLibraries";

    public static readonly Selector RequiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetBinaryArchives = "setBinaryArchives:";

    public static readonly Selector SetComputeFunction = "setComputeFunction:";

    public static readonly Selector SetContentionRelief = "setContentionRelief:";

    public static readonly Selector SetForwardProgressUsage = "setForwardProgressUsage:";

    public static readonly Selector SetInsertLibraries = "setInsertLibraries:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetLinkedFunctions = "setLinkedFunctions:";

    public static readonly Selector SetMaxCallStackDepth = "setMaxCallStackDepth:";

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";

    public static readonly Selector SetOptimizeForPersistentKernel = "setOptimizeForPersistentKernel:";

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
