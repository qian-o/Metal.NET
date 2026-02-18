namespace Metal.NET;

public partial class MTL4MachineLearningPipelineDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4MachineLearningPipelineDescriptor");

    public MTL4MachineLearningPipelineDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTL4FunctionDescriptor? MachineLearningFunctionDescriptor
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.MachineLearningFunctionDescriptor);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.SetMachineLearningFunctionDescriptor, value?.NativePtr ?? 0);
    }

    public MTLTensorExtents? InputDimensionsAtBufferIndex(nint bufferIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.InputDimensionsAtBufferIndex, bufferIndex);
        return ptr is not 0 ? new(ptr) : null;
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.Reset);
    }

    public void SetInputDimensions(MTLTensorExtents dimensions, nint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.SetInputDimensions, dimensions.NativePtr, bufferIndex);
    }
}

file static class MTL4MachineLearningPipelineDescriptorSelector
{
    public static readonly Selector InputDimensionsAtBufferIndex = Selector.Register("inputDimensionsAtBufferIndex:");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector MachineLearningFunctionDescriptor = Selector.Register("machineLearningFunctionDescriptor");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetInputDimensions = Selector.Register("setInputDimensions::");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetMachineLearningFunctionDescriptor = Selector.Register("setMachineLearningFunctionDescriptor:");
}
