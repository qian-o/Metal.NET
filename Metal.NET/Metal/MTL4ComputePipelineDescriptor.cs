namespace Metal.NET;

/// <summary>Describes a compute pipeline state.</summary>
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

    #region Instance Properties - Properties

    /// <summary>A descriptor representing the compute pipeline’s function.</summary>
    public MTL4FunctionDescriptor ComputeFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4ComputePipelineDescriptorBindings.ComputeFunctionDescriptor);
        set => SetProperty(ref field, MTL4ComputePipelineDescriptorBindings.SetComputeFunctionDescriptor, value);
    }

    /// <summary>The maximum total number of threads that Metal can execute in a single threadgroup for the compute function.</summary>
    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4ComputePipelineDescriptorBindings.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetMaxTotalThreadsPerThreadgroup, value);
    }

    /// <summary>The required number of threads per threadgroup for compute dispatches.</summary>
    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTL4ComputePipelineDescriptorBindings.RequiredThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetRequiredThreadsPerThreadgroup, value);
    }

    /// <summary>An object that contains information about functions to link to the compute pipeline.</summary>
    public MTL4StaticLinkingDescriptor StaticLinkingDescriptor
    {
        get => GetProperty(ref field, MTL4ComputePipelineDescriptorBindings.StaticLinkingDescriptor);
        set => SetProperty(ref field, MTL4ComputePipelineDescriptorBindings.SetStaticLinkingDescriptor, value);
    }

    /// <summary>A boolean value indicating whether the compute pipeline supports linking binary functions.</summary>
    public Bool8 SupportBinaryLinking
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4ComputePipelineDescriptorBindings.SupportBinaryLinking);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetSupportBinaryLinking, value);
    }

    /// <summary>A value indicating whether the pipeline supports Metal indirect command buffers.</summary>
    public MTL4IndirectCommandBufferSupportState SupportIndirectCommandBuffers
    {
        get => (MTL4IndirectCommandBufferSupportState)ObjectiveC.MsgSendLong(NativePtr, MTL4ComputePipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetSupportIndirectCommandBuffers, (nint)value);
    }

    /// <summary>A boolean value indicating whether each dimension of the threadgroup size is a multiple of its corresponding thread execution width.</summary>
    public Bool8 ThreadGroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4ComputePipelineDescriptorBindings.ThreadGroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.SetThreadGroupSizeIsMultipleOfThreadExecutionWidth, value);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>Resets the descriptor to its default values.</summary>
    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4ComputePipelineDescriptorBindings.Reset);
    }
    #endregion
}

file static class MTL4ComputePipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4ComputePipelineDescriptor");

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
