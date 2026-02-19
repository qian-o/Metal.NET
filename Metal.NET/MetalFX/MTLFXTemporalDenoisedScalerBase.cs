namespace Metal.NET;

public readonly struct MTLFXTemporalDenoisedScalerBase(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLTexture? ColorTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ColorTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetColorTexture, value?.NativePtr ?? 0);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ColorTextureFormat);
    }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ColorTextureUsage);
    }

    public MTLTexture? DenoiseStrengthMaskTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DenoiseStrengthMaskTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetDenoiseStrengthMaskTexture, value?.NativePtr ?? 0);
    }

    public MTLPixelFormat DenoiseStrengthMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DenoiseStrengthMaskTextureFormat);
    }

    public MTLTextureUsage DenoiseStrengthMaskTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DenoiseStrengthMaskTextureUsage);
    }

    public MTLTexture? DepthTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DepthTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetDepthTexture, value?.NativePtr ?? 0);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DepthTextureFormat);
    }

    public MTLTextureUsage DepthTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DepthTextureUsage);
    }

    public MTLTexture? DiffuseAlbedoTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DiffuseAlbedoTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetDiffuseAlbedoTexture, value?.NativePtr ?? 0);
    }

    public MTLPixelFormat DiffuseAlbedoTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DiffuseAlbedoTextureFormat);
    }

    public MTLTextureUsage DiffuseAlbedoTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DiffuseAlbedoTextureUsage);
    }

    public MTLTexture? ExposureTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ExposureTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetExposureTexture, value?.NativePtr ?? 0);
    }

    public MTLFence? Fence
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.Fence);
            return ptr is not 0 ? new MTLFence(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetFence, value?.NativePtr ?? 0);
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

    public MTLTexture? MotionTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.MotionTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetMotionTexture, value?.NativePtr ?? 0);
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

    public MTLTexture? NormalTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.NormalTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetNormalTexture, value?.NativePtr ?? 0);
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

    public MTLTexture? OutputTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.OutputTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetOutputTexture, value?.NativePtr ?? 0);
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

    public MTLTexture? ReactiveMaskTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ReactiveMaskTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetReactiveMaskTexture, value?.NativePtr ?? 0);
    }

    public MTLPixelFormat ReactiveMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ReactiveMaskTextureFormat);
    }

    public MTLTextureUsage ReactiveTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ReactiveTextureUsage);
    }

    public MTLTexture? RoughnessTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.RoughnessTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetRoughnessTexture, value?.NativePtr ?? 0);
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

    public MTLTexture? SpecularAlbedoTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularAlbedoTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetSpecularAlbedoTexture, value?.NativePtr ?? 0);
    }

    public MTLPixelFormat SpecularAlbedoTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularAlbedoTextureFormat);
    }

    public MTLTextureUsage SpecularAlbedoTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularAlbedoTextureUsage);
    }

    public MTLTexture? SpecularHitDistanceTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularHitDistanceTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetSpecularHitDistanceTexture, value?.NativePtr ?? 0);
    }

    public MTLPixelFormat SpecularHitDistanceTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularHitDistanceTextureFormat);
    }

    public MTLTextureUsage SpecularHitDistanceTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularHitDistanceTextureUsage);
    }

    public MTLTexture? TransparencyOverlayTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.TransparencyOverlayTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetTransparencyOverlayTexture, value?.NativePtr ?? 0);
    }

    public MTLPixelFormat TransparencyOverlayTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.TransparencyOverlayTextureFormat);
    }

    public MTLTextureUsage TransparencyOverlayTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.TransparencyOverlayTextureUsage);
    }

    public nint ViewToClipMatrix
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ViewToClipMatrix);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetViewToClipMatrix, value);
    }

    public nint WorldToViewMatrix
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.WorldToViewMatrix);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetWorldToViewMatrix, value);
    }
}

