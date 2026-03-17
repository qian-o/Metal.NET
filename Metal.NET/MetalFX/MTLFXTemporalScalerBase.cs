namespace Metal.NET;

/// <summary>
/// An upscaling effect that generates a higher resolution texture in a render pass by analyzing multiple input textures over time.
/// </summary>
public class MTLFXTemporalScalerBase(nint nativePtr, NativeObjectOwnership ownership) : MTLFXFrameInterpolatableScaler(nativePtr, ownership), INativeObject<MTLFXTemporalScalerBase>
{
    #region INativeObject
    public static new MTLFXTemporalScalerBase Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXTemporalScalerBase New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>
    /// An input color texture you set for the scaler that supports the correct color texture usage options.
    /// </summary>
    public MTLTexture ColorTexture
    {
        get => GetProperty(ref field, MTLFXTemporalScalerBaseBindings.ColorTexture);
        set => SetProperty(ref field, MTLFXTemporalScalerBaseBindings.SetColorTexture, value);
    }

    /// <summary>
    /// The pixel format of the input color texture for this this scaler.
    /// </summary>
    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBaseBindings.ColorTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input color texture needs in order to support this scaler.
    /// </summary>
    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBaseBindings.ColorTextureUsage);
    }

    /// <summary>
    /// An input depth texture you set for the scaler that supports the correct color texture usage options.
    /// </summary>
    public MTLTexture DepthTexture
    {
        get => GetProperty(ref field, MTLFXTemporalScalerBaseBindings.DepthTexture);
        set => SetProperty(ref field, MTLFXTemporalScalerBaseBindings.SetDepthTexture, value);
    }

    /// <summary>
    /// The pixel format of the input depth texture for this this scaler.
    /// </summary>
    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBaseBindings.DepthTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input depth texture needs in order to support this scaler.
    /// </summary>
    public MTLTextureUsage DepthTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBaseBindings.DepthTextureUsage);
    }

    /// <summary>
    /// The exposure texture this scaler uses.
    /// </summary>
    public MTLTexture ExposureTexture
    {
        get => GetProperty(ref field, MTLFXTemporalScalerBaseBindings.ExposureTexture);
        set => SetProperty(ref field, MTLFXTemporalScalerBaseBindings.SetExposureTexture, value);
    }

    /// <summary>
    /// An optional fence that you provide to synchronize your app’s untracked resources.
    /// </summary>
    public MTLFence Fence
    {
        get => GetProperty(ref field, MTLFXTemporalScalerBaseBindings.Fence);
        set => SetProperty(ref field, MTLFXTemporalScalerBaseBindings.SetFence, value);
    }

    /// <summary>
    /// The height, in pixels, of the region within the color texture the scaler uses as its input.
    /// </summary>
    public nuint InputContentHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.InputContentHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetInputContentHeight, value);
    }

    /// <summary>
    /// The largest scale factor the temporal scaler can use to generate output textures.
    /// </summary>
    public float InputContentMaxScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseBindings.InputContentMaxScale);
    }

    /// <summary>
    /// The smallest scale factor the temporal scaler can use to generate output textures.
    /// </summary>
    public float InputContentMinScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseBindings.InputContentMinScale);
    }

    /// <summary>
    /// The width, in pixels, of the region within the color texture the scaler uses as its input.
    /// </summary>
    public nuint InputContentWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.InputContentWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetInputContentWidth, value);
    }

    /// <summary>
    /// The height, in pixels, of the input color texture for this scaler.
    /// </summary>
    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.InputHeight);
    }

    /// <summary>
    /// The width, in pixels, of the input color texture for this scaler.
    /// </summary>
    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.InputWidth);
    }

    /// <summary>
    /// A Boolean value that indicates whether the depth texture uses zero to represent the farthest distance.
    /// </summary>
    public Bool8 IsDepthReversed
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalScalerBaseBindings.IsDepthReversed);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetDepthReversed, value);
    }

    /// <summary>
    /// The horizontal component of the subpixel sampling coordinate you use to generate the color texture input.
    /// </summary>
    public float JitterOffsetX
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseBindings.JitterOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetJitterOffsetX, value);
    }

    /// <summary>
    /// The vertical component of the subpixel sampling coordinate you use to generate the color texture input.
    /// </summary>
    public float JitterOffsetY
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseBindings.JitterOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetJitterOffsetY, value);
    }

    /// <summary>
    /// An input motion texture you set for the scaler that supports the correct color texture usage options.
    /// </summary>
    public MTLTexture MotionTexture
    {
        get => GetProperty(ref field, MTLFXTemporalScalerBaseBindings.MotionTexture);
        set => SetProperty(ref field, MTLFXTemporalScalerBaseBindings.SetMotionTexture, value);
    }

    /// <summary>
    /// The pixel format of the input motion texture for this this scaler.
    /// </summary>
    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBaseBindings.MotionTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s motion texture needs in order to support this scaler.
    /// </summary>
    public MTLTextureUsage MotionTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBaseBindings.MotionTextureUsage);
    }

    /// <summary>
    /// The horizontal scale factor the scaler applies to the input motion texture.
    /// </summary>
    public float MotionVectorScaleX
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseBindings.MotionVectorScaleX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetMotionVectorScaleX, value);
    }

    /// <summary>
    /// The vertical scale factor the scaler applies to the input motion texture.
    /// </summary>
    public float MotionVectorScaleY
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseBindings.MotionVectorScaleY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetMotionVectorScaleY, value);
    }

    /// <summary>
    /// The height, in pixels, of the output color texture for this scaler.
    /// </summary>
    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.OutputHeight);
    }

    /// <summary>
    /// The output texture into which this scaler writes its output.
    /// </summary>
    public MTLTexture OutputTexture
    {
        get => GetProperty(ref field, MTLFXTemporalScalerBaseBindings.OutputTexture);
        set => SetProperty(ref field, MTLFXTemporalScalerBaseBindings.SetOutputTexture, value);
    }

    /// <summary>
    /// The pixel format of the output color texture for this this scaler.
    /// </summary>
    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBaseBindings.OutputTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your output texture needs in order to support this scaler.
    /// </summary>
    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBaseBindings.OutputTextureUsage);
    }

    /// <summary>
    /// The width, in pixels, of the output color texture for this scaler.
    /// </summary>
    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.OutputWidth);
    }

    /// <summary>
    /// A pre-exposure value this scaler evaluates.
    /// </summary>
    public float PreExposure
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseBindings.PreExposure);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetPreExposure, value);
    }

    /// <summary>
    /// The reactive-mask texture input this scaler uses.
    /// </summary>
    public MTLTexture ReactiveMaskTexture
    {
        get => GetProperty(ref field, MTLFXTemporalScalerBaseBindings.ReactiveMaskTexture);
        set => SetProperty(ref field, MTLFXTemporalScalerBaseBindings.SetReactiveMaskTexture, value);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s reactive texture needs in order to support this scaler.
    /// </summary>
    public MTLTextureUsage ReactiveTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBaseBindings.ReactiveTextureUsage);
    }

    /// <summary>
    /// A Boolean that indicates whether the temporal scaler discards historical data from previous frames.
    /// </summary>
    public Bool8 Reset
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalScalerBaseBindings.Reset);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetReset, value);
    }
    #endregion

    public MTLPixelFormat ReactiveTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBaseBindings.ReactiveTextureFormat);
    }
}

