namespace Metal.NET;

public class MTLAccelerationStructureCommandEncoder : IDisposable
{
    public MTLAccelerationStructureCommandEncoder(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLAccelerationStructureCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAccelerationStructureCommandEncoder value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructureCommandEncoder(nint value)
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

    public void BuildAccelerationStructure(MTLAccelerationStructure accelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLBuffer scratchBuffer, uint scratchBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.BuildAccelerationStructureDescriptorScratchBufferScratchBufferOffset, accelerationStructure.NativePtr, descriptor.NativePtr, scratchBuffer.NativePtr, (nuint)scratchBufferOffset);
    }

    public void CopyAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.CopyAccelerationStructureDestinationAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyAndCompactAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.CopyAndCompactAccelerationStructureDestinationAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, uint scratchBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.RefitAccelerationStructureDescriptorDestinationAccelerationStructureScratchBufferScratchBufferOffset, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer.NativePtr, (nuint)scratchBufferOffset);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, uint scratchBufferOffset, uint options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.RefitAccelerationStructureDescriptorDestinationAccelerationStructureScratchBufferScratchBufferOffsetOptions, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer.NativePtr, (nuint)scratchBufferOffset, (nuint)options);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, uint sampleIndex, Bool8 barrier)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.SampleCountersInBufferSampleIndexBarrier, sampleBuffer.NativePtr, (nuint)sampleIndex, barrier);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.UpdateFence, fence.NativePtr);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.UseHeap, heap.NativePtr);
    }

    public void UseResource(MTLResource resource, uint usage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.UseResourceUsage, resource.NativePtr, (nuint)usage);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.WaitForFence, fence.NativePtr);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, uint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.WriteCompactedAccelerationStructureSizeBufferOffset, accelerationStructure.NativePtr, buffer.NativePtr, (nuint)offset);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, uint offset, MTLDataType sizeDataType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.WriteCompactedAccelerationStructureSizeBufferOffsetSizeDataType, accelerationStructure.NativePtr, buffer.NativePtr, (nuint)offset, (uint)sizeDataType);
    }

}

file class MTLAccelerationStructureCommandEncoderSelector
{
    public static readonly Selector BuildAccelerationStructureDescriptorScratchBufferScratchBufferOffset = Selector.Register("buildAccelerationStructure:descriptor:scratchBuffer:scratchBufferOffset:");

    public static readonly Selector CopyAccelerationStructureDestinationAccelerationStructure = Selector.Register("copyAccelerationStructure:destinationAccelerationStructure:");

    public static readonly Selector CopyAndCompactAccelerationStructureDestinationAccelerationStructure = Selector.Register("copyAndCompactAccelerationStructure:destinationAccelerationStructure:");

    public static readonly Selector RefitAccelerationStructureDescriptorDestinationAccelerationStructureScratchBufferScratchBufferOffset = Selector.Register("refitAccelerationStructure:descriptor:destinationAccelerationStructure:scratchBuffer:scratchBufferOffset:");

    public static readonly Selector RefitAccelerationStructureDescriptorDestinationAccelerationStructureScratchBufferScratchBufferOffsetOptions = Selector.Register("refitAccelerationStructure:descriptor:destinationAccelerationStructure:scratchBuffer:scratchBufferOffset:options:");

    public static readonly Selector SampleCountersInBufferSampleIndexBarrier = Selector.Register("sampleCountersInBuffer:sampleIndex:barrier:");

    public static readonly Selector UpdateFence = Selector.Register("updateFence:");

    public static readonly Selector UseHeap = Selector.Register("useHeap:");

    public static readonly Selector UseResourceUsage = Selector.Register("useResource:usage:");

    public static readonly Selector WaitForFence = Selector.Register("waitForFence:");

    public static readonly Selector WriteCompactedAccelerationStructureSizeBufferOffset = Selector.Register("writeCompactedAccelerationStructureSize:buffer:offset:");

    public static readonly Selector WriteCompactedAccelerationStructureSizeBufferOffsetSizeDataType = Selector.Register("writeCompactedAccelerationStructureSize:buffer:offset:sizeDataType:");
}
