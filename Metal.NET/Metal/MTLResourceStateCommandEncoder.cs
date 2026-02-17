namespace Metal.NET;

public class MTLResourceStateCommandEncoder : IDisposable
{
    public MTLResourceStateCommandEncoder(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLResourceStateCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public void MoveTextureMappingsFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStateCommandEncoderSelector.MoveTextureMappingsFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStateCommandEncoderSelector.UpdateFence, fence.NativePtr);
    }

    public void UpdateTextureMapping(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLRegion region, nuint mipLevel, nuint slice)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStateCommandEncoderSelector.UpdateTextureMappingModeRegionMipLevelSlice, texture.NativePtr, (uint)mode, region, mipLevel, slice);
    }

    public void UpdateTextureMapping(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStateCommandEncoderSelector.UpdateTextureMappingModeIndirectBufferIndirectBufferOffset, texture.NativePtr, (uint)mode, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    public void UpdateTextureMappings(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLRegion regions, nint mipLevels, nint slices, nuint numRegions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStateCommandEncoderSelector.UpdateTextureMappingsModeRegionsMipLevelsSlicesNumRegions, texture.NativePtr, (uint)mode, regions, mipLevels, slices, numRegions);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceStateCommandEncoderSelector.WaitForFence, fence.NativePtr);
    }

    public static implicit operator nint(MTLResourceStateCommandEncoder value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLResourceStateCommandEncoder(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

}

file class MTLResourceStateCommandEncoderSelector
{
    public static readonly Selector MoveTextureMappingsFromTextureSourceSliceSourceLevelSourceOriginSourceSizeDestinationTextureDestinationSliceDestinationLevelDestinationOrigin = Selector.Register("moveTextureMappingsFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:");

    public static readonly Selector UpdateFence = Selector.Register("updateFence:");

    public static readonly Selector UpdateTextureMappingModeRegionMipLevelSlice = Selector.Register("updateTextureMapping:mode:region:mipLevel:slice:");

    public static readonly Selector UpdateTextureMappingModeIndirectBufferIndirectBufferOffset = Selector.Register("updateTextureMapping:mode:indirectBuffer:indirectBufferOffset:");

    public static readonly Selector UpdateTextureMappingsModeRegionsMipLevelsSlicesNumRegions = Selector.Register("updateTextureMappings:mode:regions:mipLevels:slices:numRegions:");

    public static readonly Selector WaitForFence = Selector.Register("waitForFence:");
}
