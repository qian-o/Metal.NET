using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLIOCommandQueue_Selectors
{
    internal static readonly Selector enqueueBarrier = Selector.Register("enqueueBarrier");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLIOCommandQueue
{
    public readonly nint NativePtr;

    public MTLIOCommandQueue(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLIOCommandQueue o) => o.NativePtr;
    public static implicit operator MTLIOCommandQueue(nint ptr) => new MTLIOCommandQueue(ptr);

    public void EnqueueBarrier()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueue_Selectors.enqueueBarrier);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIOCommandQueue_Selectors.setLabel_, label.NativePtr);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
