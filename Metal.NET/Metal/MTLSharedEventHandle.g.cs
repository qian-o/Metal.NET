using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLSharedEventHandle_Selectors
{
}

public class MTLSharedEventHandle : IDisposable
{
    public nint NativePtr { get; }

    public MTLSharedEventHandle(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLSharedEventHandle o) => o.NativePtr;
    public static implicit operator MTLSharedEventHandle(nint ptr) => new MTLSharedEventHandle(ptr);

    ~MTLSharedEventHandle() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLSharedEventHandle");

    public static MTLSharedEventHandle New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLSharedEventHandle(ptr);
    }

}
