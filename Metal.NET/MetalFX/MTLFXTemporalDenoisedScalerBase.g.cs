namespace Metal.NET;

file class MTLFXTemporalDenoisedScalerBaseSelector
{
    public static readonly Selector SetColorTexture_ = Selector.Register("setColorTexture:");
    public static readonly Selector SetDepthTexture_ = Selector.Register("setDepthTexture:");
    public static readonly Selector SetMotionTexture_ = Selector.Register("setMotionTexture:");
    public static readonly Selector SetDiffuseAlbedoTexture_ = Selector.Register("setDiffuseAlbedoTexture:");
    public static readonly Selector SetSpecularAlbedoTexture_ = Selector.Register("setSpecularAlbedoTexture:");
    public static readonly Selector SetNormalTexture_ = Selector.Register("setNormalTexture:");
    public static readonly Selector SetRoughnessTexture_ = Selector.Register("setRoughnessTexture:");
    public static readonly Selector SetSpecularHitDistanceTexture_ = Selector.Register("setSpecularHitDistanceTexture:");
    public static readonly Selector SetDenoiseStrengthMaskTexture_ = Selector.Register("setDenoiseStrengthMaskTexture:");
    public static readonly Selector SetTransparencyOverlayTexture_ = Selector.Register("setTransparencyOverlayTexture:");
    public static readonly Selector SetOutputTexture_ = Selector.Register("setOutputTexture:");
    public static readonly Selector SetExposureTexture_ = Selector.Register("setExposureTexture:");
    public static readonly Selector SetPreExposure_ = Selector.Register("setPreExposure:");
    public static readonly Selector SetReactiveMaskTexture_ = Selector.Register("setReactiveMaskTexture:");
    public static readonly Selector SetJitterOffsetX_ = Selector.Register("setJitterOffsetX:");
    public static readonly Selector SetJitterOffsetY_ = Selector.Register("setJitterOffsetY:");
    public static readonly Selector SetMotionVectorScaleX_ = Selector.Register("setMotionVectorScaleX:");
    public static readonly Selector SetMotionVectorScaleY_ = Selector.Register("setMotionVectorScaleY:");
    public static readonly Selector SetShouldResetHistory_ = Selector.Register("setShouldResetHistory:");
    public static readonly Selector SetDepthReversed_ = Selector.Register("setDepthReversed:");
    public static readonly Selector SetWorldToViewMatrix_ = Selector.Register("setWorldToViewMatrix:");
    public static readonly Selector SetViewToClipMatrix_ = Selector.Register("setViewToClipMatrix:");
    public static readonly Selector SetFence_ = Selector.Register("setFence:");
}

public class MTLFXTemporalDenoisedScalerBase : IDisposable
{
    public MTLFXTemporalDenoisedScalerBase(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLFXTemporalDenoisedScalerBase()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFXTemporalDenoisedScalerBase value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXTemporalDenoisedScalerBase(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    public void SetColorTexture(MTLTexture colorTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetColorTexture_, colorTexture.NativePtr);
    }

    public void SetDepthTexture(MTLTexture depthTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetDepthTexture_, depthTexture.NativePtr);
    }

    public void SetMotionTexture(MTLTexture motionTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetMotionTexture_, motionTexture.NativePtr);
    }

    public void SetDiffuseAlbedoTexture(MTLTexture diffuseAlbedoTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetDiffuseAlbedoTexture_, diffuseAlbedoTexture.NativePtr);
    }

    public void SetSpecularAlbedoTexture(MTLTexture specularAlbedoTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetSpecularAlbedoTexture_, specularAlbedoTexture.NativePtr);
    }

    public void SetNormalTexture(MTLTexture normalTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetNormalTexture_, normalTexture.NativePtr);
    }

    public void SetRoughnessTexture(MTLTexture roughnessTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetRoughnessTexture_, roughnessTexture.NativePtr);
    }

    public void SetSpecularHitDistanceTexture(MTLTexture specularHitDistanceTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetSpecularHitDistanceTexture_, specularHitDistanceTexture.NativePtr);
    }

    public void SetDenoiseStrengthMaskTexture(MTLTexture denoiseStrengthMaskTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetDenoiseStrengthMaskTexture_, denoiseStrengthMaskTexture.NativePtr);
    }

    public void SetTransparencyOverlayTexture(MTLTexture transparencyOverlayTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetTransparencyOverlayTexture_, transparencyOverlayTexture.NativePtr);
    }

    public void SetOutputTexture(MTLTexture outputTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetOutputTexture_, outputTexture.NativePtr);
    }

    public void SetExposureTexture(MTLTexture exposureTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetExposureTexture_, exposureTexture.NativePtr);
    }

    public void SetPreExposure(float preExposure)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetPreExposure_, preExposure);
    }

    public void SetReactiveMaskTexture(MTLTexture reactiveMaskTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetReactiveMaskTexture_, reactiveMaskTexture.NativePtr);
    }

    public void SetJitterOffsetX(float jitterOffsetX)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetJitterOffsetX_, jitterOffsetX);
    }

    public void SetJitterOffsetY(float jitterOffsetY)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetJitterOffsetY_, jitterOffsetY);
    }

    public void SetMotionVectorScaleX(float motionVectorScaleX)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetMotionVectorScaleX_, motionVectorScaleX);
    }

    public void SetMotionVectorScaleY(float motionVectorScaleY)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetMotionVectorScaleY_, motionVectorScaleY);
    }

    public void SetShouldResetHistory(Bool8 shouldResetHistory)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetShouldResetHistory_, (nint)shouldResetHistory.Value);
    }

    public void SetDepthReversed(Bool8 depthReversed)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetDepthReversed_, (nint)depthReversed.Value);
    }

    public void SetWorldToViewMatrix(nint worldToViewMatrix)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetWorldToViewMatrix_, worldToViewMatrix);
    }

    public void SetViewToClipMatrix(nint viewToClipMatrix)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetViewToClipMatrix_, viewToClipMatrix);
    }

    public void SetFence(MTLFence fence)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetFence_, fence.NativePtr);
    }

}
