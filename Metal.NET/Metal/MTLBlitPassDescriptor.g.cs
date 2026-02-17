using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLBlitPassDescriptor_Selectors
{
    internal static readonly Selector blitPassDescriptor = Selector.Register("blitPassDescriptor");
}

public class MTLBlitPassDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLBlitPassDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLBlitPassDescriptor o) => o.NativePtr;
    public static implicit operator MTLBlitPassDescriptor(nint ptr) => new MTLBlitPassDescriptor(ptr);

    ~MTLBlitPassDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLBlitPassDescriptor");

    public static MTLBlitPassDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLBlitPassDescriptor(ptr);
    }

    public static MTLBlitPassDescriptor BlitPassDescriptor()
    {
        var __r = new MTLBlitPassDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLBlitPassDescriptor_Selectors.blitPassDescriptor));
        return __r;
    }

}
