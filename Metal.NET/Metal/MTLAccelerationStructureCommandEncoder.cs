namespace Metal.NET;

public readonly struct MTLAccelerationStructureCommandEncoder(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public void BuildAccelerationStructure(MTLAccelerationStructure accelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLBuffer scratchBuffer, nuint scratchBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.BuildAccelerationStructure, accelerationStructure.NativePtr, descriptor.NativePtr, scratchBuffer.NativePtr, scratchBufferOffset);
    }

    public void CopyAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.CopyAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyAndCompactAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.CopyAndCompactAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, nuint scratchBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.RefitAccelerationStructure, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer.NativePtr, scratchBufferOffset);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, nuint scratchBufferOffset, MTLAccelerationStructureRefitOptions options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.RefitAccelerationStructure, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer.NativePtr, scratchBufferOffset, (nuint)options);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.SampleCountersInBuffer, sampleBuffer.NativePtr, sampleIndex, (Bool8)barrier);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UpdateFence, fence.NativePtr);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UseHeap, heap.NativePtr);
    }

    public void UseResource(MTLResource resource, MTLResourceUsage usage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UseResource, resource.NativePtr, (nuint)usage);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.WaitForFence, fence.NativePtr);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, nuint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.WriteCompactedAccelerationStructureSize, accelerationStructure.NativePtr, buffer.NativePtr, offset);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, nuint offset, MTLDataType sizeDataType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.WriteCompactedAccelerationStructureSize, accelerationStructure.NativePtr, buffer.NativePtr, offset, (nuint)sizeDataType);
    }
}

file static class MTLAccelerationStructureCommandEncoderBindings
{
    public static readonly Selector BuildAccelerationStructure = Selector.Register("buildAccelerationStructure:descriptor:scratchBuffer:scratchBufferOffset:");

    public static readonly Selector CopyAccelerationStructure = Selector.Register("copyAccelerationStructure:toAccelerationStructure:");

    public static readonly Selector CopyAndCompactAccelerationStructure = Selector.Register("copyAndCompactAccelerationStructure:toAccelerationStructure:");

    public static readonly Selector RefitAccelerationStructure = Selector.Register("refitAccelerationStructure:descriptor:destination:scratchBuffer:scratchBufferOffset:");

    public static readonly Selector SampleCountersInBuffer = Selector.Register("sampleCountersInBuffer:atSampleIndex:withBarrier:");

    public static readonly Selector UpdateFence = Selector.Register("updateFence:");

    public static readonly Selector UseHeap = Selector.Register("useHeap:");

    public static readonly Selector UseResource = Selector.Register("useResource:usage:");

    public static readonly Selector WaitForFence = Selector.Register("waitForFence:");

    public static readonly Selector WriteCompactedAccelerationStructureSize = Selector.Register("writeCompactedAccelerationStructureSize:toBuffer:offset:");
}