file static class MTLFXTemporalDenoisedScalerBaseBindings
{
    public static readonly Selector ColorTexture = Selector.Register("colorTexture");

    public static readonly Selector ColorTextureFormat = Selector.Register("colorTextureFormat");

    public static readonly Selector ColorTextureUsage = Selector.Register("colorTextureUsage");

    public static readonly Selector DenoiseStrengthMaskTexture = Selector.Register("denoiseStrengthMaskTexture");

    public static readonly Selector DenoiseStrengthMaskTextureFormat = Selector.Register("denoiseStrengthMaskTextureFormat");

    public static readonly Selector DenoiseStrengthMaskTextureUsage = Selector.Register("denoiseStrengthMaskTextureUsage");

    public static readonly Selector DepthTexture = Selector.Register("depthTexture");

    public static readonly Selector DepthTextureFormat = Selector.Register("depthTextureFormat");

    public static readonly Selector DepthTextureUsage = Selector.Register("depthTextureUsage");

    public static readonly Selector DiffuseAlbedoTexture = Selector.Register("diffuseAlbedoTexture");

    public static readonly Selector DiffuseAlbedoTextureFormat = Selector.Register("diffuseAlbedoTextureFormat");

    public static readonly Selector DiffuseAlbedoTextureUsage = Selector.Register("diffuseAlbedoTextureUsage");

    public static readonly Selector ExposureTexture = Selector.Register("exposureTexture");

    public static readonly Selector Fence = Selector.Register("fence");

    public static readonly Selector InputContentMaxScale = Selector.Register("inputContentMaxScale");

    public static readonly Selector InputContentMinScale = Selector.Register("inputContentMinScale");

    public static readonly Selector InputHeight = Selector.Register("inputHeight");

    public static readonly Selector InputWidth = Selector.Register("inputWidth");

    public static readonly Selector IsDepthReversed = Selector.Register("isDepthReversed");

    public static readonly Selector JitterOffsetX = Selector.Register("jitterOffsetX");

    public static readonly Selector JitterOffsetY = Selector.Register("jitterOffsetY");

    public static readonly Selector MotionTexture = Selector.Register("motionTexture");

    public static readonly Selector MotionTextureFormat = Selector.Register("motionTextureFormat");

    public static readonly Selector MotionTextureUsage = Selector.Register("motionTextureUsage");

    public static readonly Selector MotionVectorScaleX = Selector.Register("motionVectorScaleX");

    public static readonly Selector MotionVectorScaleY = Selector.Register("motionVectorScaleY");

    public static readonly Selector NormalTexture = Selector.Register("normalTexture");

    public static readonly Selector NormalTextureFormat = Selector.Register("normalTextureFormat");

    public static readonly Selector NormalTextureUsage = Selector.Register("normalTextureUsage");

    public static readonly Selector OutputHeight = Selector.Register("outputHeight");

    public static readonly Selector OutputTexture = Selector.Register("outputTexture");

    public static readonly Selector OutputTextureFormat = Selector.Register("outputTextureFormat");

    public static readonly Selector OutputTextureUsage = Selector.Register("outputTextureUsage");

    public static readonly Selector OutputWidth = Selector.Register("outputWidth");

    public static readonly Selector PreExposure = Selector.Register("preExposure");

    public static readonly Selector ReactiveMaskTexture = Selector.Register("reactiveMaskTexture");

    public static readonly Selector ReactiveMaskTextureFormat = Selector.Register("reactiveMaskTextureFormat");

    public static readonly Selector ReactiveTextureUsage = Selector.Register("reactiveTextureUsage");

    public static readonly Selector RoughnessTexture = Selector.Register("roughnessTexture");

    public static readonly Selector RoughnessTextureFormat = Selector.Register("roughnessTextureFormat");

    public static readonly Selector RoughnessTextureUsage = Selector.Register("roughnessTextureUsage");

    public static readonly Selector SetColorTexture = Selector.Register("setColorTexture:");

    public static readonly Selector SetDenoiseStrengthMaskTexture = Selector.Register("setDenoiseStrengthMaskTexture:");

    public static readonly Selector SetDepthTexture = Selector.Register("setDepthTexture:");

    public static readonly Selector SetDiffuseAlbedoTexture = Selector.Register("setDiffuseAlbedoTexture:");

    public static readonly Selector SetExposureTexture = Selector.Register("setExposureTexture:");

    public static readonly Selector SetFence = Selector.Register("setFence:");

    public static readonly Selector SetJitterOffsetX = Selector.Register("setJitterOffsetX:");

    public static readonly Selector SetJitterOffsetY = Selector.Register("setJitterOffsetY:");

    public static readonly Selector SetMotionTexture = Selector.Register("setMotionTexture:");

    public static readonly Selector SetMotionVectorScaleX = Selector.Register("setMotionVectorScaleX:");

    public static readonly Selector SetMotionVectorScaleY = Selector.Register("setMotionVectorScaleY:");

    public static readonly Selector SetNormalTexture = Selector.Register("setNormalTexture:");

    public static readonly Selector SetOutputTexture = Selector.Register("setOutputTexture:");

    public static readonly Selector SetPreExposure = Selector.Register("setPreExposure:");

    public static readonly Selector SetReactiveMaskTexture = Selector.Register("setReactiveMaskTexture:");

    public static readonly Selector SetRoughnessTexture = Selector.Register("setRoughnessTexture:");

    public static readonly Selector SetShouldResetHistory = Selector.Register("setShouldResetHistory:");

    public static readonly Selector SetSpecularAlbedoTexture = Selector.Register("setSpecularAlbedoTexture:");

    public static readonly Selector SetSpecularHitDistanceTexture = Selector.Register("setSpecularHitDistanceTexture:");

    public static readonly Selector SetTransparencyOverlayTexture = Selector.Register("setTransparencyOverlayTexture:");

    public static readonly Selector SetViewToClipMatrix = Selector.Register("setViewToClipMatrix:");

    public static readonly Selector SetWorldToViewMatrix = Selector.Register("setWorldToViewMatrix:");

    public static readonly Selector ShouldResetHistory = Selector.Register("shouldResetHistory");

    public static readonly Selector SpecularAlbedoTexture = Selector.Register("specularAlbedoTexture");

    public static readonly Selector SpecularAlbedoTextureFormat = Selector.Register("specularAlbedoTextureFormat");

    public static readonly Selector SpecularAlbedoTextureUsage = Selector.Register("specularAlbedoTextureUsage");

    public static readonly Selector SpecularHitDistanceTexture = Selector.Register("specularHitDistanceTexture");

    public static readonly Selector SpecularHitDistanceTextureFormat = Selector.Register("specularHitDistanceTextureFormat");

    public static readonly Selector SpecularHitDistanceTextureUsage = Selector.Register("specularHitDistanceTextureUsage");

    public static readonly Selector TransparencyOverlayTexture = Selector.Register("transparencyOverlayTexture");

    public static readonly Selector TransparencyOverlayTextureFormat = Selector.Register("transparencyOverlayTextureFormat");

    public static readonly Selector TransparencyOverlayTextureUsage = Selector.Register("transparencyOverlayTextureUsage");

    public static readonly Selector ViewToClipMatrix = Selector.Register("viewToClipMatrix");

    public static readonly Selector WorldToViewMatrix = Selector.Register("worldToViewMatrix");
}
