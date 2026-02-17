namespace Metal.NET;

file class MTLAccelerationStructureCommandEncoderSelector
{
    public static readonly Selector BuildAccelerationStructure_descriptor_scratchBuffer_scratchBufferOffset_ = Selector.Register("buildAccelerationStructure:descriptor:scratchBuffer:scratchBufferOffset:");
    public static readonly Selector CopyAccelerationStructure_destinationAccelerationStructure_ = Selector.Register("copyAccelerationStructure:destinationAccelerationStructure:");
    public static readonly Selector CopyAndCompactAccelerationStructure_destinationAccelerationStructure_ = Selector.Register("copyAndCompactAccelerationStructure:destinationAccelerationStructure:");
    public static readonly Selector RefitAccelerationStructure_descriptor_destinationAccelerationStructure_scratchBuffer_scratchBufferOffset_ = Selector.Register("refitAccelerationStructure:descriptor:destinationAccelerationStructure:scratchBuffer:scratchBufferOffset:");
    public static readonly Selector RefitAccelerationStructure_descriptor_destinationAccelerationStructure_scratchBuffer_scratchBufferOffset_options_ = Selector.Register("refitAccelerationStructure:descriptor:destinationAccelerationStructure:scratchBuffer:scratchBufferOffset:options:");
    public static readonly Selector SampleCountersInBuffer_sampleIndex_barrier_ = Selector.Register("sampleCountersInBuffer:sampleIndex:barrier:");
    public static readonly Selector UpdateFence_ = Selector.Register("updateFence:");
    public static readonly Selector UseHeap_ = Selector.Register("useHeap:");
    public static readonly Selector UseResource_usage_ = Selector.Register("useResource:usage:");
    public static readonly Selector WaitForFence_ = Selector.Register("waitForFence:");
    public static readonly Selector WriteCompactedAccelerationStructureSize_buffer_offset_ = Selector.Register("writeCompactedAccelerationStructureSize:buffer:offset:");
    public static readonly Selector WriteCompactedAccelerationStructureSize_buffer_offset_sizeDataType_ = Selector.Register("writeCompactedAccelerationStructureSize:buffer:offset:sizeDataType:");
}

public class MTLAccelerationStructureCommandEncoder : IDisposable
{
    public MTLAccelerationStructureCommandEncoder(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public void BuildAccelerationStructure(MTLAccelerationStructure accelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLBuffer scratchBuffer, nuint scratchBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.BuildAccelerationStructure_descriptor_scratchBuffer_scratchBufferOffset_, accelerationStructure.NativePtr, descriptor.NativePtr, scratchBuffer.NativePtr, (nint)scratchBufferOffset);
    }

    public void CopyAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.CopyAccelerationStructure_destinationAccelerationStructure_, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyAndCompactAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.CopyAndCompactAccelerationStructure_destinationAccelerationStructure_, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, nuint scratchBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.RefitAccelerationStructure_descriptor_destinationAccelerationStructure_scratchBuffer_scratchBufferOffset_, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer.NativePtr, (nint)scratchBufferOffset);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, nuint scratchBufferOffset, nuint options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.RefitAccelerationStructure_descriptor_destinationAccelerationStructure_scratchBuffer_scratchBufferOffset_options_, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer.NativePtr, (nint)scratchBufferOffset, (nint)options);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, Bool8 barrier)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.SampleCountersInBuffer_sampleIndex_barrier_, sampleBuffer.NativePtr, (nint)sampleIndex, (nint)barrier.Value);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.UpdateFence_, fence.NativePtr);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.UseHeap_, heap.NativePtr);
    }

    public void UseResource(MTLResource resource, nuint usage)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.UseResource_usage_, resource.NativePtr, (nint)usage);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.WaitForFence_, fence.NativePtr);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, nuint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.WriteCompactedAccelerationStructureSize_buffer_offset_, accelerationStructure.NativePtr, buffer.NativePtr, (nint)offset);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, nuint offset, MTLDataType sizeDataType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoderSelector.WriteCompactedAccelerationStructureSize_buffer_offset_sizeDataType_, accelerationStructure.NativePtr, buffer.NativePtr, (nint)offset, (nint)(uint)sizeDataType);
    }

}
