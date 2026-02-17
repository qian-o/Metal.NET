using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunctionHandle_Selectors
{
}

public class MTLFunctionHandle : IDisposable
{
    public nint NativePtr { get; }

    public MTLFunctionHandle(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionHandle o) => o.NativePtr;
    public static implicit operator MTLFunctionHandle(nint ptr) => new MTLFunctionHandle(ptr);

    ~MTLFunctionHandle() => Release();

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
