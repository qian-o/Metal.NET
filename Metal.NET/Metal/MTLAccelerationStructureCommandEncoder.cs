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

    public void Build(MTLAccelerationStructure accelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLBuffer scratchBuffer, nuint scratchBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.BuildAccelerationStructure_Descriptor_ScratchBuffer_ScratchBufferOffset, accelerationStructure.NativePtr, descriptor.NativePtr, scratchBuffer.NativePtr, scratchBufferOffset);
    }

    public void Refit(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, nuint scratchBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.RefitAccelerationStructure_Descriptor_Destination_ScratchBuffer_ScratchBufferOffset, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer.NativePtr, scratchBufferOffset);
    }

    public void Refit(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, nuint scratchBufferOffset, MTLAccelerationStructureRefitOptions options)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.RefitAccelerationStructure_Descriptor_Destination_ScratchBuffer_ScratchBufferOffset_Options, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer.NativePtr, scratchBufferOffset, (nuint)options);
    }

    public void Copy(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.CopyAccelerationStructure_ToAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void WriteCompactedSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, nuint offset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.WriteCompactedAccelerationStructureSize_ToBuffer_Offset, accelerationStructure.NativePtr, buffer.NativePtr, offset);
    }

    public void WriteCompactedSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, nuint offset, MTLDataType sizeDataType)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.WriteCompactedAccelerationStructureSize_ToBuffer_Offset_SizeDataType, accelerationStructure.NativePtr, buffer.NativePtr, offset, (nuint)sizeDataType);
    }

    public void CopyAndCompact(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.CopyAndCompactAccelerationStructure_ToAccelerationStructure, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
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
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UseResource_Usage, resource.NativePtr, (nuint)usage);
    }

    public unsafe void UseResources(MTLResource[] resources, MTLResourceUsage usage)
    {
        nint* pResources = stackalloc nint[resources.Length];
        for (int i = 0; i < resources.Length; i++)
        {
            pResources[i] = resources[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UseResources_Count_Usage, (nint)pResources, (nuint)resources.Length, (nuint)usage);
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

        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UseHeaps_Count, (nint)pHeaps, (nuint)heaps.Length);
    }

    public void SampleCounters(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.SampleCountersInBuffer_AtSampleIndex_WithBarrier, sampleBuffer.NativePtr, sampleIndex, barrier);
    }
}

file static class MTLAccelerationStructureCommandEncoderBindings
{
    public static readonly Selector BuildAccelerationStructure_Descriptor_ScratchBuffer_ScratchBufferOffset = "buildAccelerationStructure:descriptor:scratchBuffer:scratchBufferOffset:";

    public static readonly Selector CopyAccelerationStructure_ToAccelerationStructure = "copyAccelerationStructure:toAccelerationStructure:";

    public static readonly Selector CopyAndCompactAccelerationStructure_ToAccelerationStructure = "copyAndCompactAccelerationStructure:toAccelerationStructure:";

    public static readonly Selector RefitAccelerationStructure_Descriptor_Destination_ScratchBuffer_ScratchBufferOffset = "refitAccelerationStructure:descriptor:destination:scratchBuffer:scratchBufferOffset:";

    public static readonly Selector RefitAccelerationStructure_Descriptor_Destination_ScratchBuffer_ScratchBufferOffset_Options = "refitAccelerationStructure:descriptor:destination:scratchBuffer:scratchBufferOffset:options:";

    public static readonly Selector SampleCountersInBuffer_AtSampleIndex_WithBarrier = "sampleCountersInBuffer:atSampleIndex:withBarrier:";

    public static readonly Selector UpdateFence = "updateFence:";

    public static readonly Selector UseHeap = "useHeap:";

    public static readonly Selector UseHeaps_Count = "useHeaps:count:";

    public static readonly Selector UseResource_Usage = "useResource:usage:";

    public static readonly Selector UseResources_Count_Usage = "useResources:count:usage:";

    public static readonly Selector WaitForFence = "waitForFence:";

    public static readonly Selector WriteCompactedAccelerationStructureSize_ToBuffer_Offset = "writeCompactedAccelerationStructureSize:toBuffer:offset:";

    public static readonly Selector WriteCompactedAccelerationStructureSize_ToBuffer_Offset_SizeDataType = "writeCompactedAccelerationStructureSize:toBuffer:offset:sizeDataType:";
}
