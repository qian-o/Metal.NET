namespace Metal.NET;

public class MTLComputePipelineDescriptor : IDisposable
{
    public MTLComputePipelineDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLComputePipelineDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSArray BinaryArchives
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorSelector.BinaryArchives));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetBinaryArchives, value.NativePtr);
    }

    public MTLPipelineBufferDescriptorArray Buffers => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorSelector.Buffers));

    public MTLFunction ComputeFunction
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorSelector.ComputeFunction));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetComputeFunction, value.NativePtr);
    }

    public NSArray InsertLibraries
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorSelector.InsertLibraries));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetInsertLibraries, value.NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetLabel, value.NativePtr);
    }

    public MTLLinkedFunctions LinkedFunctions
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorSelector.LinkedFunctions));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetLinkedFunctions, value.NativePtr);
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

    public NSArray PreloadedLibraries
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorSelector.PreloadedLibraries));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetPreloadedLibraries, value.NativePtr);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLComputePipelineDescriptorSelector.ShaderValidation));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetShaderValidation, (uint)value);
    }

    public MTLStageInputOutputDescriptor StageInputDescriptor
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorSelector.StageInputDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetStageInputDescriptor, value.NativePtr);
    }

    public Bool8 SupportAddingBinaryFunctions
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLComputePipelineDescriptorSelector.SupportAddingBinaryFunctions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetSupportAddingBinaryFunctions, value);
    }

    public Bool8 SupportIndirectCommandBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLComputePipelineDescriptorSelector.SupportIndirectCommandBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetSupportIndirectCommandBuffers, value);
    }

    public Bool8 ThreadGroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLComputePipelineDescriptorSelector.ThreadGroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.SetThreadGroupSizeIsMultipleOfThreadExecutionWidth, value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorSelector.Reset);
    }

    public static implicit operator nint(MTLComputePipelineDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLComputePipelineDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

}

file class MTLComputePipelineDescriptorSelector
{
    public static readonly Selector BinaryArchives = Selector.Register("binaryArchives");

    public static readonly Selector SetBinaryArchives = Selector.Register("setBinaryArchives:");

    public static readonly Selector Buffers = Selector.Register("buffers");

    public static readonly Selector ComputeFunction = Selector.Register("computeFunction");

    public static readonly Selector SetComputeFunction = Selector.Register("setComputeFunction:");

    public static readonly Selector InsertLibraries = Selector.Register("insertLibraries");

    public static readonly Selector SetInsertLibraries = Selector.Register("setInsertLibraries:");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector LinkedFunctions = Selector.Register("linkedFunctions");

    public static readonly Selector SetLinkedFunctions = Selector.Register("setLinkedFunctions:");

    public static readonly Selector MaxCallStackDepth = Selector.Register("maxCallStackDepth");

    public static readonly Selector SetMaxCallStackDepth = Selector.Register("setMaxCallStackDepth:");

    public static readonly Selector MaxTotalThreadsPerThreadgroup = Selector.Register("maxTotalThreadsPerThreadgroup");

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = Selector.Register("setMaxTotalThreadsPerThreadgroup:");

    public static readonly Selector PreloadedLibraries = Selector.Register("preloadedLibraries");

    public static readonly Selector SetPreloadedLibraries = Selector.Register("setPreloadedLibraries:");

    public static readonly Selector RequiredThreadsPerThreadgroup = Selector.Register("requiredThreadsPerThreadgroup");

    public static readonly Selector SetRequiredThreadsPerThreadgroup = Selector.Register("setRequiredThreadsPerThreadgroup:");

    public static readonly Selector ShaderValidation = Selector.Register("shaderValidation");

    public static readonly Selector SetShaderValidation = Selector.Register("setShaderValidation:");

    public static readonly Selector StageInputDescriptor = Selector.Register("stageInputDescriptor");

    public static readonly Selector SetStageInputDescriptor = Selector.Register("setStageInputDescriptor:");

    public static readonly Selector SupportAddingBinaryFunctions = Selector.Register("supportAddingBinaryFunctions");

    public static readonly Selector SetSupportAddingBinaryFunctions = Selector.Register("setSupportAddingBinaryFunctions:");

    public static readonly Selector SupportIndirectCommandBuffers = Selector.Register("supportIndirectCommandBuffers");

    public static readonly Selector SetSupportIndirectCommandBuffers = Selector.Register("setSupportIndirectCommandBuffers:");

    public static readonly Selector ThreadGroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("threadGroupSizeIsMultipleOfThreadExecutionWidth");

    public static readonly Selector SetThreadGroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("setThreadGroupSizeIsMultipleOfThreadExecutionWidth:");

    public static readonly Selector Reset = Selector.Register("reset");
}
