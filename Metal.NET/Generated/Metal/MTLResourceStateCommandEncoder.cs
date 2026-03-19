namespace Metal.NET;

public partial class MTLResourceStateCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTLCommandEncoder(nativePtr, ownership), INativeObject<MTLResourceStateCommandEncoder>
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
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMappingsModeRegionsMipLevelsSlicesNumRegions, texture.NativePtr, (nuint)mode, regions, mipLevels, slices, numRegions);
    }

    public void UpdateTextureMapping(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLRegion region, nuint mipLevel, nuint slice)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMappingModeRegionMipLevelSlice, texture.NativePtr, (nuint)mode, region, mipLevel, slice);
    }

    public void UpdateTextureMapping(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMappingModeIndirectBufferIndirectBufferOffset, texture.NativePtr, (nuint)mode, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void Update(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateFence, fence.NativePtr);
    }

    public void Wait(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.WaitForFence, fence.NativePtr);
    }

    public void MoveTextureMappings(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.MoveTextureMappingsFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToTextureDestinationSliceDestinationLevelDestinationOrigin, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }
}

file static class MTLResourceStateCommandEncoderBindings
{
    public static readonly Selector MoveTextureMappingsFromTextureSourceSliceSourceLevelSourceOriginSourceSizeToTextureDestinationSliceDestinationLevelDestinationOrigin = "moveTextureMappingsFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";

    public static readonly Selector UpdateFence = "updateFence:";

    public static readonly Selector UpdateTextureMappingModeIndirectBufferIndirectBufferOffset = "updateTextureMapping:mode:indirectBuffer:indirectBufferOffset:";

    public static readonly Selector UpdateTextureMappingModeRegionMipLevelSlice = "updateTextureMapping:mode:region:mipLevel:slice:";

    public static readonly Selector UpdateTextureMappingsModeRegionsMipLevelsSlicesNumRegions = "updateTextureMappings:mode:regions:mipLevels:slices:numRegions:";

    public static readonly Selector WaitForFence = "waitForFence:";
}
