using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunctionLog_Selectors
{
}

public class MTLFunctionLog : IDisposable
{
    public nint NativePtr { get; }

    public MTLFunctionLog(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunctionLog o) => o.NativePtr;
    public static implicit operator MTLFunctionLog(nint ptr) => new MTLFunctionLog(ptr);

    ~MTLFunctionLog() => Release();

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
