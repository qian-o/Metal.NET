namespace Metal.NET;

file class MTLTextureSelector
{
    public static readonly Selector NewRemoteTextureViewForDevice_ = Selector.Register("newRemoteTextureViewForDevice:");
    public static readonly Selector NewSharedTextureHandle = Selector.Register("newSharedTextureHandle");
    public static readonly Selector NewTextureView_ = Selector.Register("newTextureView:");
    public static readonly Selector ReplaceRegion_level_slice_pixelBytes_bytesPerRow_bytesPerImage_ = Selector.Register("replaceRegion:level:slice:pixelBytes:bytesPerRow:bytesPerImage:");
}

public class MTLTexture : IDisposable
{
    public MTLTexture(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        var result = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLTextureSelector.NewRemoteTextureViewForDevice_, device.NativePtr));

        return result;
    }

    public MTLSharedTextureHandle NewSharedTextureHandle()
    {
        var result = new MTLSharedTextureHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLTextureSelector.NewSharedTextureHandle));

        return result;
    }

    public MTLTexture NewTextureView(MTLPixelFormat pixelFormat)
    {
        var result = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLTextureSelector.NewTextureView_, (nint)(uint)pixelFormat));

        return result;
    }

    public MTLTexture NewTextureView(MTLTextureViewDescriptor descriptor)
    {
        var result = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLTextureSelector.NewTextureView_, descriptor.NativePtr));

        return result;
    }

    public void ReplaceRegion(MTLRegion region, nuint level, nuint slice, nint pixelBytes, nuint bytesPerRow, nuint bytesPerImage)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureSelector.ReplaceRegion_level_slice_pixelBytes_bytesPerRow_bytesPerImage_, region, (nint)level, (nint)slice, pixelBytes, (nint)bytesPerRow, (nint)bytesPerImage);
    }

}
