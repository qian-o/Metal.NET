namespace Metal.NET;

public class MTLTexture : IDisposable
{
    public MTLTexture(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLTexture()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLTexture value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTexture(nint value)
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

    public MTLTexture NewRemoteTextureViewForDevice(MTLDevice device)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.NewRemoteTextureViewForDevice, device.NativePtr));

        return result;
    }

    public MTLSharedTextureHandle NewSharedTextureHandle()
    {
        MTLSharedTextureHandle result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.NewSharedTextureHandle));

        return result;
    }

    public MTLTexture NewTextureView(MTLPixelFormat pixelFormat)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.NewTextureView, (nint)(uint)pixelFormat));

        return result;
    }

    public MTLTexture NewTextureView(MTLTextureViewDescriptor descriptor)
    {
        MTLTexture result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureSelector.NewTextureView, descriptor.NativePtr));

        return result;
    }

    public void ReplaceRegion(MTLRegion region, uint level, uint slice, int pixelBytes, uint bytesPerRow, uint bytesPerImage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureSelector.ReplaceRegionLevelSlicePixelBytesBytesPerRowBytesPerImage, region, (nint)level, (nint)slice, pixelBytes, (nint)bytesPerRow, (nint)bytesPerImage);
    }

}

file class MTLTextureSelector
{
    public static readonly Selector NewRemoteTextureViewForDevice = Selector.Register("newRemoteTextureViewForDevice:");

    public static readonly Selector NewSharedTextureHandle = Selector.Register("newSharedTextureHandle");

    public static readonly Selector NewTextureView = Selector.Register("newTextureView:");

    public static readonly Selector ReplaceRegionLevelSlicePixelBytesBytesPerRowBytesPerImage = Selector.Register("replaceRegion:level:slice:pixelBytes:bytesPerRow:bytesPerImage:");
}
