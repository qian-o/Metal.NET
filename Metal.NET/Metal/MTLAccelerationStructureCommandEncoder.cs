namespace Metal.NET;

public readonly struct MTLAccelerationStructureCommandEncoder(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLCommandEncoder(MTLAccelerationStructureCommandEncoder value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLAccelerationStructureCommandEncoder value) => new(value.NativePtr);

    public MTLAccelerationStructureCommandEncoder Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureCommandEncoderBindings.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureCommandEncoderBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.SetLabel, value.NativePtr);
    }

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

    public unsafe void UseResources(ReadOnlySpan<MTLResource> resources, MTLResourceUsage usage)
    {
        fixed (MTLResource* pResources = resources)
        {
            ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UseResources_Count_Usage, (nint)pResources, (nuint)resources.Length, (nuint)usage);
        }
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UseHeap, heap.NativePtr);
    }

    public unsafe void UseHeaps(ReadOnlySpan<MTLHeap> heaps)
    {
        fixed (MTLHeap* pHeaps = heaps)
        {
            ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.UseHeaps_Count, (nint)pHeaps, (nuint)heaps.Length);
        }
    }

    public void SampleCounters(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.SampleCountersInBuffer_AtSampleIndex_WithBarrier, sampleBuffer.NativePtr, sampleIndex, barrier);
    }

    public void EndEncoding()
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.EndEncoding);
    }

    public void Barrier(MTLStages afterQueueStages, MTLStages beforeStages)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.BarrierAfterQueueStages_BeforeStages, (nuint)afterQueueStages, (nuint)beforeStages);
    }

    public void InsertDebugSignpost(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.InsertDebugSignpost, @string.NativePtr);
    }

    public void PushDebugGroup(NSString @string)
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.PushDebugGroup, @string.NativePtr);
    }

    public void PopDebugGroup()
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureCommandEncoderBindings.PopDebugGroup);
    }
}

file static class MTLAccelerationStructureCommandEncoderBindings
{
    public static readonly Selector BarrierAfterQueueStages_BeforeStages = "barrierAfterQueueStages:beforeStages:";

    public static readonly Selector BuildAccelerationStructure_Descriptor_ScratchBuffer_ScratchBufferOffset = "buildAccelerationStructure:descriptor:scratchBuffer:scratchBufferOffset:";

    public static readonly Selector CopyAccelerationStructure_ToAccelerationStructure = "copyAccelerationStructure:toAccelerationStructure:";

    public static readonly Selector CopyAndCompactAccelerationStructure_ToAccelerationStructure = "copyAndCompactAccelerationStructure:toAccelerationStructure:";

    public static readonly Selector Device = "device";

    public static readonly Selector EndEncoding = "endEncoding";

    public static readonly Selector InsertDebugSignpost = "insertDebugSignpost:";

    public static readonly Selector Label = "label";

    public static readonly Selector PopDebugGroup = "popDebugGroup";

    public static readonly Selector PushDebugGroup = "pushDebugGroup:";

    public static readonly Selector RefitAccelerationStructure_Descriptor_Destination_ScratchBuffer_ScratchBufferOffset = "refitAccelerationStructure:descriptor:destination:scratchBuffer:scratchBufferOffset:";

    public static readonly Selector RefitAccelerationStructure_Descriptor_Destination_ScratchBuffer_ScratchBufferOffset_Options = "refitAccelerationStructure:descriptor:destination:scratchBuffer:scratchBufferOffset:options:";

    public static readonly Selector SampleCountersInBuffer_AtSampleIndex_WithBarrier = "sampleCountersInBuffer:atSampleIndex:withBarrier:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector UpdateFence = "updateFence:";

    public static readonly Selector UseHeap = "useHeap:";

    public static readonly Selector UseHeaps_Count = "useHeaps:count:";

    public static readonly Selector UseResource_Usage = "useResource:usage:";

    public static readonly Selector UseResources_Count_Usage = "useResources:count:usage:";

    public static readonly Selector WaitForFence = "waitForFence:";

    public static readonly Selector WriteCompactedAccelerationStructureSize_ToBuffer_Offset = "writeCompactedAccelerationStructureSize:toBuffer:offset:";

    public static readonly Selector WriteCompactedAccelerationStructureSize_ToBuffer_Offset_SizeDataType = "writeCompactedAccelerationStructureSize:toBuffer:offset:sizeDataType:";
}
