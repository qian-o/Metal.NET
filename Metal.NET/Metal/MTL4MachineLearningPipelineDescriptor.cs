namespace Metal.NET;

public class MTL4MachineLearningPipelineDescriptor(nint nativePtr, bool owned) : MTL4PipelineDescriptor(nativePtr, owned)
{
    public MTL4MachineLearningPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4MachineLearningPipelineDescriptorBindings.Class), true)
    {
    }

    public MTL4FunctionDescriptor? MachineLearningFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4MachineLearningPipelineDescriptorBindings.MachineLearningFunctionDescriptor);
        set => SetProperty(ref field, MTL4MachineLearningPipelineDescriptorBindings.SetMachineLearningFunctionDescriptor, value);
    }

    public MTLTensorExtents? InputDimensionsAtBufferIndex(nint bufferIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.InputDimensionsAtBufferIndex, bufferIndex);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.Reset);
    }

    public void SetInputDimensions(MTLTensorExtents dimensions, nint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetInputDimensions, dimensions.NativePtr, bufferIndex);
    }

    public void SetInputDimensions(NSArray dimensions, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetInputDimensionswithRange, dimensions.NativePtr, range);
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
