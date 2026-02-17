using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLArgument_Selectors
{
}

public class MTLArgument : IDisposable
{
    public nint NativePtr { get; }

    public MTLArgument(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLArgument o) => o.NativePtr;
    public static implicit operator MTLArgument(nint ptr) => new MTLArgument(ptr);

    ~MTLArgument() => Release();

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
