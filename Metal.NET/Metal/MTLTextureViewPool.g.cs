using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTextureViewPool_Selectors
{
    internal static readonly Selector setTextureView_index_ = Selector.Register("setTextureView:index:");
    internal static readonly Selector setTextureView_descriptor_index_ = Selector.Register("setTextureView:descriptor:index:");
    internal static readonly Selector setTextureViewFromBuffer_descriptor_offset_bytesPerRow_index_ = Selector.Register("setTextureViewFromBuffer:descriptor:offset:bytesPerRow:index:");
}

public class MTLTextureViewPool : IDisposable
{
    public nint NativePtr { get; }

    public MTLTextureViewPool(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTextureViewPool o) => o.NativePtr;
    public static implicit operator MTLTextureViewPool(nint ptr) => new MTLTextureViewPool(ptr);

    ~MTLTextureViewPool() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLTextureViewPool");

    public static MTLTextureViewPool New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLTextureViewPool(ptr);
    }

}
