using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLCommandQueueDescriptor_Selectors
{
    internal static readonly Selector setLogState_ = Selector.Register("setLogState:");
    internal static readonly Selector setMaxCommandBufferCount_ = Selector.Register("setMaxCommandBufferCount:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLCommandQueueDescriptor
{
    public readonly nint NativePtr;

    public MTLCommandQueueDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLCommandQueueDescriptor o) => o.NativePtr;
    public static implicit operator MTLCommandQueueDescriptor(nint ptr) => new MTLCommandQueueDescriptor(ptr);

    public void SetLogState(MTLLogState logState)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandQueueDescriptor_Selectors.setLogState_, logState.NativePtr);
    }

    public void SetMaxCommandBufferCount(nuint maxCommandBufferCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCommandQueueDescriptor_Selectors.setMaxCommandBufferCount_, (nint)maxCommandBufferCount);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
