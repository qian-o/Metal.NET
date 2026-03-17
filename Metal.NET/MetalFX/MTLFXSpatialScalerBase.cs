namespace Metal.NET;

/// <summary>
/// An upscaling effect that generates a higher resolution texture in a render pass by spatially analyzing an input texture.
/// </summary>
public class MTLFXSpatialScalerBase(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFXSpatialScalerBase>
{
    #region INativeObject
    public static new MTLFXSpatialScalerBase Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXSpatialScalerBase New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>
    /// The color processing mode you set in this spatial scaler’s descriptor.
    /// </summary>
    public MTLFXSpatialScalerColorProcessingMode ColorProcessingMode
    {
        get => (MTLFXSpatialScalerColorProcessingMode)ObjectiveC.MsgSendLong(NativePtr, MTLFXSpatialScalerBaseBindings.ColorProcessingMode);
    }

    /// <summary>
    /// Input color texture you set for the scaler that supports the correct color texture usage options.
    /// </summary>
    public MTLTexture ColorTexture
    {
        get => GetProperty(ref field, MTLFXSpatialScalerBaseBindings.ColorTexture);
        set => SetProperty(ref field, MTLFXSpatialScalerBaseBindings.SetColorTexture, value);
    }

    /// <summary>
    /// The pixel format of the input color texture for this this scaler.
    /// </summary>
    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXSpatialScalerBaseBindings.ColorTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input color texture needs in order to support this scaler.
    /// </summary>
    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXSpatialScalerBaseBindings.ColorTextureUsage);
    }

    /// <summary>
    /// An optional fence that you provide to synchronize your app’s untracked resources.
    /// </summary>
    public MTLFence Fence
    {
        get => GetProperty(ref field, MTLFXSpatialScalerBaseBindings.Fence);
        set => SetProperty(ref field, MTLFXSpatialScalerBaseBindings.SetFence, value);
    }

    /// <summary>
    /// The height, in pixels, of the region within the color texture the scaler uses as its input.
    /// </summary>
    public nuint InputContentHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.InputContentHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerBaseBindings.SetInputContentHeight, value);
    }

    /// <summary>
    /// The width, in pixels, of the region within the color texture the scaler uses as its input.
    /// </summary>
    public nuint InputContentWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.InputContentWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerBaseBindings.SetInputContentWidth, value);
    }

    /// <summary>
    /// The height, in pixels, of the input color texture for this scaler.
    /// </summary>
    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.InputHeight);
    }

    /// <summary>
    /// The width, in pixels, of the input color texture for this scaler.
    /// </summary>
    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.InputWidth);
    }

    /// <summary>
    /// The height, in pixels, of the output color texture for this scaler.
    /// </summary>
    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.OutputHeight);
    }

    /// <summary>
    /// The output texture into which this scaler writes its output.
    /// </summary>
    public MTLTexture OutputTexture
    {
        get => GetProperty(ref field, MTLFXSpatialScalerBaseBindings.OutputTexture);
        set => SetProperty(ref field, MTLFXSpatialScalerBaseBindings.SetOutputTexture, value);
    }

    /// <summary>
    /// The pixel format of the output color texture for this this scaler.
    /// </summary>
    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXSpatialScalerBaseBindings.OutputTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s output color texture needs in order to support this scaler.
    /// </summary>
    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXSpatialScalerBaseBindings.OutputTextureUsage);
    }

    /// <summary>
    /// The width, in pixels, of the output color texture for this scaler.
    /// </summary>
    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.OutputWidth);
    }
    #endregion
}

file static class MTLFXSpatialScalerBaseBindings
{
    public static readonly Selector ColorProcessingMode = "colorProcessingMode";

    public static readonly Selector ColorTexture = "colorTexture";

    public static readonly Selector ColorTextureFormat = "colorTextureFormat";

    public static readonly Selector ColorTextureUsage = "colorTextureUsage";

    public static readonly Selector Fence = "fence";

    public static readonly Selector InputContentHeight = "inputContentHeight";

    public static readonly Selector InputContentWidth = "inputContentWidth";

    public static readonly Selector InputHeight = "inputHeight";

    public static readonly Selector InputWidth = "inputWidth";

    public static readonly Selector OutputHeight = "outputHeight";

    public static readonly Selector OutputTexture = "outputTexture";

    public static readonly Selector OutputTextureFormat = "outputTextureFormat";

    public static readonly Selector OutputTextureUsage = "outputTextureUsage";

    public static readonly Selector OutputWidth = "outputWidth";

    public static readonly Selector SetColorTexture = "setColorTexture:";

    public static readonly Selector SetFence = "setFence:";

    public static readonly Selector SetInputContentHeight = "setInputContentHeight:";

    public static readonly Selector SetInputContentWidth = "setInputContentWidth:";

    public static readonly Selector SetOutputTexture = "setOutputTexture:";
}
