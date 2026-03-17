namespace Metal.NET;

public class MTLFXTemporalDenoisedScalerBase(nint nativePtr, NativeObjectOwnership ownership) : MTLFXFrameInterpolatableScaler(nativePtr, ownership), INativeObject<MTLFXTemporalDenoisedScalerBase>
{
    #region INativeObject
    public static new MTLFXTemporalDenoisedScalerBase Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXTemporalDenoisedScalerBase New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>
    /// Assigns the color texture this scaler evaluates.
    /// </summary>
    public MTLTexture ColorTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.ColorTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetColorTexture, value);
    }

    /// <summary>
    /// The pixel format of the input color texture for this denoiser scaler.
    /// </summary>
    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ColorTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input color texture needs in order to support this denoiser scaler.
    /// </summary>
    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ColorTextureUsage);
    }

    /// <summary>
    /// The denoise strength mask texture this scaler evaluates.
    /// </summary>
    public MTLTexture DenoiseStrengthMaskTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.DenoiseStrengthMaskTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetDenoiseStrengthMaskTexture, value);
    }

    /// <summary>
    /// The pixel format of the input denoise strength mask texture for this denoiser scaler.
    /// </summary>
    public MTLPixelFormat DenoiseStrengthMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DenoiseStrengthMaskTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input denoise strength texture needs in order to support this denoiser scaler.
    /// </summary>
    public MTLTextureUsage DenoiseStrengthMaskTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DenoiseStrengthMaskTextureUsage);
    }

    /// <summary>
    /// The depth texture this scaler evaluates.
    /// </summary>
    public MTLTexture DepthTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.DepthTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetDepthTexture, value);
    }

    /// <summary>
    /// The pixel format of the input depth texture for this denoiser scaler.
    /// </summary>
    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DepthTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input depth texture needs in order to support this denoiser scaler.
    /// </summary>
    public MTLTextureUsage DepthTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DepthTextureUsage);
    }

    /// <summary>
    /// The diffuse albedo texture this scaler evaluates.
    /// </summary>
    public MTLTexture DiffuseAlbedoTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.DiffuseAlbedoTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetDiffuseAlbedoTexture, value);
    }

    /// <summary>
    /// The pixel format of the input diffuse albedo texture for this denoiser scaler.
    /// </summary>
    public MTLPixelFormat DiffuseAlbedoTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DiffuseAlbedoTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input diffuse albedo texture needs in order to support this denoiser scaler.
    /// </summary>
    public MTLTextureUsage DiffuseAlbedoTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.DiffuseAlbedoTextureUsage);
    }

    /// <summary>
    /// An exposure texture that this denoiser scaler evaluates.
    /// </summary>
    public MTLTexture ExposureTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.ExposureTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetExposureTexture, value);
    }

    /// <summary>
    /// An optional fence that this denoiser scaler waits for and updates.
    /// </summary>
    public MTLFence Fence
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.Fence);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetFence, value);
    }

    /// <summary>
    /// The maximum input content scale this scaler supports.
    /// </summary>
    public float InputContentMaxScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.InputContentMaxScale);
    }

    /// <summary>
    /// The minimum input content scale this scaler supports.
    /// </summary>
    public float InputContentMinScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.InputContentMinScale);
    }

    /// <summary>
    /// The height, in pixels, of the input color texture for the scaler.
    /// </summary>
    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.InputHeight);
    }

    /// <summary>
    /// The width, in pixels, of the input color texture for the scaler.
    /// </summary>
    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.InputWidth);
    }

    /// <summary>
    /// A Boolean value that indicates whether the depth texture uses zero to represent the farthest distance.
    /// </summary>
    public Bool8 IsDepthReversed
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.IsDepthReversed);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetDepthReversed, value);
    }

    /// <summary>
    /// The horizontal component of the subpixel sampling coordinate you use to generate the color texture input.
    /// </summary>
    public float JitterOffsetX
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.JitterOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetJitterOffsetX, value);
    }

    /// <summary>
    /// The vertical component of the subpixel sampling coordinate you use to generate the color texture input.
    /// </summary>
    public float JitterOffsetY
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.JitterOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetJitterOffsetY, value);
    }

    /// <summary>
    /// The motion texture this scaler evaluates.
    /// </summary>
    public MTLTexture MotionTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.MotionTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetMotionTexture, value);
    }

    /// <summary>
    /// The pixel format of the input motion texture for this denoiser scaler.
    /// </summary>
    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.MotionTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input motion texture needs in order to support this denoiser scaler.
    /// </summary>
    public MTLTextureUsage MotionTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.MotionTextureUsage);
    }

    /// <summary>
    /// The horizontal scale factor the denoiser scaler applies to the input motion texture.
    /// </summary>
    public float MotionVectorScaleX
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.MotionVectorScaleX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetMotionVectorScaleX, value);
    }

    /// <summary>
    /// The vertical scale factor the denoiser scaler applies to the input motion texture.
    /// </summary>
    public float MotionVectorScaleY
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.MotionVectorScaleY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetMotionVectorScaleY, value);
    }

    /// <summary>
    /// The normal texture this scaler evaluates.
    /// </summary>
    public MTLTexture NormalTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.NormalTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetNormalTexture, value);
    }

    /// <summary>
    /// The pixel format of the input normal texture for this denoiser scaler.
    /// </summary>
    public MTLPixelFormat NormalTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.NormalTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input normal texture needs in order to support this denoiser scaler.
    /// </summary>
    public MTLTextureUsage NormalTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.NormalTextureUsage);
    }

    /// <summary>
    /// The height, in pixels, of the output color texture for the scaler.
    /// </summary>
    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.OutputHeight);
    }

    /// <summary>
    /// The output texture into which this denoiser scaler writes its output.
    /// </summary>
    public MTLTexture OutputTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.OutputTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetOutputTexture, value);
    }

    /// <summary>
    /// The pixel format of the output color texture for this denoiser scaler.
    /// </summary>
    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.OutputTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s output texture needs in order to support this denoiser scaler.
    /// </summary>
    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.OutputTextureUsage);
    }

    /// <summary>
    /// The width, in pixels, of the output color texture for the scaler.
    /// </summary>
    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.OutputWidth);
    }

    /// <summary>
    /// A pre-exposure value for this scaler to evaluate.
    /// </summary>
    public float PreExposure
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.PreExposure);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetPreExposure, value);
    }

    /// <summary>
    /// A reactive-mask texture input for this scaler to evaluate.
    /// </summary>
    public MTLTexture ReactiveMaskTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.ReactiveMaskTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetReactiveMaskTexture, value);
    }

    /// <summary>
    /// The pixel format of the input reactive mask texture for this denoiser scaler.
    /// </summary>
    public MTLPixelFormat ReactiveMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ReactiveMaskTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input reactive texture needs in order to support this denoiser scaler.
    /// </summary>
    public MTLTextureUsage ReactiveTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ReactiveTextureUsage);
    }

    /// <summary>
    /// The roughness texture this scaler evaluates.
    /// </summary>
    public MTLTexture RoughnessTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.RoughnessTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetRoughnessTexture, value);
    }

    /// <summary>
    /// The pixel format of the input normal texture for this denoiser scaler.
    /// </summary>
    public MTLPixelFormat RoughnessTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.RoughnessTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input roughness texture needs in order to support this denoiser scaler.
    /// </summary>
    public MTLTextureUsage RoughnessTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.RoughnessTextureUsage);
    }

    /// <summary>
    /// A Boolean property indicating whether to reset history.
    /// </summary>
    public Bool8 ShouldResetHistory
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ShouldResetHistory);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetShouldResetHistory, value);
    }

    /// <summary>
    /// The specular albedo texture this scaler evaluates.
    /// </summary>
    public MTLTexture SpecularAlbedoTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SpecularAlbedoTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetSpecularAlbedoTexture, value);
    }

    /// <summary>
    /// The pixel format of the input specular albedo for this denoiser scaler.
    /// </summary>
    public MTLPixelFormat SpecularAlbedoTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularAlbedoTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input specular albedo texture needs in order to support this denoiser scaler.
    /// </summary>
    public MTLTextureUsage SpecularAlbedoTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularAlbedoTextureUsage);
    }

    /// <summary>
    /// The specular hit texture this scaler evaluates.
    /// </summary>
    public MTLTexture SpecularHitDistanceTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SpecularHitDistanceTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetSpecularHitDistanceTexture, value);
    }

    /// <summary>
    /// The pixel format of the input specular hit distance texture for this denoiser scaler.
    /// </summary>
    public MTLPixelFormat SpecularHitDistanceTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularHitDistanceTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input specular hit texture needs in order to support this denoiser scaler.
    /// </summary>
    public MTLTextureUsage SpecularHitDistanceTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SpecularHitDistanceTextureUsage);
    }

    /// <summary>
    /// The transparency overlay texture that this scaler evaluates.
    /// </summary>
    public MTLTexture TransparencyOverlayTexture
    {
        get => GetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.TransparencyOverlayTexture);
        set => SetProperty(ref field, MTLFXTemporalDenoisedScalerBaseBindings.SetTransparencyOverlayTexture, value);
    }

    /// <summary>
    /// The pixel format of the input transparency overlay texture for this denoiser scaler.
    /// </summary>
    public MTLPixelFormat TransparencyOverlayTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.TransparencyOverlayTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input transparency overlay texture needs in order to support this denoiser scaler.
    /// </summary>
    public MTLTextureUsage TransparencyOverlayTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.TransparencyOverlayTextureUsage);
    }

    /// <summary>
    /// The view-to-clip coordinates transformation matrix this scaler uses as part of its operation.
    /// </summary>
    public SimdFloat4x4 ViewToClipMatrix
    {
        get => ObjectiveC.MsgSendSimdFloat4x4(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.ViewToClipMatrix);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetViewToClipMatrix, value);
    }

    /// <summary>
    /// The world-to-view transformation matrix this scaler uses as part of its operation.
    /// </summary>
    public SimdFloat4x4 WorldToViewMatrix
    {
        get => ObjectiveC.MsgSendSimdFloat4x4(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.WorldToViewMatrix);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBaseBindings.SetWorldToViewMatrix, value);
    }
    #endregion
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
