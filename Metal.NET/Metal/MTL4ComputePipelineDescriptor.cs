namespace Metal.NET;

public class MTL4ComputePipelineDescriptor(nint nativePtr) : MTL4PipelineDescriptor(nativePtr)
{
    public MTL4ComputePipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4ComputePipelineDescriptorSelector.Class))
    {
    }

    public MTL4FunctionDescriptor? ComputeFunctionDescriptor
    {
        get => GetNullableObject<MTL4FunctionDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ComputePipelineDescriptorSelector.ComputeFunctionDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorSelector.SetComputeFunctionDescriptor, value?.NativePtr ?? 0);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4ComputePipelineDescriptorSelector.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorSelector.SetMaxTotalThreadsPerThreadgroup, value);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveCRuntime.MsgSendMTLSize(NativePtr, MTL4ComputePipelineDescriptorSelector.RequiredThreadsPerThreadgroup);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorSelector.SetRequiredThreadsPerThreadgroup, value);
    }

    public MTL4StaticLinkingDescriptor? StaticLinkingDescriptor
    {
        get => GetNullableObject<MTL4StaticLinkingDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ComputePipelineDescriptorSelector.StaticLinkingDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorSelector.SetStaticLinkingDescriptor, value?.NativePtr ?? 0);
    }

    public bool SupportBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4ComputePipelineDescriptorSelector.SupportBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorSelector.SetSupportBinaryLinking, (Bool8)value);
    }

    public MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers
    {
        get => (MTL4IndirectCommandBufferSupportState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ComputePipelineDescriptorSelector.SupportIndirectCommandBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorSelector.SetSupportIndirectCommandBuffers, (nint)value);
    }

    public bool ThreadGroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4ComputePipelineDescriptorSelector.ThreadGroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorSelector.SetThreadGroupSizeIsMultipleOfThreadExecutionWidth, (Bool8)value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorSelector.Reset);
    }
}

file static class MTL4ComputePipelineDescriptorSelector
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
