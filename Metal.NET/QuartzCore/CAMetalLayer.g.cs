using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class CAMetalLayer_Selectors
{
    internal static readonly Selector setDevice_ = Selector.Register("setDevice:");
    internal static readonly Selector setPixelFormat_ = Selector.Register("setPixelFormat:");
    internal static readonly Selector setFramebufferOnly_ = Selector.Register("setFramebufferOnly:");
    internal static readonly Selector setMaximumDrawableCount_ = Selector.Register("setMaximumDrawableCount:");
    internal static readonly Selector setDisplaySyncEnabled_ = Selector.Register("setDisplaySyncEnabled:");
    internal static readonly Selector setColorspace_ = Selector.Register("setColorspace:");
    internal static readonly Selector setAllowsNextDrawableTimeout_ = Selector.Register("setAllowsNextDrawableTimeout:");
    internal static readonly Selector layer = Selector.Register("layer");
}

public class CAMetalLayer : IDisposable
{
    public nint NativePtr { get; }

    public CAMetalLayer(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(CAMetalLayer o) => o.NativePtr;
    public static implicit operator CAMetalLayer(nint ptr) => new CAMetalLayer(ptr);

    ~CAMetalLayer() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("CAMetalLayer");

    public static CAMetalLayer New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new CAMetalLayer(ptr);
    }

    public void SetDevice(MTLDevice device)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayer_Selectors.setDevice_, device.NativePtr);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayer_Selectors.setPixelFormat_, (nint)(uint)pixelFormat);
    }

    public void SetFramebufferOnly(Bool8 framebufferOnly)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayer_Selectors.setFramebufferOnly_, (nint)framebufferOnly.Value);
    }

    public void SetMaximumDrawableCount(nuint maximumDrawableCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayer_Selectors.setMaximumDrawableCount_, (nint)maximumDrawableCount);
    }

    public void SetDisplaySyncEnabled(Bool8 displaySyncEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayer_Selectors.setDisplaySyncEnabled_, (nint)displaySyncEnabled.Value);
    }

    public void SetColorspace(nint colorspace)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayer_Selectors.setColorspace_, colorspace);
    }

    public void SetAllowsNextDrawableTimeout(Bool8 allowsNextDrawableTimeout)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, CAMetalLayer_Selectors.setAllowsNextDrawableTimeout_, (nint)allowsNextDrawableTimeout.Value);
    }

    public static CAMetalLayer Layer()
    {
        var __r = new CAMetalLayer(ObjectiveCRuntime.intptr_objc_msgSend(s_class, CAMetalLayer_Selectors.layer));
        return __r;
    }

}
