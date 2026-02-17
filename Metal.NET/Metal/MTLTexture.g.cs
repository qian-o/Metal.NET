using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTexture_Selectors
{
    internal static readonly Selector newRemoteTextureViewForDevice_ = Selector.Register("newRemoteTextureViewForDevice:");
    internal static readonly Selector newSharedTextureHandle = Selector.Register("newSharedTextureHandle");
    internal static readonly Selector newTextureView_ = Selector.Register("newTextureView:");
    internal static readonly Selector replaceRegion_level_slice_pixelBytes_bytesPerRow_bytesPerImage_ = Selector.Register("replaceRegion:level:slice:pixelBytes:bytesPerRow:bytesPerImage:");
}

public class MTLTexture : IDisposable
{
    public nint NativePtr { get; }

    public MTLTexture(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTexture o) => o.NativePtr;
    public static implicit operator MTLTexture(nint ptr) => new MTLTexture(ptr);

    ~MTLTexture() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    public MTLTexture NewRemoteTextureViewForDevice(MTLDevice device)
    {
        var __r = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLTexture_Selectors.newRemoteTextureViewForDevice_, device.NativePtr));
        return __r;
    }

    public MTLSharedTextureHandle NewSharedTextureHandle()
    {
        var __r = new MTLSharedTextureHandle(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLTexture_Selectors.newSharedTextureHandle));
        return __r;
    }

    public MTLTexture NewTextureView(MTLPixelFormat pixelFormat)
    {
        var __r = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLTexture_Selectors.newTextureView_, (nint)(uint)pixelFormat));
        return __r;
    }

    public MTLTexture NewTextureView(MTLTextureViewDescriptor descriptor)
    {
        var __r = new MTLTexture(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLTexture_Selectors.newTextureView_, descriptor.NativePtr));
        return __r;
    }

    public void ReplaceRegion(MTLRegion region, nuint level, nuint slice, nint pixelBytes, nuint bytesPerRow, nuint bytesPerImage)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTexture_Selectors.replaceRegion_level_slice_pixelBytes_bytesPerRow_bytesPerImage_, region, (nint)level, (nint)slice, pixelBytes, (nint)bytesPerRow, (nint)bytesPerImage);
    }

}
