using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLPackedFloatQuaternion_Selectors
{
}

public class MTLPackedFloatQuaternion : IDisposable
{
    public nint NativePtr { get; }

    public MTLPackedFloatQuaternion(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLPackedFloatQuaternion o) => o.NativePtr;
    public static implicit operator MTLPackedFloatQuaternion(nint ptr) => new MTLPackedFloatQuaternion(ptr);

    ~MTLPackedFloatQuaternion() => Release();

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
