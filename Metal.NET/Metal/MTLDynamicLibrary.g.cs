using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLDynamicLibrary_Selectors
{
    internal static readonly Selector serializeToURL_error_ = Selector.Register("serializeToURL:error:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

public class MTLDynamicLibrary : IDisposable
{
    public nint NativePtr { get; }

    public MTLDynamicLibrary(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLDynamicLibrary o) => o.NativePtr;
    public static implicit operator MTLDynamicLibrary(nint ptr) => new MTLDynamicLibrary(ptr);

    ~MTLDynamicLibrary() => Release();

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

    public Bool8 SerializeToURL(NSURL url, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLDynamicLibrary_Selectors.serializeToURL_error_, url.NativePtr, out __errorPtr) != 0;
        error = new NSError(__errorPtr);
        return __r;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDynamicLibrary_Selectors.setLabel_, label.NativePtr);
    }

}
