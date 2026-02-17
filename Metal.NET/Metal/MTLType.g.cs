using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLType_Selectors
{
}

public class MTLType : IDisposable
{
    public nint NativePtr { get; }

    public MTLType(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLType o) => o.NativePtr;
    public static implicit operator MTLType(nint ptr) => new MTLType(ptr);

    ~MTLType() => Release();

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
