namespace Metal.NET;

public readonly struct MTLResourceStateCommandEncoder(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public void MoveTextureMappingsFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.MoveTextureMappingsFromTexture, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateFence, fence.NativePtr);
    }

    public void UpdateTextureMapping(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLRegion region, nuint mipLevel, nuint slice)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMapping, texture.NativePtr, (nuint)mode, region, mipLevel, slice);
    }

    public void UpdateTextureMapping(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMapping, texture.NativePtr, (nuint)mode, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void UpdateTextureMappings(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLRegion regions, nint mipLevels, nint slices, nuint numRegions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMappings, texture.NativePtr, (nuint)mode, regions, mipLevels, slices, numRegions);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.WaitForFence, fence.NativePtr);
    }
}

file static class MTLResourceStateCommandEncoderBindings
{
    public static readonly Selector MoveTextureMappingsFromTexture = Selector.Register("moveTextureMappingsFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:");

    public static readonly Selector UpdateFence = Selector.Register("updateFence:");

    public static readonly Selector UpdateTextureMapping = Selector.Register("updateTextureMapping:mode:region:mipLevel:slice:");

    public static readonly Selector UpdateTextureMappings = Selector.Register("updateTextureMappings:mode:regions:mipLevels:slices:numRegions:");

    public static readonly Selector WaitForFence = Selector.Register("waitForFence:");
}
