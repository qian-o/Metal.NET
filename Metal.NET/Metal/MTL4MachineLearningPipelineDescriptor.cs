namespace Metal.NET;

public class MTL4MachineLearningPipelineDescriptor(nint nativePtr) : MTL4PipelineDescriptor(nativePtr)
{
    public MTL4MachineLearningPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4MachineLearningPipelineDescriptorSelector.Class))
    {
    }

    public new NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTL4FunctionDescriptor? MachineLearningFunctionDescriptor
    {
        get => GetNullableObject<MTL4FunctionDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.MachineLearningFunctionDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.SetMachineLearningFunctionDescriptor, value?.NativePtr ?? 0);
    }

    public MTLTensorExtents? InputDimensionsAtBufferIndex(nint bufferIndex)
    {
        return GetNullableObject<MTLTensorExtents>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.InputDimensionsAtBufferIndex, bufferIndex));
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.Reset);
    }

    public void SetInputDimensions(MTLTensorExtents dimensions, nint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.SetInputDimensions, dimensions.NativePtr, bufferIndex);
    }

    public void SetInputDimensions(NSArray dimensions, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.SetInputDimensions, dimensions.NativePtr, range);
    }
}

file static class MTL4MachineLearningPipelineDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4MachineLearningPipelineDescriptor");

    public static readonly Selector InputDimensionsAtBufferIndex = Selector.Register("inputDimensionsAtBufferIndex:");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector MachineLearningFunctionDescriptor = Selector.Register("machineLearningFunctionDescriptor");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetInputDimensions = Selector.Register("setInputDimensions:atBufferIndex:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetMachineLearningFunctionDescriptor = Selector.Register("setMachineLearningFunctionDescriptor:");
}
