using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLResourceViewPool_Selectors
{
}

public class MTLResourceViewPool : IDisposable
{
    public nint NativePtr { get; }

    public MTLResourceViewPool(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLResourceViewPool o) => o.NativePtr;
    public static implicit operator MTLResourceViewPool(nint ptr) => new MTLResourceViewPool(ptr);

    ~MTLResourceViewPool() => Release();

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
