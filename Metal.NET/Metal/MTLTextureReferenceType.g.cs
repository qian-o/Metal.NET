using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLTextureReferenceType_Selectors
{
}

public class MTLTextureReferenceType : IDisposable
{
    public nint NativePtr { get; }

    public MTLTextureReferenceType(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLTextureReferenceType o) => o.NativePtr;
    public static implicit operator MTLTextureReferenceType(nint ptr) => new MTLTextureReferenceType(ptr);

    ~MTLTextureReferenceType() => Release();

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
