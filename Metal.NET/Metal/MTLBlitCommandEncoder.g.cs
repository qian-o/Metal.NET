namespace Metal.NET;

file class MTLBlitCommandEncoderSelector
{
    public static readonly Selector CopyFromBuffer_sourceOffset_sourceBytesPerRow_sourceBytesPerImage_sourceSize_destinationTexture_destinationSlice_destinationLevel_destinationOrigin_ = Selector.Register("copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:");
    public static readonly Selector CopyFromBuffer_sourceOffset_destinationBuffer_destinationOffset_size_ = Selector.Register("copyFromBuffer:sourceOffset:destinationBuffer:destinationOffset:size:");
    public static readonly Selector CopyFromTensor_sourceOrigin_sourceDimensions_destinationTensor_destinationOrigin_destinationDimensions_ = Selector.Register("copyFromTensor:sourceOrigin:sourceDimensions:destinationTensor:destinationOrigin:destinationDimensions:");
    public static readonly Selector CopyFromTexture_sourceSlice_sourceLevel_sourceOrigin_sourceSize_destinationTexture_destinationSlice_destinationLevel_destinationOrigin_ = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:");
    public static readonly Selector CopyFromTexture_sourceSlice_sourceLevel_destinationTexture_destinationSlice_destinationLevel_sliceCount_levelCount_ = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:destinationTexture:destinationSlice:destinationLevel:sliceCount:levelCount:");
    public static readonly Selector CopyFromTexture_destinationTexture_ = Selector.Register("copyFromTexture:destinationTexture:");
    public static readonly Selector GenerateMipmaps_ = Selector.Register("generateMipmaps:");
    public static readonly Selector OptimizeContentsForCPUAccess_ = Selector.Register("optimizeContentsForCPUAccess:");
    public static readonly Selector OptimizeContentsForCPUAccess_slice_level_ = Selector.Register("optimizeContentsForCPUAccess:slice:level:");
    public static readonly Selector OptimizeContentsForGPUAccess_ = Selector.Register("optimizeContentsForGPUAccess:");
    public static readonly Selector OptimizeContentsForGPUAccess_slice_level_ = Selector.Register("optimizeContentsForGPUAccess:slice:level:");
    public static readonly Selector SampleCountersInBuffer_sampleIndex_barrier_ = Selector.Register("sampleCountersInBuffer:sampleIndex:barrier:");
    public static readonly Selector SynchronizeResource_ = Selector.Register("synchronizeResource:");
    public static readonly Selector SynchronizeTexture_slice_level_ = Selector.Register("synchronizeTexture:slice:level:");
    public static readonly Selector UpdateFence_ = Selector.Register("updateFence:");
    public static readonly Selector WaitForFence_ = Selector.Register("waitForFence:");
}

public class MTLBlitCommandEncoder : IDisposable
{
    public MTLBlitCommandEncoder(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLBlitCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLBlitCommandEncoder value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLBlitCommandEncoder(nint value)
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

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromBuffer_sourceOffset_sourceBytesPerRow_sourceBytesPerImage_sourceSize_destinationTexture_destinationSlice_destinationLevel_destinationOrigin_, sourceBuffer.NativePtr, (nint)sourceOffset, (nint)sourceBytesPerRow, (nint)sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, (nint)destinationSlice, (nint)destinationLevel, destinationOrigin);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, MTLBuffer destinationBuffer, nuint destinationOffset, nuint size)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromBuffer_sourceOffset_destinationBuffer_destinationOffset_size_, sourceBuffer.NativePtr, (nint)sourceOffset, destinationBuffer.NativePtr, (nint)destinationOffset, (nint)size);
    }

    public void CopyFromTensor(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTensor_sourceOrigin_sourceDimensions_destinationTensor_destinationOrigin_destinationDimensions_, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTexture_sourceSlice_sourceLevel_sourceOrigin_sourceSize_destinationTexture_destinationSlice_destinationLevel_destinationOrigin_, sourceTexture.NativePtr, (nint)sourceSlice, (nint)sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, (nint)destinationSlice, (nint)destinationLevel, destinationOrigin);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, nuint sliceCount, nuint levelCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTexture_sourceSlice_sourceLevel_destinationTexture_destinationSlice_destinationLevel_sliceCount_levelCount_, sourceTexture.NativePtr, (nint)sourceSlice, (nint)sourceLevel, destinationTexture.NativePtr, (nint)destinationSlice, (nint)destinationLevel, (nint)sliceCount, (nint)levelCount);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTexture_destinationTexture_, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }

    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitCommandEncoderSelector.GenerateMipmaps_, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeContentsForCPUAccess_, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeContentsForCPUAccess_slice_level_, texture.NativePtr, (nint)slice, (nint)level);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeContentsForGPUAccess_, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeContentsForGPUAccess_slice_level_, texture.NativePtr, (nint)slice, (nint)level);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, Bool8 barrier)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitCommandEncoderSelector.SampleCountersInBuffer_sampleIndex_barrier_, sampleBuffer.NativePtr, (nint)sampleIndex, (nint)barrier.Value);
    }

    public void SynchronizeResource(MTLResource resource)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitCommandEncoderSelector.SynchronizeResource_, resource.NativePtr);
    }

    public void SynchronizeTexture(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitCommandEncoderSelector.SynchronizeTexture_slice_level_, texture.NativePtr, (nint)slice, (nint)level);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitCommandEncoderSelector.UpdateFence_, fence.NativePtr);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitCommandEncoderSelector.WaitForFence_, fence.NativePtr);
    }

}
