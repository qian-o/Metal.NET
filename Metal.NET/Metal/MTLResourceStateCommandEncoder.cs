namespace Metal.NET;

public class MTLResourceStateCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLResourceStateCommandEncoder>
{
    #region INativeObject
    public static new MTLResourceStateCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLResourceStateCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public void UpdateTextureMappingsModeRegionsMipLevelsSlicesNumRegions(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLRegion regions, nint mipLevels, nint slices, nuint numRegions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMappings, texture.NativePtr, (nuint)mode, regions, mipLevels, slices, numRegions);
    }

    public void UpdateTextureMappingModeRegionMipLevelSlice(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLRegion region, nuint mipLevel, nuint slice)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMapping, texture.NativePtr, (nuint)mode, region, mipLevel, slice);
    }

    public void UpdateTextureMappingModeIndirectBufferIndirectBufferOffset(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMappingmodeindirectBufferindirectBufferOffset, texture.NativePtr, (nuint)mode, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateFence, fence.NativePtr);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.WaitForFence, fence.NativePtr);
    }

    public void MoveTextureMappingsFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToTextureDestinationSliceDestinationLevelDestinationOrigin(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.MoveTextureMappingsFromTexture, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }
}

file static class MTLResourceStateCommandEncoderBindings
{
    public static readonly Selector MoveTextureMappingsFromTexture = "moveTextureMappingsFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector UpdateFence = "updateFence:";

    public static readonly Selector UpdateTextureMapping = "updateTextureMapping:mode:region:mipLevel:slice:";

    public static readonly Selector UpdateTextureMappingmodeindirectBufferindirectBufferOffset = "updateTextureMapping:mode:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector UpdateTextureMappings = "updateTextureMappings:mode:regions:mipLevels:slices:numRegions:";

    public static readonly Selector WaitForFence = "waitForFence:";
}
