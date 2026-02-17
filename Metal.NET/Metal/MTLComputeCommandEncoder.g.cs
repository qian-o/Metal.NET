using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLComputeCommandEncoder_Selectors
{
    internal static readonly Selector dispatchThreadgroups_threadsPerThreadgroup_ = Selector.Register("dispatchThreadgroups:threadsPerThreadgroup:");
    internal static readonly Selector dispatchThreads_threadsPerThreadgroup_ = Selector.Register("dispatchThreads:threadsPerThreadgroup:");
    internal static readonly Selector executeCommandsInBuffer_indirectRangeBuffer_indirectBufferOffset_ = Selector.Register("executeCommandsInBuffer:indirectRangeBuffer:indirectBufferOffset:");
    internal static readonly Selector memoryBarrier_ = Selector.Register("memoryBarrier:");
    internal static readonly Selector sampleCountersInBuffer_sampleIndex_barrier_ = Selector.Register("sampleCountersInBuffer:sampleIndex:barrier:");
    internal static readonly Selector setAccelerationStructure_bufferIndex_ = Selector.Register("setAccelerationStructure:bufferIndex:");
    internal static readonly Selector setBuffer_offset_index_ = Selector.Register("setBuffer:offset:index:");
    internal static readonly Selector setBuffer_offset_stride_index_ = Selector.Register("setBuffer:offset:stride:index:");
    internal static readonly Selector setBufferOffset_index_ = Selector.Register("setBufferOffset:index:");
    internal static readonly Selector setBufferOffset_stride_index_ = Selector.Register("setBufferOffset:stride:index:");
    internal static readonly Selector setBytes_length_index_ = Selector.Register("setBytes:length:index:");
    internal static readonly Selector setBytes_length_stride_index_ = Selector.Register("setBytes:length:stride:index:");
    internal static readonly Selector setComputePipelineState_ = Selector.Register("setComputePipelineState:");
    internal static readonly Selector setImageblockWidth_height_ = Selector.Register("setImageblockWidth:height:");
    internal static readonly Selector setIntersectionFunctionTable_bufferIndex_ = Selector.Register("setIntersectionFunctionTable:bufferIndex:");
    internal static readonly Selector setSamplerState_index_ = Selector.Register("setSamplerState:index:");
    internal static readonly Selector setStageInRegion_indirectBufferOffset_ = Selector.Register("setStageInRegion:indirectBufferOffset:");
    internal static readonly Selector setTexture_index_ = Selector.Register("setTexture:index:");
    internal static readonly Selector setThreadgroupMemoryLength_index_ = Selector.Register("setThreadgroupMemoryLength:index:");
    internal static readonly Selector setVisibleFunctionTable_bufferIndex_ = Selector.Register("setVisibleFunctionTable:bufferIndex:");
    internal static readonly Selector updateFence_ = Selector.Register("updateFence:");
    internal static readonly Selector useHeap_ = Selector.Register("useHeap:");
    internal static readonly Selector useResource_usage_ = Selector.Register("useResource:usage:");
    internal static readonly Selector waitForFence_ = Selector.Register("waitForFence:");
}

public class MTLComputeCommandEncoder : IDisposable
{
    public nint NativePtr { get; }

    public MTLComputeCommandEncoder(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLComputeCommandEncoder o) => o.NativePtr;
    public static implicit operator MTLComputeCommandEncoder(nint ptr) => new MTLComputeCommandEncoder(ptr);

    ~MTLComputeCommandEncoder() => Release();

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

    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.dispatchThreadgroups_threadsPerThreadgroup_, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.dispatchThreads_threadsPerThreadgroup_, threadsPerGrid, threadsPerThreadgroup);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.executeCommandsInBuffer_indirectRangeBuffer_indirectBufferOffset_, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, (nint)indirectBufferOffset);
    }

    public void MemoryBarrier(nuint scope)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.memoryBarrier_, (nint)scope);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, Bool8 barrier)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.sampleCountersInBuffer_sampleIndex_barrier_, sampleBuffer.NativePtr, (nint)sampleIndex, (nint)barrier.Value);
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.setAccelerationStructure_bufferIndex_, accelerationStructure.NativePtr, (nint)bufferIndex);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.setBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.setBuffer_offset_stride_index_, buffer.NativePtr, (nint)offset, (nint)stride, (nint)index);
    }

    public void SetBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.setBufferOffset_index_, (nint)offset, (nint)index);
    }

    public void SetBufferOffset(nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.setBufferOffset_stride_index_, (nint)offset, (nint)stride, (nint)index);
    }

    public void SetBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.setBytes_length_index_, bytes, (nint)length, (nint)index);
    }

    public void SetBytes(nint bytes, nuint length, nuint stride, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.setBytes_length_stride_index_, bytes, (nint)length, (nint)stride, (nint)index);
    }

    public void SetComputePipelineState(MTLComputePipelineState state)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.setComputePipelineState_, state.NativePtr);
    }

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.setImageblockWidth_height_, (nint)width, (nint)height);
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.setIntersectionFunctionTable_bufferIndex_, intersectionFunctionTable.NativePtr, (nint)bufferIndex);
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.setSamplerState_index_, sampler.NativePtr, (nint)index);
    }

    public void SetStageInRegion(MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.setStageInRegion_indirectBufferOffset_, indirectBuffer.NativePtr, (nint)indirectBufferOffset);
    }

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.setTexture_index_, texture.NativePtr, (nint)index);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.setThreadgroupMemoryLength_index_, (nint)length, (nint)index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.setVisibleFunctionTable_bufferIndex_, visibleFunctionTable.NativePtr, (nint)bufferIndex);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.updateFence_, fence.NativePtr);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.useHeap_, heap.NativePtr);
    }

    public void UseResource(MTLResource resource, nuint usage)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.useResource_usage_, resource.NativePtr, (nint)usage);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoder_Selectors.waitForFence_, fence.NativePtr);
    }

}
