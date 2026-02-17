using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLAccelerationStructureCommandEncoder_Selectors
{
    internal static readonly Selector buildAccelerationStructure_descriptor_scratchBuffer_scratchBufferOffset_ = Selector.Register("buildAccelerationStructure:descriptor:scratchBuffer:scratchBufferOffset:");
    internal static readonly Selector copyAccelerationStructure_destinationAccelerationStructure_ = Selector.Register("copyAccelerationStructure:destinationAccelerationStructure:");
    internal static readonly Selector copyAndCompactAccelerationStructure_destinationAccelerationStructure_ = Selector.Register("copyAndCompactAccelerationStructure:destinationAccelerationStructure:");
    internal static readonly Selector refitAccelerationStructure_descriptor_destinationAccelerationStructure_scratchBuffer_scratchBufferOffset_ = Selector.Register("refitAccelerationStructure:descriptor:destinationAccelerationStructure:scratchBuffer:scratchBufferOffset:");
    internal static readonly Selector refitAccelerationStructure_descriptor_destinationAccelerationStructure_scratchBuffer_scratchBufferOffset_options_ = Selector.Register("refitAccelerationStructure:descriptor:destinationAccelerationStructure:scratchBuffer:scratchBufferOffset:options:");
    internal static readonly Selector sampleCountersInBuffer_sampleIndex_barrier_ = Selector.Register("sampleCountersInBuffer:sampleIndex:barrier:");
    internal static readonly Selector updateFence_ = Selector.Register("updateFence:");
    internal static readonly Selector useHeap_ = Selector.Register("useHeap:");
    internal static readonly Selector useResource_usage_ = Selector.Register("useResource:usage:");
    internal static readonly Selector waitForFence_ = Selector.Register("waitForFence:");
    internal static readonly Selector writeCompactedAccelerationStructureSize_buffer_offset_ = Selector.Register("writeCompactedAccelerationStructureSize:buffer:offset:");
    internal static readonly Selector writeCompactedAccelerationStructureSize_buffer_offset_sizeDataType_ = Selector.Register("writeCompactedAccelerationStructureSize:buffer:offset:sizeDataType:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLAccelerationStructureCommandEncoder
{
    public readonly nint NativePtr;

    public MTLAccelerationStructureCommandEncoder(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLAccelerationStructureCommandEncoder o) => o.NativePtr;
    public static implicit operator MTLAccelerationStructureCommandEncoder(nint ptr) => new MTLAccelerationStructureCommandEncoder(ptr);

    public void BuildAccelerationStructure(MTLAccelerationStructure accelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLBuffer scratchBuffer, nuint scratchBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoder_Selectors.buildAccelerationStructure_descriptor_scratchBuffer_scratchBufferOffset_, accelerationStructure.NativePtr, descriptor.NativePtr, scratchBuffer.NativePtr, (nint)scratchBufferOffset);
    }

    public void CopyAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoder_Selectors.copyAccelerationStructure_destinationAccelerationStructure_, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyAndCompactAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoder_Selectors.copyAndCompactAccelerationStructure_destinationAccelerationStructure_, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, nuint scratchBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoder_Selectors.refitAccelerationStructure_descriptor_destinationAccelerationStructure_scratchBuffer_scratchBufferOffset_, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer.NativePtr, (nint)scratchBufferOffset);
    }

    public void RefitAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, MTLAccelerationStructure destinationAccelerationStructure, MTLBuffer scratchBuffer, nuint scratchBufferOffset, nuint options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoder_Selectors.refitAccelerationStructure_descriptor_destinationAccelerationStructure_scratchBuffer_scratchBufferOffset_options_, sourceAccelerationStructure.NativePtr, descriptor.NativePtr, destinationAccelerationStructure.NativePtr, scratchBuffer.NativePtr, (nint)scratchBufferOffset, (nint)options);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, Bool8 barrier)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoder_Selectors.sampleCountersInBuffer_sampleIndex_barrier_, sampleBuffer.NativePtr, (nint)sampleIndex, (nint)barrier.Value);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoder_Selectors.updateFence_, fence.NativePtr);
    }

    public void UseHeap(MTLHeap heap)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoder_Selectors.useHeap_, heap.NativePtr);
    }

    public void UseResource(MTLResource resource, nuint usage)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoder_Selectors.useResource_usage_, resource.NativePtr, (nint)usage);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoder_Selectors.waitForFence_, fence.NativePtr);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, nuint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoder_Selectors.writeCompactedAccelerationStructureSize_buffer_offset_, accelerationStructure.NativePtr, buffer.NativePtr, (nint)offset);
    }

    public void WriteCompactedAccelerationStructureSize(MTLAccelerationStructure accelerationStructure, MTLBuffer buffer, nuint offset, MTLDataType sizeDataType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureCommandEncoder_Selectors.writeCompactedAccelerationStructureSize_buffer_offset_sizeDataType_, accelerationStructure.NativePtr, buffer.NativePtr, (nint)offset, (nint)(uint)sizeDataType);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
