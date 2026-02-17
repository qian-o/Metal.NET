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

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTL4MachineLearningPipelineDescriptor
{
    public readonly nint NativePtr;

    public MTL4MachineLearningPipelineDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4MachineLearningPipelineDescriptor o) => o.NativePtr;
    public static implicit operator MTL4MachineLearningPipelineDescriptor(nint ptr) => new MTL4MachineLearningPipelineDescriptor(ptr);

    public MTLTensorExtents InputDimensionsAtBufferIndex(nint bufferIndex)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4MachineLearningPipelineDescriptor_Selectors.inputDimensionsAtBufferIndex_, bufferIndex);
        return new MTLTensorExtents(__result);
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

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
