using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLBinding_Selectors
{
}

public class MTLBinding : IDisposable
{
    public nint NativePtr { get; }

    public MTLBinding(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLBinding o) => o.NativePtr;
    public static implicit operator MTLBinding(nint ptr) => new MTLBinding(ptr);

    ~MTLBinding() => Release();

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
