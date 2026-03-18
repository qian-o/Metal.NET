namespace Metal.NET;

public class MTLResourceStateCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTLCommandEncoder(nativePtr, ownership), INativeObject<MTLResourceStateCommandEncoder>
{
    #region INativeObject
    public static new MTLResourceStateCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLResourceStateCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public void UpdateTextureMappings(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLRegion regions, nint mipLevels, nint slices, nuint numRegions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMappings, texture.NativePtr, (nuint)mode, regions, mipLevels, slices, numRegions);
    }

    public void UpdateTextureMapping(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLRegion region, nuint mipLevel, nuint slice)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMapping, texture.NativePtr, (nuint)mode, region, mipLevel, slice);
    }

    public void UpdateTextureMapping(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMappingModeIndirectBufferIndirectBufferOffset, texture.NativePtr, (nuint)mode, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void Update(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.Update, fence.NativePtr);
    }

    public void Wait(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.Wait, fence.NativePtr);
    }

    public void MoveTextureMappings(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.MoveTextureMappings, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }
}

file static class MTLResourceStateCommandEncoderBindings
{
    public static readonly Selector MoveTextureMappings = "moveTextureMappingsFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector Update = "updateFence:";

    public static readonly Selector UpdateTextureMapping = "updateTextureMapping:mode:region:mipLevel:slice:";

    public static readonly Selector UpdateTextureMappingModeIndirectBufferIndirectBufferOffset = "updateTextureMapping:mode:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector UpdateTextureMappings = "updateTextureMappings:mode:regions:mipLevels:slices:numRegions:";

    public static readonly Selector Wait = "waitForFence:";
}
