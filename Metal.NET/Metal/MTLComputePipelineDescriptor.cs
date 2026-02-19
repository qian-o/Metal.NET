namespace Metal.NET;

public class MTLComputePipelineDescriptor(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public MTLComputePipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLComputePipelineDescriptorBindings.Class), false)
    {
    }

    public NSArray? BinaryArchives
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.BinaryArchives);
        set => SetProperty(ref field, MTLComputePipelineDescriptorBindings.SetBinaryArchives, value);
    }

    public MTLPipelineBufferDescriptorArray? Buffers
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.Buffers);
    }

    public MTLFunction? ComputeFunction
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.ComputeFunction);
        set => SetProperty(ref field, MTLComputePipelineDescriptorBindings.SetComputeFunction, value);
    }

    public NSArray? InsertLibraries
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.InsertLibraries);
        set => SetProperty(ref field, MTLComputePipelineDescriptorBindings.SetInsertLibraries, value);
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.Label);
        set => SetProperty(ref field, MTLComputePipelineDescriptorBindings.SetLabel, value);
    }

    public MTLLinkedFunctions? LinkedFunctions
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.LinkedFunctions);
        set => SetProperty(ref field, MTLComputePipelineDescriptorBindings.SetLinkedFunctions, value);
    }

    public nuint MaxCallStackDepth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineDescriptorBindings.MaxCallStackDepth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetMaxCallStackDepth, value);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineDescriptorBindings.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetMaxTotalThreadsPerThreadgroup, value);
    }

    public NSArray? PreloadedLibraries
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.PreloadedLibraries);
        set => SetProperty(ref field, MTLComputePipelineDescriptorBindings.SetPreloadedLibraries, value);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLComputePipelineDescriptorBindings.RequiredThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetRequiredThreadsPerThreadgroup, value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorBindings.ShaderValidation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetShaderValidation, (nint)value);
    }

    public MTLStageInputOutputDescriptor? StageInputDescriptor
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.StageInputDescriptor);
        set => SetProperty(ref field, MTLComputePipelineDescriptorBindings.SetStageInputDescriptor, value);
    }

    public bool SupportAddingBinaryFunctions
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLComputePipelineDescriptorBindings.SupportAddingBinaryFunctions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetSupportAddingBinaryFunctions, (Bool8)value);
    }

    public bool SupportIndirectCommandBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLComputePipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetSupportIndirectCommandBuffers, (Bool8)value);
    }

    public bool ThreadGroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLComputePipelineDescriptorBindings.ThreadGroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetThreadGroupSizeIsMultipleOfThreadExecutionWidth, (Bool8)value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.Reset);
    }
}

file static class MTLComputePipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePipelineDescriptor");

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
