namespace Metal.NET;

public class MTL4MachineLearningPipelineDescriptor(nint nativePtr) : MTL4PipelineDescriptor(nativePtr)
{
    public MTL4MachineLearningPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4MachineLearningPipelineDescriptorBindings.Class))
    {
    }

    public new NSString? Label
    {
        get => GetProperty(ref field, MTL4MachineLearningPipelineDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4MachineLearningPipelineDescriptorBindings.SetLabel, value);
    }

    public MTL4FunctionDescriptor? MachineLearningFunctionDescriptor
    {
        get => GetProperty(ref field, MTL4MachineLearningPipelineDescriptorBindings.MachineLearningFunctionDescriptor);
        set => SetProperty(ref field, MTL4MachineLearningPipelineDescriptorBindings.SetMachineLearningFunctionDescriptor, value);
    }

    public MTLTensorExtents? InputDimensionsAtBufferIndex(nint bufferIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.InputDimensionsAtBufferIndex, bufferIndex);

        if (nativePtr is 0)
        {
            return null;
        }

        ObjectiveCRuntime.Retain(nativePtr);

        return new(nativePtr);
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

    public static readonly Selector Label = "label";

    public static readonly Selector MachineLearningFunctionDescriptor = "machineLearningFunctionDescriptor";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetInputDimensions = "setInputDimensions:atBufferIndex:";

    public static readonly Selector SetInputDimensionswithRange = "setInputDimensions:withRange:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetMachineLearningFunctionDescriptor = "setMachineLearningFunctionDescriptor:";
}
