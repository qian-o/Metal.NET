using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLSharedEventListener_Selectors
{
    internal static readonly Selector sharedListener = Selector.Register("sharedListener");
}

public class MTLSharedEventListener : IDisposable
{
    public nint NativePtr { get; }

    public MTLSharedEventListener(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLSharedEventListener o) => o.NativePtr;
    public static implicit operator MTLSharedEventListener(nint ptr) => new MTLSharedEventListener(ptr);

    ~MTLSharedEventListener() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLSharedEventListener");

    public static MTLSharedEventListener SharedListener()
    {
        var __r = new MTLSharedEventListener(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLSharedEventListener_Selectors.sharedListener));
        return __r;
    }

}
