namespace Metal.NET;

public class MTLBlitCommandEncoder : IDisposable
{
    public MTLBlitCommandEncoder(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLBlitCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin, MTLBlitOption options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOriginOptions, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin, (uint)options);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, MTLBuffer destinationBuffer, nuint destinationOffset, nuint size)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromBufferSourceOffsetDestinationBufferDestinationOffsetSize, sourceBuffer.NativePtr, sourceOffset, destinationBuffer.NativePtr, destinationOffset, size);
    }

    public void CopyFromTensor(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTensorSourceOriginSourceDimensionsDestinationTensorDestinationOriginDestinationDimensions, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImage, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage, MTLBlitOption options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage, (uint)options);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, nuint sliceCount, nuint levelCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTextureSourceSliceSourceLevelDestinationTextureDestinationSliceDestinationLevelSliceCountLevelCount, sourceTexture.NativePtr, sourceSlice, sourceLevel, destinationTexture.NativePtr, destinationSlice, destinationLevel, sliceCount, levelCount);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyFromTextureDestinationTexture, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }

    public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, nuint destinationIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.CopyIndirectCommandBufferSourceRangeDestinationDestinationIndex, source.NativePtr, sourceRange, destination.NativePtr, destinationIndex);
    }

    public void FillBuffer(MTLBuffer buffer, NSRange range, byte value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.FillBufferRangeValue, buffer.NativePtr, range, value);
    }

    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.GenerateMipmaps, texture.NativePtr);
    }

    public void GetTextureAccessCounters(MTLTexture texture, MTLRegion region, nuint mipLevel, nuint slice, Bool8 resetCounters, MTLBuffer countersBuffer, nuint countersBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.GetTextureAccessCountersRegionMipLevelSliceResetCountersCountersBufferCountersBufferOffset, texture.NativePtr, region, mipLevel, slice, resetCounters, countersBuffer.NativePtr, countersBufferOffset);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeContentsForCPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeContentsForCPUAccessSliceLevel, texture.NativePtr, slice, level);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeContentsForGPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeContentsForGPUAccessSliceLevel, texture.NativePtr, slice, level);
    }

    public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.OptimizeIndirectCommandBufferRange, indirectCommandBuffer.NativePtr, range);
    }

    public void ResetCommandsInBuffer(MTLIndirectCommandBuffer buffer, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.ResetCommandsInBufferRange, buffer.NativePtr, range);
    }

    public void ResetTextureAccessCounters(MTLTexture texture, MTLRegion region, nuint mipLevel, nuint slice)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.ResetTextureAccessCountersRegionMipLevelSlice, texture.NativePtr, region, mipLevel, slice);
    }

    public void ResolveCounters(MTLCounterSampleBuffer sampleBuffer, NSRange range, MTLBuffer destinationBuffer, nuint destinationOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.ResolveCountersRangeDestinationBufferDestinationOffset, sampleBuffer.NativePtr, range, destinationBuffer.NativePtr, destinationOffset);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, Bool8 barrier)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.SampleCountersInBufferSampleIndexBarrier, sampleBuffer.NativePtr, sampleIndex, barrier);
    }

    public void SynchronizeResource(MTLResource resource)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.SynchronizeResource, resource.NativePtr);
    }

    public void SynchronizeTexture(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderSelector.SynchronizeTextureSliceLevel, texture.NativePtr, slice, level);
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
