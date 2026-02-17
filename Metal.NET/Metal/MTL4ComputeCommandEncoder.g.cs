using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4ComputeCommandEncoder_Selectors
{
    internal static readonly Selector copyAccelerationStructure_destinationAccelerationStructure_ = Selector.Register("copyAccelerationStructure:destinationAccelerationStructure:");
    internal static readonly Selector copyAndCompactAccelerationStructure_destinationAccelerationStructure_ = Selector.Register("copyAndCompactAccelerationStructure:destinationAccelerationStructure:");
    internal static readonly Selector copyFromBuffer_sourceOffset_destinationBuffer_destinationOffset_size_ = Selector.Register("copyFromBuffer:sourceOffset:destinationBuffer:destinationOffset:size:");
    internal static readonly Selector copyFromBuffer_sourceOffset_sourceBytesPerRow_sourceBytesPerImage_sourceSize_destinationTexture_destinationSlice_destinationLevel_destinationOrigin_ = Selector.Register("copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:");
    internal static readonly Selector copyFromTensor_sourceOrigin_sourceDimensions_destinationTensor_destinationOrigin_destinationDimensions_ = Selector.Register("copyFromTensor:sourceOrigin:sourceDimensions:destinationTensor:destinationOrigin:destinationDimensions:");
    internal static readonly Selector copyFromTexture_destinationTexture_ = Selector.Register("copyFromTexture:destinationTexture:");
    internal static readonly Selector copyFromTexture_sourceSlice_sourceLevel_destinationTexture_destinationSlice_destinationLevel_sliceCount_levelCount_ = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:destinationTexture:destinationSlice:destinationLevel:sliceCount:levelCount:");
    internal static readonly Selector copyFromTexture_sourceSlice_sourceLevel_sourceOrigin_sourceSize_destinationTexture_destinationSlice_destinationLevel_destinationOrigin_ = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:");
    internal static readonly Selector dispatchThreadgroups_threadsPerThreadgroup_ = Selector.Register("dispatchThreadgroups:threadsPerThreadgroup:");
    internal static readonly Selector dispatchThreads_threadsPerThreadgroup_ = Selector.Register("dispatchThreads:threadsPerThreadgroup:");
    internal static readonly Selector dispatchThreads_ = Selector.Register("dispatchThreads:");
    internal static readonly Selector executeCommandsInBuffer_indirectRangeBuffer_ = Selector.Register("executeCommandsInBuffer:indirectRangeBuffer:");
    internal static readonly Selector generateMipmaps_ = Selector.Register("generateMipmaps:");
    internal static readonly Selector optimizeContentsForCPUAccess_ = Selector.Register("optimizeContentsForCPUAccess:");
    internal static readonly Selector optimizeContentsForCPUAccess_slice_level_ = Selector.Register("optimizeContentsForCPUAccess:slice:level:");
    internal static readonly Selector optimizeContentsForGPUAccess_ = Selector.Register("optimizeContentsForGPUAccess:");
    internal static readonly Selector optimizeContentsForGPUAccess_slice_level_ = Selector.Register("optimizeContentsForGPUAccess:slice:level:");
    internal static readonly Selector setArgumentTable_ = Selector.Register("setArgumentTable:");
    internal static readonly Selector setComputePipelineState_ = Selector.Register("setComputePipelineState:");
    internal static readonly Selector setImageblockWidth_height_ = Selector.Register("setImageblockWidth:height:");
    internal static readonly Selector setThreadgroupMemoryLength_index_ = Selector.Register("setThreadgroupMemoryLength:index:");
    internal static readonly Selector writeTimestamp_counterHeap_index_ = Selector.Register("writeTimestamp:counterHeap:index:");
}

public class MTL4ComputeCommandEncoder : IDisposable
{
    public nint NativePtr { get; }

    public MTL4ComputeCommandEncoder(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4ComputeCommandEncoder o) => o.NativePtr;
    public static implicit operator MTL4ComputeCommandEncoder(nint ptr) => new MTL4ComputeCommandEncoder(ptr);

    ~MTL4ComputeCommandEncoder() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    public void CopyAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.copyAccelerationStructure_destinationAccelerationStructure_, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyAndCompactAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.copyAndCompactAccelerationStructure_destinationAccelerationStructure_, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, MTLBuffer destinationBuffer, nuint destinationOffset, nuint size)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.copyFromBuffer_sourceOffset_destinationBuffer_destinationOffset_size_, sourceBuffer.NativePtr, (nint)sourceOffset, destinationBuffer.NativePtr, (nint)destinationOffset, (nint)size);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.copyFromBuffer_sourceOffset_sourceBytesPerRow_sourceBytesPerImage_sourceSize_destinationTexture_destinationSlice_destinationLevel_destinationOrigin_, sourceBuffer.NativePtr, (nint)sourceOffset, (nint)sourceBytesPerRow, (nint)sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, (nint)destinationSlice, (nint)destinationLevel, destinationOrigin);
    }

    public void CopyFromTensor(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.copyFromTensor_sourceOrigin_sourceDimensions_destinationTensor_destinationOrigin_destinationDimensions_, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.copyFromTexture_destinationTexture_, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, nuint sliceCount, nuint levelCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.copyFromTexture_sourceSlice_sourceLevel_destinationTexture_destinationSlice_destinationLevel_sliceCount_levelCount_, sourceTexture.NativePtr, (nint)sourceSlice, (nint)sourceLevel, destinationTexture.NativePtr, (nint)destinationSlice, (nint)destinationLevel, (nint)sliceCount, (nint)levelCount);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.copyFromTexture_sourceSlice_sourceLevel_sourceOrigin_sourceSize_destinationTexture_destinationSlice_destinationLevel_destinationOrigin_, sourceTexture.NativePtr, (nint)sourceSlice, (nint)sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, (nint)destinationSlice, (nint)destinationLevel, destinationOrigin);
    }

    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.dispatchThreadgroups_threadsPerThreadgroup_, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.dispatchThreads_threadsPerThreadgroup_, threadsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreads(nuint indirectBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.dispatchThreads_, (nint)indirectBuffer);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, nuint indirectRangeBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.executeCommandsInBuffer_indirectRangeBuffer_, indirectCommandbuffer.NativePtr, (nint)indirectRangeBuffer);
    }

    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.generateMipmaps_, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.optimizeContentsForCPUAccess_, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.optimizeContentsForCPUAccess_slice_level_, texture.NativePtr, (nint)slice, (nint)level);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.optimizeContentsForGPUAccess_, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.optimizeContentsForGPUAccess_slice_level_, texture.NativePtr, (nint)slice, (nint)level);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.setArgumentTable_, argumentTable.NativePtr);
    }

    public void SetComputePipelineState(MTLComputePipelineState state)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.setComputePipelineState_, state.NativePtr);
    }

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.setImageblockWidth_height_, (nint)width, (nint)height);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.setThreadgroupMemoryLength_index_, (nint)length, (nint)index);
    }

    public void WriteTimestamp(MTL4TimestampGranularity granularity, MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoder_Selectors.writeTimestamp_counterHeap_index_, (nint)(uint)granularity, counterHeap.NativePtr, (nint)index);
    }

}
