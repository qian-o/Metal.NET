using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTextureBinding_Selectors
{
}

public class MTLTextureBinding : IDisposable
{
    public nint NativePtr { get; }

    public MTLTextureBinding(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTextureBinding o) => o.NativePtr;
    public static implicit operator MTLTextureBinding(nint ptr) => new MTLTextureBinding(ptr);

    ~MTLTextureBinding() => Release();

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
