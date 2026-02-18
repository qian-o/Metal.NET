namespace Metal.NET;

public class MTLFXTemporalDenoisedScalerBase(nint nativePtr) : MTLFXFrameInterpolatableScaler(nativePtr)
{
    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.ColorTextureUsage));
    }

    public MTLTextureUsage DepthTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.DepthTextureUsage));
    }

    public MTLTextureUsage MotionTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.MotionTextureUsage));
    }

    public MTLTextureUsage ReactiveTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.ReactiveTextureUsage));
    }

    public MTLTextureUsage DiffuseAlbedoTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.DiffuseAlbedoTextureUsage));
    }

    public MTLTextureUsage SpecularAlbedoTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SpecularAlbedoTextureUsage));
    }

    public MTLTextureUsage NormalTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.NormalTextureUsage));
    }

    public MTLTextureUsage RoughnessTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.RoughnessTextureUsage));
    }

    public MTLTextureUsage SpecularHitDistanceTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SpecularHitDistanceTextureUsage));
    }

    public MTLTextureUsage DenoiseStrengthMaskTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.DenoiseStrengthMaskTextureUsage));
    }

    public MTLTextureUsage TransparencyOverlayTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.TransparencyOverlayTextureUsage));
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.OutputTextureUsage));
    }

    public MTLTexture ColorTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.ColorTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetColorTexture, value.NativePtr);
    }

    public MTLTexture DepthTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.DepthTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetDepthTexture, value.NativePtr);
    }

    public MTLTexture MotionTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.MotionTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetMotionTexture, value.NativePtr);
    }

    public MTLTexture DiffuseAlbedoTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.DiffuseAlbedoTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetDiffuseAlbedoTexture, value.NativePtr);
    }

    public MTLTexture SpecularAlbedoTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SpecularAlbedoTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetSpecularAlbedoTexture, value.NativePtr);
    }

    public MTLTexture NormalTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.NormalTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetNormalTexture, value.NativePtr);
    }

    public MTLTexture RoughnessTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.RoughnessTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetRoughnessTexture, value.NativePtr);
    }

    public MTLTexture SpecularHitDistanceTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SpecularHitDistanceTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetSpecularHitDistanceTexture, value.NativePtr);
    }

    public MTLTexture DenoiseStrengthMaskTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.DenoiseStrengthMaskTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetDenoiseStrengthMaskTexture, value.NativePtr);
    }

    public MTLTexture TransparencyOverlayTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.TransparencyOverlayTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetTransparencyOverlayTexture, value.NativePtr);
    }

    public MTLTexture OutputTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.OutputTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetOutputTexture, value.NativePtr);
    }

    public MTLTexture ExposureTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.ExposureTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetExposureTexture, value.NativePtr);
    }

    public float PreExposure
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.PreExposure);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetPreExposure, value);
    }

    public MTLTexture ReactiveMaskTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.ReactiveMaskTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetReactiveMaskTexture, value.NativePtr);
    }

    public float JitterOffsetX
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.JitterOffsetX);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetJitterOffsetX, value);
    }

    public float JitterOffsetY
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.JitterOffsetY);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetJitterOffsetY, value);
    }

    public float MotionVectorScaleX
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.MotionVectorScaleX);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetMotionVectorScaleX, value);
    }

    public float MotionVectorScaleY
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.MotionVectorScaleY);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetMotionVectorScaleY, value);
    }

    public Bool8 ShouldResetHistory
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.ShouldResetHistory);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetShouldResetHistory, value);
    }

    public Bool8 IsDepthReversed
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.IsDepthReversed);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.ColorTextureFormat));
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.DepthTextureFormat));
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.MotionTextureFormat));
    }

    public MTLPixelFormat DiffuseAlbedoTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.DiffuseAlbedoTextureFormat));
    }

    public MTLPixelFormat SpecularAlbedoTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SpecularAlbedoTextureFormat));
    }

    public MTLPixelFormat NormalTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.NormalTextureFormat));
    }

    public MTLPixelFormat RoughnessTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.RoughnessTextureFormat));
    }

    public MTLPixelFormat SpecularHitDistanceTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SpecularHitDistanceTextureFormat));
    }

    public MTLPixelFormat DenoiseStrengthMaskTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.DenoiseStrengthMaskTextureFormat));
    }

    public MTLPixelFormat TransparencyOverlayTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.TransparencyOverlayTextureFormat));
    }

    public MTLPixelFormat ReactiveMaskTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.ReactiveMaskTextureFormat));
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.OutputTextureFormat));
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.InputWidth);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.InputHeight);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.OutputWidth);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.OutputHeight);
    }

    public float InputContentMinScale
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.InputContentMinScale);
    }

    public float InputContentMaxScale
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.InputContentMaxScale);
    }

    public nint WorldToViewMatrix
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.WorldToViewMatrix);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetWorldToViewMatrix, value);
    }

    public nint ViewToClipMatrix
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.ViewToClipMatrix);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetViewToClipMatrix, value);
    }

    public MTLFence Fence
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.Fence));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetFence, value.NativePtr);
    }

    public static implicit operator nint(MTLFXTemporalDenoisedScalerBase value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXTemporalDenoisedScalerBase(nint value)
    {
        return new(value);
    }

    public void SetDepthReversed(Bool8 depthReversed)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseSelector.SetDepthReversed, depthReversed);
    }
}

