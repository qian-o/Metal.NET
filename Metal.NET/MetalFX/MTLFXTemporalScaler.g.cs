using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFXTemporalScaler_Selectors
{
    internal static readonly Selector encodeToCommandBuffer_ = Selector.Register("encodeToCommandBuffer:");
}

public class MTLFXTemporalScaler : IDisposable
{
    public nint NativePtr { get; }

    public MTLFXTemporalScaler(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFXTemporalScaler o) => o.NativePtr;
    public static implicit operator MTLFXTemporalScaler(nint ptr) => new MTLFXTemporalScaler(ptr);

    ~MTLFXTemporalScaler() => Release();

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

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScaler_Selectors.encodeToCommandBuffer_, pCommandBuffer.NativePtr);
    }

}
