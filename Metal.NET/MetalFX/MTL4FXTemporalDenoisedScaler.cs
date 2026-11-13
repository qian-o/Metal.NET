namespace Metal.NET;

public readonly struct MTL4FXTemporalDenoisedScaler(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLFXTemporalDenoisedScalerBase(MTL4FXTemporalDenoisedScaler value) => new(value.NativePtr);

    public static implicit operator MTLFXFrameInterpolatableScaler(MTL4FXTemporalDenoisedScaler value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4FXTemporalDenoisedScaler value) => new(value.NativePtr);

    public MTL4FXTemporalDenoisedScaler Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.ColorTextureUsage);
    }

    public MTLTextureUsage DepthTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.DepthTextureUsage);
    }

    public MTLTextureUsage MotionTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.MotionTextureUsage);
    }

    public MTLTextureUsage ReactiveMaskTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.ReactiveMaskTextureUsage);
    }

    /// <summary>
    /// Deprecated: Use reactiveMaskTextureUsage instead
    /// </summary>
    [Obsolete("Use reactiveMaskTextureUsage instead")]
    public MTLTextureUsage ReactiveTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.ReactiveTextureUsage);
    }

    public MTLTextureUsage DiffuseAlbedoTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.DiffuseAlbedoTextureUsage);
    }

    public MTLTextureUsage SpecularAlbedoTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SpecularAlbedoTextureUsage);
    }

    public MTLTextureUsage NormalTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.NormalTextureUsage);
    }

    public MTLTextureUsage RoughnessTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.RoughnessTextureUsage);
    }

    public MTLTextureUsage SpecularHitDistanceTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SpecularHitDistanceTextureUsage);
    }

    public MTLTextureUsage DenoiseStrengthMaskTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.DenoiseStrengthMaskTextureUsage);
    }

    public MTLTextureUsage TransparencyOverlayTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.TransparencyOverlayTextureUsage);
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.OutputTextureUsage);
    }

    public MTLTexture ColorTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.ColorTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetColorTexture, value.NativePtr);
    }

    public MTLTexture DepthTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.DepthTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetDepthTexture, value.NativePtr);
    }

    public MTLTexture MotionTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.MotionTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetMotionTexture, value.NativePtr);
    }

    public MTLTexture DiffuseAlbedoTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.DiffuseAlbedoTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetDiffuseAlbedoTexture, value.NativePtr);
    }

    public MTLTexture SpecularAlbedoTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SpecularAlbedoTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetSpecularAlbedoTexture, value.NativePtr);
    }

    public MTLTexture NormalTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.NormalTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetNormalTexture, value.NativePtr);
    }

    public MTLTexture RoughnessTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.RoughnessTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetRoughnessTexture, value.NativePtr);
    }

    public MTLTexture SpecularHitDistanceTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SpecularHitDistanceTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetSpecularHitDistanceTexture, value.NativePtr);
    }

    public MTLTexture DenoiseStrengthMaskTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.DenoiseStrengthMaskTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetDenoiseStrengthMaskTexture, value.NativePtr);
    }

    public MTLTexture TransparencyOverlayTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.TransparencyOverlayTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetTransparencyOverlayTexture, value.NativePtr);
    }

    public MTLTexture OutputTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.OutputTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetOutputTexture, value.NativePtr);
    }

    public MTLTexture ExposureTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.ExposureTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetExposureTexture, value.NativePtr);
    }

    public float PreExposure
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4FXTemporalDenoisedScalerBindings.PreExposure);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetPreExposure, value);
    }

    public MTLTexture ReactiveMaskTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.ReactiveMaskTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetReactiveMaskTexture, value.NativePtr);
    }

    public float JitterOffsetX
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4FXTemporalDenoisedScalerBindings.JitterOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetJitterOffsetX, value);
    }

    public float JitterOffsetY
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4FXTemporalDenoisedScalerBindings.JitterOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetJitterOffsetY, value);
    }

    public float MotionVectorScaleX
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4FXTemporalDenoisedScalerBindings.MotionVectorScaleX);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetMotionVectorScaleX, value);
    }

    public float MotionVectorScaleY
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4FXTemporalDenoisedScalerBindings.MotionVectorScaleY);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetMotionVectorScaleY, value);
    }

    public Bool8 ShouldResetHistory
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4FXTemporalDenoisedScalerBindings.ShouldResetHistory);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetShouldResetHistory, value);
    }

    public Bool8 IsDepthReversed
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4FXTemporalDenoisedScalerBindings.IsDepthReversed);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetDepthReversed, value);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.ColorTextureFormat);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.DepthTextureFormat);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.MotionTextureFormat);
    }

    public MTLPixelFormat DiffuseAlbedoTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.DiffuseAlbedoTextureFormat);
    }

    public MTLPixelFormat SpecularAlbedoTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SpecularAlbedoTextureFormat);
    }

    public MTLPixelFormat NormalTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.NormalTextureFormat);
    }

    public MTLPixelFormat RoughnessTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.RoughnessTextureFormat);
    }

    public MTLPixelFormat SpecularHitDistanceTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SpecularHitDistanceTextureFormat);
    }

    public MTLPixelFormat DenoiseStrengthMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.DenoiseStrengthMaskTextureFormat);
    }

    public MTLPixelFormat TransparencyOverlayTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.TransparencyOverlayTextureFormat);
    }

    public MTLPixelFormat ReactiveMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.ReactiveMaskTextureFormat);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXTemporalDenoisedScalerBindings.OutputTextureFormat);
    }

    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.InputWidth);
    }

    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.InputHeight);
    }

    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.OutputWidth);
    }

    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.OutputHeight);
    }

    public float InputContentMinScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4FXTemporalDenoisedScalerBindings.InputContentMinScale);
    }

    public float InputContentMaxScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4FXTemporalDenoisedScalerBindings.InputContentMaxScale);
    }

    public SimdFloat4x4 WorldToViewMatrix
    {
        get => ObjectiveC.MsgSendSimdFloat4x4(NativePtr, MTL4FXTemporalDenoisedScalerBindings.WorldToViewMatrix);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetWorldToViewMatrix, value);
    }

    public SimdFloat4x4 ViewToClipMatrix
    {
        get => ObjectiveC.MsgSendSimdFloat4x4(NativePtr, MTL4FXTemporalDenoisedScalerBindings.ViewToClipMatrix);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetViewToClipMatrix, value);
    }

    public MTLFence Fence
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXTemporalDenoisedScalerBindings.Fence));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.SetFence, value.NativePtr);
    }

    public void Encode(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTL4FXTemporalDenoisedScalerBindings
{
    public static readonly Selector ColorTexture = "colorTexture";

    public static readonly Selector ColorTextureFormat = "colorTextureFormat";

    public static readonly Selector ColorTextureUsage = "colorTextureUsage";

    public static readonly Selector DenoiseStrengthMaskTexture = "denoiseStrengthMaskTexture";

    public static readonly Selector DenoiseStrengthMaskTextureFormat = "denoiseStrengthMaskTextureFormat";

    public static readonly Selector DenoiseStrengthMaskTextureUsage = "denoiseStrengthMaskTextureUsage";

    public static readonly Selector DepthTexture = "depthTexture";

    public static readonly Selector DepthTextureFormat = "depthTextureFormat";

    public static readonly Selector DepthTextureUsage = "depthTextureUsage";

    public static readonly Selector DiffuseAlbedoTexture = "diffuseAlbedoTexture";

    public static readonly Selector DiffuseAlbedoTextureFormat = "diffuseAlbedoTextureFormat";

    public static readonly Selector DiffuseAlbedoTextureUsage = "diffuseAlbedoTextureUsage";

    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";

    public static readonly Selector ExposureTexture = "exposureTexture";

    public static readonly Selector Fence = "fence";

    public static readonly Selector InputContentMaxScale = "inputContentMaxScale";

    public static readonly Selector InputContentMinScale = "inputContentMinScale";

    public static readonly Selector InputHeight = "inputHeight";

    public static readonly Selector InputWidth = "inputWidth";

    public static readonly Selector IsDepthReversed = "isDepthReversed";

    public static readonly Selector JitterOffsetX = "jitterOffsetX";

    public static readonly Selector JitterOffsetY = "jitterOffsetY";

    public static readonly Selector MotionTexture = "motionTexture";

    public static readonly Selector MotionTextureFormat = "motionTextureFormat";

    public static readonly Selector MotionTextureUsage = "motionTextureUsage";

    public static readonly Selector MotionVectorScaleX = "motionVectorScaleX";

    public static readonly Selector MotionVectorScaleY = "motionVectorScaleY";

    public static readonly Selector NormalTexture = "normalTexture";

    public static readonly Selector NormalTextureFormat = "normalTextureFormat";

    public static readonly Selector NormalTextureUsage = "normalTextureUsage";

    public static readonly Selector OutputHeight = "outputHeight";

    public static readonly Selector OutputTexture = "outputTexture";

    public static readonly Selector OutputTextureFormat = "outputTextureFormat";

    public static readonly Selector OutputTextureUsage = "outputTextureUsage";

    public static readonly Selector OutputWidth = "outputWidth";

    public static readonly Selector PreExposure = "preExposure";

    public static readonly Selector ReactiveMaskTexture = "reactiveMaskTexture";

    public static readonly Selector ReactiveMaskTextureFormat = "reactiveMaskTextureFormat";

    public static readonly Selector ReactiveMaskTextureUsage = "reactiveMaskTextureUsage";

    public static readonly Selector ReactiveTextureUsage = "reactiveTextureUsage";

    public static readonly Selector RoughnessTexture = "roughnessTexture";

    public static readonly Selector RoughnessTextureFormat = "roughnessTextureFormat";

    public static readonly Selector RoughnessTextureUsage = "roughnessTextureUsage";

    public static readonly Selector SetColorTexture = "setColorTexture:";

    public static readonly Selector SetDenoiseStrengthMaskTexture = "setDenoiseStrengthMaskTexture:";

    public static readonly Selector SetDepthReversed = "setDepthReversed:";

    public static readonly Selector SetDepthTexture = "setDepthTexture:";

    public static readonly Selector SetDiffuseAlbedoTexture = "setDiffuseAlbedoTexture:";

    public static readonly Selector SetExposureTexture = "setExposureTexture:";

    public static readonly Selector SetFence = "setFence:";

    public static readonly Selector SetJitterOffsetX = "setJitterOffsetX:";

    public static readonly Selector SetJitterOffsetY = "setJitterOffsetY:";

    public static readonly Selector SetMotionTexture = "setMotionTexture:";

    public static readonly Selector SetMotionVectorScaleX = "setMotionVectorScaleX:";

    public static readonly Selector SetMotionVectorScaleY = "setMotionVectorScaleY:";

    public static readonly Selector SetNormalTexture = "setNormalTexture:";

    public static readonly Selector SetOutputTexture = "setOutputTexture:";

    public static readonly Selector SetPreExposure = "setPreExposure:";

    public static readonly Selector SetReactiveMaskTexture = "setReactiveMaskTexture:";

    public static readonly Selector SetRoughnessTexture = "setRoughnessTexture:";

    public static readonly Selector SetShouldResetHistory = "setShouldResetHistory:";

    public static readonly Selector SetSpecularAlbedoTexture = "setSpecularAlbedoTexture:";

    public static readonly Selector SetSpecularHitDistanceTexture = "setSpecularHitDistanceTexture:";

    public static readonly Selector SetTransparencyOverlayTexture = "setTransparencyOverlayTexture:";

    public static readonly Selector SetViewToClipMatrix = "setViewToClipMatrix:";

    public static readonly Selector SetWorldToViewMatrix = "setWorldToViewMatrix:";

    public static readonly Selector ShouldResetHistory = "shouldResetHistory";

    public static readonly Selector SpecularAlbedoTexture = "specularAlbedoTexture";

    public static readonly Selector SpecularAlbedoTextureFormat = "specularAlbedoTextureFormat";

    public static readonly Selector SpecularAlbedoTextureUsage = "specularAlbedoTextureUsage";

    public static readonly Selector SpecularHitDistanceTexture = "specularHitDistanceTexture";

    public static readonly Selector SpecularHitDistanceTextureFormat = "specularHitDistanceTextureFormat";

    public static readonly Selector SpecularHitDistanceTextureUsage = "specularHitDistanceTextureUsage";

    public static readonly Selector TransparencyOverlayTexture = "transparencyOverlayTexture";

    public static readonly Selector TransparencyOverlayTextureFormat = "transparencyOverlayTextureFormat";

    public static readonly Selector TransparencyOverlayTextureUsage = "transparencyOverlayTextureUsage";

    public static readonly Selector ViewToClipMatrix = "viewToClipMatrix";

    public static readonly Selector WorldToViewMatrix = "worldToViewMatrix";
}
