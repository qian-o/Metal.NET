using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLCounter_Selectors
{
}

public class MTLCounter : IDisposable
{
    public nint NativePtr { get; }

    public MTLCounter(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLCounter o) => o.NativePtr;
    public static implicit operator MTLCounter(nint ptr) => new MTLCounter(ptr);

    ~MTLCounter() => Release();

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
