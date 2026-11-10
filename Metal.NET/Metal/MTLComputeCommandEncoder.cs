namespace Metal.NET;

public readonly struct MTLComputeCommandEncoder(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLCommandEncoder(MTLComputeCommandEncoder value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLComputeCommandEncoder value) => new(value.NativePtr);

    public MTLComputeCommandEncoder Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLDispatchType DispatchType
    {
        get => (MTLDispatchType)ObjectiveC.MsgSendULong(NativePtr, MTLComputeCommandEncoderBindings.DispatchType);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLComputeCommandEncoderBindings.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLComputeCommandEncoderBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetLabel, value.NativePtr);
    }

    public void SetComputePipelineState(MTLComputePipelineState state)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetComputePipelineState, state.NativePtr);
    }

    public void SetBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBytes_Length_AtIndex, bytes, length, index);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBuffer_Offset_AtIndex, buffer.NativePtr, offset, index);
    }

    public void SetBufferOffset(nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBufferOffset_AtIndex, offset, index);
    }

    public unsafe void SetBuffers(ReadOnlySpan<MTLBuffer> buffers, ReadOnlySpan<nuint> offsets, NSRange range)
    {
        fixed (MTLBuffer* pBuffers = buffers)
        {
            fixed (nuint* pOffsets = offsets)
            {
                ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBuffers_Offsets_WithRange, (nint)pBuffers, (nint)pOffsets, range);
            }
        }
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBuffer_Offset_AttributeStride_AtIndex, buffer.NativePtr, offset, stride, index);
    }

    public unsafe void SetBuffers(ReadOnlySpan<MTLBuffer> buffers, ReadOnlySpan<nuint> offsets, ReadOnlySpan<nuint> strides, NSRange range)
    {
        fixed (MTLBuffer* pBuffers = buffers)
        {
            fixed (nuint* pOffsets = offsets)
            {
                fixed (nuint* pStrides = strides)
                {
                    ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBuffers_Offsets_AttributeStrides_WithRange, (nint)pBuffers, (nint)pOffsets, (nint)pStrides, range);
                }
            }
        }
    }

    public void SetBufferOffset(nuint offset, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBufferOffset_AttributeStride_AtIndex, offset, stride, index);
    }

    public void SetBytes(nint bytes, nuint length, nuint stride, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBytes_Length_AttributeStride_AtIndex, bytes, length, stride, index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetVisibleFunctionTable_AtBufferIndex, visibleFunctionTable.NativePtr, bufferIndex);
    }

    public unsafe void SetVisibleFunctionTables(ReadOnlySpan<MTLVisibleFunctionTable> visibleFunctionTables, NSRange range)
    {
        fixed (MTLVisibleFunctionTable* pVisibleFunctionTables = visibleFunctionTables)
        {
            ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetVisibleFunctionTables_WithBufferRange, (nint)pVisibleFunctionTables, range);
        }
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetIntersectionFunctionTable_AtBufferIndex, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public unsafe void SetIntersectionFunctionTables(ReadOnlySpan<MTLIntersectionFunctionTable> intersectionFunctionTables, NSRange range)
    {
        fixed (MTLIntersectionFunctionTable* pIntersectionFunctionTables = intersectionFunctionTables)
        {
            ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetIntersectionFunctionTables_WithBufferRange, (nint)pIntersectionFunctionTables, range);
        }
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetAccelerationStructure_AtBufferIndex, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetTexture_AtIndex, texture.NativePtr, index);
    }

    public unsafe void SetTextures(ReadOnlySpan<MTLTexture> textures, NSRange range)
    {
        fixed (MTLTexture* pTextures = textures)
        {
            ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetTextures_WithRange, (nint)pTextures, range);
        }
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetSamplerState_AtIndex, sampler.NativePtr, index);
    }

    public unsafe void SetSamplerStates(ReadOnlySpan<MTLSamplerState> samplers, NSRange range)
    {
        fixed (MTLSamplerState* pSamplers = samplers)
        {
            ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetSamplerStates_WithRange, (nint)pSamplers, range);
        }
    }

    public void SetSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetSamplerState_LodMinClamp_LodMaxClamp_AtIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public unsafe void SetSamplerStates(ReadOnlySpan<MTLSamplerState> samplers, ReadOnlySpan<float> lodMinClamps, ReadOnlySpan<float> lodMaxClamps, NSRange range)
    {
        fixed (MTLSamplerState* pSamplers = samplers)
        {
            fixed (float* pLodMinClamps = lodMinClamps)
            {
                fixed (float* pLodMaxClamps = lodMaxClamps)
                {
                    ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetSamplerStates_LodMinClamps_LodMaxClamps_WithRange, (nint)pSamplers, (nint)pLodMinClamps, (nint)pLodMaxClamps, range);
                }
            }
        }
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetThreadgroupMemoryLength_AtIndex, length, index);
    }

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetImageblockWidth_Height, width, height);
    }

    public void SetStageInRegion(MTLRegion region)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetStageInRegion, region);
    }

    public void SetStageInRegionWithIndirectBuffer(MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetStageInRegionWithIndirectBuffer_IndirectBufferOffset, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.DispatchThreadgroups_ThreadsPerThreadgroup, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreadgroups(MTLBuffer indirectBuffer, nuint indirectBufferOffset, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.DispatchThreadgroupsWithIndirectBuffer_IndirectBufferOffset_ThreadsPerThreadgroup, indirectBuffer.NativePtr, indirectBufferOffset, threadsPerThreadgroup);
    }

    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.DispatchThreads_ThreadsPerThreadgroup, threadsPerGrid, threadsPerThreadgroup);
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
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.UseResource_Usage, resource.NativePtr, (nuint)usage);
    }

    public unsafe void UseResources(ReadOnlySpan<MTLResource> resources, MTLResourceUsage usage)
    {
        fixed (MTLResource* pResources = resources)
        {
            ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.UseResources_Count_Usage, (nint)pResources, (nuint)resources.Length, (nuint)usage);
        }
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.UseHeap, heap.NativePtr);
    }

    public unsafe void UseHeaps(ReadOnlySpan<MTLHeap> heaps)
    {
        fixed (MTLHeap* pHeaps = heaps)
        {
            ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.UseHeaps_Count, (nint)pHeaps, (nuint)heaps.Length);
        }
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.ExecuteCommandsInBuffer_WithRange, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.ExecuteCommandsInBuffer_IndirectBuffer_IndirectBufferOffset, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, indirectBufferOffset);
    }

    public void MemoryBarrier(MTLBarrierScope scope)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.MemoryBarrierWithScope, (nuint)scope);
    }

    public unsafe void MemoryBarrierWithResources(ReadOnlySpan<MTLResource> resources)
    {
        fixed (MTLResource* pResources = resources)
        {
            ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.MemoryBarrierWithResources_Count, (nint)pResources, (nuint)resources.Length);
        }
    }

    public void SampleCounters(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SampleCountersInBuffer_AtSampleIndex_WithBarrier, sampleBuffer.NativePtr, sampleIndex, barrier);
    }

    public void EndEncoding()
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.EndEncoding);
    }

    public void Barrier(MTLStages afterQueueStages, MTLStages beforeStages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.BarrierAfterQueueStages_BeforeStages, (nuint)afterQueueStages, (nuint)beforeStages);
    }

    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.InsertDebugSignpost, @string.NativePtr);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.PushDebugGroup, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.PopDebugGroup);
    }
}

