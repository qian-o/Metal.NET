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

    public void BuildAccelerationStructure(MTLAccelerationStructure accelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLBuffer scratchBuffer, nuint scratchBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.BuildAccelerationStructure, accelerationStructure.NativePtr, descriptor.NativePtr, scratchBuffer.NativePtr, scratchBufferOffset);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, nuint scratchBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.RefitAccelerationStructure, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer.NativePtr, scratchBufferOffset);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, nuint scratchBufferOffset, MTLAccelerationStructureRefitOptions options)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.RefitAccelerationStructureDescriptorDestinationScratchBufferScratchBufferOffsetOptions, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer.NativePtr, scratchBufferOffset, (nuint)options);
    }

    public void CopyAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.CopyAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, nuint offset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.WriteCompactedAccelerationStructureSize, accelerationStructure.NativePtr, buffer.NativePtr, offset);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, nuint offset, MTLDataType sizeDataType)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.WriteCompactedAccelerationStructureSizeToBufferOffsetSizeDataType, accelerationStructure.NativePtr, buffer.NativePtr, offset, (nuint)sizeDataType);
    }

    public void CopyAndCompactAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.CopyAndCompactAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UpdateFence, fence.NativePtr);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.WaitForFence, fence.NativePtr);
    }

    public void UseResource(MTLResource resource, MTLResourceUsage usage)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UseResource, resource.NativePtr, (nuint)usage);
    }

    public unsafe void UseResources(MTLResource[] resources, MTLResourceUsage usage)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UseResources, (nint)pResources, (nuint)resources.Length, (nuint)usage);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UseHeap, heap.NativePtr);
    }

    public unsafe void UseHeaps(MTLHeap[] heaps)
    {
        nint* pHeaps = stackalloc nint[heaps.Length];
        for (int i = 0; i < heaps.Length; i++)
        {
            pHeaps[i] = heaps[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UseHeaps, (nint)pHeaps, (nuint)heaps.Length);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.SampleCountersInBuffer, sampleBuffer.NativePtr, sampleIndex, barrier);
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
