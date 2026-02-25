namespace Metal.NET;

public class MTL4MachineLearningPipelineDescriptor(nint nativePtr, bool ownsReference) : MTL4PipelineDescriptor(nativePtr, ownsReference), INativeObject<MTL4MachineLearningPipelineDescriptor>
{
    public static new MTL4MachineLearningPipelineDescriptor Null { get; } = new(0, false);

    public static new MTL4MachineLearningPipelineDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTL4MachineLearningPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4MachineLearningPipelineDescriptorBindings.Class), true)
    {
    }

    public MTL4FunctionDescriptor MachineLearningFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4MachineLearningPipelineDescriptorBindings.MachineLearningFunctionDescriptor);
        set => SetProperty(ref field, MTL4MachineLearningPipelineDescriptorBindings.SetMachineLearningFunctionDescriptor, value);
    }

    public MTLTensorExtents InputDimensionsAtBufferIndex(nint bufferIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.InputDimensionsAtBufferIndex, bufferIndex);

        ObjectiveCRuntime.Retain(nativePtr);

        return new(nativePtr, true);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.Reset);
    }

    public void SetInputDimensions(MTLTensorExtents dimensions, nint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetInputDimensions, dimensions.NativePtr, bufferIndex);
    }

    public void SetInputDimensions(MTLTensorExtents[] dimensions, NSRange range)
    {
        nint pDimensions = NSArray.FromArray(dimensions);

        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetInputDimensionswithRange, pDimensions, range);

        ObjectiveCRuntime.Release(pDimensions);
    }
}

file static class MTL4MachineLearningPipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4MachineLearningPipelineDescriptor");

    public static readonly Selector InputDimensionsAtBufferIndex = "inputDimensionsAtBufferIndex:";

    public static readonly Selector MachineLearningFunctionDescriptor = "machineLearningFunctionDescriptor";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetInputDimensions = "setInputDimensions:atBufferIndex:";

    public static readonly Selector SetInputDimensionswithRange = "setInputDimensions:withRange:";

    public static readonly Selector SetMachineLearningFunctionDescriptor = "setMachineLearningFunctionDescriptor:";
}
