namespace Metal.NET;

file class MTL4MachineLearningPipelineDescriptorSelector
{
    public static readonly Selector InputDimensionsAtBufferIndex_ = Selector.Register("inputDimensionsAtBufferIndex:");
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector SetInputDimensions_bufferIndex_ = Selector.Register("setInputDimensions:bufferIndex:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector SetMachineLearningFunctionDescriptor_ = Selector.Register("setMachineLearningFunctionDescriptor:");
}

public class MTL4MachineLearningPipelineDescriptor : IDisposable
{
    public MTL4MachineLearningPipelineDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public MTLTensorExtents InputDimensionsAtBufferIndex(nint bufferIndex)
    {
        var result = new MTLTensorExtents(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.InputDimensionsAtBufferIndex_, bufferIndex));

        return result;
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.Reset);
    }

    public void SetInputDimensions(MTLTensorExtents dimensions, nint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.SetInputDimensions_bufferIndex_, dimensions.NativePtr, bufferIndex);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.SetLabel_, label.NativePtr);
    }

    public void SetMachineLearningFunctionDescriptor(MTL4FunctionDescriptor machineLearningFunctionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningPipelineDescriptorSelector.SetMachineLearningFunctionDescriptor_, machineLearningFunctionDescriptor.NativePtr);
    }

}
