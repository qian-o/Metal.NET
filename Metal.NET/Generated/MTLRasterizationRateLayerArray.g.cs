using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRasterizationRateLayerArray_Selectors
{
    internal static readonly Selector object_ = Selector.Register("object:");
    internal static readonly Selector setObject_layerIndex_ = Selector.Register("setObject:layerIndex:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLRasterizationRateLayerArray
{
    public readonly nint NativePtr;

    public MTLRasterizationRateLayerArray(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRasterizationRateLayerArray o) => o.NativePtr;
    public static implicit operator MTLRasterizationRateLayerArray(nint ptr) => new MTLRasterizationRateLayerArray(ptr);

    public MTLRasterizationRateLayerDescriptor Object(nuint layerIndex)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRasterizationRateLayerArray_Selectors.object_, (nint)layerIndex);
        return new MTLRasterizationRateLayerDescriptor(__result);
    }

    public void SetObject(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateLayerArray_Selectors.setObject_layerIndex_, layer.NativePtr, (nint)layerIndex);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
