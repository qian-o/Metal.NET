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

    public void SynchronizeResource(MTLResource resource)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.SynchronizeResource, resource.NativePtr);
    }

    public void SynchronizeTextureSliceLevel(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.SynchronizeTexture, texture.NativePtr, slice, level);
    }

    public void SynchronizeTexture(MTLTexture texture, nuint slice, nuint level)
    {
        SynchronizeTextureSliceLevel(texture, slice, level);
    }

    public void CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToTextureDestinationSliceDestinationLevelDestinationOrigin(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTexture, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToTextureDestinationSliceDestinationLevelDestinationOrigin(sourceTexture, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOrigin(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromBuffer, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOrigin(sourceBuffer, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOriginOptions(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin, MTLBlitOption options)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOriginOptions, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin, (nuint)options);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin, MTLBlitOption options)
    {
        CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOriginOptions(sourceBuffer, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture, destinationSlice, destinationLevel, destinationOrigin, options);
    }

    public void CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImage(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImage, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage)
    {
        CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImage(sourceTexture, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer, destinationOffset, destinationBytesPerRow, destinationBytesPerImage);
    }

    public void CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage, MTLBlitOption options)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage, (nuint)options);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage, MTLBlitOption options)
    {
        CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions(sourceTexture, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer, destinationOffset, destinationBytesPerRow, destinationBytesPerImage, options);
    }

    public void GenerateMipmapsForTexture(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.GenerateMipmapsForTexture, texture.NativePtr);
    }

    public void FillBufferRangeValue(MTLBuffer buffer, NSRange range, byte value)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.FillBuffer, buffer.NativePtr, range, value);
    }

    public void FillBuffer(MTLBuffer buffer, NSRange range, byte value)
    {
        FillBufferRangeValue(buffer, range, value);
    }

    public void CopyFromTextureSourceSliceSourceLevelToTextureDestinationSliceDestinationLevelSliceCountLevelCount(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, nuint sliceCount, nuint levelCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTextureSourceSliceSourceLevelToTextureDestinationSliceDestinationLevelSliceCountLevelCount, sourceTexture.NativePtr, sourceSlice, sourceLevel, destinationTexture.NativePtr, destinationSlice, destinationLevel, sliceCount, levelCount);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, nuint sliceCount, nuint levelCount)
    {
        CopyFromTextureSourceSliceSourceLevelToTextureDestinationSliceDestinationLevelSliceCountLevelCount(sourceTexture, sourceSlice, sourceLevel, destinationTexture, destinationSlice, destinationLevel, sliceCount, levelCount);
    }

    public void CopyFromTextureToTexture(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTextureToTexture, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        CopyFromTextureToTexture(sourceTexture, destinationTexture);
    }

    public void CopyFromBufferSourceOffsetToBufferDestinationOffsetSize(MTLBuffer sourceBuffer, nuint sourceOffset, MTLBuffer destinationBuffer, nuint destinationOffset, nuint size)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromBufferSourceOffsetToBufferDestinationOffsetSize, sourceBuffer.NativePtr, sourceOffset, destinationBuffer.NativePtr, destinationOffset, size);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, MTLBuffer destinationBuffer, nuint destinationOffset, nuint size)
    {
        CopyFromBufferSourceOffsetToBufferDestinationOffsetSize(sourceBuffer, sourceOffset, destinationBuffer, destinationOffset, size);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.UpdateFence, fence.NativePtr);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.WaitForFence, fence.NativePtr);
    }

    public void GetTextureAccessCountersRegionMipLevelSliceResetCountersCountersBufferCountersBufferOffset(MTLTexture texture, MTLRegion region, nuint mipLevel, nuint slice, bool resetCounters, MTLBuffer countersBuffer, nuint countersBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.GetTextureAccessCounters, texture.NativePtr, region, mipLevel, slice, resetCounters, countersBuffer.NativePtr, countersBufferOffset);
    }

    public void GetTextureAccessCounters(MTLTexture texture, MTLRegion region, nuint mipLevel, nuint slice, bool resetCounters, MTLBuffer countersBuffer, nuint countersBufferOffset)
    {
        GetTextureAccessCountersRegionMipLevelSliceResetCountersCountersBufferCountersBufferOffset(texture, region, mipLevel, slice, resetCounters, countersBuffer, countersBufferOffset);
    }

    public void ResetTextureAccessCountersRegionMipLevelSlice(MTLTexture texture, MTLRegion region, nuint mipLevel, nuint slice)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResetTextureAccessCounters, texture.NativePtr, region, mipLevel, slice);
    }

    public void ResetTextureAccessCounters(MTLTexture texture, MTLRegion region, nuint mipLevel, nuint slice)
    {
        ResetTextureAccessCountersRegionMipLevelSlice(texture, region, mipLevel, slice);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForGPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccessSliceLevel(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForGPUAccessSliceLevel, texture.NativePtr, slice, level);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        OptimizeContentsForGPUAccessSliceLevel(texture, slice, level);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForCPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccessSliceLevel(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForCPUAccessSliceLevel, texture.NativePtr, slice, level);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        OptimizeContentsForCPUAccessSliceLevel(texture, slice, level);
    }

    public void ResetCommandsInBufferWithRange(MTLIndirectCommandBuffer buffer, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResetCommandsInBuffer, buffer.NativePtr, range);
    }

    public void ResetCommandsInBuffer(MTLIndirectCommandBuffer buffer, NSRange range)
    {
        ResetCommandsInBufferWithRange(buffer, range);
    }

    public void CopyIndirectCommandBufferSourceRangeDestinationDestinationIndex(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, nuint destinationIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyIndirectCommandBuffer, source.NativePtr, sourceRange, destination.NativePtr, destinationIndex);
    }

    public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, nuint destinationIndex)
    {
        CopyIndirectCommandBufferSourceRangeDestinationDestinationIndex(source, sourceRange, destination, destinationIndex);
    }

    public void OptimizeIndirectCommandBufferWithRange(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeIndirectCommandBuffer, indirectCommandBuffer.NativePtr, range);
    }

    public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
    {
        OptimizeIndirectCommandBufferWithRange(indirectCommandBuffer, range);
    }

    public void SampleCountersInBufferAtSampleIndexWithBarrier(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.SampleCountersInBuffer, sampleBuffer.NativePtr, sampleIndex, barrier);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        SampleCountersInBufferAtSampleIndexWithBarrier(sampleBuffer, sampleIndex, barrier);
    }

    public void ResolveCountersInRangeDestinationBufferDestinationOffset(MTLCounterSampleBuffer sampleBuffer, NSRange range, MTLBuffer destinationBuffer, nuint destinationOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResolveCounters, sampleBuffer.NativePtr, range, destinationBuffer.NativePtr, destinationOffset);
    }

    public void ResolveCounters(MTLCounterSampleBuffer sampleBuffer, NSRange range, MTLBuffer destinationBuffer, nuint destinationOffset)
    {
        ResolveCountersInRangeDestinationBufferDestinationOffset(sampleBuffer, range, destinationBuffer, destinationOffset);
    }

    public void CopyFromTensorSourceOriginSourceDimensionsToTensorDestinationOriginDestinationDimensions(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTensor, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }

    public void CopyFromTensor(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        CopyFromTensorSourceOriginSourceDimensionsToTensorDestinationOriginDestinationDimensions(sourceTensor, sourceOrigin, sourceDimensions, destinationTensor, destinationOrigin, destinationDimensions);
    }
}

