using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4PipelineDescriptor_Selectors
{
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
    internal static readonly Selector setOptions_ = Selector.Register("setOptions:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTL4PipelineDescriptor
{
    public readonly nint NativePtr;

    public MTL4PipelineDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4PipelineDescriptor o) => o.NativePtr;
    public static implicit operator MTL4PipelineDescriptor(nint ptr) => new MTL4PipelineDescriptor(ptr);

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4PipelineDescriptor_Selectors.setLabel_, label.NativePtr);
    }

    public void SetOptions(MTL4PipelineOptions options)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4PipelineDescriptor_Selectors.setOptions_, options.NativePtr);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
