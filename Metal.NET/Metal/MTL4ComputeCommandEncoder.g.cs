namespace Metal.NET;

file class MTL4ComputeCommandEncoderSelector
{
    public static readonly Selector CopyAccelerationStructure_destinationAccelerationStructure_ = Selector.Register("copyAccelerationStructure:destinationAccelerationStructure:");
    public static readonly Selector CopyAndCompactAccelerationStructure_destinationAccelerationStructure_ = Selector.Register("copyAndCompactAccelerationStructure:destinationAccelerationStructure:");
    public static readonly Selector CopyFromBuffer_sourceOffset_destinationBuffer_destinationOffset_size_ = Selector.Register("copyFromBuffer:sourceOffset:destinationBuffer:destinationOffset:size:");
    public static readonly Selector CopyFromBuffer_sourceOffset_sourceBytesPerRow_sourceBytesPerImage_sourceSize_destinationTexture_destinationSlice_destinationLevel_destinationOrigin_ = Selector.Register("copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:");
    public static readonly Selector CopyFromTensor_sourceOrigin_sourceDimensions_destinationTensor_destinationOrigin_destinationDimensions_ = Selector.Register("copyFromTensor:sourceOrigin:sourceDimensions:destinationTensor:destinationOrigin:destinationDimensions:");
    public static readonly Selector CopyFromTexture_destinationTexture_ = Selector.Register("copyFromTexture:destinationTexture:");
    public static readonly Selector CopyFromTexture_sourceSlice_sourceLevel_destinationTexture_destinationSlice_destinationLevel_sliceCount_levelCount_ = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:destinationTexture:destinationSlice:destinationLevel:sliceCount:levelCount:");
    public static readonly Selector CopyFromTexture_sourceSlice_sourceLevel_sourceOrigin_sourceSize_destinationTexture_destinationSlice_destinationLevel_destinationOrigin_ = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:");
    public static readonly Selector DispatchThreadgroups_threadsPerThreadgroup_ = Selector.Register("dispatchThreadgroups:threadsPerThreadgroup:");
    public static readonly Selector DispatchThreads_threadsPerThreadgroup_ = Selector.Register("dispatchThreads:threadsPerThreadgroup:");
    public static readonly Selector DispatchThreads_ = Selector.Register("dispatchThreads:");
    public static readonly Selector ExecuteCommandsInBuffer_indirectRangeBuffer_ = Selector.Register("executeCommandsInBuffer:indirectRangeBuffer:");
    public static readonly Selector GenerateMipmaps_ = Selector.Register("generateMipmaps:");
    public static readonly Selector OptimizeContentsForCPUAccess_ = Selector.Register("optimizeContentsForCPUAccess:");
    public static readonly Selector OptimizeContentsForCPUAccess_slice_level_ = Selector.Register("optimizeContentsForCPUAccess:slice:level:");
    public static readonly Selector OptimizeContentsForGPUAccess_ = Selector.Register("optimizeContentsForGPUAccess:");
    public static readonly Selector OptimizeContentsForGPUAccess_slice_level_ = Selector.Register("optimizeContentsForGPUAccess:slice:level:");
    public static readonly Selector SetArgumentTable_ = Selector.Register("setArgumentTable:");
    public static readonly Selector SetComputePipelineState_ = Selector.Register("setComputePipelineState:");
    public static readonly Selector SetImageblockWidth_height_ = Selector.Register("setImageblockWidth:height:");
    public static readonly Selector SetThreadgroupMemoryLength_index_ = Selector.Register("setThreadgroupMemoryLength:index:");
    public static readonly Selector WriteTimestamp_counterHeap_index_ = Selector.Register("writeTimestamp:counterHeap:index:");
}

public class MTL4ComputeCommandEncoder : IDisposable
{
    public MTL4ComputeCommandEncoder(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4ComputeCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4ComputeCommandEncoder value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4ComputeCommandEncoder(nint value)
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

    public void CopyAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyAccelerationStructure_destinationAccelerationStructure_, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyAndCompactAccelerationStructure(MTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructure destinationAccelerationStructure)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyAndCompactAccelerationStructure_destinationAccelerationStructure_, sourceAccelerationStructure.NativePtr, destinationAccelerationStructure.NativePtr);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, MTLBuffer destinationBuffer, nuint destinationOffset, nuint size)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromBuffer_sourceOffset_destinationBuffer_destinationOffset_size_, sourceBuffer.NativePtr, (nint)sourceOffset, destinationBuffer.NativePtr, (nint)destinationOffset, (nint)size);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromBuffer_sourceOffset_sourceBytesPerRow_sourceBytesPerImage_sourceSize_destinationTexture_destinationSlice_destinationLevel_destinationOrigin_, sourceBuffer.NativePtr, (nint)sourceOffset, (nint)sourceBytesPerRow, (nint)sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, (nint)destinationSlice, (nint)destinationLevel, destinationOrigin);
    }

    public void CopyFromTensor(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTensor_sourceOrigin_sourceDimensions_destinationTensor_destinationOrigin_destinationDimensions_, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTexture_destinationTexture_, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, nuint sliceCount, nuint levelCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTexture_sourceSlice_sourceLevel_destinationTexture_destinationSlice_destinationLevel_sliceCount_levelCount_, sourceTexture.NativePtr, (nint)sourceSlice, (nint)sourceLevel, destinationTexture.NativePtr, (nint)destinationSlice, (nint)destinationLevel, (nint)sliceCount, (nint)levelCount);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.CopyFromTexture_sourceSlice_sourceLevel_sourceOrigin_sourceSize_destinationTexture_destinationSlice_destinationLevel_destinationOrigin_, sourceTexture.NativePtr, (nint)sourceSlice, (nint)sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, (nint)destinationSlice, (nint)destinationLevel, destinationOrigin);
    }

    public void DispatchThreadgroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.DispatchThreadgroups_threadsPerThreadgroup_, threadgroupsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreads(MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.DispatchThreads_threadsPerThreadgroup_, threadsPerGrid, threadsPerThreadgroup);
    }

    public void DispatchThreads(nuint indirectBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.DispatchThreads_, (nint)indirectBuffer);
    }

    public void ExecuteCommandsInBuffer(MTLIndirectCommandBuffer indirectCommandbuffer, nuint indirectRangeBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.ExecuteCommandsInBuffer_indirectRangeBuffer_, indirectCommandbuffer.NativePtr, (nint)indirectRangeBuffer);
    }

    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.GenerateMipmaps_, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForCPUAccess_, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForCPUAccess_slice_level_, texture.NativePtr, (nint)slice, (nint)level);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForGPUAccess_, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.OptimizeContentsForGPUAccess_slice_level_, texture.NativePtr, (nint)slice, (nint)level);
    }

    public void SetArgumentTable(MTL4ArgumentTable argumentTable)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.SetArgumentTable_, argumentTable.NativePtr);
    }

    public void SetComputePipelineState(MTLComputePipelineState state)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.SetComputePipelineState_, state.NativePtr);
    }

    public void SetImageblockWidth(nuint width, nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.SetImageblockWidth_height_, (nint)width, (nint)height);
    }

    public void SetThreadgroupMemoryLength(nuint length, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.SetThreadgroupMemoryLength_index_, (nint)length, (nint)index);
    }

    public void WriteTimestamp(MTL4TimestampGranularity granularity, MTL4CounterHeap counterHeap, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4ComputeCommandEncoderSelector.WriteTimestamp_counterHeap_index_, (nint)(uint)granularity, counterHeap.NativePtr, (nint)index);
    }

}
