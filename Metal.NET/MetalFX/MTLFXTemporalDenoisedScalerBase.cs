namespace Metal.NET;

public class MTLFXTemporalDenoisedScalerBase(nint nativePtr) : MTLFXFrameInterpolatableScaler(nativePtr), INativeObject<MTLFXTemporalDenoisedScalerBase>
{
    public static new MTLFXTemporalDenoisedScalerBase Create(nint nativePtr) => new(nativePtr);

    public MTLTexture ColorTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.ColorTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetColorTexture, value);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ColorTextureFormat);
    }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ColorTextureUsage);
    }

    public MTLTexture DenoiseStrengthMaskTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.DenoiseStrengthMaskTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetDenoiseStrengthMaskTexture, value);
    }

    public MTLPixelFormat DenoiseStrengthMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DenoiseStrengthMaskTextureFormat);
    }

    public MTLTextureUsage DenoiseStrengthMaskTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DenoiseStrengthMaskTextureUsage);
    }

    public MTLTexture DepthTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.DepthTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetDepthTexture, value);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DepthTextureFormat);
    }

    public MTLTextureUsage DepthTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DepthTextureUsage);
    }

    public MTLTexture DiffuseAlbedoTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.DiffuseAlbedoTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetDiffuseAlbedoTexture, value);
    }

    public MTLPixelFormat DiffuseAlbedoTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DiffuseAlbedoTextureFormat);
    }

    public MTLTextureUsage DiffuseAlbedoTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DiffuseAlbedoTextureUsage);
    }

    public MTLTexture ExposureTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.ExposureTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetExposureTexture, value);
    }

    public MTLFence Fence
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.Fence);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetFence, value);
    }

    public float InputContentMaxScale
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.InputContentMaxScale);
    }

    public float InputContentMinScale
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.InputContentMinScale);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.InputHeight);
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.InputWidth);
    }

    public bool IsDepthReversed
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.IsDepthReversed);
    }

    public float JitterOffsetX
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.JitterOffsetX);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetJitterOffsetX, value);
    }

    public float JitterOffsetY
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.JitterOffsetY);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetJitterOffsetY, value);
    }

    public MTLTexture MotionTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.MotionTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetMotionTexture, value);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.MotionTextureFormat);
    }

    public MTLTextureUsage MotionTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.MotionTextureUsage);
    }

    public float MotionVectorScaleX
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.MotionVectorScaleX);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetMotionVectorScaleX, value);
    }

    public float MotionVectorScaleY
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.MotionVectorScaleY);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetMotionVectorScaleY, value);
    }

    public MTLTexture NormalTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.NormalTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetNormalTexture, value);
    }

    public MTLPixelFormat NormalTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.NormalTextureFormat);
    }

    public MTLTextureUsage NormalTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.NormalTextureUsage);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.OutputHeight);
    }

    public MTLTexture OutputTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.OutputTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetOutputTexture, value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.OutputTextureFormat);
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.OutputTextureUsage);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.OutputWidth);
    }

    public float PreExposure
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.PreExposure);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetPreExposure, value);
    }

    public MTLTexture ReactiveMaskTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.ReactiveMaskTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetReactiveMaskTexture, value);
    }

    public MTLPixelFormat ReactiveMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ReactiveMaskTextureFormat);
    }

    public MTLTextureUsage ReactiveTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ReactiveTextureUsage);
    }

    public MTLTexture RoughnessTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.RoughnessTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetRoughnessTexture, value);
    }

    public MTLPixelFormat RoughnessTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.RoughnessTextureFormat);
    }

    public MTLTextureUsage RoughnessTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.RoughnessTextureUsage);
    }

    public bool ShouldResetHistory
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ShouldResetHistory);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetShouldResetHistory, (Bool8)value);
    }

    public MTLTexture SpecularAlbedoTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SpecularAlbedoTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetSpecularAlbedoTexture, value);
    }

    public MTLPixelFormat SpecularAlbedoTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularAlbedoTextureFormat);
    }

    public MTLTextureUsage SpecularAlbedoTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularAlbedoTextureUsage);
    }

    public MTLTexture SpecularHitDistanceTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SpecularHitDistanceTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetSpecularHitDistanceTexture, value);
    }

    public MTLPixelFormat SpecularHitDistanceTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularHitDistanceTextureFormat);
    }

    public MTLTextureUsage SpecularHitDistanceTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularHitDistanceTextureUsage);
    }

    public MTLTexture TransparencyOverlayTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.TransparencyOverlayTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetTransparencyOverlayTexture, value);
    }

    public MTLPixelFormat TransparencyOverlayTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.TransparencyOverlayTextureFormat);
    }

    public MTLTextureUsage TransparencyOverlayTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.TransparencyOverlayTextureUsage);
    }

    public SimdFloat4x4 ViewToClipMatrix
    {
        get => ObjectiveCRuntime.MsgSendSimdFloat4x4(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ViewToClipMatrix);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetViewToClipMatrix, value);
    }

    public SimdFloat4x4 WorldToViewMatrix
    {
        get => ObjectiveCRuntime.MsgSendSimdFloat4x4(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.WorldToViewMatrix);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetWorldToViewMatrix, value);
    }

    public void SetDepthReversed(bool depthReversed)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetDepthReversed, (Bool8)depthReversed);
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
