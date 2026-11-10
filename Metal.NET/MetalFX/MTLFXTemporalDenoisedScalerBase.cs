namespace Metal.NET;

public readonly struct MTLFXTemporalDenoisedScalerBase(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLFXFrameInterpolatableScaler(MTLFXTemporalDenoisedScalerBase value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLFXTemporalDenoisedScalerBase value) => new(value.NativePtr);

    public MTLFXTemporalDenoisedScalerBase Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ColorTextureUsage);
    }

    public MTLTextureUsage DepthTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DepthTextureUsage);
    }

    public MTLTextureUsage MotionTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.MotionTextureUsage);
    }

    public MTLTextureUsage ReactiveMaskTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ReactiveMaskTextureUsage);
    }

    /// <summary>
    /// Deprecated: Use reactiveMaskTextureUsage instead
    /// </summary>
    [Obsolete("Use reactiveMaskTextureUsage instead")]
    public MTLTextureUsage ReactiveTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ReactiveTextureUsage);
    }

    public MTLTextureUsage DiffuseAlbedoTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DiffuseAlbedoTextureUsage);
    }

    public MTLTextureUsage SpecularAlbedoTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularAlbedoTextureUsage);
    }

    public MTLTextureUsage NormalTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.NormalTextureUsage);
    }

    public MTLTextureUsage RoughnessTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.RoughnessTextureUsage);
    }

    public MTLTextureUsage SpecularHitDistanceTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularHitDistanceTextureUsage);
    }

    public MTLTextureUsage DenoiseStrengthMaskTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DenoiseStrengthMaskTextureUsage);
    }

    public MTLTextureUsage TransparencyOverlayTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.TransparencyOverlayTextureUsage);
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.OutputTextureUsage);
    }

    public MTLTexture ColorTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ColorTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetColorTexture, value.NativePtr);
    }

    public MTLTexture DepthTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DepthTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetDepthTexture, value.NativePtr);
    }

    public MTLTexture MotionTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.MotionTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetMotionTexture, value.NativePtr);
    }

    public MTLTexture DiffuseAlbedoTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DiffuseAlbedoTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetDiffuseAlbedoTexture, value.NativePtr);
    }

    public MTLTexture SpecularAlbedoTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularAlbedoTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetSpecularAlbedoTexture, value.NativePtr);
    }

    public MTLTexture NormalTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.NormalTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetNormalTexture, value.NativePtr);
    }

    public MTLTexture RoughnessTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.RoughnessTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetRoughnessTexture, value.NativePtr);
    }

    public MTLTexture SpecularHitDistanceTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularHitDistanceTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetSpecularHitDistanceTexture, value.NativePtr);
    }

    public MTLTexture DenoiseStrengthMaskTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DenoiseStrengthMaskTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetDenoiseStrengthMaskTexture, value.NativePtr);
    }

    public MTLTexture TransparencyOverlayTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.TransparencyOverlayTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetTransparencyOverlayTexture, value.NativePtr);
    }

    public MTLTexture OutputTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.OutputTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetOutputTexture, value.NativePtr);
    }

    public MTLTexture ExposureTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ExposureTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetExposureTexture, value.NativePtr);
    }

    public float PreExposure
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.PreExposure);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetPreExposure, value);
    }

    public MTLTexture ReactiveMaskTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ReactiveMaskTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetReactiveMaskTexture, value.NativePtr);
    }

    public float JitterOffsetX
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.JitterOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetJitterOffsetX, value);
    }

    public float JitterOffsetY
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.JitterOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetJitterOffsetY, value);
    }

    public float MotionVectorScaleX
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.MotionVectorScaleX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetMotionVectorScaleX, value);
    }

    public float MotionVectorScaleY
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.MotionVectorScaleY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetMotionVectorScaleY, value);
    }

    public Bool8 ShouldResetHistory
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ShouldResetHistory);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetShouldResetHistory, value);
    }

    public Bool8 IsDepthReversed
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.IsDepthReversed);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetDepthReversed, value);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ColorTextureFormat);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DepthTextureFormat);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.MotionTextureFormat);
    }

    public MTLPixelFormat DiffuseAlbedoTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DiffuseAlbedoTextureFormat);
    }

    public MTLPixelFormat SpecularAlbedoTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularAlbedoTextureFormat);
    }

    public MTLPixelFormat NormalTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.NormalTextureFormat);
    }

    public MTLPixelFormat RoughnessTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.RoughnessTextureFormat);
    }

    public MTLPixelFormat SpecularHitDistanceTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularHitDistanceTextureFormat);
    }

    public MTLPixelFormat DenoiseStrengthMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DenoiseStrengthMaskTextureFormat);
    }

    public MTLPixelFormat TransparencyOverlayTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.TransparencyOverlayTextureFormat);
    }

    public MTLPixelFormat ReactiveMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ReactiveMaskTextureFormat);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.OutputTextureFormat);
    }

    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.InputWidth);
    }

    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.InputHeight);
    }

    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.OutputWidth);
    }

    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.OutputHeight);
    }

    public float InputContentMinScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.InputContentMinScale);
    }

    public float InputContentMaxScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.InputContentMaxScale);
    }

    public SimdFloat4x4 WorldToViewMatrix
    {
        get => ObjectiveC.MsgSendSimdFloat4x4(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.WorldToViewMatrix);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetWorldToViewMatrix, value);
    }

    public SimdFloat4x4 ViewToClipMatrix
    {
        get => ObjectiveC.MsgSendSimdFloat4x4(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ViewToClipMatrix);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetViewToClipMatrix, value);
    }

    public MTLFence Fence
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.Fence));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetFence, value.NativePtr);
    }
}

file static class MTLFXTemporalDenoisedScalerBaseBindings
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
