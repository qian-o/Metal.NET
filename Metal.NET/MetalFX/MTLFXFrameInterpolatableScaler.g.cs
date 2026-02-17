using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFXFrameInterpolatableScaler_Selectors
{
}

public class MTLFXFrameInterpolatableScaler : IDisposable
{
    public nint NativePtr { get; }

    public MTLFXFrameInterpolatableScaler(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFXFrameInterpolatableScaler o) => o.NativePtr;
    public static implicit operator MTLFXFrameInterpolatableScaler(nint ptr) => new MTLFXFrameInterpolatableScaler(ptr);

    ~MTLFXFrameInterpolatableScaler() => Release();

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
