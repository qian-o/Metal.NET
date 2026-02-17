using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLCounterSampleBuffer_Selectors
{
}

public class MTLCounterSampleBuffer : IDisposable
{
    public nint NativePtr { get; }

    public MTLCounterSampleBuffer(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLCounterSampleBuffer o) => o.NativePtr;
    public static implicit operator MTLCounterSampleBuffer(nint ptr) => new MTLCounterSampleBuffer(ptr);

    ~MTLCounterSampleBuffer() => Release();

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
