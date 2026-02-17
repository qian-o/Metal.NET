using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFXFrameInterpolator_Selectors
{
    internal static readonly Selector encodeToCommandBuffer_ = Selector.Register("encodeToCommandBuffer:");
}

public class MTLFXFrameInterpolator : IDisposable
{
    public nint NativePtr { get; }

    public MTLFXFrameInterpolator(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFXFrameInterpolator o) => o.NativePtr;
    public static implicit operator MTLFXFrameInterpolator(nint ptr) => new MTLFXFrameInterpolator(ptr);

    ~MTLFXFrameInterpolator() => Release();

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

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolator_Selectors.encodeToCommandBuffer_, commandBuffer.NativePtr);
    }

}
