namespace Metal.NET;

file class MTLComputeCommandEncoderSelector
{
    public static readonly Selector DispatchThreadgroups_threadsPerThreadgroup_ = Selector.Register("dispatchThreadgroups:threadsPerThreadgroup:");
    public static readonly Selector DispatchThreads_threadsPerThreadgroup_ = Selector.Register("dispatchThreads:threadsPerThreadgroup:");
    public static readonly Selector ExecuteCommandsInBuffer_indirectRangeBuffer_indirectBufferOffset_ = Selector.Register("executeCommandsInBuffer:indirectRangeBuffer:indirectBufferOffset:");
    public static readonly Selector MemoryBarrier_ = Selector.Register("memoryBarrier:");
    public static readonly Selector SampleCountersInBuffer_sampleIndex_barrier_ = Selector.Register("sampleCountersInBuffer:sampleIndex:barrier:");
    public static readonly Selector SetAccelerationStructure_bufferIndex_ = Selector.Register("setAccelerationStructure:bufferIndex:");
    public static readonly Selector SetBuffer_offset_index_ = Selector.Register("setBuffer:offset:index:");
    public static readonly Selector SetBuffer_offset_stride_index_ = Selector.Register("setBuffer:offset:stride:index:");
    public static readonly Selector SetBufferOffset_index_ = Selector.Register("setBufferOffset:index:");
    public static readonly Selector SetBufferOffset_stride_index_ = Selector.Register("setBufferOffset:stride:index:");
    public static readonly Selector SetBytes_length_index_ = Selector.Register("setBytes:length:index:");
    public static readonly Selector SetBytes_length_stride_index_ = Selector.Register("setBytes:length:stride:index:");
    public static readonly Selector SetComputePipelineState_ = Selector.Register("setComputePipelineState:");
    public static readonly Selector SetImageblockWidth_height_ = Selector.Register("setImageblockWidth:height:");
    public static readonly Selector SetIntersectionFunctionTable_bufferIndex_ = Selector.Register("setIntersectionFunctionTable:bufferIndex:");
    public static readonly Selector SetSamplerState_index_ = Selector.Register("setSamplerState:index:");
    public static readonly Selector SetStageInRegion_indirectBufferOffset_ = Selector.Register("setStageInRegion:indirectBufferOffset:");
    public static readonly Selector SetTexture_index_ = Selector.Register("setTexture:index:");
    public static readonly Selector SetThreadgroupMemoryLength_index_ = Selector.Register("setThreadgroupMemoryLength:index:");
    public static readonly Selector SetVisibleFunctionTable_bufferIndex_ = Selector.Register("setVisibleFunctionTable:bufferIndex:");
    public static readonly Selector UpdateFence_ = Selector.Register("updateFence:");
    public static readonly Selector UseHeap_ = Selector.Register("useHeap:");
    public static readonly Selector UseResource_usage_ = Selector.Register("useResource:usage:");
    public static readonly Selector WaitForFence_ = Selector.Register("waitForFence:");
}

public class MTLComputeCommandEncoder : IDisposable
{
    public MTLComputeCommandEncoder(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLComputeCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLComputeCommandEncoder value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLComputeCommandEncoder(nint value)
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

    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.DispatchThreadgroups_threadsPerThreadgroup_, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.DispatchThreads_threadsPerThreadgroup_, threadsPerGrid, threadsPerThreadgroup);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.ExecuteCommandsInBuffer_indirectRangeBuffer_indirectBufferOffset_, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, (nint)indirectBufferOffset);
    }

    public void MemoryBarrier(nuint scope)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.MemoryBarrier_, (nint)scope);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, Bool8 barrier)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.SampleCountersInBuffer_sampleIndex_barrier_, sampleBuffer.NativePtr, (nint)sampleIndex, (nint)barrier.Value);
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.SetAccelerationStructure_bufferIndex_, accelerationStructure.NativePtr, (nint)bufferIndex);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBuffer_offset_stride_index_, buffer.NativePtr, (nint)offset, (nint)stride, (nint)index);
    }

    public void SetBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBufferOffset_index_, (nint)offset, (nint)index);
    }

    public void SetBufferOffset(nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBufferOffset_stride_index_, (nint)offset, (nint)stride, (nint)index);
    }

    public void SetBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBytes_length_index_, bytes, (nint)length, (nint)index);
    }

    public void SetBytes(nint bytes, nuint length, nuint stride, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBytes_length_stride_index_, bytes, (nint)length, (nint)stride, (nint)index);
    }

    public void SetComputePipelineState(MTLComputePipelineState state)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.SetComputePipelineState_, state.NativePtr);
    }

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.SetImageblockWidth_height_, (nint)width, (nint)height);
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.SetIntersectionFunctionTable_bufferIndex_, intersectionFunctionTable.NativePtr, (nint)bufferIndex);
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.SetSamplerState_index_, sampler.NativePtr, (nint)index);
    }

    public void SetStageInRegion(MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.SetStageInRegion_indirectBufferOffset_, indirectBuffer.NativePtr, (nint)indirectBufferOffset);
    }

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.SetTexture_index_, texture.NativePtr, (nint)index);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.SetThreadgroupMemoryLength_index_, (nint)length, (nint)index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.SetVisibleFunctionTable_bufferIndex_, visibleFunctionTable.NativePtr, (nint)bufferIndex);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.UpdateFence_, fence.NativePtr);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.UseHeap_, heap.NativePtr);
    }

    public void UseResource(MTLResource resource, nuint usage)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.UseResource_usage_, resource.NativePtr, (nint)usage);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputeCommandEncoderSelector.WaitForFence_, fence.NativePtr);
    }

}
