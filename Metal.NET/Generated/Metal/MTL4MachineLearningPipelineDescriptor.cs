namespace Metal.NET;

public partial class MTL4MachineLearningPipelineDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTL4PipelineDescriptor(nativePtr, ownership), INativeObject<MTL4MachineLearningPipelineDescriptor>
{
    #region INativeObject
    public static new MTL4MachineLearningPipelineDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4MachineLearningPipelineDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4MachineLearningPipelineDescriptor() : this(ObjectiveC.AllocInit(MTL4MachineLearningPipelineDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTL4FunctionDescriptor MachineLearningFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4MachineLearningPipelineDescriptorBindings.MachineLearningFunctionDescriptor);
        set => SetProperty(ref field, MTL4MachineLearningPipelineDescriptorBindings.SetMachineLearningFunctionDescriptor, value);
    }

    public void SetInputDimensions(MTLTensorExtents dimensions, nint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetInputDimensions_AtBufferIndex, dimensions.NativePtr, bufferIndex);
    }

    public void SetInputDimensions(MTLTensorExtents[] dimensions, NSRange range)
    {
        nint pDimensions = NSArray.FromArray(dimensions);

        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetInputDimensions_WithRange, pDimensions, range);

        ObjectiveC.Release(pDimensions);
    }

    public MTLTensorExtents InputDimensions(nint bufferIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.InputDimensionsAtBufferIndex, bufferIndex);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.Reset);
    }
}

file static class MTL4MachineLearningPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4MachineLearningPipelineDescriptor");

    public static readonly Selector InputDimensionsAtBufferIndex = "inputDimensionsAtBufferIndex:";

    public static readonly Selector MachineLearningFunctionDescriptor = "machineLearningFunctionDescriptor";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetInputDimensions_AtBufferIndex = "setInputDimensions:atBufferIndex:";

    public static readonly Selector SetInputDimensions_WithRange = "setInputDimensions:withRange:";

    public static readonly Selector SetMachineLearningFunctionDescriptor = "setMachineLearningFunctionDescriptor:";
}
