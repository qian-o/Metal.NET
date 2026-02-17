namespace Metal.NET;

public class MTLFXTemporalDenoisedScalerBase : IDisposable
{
    public MTLFXTemporalDenoisedScalerBase(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetColorTexture, colorTexture.NativePtr);
    }

    public void SetDepthTexture(MTLTexture depthTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetDepthTexture, depthTexture.NativePtr);
    }

    public void SetMotionTexture(MTLTexture motionTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetMotionTexture, motionTexture.NativePtr);
    }

    public void SetDiffuseAlbedoTexture(MTLTexture diffuseAlbedoTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetDiffuseAlbedoTexture, diffuseAlbedoTexture.NativePtr);
    }

    public void SetSpecularAlbedoTexture(MTLTexture specularAlbedoTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetSpecularAlbedoTexture, specularAlbedoTexture.NativePtr);
    }

    public void SetNormalTexture(MTLTexture normalTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetNormalTexture, normalTexture.NativePtr);
    }

    public void SetRoughnessTexture(MTLTexture roughnessTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetRoughnessTexture, roughnessTexture.NativePtr);
    }

    public void SetSpecularHitDistanceTexture(MTLTexture specularHitDistanceTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetSpecularHitDistanceTexture, specularHitDistanceTexture.NativePtr);
    }

    public void SetDenoiseStrengthMaskTexture(MTLTexture denoiseStrengthMaskTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetDenoiseStrengthMaskTexture, denoiseStrengthMaskTexture.NativePtr);
    }

    public void SetTransparencyOverlayTexture(MTLTexture transparencyOverlayTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetTransparencyOverlayTexture, transparencyOverlayTexture.NativePtr);
    }

    public void SetOutputTexture(MTLTexture outputTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetOutputTexture, outputTexture.NativePtr);
    }

    public void SetExposureTexture(MTLTexture exposureTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetExposureTexture, exposureTexture.NativePtr);
    }

    public void SetPreExposure(float preExposure)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetPreExposure, preExposure);
    }

    public void SetReactiveMaskTexture(MTLTexture reactiveMaskTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetReactiveMaskTexture, reactiveMaskTexture.NativePtr);
    }

    public void SetJitterOffsetX(float jitterOffsetX)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetJitterOffsetX, jitterOffsetX);
    }

    public void SetJitterOffsetY(float jitterOffsetY)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetJitterOffsetY, jitterOffsetY);
    }

    public void SetMotionVectorScaleX(float motionVectorScaleX)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetMotionVectorScaleX, motionVectorScaleX);
    }

    public void SetMotionVectorScaleY(float motionVectorScaleY)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetMotionVectorScaleY, motionVectorScaleY);
    }

    public void SetShouldResetHistory(Bool8 shouldResetHistory)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetShouldResetHistory, (nint)shouldResetHistory.Value);
    }

    public void SetDepthReversed(Bool8 depthReversed)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetDepthReversed, (nint)depthReversed.Value);
    }

    public void SetWorldToViewMatrix(int worldToViewMatrix)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetWorldToViewMatrix, worldToViewMatrix);
    }

    public void SetViewToClipMatrix(int viewToClipMatrix)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetViewToClipMatrix, viewToClipMatrix);
    }

    public void SetFence(MTLFence fence)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetFence, fence.NativePtr);
    }

}

file class MTLFXTemporalDenoisedScalerBaseSelector
{
    public static readonly Selector SetColorTexture = Selector.Register("setColorTexture:");

    public static readonly Selector SetDepthTexture = Selector.Register("setDepthTexture:");

    public static readonly Selector SetMotionTexture = Selector.Register("setMotionTexture:");

    public static readonly Selector SetDiffuseAlbedoTexture = Selector.Register("setDiffuseAlbedoTexture:");

    public static readonly Selector SetSpecularAlbedoTexture = Selector.Register("setSpecularAlbedoTexture:");

    public static readonly Selector SetNormalTexture = Selector.Register("setNormalTexture:");

    public static readonly Selector SetRoughnessTexture = Selector.Register("setRoughnessTexture:");

    public static readonly Selector SetSpecularHitDistanceTexture = Selector.Register("setSpecularHitDistanceTexture:");

    public static readonly Selector SetDenoiseStrengthMaskTexture = Selector.Register("setDenoiseStrengthMaskTexture:");

    public static readonly Selector SetTransparencyOverlayTexture = Selector.Register("setTransparencyOverlayTexture:");

    public static readonly Selector SetOutputTexture = Selector.Register("setOutputTexture:");

    public static readonly Selector SetExposureTexture = Selector.Register("setExposureTexture:");

    public static readonly Selector SetPreExposure = Selector.Register("setPreExposure:");

    public static readonly Selector SetReactiveMaskTexture = Selector.Register("setReactiveMaskTexture:");

    public static readonly Selector SetJitterOffsetX = Selector.Register("setJitterOffsetX:");

    public static readonly Selector SetJitterOffsetY = Selector.Register("setJitterOffsetY:");

    public static readonly Selector SetMotionVectorScaleX = Selector.Register("setMotionVectorScaleX:");

    public static readonly Selector SetMotionVectorScaleY = Selector.Register("setMotionVectorScaleY:");

    public static readonly Selector SetShouldResetHistory = Selector.Register("setShouldResetHistory:");

    public static readonly Selector SetDepthReversed = Selector.Register("setDepthReversed:");

    public static readonly Selector SetWorldToViewMatrix = Selector.Register("setWorldToViewMatrix:");

    public static readonly Selector SetViewToClipMatrix = Selector.Register("setViewToClipMatrix:");

    public static readonly Selector SetFence = Selector.Register("setFence:");
}
