using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLAccelerationStructure_Selectors
{
}

public class MTLAccelerationStructure : IDisposable
{
    public nint NativePtr { get; }

    public MTLAccelerationStructure(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLAccelerationStructure o) => o.NativePtr;
    public static implicit operator MTLAccelerationStructure(nint ptr) => new MTLAccelerationStructure(ptr);

    ~MTLAccelerationStructure() => Release();

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
