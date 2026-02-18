namespace Metal.NET;

public class MTLComputeCommandEncoder(nint nativePtr) : MTLCommandEncoder(nativePtr)
{

    public MTLDispatchType DispatchType
    {
        get => (MTLDispatchType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLComputeCommandEncoderSelector.DispatchType);
    }

    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.DispatchThreadgroups, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreadgroups(MTLBuffer indirectBuffer, nuint indirectBufferOffset, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.DispatchThreadgroups, indirectBuffer.NativePtr, indirectBufferOffset, threadsPerThreadgroup);
    }

    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.DispatchThreads, threadsPerGrid, threadsPerThreadgroup);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.ExecuteCommandsInBuffer, indirectCommandBuffer.NativePtr, executionRange);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, MTLBuffer indirectRangeBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.ExecuteCommandsInBuffer, indirectCommandbuffer.NativePtr, indirectRangeBuffer.NativePtr, indirectBufferOffset);
    }

    public void MemoryBarrier(MTLBarrierScope scope)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.MemoryBarrier, (nuint)scope);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SampleCountersInBuffer, sampleBuffer.NativePtr, sampleIndex, (Bool8)barrier);
    }

    public void SetAccelerationStructure(MTLAccelerationStructure accelerationStructure, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetAccelerationStructure, accelerationStructure.NativePtr, bufferIndex);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBuffer, buffer.NativePtr, offset, index);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBuffer, buffer.NativePtr, offset, stride, index);
    }

    public void SetBufferOffset(nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBufferOffset, offset, index);
    }

    public void SetBufferOffset(nuint offset, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBufferOffset, offset, stride, index);
    }

    public void SetBytes(nint bytes, nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBytes, bytes, length, index);
    }

    public void SetBytes(nint bytes, nuint length, nuint stride, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetBytes, bytes, length, stride, index);
    }

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetImageblockWidth, width, height);
    }

    public void SetIntersectionFunctionTable(MTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetIntersectionFunctionTable, intersectionFunctionTable.NativePtr, bufferIndex);
    }

    public void SetSamplerState(MTLSamplerState sampler, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetSamplerState, sampler.NativePtr, index);
    }

    public void SetSamplerState(MTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetSamplerState, sampler.NativePtr, lodMinClamp, lodMaxClamp, index);
    }

    public void SetStageInRegion(MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetStageInRegion, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void SetTexture(MTLTexture texture, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetTexture, texture.NativePtr, index);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetThreadgroupMemoryLength, length, index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable visibleFunctionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.SetVisibleFunctionTable, visibleFunctionTable.NativePtr, bufferIndex);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.UseResource, resource.NativePtr, (nuint)usage);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLComputeCommandEncoderSelector.WaitForFence, fence.NativePtr);
    }
}

file static class MTLComputeCommandEncoderSelector
{
    public static readonly Selector DispatchThreadgroups = Selector.Register("dispatchThreadgroups:threadsPerThreadgroup:");

    public static readonly Selector DispatchThreads = Selector.Register("dispatchThreads:threadsPerThreadgroup:");

    public static readonly Selector DispatchType = Selector.Register("dispatchType");

    public static readonly Selector ExecuteCommandsInBuffer = Selector.Register("executeCommandsInBuffer:withRange:");

    public static readonly Selector MemoryBarrier = Selector.Register("memoryBarrierWithScope:");

    public static readonly Selector SampleCountersInBuffer = Selector.Register("sampleCountersInBuffer:atSampleIndex:withBarrier:");

    public static readonly Selector SetAccelerationStructure = Selector.Register("setAccelerationStructure:atBufferIndex:");

    public static readonly Selector SetBuffer = Selector.Register("setBuffer:offset:atIndex:");

    public static readonly Selector SetBufferOffset = Selector.Register("setBufferOffset:atIndex:");

    public static readonly Selector SetBytes = Selector.Register("setBytes:length:atIndex:");

    public static readonly Selector SetImageblockWidth = Selector.Register("setImageblockWidth:height:");

    public static readonly Selector SetIntersectionFunctionTable = Selector.Register("setIntersectionFunctionTable:atBufferIndex:");

    public static readonly Selector SetSamplerState = Selector.Register("setSamplerState:atIndex:");

    public static readonly Selector SetStageInRegion = Selector.Register("setStageInRegionWithIndirectBuffer:indirectBufferOffset:");

    public static readonly Selector SetTexture = Selector.Register("setTexture:atIndex:");

    public static readonly Selector SetThreadgroupMemoryLength = Selector.Register("setThreadgroupMemoryLength:atIndex:");

    public static readonly Selector SetVisibleFunctionTable = Selector.Register("setVisibleFunctionTable:atBufferIndex:");

    public static readonly Selector UpdateFence = Selector.Register("updateFence:");

    public static readonly Selector UseHeap = Selector.Register("useHeap:");

    public static readonly Selector UseResource = Selector.Register("useResource:usage:");

    public static readonly Selector WaitForFence = Selector.Register("waitForFence:");
}
