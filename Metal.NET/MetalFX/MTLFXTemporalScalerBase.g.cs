using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFXTemporalScalerBase_Selectors
{
    internal static readonly Selector setInputContentWidth_ = Selector.Register("setInputContentWidth:");
    internal static readonly Selector setInputContentHeight_ = Selector.Register("setInputContentHeight:");
    internal static readonly Selector setColorTexture_ = Selector.Register("setColorTexture:");
    internal static readonly Selector setDepthTexture_ = Selector.Register("setDepthTexture:");
    internal static readonly Selector setMotionTexture_ = Selector.Register("setMotionTexture:");
    internal static readonly Selector setOutputTexture_ = Selector.Register("setOutputTexture:");
    internal static readonly Selector setExposureTexture_ = Selector.Register("setExposureTexture:");
    internal static readonly Selector setPreExposure_ = Selector.Register("setPreExposure:");
    internal static readonly Selector setJitterOffsetX_ = Selector.Register("setJitterOffsetX:");
    internal static readonly Selector setJitterOffsetY_ = Selector.Register("setJitterOffsetY:");
    internal static readonly Selector setMotionVectorScaleX_ = Selector.Register("setMotionVectorScaleX:");
    internal static readonly Selector setMotionVectorScaleY_ = Selector.Register("setMotionVectorScaleY:");
    internal static readonly Selector setReactiveMaskTexture_ = Selector.Register("setReactiveMaskTexture:");
    internal static readonly Selector setReset_ = Selector.Register("setReset:");
    internal static readonly Selector setDepthReversed_ = Selector.Register("setDepthReversed:");
    internal static readonly Selector setFence_ = Selector.Register("setFence:");
}

public class MTLFXTemporalScalerBase : IDisposable
{
    public nint NativePtr { get; }

    public MTLFXTemporalScalerBase(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFXTemporalScalerBase o) => o.NativePtr;
    public static implicit operator MTLFXTemporalScalerBase(nint ptr) => new MTLFXTemporalScalerBase(ptr);

    ~MTLFXTemporalScalerBase() => Release();

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

    public void SetInputContentWidth(nuint width)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBase_Selectors.setInputContentWidth_, (nint)width);
    }

    public void SetInputContentHeight(nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBase_Selectors.setInputContentHeight_, (nint)height);
    }

    public void SetColorTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBase_Selectors.setColorTexture_, pTexture.NativePtr);
    }

    public void SetDepthTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBase_Selectors.setDepthTexture_, pTexture.NativePtr);
    }

    public void SetMotionTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBase_Selectors.setMotionTexture_, pTexture.NativePtr);
    }

    public void SetOutputTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBase_Selectors.setOutputTexture_, pTexture.NativePtr);
    }

    public void SetExposureTexture(MTLTexture pTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBase_Selectors.setExposureTexture_, pTexture.NativePtr);
    }

    public void SetPreExposure(float preExposure)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBase_Selectors.setPreExposure_, preExposure);
    }

    public void SetJitterOffsetX(float offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBase_Selectors.setJitterOffsetX_, offset);
    }

    public void SetJitterOffsetY(float offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBase_Selectors.setJitterOffsetY_, offset);
    }

    public void SetMotionVectorScaleX(float scale)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBase_Selectors.setMotionVectorScaleX_, scale);
    }

    public void SetMotionVectorScaleY(float scale)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBase_Selectors.setMotionVectorScaleY_, scale);
    }

    public void SetReactiveMaskTexture(MTLTexture reactiveMaskTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBase_Selectors.setReactiveMaskTexture_, reactiveMaskTexture.NativePtr);
    }

    public void SetReset(Bool8 reset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBase_Selectors.setReset_, (nint)reset.Value);
    }

    public void SetDepthReversed(Bool8 depthReversed)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBase_Selectors.setDepthReversed_, (nint)depthReversed.Value);
    }

    public void SetFence(MTLFence pFence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerBase_Selectors.setFence_, pFence.NativePtr);
    }

}
