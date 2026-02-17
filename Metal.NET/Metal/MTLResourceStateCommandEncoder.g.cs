namespace Metal.NET;

file class MTLResourceStateCommandEncoderSelector
{
    public static readonly Selector MoveTextureMappingsFromTexture_sourceSlice_sourceLevel_sourceOrigin_sourceSize_destinationTexture_destinationSlice_destinationLevel_destinationOrigin_ = Selector.Register("moveTextureMappingsFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:destinationTexture:destinationSlice:destinationLevel:destinationOrigin:");
    public static readonly Selector UpdateFence_ = Selector.Register("updateFence:");
    public static readonly Selector UpdateTextureMapping_mode_indirectBuffer_indirectBufferOffset_ = Selector.Register("updateTextureMapping:mode:indirectBuffer:indirectBufferOffset:");
    public static readonly Selector WaitForFence_ = Selector.Register("waitForFence:");
}

public class MTLResourceStateCommandEncoder : IDisposable
{
    public MTLResourceStateCommandEncoder(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLResourceStateCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    public void MoveTextureMappingsFromTexture(MTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResourceStateCommandEncoderSelector.MoveTextureMappingsFromTexture_sourceSlice_sourceLevel_sourceOrigin_sourceSize_destinationTexture_destinationSlice_destinationLevel_destinationOrigin_, sourceTexture.NativePtr, (nint)sourceSlice, (nint)sourceLevel, sourceOrigin, sourceSize, destinationTexture.NativePtr, (nint)destinationSlice, (nint)destinationLevel, destinationOrigin);
    }

    public void UpdateFence(MTLFence fence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResourceStateCommandEncoderSelector.UpdateFence_, fence.NativePtr);
    }

    public void UpdateTextureMapping(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLBuffer indirectBuffer, nuint indirectBufferOffset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResourceStateCommandEncoderSelector.UpdateTextureMapping_mode_indirectBuffer_indirectBufferOffset_, texture.NativePtr, (nint)(uint)mode, indirectBuffer.NativePtr, (nint)indirectBufferOffset);
    }

    public void WaitForFence(MTLFence fence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResourceStateCommandEncoderSelector.WaitForFence_, fence.NativePtr);
    }

}
