namespace Metal.NET;

public class MTLComputePipelineDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLComputePipelineDescriptor>
{
    #region INativeObject
    public static new MTLComputePipelineDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLComputePipelineDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLComputePipelineDescriptor() : this(ObjectiveC.AllocInit(MTLComputePipelineDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.Label);
        set => SetProperty(ref field, MTLComputePipelineDescriptorBindings.SetLabel, value);
    }

    public MTLFunction ComputeFunction
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.ComputeFunction);
        set => SetProperty(ref field, MTLComputePipelineDescriptorBindings.SetComputeFunction, value);
    }

    public Bool8 ThreadGroupSizeIsMultipleOfThreadExecutionWidth
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLComputePipelineDescriptorBindings.ThreadGroupSizeIsMultipleOfThreadExecutionWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetThreadGroupSizeIsMultipleOfThreadExecutionWidth, value);
    }

    public nuint MaxTotalThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineDescriptorBindings.MaxTotalThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetMaxTotalThreadsPerThreadgroup, value);
    }

    public MTLStageInputOutputDescriptor StageInputDescriptor
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.StageInputDescriptor);
        set => SetProperty(ref field, MTLComputePipelineDescriptorBindings.SetStageInputDescriptor, value);
    }

    public MTLPipelineBufferDescriptorArray Buffers
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.Buffers);
    }

    public Bool8 SupportIndirectCommandBuffers
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLComputePipelineDescriptorBindings.SupportIndirectCommandBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetSupportIndirectCommandBuffers, value);
    }

    public MTLLinkedFunctions LinkedFunctions
    {
        get => GetProperty(ref field, MTLComputePipelineDescriptorBindings.LinkedFunctions);
        set => SetProperty(ref field, MTLComputePipelineDescriptorBindings.SetLinkedFunctions, value);
    }

    public Bool8 SupportAddingBinaryFunctions
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLComputePipelineDescriptorBindings.SupportAddingBinaryFunctions);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetSupportAddingBinaryFunctions, value);
    }

    public nuint MaxCallStackDepth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLComputePipelineDescriptorBindings.MaxCallStackDepth);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetMaxCallStackDepth, value);
    }

    public MTLShaderValidation ShaderValidation
    {
        get => (MTLShaderValidation)ObjectiveC.MsgSendLong(NativePtr, MTLComputePipelineDescriptorBindings.ShaderValidation);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetShaderValidation, (nint)value);
    }

    public MTLSize RequiredThreadsPerThreadgroup
    {
        get => ObjectiveC.MsgSendMTLSize(NativePtr, MTLComputePipelineDescriptorBindings.RequiredThreadsPerThreadgroup);
        set => ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.SetRequiredThreadsPerThreadgroup, value);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputePipelineDescriptorBindings.Reset);
    }
}

file static class MTLComputePipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLComputePipelineDescriptor");

    public static readonly Selector Buffers = "buffers";

    public static readonly Selector ComputeFunction = "computeFunction";

    public static readonly Selector Label = "label";

    public static readonly Selector LinkedFunctions = "linkedFunctions";

    public static readonly Selector MaxCallStackDepth = "maxCallStackDepth";

    public static readonly Selector MaxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";

    public static readonly Selector RequiredThreadsPerThreadgroup = "requiredThreadsPerThreadgroup";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetComputeFunction = "setComputeFunction:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetLinkedFunctions = "setLinkedFunctions:";

    public static readonly Selector SetMaxCallStackDepth = "setMaxCallStackDepth:";

    public static readonly Selector SetMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";

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
