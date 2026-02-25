namespace Metal.NET;

public class MTLBlitCommandEncoder(nint nativePtr, bool ownsReference = true) : MTLCommandEncoder(nativePtr, ownsReference), INativeObject<MTLBlitCommandEncoder>
{
    public static new MTLBlitCommandEncoder Create(nint nativePtr) => new(nativePtr);

    public static new MTLBlitCommandEncoder CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromBuffer, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin, MTLBlitOption options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromBuffersourceOffsetsourceBytesPerRowsourceBytesPerImagesourceSizetoTexturedestinationSlicedestinationLeveldestinationOriginoptions, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin, (nuint)options);
    }

    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, MTLBuffer destinationBuffer, nuint destinationOffset, nuint size)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromBuffersourceOffsettoBufferdestinationOffsetsize, sourceBuffer.NativePtr, sourceOffset, destinationBuffer.NativePtr, destinationOffset, size);
    }

    public void CopyFromTensor(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTensor, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTexture, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImage, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage, MTLBlitOption options)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImageoptions, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage, (nuint)options);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, nuint sliceCount, nuint levelCount)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTexturesourceSlicesourceLeveltoTexturedestinationSlicedestinationLevelsliceCountlevelCount, sourceTexture.NativePtr, sourceSlice, sourceLevel, destinationTexture.NativePtr, destinationSlice, destinationLevel, sliceCount, levelCount);
    }

    public void CopyFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTexturetoTexture, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }

    public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, nuint destinationIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyIndirectCommandBuffer, source.NativePtr, sourceRange, destination.NativePtr, destinationIndex);
    }

    public void FillBuffer(MTLBuffer buffer, NSRange range, byte value)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.FillBuffer, buffer.NativePtr, range, value);
    }

    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.GenerateMipmaps, texture.NativePtr);
    }

    public void GetTextureAccessCounters(MTLTexture texture, MTLRegion region, nuint mipLevel, nuint slice, bool resetCounters, MTLBuffer countersBuffer, nuint countersBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.GetTextureAccessCounters, texture.NativePtr, region, mipLevel, slice, (Bool8)resetCounters, countersBuffer.NativePtr, countersBufferOffset);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForCPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForCPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForCPUAccessslicelevel, texture.NativePtr, slice, level);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForGPUAccess, texture.NativePtr);
    }

    public void OptimizeContentsForGPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForGPUAccessslicelevel, texture.NativePtr, slice, level);
    }

    public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeIndirectCommandBuffer, indirectCommandBuffer.NativePtr, range);
    }

    public void ResetCommandsInBuffer(MTLIndirectCommandBuffer buffer, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResetCommandsInBuffer, buffer.NativePtr, range);
    }

    public void ResetTextureAccessCounters(MTLTexture texture, MTLRegion region, nuint mipLevel, nuint slice)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResetTextureAccessCounters, texture.NativePtr, region, mipLevel, slice);
    }

    public void ResolveCounters(MTLCounterSampleBuffer sampleBuffer, NSRange range, MTLBuffer destinationBuffer, nuint destinationOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResolveCounters, sampleBuffer.NativePtr, range, destinationBuffer.NativePtr, destinationOffset);
    }

    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.SampleCountersInBuffer, sampleBuffer.NativePtr, sampleIndex, (Bool8)barrier);
    }

    public void SynchronizeResource(MTLResource resource)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.SynchronizeResource, resource.NativePtr);
    }

    public void SynchronizeTexture(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.SynchronizeTexture, texture.NativePtr, slice, level);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.UpdateFence, fence.NativePtr);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.WaitForFence, fence.NativePtr);
    }
}

file static class MTLBlitCommandEncoderBindings
{
    public static readonly Selector CopyFromBuffer = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector CopyFromBuffersourceOffsetsourceBytesPerRowsourceBytesPerImagesourceSizetoTexturedestinationSlicedestinationLeveldestinationOriginoptions = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:options:";

    public static readonly Selector CopyFromBuffersourceOffsettoBufferdestinationOffsetsize = "copyFromBuffer:sourceOffset:toBuffer:destinationOffset:size:";

    public static readonly Selector CopyFromTensor = "copyFromTensor:sourceOrigin:sourceDimensions:toTensor:destinationOrigin:destinationDimensions:";

    public static readonly Selector CopyFromTexture = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector CopyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImage = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:";

    public static readonly Selector CopyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImageoptions = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:options:";

    public static readonly Selector CopyFromTexturesourceSlicesourceLeveltoTexturedestinationSlicedestinationLevelsliceCountlevelCount = "copyFromTexture:sourceSlice:sourceLevel:toTexture:destinationSlice:destinationLevel:sliceCount:levelCount:";

    public static readonly Selector CopyFromTexturetoTexture = "copyFromTexture:toTexture:";

    public static readonly Selector CopyIndirectCommandBuffer = "copyIndirectCommandBuffer:sourceRange:destination:destinationIndex:";

    public static readonly Selector FillBuffer = "fillBuffer:range:value:";

    public static readonly Selector GenerateMipmaps = "generateMipmapsForTexture:";

    public static readonly Selector GetTextureAccessCounters = "getTextureAccessCounters:region:mipLevel:slice:resetCounters:countersBuffer:countersBufferOffset:";

    public static readonly Selector OptimizeContentsForCPUAccess = "optimizeContentsForCPUAccess:";

    public static readonly Selector OptimizeContentsForCPUAccessslicelevel = "optimizeContentsForCPUAccess:slice:level:";

    public static readonly Selector OptimizeContentsForGPUAccess = "optimizeContentsForGPUAccess:";

    public static readonly Selector OptimizeContentsForGPUAccessslicelevel = "optimizeContentsForGPUAccess:slice:level:";

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
