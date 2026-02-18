namespace Metal.NET;

public class MTLAccelerationStructureCommandEncoder(nint nativePtr) : MTLCommandEncoder(nativePtr)
{
    public static implicit operator nint(MTLAccelerationStructureCommandEncoder value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructureCommandEncoder(nint value)
    {
        return new(value);
    }

    public void BuildAccelerationStructure(MTLAccelerationStructure accelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLBuffer scratchBuffer, nuint scratchBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.BuildAccelerationStructureDescriptorScratchBufferScratchBufferOffset, accelerationStructure.NativePtr, descriptor.NativePtr, scratchBuffer.NativePtr, scratchBufferOffset);
    }

    public void CopyAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.CopyAccelerationStructureToAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyAndCompactAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.CopyAndCompactAccelerationStructureToAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, nuint scratchBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.RefitAccelerationStructureDescriptorDestinationScratchBufferScratchBufferOffset, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer.NativePtr, scratchBufferOffset);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, nuint scratchBufferOffset, MTLAccelerationStructureRefitOptions options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.RefitAccelerationStructureDescriptorDestinationScratchBufferScratchBufferOffsetOptions, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer.NativePtr, scratchBufferOffset, (ulong)options);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, Bool8 barrier)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.SampleCountersInBufferAtSampleIndexWithBarrier, sampleBuffer.NativePtr, sampleIndex, barrier);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.UpdateFence, fence.NativePtr);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.UseHeap, heap.NativePtr);
    }

    public void UseResource(MTLResource resource, MTLResourceUsage usage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.UseResourceUsage, resource.NativePtr, (ulong)usage);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.WaitForFence, fence.NativePtr);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.WriteCompactedAccelerationStructureSizeToBufferOffset, accelerationStructure.NativePtr, buffer.NativePtr, offset);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, nuint offset, MTLDataType sizeDataType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.WriteCompactedAccelerationStructureSizeToBufferOffsetSizeDataType, accelerationStructure.NativePtr, buffer.NativePtr, offset, (ulong)sizeDataType);
    }
}

file class MTLAccelerationStructureCommandEncoderSelector
{
    public static readonly Selector BuildAccelerationStructureDescriptorScratchBufferScratchBufferOffset = Selector.Register("buildAccelerationStructure:descriptor:scratchBuffer:scratchBufferOffset:");

    public static readonly Selector CopyAccelerationStructureToAccelerationStructure = Selector.Register("copyAccelerationStructure:toAccelerationStructure:");

    public static readonly Selector CopyAndCompactAccelerationStructureToAccelerationStructure = Selector.Register("copyAndCompactAccelerationStructure:toAccelerationStructure:");

    public static readonly Selector RefitAccelerationStructureDescriptorDestinationScratchBufferScratchBufferOffset = Selector.Register("refitAccelerationStructure:descriptor:destination:scratchBuffer:scratchBufferOffset:");

    public static readonly Selector RefitAccelerationStructureDescriptorDestinationScratchBufferScratchBufferOffsetOptions = Selector.Register("refitAccelerationStructure:descriptor:destination:scratchBuffer:scratchBufferOffset:options:");

    public static readonly Selector SampleCountersInBufferAtSampleIndexWithBarrier = Selector.Register("sampleCountersInBuffer:atSampleIndex:withBarrier:");

    public static readonly Selector UpdateFence = Selector.Register("updateFence:");

    public static readonly Selector UseHeap = Selector.Register("useHeap:");

    public static readonly Selector UseResourceUsage = Selector.Register("useResource:usage:");

    public static readonly Selector WaitForFence = Selector.Register("waitForFence:");

    public static readonly Selector WriteCompactedAccelerationStructureSizeToBufferOffset = Selector.Register("writeCompactedAccelerationStructureSize:toBuffer:offset:");

    public static readonly Selector WriteCompactedAccelerationStructureSizeToBufferOffsetSizeDataType = Selector.Register("writeCompactedAccelerationStructureSize:toBuffer:offset:sizeDataType:");
}
