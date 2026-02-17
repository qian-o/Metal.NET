using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRasterizationRateMapDescriptor_Selectors
{
    internal static readonly Selector layer_ = Selector.Register("layer:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
    internal static readonly Selector setLayer_layerIndex_ = Selector.Register("setLayer:layerIndex:");
    internal static readonly Selector setScreenSize_ = Selector.Register("setScreenSize:");
}

public class MTLRasterizationRateMapDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLRasterizationRateMapDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRasterizationRateMapDescriptor o) => o.NativePtr;
    public static implicit operator MTLRasterizationRateMapDescriptor(nint ptr) => new MTLRasterizationRateMapDescriptor(ptr);

    ~MTLRasterizationRateMapDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRasterizationRateMapDescriptor");

    public static MTLRasterizationRateMapDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLRasterizationRateMapDescriptor(ptr);
    }

    public MTLRasterizationRateLayerDescriptor Layer(nuint layerIndex)
    {
        var __r = new MTLRasterizationRateLayerDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRasterizationRateMapDescriptor_Selectors.layer_, (nint)layerIndex));
        return __r;
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateMapDescriptor_Selectors.setLabel_, label.NativePtr);
    }

    public void SetLayer(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateMapDescriptor_Selectors.setLayer_layerIndex_, layer.NativePtr, (nint)layerIndex);
    }

    public void SetScreenSize(MTLSize screenSize)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateMapDescriptor_Selectors.setScreenSize_, screenSize);
    }

}
