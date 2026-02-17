using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class NSURL_Selectors
{
    internal static readonly Selector initFileURLWithPath_ = Selector.Register("initFileURLWithPath:");
    internal static readonly Selector fileURLWithPath_ = Selector.Register("fileURLWithPath:");
}

public class NSURL : IDisposable
{
    public nint NativePtr { get; }

    public NSURL(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(NSURL o) => o.NativePtr;
    public static implicit operator NSURL(nint ptr) => new NSURL(ptr);

    ~NSURL() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("NSURL");

    public NSURL InitFileURLWithPath(NSString pPath)
    {
        var __r = new NSURL(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, NSURL_Selectors.initFileURLWithPath_, pPath.NativePtr));
        return __r;
    }

    public static NSURL FileURLWithPath(NSString pPath)
    {
        var __r = new NSURL(ObjectiveCRuntime.intptr_objc_msgSend(s_class, NSURL_Selectors.fileURLWithPath_, pPath.NativePtr));
        return __r;
    }

}
