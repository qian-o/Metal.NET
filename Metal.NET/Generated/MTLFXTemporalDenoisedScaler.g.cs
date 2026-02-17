using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFXTemporalDenoisedScaler_Selectors
{
    internal static readonly Selector encodeToCommandBuffer_ = Selector.Register("encodeToCommandBuffer:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLFXTemporalDenoisedScaler
{
    public readonly nint NativePtr;

    public MTLFXTemporalDenoisedScaler(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFXTemporalDenoisedScaler o) => o.NativePtr;
    public static implicit operator MTLFXTemporalDenoisedScaler(nint ptr) => new MTLFXTemporalDenoisedScaler(ptr);

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScaler_Selectors.encodeToCommandBuffer_, commandBuffer.NativePtr);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
