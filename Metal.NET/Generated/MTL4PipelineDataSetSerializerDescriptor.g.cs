using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4PipelineDataSetSerializerDescriptor_Selectors
{
    internal static readonly Selector setConfiguration_ = Selector.Register("setConfiguration:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTL4PipelineDataSetSerializerDescriptor
{
    public readonly nint NativePtr;

    public MTL4PipelineDataSetSerializerDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4PipelineDataSetSerializerDescriptor o) => o.NativePtr;
    public static implicit operator MTL4PipelineDataSetSerializerDescriptor(nint ptr) => new MTL4PipelineDataSetSerializerDescriptor(ptr);

    public void SetConfiguration(nuint configuration)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4PipelineDataSetSerializerDescriptor_Selectors.setConfiguration_, (nint)configuration);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
