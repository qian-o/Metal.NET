using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLLogContainer_Selectors
{
}

public class MTLLogContainer : IDisposable
{
    public nint NativePtr { get; }

    public MTLLogContainer(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLLogContainer o) => o.NativePtr;
    public static implicit operator MTLLogContainer(nint ptr) => new MTLLogContainer(ptr);

    ~MTLLogContainer() => Release();

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
