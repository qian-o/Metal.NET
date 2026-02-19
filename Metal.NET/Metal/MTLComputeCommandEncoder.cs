namespace Metal.NET;

public class MTLComputeCommandEncoder(nint nativePtr) : MTLCommandEncoder(nativePtr)
{
    public MTLDispatchType DispatchType
    {
        get => (MTLDispatchType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputeCommandEncoderBindings.DispatchType);
    }

    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.DispatchThreadgroups, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreadgroups(MTLBuffer indirectBuffer, nuint indirectBufferOffset, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.DispatchThreadgroups, indirectBuffer.NativePtr, indirectBufferOffset, threadsPerThreadgroup);
    }

    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.DispatchThreads, threadsPerGrid, threadsPerThreadgroup);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.ExecuteCommandsInBuffer, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.ExecuteCommandsInBuffer, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, indirectBufferOffset);
    }

    public void MemoryBarrier(MTLBarrierScope scope)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.MemoryBarrier, (nuint)scope);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SampleCountersInBuffer, sampleBuffer.NativePtr, sampleIndex, (Bool8)barrier);
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBuffer, buffer.NativePtr, offset, index);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBuffer, buffer.NativePtr, offset, stride, index);
    }

    public void SetBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBufferOffset, offset, index);
    }

    public void SetBufferOffset(nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBufferOffset, offset, stride, index);
    }

    public void SetBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBytes, bytes, length, index);
    }

    public void SetBytes(nint bytes, nuint length, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetBytes, bytes, length, stride, index);
    }

    public void SetComputePipelineState(MTLComputePipelineState state)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetComputePipelineState, state.NativePtr);
    }

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetImageblockWidth, width, height);
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetSamplerState, sampler.NativePtr, index);
    }

    public void SetSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetSamplerState, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetStageInRegion(MTLRegion region)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetStageInRegion, region);
    }

    public void SetStageInRegion(MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetStageInRegion, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetTexture, texture.NativePtr, index);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetThreadgroupMemoryLength, length, index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.SetVisibleFunctionTable, visibleFunctionTable.NativePtr, bufferIndex);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.UpdateFence, fence.NativePtr);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.UseHeap, heap.NativePtr);
    }

    public void UseResource(MTLResource resource, MTLResourceUsage usage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.UseResource, resource.NativePtr, (nuint)usage);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderBindings.WaitForFence, fence.NativePtr);
    }
}

file static class MTLComputeCommandEncoderBindings
{
    public static readonly Selector DispatchThreadgroups = "dispatchThreadgroups:threadsPerThreadgroup:";

    public static readonly Selector DispatchThreads = "dispatchThreads:threadsPerThreadgroup:";

    public static readonly Selector DispatchType = "dispatchType";

    public static readonly Selector ExecuteCommandsInBuffer = "executeCommandsInBuffer:withRange:";

    public static readonly Selector MemoryBarrier = "memoryBarrierWithScope:";

    public static readonly Selector SampleCountersInBuffer = "sampleCountersInBuffer:atSampleIndex:withBarrier:";

    public static readonly Selector SetAccelerationStructure = "setAccelerationStructure:atBufferIndex:";

    public static readonly Selector SetBuffer = "setBuffer:offset:atIndex:";

    public static readonly Selector SetBufferOffset = "setBufferOffset:atIndex:";

    public static readonly Selector SetBytes = "setBytes:length:atIndex:";

    public static readonly Selector SetComputePipelineState = "setComputePipelineState:";

    public static readonly Selector SetImageblockWidth = "setImageblockWidth:height:";

    public static readonly Selector SetIntersectionFunctionTable = "setIntersectionFunctionTable:atBufferIndex:";

    public static readonly Selector SetSamplerState = "setSamplerState:atIndex:";

    public static readonly Selector SetStageInRegion = "setStageInRegion:";

    public static readonly Selector SetTexture = "setTexture:atIndex:";

    public static readonly Selector SetThreadgroupMemoryLength = "setThreadgroupMemoryLength:atIndex:";

    public static readonly Selector SetVisibleFunctionTable = "setVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector UpdateFence = "updateFence:";

    public static readonly Selector UseHeap = "useHeap:";

    public static readonly Selector UseResource = "useResource:usage:";

    public static readonly Selector WaitForFence = "waitForFence:";
}
