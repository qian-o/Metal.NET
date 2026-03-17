namespace Metal.NET;

public class MTLFXTemporalDenoisedScalerBase(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFXTemporalDenoisedScalerBase>
{
    #region INativeObject
    public static new MTLFXTemporalDenoisedScalerBase Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXTemporalDenoisedScalerBase New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

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
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.ColorTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetColorTexture, value);
    }

    public MTLTexture DepthTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.DepthTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetDepthTexture, value);
    }

    public MTLTexture MotionTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.MotionTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetMotionTexture, value);
    }

    public MTLTexture DiffuseAlbedoTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.DiffuseAlbedoTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetDiffuseAlbedoTexture, value);
    }

    public MTLTexture SpecularAlbedoTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SpecularAlbedoTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetSpecularAlbedoTexture, value);
    }

    public MTLTexture NormalTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.NormalTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetNormalTexture, value);
    }

    public MTLTexture RoughnessTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.RoughnessTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetRoughnessTexture, value);
    }

    public MTLTexture SpecularHitDistanceTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SpecularHitDistanceTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetSpecularHitDistanceTexture, value);
    }

    public MTLTexture DenoiseStrengthMaskTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.DenoiseStrengthMaskTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetDenoiseStrengthMaskTexture, value);
    }

    public MTLTexture TransparencyOverlayTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.TransparencyOverlayTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetTransparencyOverlayTexture, value);
    }

    public MTLTexture OutputTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.OutputTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetOutputTexture, value);
    }

    public MTLTexture ExposureTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.ExposureTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetExposureTexture, value);
    }

    public float PreExposure
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.PreExposure);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetPreExposure, value);
    }

    public MTLTexture ReactiveMaskTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.ReactiveMaskTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetReactiveMaskTexture, value);
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

    public simd_float4x4 WorldToViewMatrix
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.WorldToViewMatrix);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetWorldToViewMatrix, value);
    }

    public simd_float4x4 ViewToClipMatrix
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.ViewToClipMatrix);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetViewToClipMatrix, value);
    }

    public MTLFence Fence
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.Fence);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetFence, value);
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
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.ColorTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetColorTexture, value);
    }

    public MTLTexture DepthTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.DepthTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetDepthTexture, value);
    }

    public MTLTexture MotionTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.MotionTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetMotionTexture, value);
    }

    public MTLTexture DiffuseAlbedoTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.DiffuseAlbedoTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetDiffuseAlbedoTexture, value);
    }

    public MTLTexture SpecularAlbedoTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SpecularAlbedoTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetSpecularAlbedoTexture, value);
    }

    public MTLTexture NormalTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.NormalTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetNormalTexture, value);
    }

    public MTLTexture RoughnessTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.RoughnessTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetRoughnessTexture, value);
    }

    public MTLTexture SpecularHitDistanceTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SpecularHitDistanceTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetSpecularHitDistanceTexture, value);
    }

    public MTLTexture DenoiseStrengthMaskTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.DenoiseStrengthMaskTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetDenoiseStrengthMaskTexture, value);
    }

    public MTLTexture TransparencyOverlayTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.TransparencyOverlayTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetTransparencyOverlayTexture, value);
    }

    public MTLTexture OutputTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.OutputTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetOutputTexture, value);
    }

    public MTLTexture ExposureTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.ExposureTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetExposureTexture, value);
    }

    public float PreExposure
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.PreExposure);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetPreExposure, value);
    }

    public MTLTexture ReactiveMaskTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.ReactiveMaskTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetReactiveMaskTexture, value);
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

    public simd_float4x4 WorldToViewMatrix
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.WorldToViewMatrix);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetWorldToViewMatrix, value);
    }

    public simd_float4x4 ViewToClipMatrix
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.ViewToClipMatrix);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetViewToClipMatrix, value);
    }

    public MTLFence Fence
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.Fence);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetFence, value);
    }

    public void SetColorTexture(MTLTexture colorTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetColorTexture, colorTexture.NativePtr);
    }

    public void SetDepthTexture(MTLTexture depthTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetDepthTexture, depthTexture.NativePtr);
    }

    public void SetMotionTexture(MTLTexture motionTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetMotionTexture, motionTexture.NativePtr);
    }

    public void SetDiffuseAlbedoTexture(MTLTexture diffuseAlbedoTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetDiffuseAlbedoTexture, diffuseAlbedoTexture.NativePtr);
    }

    public void SetSpecularAlbedoTexture(MTLTexture specularAlbedoTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetSpecularAlbedoTexture, specularAlbedoTexture.NativePtr);
    }

    public void SetNormalTexture(MTLTexture normalTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetNormalTexture, normalTexture.NativePtr);
    }

    public void SetRoughnessTexture(MTLTexture roughnessTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetRoughnessTexture, roughnessTexture.NativePtr);
    }

    public void SetSpecularHitDistanceTexture(MTLTexture specularHitDistanceTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetSpecularHitDistanceTexture, specularHitDistanceTexture.NativePtr);
    }

    public void SetDenoiseStrengthMaskTexture(MTLTexture denoiseStrengthMaskTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetDenoiseStrengthMaskTexture, denoiseStrengthMaskTexture.NativePtr);
    }

    public void SetTransparencyOverlayTexture(MTLTexture transparencyOverlayTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetTransparencyOverlayTexture, transparencyOverlayTexture.NativePtr);
    }

    public void SetOutputTexture(MTLTexture outputTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetOutputTexture, outputTexture.NativePtr);
    }

    public void SetExposureTexture(MTLTexture exposureTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetExposureTexture, exposureTexture.NativePtr);
    }

    public void SetPreExposure(float preExposure)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetPreExposure, preExposure);
    }

    public void SetReactiveMaskTexture(MTLTexture reactiveMaskTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetReactiveMaskTexture, reactiveMaskTexture.NativePtr);
    }

    public void SetJitterOffsetX(float jitterOffsetX)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetJitterOffsetX, jitterOffsetX);
    }

    public void SetJitterOffsetY(float jitterOffsetY)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetJitterOffsetY, jitterOffsetY);
    }

    public void SetMotionVectorScaleX(float motionVectorScaleX)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetMotionVectorScaleX, motionVectorScaleX);
    }

    public void SetMotionVectorScaleY(float motionVectorScaleY)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetMotionVectorScaleY, motionVectorScaleY);
    }

    public void SetShouldResetHistory(bool shouldResetHistory)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetShouldResetHistory, shouldResetHistory);
    }

    public void SetIsDepthReversed(bool isDepthReversed)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetIsDepthReversed, isDepthReversed);
    }

    public void SetWorldToViewMatrix(simd_float4x4 worldToViewMatrix)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetWorldToViewMatrix, worldToViewMatrix.NativePtr);
    }

    public void SetViewToClipMatrix(simd_float4x4 viewToClipMatrix)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetViewToClipMatrix, viewToClipMatrix.NativePtr);
    }

    public void SetFence(MTLFence fence)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetFence, fence.NativePtr);
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

    public static readonly Selector SetIsDepthReversed = "setDepthReversed:";

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
