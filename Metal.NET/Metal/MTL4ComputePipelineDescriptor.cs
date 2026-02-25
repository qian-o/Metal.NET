namespace Metal.NET;

public class MTL4ComputePipelineDescriptor(nint nativePtr, bool ownsReference) : MTL4PipelineDescriptor(nativePtr, ownsReference), INativeObject<MTL4ComputePipelineDescriptor>
{
    public static new MTL4ComputePipelineDescriptor Create(nint nativePtr) => new(nativePtr, true);

    public static new MTL4ComputePipelineDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTL4ComputePipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4ComputePipelineDescriptorBindings.Class), true)
    {
    }

    public MTL4FunctionDescriptor ComputeFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4ComputePipelineDescriptorBindings.ComputeFunctionDescriptor);
        set => SetProperty(ref field, MTL4ComputePipelineDescriptorBindings.SetComputeFunctionDescriptor, value);
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

    public MTL4StaticLinkingDescriptor StaticLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4ComputePipelineDescriptorBindings.StaticLinkingDescriptor);
        set => SetProperty(ref field, MTL4ComputePipelineDescriptorBindings.SetStaticLinkingDescriptor, value);
    }

    public Bool8 SupportBinaryLinking
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4ComputePipelineDescriptorBindings.SupportBinaryLinking);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetSupportBinaryLinking, value);
    }

    public MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers
    {
        get => (MTL4IndirectCommandBufferSupportState)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4ComputePipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetSupportIndirectCommandBuffers, (nint)value);
    }

    public Bool8 ThreadGroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4ComputePipelineDescriptorBindings.ThreadGroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetThreadGroupSizeIsMultipleOfThreadExecutionWidth, value);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.Reset);
    }
}

file static class MTL4ComputePipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4ComputePipelineDescriptor");

    public static readonly Selector ComputeFunctionDescriptor = "computeFunctionDescriptor";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector RequiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetComputeFunctionDescriptor = "setComputeFunctionDescriptor:";

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";

    public static readonly Selector SetRequiredThreadsPerThreadgroup = "setRequiredThreadsPerThreadgroup:";

    public static readonly Selector SetStaticLinkingDescriptor = "setStaticLinkingDescriptor:";

    public static readonly Selector SetSupportBinaryLinking = "setSupportBinaryLinking:";

    public static readonly Selector SetSupportIndirectCommandBuffers = "setSupportIndirectCommandBuffers:";

    public static readonly Selector SetThreadGroupSizeIsMultipleOfThreadExecutionWidth = "setThreadGroupSizeIsMultipleOfThreadExecutionWidth:";

    public static readonly Selector StaticLinkingDescriptor = "staticLinkingDescriptor";

    public static readonly Selector SupportBinaryLinking = "supportBinaryLinking";

    public static readonly Selector SupportIndirectCommandBuffers = "supportIndirectCommandBuffers";

    public static readonly Selector ThreadGroupSizeIsMultipleOfThreadExecutionWidth = "threadGroupSizeIsMultipleOfThreadExecutionWidth";
}
