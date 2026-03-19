namespace Metal.NET;

public class MTLComputeCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTLCommandEncoder(nativePtr, ownership), INativeObject<MTLComputeCommandEncoder>
{
    #region INativeObject
    public static new MTLComputeCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLComputeCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDispatchType DispatchType
    {
        get => (MTLDispatchType)ObjectiveC.MsgSendULong(NativePtr, MTLComputeCommandEncoderBindings.DispatchType);
    }

    public void SetComputePipelineState(MTLComputePipelineState state)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetComputePipelineState, state.NativePtr);
    }

    public void SetBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBytesLengthAtIndex, bytes, length, index);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBufferOffsetAtIndex, buffer.NativePtr, offset, index);
    }

    public void SetBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBufferOffsetAtIndex, offset, index);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBufferOffsetAttributeStrideAtIndex, buffer.NativePtr, offset, stride, index);
    }

    public void SetBufferOffset(nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBufferOffsetAttributeStrideAtIndex, offset, stride, index);
    }

    public void SetBytes(nint bytes, nuint length, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBytesLengthAttributeStrideAtIndex, bytes, length, stride, index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetVisibleFunctionTableAtBufferIndex, visibleFunctionTable.NativePtr, bufferIndex);
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetIntersectionFunctionTableAtBufferIndex, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetAccelerationStructureAtBufferIndex, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetTextureAtIndex, texture.NativePtr, index);
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetSamplerStateAtIndex, sampler.NativePtr, index);
    }

    public void SetSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetSamplerStateLodMinClampLodMaxClampAtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetThreadgroupMemoryLengthAtIndex, length, index);
    }

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetImageblockWidthHeight, width, height);
    }

    public void SetStageInRegion(MTLRegion region)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetStageInRegion, region);
    }

    public void SetStageInRegionWithIndirectBuffer(MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetStageInRegionWithIndirectBufferIndirectBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.DispatchThreadgroupsThreadsPerThreadgroup, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreadgroups(MTLBuffer indirectBuffer, nuint indirectBufferOffset, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.DispatchThreadgroupsWithIndirectBufferIndirectBufferOffsetThreadsPerThreadgroup, indirectBuffer.NativePtr, indirectBufferOffset, threadsPerThreadgroup);
    }

    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.DispatchThreadsThreadsPerThreadgroup, threadsPerGrid, threadsPerThreadgroup);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.UpdateFence, fence.NativePtr);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.WaitForFence, fence.NativePtr);
    }

    public void UseResource(MTLResource resource, MTLResourceUsage usage)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.UseResourceUsage, resource.NativePtr, (nuint)usage);
    }

    public unsafe void UseResources(MTLResource[] resources, MTLResourceUsage usage)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.UseResourcesCountUsage, (nint)pResources, (nuint)resources.Length, (nuint)usage);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.UseHeap, heap.NativePtr);
    }

    public unsafe void UseHeaps(MTLHeap[] heaps)
    {
        nint* pHeaps = stackalloc nint[heaps.Length];
        for (int i = 0; i < heaps.Length; i++)
        {
            pHeaps[i] = heaps[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.UseHeapsCount, (nint)pHeaps, (nuint)heaps.Length);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.ExecuteCommandsInBufferWithRange, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.ExecuteCommandsInBufferIndirectBufferIndirectBufferOffset, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, indirectBufferOffset);
    }

    public void MemoryBarrier(MTLBarrierScope scope)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.MemoryBarrierWithScope, (nuint)scope);
    }

    public unsafe void MemoryBarrierWithResources(MTLResource[] resources)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.MemoryBarrierWithResourcesCount, (nint)pResources, (nuint)resources.Length);
    }

    public void SampleCounters(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SampleCountersInBufferAtSampleIndexWithBarrier, sampleBuffer.NativePtr, sampleIndex, barrier);
    }
}

file static class MTLComputeCommandEncoderBindings
{
    public static readonly Selector DispatchThreadgroupsThreadsPerThreadgroup = "dispatchThreadgroups:threadsPerThreadgroup:";

    public static readonly Selector DispatchThreadgroupsWithIndirectBufferIndirectBufferOffsetThreadsPerThreadgroup = "dispatchThreadgroupsWithIndirectBuffer:indirectBufferOffset:threadsPerThreadgroup:";

    public static readonly Selector DispatchThreadsThreadsPerThreadgroup = "dispatchThreads:threadsPerThreadgroup:";

    public static readonly Selector DispatchType = "dispatchType";

    public static readonly Selector ExecuteCommandsInBufferIndirectBufferIndirectBufferOffset = "executeCommandsInBuffer:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector ExecuteCommandsInBufferWithRange = "executeCommandsInBuffer:withRange:";

    public static readonly Selector MemoryBarrierWithResourcesCount = "memoryBarrierWithResources:count:";

    public static readonly Selector MemoryBarrierWithScope = "memoryBarrierWithScope:";

    public static readonly Selector SampleCountersInBufferAtSampleIndexWithBarrier = "sampleCountersInBuffer:atSampleIndex:withBarrier:";

    public static readonly Selector SetAccelerationStructureAtBufferIndex = "setAccelerationStructure:atBufferIndex:";

    public static readonly Selector SetBufferOffsetAtIndex = "setBuffer:offset:atIndex:";

    public static readonly Selector SetBufferOffsetAttributeStrideAtIndex = "setBuffer:offset:attributeStride:atIndex:";

    public static readonly Selector SetBytesLengthAtIndex = "setBytes:length:atIndex:";

    public static readonly Selector SetBytesLengthAttributeStrideAtIndex = "setBytes:length:attributeStride:atIndex:";

    public static readonly Selector SetComputePipelineState = "setComputePipelineState:";

    public static readonly Selector SetImageblockWidthHeight = "setImageblockWidth:height:";

    public static readonly Selector SetIntersectionFunctionTableAtBufferIndex = "setIntersectionFunctionTable:atBufferIndex:";

    public static readonly Selector SetSamplerStateAtIndex = "setSamplerState:atIndex:";

    public static readonly Selector SetSamplerStateLodMinClampLodMaxClampAtIndex = "setSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetStageInRegion = "setStageInRegion:";

    public static readonly Selector SetStageInRegionWithIndirectBufferIndirectBufferOffset = "setStageInRegionWithIndirectBuffer:indirectBufferOffset:";

    public static readonly Selector SetTextureAtIndex = "setTexture:atIndex:";

    public static readonly Selector SetThreadgroupMemoryLengthAtIndex = "setThreadgroupMemoryLength:atIndex:";

    public static readonly Selector SetVisibleFunctionTableAtBufferIndex = "setVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector UpdateFence = "updateFence:";

    public static readonly Selector UseHeap = "useHeap:";

    public static readonly Selector UseHeapsCount = "useHeaps:count:";

    public static readonly Selector UseResourcesCountUsage = "useResources:count:usage:";

    public static readonly Selector UseResourceUsage = "useResource:usage:";

    public static readonly Selector WaitForFence = "waitForFence:";
}