file static class MTLBlitCommandEncoderBindings
{
    public static readonly Selector CopyFromBuffer = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector CopyFromBufferSourceOffsetSourceBytesPerRowSourceBytesPerImageSourceSizeToTextureDestinationSliceDestinationLevelDestinationOriginOptions = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:options:";

    public static readonly Selector CopyFromBufferSourceOffsetToBufferDestinationOffsetSize = "copyFromBuffer:sourceOffset:toBuffer:destinationOffset:size:";

    public static readonly Selector CopyFromTensor = "copyFromTensor:sourceOrigin:sourceDimensions:toTensor:destinationOrigin:destinationDimensions:";

    public static readonly Selector CopyFromTexture = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImage = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:";

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToBufferDestinationOffsetDestinationBytesPerRowDestinationBytesPerImageOptions = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:options:";

    public static readonly Selector CopyFromTextureSourceSliceSourceLevelToTextureDestinationSliceDestinationLevelSliceCountLevelCount = "copyFromTexture:sourceSlice:sourceLevel:toTexture:destinationSlice:destinationLevel:sliceCount:levelCount:";

    public static readonly Selector CopyFromTextureToTexture = "copyFromTexture:toTexture:";

    public static readonly Selector CopyIndirectCommandBuffer = "copyIndirectCommandBuffer:sourceRange:destination:destinationIndex:";

    public static readonly Selector FillBuffer = "fillBuffer:range:value:";

    public static readonly Selector GenerateMipmapsForTexture = "generateMipmapsForTexture:";

    public static readonly Selector GetTextureAccessCounters = "getTextureAccessCounters:region:mipLevel:slice:resetCounters:countersBuffer:countersBufferOffset:";

    public static readonly Selector OptimizeContentsForCPUAccess = "optimizeContentsForCPUAccess:";

    public static readonly Selector OptimizeContentsForCPUAccessSliceLevel = "optimizeContentsForCPUAccess:slice:level:";

    public static readonly Selector OptimizeContentsForGPUAccess = "optimizeContentsForGPUAccess:";

    public static readonly Selector OptimizeContentsForGPUAccessSliceLevel = "optimizeContentsForGPUAccess:slice:level:";

    public static readonly Selector OptimizeIndirectCommandBuffer = "optimizeIndirectCommandBuffer:withRange:";

    public static readonly Selector ResetCommandsInBuffer = "resetCommandsInBuffer:withRange:";

    public static readonly Selector ResetTextureAccessCounters = "resetTextureAccessCounters:region:mipLevel:slice:";

    public static readonly Selector ResolveCounters = "resolveCounters:inRange:destinationBuffer:destinationOffset:";

    public static readonly Selector SampleCountersInBuffer = "sampleCountersInBuffer:atSampleIndex:withBarrier:";

    public static readonly Selector SynchronizeResource = "synchronizeResource:";

    public static readonly Selector SynchronizeTexture = "synchronizeTexture:slice:level:";

    public static readonly Selector UpdateFence = "updateFence:";

    public static readonly Selector WaitForFence = "waitForFence:";
}
