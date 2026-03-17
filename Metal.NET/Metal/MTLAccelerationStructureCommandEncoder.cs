namespace Metal.NET;

public class MTLAccelerationStructureCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTLCommandEncoder(nativePtr, ownership), INativeObject<MTLAccelerationStructureCommandEncoder>
{
    #region INativeObject
    public static new MTLAccelerationStructureCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLAccelerationStructureCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public void BuildAccelerationStructureDescriptorScratchBufferScratchBufferOffset(MTLAccelerationStructure accelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLBuffer scratchBuffer, nuint scratchBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.BuildAccelerationStructure, accelerationStructure.NativePtr, descriptor.NativePtr, scratchBuffer.NativePtr, scratchBufferOffset);
    }

    public void BuildAccelerationStructure(MTLAccelerationStructure accelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLBuffer scratchBuffer, nuint scratchBufferOffset)
    {
        BuildAccelerationStructureDescriptorScratchBufferScratchBufferOffset(accelerationStructure, descriptor, scratchBuffer, scratchBufferOffset);
    }

    public void RefitAccelerationStructureDescriptorDestinationScratchBufferScratchBufferOffset(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, nuint scratchBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.RefitAccelerationStructure, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer.NativePtr, scratchBufferOffset);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, nuint scratchBufferOffset)
    {
        RefitAccelerationStructureDescriptorDestinationScratchBufferScratchBufferOffset(sourceAccelerationStructure, descriptor, destinationAccelerationStructure, scratchBuffer, scratchBufferOffset);
    }

    public void RefitAccelerationStructureDescriptorDestinationScratchBufferScratchBufferOffsetOptions(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, nuint scratchBufferOffset, MTLAccelerationStructureRefitOptions options)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.RefitAccelerationStructureDescriptorDestinationScratchBufferScratchBufferOffsetOptions, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer.NativePtr, scratchBufferOffset, (nuint)options);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, nuint scratchBufferOffset, MTLAccelerationStructureRefitOptions options)
    {
        RefitAccelerationStructureDescriptorDestinationScratchBufferScratchBufferOffsetOptions(sourceAccelerationStructure, descriptor, destinationAccelerationStructure, scratchBuffer, scratchBufferOffset, options);
    }

    public void CopyAccelerationStructureToAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.CopyAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        CopyAccelerationStructureToAccelerationStructure(sourceAccelerationStructure, destinationAccelerationStructure);
    }

    public void WriteCompactedAccelerationStructureSizeToBufferOffset(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, nuint offset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.WriteCompactedAccelerationStructureSize, accelerationStructure.NativePtr, buffer.NativePtr, offset);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, nuint offset)
    {
        WriteCompactedAccelerationStructureSizeToBufferOffset(accelerationStructure, buffer, offset);
    }

    public void WriteCompactedAccelerationStructureSizeToBufferOffsetSizeDataType(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, nuint offset, MTLDataType sizeDataType)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.WriteCompactedAccelerationStructureSizeToBufferOffsetSizeDataType, accelerationStructure.NativePtr, buffer.NativePtr, offset, (nuint)sizeDataType);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, nuint offset, MTLDataType sizeDataType)
    {
        WriteCompactedAccelerationStructureSizeToBufferOffsetSizeDataType(accelerationStructure, buffer, offset, sizeDataType);
    }

    public void CopyAndCompactAccelerationStructureToAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.CopyAndCompactAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyAndCompactAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        CopyAndCompactAccelerationStructureToAccelerationStructure(sourceAccelerationStructure, destinationAccelerationStructure);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UpdateFence, fence.NativePtr);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.WaitForFence, fence.NativePtr);
    }

    public void UseResourceUsage(MTLResource resource, MTLResourceUsage usage)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UseResource, resource.NativePtr, (nuint)usage);
    }

    public void UseResource(MTLResource resource, MTLResourceUsage usage)
    {
        UseResourceUsage(resource, usage);
    }

    public unsafe void UseResourcesCountUsage(MTLResource[] resources, MTLResourceUsage usage)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UseResources, (nint)pResources, (nuint)resources.Length, (nuint)usage);
    }

    public unsafe void UseResources(MTLResource[] resources, MTLResourceUsage usage)
    {
        UseResourcesCountUsage(resources, usage);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UseHeap, heap.NativePtr);
    }

    public unsafe void UseHeapsCount(MTLHeap[] heaps)
    {
        nint* pHeaps = stackalloc nint[heaps.Length];
        for (int i = 0; i < heaps.Length; i++)
        {
            pHeaps[i] = heaps[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UseHeaps, (nint)pHeaps, (nuint)heaps.Length);
    }

    public unsafe void UseHeaps(MTLHeap[] heaps)
    {
        UseHeapsCount(heaps);
    }

    public void SampleCountersInBufferAtSampleIndexWithBarrier(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.SampleCountersInBuffer, sampleBuffer.NativePtr, sampleIndex, barrier);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        SampleCountersInBufferAtSampleIndexWithBarrier(sampleBuffer, sampleIndex, barrier);
    }
}

file static class MTLAccelerationStructureCommandEncoderBindings
{
    public static readonly Selector BuildAccelerationStructure = "buildAccelerationStructure:descriptor:scratchBuffer:scratchBufferOffset:";

    public static readonly Selector CopyAccelerationStructure = "copyAccelerationStructure:toAccelerationStructure:";

    public static readonly Selector CopyAndCompactAccelerationStructure = "copyAndCompactAccelerationStructure:toAccelerationStructure:";

    public static readonly Selector RefitAccelerationStructure = "refitAccelerationStructure:descriptor:destination:scratchBuffer:scratchBufferOffset:";

    public static readonly Selector RefitAccelerationStructureDescriptorDestinationScratchBufferScratchBufferOffsetOptions = "refitAccelerationStructure:descriptor:destination:scratchBuffer:scratchBufferOffset:options:";

    public static readonly Selector SampleCountersInBuffer = "sampleCountersInBuffer:atSampleIndex:withBarrier:";

    public static readonly Selector UpdateFence = "updateFence:";

    public static readonly Selector UseHeap = "useHeap:";

    public static readonly Selector UseHeaps = "useHeaps:count:";

    public static readonly Selector UseResource = "useResource:usage:";

    public static readonly Selector UseResources = "useResources:count:usage:";

    public static readonly Selector WaitForFence = "waitForFence:";

    public static readonly Selector WriteCompactedAccelerationStructureSize = "writeCompactedAccelerationStructureSize:toBuffer:offset:";

    public static readonly Selector WriteCompactedAccelerationStructureSizeToBufferOffsetSizeDataType = "writeCompactedAccelerationStructureSize:toBuffer:offset:sizeDataType:";
}
