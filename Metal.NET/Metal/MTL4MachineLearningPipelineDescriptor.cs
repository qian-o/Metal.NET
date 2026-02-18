namespace Metal.NET;

public class MTL4MachineLearningPipelineDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4MachineLearningPipelineDescriptor");

    public MTL4MachineLearningPipelineDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTL4MachineLearningPipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTL4MachineLearningPipelineDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.SetLabel, value.NativePtr);
    }

    public MTL4FunctionDescriptor MachineLearningFunctionDescriptor
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.MachineLearningFunctionDescriptor));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.SetMachineLearningFunctionDescriptor, value.NativePtr);
    }

    public MTLTensorExtents InputDimensionsAtBufferIndex(nint bufferIndex)
    {
        MTLTensorExtents result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.InputDimensionsAtBufferIndex, bufferIndex));

        return result;
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.Reset);
    }

    public void SetInputDimensions(MTLTensorExtents dimensions, nint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.SetInputDimensionsBufferIndex, dimensions.NativePtr, bufferIndex);
    }

    public void SetInputDimensions(NSArray dimensions, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.SetInputDimensionsRange, dimensions.NativePtr, range);
    }

    public static implicit operator nint(MTL4MachineLearningPipelineDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4MachineLearningPipelineDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTL4MachineLearningPipelineDescriptorSelector
{
    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector MachineLearningFunctionDescriptor = Selector.Register("machineLearningFunctionDescriptor");

    public static readonly Selector SetMachineLearningFunctionDescriptor = Selector.Register("setMachineLearningFunctionDescriptor:");

    public static readonly Selector InputDimensionsAtBufferIndex = Selector.Register("inputDimensionsAtBufferIndex:");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetInputDimensionsBufferIndex = Selector.Register("setInputDimensions:bufferIndex:");

    public static readonly Selector SetInputDimensionsRange = Selector.Register("setInputDimensions:range:");
}
