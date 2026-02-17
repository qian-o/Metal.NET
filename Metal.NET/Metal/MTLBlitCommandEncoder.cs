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

    public void CopyFromBuffer(MTLBuffer sourceBuffer, uint sourceOffset, uint sourceBytesPerRow, uint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, uint destinationSlice, uint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin, sourceBuffer.NativePtr, (nuint)sourceOffset, (nuint)sourceBytesPerRow, (nuint)sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, (nuint)destinationSlice, (nuint)destinationLevel, destinationOrigin);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, uint sourceOffset, uint sourceBytesPerRow, uint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, uint destinationSlice, uint destinationLevel, MTLOrigin destinationOrigin, uint options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOriginOptions, sourceBuffer.NativePtr, (nuint)sourceOffset, (nuint)sourceBytesPerRow, (nuint)sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, (nuint)destinationSlice, (nuint)destinationLevel, destinationOrigin, (nuint)options);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, uint sourceOffset, MTLBuffer destinationBuffer, uint destinationOffset, uint size)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromBufferSourceOffsetDestinationBufferDestinationOffsetSize, sourceBuffer.NativePtr, (nuint)sourceOffset, destinationBuffer.NativePtr, (nuint)destinationOffset, (nuint)size);
    }

    public void CopyFromTensor(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTensorSourceOriginSourceDimensionsDestinationTensorDestinationOriginDestinationDimensions, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, uint sourceSlice, uint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, uint destinationSlice, uint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin, sourceTexture.NativePtr, (nuint)sourceSlice, (nuint)sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, (nuint)destinationSlice, (nuint)destinationLevel, destinationOrigin);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, uint sourceSlice, uint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, uint destinationOffset, uint destinationBytesPerRow, uint destinationBytesPerImage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImage, sourceTexture.NativePtr, (nuint)sourceSlice, (nuint)sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, (nuint)destinationOffset, (nuint)destinationBytesPerRow, (nuint)destinationBytesPerImage);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, uint sourceSlice, uint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, uint destinationOffset, uint destinationBytesPerRow, uint destinationBytesPerImage, uint options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions, sourceTexture.NativePtr, (nuint)sourceSlice, (nuint)sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, (nuint)destinationOffset, (nuint)destinationBytesPerRow, (nuint)destinationBytesPerImage, (nuint)options);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, uint sourceSlice, uint sourceLevel, MTLTexture destinationTexture, uint destinationSlice, uint destinationLevel, uint sliceCount, uint levelCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelDestinationTextureDestinationSliceDestinationLevelSliceCountLevelCount, sourceTexture.NativePtr, (nuint)sourceSlice, (nuint)sourceLevel, destinationTexture.NativePtr, (nuint)destinationSlice, (nuint)destinationLevel, (nuint)sliceCount, (nuint)levelCount);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTextureDestinationTexture, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }

    public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, uint destinationIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyIndirectCommandBufferSourceRangeDestinationDestinationIndex, source.NativePtr, sourceRange, destination.NativePtr, (nuint)destinationIndex);
    }

    public void FillBuffer(MTLBuffer buffer, NSRange range, byte value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.FillBufferRangeValue, buffer.NativePtr, range, value);
    }

    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.GenerateMipmaps, texture.NativePtr);
    }

    public void GetTextureAccessCounters(MTLTexture texture, MTLRegion region, uint mipLevel, uint slice, Bool8 resetCounters, MTLBuffer countersBuffer, uint countersBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.GetTextureAccessCountersRegionMipLevelSliceResetCountersCountersBufferCountersBufferOffset, texture.NativePtr, region, (nuint)mipLevel, (nuint)slice, resetCounters, countersBuffer.NativePtr, (nuint)countersBufferOffset);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeContentsForCPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture, uint slice, uint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeContentsForCPUAccessSliceLevel, texture.NativePtr, (nuint)slice, (nuint)level);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeContentsForGPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture, uint slice, uint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeContentsForGPUAccessSliceLevel, texture.NativePtr, (nuint)slice, (nuint)level);
    }

    public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeIndirectCommandBufferRange, indirectCommandBuffer.NativePtr, range);
    }

    public void ResetCommandsInBuffer(MTLIndirectCommandBuffer buffer, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.ResetCommandsInBufferRange, buffer.NativePtr, range);
    }

    public void ResetTextureAccessCounters(MTLTexture texture, MTLRegion region, uint mipLevel, uint slice)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.ResetTextureAccessCountersRegionMipLevelSlice, texture.NativePtr, region, (nuint)mipLevel, (nuint)slice);
    }

    public void ResolveCounters(MTLCounterSampleBuffer sampleBuffer, NSRange range, MTLBuffer destinationBuffer, uint destinationOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.ResolveCountersRangeDestinationBufferDestinationOffset, sampleBuffer.NativePtr, range, destinationBuffer.NativePtr, (nuint)destinationOffset);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, uint sampleIndex, Bool8 barrier)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.SampleCountersInBufferSampleIndexBarrier, sampleBuffer.NativePtr, (nuint)sampleIndex, barrier);
    }

    public void SynchronizeResource(MTLResource resource)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.SynchronizeResource, resource.NativePtr);
    }

    public void SynchronizeTexture(MTLTexture texture, uint slice, uint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.SynchronizeTextureSliceLevel, texture.NativePtr, (nuint)slice, (nuint)level);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.UpdateFence, fence.NativePtr);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.WaitForFence, fence.NativePtr);
    }

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

}

