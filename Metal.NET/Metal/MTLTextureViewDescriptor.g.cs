using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTextureViewDescriptor_Selectors
{
    internal static readonly Selector setPixelFormat_ = Selector.Register("setPixelFormat:");
    internal static readonly Selector setSwizzle_ = Selector.Register("setSwizzle:");
    internal static readonly Selector setTextureType_ = Selector.Register("setTextureType:");
}

public class MTLTextureViewDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLTextureViewDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTextureViewDescriptor o) => o.NativePtr;
    public static implicit operator MTLTextureViewDescriptor(nint ptr) => new MTLTextureViewDescriptor(ptr);

    ~MTLTextureViewDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLTextureViewDescriptor");

    public static MTLTextureViewDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLTextureViewDescriptor(ptr);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureViewDescriptor_Selectors.setPixelFormat_, (nint)(uint)pixelFormat);
    }

    public void SetSwizzle(MTLTextureSwizzleChannels swizzle)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureViewDescriptor_Selectors.setSwizzle_, swizzle.NativePtr);
    }

    public void SetTextureType(MTLTextureType textureType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureViewDescriptor_Selectors.setTextureType_, (nint)(uint)textureType);
    }

}
