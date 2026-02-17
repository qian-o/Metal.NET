using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLPipelineBufferDescriptor_Selectors
{
    internal static readonly Selector setMutability_ = Selector.Register("setMutability:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLPipelineBufferDescriptor
{
    public readonly nint NativePtr;

    public MTLPipelineBufferDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLPipelineBufferDescriptor o) => o.NativePtr;
    public static implicit operator MTLPipelineBufferDescriptor(nint ptr) => new MTLPipelineBufferDescriptor(ptr);

    public void SetMutability(MTLMutability mutability)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPipelineBufferDescriptor_Selectors.setMutability_, (nint)(uint)mutability);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