file class MTLBlitCommandEncoderSelector
{
    public static readonly Selector CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin = Selector.Register("copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:");

    public static readonly Selector CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOriginOptions = Selector.Register("copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:options:");

    public static readonly Selector CopyFromBufferSourceOffsetDestinationBufferDestinationOffsetSize = Selector.Register("copyFromBuffer:sourceOffset:destinationBuffer:destinationOffset:size:");

    public static readonly Selector CopyFromTensorSourceOriginSourceDimensionsDestinationTensorDestinationOriginDestinationDimensions = Selector.Register("copyFromTensor:sourceOrigin:sourceDimensions:destinationTensor:destinationOrigin:destinationDimensions:");

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:");

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImage = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:destinationBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:");

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:destinationBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:options:");

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelDestinationTextureDestinationSliceDestinationLevelSliceCountLevelCount = Selector.Register("copyFromTexture:sourceSlice:sourceLevel:destinationTexture:destinationSlice:destinationLevel:sliceCount:levelCount:");

    public static readonly Selector CopyFromTextureDestinationTexture = Selector.Register("copyFromTexture:destinationTexture:");

    public static readonly Selector CopyIndirectCommandBufferSourceRangeDestinationDestinationIndex = Selector.Register("copyIndirectCommandBuffer:sourceRange:destination:destinationIndex:");

    public static readonly Selector FillBufferRangeValue = Selector.Register("fillBuffer:range:value:");

    public static readonly Selector GenerateMipmaps = Selector.Register("generateMipmaps:");

    public static readonly Selector GetTextureAccessCountersRegionMipLevelSliceResetCountersCountersBufferCountersBufferOffset = Selector.Register("getTextureAccessCounters:region:mipLevel:slice:resetCounters:countersBuffer:countersBufferOffset:");

    public static readonly Selector OptimizeContentsForCPUAccess = Selector.Register("optimizeContentsForCPUAccess:");

    public static readonly Selector OptimizeContentsForCPUAccessSliceLevel = Selector.Register("optimizeContentsForCPUAccess:slice:level:");

    public static readonly Selector OptimizeContentsForGPUAccess = Selector.Register("optimizeContentsForGPUAccess:");

    public static readonly Selector OptimizeContentsForGPUAccessSliceLevel = Selector.Register("optimizeContentsForGPUAccess:slice:level:");

    public static readonly Selector OptimizeIndirectCommandBufferRange = Selector.Register("optimizeIndirectCommandBuffer:range:");

    public static readonly Selector ResetCommandsInBufferRange = Selector.Register("resetCommandsInBuffer:range:");

    public static readonly Selector ResetTextureAccessCountersRegionMipLevelSlice = Selector.Register("resetTextureAccessCounters:region:mipLevel:slice:");

    public static readonly Selector ResolveCountersRangeDestinationBufferDestinationOffset = Selector.Register("resolveCounters:range:destinationBuffer:destinationOffset:");

    public static readonly Selector SampleCountersInBufferSampleIndexBarrier = Selector.Register("sampleCountersInBuffer:sampleIndex:barrier:");

    public static readonly Selector SynchronizeResource = Selector.Register("synchronizeResource:");

    public static readonly Selector SynchronizeTextureSliceLevel = Selector.Register("synchronizeTexture:slice:level:");

    public static readonly Selector UpdateFence = Selector.Register("updateFence:");

    public static readonly Selector WaitForFence = Selector.Register("waitForFence:");
}
