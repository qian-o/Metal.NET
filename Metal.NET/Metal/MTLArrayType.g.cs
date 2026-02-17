using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLArrayType_Selectors
{
}

public class MTLArrayType : IDisposable
{
    public nint NativePtr { get; }

    public MTLArrayType(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLArrayType o) => o.NativePtr;
    public static implicit operator MTLArrayType(nint ptr) => new MTLArrayType(ptr);

    ~MTLArrayType() => Release();

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
