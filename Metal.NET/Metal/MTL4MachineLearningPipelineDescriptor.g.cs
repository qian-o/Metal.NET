namespace Metal.NET;

public class MTL4MachineLearningPipelineDescriptor : IDisposable
{
    public MTL4MachineLearningPipelineDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4MachineLearningPipelineDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    public MTLTensorExtents InputDimensionsAtBufferIndex(int bufferIndex)
    {
        var result = new MTLTensorExtents(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.InputDimensionsAtBufferIndex, bufferIndex));

        return result;
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.Reset);
    }

    public void SetInputDimensions(MTLTensorExtents dimensions, int bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.SetInputDimensionsBufferIndex, dimensions.NativePtr, bufferIndex);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.SetLabel, label.NativePtr);
    }

    public void SetMachineLearningFunctionDescriptor(MTL4FunctionDescriptor machineLearningFunctionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.SetMachineLearningFunctionDescriptor, machineLearningFunctionDescriptor.NativePtr);
    }

}

file class MTL4MachineLearningPipelineDescriptorSelector
{
    public static readonly Selector InputDimensionsAtBufferIndex = Selector.Register("inputDimensionsAtBufferIndex:");
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetInputDimensionsBufferIndex = Selector.Register("setInputDimensions:bufferIndex:");
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
    public static readonly Selector SetMachineLearningFunctionDescriptor = Selector.Register("setMachineLearningFunctionDescriptor:");
}
