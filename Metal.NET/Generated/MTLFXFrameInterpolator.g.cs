using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFXFrameInterpolator_Selectors
{
    internal static readonly Selector encodeToCommandBuffer_ = Selector.Register("encodeToCommandBuffer:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLFXFrameInterpolator
{
    public readonly nint NativePtr;

    public MTLFXFrameInterpolator(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFXFrameInterpolator o) => o.NativePtr;
    public static implicit operator MTLFXFrameInterpolator(nint ptr) => new MTLFXFrameInterpolator(ptr);

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolator_Selectors.encodeToCommandBuffer_, commandBuffer.NativePtr);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
