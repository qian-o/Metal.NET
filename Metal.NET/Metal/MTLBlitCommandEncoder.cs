namespace Metal.NET;

public partial class MTLBlitCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTLCommandEncoder(nativePtr, ownership), INativeObject<MTLBlitCommandEncoder>
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
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.SynchronizeTexture_Slice_Level, texture.NativePtr, slice, level);
    }

    public void Copy(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTexture_SourceSlice_SourceLevel_SourceOrigin_SourceSize_ToTexture_DestinationSlice_DestinationLevel_DestinationOrigin, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void Copy(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromBuffer_SourceOffset_SourceBytesPerRow_SourceBytesPerImage_SourceSize_ToTexture_DestinationSlice_DestinationLevel_DestinationOrigin, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void Copy(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin, MTLBlitOption options)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromBuffer_SourceOffset_SourceBytesPerRow_SourceBytesPerImage_SourceSize_ToTexture_DestinationSlice_DestinationLevel_DestinationOrigin_Options, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin, (nuint)options);
    }

    public void Copy(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTexture_SourceSlice_SourceLevel_SourceOrigin_SourceSize_ToBuffer_DestinationOffset_DestinationBytesPerRow_DestinationBytesPerImage, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage);
    }

    public void Copy(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage, MTLBlitOption options)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTexture_SourceSlice_SourceLevel_SourceOrigin_SourceSize_ToBuffer_DestinationOffset_DestinationBytesPerRow_DestinationBytesPerImage_Options, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage, (nuint)options);
    }

    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.GenerateMipmapsForTexture, texture.NativePtr);
    }

    public void Fill(MTLBuffer buffer, NSRange range, byte value)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.FillBuffer_Range_Value, buffer.NativePtr, range, value);
    }

    public void Copy(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, nuint sliceCount, nuint levelCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTexture_SourceSlice_SourceLevel_ToTexture_DestinationSlice_DestinationLevel_SliceCount_LevelCount, sourceTexture.NativePtr, sourceSlice, sourceLevel, destinationTexture.NativePtr, destinationSlice, destinationLevel, sliceCount, levelCount);
    }

    public void Copy(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTexture_ToTexture, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }

    public void Copy(MTLBuffer sourceBuffer, nuint sourceOffset, MTLBuffer destinationBuffer, nuint destinationOffset, nuint size)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromBuffer_SourceOffset_ToBuffer_DestinationOffset_Size, sourceBuffer.NativePtr, sourceOffset, destinationBuffer.NativePtr, destinationOffset, size);
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
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.GetTextureAccessCounters_Region_MipLevel_Slice_ResetCounters_CountersBuffer_CountersBufferOffset, texture.NativePtr, region, mipLevel, slice, resetCounters, countersBuffer.NativePtr, countersBufferOffset);
    }

    public void ResetTextureAccessCounters(MTLTexture texture, MTLRegion region, nuint mipLevel, nuint slice)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResetTextureAccessCounters_Region_MipLevel_Slice, texture.NativePtr, region, mipLevel, slice);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForGPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForGPUAccess_Slice_Level, texture.NativePtr, slice, level);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForCPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForCPUAccess_Slice_Level, texture.NativePtr, slice, level);
    }

    public void ResetCommandsInBuffer(MTLIndirectCommandBuffer buffer, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResetCommandsInBuffer_WithRange, buffer.NativePtr, range);
    }

    public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, nuint destinationIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyIndirectCommandBuffer_SourceRange_Destination_DestinationIndex, source.NativePtr, sourceRange, destination.NativePtr, destinationIndex);
    }

    public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeIndirectCommandBuffer_WithRange, indirectCommandBuffer.NativePtr, range);
    }

    public void SampleCounters(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.SampleCountersInBuffer_AtSampleIndex_WithBarrier, sampleBuffer.NativePtr, sampleIndex, barrier);
    }

    public void ResolveCounters(MTLCounterSampleBuffer sampleBuffer, NSRange range, MTLBuffer destinationBuffer, nuint destinationOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResolveCounters_InRange_DestinationBuffer_DestinationOffset, sampleBuffer.NativePtr, range, destinationBuffer.NativePtr, destinationOffset);
    }

    public void Copy(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTensor_SourceOrigin_SourceDimensions_ToTensor_DestinationOrigin_DestinationDimensions, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }
}

