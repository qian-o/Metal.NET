using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFXTemporalDenoisedScaler_Selectors
{
    internal static readonly Selector encodeToCommandBuffer_ = Selector.Register("encodeToCommandBuffer:");
}

public class MTLFXTemporalDenoisedScaler : IDisposable
{
    public nint NativePtr { get; }

    public MTLFXTemporalDenoisedScaler(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFXTemporalDenoisedScaler o) => o.NativePtr;
    public static implicit operator MTLFXTemporalDenoisedScaler(nint ptr) => new MTLFXTemporalDenoisedScaler(ptr);

    ~MTLFXTemporalDenoisedScaler() => Release();

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

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScaler_Selectors.encodeToCommandBuffer_, commandBuffer.NativePtr);
    }

}
