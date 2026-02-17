using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4MachineLearningPipelineDescriptor_Selectors
{
    internal static readonly Selector inputDimensionsAtBufferIndex_ = Selector.Register("inputDimensionsAtBufferIndex:");
    internal static readonly Selector reset = Selector.Register("reset");
    internal static readonly Selector setInputDimensions_bufferIndex_ = Selector.Register("setInputDimensions:bufferIndex:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
    internal static readonly Selector setMachineLearningFunctionDescriptor_ = Selector.Register("setMachineLearningFunctionDescriptor:");
}

public class MTL4MachineLearningPipelineDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4MachineLearningPipelineDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4MachineLearningPipelineDescriptor o) => o.NativePtr;
    public static implicit operator MTL4MachineLearningPipelineDescriptor(nint ptr) => new MTL4MachineLearningPipelineDescriptor(ptr);

    ~MTL4MachineLearningPipelineDescriptor() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    public MTLTensorExtents InputDimensionsAtBufferIndex(nint bufferIndex)
    {
        var __r = new MTLTensorExtents(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4MachineLearningPipelineDescriptor_Selectors.inputDimensionsAtBufferIndex_, bufferIndex));
        return __r;
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningPipelineDescriptor_Selectors.reset);
    }

    public void SetInputDimensions(MTLTensorExtents dimensions, nint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningPipelineDescriptor_Selectors.setInputDimensions_bufferIndex_, dimensions.NativePtr, bufferIndex);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningPipelineDescriptor_Selectors.setLabel_, label.NativePtr);
    }

    public void SetMachineLearningFunctionDescriptor(MTL4FunctionDescriptor machineLearningFunctionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4MachineLearningPipelineDescriptor_Selectors.setMachineLearningFunctionDescriptor_, machineLearningFunctionDescriptor.NativePtr);
    }

}
