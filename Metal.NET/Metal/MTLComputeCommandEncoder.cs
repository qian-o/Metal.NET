namespace Metal.NET;

public class MTLComputeCommandEncoder : IDisposable
{
    public MTLComputeCommandEncoder(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLComputeCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDispatchType DispatchType => (MTLDispatchType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLComputeCommandEncoderSelector.DispatchType));

    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.DispatchThreadgroupsThreadsPerThreadgroup, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreadgroups(MTLBuffer indirectBuffer, uint indirectBufferOffset, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.DispatchThreadgroupsIndirectBufferOffsetThreadsPerThreadgroup, indirectBuffer.NativePtr, (nuint)indirectBufferOffset, threadsPerThreadgroup);
    }

    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.DispatchThreadsThreadsPerThreadgroup, threadsPerGrid, threadsPerThreadgroup);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.ExecuteCommandsInBufferExecutionRange, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, uint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.ExecuteCommandsInBufferIndirectRangeBufferIndirectBufferOffset, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, (nuint)indirectBufferOffset);
    }

    public void MemoryBarrier(uint scope)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.MemoryBarrier, (nuint)scope);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, uint sampleIndex, Bool8 barrier)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SampleCountersInBufferSampleIndexBarrier, sampleBuffer.NativePtr, (nuint)sampleIndex, barrier);
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, uint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetAccelerationStructureBufferIndex, accelerationStructure.NativePtr, (nuint)bufferIndex);
    }

    public void SetBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBufferOffsetIndex, buffer.NativePtr, (nuint)offset, (nuint)index);
    }

    public void SetBuffer(MTLBuffer buffer, uint offset, uint stride, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBufferOffsetStrideIndex, buffer.NativePtr, (nuint)offset, (nuint)stride, (nuint)index);
    }

    public void SetBufferOffset(uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBufferOffsetIndex2, (nuint)offset, (nuint)index);
    }

    public void SetBufferOffset(uint offset, uint stride, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBufferOffsetStrideIndex3, (nuint)offset, (nuint)stride, (nuint)index);
    }

    public void SetBytes(int bytes, uint length, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBytesLengthIndex, bytes, (nuint)length, (nuint)index);
    }

    public void SetBytes(int bytes, uint length, uint stride, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBytesLengthStrideIndex, bytes, (nuint)length, (nuint)stride, (nuint)index);
    }

    public void SetComputePipelineState(MTLComputePipelineState state)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetComputePipelineState, state.NativePtr);
    }

    public void SetImageblockWidth(uint width, uint height)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetImageblockWidthHeight, (nuint)width, (nuint)height);
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, uint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetIntersectionFunctionTableBufferIndex, intersectionFunctionTable.NativePtr, (nuint)bufferIndex);
    }

    public void SetSamplerState(MTLSamplerState sampler, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetSamplerStateIndex, sampler.NativePtr, (nuint)index);
    }

    public void SetSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetSamplerStateLodMinClampLodMaxClampIndex, sampler.NativePtr, lodMinClamp, lodMaxClamp, (nuint)index);
    }

    public void SetStageInRegion(MTLRegion region)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetStageInRegion, region);
    }

    public void SetStageInRegion(MTLBuffer indirectBuffer, uint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetStageInRegionIndirectBufferOffset, indirectBuffer.NativePtr, (nuint)indirectBufferOffset);
    }

    public void SetTexture(MTLTexture texture, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetTextureIndex, texture.NativePtr, (nuint)index);
    }

    public void SetThreadgroupMemoryLength(uint length, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetThreadgroupMemoryLengthIndex, (nuint)length, (nuint)index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, uint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetVisibleFunctionTableBufferIndex, visibleFunctionTable.NativePtr, (nuint)bufferIndex);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.UpdateFence, fence.NativePtr);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.UseHeap, heap.NativePtr);
    }

    public void UseResource(MTLResource resource, uint usage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.UseResourceUsage, resource.NativePtr, (nuint)usage);
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

    public static readonly Selector DispatchThreadgroupsThreadsPerThreadgroup = Selector.Register("dispatchThreadgroups:threadsPerThreadgroup:");

    public static readonly Selector DispatchThreadgroupsIndirectBufferOffsetThreadsPerThreadgroup = Selector.Register("dispatchThreadgroups:indirectBufferOffset:threadsPerThreadgroup:");

    public static readonly Selector DispatchThreadsThreadsPerThreadgroup = Selector.Register("dispatchThreads:threadsPerThreadgroup:");

    public static readonly Selector ExecuteCommandsInBufferExecutionRange = Selector.Register("executeCommandsInBuffer:executionRange:");

    public static readonly Selector ExecuteCommandsInBufferIndirectRangeBufferIndirectBufferOffset = Selector.Register("executeCommandsInBuffer:indirectRangeBuffer:indirectBufferOffset:");

    public static readonly Selector MemoryBarrier = Selector.Register("memoryBarrier:");

    public static readonly Selector SampleCountersInBufferSampleIndexBarrier = Selector.Register("sampleCountersInBuffer:sampleIndex:barrier:");

    public static readonly Selector SetAccelerationStructureBufferIndex = Selector.Register("setAccelerationStructure:bufferIndex:");

    public static readonly Selector SetBufferOffsetIndex = Selector.Register("setBuffer:offset:index:");

    public static readonly Selector SetBufferOffsetStrideIndex = Selector.Register("setBuffer:offset:stride:index:");

    public static readonly Selector SetBufferOffsetIndex2 = Selector.Register("setBufferOffset:index:");

    public static readonly Selector SetBufferOffsetStrideIndex3 = Selector.Register("setBufferOffset:stride:index:");

    public static readonly Selector SetBytesLengthIndex = Selector.Register("setBytes:length:index:");

    public static readonly Selector SetBytesLengthStrideIndex = Selector.Register("setBytes:length:stride:index:");

    public static readonly Selector SetComputePipelineState = Selector.Register("setComputePipelineState:");

    public static readonly Selector SetImageblockWidthHeight = Selector.Register("setImageblockWidth:height:");

    public static readonly Selector SetIntersectionFunctionTableBufferIndex = Selector.Register("setIntersectionFunctionTable:bufferIndex:");

    public static readonly Selector SetSamplerStateIndex = Selector.Register("setSamplerState:index:");

    public static readonly Selector SetSamplerStateLodMinClampLodMaxClampIndex = Selector.Register("setSamplerState:lodMinClamp:lodMaxClamp:index:");

    public static readonly Selector SetStageInRegion = Selector.Register("setStageInRegion:");

    public static readonly Selector SetStageInRegionIndirectBufferOffset = Selector.Register("setStageInRegion:indirectBufferOffset:");

    public static readonly Selector SetTextureIndex = Selector.Register("setTexture:index:");

    public static readonly Selector SetThreadgroupMemoryLengthIndex = Selector.Register("setThreadgroupMemoryLength:index:");

    public static readonly Selector SetVisibleFunctionTableBufferIndex = Selector.Register("setVisibleFunctionTable:bufferIndex:");

    public static readonly Selector UpdateFence = Selector.Register("updateFence:");

    public static readonly Selector UseHeap = Selector.Register("useHeap:");

    public static readonly Selector UseResourceUsage = Selector.Register("useResource:usage:");

    public static readonly Selector WaitForFence = Selector.Register("waitForFence:");
}
