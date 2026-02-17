using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLIOScratchBuffer_Selectors
{
}

public class MTLIOScratchBuffer : IDisposable
{
    public nint NativePtr { get; }

    public MTLIOScratchBuffer(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLIOScratchBuffer o) => o.NativePtr;
    public static implicit operator MTLIOScratchBuffer(nint ptr) => new MTLIOScratchBuffer(ptr);

    ~MTLIOScratchBuffer() => Release();

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
