namespace Metal.NET;

public class MTLComputeCommandEncoder : IDisposable
{
    public MTLComputeCommandEncoder(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLComputeCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDispatchType DispatchType
    {
        get => (MTLDispatchType)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLComputeCommandEncoderSelector.DispatchType));
    }

    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.DispatchThreadgroupsWithIndirectBufferIndirectBufferOffsetThreadsPerThreadgroup, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreadgroups(MTLBuffer indirectBuffer, nuint indirectBufferOffset, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.DispatchThreadgroupsWithIndirectBufferIndirectBufferOffsetThreadsPerThreadgroup, indirectBuffer.NativePtr, indirectBufferOffset, threadsPerThreadgroup);
    }

    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.DispatchThreadsThreadsPerThreadgroup, threadsPerGrid, threadsPerThreadgroup);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.ExecuteCommandsInBufferIndirectBufferIndirectBufferOffset, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.ExecuteCommandsInBufferIndirectBufferIndirectBufferOffset, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, indirectBufferOffset);
    }

    public void MemoryBarrier(MTLBarrierScope scope)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.MemoryBarrierWithResourcesCount, (ulong)scope);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, Bool8 barrier)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SampleCountersInBufferAtSampleIndexWithBarrier, sampleBuffer.NativePtr, sampleIndex, barrier);
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetAccelerationStructureAtBufferIndex, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBufferOffsetAttributeStrideAtIndex, buffer.NativePtr, offset, index);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBufferOffsetAttributeStrideAtIndex, buffer.NativePtr, offset, stride, index);
    }

    public void SetBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBufferOffsetAttributeStrideAtIndex3, offset, index);
    }

    public void SetBufferOffset(nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBufferOffsetAttributeStrideAtIndex3, offset, stride, index);
    }

    public void SetBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBytesLengthAttributeStrideAtIndex, bytes, length, index);
    }

    public void SetBytes(nint bytes, nuint length, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBytesLengthAttributeStrideAtIndex, bytes, length, stride, index);
    }

    public void SetComputePipelineState(MTLComputePipelineState state)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetComputePipelineState, state.NativePtr);
    }

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetImageblockWidthHeight, width, height);
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetIntersectionFunctionTableAtBufferIndex, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, index);
    }

    public void SetSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetStageInRegion(MTLRegion region)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetStageInRegionWithIndirectBufferIndirectBufferOffset, region);
    }

    public void SetStageInRegion(MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetStageInRegionWithIndirectBufferIndirectBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetTextureAtIndex, texture.NativePtr, index);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetThreadgroupMemoryLengthAtIndex, length, index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetVisibleFunctionTableAtBufferIndex, visibleFunctionTable.NativePtr, bufferIndex);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.UpdateFence, fence.NativePtr);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.UseHeap, heap.NativePtr);
    }

    public void UseResource(MTLResource resource, MTLResourceUsage usage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.UseResourceUsage, resource.NativePtr, (ulong)usage);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.WaitForFence, fence.NativePtr);
    }

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
}

file class MTLComputeCommandEncoderSelector
{
    public static readonly Selector DispatchType = Selector.Register("dispatchType");

    public static readonly Selector DispatchThreadgroupsWithIndirectBufferIndirectBufferOffsetThreadsPerThreadgroup = Selector.Register("dispatchThreadgroupsWithIndirectBuffer:indirectBufferOffset:threadsPerThreadgroup:");

    public static readonly Selector DispatchThreadsThreadsPerThreadgroup = Selector.Register("dispatchThreads:threadsPerThreadgroup:");

    public static readonly Selector ExecuteCommandsInBufferIndirectBufferIndirectBufferOffset = Selector.Register("executeCommandsInBuffer:indirectBuffer:indirectBufferOffset:");

    public static readonly Selector MemoryBarrierWithResourcesCount = Selector.Register("memoryBarrierWithResources:count:");

    public static readonly Selector SampleCountersInBufferAtSampleIndexWithBarrier = Selector.Register("sampleCountersInBuffer:atSampleIndex:withBarrier:");

    public static readonly Selector SetAccelerationStructureAtBufferIndex = Selector.Register("setAccelerationStructure:atBufferIndex:");

    public static readonly Selector SetBufferOffsetAttributeStrideAtIndex = Selector.Register("setBuffer:offset:attributeStride:atIndex:");

    public static readonly Selector SetBufferOffsetAttributeStrideAtIndex3 = Selector.Register("setBufferOffset:attributeStride:atIndex:");

    public static readonly Selector SetBytesLengthAttributeStrideAtIndex = Selector.Register("setBytes:length:attributeStride:atIndex:");

    public static readonly Selector SetComputePipelineState = Selector.Register("setComputePipelineState:");

    public static readonly Selector SetImageblockWidthHeight = Selector.Register("setImageblockWidth:height:");

    public static readonly Selector SetIntersectionFunctionTableAtBufferIndex = Selector.Register("setIntersectionFunctionTable:atBufferIndex:");

    public static readonly Selector SetSamplerStateLodMinClampLodMaxClampAtIndex = Selector.Register("setSamplerState:lodMinClamp:lodMaxClamp:atIndex:");

    public static readonly Selector SetStageInRegionWithIndirectBufferIndirectBufferOffset = Selector.Register("setStageInRegionWithIndirectBuffer:indirectBufferOffset:");

    public static readonly Selector SetTextureAtIndex = Selector.Register("setTexture:atIndex:");

    public static readonly Selector SetThreadgroupMemoryLengthAtIndex = Selector.Register("setThreadgroupMemoryLength:atIndex:");

    public static readonly Selector SetVisibleFunctionTableAtBufferIndex = Selector.Register("setVisibleFunctionTable:atBufferIndex:");

    public static readonly Selector UpdateFence = Selector.Register("updateFence:");

    public static readonly Selector UseHeap = Selector.Register("useHeap:");

    public static readonly Selector UseResourceUsage = Selector.Register("useResource:usage:");

    public static readonly Selector WaitForFence = Selector.Register("waitForFence:");
}
