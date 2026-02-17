using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4CommandBufferOptions_Selectors
{
    internal static readonly Selector setLogState_ = Selector.Register("setLogState:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTL4CommandBufferOptions
{
    public readonly nint NativePtr;

    public MTL4CommandBufferOptions(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4CommandBufferOptions o) => o.NativePtr;
    public static implicit operator MTL4CommandBufferOptions(nint ptr) => new MTL4CommandBufferOptions(ptr);

    public void SetLogState(MTLLogState logState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandBufferOptions_Selectors.setLogState_, logState.NativePtr);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
