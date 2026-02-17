using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLAttribute_Selectors
{
}

public class MTLAttribute : IDisposable
{
    public nint NativePtr { get; }

    public MTLAttribute(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLAttribute o) => o.NativePtr;
    public static implicit operator MTLAttribute(nint ptr) => new MTLAttribute(ptr);

    ~MTLAttribute() => Release();

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
