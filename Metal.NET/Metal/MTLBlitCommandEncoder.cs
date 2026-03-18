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
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.Synchronize, resource.NativePtr);
    }

    public void Synchronize(MTLTexture texture, nuint slice, nuint level)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.SynchronizeTextureSliceLevel, texture.NativePtr, slice, level);
    }

    public void GenerateMipmaps(MTLTexture texture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.GenerateMipmaps, texture.NativePtr);
    }

    public void Fill(MTLBuffer buffer, NSRange range, byte value)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.Fill, buffer.NativePtr, range, value);
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
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.GetTextureAccessCounters, texture.NativePtr, region, mipLevel, slice, resetCounters, countersBuffer.NativePtr, countersBufferOffset);
    }

    public void ResetTextureAccessCounters(MTLTexture texture, MTLRegion region, nuint mipLevel, nuint slice)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResetTextureAccessCounters, texture.NativePtr, region, mipLevel, slice);
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
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResetCommandsInBuffer, buffer.NativePtr, range);
    }

    public void CopyIndirectCommandBuffer(MTLIndirectCommandBuffer source, NSRange sourceRange, MTLIndirectCommandBuffer destination, nuint destinationIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.CopyIndirectCommandBuffer, source.NativePtr, sourceRange, destination.NativePtr, destinationIndex);
    }

    public void OptimizeIndirectCommandBuffer(MTLIndirectCommandBuffer indirectCommandBuffer, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.OptimizeIndirectCommandBuffer, indirectCommandBuffer.NativePtr, range);
    }

    public void SampleCounters(MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.SampleCounters, sampleBuffer.NativePtr, sampleIndex, barrier);
    }

    public void ResolveCounters(MTLCounterSampleBuffer sampleBuffer, NSRange range, MTLBuffer destinationBuffer, nuint destinationOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBlitCommandEncoderBindings.ResolveCounters, sampleBuffer.NativePtr, range, destinationBuffer.NativePtr, destinationOffset);
    }
}

file static class MTLBlitCommandEncoderBindings
{
    public static readonly Selector CopyIndirectCommandBuffer = "copyIndirectCommandBuffer:sourceRange:destination:destinationIndex:";

    public static readonly Selector Fill = "fillBuffer:range:value:";

    public static readonly Selector GenerateMipmaps = "generateMipmapsForTexture:";

    public static readonly Selector GetTextureAccessCounters = "getTextureAccessCounters:region:mipLevel:slice:resetCounters:countersBuffer:countersBufferOffset:";

    public static readonly Selector OptimizeContentsForCPUAccess = "optimizeContentsForCPUAccess:";

    public static readonly Selector OptimizeContentsForCPUAccessSliceLevel = "optimizeContentsForCPUAccess:slice:level:";

    public static readonly Selector OptimizeContentsForGPUAccess = "optimizeContentsForGPUAccess:";

    public static readonly Selector OptimizeContentsForGPUAccessSliceLevel = "optimizeContentsForGPUAccess:slice:level:";

    public static readonly Selector OptimizeIndirectCommandBuffer = "optimizeIndirectCommandBuffer:withRange:";

    public static readonly Selector ResetCommandsInBuffer = "resetCommandsInBuffer:withRange:";

    public static readonly Selector ResetTextureAccessCounters = "resetTextureAccessCounters:region:mipLevel:slice:";

    public static readonly Selector ResolveCounters = "resolveCounters:inRange:destinationBuffer:destinationOffset:";

    public static readonly Selector SampleCounters = "sampleCountersInBuffer:atSampleIndex:withBarrier:";

    public static readonly Selector Synchronize = "synchronizeResource:";

    public static readonly Selector SynchronizeTextureSliceLevel = "synchronizeTexture:slice:level:";

    public static readonly Selector UpdateFence = "updateFence:";

    public static readonly Selector WaitForFence = "waitForFence:";
}
