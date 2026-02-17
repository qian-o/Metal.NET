using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4ComputePipelineDescriptor_Selectors
{
    internal static readonly Selector reset = Selector.Register("reset");
    internal static readonly Selector setComputeFunctionDescriptor_ = Selector.Register("setComputeFunctionDescriptor:");
    internal static readonly Selector setMaxTotalThreadsPerThreadgroup_ = Selector.Register("setMaxTotalThreadsPerThreadgroup:");
    internal static readonly Selector setRequiredThreadsPerThreadgroup_ = Selector.Register("setRequiredThreadsPerThreadgroup:");
    internal static readonly Selector setStaticLinkingDescriptor_ = Selector.Register("setStaticLinkingDescriptor:");
    internal static readonly Selector setSupportBinaryLinking_ = Selector.Register("setSupportBinaryLinking:");
    internal static readonly Selector setSupportIndirectCommandBuffers_ = Selector.Register("setSupportIndirectCommandBuffers:");
    internal static readonly Selector setThreadGroupSizeIsMultipleOfThreadExecutionWidth_ = Selector.Register("setThreadGroupSizeIsMultipleOfThreadExecutionWidth:");
}

public class MTL4ComputePipelineDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4ComputePipelineDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4ComputePipelineDescriptor o) => o.NativePtr;
    public static implicit operator MTL4ComputePipelineDescriptor(nint ptr) => new MTL4ComputePipelineDescriptor(ptr);

    ~MTL4ComputePipelineDescriptor() => Release();

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

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputePipelineDescriptor_Selectors.reset);
    }

    public void SetComputeFunctionDescriptor(MTL4FunctionDescriptor computeFunctionDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputePipelineDescriptor_Selectors.setComputeFunctionDescriptor_, computeFunctionDescriptor.NativePtr);
    }

    public void SetMaxTotalThreadsPerThreadgroup(nuint maxTotalThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputePipelineDescriptor_Selectors.setMaxTotalThreadsPerThreadgroup_, (nint)maxTotalThreadsPerThreadgroup);
    }

    public void SetRequiredThreadsPerThreadgroup(MTLSize requiredThreadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputePipelineDescriptor_Selectors.setRequiredThreadsPerThreadgroup_, requiredThreadsPerThreadgroup);
    }

    public void SetStaticLinkingDescriptor(MTL4StaticLinkingDescriptor staticLinkingDescriptor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputePipelineDescriptor_Selectors.setStaticLinkingDescriptor_, staticLinkingDescriptor.NativePtr);
    }

    public void SetSupportBinaryLinking(Bool8 supportBinaryLinking)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputePipelineDescriptor_Selectors.setSupportBinaryLinking_, (nint)supportBinaryLinking.Value);
    }

    public void SetSupportIndirectCommandBuffers(MTL4IndirectCommandBufferSupportState supportIndirectCommandBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputePipelineDescriptor_Selectors.setSupportIndirectCommandBuffers_, (nint)(uint)supportIndirectCommandBuffers);
    }

    public void SetThreadGroupSizeIsMultipleOfThreadExecutionWidth(Bool8 threadGroupSizeIsMultipleOfThreadExecutionWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputePipelineDescriptor_Selectors.setThreadGroupSizeIsMultipleOfThreadExecutionWidth_, (nint)threadGroupSizeIsMultipleOfThreadExecutionWidth.Value);
    }

}
