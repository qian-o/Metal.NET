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

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLTexture
{
    public readonly nint NativePtr;

    public MTLTexture(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTexture o) => o.NativePtr;
    public static implicit operator MTLTexture(nint ptr) => new MTLTexture(ptr);

    public MTLTexture NewRemoteTextureViewForDevice(MTLDevice device)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLTexture_Selectors.newRemoteTextureViewForDevice_, device.NativePtr);
        return new MTLTexture(__result);
    }

    public MTLSharedTextureHandle NewSharedTextureHandle()
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLTexture_Selectors.newSharedTextureHandle);
        return new MTLSharedTextureHandle(__result);
    }

    public MTLTexture NewTextureView(MTLPixelFormat pixelFormat)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLTexture_Selectors.newTextureView_, (nint)(uint)pixelFormat);
        return new MTLTexture(__result);
    }

    public MTLTexture NewTextureView(MTLTextureViewDescriptor descriptor)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLTexture_Selectors.newTextureView_, descriptor.NativePtr);
        return new MTLTexture(__result);
    }

    public void ReplaceRegion(MTLRegion region, nuint level, nuint slice, nint pixelBytes, nuint bytesPerRow, nuint bytesPerImage)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTexture_Selectors.replaceRegion_level_slice_pixelBytes_bytesPerRow_bytesPerImage_, region, (nint)level, (nint)slice, pixelBytes, (nint)bytesPerRow, (nint)bytesPerImage);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
