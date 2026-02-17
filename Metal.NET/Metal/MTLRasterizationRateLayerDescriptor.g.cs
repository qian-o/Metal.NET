using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRasterizationRateLayerDescriptor_Selectors
{
    internal static readonly Selector setSampleCount_ = Selector.Register("setSampleCount:");
}

public class MTLRasterizationRateLayerDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLRasterizationRateLayerDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRasterizationRateLayerDescriptor o) => o.NativePtr;
    public static implicit operator MTLRasterizationRateLayerDescriptor(nint ptr) => new MTLRasterizationRateLayerDescriptor(ptr);

    ~MTLRasterizationRateLayerDescriptor() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRasterizationRateLayerDescriptor");

    public static MTLRasterizationRateLayerDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLRasterizationRateLayerDescriptor(ptr);
    }

    public void SetSampleCount(MTLSize sampleCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateLayerDescriptor_Selectors.setSampleCount_, sampleCount);
    }

}
