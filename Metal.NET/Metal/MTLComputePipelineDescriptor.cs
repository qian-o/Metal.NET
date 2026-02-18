namespace Metal.NET;

public class MTLComputePipelineDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLComputePipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLComputePipelineDescriptorSelector.Class))
    {
    }

    public NSArray? BinaryArchives
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorSelector.BinaryArchives));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetBinaryArchives, value?.NativePtr ?? 0);
    }

    public MTLPipelineBufferDescriptorArray? Buffers
    {
        get => GetNullableObject<MTLPipelineBufferDescriptorArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorSelector.Buffers));
    }

    public MTLFunction? ComputeFunction
    {
        get => GetNullableObject<MTLFunction>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorSelector.ComputeFunction));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetComputeFunction, value?.NativePtr ?? 0);
    }

    public NSArray? InsertLibraries
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorSelector.InsertLibraries));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetInsertLibraries, value?.NativePtr ?? 0);
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTLLinkedFunctions? LinkedFunctions
    {
        get => GetNullableObject<MTLLinkedFunctions>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorSelector.LinkedFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetLinkedFunctions, value?.NativePtr ?? 0);
    }

    public nuint MaxCallStackDepth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineDescriptorSelector.MaxCallStackDepth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetMaxCallStackDepth, value);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputePipelineDescriptorSelector.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetMaxTotalThreadsPerThreadgroup, value);
    }

    public NSArray? PreloadedLibraries
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorSelector.PreloadedLibraries));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetPreloadedLibraries, value?.NativePtr ?? 0);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTLComputePipelineDescriptorSelector.RequiredThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetRequiredThreadsPerThreadgroup, value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorSelector.ShaderValidation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetShaderValidation, (nint)value);
    }

    public MTLStageInputOutputDescriptor? StageInputDescriptor
    {
        get => GetNullableObject<MTLStageInputOutputDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorSelector.StageInputDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetStageInputDescriptor, value?.NativePtr ?? 0);
    }

    public bool SupportAddingBinaryFunctions
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLComputePipelineDescriptorSelector.SupportAddingBinaryFunctions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetSupportAddingBinaryFunctions, (Bool8)value);
    }

    public bool SupportIndirectCommandBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLComputePipelineDescriptorSelector.SupportIndirectCommandBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetSupportIndirectCommandBuffers, (Bool8)value);
    }

    public bool ThreadGroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLComputePipelineDescriptorSelector.ThreadGroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetThreadGroupSizeIsMultipleOfThreadExecutionWidth, (Bool8)value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.Reset);
    }
}

file static class MTLComputePipelineDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePipelineDescriptor");

    public static readonly Selector BinaryArchives = Selector.Register("binaryArchives");

    public static readonly Selector Buffers = Selector.Register("buffers");

    public static readonly Selector ComputeFunction = Selector.Register("computeFunction");

    public static readonly Selector InsertLibraries = Selector.Register("insertLibraries");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector LinkedFunctions = Selector.Register("linkedFunctions");

    public static readonly Selector MaxCallStackDepth = Selector.Register("maxCallStackDepth");

    public static readonly Selector MaxTotalThreadsPerThreadgroup = Selector.Register("maxTotalThreadsPerThreadgroup");

    public static readonly Selector PreloadedLibraries = Selector.Register("preloadedLibraries");

    public static readonly Selector RequiredThreadsPerThreadgroup = Selector.Register("requiredThreadsPerThreadgroup");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");

    public static readonly Selector SetComputeFunction = Selector.Register("setComputeFunction:");

    public static readonly Selector SetInsertLibraries = Selector.Register("setInsertLibraries:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetLinkedFunctions = Selector.Register("setLinkedFunctions:");

    public static readonly Selector SetMaxCallStackDepth = Selector.Register("setMaxCallStackDepth:");

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = Selector.Register("setMaxTotalThreadsPerThreadgroup:");

    public static readonly Selector SetPreloadedLibraries = Selector.Register("setPreloadedLibraries:");

    public static readonly Selector SetRequiredThreadsPerThreadgroup = Selector.Register("setRequiredThreadsPerThreadgroup:");

    public static readonly Selector SetShaderValidation = Selector.Register("setShaderValidation:");

    public static readonly Selector SetStageInputDescriptor = Selector.Register("setStageInputDescriptor:");

    public static readonly Selector SetSupportAddingBinaryFunctions = Selector.Register("setSupportAddingBinaryFunctions:");

    public static readonly Selector SetSupportIndirectCommandBuffers = Selector.Register("setSupportIndirectCommandBuffers:");

    public static readonly Selector SetThreadGroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("setThreadGroupSizeIsMultipleOfThreadExecutionWidth:");

    public static readonly Selector ShaderValidation = Selector.Register("shaderValidation");

    public static readonly Selector StageInputDescriptor = Selector.Register("stageInputDescriptor");

    public static readonly Selector SupportAddingBinaryFunctions = Selector.Register("supportAddingBinaryFunctions");

    public static readonly Selector SupportIndirectCommandBuffers = Selector.Register("supportIndirectCommandBuffers");

    public static readonly Selector ThreadGroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("threadGroupSizeIsMultipleOfThreadExecutionWidth");
}
