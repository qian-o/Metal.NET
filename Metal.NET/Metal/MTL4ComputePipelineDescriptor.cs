namespace Metal.NET;

public readonly struct MTL4ComputePipelineDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTL4PipelineDescriptor(MTL4ComputePipelineDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4ComputePipelineDescriptor value) => new(value.NativePtr);

    public MTL4ComputePipelineDescriptor() : this(ObjectiveC.AllocInit(MTL4ComputePipelineDescriptorBindings.Class))
    {
    }

    public MTL4ComputePipelineDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTL4FunctionDescriptor ComputeFunctionDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4ComputePipelineDescriptorBindings.ComputeFunctionDescriptor));
        set => ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetComputeFunctionDescriptor, value.NativePtr);
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
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4ComputePipelineDescriptorBindings.StaticLinkingDescriptor));
        set => ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetStaticLinkingDescriptor, value.NativePtr);
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

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4ComputePipelineDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTL4PipelineOptions Options
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4ComputePipelineDescriptorBindings.Options));
        set => ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetOptions, value.NativePtr);
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

    public static readonly Selector Label = "label";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector OptimizeForPersistentKernel = "optimizeForPersistentKernel";

    public static readonly Selector Options = "options";

    public static readonly Selector RequiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetComputeFunctionDescriptor = "setComputeFunctionDescriptor:";

    public static readonly Selector SetContentionRelief = "setContentionRelief:";

    public static readonly Selector SetForwardProgressUsage = "setForwardProgressUsage:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";

    public static readonly Selector SetOptimizeForPersistentKernel = "setOptimizeForPersistentKernel:";

    public static readonly Selector SetOptions = "setOptions:";

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
