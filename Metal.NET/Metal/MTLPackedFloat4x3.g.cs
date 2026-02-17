using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLPackedFloat4x3_Selectors
{
}

public class MTLPackedFloat4x3 : IDisposable
{
    public nint NativePtr { get; }

    public MTLPackedFloat4x3(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLPackedFloat4x3 o) => o.NativePtr;
    public static implicit operator MTLPackedFloat4x3(nint ptr) => new MTLPackedFloat4x3(ptr);

    ~MTLPackedFloat4x3() => Release();

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
