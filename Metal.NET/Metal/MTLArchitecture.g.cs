using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLArchitecture_Selectors
{
}

public class MTLArchitecture : IDisposable
{
    public nint NativePtr { get; }

    public MTLArchitecture(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLArchitecture o) => o.NativePtr;
    public static implicit operator MTLArchitecture(nint ptr) => new MTLArchitecture(ptr);

    ~MTLArchitecture() => Release();

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
