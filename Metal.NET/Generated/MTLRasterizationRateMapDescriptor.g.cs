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

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLRasterizationRateMapDescriptor
{
    public readonly nint NativePtr;

    public MTLRasterizationRateMapDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRasterizationRateMapDescriptor o) => o.NativePtr;
    public static implicit operator MTLRasterizationRateMapDescriptor(nint ptr) => new MTLRasterizationRateMapDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLRasterizationRateMapDescriptor");

    public static MTLRasterizationRateMapDescriptor Alloc()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        return new MTLRasterizationRateMapDescriptor(ptr);
    }

    public MTLRasterizationRateMapDescriptor Init()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, Selector.Register("init"));
        return new MTLRasterizationRateMapDescriptor(ptr);
    }

    public static MTLRasterizationRateMapDescriptor New()
    {
        return Alloc().Init();
    }

    public MTLRasterizationRateLayerDescriptor Layer(nuint layerIndex)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRasterizationRateMapDescriptor_Selectors.layer_, (nint)layerIndex);
        return new MTLRasterizationRateLayerDescriptor(__result);
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

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
