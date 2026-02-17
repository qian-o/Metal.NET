using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLPackedFloat3_Selectors
{
}

public class MTLPackedFloat3 : IDisposable
{
    public nint NativePtr { get; }

    public MTLPackedFloat3(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLPackedFloat3 o) => o.NativePtr;
    public static implicit operator MTLPackedFloat3(nint ptr) => new MTLPackedFloat3(ptr);

    ~MTLPackedFloat3() => Release();

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
