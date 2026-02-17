using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunctionLogDebugLocation_Selectors
{
}

public class MTLFunctionLogDebugLocation : IDisposable
{
    public nint NativePtr { get; }

    public MTLFunctionLogDebugLocation(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionLogDebugLocation o) => o.NativePtr;
    public static implicit operator MTLFunctionLogDebugLocation(nint ptr) => new MTLFunctionLogDebugLocation(ptr);

    ~MTLFunctionLogDebugLocation() => Release();

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
