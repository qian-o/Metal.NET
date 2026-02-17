using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFXSpatialScaler_Selectors
{
    internal static readonly Selector encodeToCommandBuffer_ = Selector.Register("encodeToCommandBuffer:");
}

public class MTLFXSpatialScaler : IDisposable
{
    public nint NativePtr { get; }

    public MTLFXSpatialScaler(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFXSpatialScaler o) => o.NativePtr;
    public static implicit operator MTLFXSpatialScaler(nint ptr) => new MTLFXSpatialScaler(ptr);

    ~MTLFXSpatialScaler() => Release();

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

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScaler_Selectors.encodeToCommandBuffer_, pCommandBuffer.NativePtr);
    }

}
