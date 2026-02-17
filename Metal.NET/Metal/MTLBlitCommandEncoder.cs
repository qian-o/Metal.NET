namespace Metal.NET;

public class MTLBlitCommandEncoder : IDisposable
{
    public MTLBlitCommandEncoder(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void CopyFromBuffer(MTLBuffer sourceBuffer, uint sourceOffset, uint sourceBytesPerRow, uint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, uint destinationSlice, uint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin, sourceBuffer.NativePtr, (nint)sourceOffset, (nint)sourceBytesPerRow, (nint)sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, (nint)destinationSlice, (nint)destinationLevel, destinationOrigin);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, uint sourceOffset, MTLBuffer destinationBuffer, uint destinationOffset, uint size)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromBufferSourceOffsetDestinationBufferDestinationOffsetSize, sourceBuffer.NativePtr, (nint)sourceOffset, destinationBuffer.NativePtr, (nint)destinationOffset, (nint)size);
    }

    public void CopyFromTensor(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTensorSourceOriginSourceDimensionsDestinationTensorDestinationOriginDestinationDimensions, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, uint sourceSlice, uint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, uint destinationSlice, uint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin, sourceTexture.NativePtr, (nint)sourceSlice, (nint)sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, (nint)destinationSlice, (nint)destinationLevel, destinationOrigin);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, uint sourceSlice, uint sourceLevel, MTLTexture destinationTexture, uint destinationSlice, uint destinationLevel, uint sliceCount, uint levelCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelDestinationTextureDestinationSliceDestinationLevelSliceCountLevelCount, sourceTexture.NativePtr, (nint)sourceSlice, (nint)sourceLevel, destinationTexture.NativePtr, (nint)destinationSlice, (nint)destinationLevel, (nint)sliceCount, (nint)levelCount);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTextureDestinationTexture, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }

    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.GenerateMipmaps, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeContentsForCPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture, uint slice, uint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeContentsForCPUAccessSliceLevel, texture.NativePtr, (nint)slice, (nint)level);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeContentsForGPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture, uint slice, uint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeContentsForGPUAccessSliceLevel, texture.NativePtr, (nint)slice, (nint)level);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, uint sampleIndex, Bool8 barrier)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.SampleCountersInBufferSampleIndexBarrier, sampleBuffer.NativePtr, (nint)sampleIndex, (nint)barrier.Value);
    }

    public void SynchronizeResource(MTLResource resource)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.SynchronizeResource, resource.NativePtr);
    }

    public void SynchronizeTexture(MTLTexture texture, uint slice, uint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.SynchronizeTextureSliceLevel, texture.NativePtr, (nint)slice, (nint)level);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.UpdateFence, fence.NativePtr);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.WaitForFence, fence.NativePtr);
    }

}

file class MTLBlitCommandEncoderSelector
{
    public static readonly Selector CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin = Selector.Register("copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:");

    public static readonly Selector CopyFromBufferSourceOffsetDestinationBufferDestinationOffsetSize = Selector.Register("copyFromBuffer:sourceOffset:destinationBuffer:destinationOffset:size:");

    public static readonly Selector CopyFromTensorSourceOriginSourceDimensionsDestinationTensorDestinationOriginDestinationDimensions = Selector.Register("copyFromTensor:sourceOrigin:sourceDimensions:destinationTensor:destinationOrigin:destinationDimensions:");

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:");

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelDestinationTextureDestinationSliceDestinationLevelSliceCountLevelCount = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:destinationTexture:destinationSlice:destinationLevel:sliceCount:levelCount:");

    public static readonly Selector CopyFromTextureDestinationTexture = Selector.Register("copyFromTexture:destinationTexture:");

    public static readonly Selector GenerateMipmaps = Selector.Register("generateMipmaps:");

    public static readonly Selector OptimizeContentsForCPUAccess = Selector.Register("optimizeContentsForCPUAccess:");

    public static readonly Selector OptimizeContentsForCPUAccessSliceLevel = Selector.Register("optimizeContentsForCPUAccess:slice:level:");

    public static readonly Selector OptimizeContentsForGPUAccess = Selector.Register("optimizeContentsForGPUAccess:");

    public static readonly Selector OptimizeContentsForGPUAccessSliceLevel = Selector.Register("optimizeContentsForGPUAccess:slice:level:");

    public static readonly Selector SampleCountersInBufferSampleIndexBarrier = Selector.Register("sampleCountersInBuffer:sampleIndex:barrier:");

    public static readonly Selector SynchronizeResource = Selector.Register("synchronizeResource:");

    public static readonly Selector SynchronizeTextureSliceLevel = Selector.Register("synchronizeTexture:slice:level:");

    public static readonly Selector UpdateFence = Selector.Register("updateFence:");

    public static readonly Selector WaitForFence = Selector.Register("waitForFence:");
}
