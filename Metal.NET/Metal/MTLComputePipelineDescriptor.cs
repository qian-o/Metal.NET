namespace Metal.NET;

public readonly struct MTLComputePipelineDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLComputePipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLComputePipelineDescriptorBindings.Class))
    {
    }

    public NSArray? BinaryArchives
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorBindings.BinaryArchives);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetBinaryArchives, value?.NativePtr ?? 0);
    }

    public MTLPipelineBufferDescriptorArray? Buffers
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorBindings.Buffers);
            return ptr is not 0 ? new MTLPipelineBufferDescriptorArray(ptr) : default;
        }
    }

    public MTLFunction? ComputeFunction
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorBindings.ComputeFunction);
            return ptr is not 0 ? new MTLFunction(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetComputeFunction, value?.NativePtr ?? 0);
    }

    public NSArray? InsertLibraries
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorBindings.InsertLibraries);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetInsertLibraries, value?.NativePtr ?? 0);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
    }

    public MTLLinkedFunctions? LinkedFunctions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorBindings.LinkedFunctions);
            return ptr is not 0 ? new MTLLinkedFunctions(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetLinkedFunctions, value?.NativePtr ?? 0);
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
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorBindings.PreloadedLibraries);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetPreloadedLibraries, value?.NativePtr ?? 0);
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
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineDescriptorBindings.StageInputDescriptor);
            return ptr is not 0 ? new MTLStageInputOutputDescriptor(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetStageInputDescriptor, value?.NativePtr ?? 0);
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