file static class MTLFXTemporalScalerBaseBindings
{
    public static readonly Selector ColorTexture = "colorTexture";

    public static readonly Selector ColorTextureFormat = "colorTextureFormat";

    public static readonly Selector ColorTextureUsage = "colorTextureUsage";

    public static readonly Selector DepthTexture = "depthTexture";

    public static readonly Selector DepthTextureFormat = "depthTextureFormat";

    public static readonly Selector DepthTextureUsage = "depthTextureUsage";

    public static readonly Selector ExposureTexture = "exposureTexture";

    public static readonly Selector Fence = "fence";

    public static readonly Selector InputContentHeight = "inputContentHeight";

    public static readonly Selector InputContentMaxScale = "inputContentMaxScale";

    public static readonly Selector InputContentMinScale = "inputContentMinScale";

    public static readonly Selector InputContentWidth = "inputContentWidth";

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

    public static readonly Selector OutputHeight = "outputHeight";

    public static readonly Selector OutputTexture = "outputTexture";

    public static readonly Selector OutputTextureFormat = "outputTextureFormat";

    public static readonly Selector OutputTextureUsage = "outputTextureUsage";

    public static readonly Selector OutputWidth = "outputWidth";

    public static readonly Selector PreExposure = "preExposure";

    public static readonly Selector ReactiveMaskTexture = "reactiveMaskTexture";

    public static readonly Selector ReactiveTextureFormat = "reactiveTextureFormat";

    public static readonly Selector ReactiveTextureUsage = "reactiveTextureUsage";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetColorTexture = "setColorTexture:";

    public static readonly Selector SetDepthReversed = "setDepthReversed:";

    public static readonly Selector SetDepthTexture = "setDepthTexture:";

    public static readonly Selector SetExposureTexture = "setExposureTexture:";

    public static readonly Selector SetFence = "setFence:";

    public static readonly Selector SetInputContentHeight = "setInputContentHeight:";

    public static readonly Selector SetInputContentWidth = "setInputContentWidth:";

    public static readonly Selector SetJitterOffsetX = "setJitterOffsetX:";

    public static readonly Selector SetJitterOffsetY = "setJitterOffsetY:";

    public static readonly Selector SetMotionTexture = "setMotionTexture:";

    public static readonly Selector SetMotionVectorScaleX = "setMotionVectorScaleX:";

    public static readonly Selector SetMotionVectorScaleY = "setMotionVectorScaleY:";

    public static readonly Selector SetOutputTexture = "setOutputTexture:";

    public static readonly Selector SetPreExposure = "setPreExposure:";

    public static readonly Selector SetReactiveMaskTexture = "setReactiveMaskTexture:";

    public static readonly Selector SetReset = "setReset:";
}
