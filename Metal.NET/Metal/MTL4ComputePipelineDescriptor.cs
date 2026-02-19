namespace Metal.NET;

public readonly struct MTL4ComputePipelineDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4ComputePipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4ComputePipelineDescriptorBindings.Class))
    {
    }

    public MTL4FunctionDescriptor? ComputeFunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ComputePipelineDescriptorBindings.ComputeFunctionDescriptor);
            return ptr is not 0 ? new MTL4FunctionDescriptor(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetComputeFunctionDescriptor, value?.NativePtr ?? 0);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4ComputePipelineDescriptorBindings.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetMaxTotalThreadsPerThreadgroup, value);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTL4ComputePipelineDescriptorBindings.RequiredThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetRequiredThreadsPerThreadgroup, value);
    }

    public MTL4StaticLinkingDescriptor? StaticLinkingDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ComputePipelineDescriptorBindings.StaticLinkingDescriptor);
            return ptr is not 0 ? new MTL4StaticLinkingDescriptor(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetStaticLinkingDescriptor, value?.NativePtr ?? 0);
    }

    public bool SupportBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4ComputePipelineDescriptorBindings.SupportBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetSupportBinaryLinking, (Bool8)value);
    }

    public MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers
    {
        get => (MTL4IndirectCommandBufferSupportState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ComputePipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetSupportIndirectCommandBuffers, (nint)value);
    }

    public bool ThreadGroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4ComputePipelineDescriptorBindings.ThreadGroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetThreadGroupSizeIsMultipleOfThreadExecutionWidth, (Bool8)value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.Reset);
    }
}

file static class MTL4ComputePipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4ComputePipelineDescriptor");

    public static readonly Selector ComputeFunctionDescriptor = Selector.Register("computeFunctionDescriptor");

    public static readonly Selector MaxTotalThreadsPerThreadgroup = Selector.Register("maxTotalThreadsPerThreadgroup");

    public static readonly Selector RequiredThreadsPerThreadgroup = Selector.Register("requiredThreadsPerThreadgroup");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetComputeFunctionDescriptor = Selector.Register("setComputeFunctionDescriptor:");

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = Selector.Register("setMaxTotalThreadsPerThreadgroup:");

    public static readonly Selector SetRequiredThreadsPerThreadgroup = Selector.Register("setRequiredThreadsPerThreadgroup:");

    public static readonly Selector SetStaticLinkingDescriptor = Selector.Register("setStaticLinkingDescriptor:");

    public static readonly Selector SetSupportBinaryLinking = Selector.Register("setSupportBinaryLinking:");

    public static readonly Selector SetSupportIndirectCommandBuffers = Selector.Register("setSupportIndirectCommandBuffers:");

    public static readonly Selector SetThreadGroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("setThreadGroupSizeIsMultipleOfThreadExecutionWidth:");

    public static readonly Selector StaticLinkingDescriptor = Selector.Register("staticLinkingDescriptor");

    public static readonly Selector SupportBinaryLinking = Selector.Register("supportBinaryLinking");

    public static readonly Selector SupportIndirectCommandBuffers = Selector.Register("supportIndirectCommandBuffers");

    public static readonly Selector ThreadGroupSizeIsMultipleOfThreadExecutionWidth = Selector.Register("threadGroupSizeIsMultipleOfThreadExecutionWidth");
}
