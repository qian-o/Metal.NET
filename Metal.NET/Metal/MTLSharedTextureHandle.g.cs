using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLSharedTextureHandle_Selectors
{
}

public class MTLSharedTextureHandle : IDisposable
{
    public nint NativePtr { get; }

    public MTLSharedTextureHandle(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLSharedTextureHandle o) => o.NativePtr;
    public static implicit operator MTLSharedTextureHandle(nint ptr) => new MTLSharedTextureHandle(ptr);

    ~MTLSharedTextureHandle() => Release();

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

}
