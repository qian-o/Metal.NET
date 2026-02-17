using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRasterizationRateLayerArray_Selectors
{
    internal static readonly Selector object_ = Selector.Register("object:");
    internal static readonly Selector setObject_layerIndex_ = Selector.Register("setObject:layerIndex:");
}

public class MTLRasterizationRateLayerArray : IDisposable
{
    public nint NativePtr { get; }

    public MTLRasterizationRateLayerArray(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRasterizationRateLayerArray o) => o.NativePtr;
    public static implicit operator MTLRasterizationRateLayerArray(nint ptr) => new MTLRasterizationRateLayerArray(ptr);

    ~MTLRasterizationRateLayerArray() => Release();

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

    public MTLRasterizationRateLayerDescriptor Object(nuint layerIndex)
    {
        var __r = new MTLRasterizationRateLayerDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRasterizationRateLayerArray_Selectors.object_, (nint)layerIndex));
        return __r;
    }

    public void SetObject(MTLRasterizationRateLayerDescriptor layer, nuint layerIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateLayerArray_Selectors.setObject_layerIndex_, layer.NativePtr, (nint)layerIndex);
    }

}
