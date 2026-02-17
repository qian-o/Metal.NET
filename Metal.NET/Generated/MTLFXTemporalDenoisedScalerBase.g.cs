using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFXTemporalDenoisedScalerBase_Selectors
{
    internal static readonly Selector setColorTexture_ = Selector.Register("setColorTexture:");
    internal static readonly Selector setDepthTexture_ = Selector.Register("setDepthTexture:");
    internal static readonly Selector setMotionTexture_ = Selector.Register("setMotionTexture:");
    internal static readonly Selector setDiffuseAlbedoTexture_ = Selector.Register("setDiffuseAlbedoTexture:");
    internal static readonly Selector setSpecularAlbedoTexture_ = Selector.Register("setSpecularAlbedoTexture:");
    internal static readonly Selector setNormalTexture_ = Selector.Register("setNormalTexture:");
    internal static readonly Selector setRoughnessTexture_ = Selector.Register("setRoughnessTexture:");
    internal static readonly Selector setSpecularHitDistanceTexture_ = Selector.Register("setSpecularHitDistanceTexture:");
    internal static readonly Selector setDenoiseStrengthMaskTexture_ = Selector.Register("setDenoiseStrengthMaskTexture:");
    internal static readonly Selector setTransparencyOverlayTexture_ = Selector.Register("setTransparencyOverlayTexture:");
    internal static readonly Selector setOutputTexture_ = Selector.Register("setOutputTexture:");
    internal static readonly Selector setExposureTexture_ = Selector.Register("setExposureTexture:");
    internal static readonly Selector setPreExposure_ = Selector.Register("setPreExposure:");
    internal static readonly Selector setReactiveMaskTexture_ = Selector.Register("setReactiveMaskTexture:");
    internal static readonly Selector setJitterOffsetX_ = Selector.Register("setJitterOffsetX:");
    internal static readonly Selector setJitterOffsetY_ = Selector.Register("setJitterOffsetY:");
    internal static readonly Selector setMotionVectorScaleX_ = Selector.Register("setMotionVectorScaleX:");
    internal static readonly Selector setMotionVectorScaleY_ = Selector.Register("setMotionVectorScaleY:");
    internal static readonly Selector setShouldResetHistory_ = Selector.Register("setShouldResetHistory:");
    internal static readonly Selector setDepthReversed_ = Selector.Register("setDepthReversed:");
    internal static readonly Selector setWorldToViewMatrix_ = Selector.Register("setWorldToViewMatrix:");
    internal static readonly Selector setViewToClipMatrix_ = Selector.Register("setViewToClipMatrix:");
    internal static readonly Selector setFence_ = Selector.Register("setFence:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLFXTemporalDenoisedScalerBase
{
    public readonly nint NativePtr;

    public MTLFXTemporalDenoisedScalerBase(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFXTemporalDenoisedScalerBase o) => o.NativePtr;
    public static implicit operator MTLFXTemporalDenoisedScalerBase(nint ptr) => new MTLFXTemporalDenoisedScalerBase(ptr);

    public void SetColorTexture(MTLTexture colorTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setColorTexture_, colorTexture.NativePtr);
    }

    public void SetDepthTexture(MTLTexture depthTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setDepthTexture_, depthTexture.NativePtr);
    }

    public void SetMotionTexture(MTLTexture motionTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setMotionTexture_, motionTexture.NativePtr);
    }

    public void SetDiffuseAlbedoTexture(MTLTexture diffuseAlbedoTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setDiffuseAlbedoTexture_, diffuseAlbedoTexture.NativePtr);
    }

    public void SetSpecularAlbedoTexture(MTLTexture specularAlbedoTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setSpecularAlbedoTexture_, specularAlbedoTexture.NativePtr);
    }

    public void SetNormalTexture(MTLTexture normalTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setNormalTexture_, normalTexture.NativePtr);
    }

    public void SetRoughnessTexture(MTLTexture roughnessTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setRoughnessTexture_, roughnessTexture.NativePtr);
    }

    public void SetSpecularHitDistanceTexture(MTLTexture specularHitDistanceTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setSpecularHitDistanceTexture_, specularHitDistanceTexture.NativePtr);
    }

    public void SetDenoiseStrengthMaskTexture(MTLTexture denoiseStrengthMaskTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setDenoiseStrengthMaskTexture_, denoiseStrengthMaskTexture.NativePtr);
    }

    public void SetTransparencyOverlayTexture(MTLTexture transparencyOverlayTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setTransparencyOverlayTexture_, transparencyOverlayTexture.NativePtr);
    }

    public void SetOutputTexture(MTLTexture outputTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setOutputTexture_, outputTexture.NativePtr);
    }

    public void SetExposureTexture(MTLTexture exposureTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setExposureTexture_, exposureTexture.NativePtr);
    }

    public void SetPreExposure(float preExposure)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setPreExposure_, preExposure);
    }

    public void SetReactiveMaskTexture(MTLTexture reactiveMaskTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setReactiveMaskTexture_, reactiveMaskTexture.NativePtr);
    }

    public void SetJitterOffsetX(float jitterOffsetX)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setJitterOffsetX_, jitterOffsetX);
    }

    public void SetJitterOffsetY(float jitterOffsetY)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setJitterOffsetY_, jitterOffsetY);
    }

    public void SetMotionVectorScaleX(float motionVectorScaleX)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setMotionVectorScaleX_, motionVectorScaleX);
    }

    public void SetMotionVectorScaleY(float motionVectorScaleY)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setMotionVectorScaleY_, motionVectorScaleY);
    }

    public void SetShouldResetHistory(Bool8 shouldResetHistory)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setShouldResetHistory_, (nint)shouldResetHistory.Value);
    }

    public void SetDepthReversed(Bool8 depthReversed)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setDepthReversed_, (nint)depthReversed.Value);
    }

    public void SetWorldToViewMatrix(nint worldToViewMatrix)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setWorldToViewMatrix_, worldToViewMatrix);
    }

    public void SetViewToClipMatrix(nint viewToClipMatrix)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setViewToClipMatrix_, viewToClipMatrix);
    }

    public void SetFence(MTLFence fence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBase_Selectors.setFence_, fence.NativePtr);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
