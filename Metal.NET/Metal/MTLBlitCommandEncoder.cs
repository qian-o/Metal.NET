namespace Metal.NET;

public class MTLBlitCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTLCommandEncoder(nativePtr, ownership), INativeObject<MTLBlitCommandEncoder>
{
    #region INativeObject
    public static new MTLBlitCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLBlitCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public void Synchronize(MTLResource resource)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.SynchronizeResource, resource.NativePtr);
    }

    public void Synchronize(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.SynchronizeTextureSliceLevel, texture.NativePtr, slice, level);
    }

    public void Copy(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToTextureDestinationSliceDestinationLevelDestinationOrigin, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void Copy(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOrigin, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void Copy(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin, MTLBlitOption options)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOriginOptions, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin, (nuint)options);
    }

    public void Copy(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImage, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage);
    }

    public void Copy(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage, MTLBlitOption options)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage, (nuint)options);
    }

    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.GenerateMipmapsForTexture, texture.NativePtr);
    }

    public void Fill(MTLBuffer buffer, NSRange range, byte value)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.FillBufferRangeValue, buffer.NativePtr, range, value);
    }

    public void Copy(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, nuint sliceCount, nuint levelCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTextureSourceSliceSourceLevelToTextureDestinationSliceDestinationLevelSliceCountLevelCount, sourceTexture.NativePtr, sourceSlice, sourceLevel, destinationTexture.NativePtr, destinationSlice, destinationLevel, sliceCount, levelCount);
    }

    public void Copy(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTextureToTexture, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }

    public void Copy(MTLBuffer sourceBuffer, nuint sourceOffset, MTLBuffer destinationBuffer, nuint destinationOffset, nuint size)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromBufferSourceOffsetToBufferDestinationOffsetSize, sourceBuffer.NativePtr, sourceOffset, destinationBuffer.NativePtr, destinationOffset, size);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.UpdateFence, fence.NativePtr);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.WaitForFence, fence.NativePtr);
    }

    public void GetTextureAccessCounters(MTLTexture texture, MTLRegion region, nuint mipLevel, nuint slice, bool resetCounters, MTLBuffer countersBuffer, nuint countersBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.GetTextureAccessCountersRegionMipLevelSliceResetCountersCountersBufferCountersBufferOffset, texture.NativePtr, region, mipLevel, slice, resetCounters, countersBuffer.NativePtr, countersBufferOffset);
    }

    public void ResetTextureAccessCounters(MTLTexture texture, MTLRegion region, nuint mipLevel, nuint slice)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResetTextureAccessCountersRegionMipLevelSlice, texture.NativePtr, region, mipLevel, slice);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForGPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForGPUAccessSliceLevel, texture.NativePtr, slice, level);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForCPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForCPUAccessSliceLevel, texture.NativePtr, slice, level);
    }

    public void ResetCommandsInBuffer(MTLIndirectCommandBuffer buffer, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResetCommandsInBufferWithRange, buffer.NativePtr, range);
    }

    public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, nuint destinationIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyIndirectCommandBufferSourceRangeDestinationDestinationIndex, source.NativePtr, sourceRange, destination.NativePtr, destinationIndex);
    }

    public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeIndirectCommandBufferWithRange, indirectCommandBuffer.NativePtr, range);
    }

    public void SampleCounters(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.SampleCountersInBufferAtSampleIndexWithBarrier, sampleBuffer.NativePtr, sampleIndex, barrier);
    }

    public void ResolveCounters(MTLCounterSampleBuffer sampleBuffer, NSRange range, MTLBuffer destinationBuffer, nuint destinationOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResolveCountersInRangeDestinationBufferDestinationOffset, sampleBuffer.NativePtr, range, destinationBuffer.NativePtr, destinationOffset);
    }

    public void Copy(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTensorSourceOriginSourceDimensionsToTensorDestinationOriginDestinationDimensions, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }
}

file static class MTLBlitCommandEncoderBindings
{
    public static readonly Selector CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOrigin = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOriginOptions = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:options:";

    public static readonly Selector CopyFromBufferSourceOffsetToBufferDestinationOffsetSize = "copyFromBuffer:sourceOffset:toBuffer:destinationOffset:size:";

    public static readonly Selector CopyFromTensorSourceOriginSourceDimensionsToTensorDestinationOriginDestinationDimensions = "copyFromTensor:sourceOrigin:sourceDimensions:toTensor:destinationOrigin:destinationDimensions:";

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImage = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:";

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:options:";

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToTextureDestinationSliceDestinationLevelDestinationOrigin = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelToTextureDestinationSliceDestinationLevelSliceCountLevelCount = "copyFromTexture:sourceSlice:sourceLevel:toTexture:destinationSlice:destinationLevel:sliceCount:levelCount:";

    public static readonly Selector CopyFromTextureToTexture = "copyFromTexture:toTexture:";

    public static readonly Selector CopyIndirectCommandBufferSourceRangeDestinationDestinationIndex = "copyIndirectCommandBuffer:sourceRange:destination:destinationIndex:";

    public static readonly Selector FillBufferRangeValue = "fillBuffer:range:value:";

    public static readonly Selector GenerateMipmapsForTexture = "generateMipmapsForTexture:";

    public static readonly Selector GetTextureAccessCountersRegionMipLevelSliceResetCountersCountersBufferCountersBufferOffset = "getTextureAccessCounters:region:mipLevel:slice:resetCounters:countersBuffer:countersBufferOffset:";

    public static readonly Selector OptimizeContentsForCPUAccess = "optimizeContentsForCPUAccess:";

    public static readonly Selector OptimizeContentsForCPUAccessSliceLevel = "optimizeContentsForCPUAccess:slice:level:";

    public static readonly Selector OptimizeContentsForGPUAccess = "optimizeContentsForGPUAccess:";

    public static readonly Selector OptimizeContentsForGPUAccessSliceLevel = "optimizeContentsForGPUAccess:slice:level:";

    public static readonly Selector OptimizeIndirectCommandBufferWithRange = "optimizeIndirectCommandBuffer:withRange:";

    public static readonly Selector ResetCommandsInBufferWithRange = "resetCommandsInBuffer:withRange:";

    public static readonly Selector ResetTextureAccessCountersRegionMipLevelSlice = "resetTextureAccessCounters:region:mipLevel:slice:";

    public static readonly Selector ResolveCountersInRangeDestinationBufferDestinationOffset = "resolveCounters:inRange:destinationBuffer:destinationOffset:";

    public static readonly Selector SampleCountersInBufferAtSampleIndexWithBarrier = "sampleCountersInBuffer:atSampleIndex:withBarrier:";

    public static readonly Selector SynchronizeResource = "synchronizeResource:";

    public static readonly Selector SynchronizeTextureSliceLevel = "synchronizeTexture:slice:level:";

    public static readonly Selector UpdateFence = "updateFence:";

    public static readonly Selector WaitForFence = "waitForFence:";
}
