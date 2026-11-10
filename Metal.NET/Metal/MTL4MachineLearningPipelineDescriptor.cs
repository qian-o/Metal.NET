namespace Metal.NET;

public readonly struct MTL4MachineLearningPipelineDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTL4PipelineDescriptor(MTL4MachineLearningPipelineDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4MachineLearningPipelineDescriptor value) => new(value.NativePtr);

    public MTL4MachineLearningPipelineDescriptor() : this(ObjectiveC.AllocInit(MTL4MachineLearningPipelineDescriptorBindings.Class))
    {
    }

    public MTL4MachineLearningPipelineDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetLabel, value.NativePtr);
    }

    public MTL4FunctionDescriptor MachineLearningFunctionDescriptor
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.MachineLearningFunctionDescriptor));
        set => ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetMachineLearningFunctionDescriptor, value.NativePtr);
    }

    public MTL4PipelineOptions Options
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.Options));
        set => ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetOptions, value.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetLabel, label.NativePtr);
    }

    public void SetInputDimensions(MTLTensorExtents dimensions, nint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetInputDimensions_AtBufferIndex, dimensions.NativePtr, bufferIndex);
    }

    public void SetInputDimensions(NSArray<MTLTensorExtents> dimensions, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.SetInputDimensions_WithRange, dimensions.NativePtr, range);
    }

    public MTLTensorExtents InputDimensions(nint bufferIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4MachineLearningPipelineDescriptorBindings.InputDimensionsAtBufferIndex, bufferIndex);

        return new(nativePtr);
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

    public static readonly Selector Label = "label";

    public static readonly Selector MachineLearningFunctionDescriptor = "machineLearningFunctionDescriptor";

    public static readonly Selector Options = "options";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetInputDimensions_AtBufferIndex = "setInputDimensions:atBufferIndex:";

    public static readonly Selector SetInputDimensions_WithRange = "setInputDimensions:withRange:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetMachineLearningFunctionDescriptor = "setMachineLearningFunctionDescriptor:";

    public static readonly Selector SetOptions = "setOptions:";
}
