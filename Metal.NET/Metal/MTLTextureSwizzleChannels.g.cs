using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTextureSwizzleChannels_Selectors
{
    internal static readonly Selector Default = Selector.Register("Default");
    internal static readonly Selector Make_g_b_a_ = Selector.Register("Make:g:b:a:");
}

public class MTLTextureSwizzleChannels : IDisposable
{
    public nint NativePtr { get; }

    public MTLTextureSwizzleChannels(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTextureSwizzleChannels o) => o.NativePtr;
    public static implicit operator MTLTextureSwizzleChannels(nint ptr) => new MTLTextureSwizzleChannels(ptr);

    ~MTLTextureSwizzleChannels() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLTextureSwizzleChannels");

    public static MTLTextureSwizzleChannels Default()
    {
        var __r = new MTLTextureSwizzleChannels(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLTextureSwizzleChannels_Selectors.Default));
        return __r;
    }

    public static MTLTextureSwizzleChannels Make(MTLTextureSwizzle r, MTLTextureSwizzle g, MTLTextureSwizzle b, MTLTextureSwizzle a)
    {
        var __r = new MTLTextureSwizzleChannels(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLTextureSwizzleChannels_Selectors.Make_g_b_a_, (nint)(uint)r, (nint)(uint)g, (nint)(uint)b, (nint)(uint)a));
        return __r;
    }

}
