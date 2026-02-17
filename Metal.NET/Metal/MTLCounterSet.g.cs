using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLCounterSet_Selectors
{
}

public class MTLCounterSet : IDisposable
{
    public nint NativePtr { get; }

    public MTLCounterSet(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLCounterSet o) => o.NativePtr;
    public static implicit operator MTLCounterSet(nint ptr) => new MTLCounterSet(ptr);

    ~MTLCounterSet() => Release();

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