file class MTLFXTemporalDenoisedScalerBaseSelector
{
    public static readonly Selector ColorTextureUsage = Selector.Register("colorTextureUsage");

    public static readonly Selector DepthTextureUsage = Selector.Register("depthTextureUsage");

    public static readonly Selector MotionTextureUsage = Selector.Register("motionTextureUsage");

    public static readonly Selector ReactiveTextureUsage = Selector.Register("reactiveTextureUsage");

    public static readonly Selector DiffuseAlbedoTextureUsage = Selector.Register("diffuseAlbedoTextureUsage");

    public static readonly Selector SpecularAlbedoTextureUsage = Selector.Register("specularAlbedoTextureUsage");

    public static readonly Selector NormalTextureUsage = Selector.Register("normalTextureUsage");

    public static readonly Selector RoughnessTextureUsage = Selector.Register("roughnessTextureUsage");

    public static readonly Selector SpecularHitDistanceTextureUsage = Selector.Register("specularHitDistanceTextureUsage");

    public static readonly Selector DenoiseStrengthMaskTextureUsage = Selector.Register("denoiseStrengthMaskTextureUsage");

    public static readonly Selector TransparencyOverlayTextureUsage = Selector.Register("transparencyOverlayTextureUsage");

    public static readonly Selector OutputTextureUsage = Selector.Register("outputTextureUsage");

    public static readonly Selector ColorTexture = Selector.Register("colorTexture");

    public static readonly Selector SetColorTexture = Selector.Register("setColorTexture:");

    public static readonly Selector DepthTexture = Selector.Register("depthTexture");

    public static readonly Selector SetDepthTexture = Selector.Register("setDepthTexture:");

    public static readonly Selector MotionTexture = Selector.Register("motionTexture");

    public static readonly Selector SetMotionTexture = Selector.Register("setMotionTexture:");

    public static readonly Selector DiffuseAlbedoTexture = Selector.Register("diffuseAlbedoTexture");

    public static readonly Selector SetDiffuseAlbedoTexture = Selector.Register("setDiffuseAlbedoTexture:");

    public static readonly Selector SpecularAlbedoTexture = Selector.Register("specularAlbedoTexture");

    public static readonly Selector SetSpecularAlbedoTexture = Selector.Register("setSpecularAlbedoTexture:");

    public static readonly Selector NormalTexture = Selector.Register("normalTexture");

    public static readonly Selector SetNormalTexture = Selector.Register("setNormalTexture:");

    public static readonly Selector RoughnessTexture = Selector.Register("roughnessTexture");

    public static readonly Selector SetRoughnessTexture = Selector.Register("setRoughnessTexture:");

    public static readonly Selector SpecularHitDistanceTexture = Selector.Register("specularHitDistanceTexture");

    public static readonly Selector SetSpecularHitDistanceTexture = Selector.Register("setSpecularHitDistanceTexture:");

    public static readonly Selector DenoiseStrengthMaskTexture = Selector.Register("denoiseStrengthMaskTexture");

    public static readonly Selector SetDenoiseStrengthMaskTexture = Selector.Register("setDenoiseStrengthMaskTexture:");

    public static readonly Selector TransparencyOverlayTexture = Selector.Register("transparencyOverlayTexture");

    public static readonly Selector SetTransparencyOverlayTexture = Selector.Register("setTransparencyOverlayTexture:");

    public static readonly Selector OutputTexture = Selector.Register("outputTexture");

    public static readonly Selector SetOutputTexture = Selector.Register("setOutputTexture:");

    public static readonly Selector ExposureTexture = Selector.Register("exposureTexture");

    public static readonly Selector SetExposureTexture = Selector.Register("setExposureTexture:");

    public static readonly Selector PreExposure = Selector.Register("preExposure");

    public static readonly Selector SetPreExposure = Selector.Register("setPreExposure:");

    public static readonly Selector ReactiveMaskTexture = Selector.Register("reactiveMaskTexture");

    public static readonly Selector SetReactiveMaskTexture = Selector.Register("setReactiveMaskTexture:");

    public static readonly Selector JitterOffsetX = Selector.Register("jitterOffsetX");

    public static readonly Selector SetJitterOffsetX = Selector.Register("setJitterOffsetX:");

    public static readonly Selector JitterOffsetY = Selector.Register("jitterOffsetY");

    public static readonly Selector SetJitterOffsetY = Selector.Register("setJitterOffsetY:");

    public static readonly Selector MotionVectorScaleX = Selector.Register("motionVectorScaleX");

    public static readonly Selector SetMotionVectorScaleX = Selector.Register("setMotionVectorScaleX:");

    public static readonly Selector MotionVectorScaleY = Selector.Register("motionVectorScaleY");

    public static readonly Selector SetMotionVectorScaleY = Selector.Register("setMotionVectorScaleY:");

    public static readonly Selector ShouldResetHistory = Selector.Register("shouldResetHistory");

    public static readonly Selector SetShouldResetHistory = Selector.Register("setShouldResetHistory:");

    public static readonly Selector IsDepthReversed = Selector.Register("isDepthReversed");

    public static readonly Selector ColorTextureFormat = Selector.Register("colorTextureFormat");

    public static readonly Selector DepthTextureFormat = Selector.Register("depthTextureFormat");

    public static readonly Selector MotionTextureFormat = Selector.Register("motionTextureFormat");

    public static readonly Selector DiffuseAlbedoTextureFormat = Selector.Register("diffuseAlbedoTextureFormat");

    public static readonly Selector SpecularAlbedoTextureFormat = Selector.Register("specularAlbedoTextureFormat");

    public static readonly Selector NormalTextureFormat = Selector.Register("normalTextureFormat");

    public static readonly Selector RoughnessTextureFormat = Selector.Register("roughnessTextureFormat");

    public static readonly Selector SpecularHitDistanceTextureFormat = Selector.Register("specularHitDistanceTextureFormat");

    public static readonly Selector DenoiseStrengthMaskTextureFormat = Selector.Register("denoiseStrengthMaskTextureFormat");

    public static readonly Selector TransparencyOverlayTextureFormat = Selector.Register("transparencyOverlayTextureFormat");

    public static readonly Selector ReactiveMaskTextureFormat = Selector.Register("reactiveMaskTextureFormat");

    public static readonly Selector OutputTextureFormat = Selector.Register("outputTextureFormat");

    public static readonly Selector InputWidth = Selector.Register("inputWidth");

    public static readonly Selector InputHeight = Selector.Register("inputHeight");

    public static readonly Selector OutputWidth = Selector.Register("outputWidth");

    public static readonly Selector OutputHeight = Selector.Register("outputHeight");

    public static readonly Selector InputContentMinScale = Selector.Register("inputContentMinScale");

    public static readonly Selector InputContentMaxScale = Selector.Register("inputContentMaxScale");

    public static readonly Selector WorldToViewMatrix = Selector.Register("worldToViewMatrix");

    public static readonly Selector SetWorldToViewMatrix = Selector.Register("setWorldToViewMatrix:");

    public static readonly Selector ViewToClipMatrix = Selector.Register("viewToClipMatrix");

    public static readonly Selector SetViewToClipMatrix = Selector.Register("setViewToClipMatrix:");

    public static readonly Selector Fence = Selector.Register("fence");

    public static readonly Selector SetFence = Selector.Register("setFence:");

    public static readonly Selector SetDepthReversed = Selector.Register("setDepthReversed:");
}
