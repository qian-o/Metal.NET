using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRasterizationRateLayerDescriptor_Selectors
{
    internal static readonly Selector setSampleCount_ = Selector.Register("setSampleCount:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLRasterizationRateLayerDescriptor
{
    public readonly nint NativePtr;

    public MTLRasterizationRateLayerDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRasterizationRateLayerDescriptor o) => o.NativePtr;
    public static implicit operator MTLRasterizationRateLayerDescriptor(nint ptr) => new MTLRasterizationRateLayerDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRasterizationRateLayerDescriptor");

    public static MTLRasterizationRateLayerDescriptor Alloc()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        return new MTLRasterizationRateLayerDescriptor(ptr);
    }

    public MTLRasterizationRateLayerDescriptor Init()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, Selector.Register("init"));
        return new MTLRasterizationRateLayerDescriptor(ptr);
    }

    public static MTLRasterizationRateLayerDescriptor New()
    {
        return Alloc().Init();
    }

    public void SetSampleCount(MTLSize sampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateLayerDescriptor_Selectors.setSampleCount_, sampleCount);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