file static class MTLComputeCommandEncoderBindings
{
    public static readonly Selector BarrierAfterQueueStages_BeforeStages = "barrierAfterQueueStages:beforeStages:";

    public static readonly Selector Device = "device";

    public static readonly Selector DispatchThreadgroups_ThreadsPerThreadgroup = "dispatchThreadgroups:threadsPerThreadgroup:";

    public static readonly Selector DispatchThreadgroupsWithIndirectBuffer_IndirectBufferOffset_ThreadsPerThreadgroup = "dispatchThreadgroupsWithIndirectBuffer:indirectBufferOffset:threadsPerThreadgroup:";

    public static readonly Selector DispatchThreads_ThreadsPerThreadgroup = "dispatchThreads:threadsPerThreadgroup:";

    public static readonly Selector DispatchType = "dispatchType";

    public static readonly Selector EndEncoding = "endEncoding";

    public static readonly Selector ExecuteCommandsInBuffer_IndirectBuffer_IndirectBufferOffset = "executeCommandsInBuffer:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector ExecuteCommandsInBuffer_WithRange = "executeCommandsInBuffer:withRange:";

    public static readonly Selector InsertDebugSignpost = "insertDebugSignpost:";

    public static readonly Selector Label = "label";

    public static readonly Selector MemoryBarrierWithResources_Count = "memoryBarrierWithResources:count:";

    public static readonly Selector MemoryBarrierWithScope = "memoryBarrierWithScope:";

    public static readonly Selector PopDebugGroup = "popDebugGroup";

    public static readonly Selector PushDebugGroup = "pushDebugGroup:";

    public static readonly Selector SampleCountersInBuffer_AtSampleIndex_WithBarrier = "sampleCountersInBuffer:atSampleIndex:withBarrier:";

    public static readonly Selector SetAccelerationStructure_AtBufferIndex = "setAccelerationStructure:atBufferIndex:";

    public static readonly Selector SetBuffer_Offset_AtIndex = "setBuffer:offset:atIndex:";

    public static readonly Selector SetBuffer_Offset_AttributeStride_AtIndex = "setBuffer:offset:attributeStride:atIndex:";

    public static readonly Selector SetBufferOffset_AtIndex = "setBufferOffset:atIndex:";

    public static readonly Selector SetBufferOffset_AttributeStride_AtIndex = "setBufferOffset:attributeStride:atIndex:";

    public static readonly Selector SetBuffers_Offsets_AttributeStrides_WithRange = "setBuffers:offsets:attributeStrides:withRange:";

    public static readonly Selector SetBuffers_Offsets_WithRange = "setBuffers:offsets:withRange:";

    public static readonly Selector SetBytes_Length_AtIndex = "setBytes:length:atIndex:";

    public static readonly Selector SetBytes_Length_AttributeStride_AtIndex = "setBytes:length:attributeStride:atIndex:";

    public static readonly Selector SetComputePipelineState = "setComputePipelineState:";

    public static readonly Selector SetImageblockWidth_Height = "setImageblockWidth:height:";

    public static readonly Selector SetIntersectionFunctionTable_AtBufferIndex = "setIntersectionFunctionTable:atBufferIndex:";

    public static readonly Selector SetIntersectionFunctionTables_WithBufferRange = "setIntersectionFunctionTables:withBufferRange:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetSamplerState_AtIndex = "setSamplerState:atIndex:";

    public static readonly Selector SetSamplerState_LodMinClamp_LodMaxClamp_AtIndex = "setSamplerState:lodMinClamp:lodMaxClamp:atIndex:";

    public static readonly Selector SetSamplerStates_LodMinClamps_LodMaxClamps_WithRange = "setSamplerStates:lodMinClamps:lodMaxClamps:withRange:";

    public static readonly Selector SetSamplerStates_WithRange = "setSamplerStates:withRange:";

    public static readonly Selector SetStageInRegion = "setStageInRegion:";

    public static readonly Selector SetStageInRegionWithIndirectBuffer_IndirectBufferOffset = "setStageInRegionWithIndirectBuffer:indirectBufferOffset:";

    public static readonly Selector SetTexture_AtIndex = "setTexture:atIndex:";

    public static readonly Selector SetTextures_WithRange = "setTextures:withRange:";

    public static readonly Selector SetThreadgroupMemoryLength_AtIndex = "setThreadgroupMemoryLength:atIndex:";

    public static readonly Selector SetVisibleFunctionTable_AtBufferIndex = "setVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector SetVisibleFunctionTables_WithBufferRange = "setVisibleFunctionTables:withBufferRange:";

    public static readonly Selector UpdateFence = "updateFence:";

    public static readonly Selector UseHeap = "useHeap:";

    public static readonly Selector UseHeaps_Count = "useHeaps:count:";

    public static readonly Selector UseResource_Usage = "useResource:usage:";

    public static readonly Selector UseResources_Count_Usage = "useResources:count:usage:";

    public static readonly Selector WaitForFence = "waitForFence:";
}
