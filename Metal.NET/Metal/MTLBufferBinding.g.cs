using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLBufferBinding_Selectors
{
}

public class MTLBufferBinding : IDisposable
{
    public nint NativePtr { get; }

    public MTLBufferBinding(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLBufferBinding o) => o.NativePtr;
    public static implicit operator MTLBufferBinding(nint ptr) => new MTLBufferBinding(ptr);

    ~MTLBufferBinding() => Release();

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
