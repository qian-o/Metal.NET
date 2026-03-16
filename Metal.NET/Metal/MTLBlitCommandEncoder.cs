namespace Metal.NET;

/// <summary>Encodes commands that copy and modify resources for a single blit pass.</summary>
public class MTLBlitCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTLCommandEncoder(nativePtr, ownership), INativeObject<MTLBlitCommandEncoder>
{
    #region INativeObject
    public static new MTLBlitCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLBlitCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Filling buffers - Methods

    /// <summary>Encodes a command that fills a buffer with a constant value for each byte.</summary>
    public void FillBuffer(MTLBuffer buffer, NSRange range, byte value)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.FillBuffer, buffer.NativePtr, range, value);
    }
    #endregion

    #region Generating texture mipmaps - Methods

    /// <summary>Encodes a command that generates mipmaps for a texture from the base mipmap level up to the highest mipmap level.</summary>
    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.GenerateMipmaps, texture.NativePtr);
    }
    #endregion

    #region Copying buffer data to another buffer - Methods

    /// <summary>Encodes a command that copies data from one buffer into another.</summary>
    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromBuffer, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    /// <summary>Encodes a command that copies data from one buffer into another.</summary>
    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin, MTLBlitOption options)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromBuffersourceOffsetsourceBytesPerRowsourceBytesPerImagesourceSizetoTexturedestinationSlicedestinationLeveldestinationOriginoptions, sourceBuffer.NativePtr, sourceOffset, sourceBytesPerRow, sourceBytesPerImage, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin, (nuint)options);
    }

    /// <summary>Encodes a command that copies data from one buffer into another.</summary>
    public void CopyFromBuffer(MTLBuffer sourceBuffer, nuint sourceOffset, MTLBuffer destinationBuffer, nuint destinationOffset, nuint size)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromBuffersourceOffsettoBufferdestinationOffsetsize, sourceBuffer.NativePtr, sourceOffset, destinationBuffer.NativePtr, destinationOffset, size);
    }
    #endregion

    #region Copying texture data to another texture - Methods

    /// <summary>Encodes a command that copies data from one texture to another.</summary>
    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, nuint sliceCount, nuint levelCount)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTexture, sourceTexture.NativePtr, sourceSlice, sourceLevel, destinationTexture.NativePtr, destinationSlice, destinationLevel, sliceCount, levelCount);
    }

    /// <summary>Encodes a command that copies data from one texture to another.</summary>
    public void CopyFromTexture(MTLTexture sourceTexture, MTLTexture destinationTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTexturetoTexture, sourceTexture.NativePtr, destinationTexture.NativePtr);
    }

    /// <summary>Encodes a command that copies data from one texture to another.</summary>
    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImage, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage);
    }

    /// <summary>Encodes a command that copies data from one texture to another.</summary>
    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoTexturedestinationSlicedestinationLeveldestinationOrigin, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    /// <summary>Encodes a command that copies data from one texture to another.</summary>
    public void CopyFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLBuffer destinationBuffer, nuint destinationOffset, nuint destinationBytesPerRow, nuint destinationBytesPerImage, MTLBlitOption options)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImageoptions, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationBuffer.NativePtr, destinationOffset, destinationBytesPerRow, destinationBytesPerImage, (nuint)options);
    }

    /// <summary>Encodes a command to copy data from a slice of one tensor into a slice of another tensor.</summary>
    public void CopyFromTensor(MTLTensor sourceTensor, MTLTensorExtents sourceOrigin, MTLTensorExtents sourceDimensions, MTLTensor destinationTensor, MTLTensorExtents destinationOrigin, MTLTensorExtents destinationDimensions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyFromTensor, sourceTensor.NativePtr, sourceOrigin.NativePtr, sourceDimensions.NativePtr, destinationTensor.NativePtr, destinationOrigin.NativePtr, destinationDimensions.NativePtr);
    }
    #endregion

    #region Optimizing textures for GPU access - Methods

    /// <summary>Encodes a command that improves the performance of GPU memory operations with a texture.</summary>
    public void OptimizeContentsForGPUAccess(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForGPUAccess, texture.NativePtr);
    }

    /// <summary>Encodes a command that improves the performance of GPU memory operations with a texture.</summary>
    public void OptimizeContentsForGPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForGPUAccessslicelevel, texture.NativePtr, slice, level);
    }
    #endregion

    #region Optimizing textures for CPU access - Methods

    /// <summary>Encodes a command that improves the performance of CPU memory operations with a texture.</summary>
    public void OptimizeContentsForCPUAccess(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForCPUAccess, texture.NativePtr);
    }

    /// <summary>Encodes a command that improves the performance of CPU memory operations with a texture.</summary>
    public void OptimizeContentsForCPUAccess(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeContentsForCPUAccessslicelevel, texture.NativePtr, slice, level);
    }
    #endregion

    #region Synchronizing managed resources - Methods

    /// <summary>Encodes a command that synchronizes the CPU’s copy of a managed resource, such as a buffer or texture, so that it matches the GPU’s copy.</summary>
    public void SynchronizeResource(MTLResource resource)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.SynchronizeResource, resource.NativePtr);
    }

    /// <summary>Encodes a command that synchronizes a part of the CPU’s copy of a texture so that it matches the GPU’s copy.</summary>
    public void SynchronizeTexture(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.SynchronizeTexture, texture.NativePtr, slice, level);
    }
    #endregion

    #region Preventing resource access conflicts - Methods

    /// <summary>Encodes a command that instructs the GPU to pause the blit pass until another pass updates a fence.</summary>
    public void WaitForFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.WaitForFence, fence.NativePtr);
    }

    /// <summary>Encodes a command that instructs the GPU to update a fence after the blit pass completes.</summary>
    public void UpdateFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.UpdateFence, fence.NativePtr);
    }
    #endregion

    #region Managing indirect command buffers - Methods

    /// <summary>Encodes a command that copies commands from one indirect command buffer into another.</summary>
    public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, nuint destinationIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyIndirectCommandBuffer, source.NativePtr, sourceRange, destination.NativePtr, destinationIndex);
    }

    /// <summary>Encodes a command that resets a range of commands in an indirect command buffer.</summary>
    public void ResetCommandsInBuffer(MTLIndirectCommandBuffer buffer, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResetCommandsInBuffer, buffer.NativePtr, range);
    }

    /// <summary>Encodes a command that can improve the performance of a range of commands within an indirect command buffer.</summary>
    public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeIndirectCommandBuffer, indirectCommandBuffer.NativePtr, range);
    }
    #endregion

    #region Sampling counters - Methods

    /// <summary>Encodes a command that samples the GPU’s hardware counters during a blit pass and stores the data in a counter sample buffer.</summary>
    public void SampleCountersInBuffer(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.SampleCountersInBuffer, sampleBuffer.NativePtr, sampleIndex, barrier);
    }

    /// <summary>Encodes a command that resolves the data from the samples in a sample counter buffer and stores the results into a buffer.</summary>
    public void ResolveCounters(MTLCounterSampleBuffer sampleBuffer, NSRange range, MTLBuffer destinationBuffer, nuint destinationOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResolveCounters, sampleBuffer.NativePtr, range, destinationBuffer.NativePtr, destinationOffset);
    }
    #endregion

    #region Managing sparse texture access counters - Methods

    /// <summary>Encodes a command that retrieves a sparse texture’s access data for a specific region, mipmap level, and slice.</summary>
    [Obsolete]
    public void GetTextureAccessCounters(MTLTexture texture, MTLRegion region, nuint mipLevel, nuint slice, bool resetCounters, MTLBuffer countersBuffer, nuint countersBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.GetTextureAccessCounters, texture.NativePtr, region, mipLevel, slice, resetCounters, countersBuffer.NativePtr, countersBufferOffset);
    }

    /// <summary>Encodes a command that resets a sparse texture’s access data for a specific region, mipmap level, and slice.</summary>
    [Obsolete]
    public void ResetTextureAccessCounters(MTLTexture texture, MTLRegion region, nuint mipLevel, nuint slice)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResetTextureAccessCounters, texture.NativePtr, region, mipLevel, slice);
    }
    #endregion
}

file static class MTLBlitCommandEncoderBindings
{
    public static readonly Selector CopyFromBuffer = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector CopyFromBuffersourceOffsetsourceBytesPerRowsourceBytesPerImagesourceSizetoTexturedestinationSlicedestinationLeveldestinationOriginoptions = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:options:";

    public static readonly Selector CopyFromBuffersourceOffsettoBufferdestinationOffsetsize = "copyFromBuffer:sourceOffset:toBuffer:destinationOffset:size:";

    public static readonly Selector CopyFromTensor = "copyFromTensor:sourceOrigin:sourceDimensions:toTensor:destinationOrigin:destinationDimensions:";

    public static readonly Selector CopyFromTexture = "copyFromTexture:sourceSlice:sourceLevel:toTexture:destinationSlice:destinationLevel:sliceCount:levelCount:";

    public static readonly Selector CopyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImage = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:";

    public static readonly Selector CopyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoBufferdestinationOffsetdestinationBytesPerRowdestinationBytesPerImageoptions = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:options:";

    public static readonly Selector CopyFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoTexturedestinationSlicedestinationLeveldestinationOrigin = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

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
