namespace Metal.NET;

public class MTL4ComputePipelineDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4PipelineDescriptor(nativePtr, ownership), INativeObject<MTL4ComputePipelineDescriptor>
{
    #region INativeObject
    public static new MTL4ComputePipelineDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4ComputePipelineDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4ComputePipelineDescriptor() : this(ObjectiveC.AllocInit(MTL4ComputePipelineDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTL4FunctionDescriptor ComputeFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4ComputePipelineDescriptorBindings.ComputeFunctionDescriptor);
        set => SetProperty(ref field, MTL4ComputePipelineDescriptorBindings.SetComputeFunctionDescriptor, value);
    }

    public Bool8 ThreadGroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4ComputePipelineDescriptorBindings.ThreadGroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetThreadGroupSizeIsMultipleOfThreadExecutionWidth, value);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4ComputePipelineDescriptorBindings.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetMaxTotalThreadsPerThreadgroup, value);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTL4ComputePipelineDescriptorBindings.RequiredThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetRequiredThreadsPerThreadgroup, value);
    }

    public Bool8 SupportBinaryLinking
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4ComputePipelineDescriptorBindings.SupportBinaryLinking);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetSupportBinaryLinking, value);
    }

    public MTL4StaticLinkingDescriptor StaticLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4ComputePipelineDescriptorBindings.StaticLinkingDescriptor);
        set => SetProperty(ref field, MTL4ComputePipelineDescriptorBindings.SetStaticLinkingDescriptor, value);
    }

    public MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers
    {
        get => (MTL4IndirectCommandBufferSupportState)ObjectiveC.MsgSendLong(NativePtr, MTL4ComputePipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetSupportIndirectCommandBuffers, (nint)value);
    }

    public MTLForwardProgressUsage ForwardProgressUsage
    {
        get => (MTLForwardProgressUsage)ObjectiveC.MsgSendLong(NativePtr, MTL4ComputePipelineDescriptorBindings.ForwardProgressUsage);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetForwardProgressUsage, (nint)value);
    }

    public MTLContentionRelief ContentionRelief
    {
        get => (MTLContentionRelief)ObjectiveC.MsgSendLong(NativePtr, MTL4ComputePipelineDescriptorBindings.ContentionRelief);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetContentionRelief, (nint)value);
    }

    public Bool8 OptimizeForPersistentKernel
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4ComputePipelineDescriptorBindings.OptimizeForPersistentKernel);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetOptimizeForPersistentKernel, value);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.Reset);
    }
}

file static class MTL4ComputePipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4ComputePipelineDescriptor");

    public static readonly Selector ComputeFunctionDescriptor = "computeFunctionDescriptor";

    public static readonly Selector ContentionRelief = "contentionRelief";

    public static readonly Selector ForwardProgressUsage = "forwardProgressUsage";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector OptimizeForPersistentKernel = "optimizeForPersistentKernel";

    public static readonly Selector RequiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetComputeFunctionDescriptor = "setComputeFunctionDescriptor:";

    public static readonly Selector SetContentionRelief = "setContentionRelief:";

    public static readonly Selector SetForwardProgressUsage = "setForwardProgressUsage:";

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";

    public static readonly Selector SetOptimizeForPersistentKernel = "setOptimizeForPersistentKernel:";

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