file static class MTLBlitCommandEncoderBindings
{
    public static readonly Selector CopyFromBuffer_SourceOffset_SourceBytesPerRow_SourceBytesPerImage_SourceSize_ToTexture_DestinationSlice_DestinationLevel_DestinationOrigin = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector CopyFromBuffer_SourceOffset_SourceBytesPerRow_SourceBytesPerImage_SourceSize_ToTexture_DestinationSlice_DestinationLevel_DestinationOrigin_Options = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:options:";

    public static readonly Selector CopyFromBuffer_SourceOffset_ToBuffer_DestinationOffset_Size = "copyFromBuffer:sourceOffset:toBuffer:destinationOffset:size:";

    public static readonly Selector CopyFromTensor_SourceOrigin_SourceDimensions_ToTensor_DestinationOrigin_DestinationDimensions = "copyFromTensor:sourceOrigin:sourceDimensions:toTensor:destinationOrigin:destinationDimensions:";

    public static readonly Selector CopyFromTexture_SourceSlice_SourceLevel_SourceOrigin_SourceSize_ToBuffer_DestinationOffset_DestinationBytesPerRow_DestinationBytesPerImage = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:";

    public static readonly Selector CopyFromTexture_SourceSlice_SourceLevel_SourceOrigin_SourceSize_ToBuffer_DestinationOffset_DestinationBytesPerRow_DestinationBytesPerImage_Options = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:options:";

    public static readonly Selector CopyFromTexture_SourceSlice_SourceLevel_SourceOrigin_SourceSize_ToTexture_DestinationSlice_DestinationLevel_DestinationOrigin = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector CopyFromTexture_SourceSlice_SourceLevel_ToTexture_DestinationSlice_DestinationLevel_SliceCount_LevelCount = "copyFromTexture:sourceSlice:sourceLevel:toTexture:destinationSlice:destinationLevel:sliceCount:levelCount:";

    public static readonly Selector CopyFromTexture_ToTexture = "copyFromTexture:toTexture:";

    public static readonly Selector CopyIndirectCommandBuffer_SourceRange_Destination_DestinationIndex = "copyIndirectCommandBuffer:sourceRange:destination:destinationIndex:";

    public static readonly Selector FillBuffer_Range_Value = "fillBuffer:range:value:";

    public static readonly Selector GenerateMipmapsForTexture = "generateMipmapsForTexture:";

    public static readonly Selector GetTextureAccessCounters_Region_MipLevel_Slice_ResetCounters_CountersBuffer_CountersBufferOffset = "getTextureAccessCounters:region:mipLevel:slice:resetCounters:countersBuffer:countersBufferOffset:";

    public static readonly Selector OptimizeContentsForCPUAccess = "optimizeContentsForCPUAccess:";

    public static readonly Selector OptimizeContentsForCPUAccess_Slice_Level = "optimizeContentsForCPUAccess:slice:level:";

    public static readonly Selector OptimizeContentsForGPUAccess = "optimizeContentsForGPUAccess:";

    public static readonly Selector OptimizeContentsForGPUAccess_Slice_Level = "optimizeContentsForGPUAccess:slice:level:";

    public static readonly Selector OptimizeIndirectCommandBuffer_WithRange = "optimizeIndirectCommandBuffer:withRange:";

    public static readonly Selector ResetCommandsInBuffer_WithRange = "resetCommandsInBuffer:withRange:";

    public static readonly Selector ResetTextureAccessCounters_Region_MipLevel_Slice = "resetTextureAccessCounters:region:mipLevel:slice:";

    public static readonly Selector ResolveCounters_InRange_DestinationBuffer_DestinationOffset = "resolveCounters:inRange:destinationBuffer:destinationOffset:";

    public static readonly Selector SampleCountersInBuffer_AtSampleIndex_WithBarrier = "sampleCountersInBuffer:atSampleIndex:withBarrier:";

    public static readonly Selector SynchronizeResource = "synchronizeResource:";

    public static readonly Selector SynchronizeTexture_Slice_Level = "synchronizeTexture:slice:level:";

    public static readonly Selector UpdateFence = "updateFence:";

    public static readonly Selector WaitForFence = "waitForFence:";
}
