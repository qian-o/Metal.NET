using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLAllocation_Selectors
{
}

public class MTLAllocation : IDisposable
{
    public nint NativePtr { get; }

    public MTLAllocation(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLAllocation o) => o.NativePtr;
    public static implicit operator MTLAllocation(nint ptr) => new MTLAllocation(ptr);

    ~MTLAllocation() => Release();

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
