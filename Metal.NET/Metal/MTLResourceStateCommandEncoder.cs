namespace Metal.NET;

/// <summary>An encoder that encodes commands that modify resource configurations.</summary>
public class MTLResourceStateCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTLCommandEncoder(nativePtr, ownership), INativeObject<MTLResourceStateCommandEncoder>
{
    #region INativeObject
    public static new MTLResourceStateCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLResourceStateCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Updating texture memory assignments - Methods

    /// <summary>Encodes a command to update the texture mappings for a region in a single texture mipmap.</summary>
    public void UpdateTextureMapping(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLRegion region, nuint mipLevel, nuint slice)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMapping, texture.NativePtr, (nuint)mode, region, mipLevel, slice);
    }

    /// <summary>Encodes a command to update the texture mappings for a region in a single texture mipmap.</summary>
    public void UpdateTextureMapping(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMappingmodeindirectBufferindirectBufferOffset, texture.NativePtr, (nuint)mode, indirectBuffer.NativePtr, indirectBufferOffset);
    }

    /// <summary>Encodes a command to update memory mappings for multiple regions inside a texture.</summary>
    public void UpdateTextureMappings(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLRegion regions, nint mipLevels, nint slices, nuint numRegions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateTextureMappings, texture.NativePtr, (nuint)mode, regions, mipLevels, slices, numRegions);
    }
    #endregion

    #region Performing fence operations - Methods

    /// <summary>Encodes a command that instructs the GPU to update a fence, which signals passes waiting on the fence.</summary>
    public void UpdateFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.UpdateFence, fence.NativePtr);
    }

    /// <summary>Encodes a command that instructs the GPU to pause before starting the resource state commands until another pass updates a fence.</summary>
    public void WaitForFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.WaitForFence, fence.NativePtr);
    }
    #endregion

    #region Instance Methods - Methods

    public void MoveTextureMappingsFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceStateCommandEncoderBindings.MoveTextureMappingsFromTexture, sourceTexture.NativePtr, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, destinationSlice, destinationLevel, destinationOrigin);
    }
    #endregion
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
