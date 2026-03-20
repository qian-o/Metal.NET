namespace Metal.NET;

public partial class MTLFXSpatialScalerBase(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFXSpatialScalerBase>
{
    #region INativeObject
    public static new MTLFXSpatialScalerBase Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXSpatialScalerBase New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXSpatialScalerBaseBindings.ColorTextureUsage);
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXSpatialScalerBaseBindings.OutputTextureUsage);
    }

    public nuint InputContentWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.InputContentWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerBaseBindings.SetInputContentWidth, value);
    }

    public nuint InputContentHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.InputContentHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerBaseBindings.SetInputContentHeight, value);
    }

    public MTLTexture ColorTexture
    {
        get => GetProperty(ref field, MTLFXSpatialScalerBaseBindings.ColorTexture);
        set => SetProperty(ref field, MTLFXSpatialScalerBaseBindings.SetColorTexture, value);
    }

    public MTLTexture OutputTexture
    {
        get => GetProperty(ref field, MTLFXSpatialScalerBaseBindings.OutputTexture);
        set => SetProperty(ref field, MTLFXSpatialScalerBaseBindings.SetOutputTexture, value);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXSpatialScalerBaseBindings.ColorTextureFormat);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXSpatialScalerBaseBindings.OutputTextureFormat);
    }

    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.InputWidth);
    }

    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.InputHeight);
    }

    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.OutputWidth);
    }

    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.OutputHeight);
    }

    public MTLFXSpatialScalerColorProcessingMode ColorProcessingMode
    {
        get => (MTLFXSpatialScalerColorProcessingMode)ObjectiveC.MsgSendLong(NativePtr, MTLFXSpatialScalerBaseBindings.ColorProcessingMode);
    }

    public MTLFence Fence
    {
        get => GetProperty(ref field, MTLFXSpatialScalerBaseBindings.Fence);
        set => SetProperty(ref field, MTLFXSpatialScalerBaseBindings.SetFence, value);
    }
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
