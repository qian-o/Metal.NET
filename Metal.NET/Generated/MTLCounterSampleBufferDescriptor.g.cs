using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLCounterSampleBufferDescriptor_Selectors
{
    internal static readonly Selector setCounterSet_ = Selector.Register("setCounterSet:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
    internal static readonly Selector setSampleCount_ = Selector.Register("setSampleCount:");
    internal static readonly Selector setStorageMode_ = Selector.Register("setStorageMode:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLCounterSampleBufferDescriptor
{
    public readonly nint NativePtr;

    public MTLCounterSampleBufferDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLCounterSampleBufferDescriptor o) => o.NativePtr;
    public static implicit operator MTLCounterSampleBufferDescriptor(nint ptr) => new MTLCounterSampleBufferDescriptor(ptr);

    public void SetCounterSet(MTLCounterSet counterSet)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCounterSampleBufferDescriptor_Selectors.setCounterSet_, counterSet.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCounterSampleBufferDescriptor_Selectors.setLabel_, label.NativePtr);
    }

    public void SetSampleCount(nuint sampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCounterSampleBufferDescriptor_Selectors.setSampleCount_, (nint)sampleCount);
    }

    public void SetStorageMode(MTLStorageMode storageMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCounterSampleBufferDescriptor_Selectors.setStorageMode_, (nint)(uint)storageMode);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
