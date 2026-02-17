using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLIndirectComputeCommand_Selectors
{
    internal static readonly Selector clearBarrier = Selector.Register("clearBarrier");
    internal static readonly Selector concurrentDispatchThreadgroups_threadsPerThreadgroup_ = Selector.Register("concurrentDispatchThreadgroups:threadsPerThreadgroup:");
    internal static readonly Selector concurrentDispatchThreads_threadsPerThreadgroup_ = Selector.Register("concurrentDispatchThreads:threadsPerThreadgroup:");
    internal static readonly Selector reset = Selector.Register("reset");
    internal static readonly Selector setBarrier = Selector.Register("setBarrier");
    internal static readonly Selector setComputePipelineState_ = Selector.Register("setComputePipelineState:");
    internal static readonly Selector setImageblockWidth_height_ = Selector.Register("setImageblockWidth:height:");
    internal static readonly Selector setKernelBuffer_offset_index_ = Selector.Register("setKernelBuffer:offset:index:");
    internal static readonly Selector setKernelBuffer_offset_stride_index_ = Selector.Register("setKernelBuffer:offset:stride:index:");
    internal static readonly Selector setThreadgroupMemoryLength_index_ = Selector.Register("setThreadgroupMemoryLength:index:");
}

public class MTLIndirectComputeCommand : IDisposable
{
    public nint NativePtr { get; }

    public MTLIndirectComputeCommand(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLIndirectComputeCommand o) => o.NativePtr;
    public static implicit operator MTLIndirectComputeCommand(nint ptr) => new MTLIndirectComputeCommand(ptr);

    ~MTLIndirectComputeCommand() => Release();

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

    public void ClearBarrier()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommand_Selectors.clearBarrier);
    }

    public void ConcurrentDispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommand_Selectors.concurrentDispatchThreadgroups_threadsPerThreadgroup_, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void ConcurrentDispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommand_Selectors.concurrentDispatchThreads_threadsPerThreadgroup_, threadsPerGrid, threadsPerThreadgroup);
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommand_Selectors.reset);
    }

    public void SetBarrier()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommand_Selectors.setBarrier);
    }

    public void SetComputePipelineState(MTLComputePipelineState pipelineState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommand_Selectors.setComputePipelineState_, pipelineState.NativePtr);
    }

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommand_Selectors.setImageblockWidth_height_, (nint)width, (nint)height);
    }

    public void SetKernelBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommand_Selectors.setKernelBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetKernelBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommand_Selectors.setKernelBuffer_offset_stride_index_, buffer.NativePtr, (nint)offset, (nint)stride, (nint)index);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIndirectComputeCommand_Selectors.setThreadgroupMemoryLength_index_, (nint)length, (nint)index);
    }

}
