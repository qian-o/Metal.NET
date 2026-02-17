using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4CommandQueueDescriptor_Selectors
{
    internal static readonly Selector setFeedbackQueue_ = Selector.Register("setFeedbackQueue:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTL4CommandQueueDescriptor
{
    public readonly nint NativePtr;

    public MTL4CommandQueueDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4CommandQueueDescriptor o) => o.NativePtr;
    public static implicit operator MTL4CommandQueueDescriptor(nint ptr) => new MTL4CommandQueueDescriptor(ptr);

    public void SetFeedbackQueue(nint feedbackQueue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueDescriptor_Selectors.setFeedbackQueue_, feedbackQueue);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CommandQueueDescriptor_Selectors.setLabel_, label.NativePtr);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
