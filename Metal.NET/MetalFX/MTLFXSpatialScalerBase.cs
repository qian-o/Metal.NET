namespace Metal.NET;

public class MTLFXSpatialScalerBase(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLFXSpatialScalerBase>
{
    public static MTLFXSpatialScalerBase Create(nint nativePtr) => new(nativePtr);

    public MTLFXSpatialScalerColorProcessingMode ColorProcessingMode
    {
        get => (MTLFXSpatialScalerColorProcessingMode)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerBaseBindings.ColorProcessingMode);
    }

    public MTLTexture ColorTexture
    {
        get => GetProperty(ref field, MTLFXSpatialScalerBaseBindings.ColorTexture);
        set => SetProperty(ref field, MTLFXSpatialScalerBaseBindings.SetColorTexture, value);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.ColorTextureFormat);
    }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.ColorTextureUsage);
    }

    public MTLFence Fence
    {
        get => GetProperty(ref field, MTLFXSpatialScalerBaseBindings.Fence);
        set => SetProperty(ref field, MTLFXSpatialScalerBaseBindings.SetFence, value);
    }

    public nuint InputContentHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.InputContentHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBaseBindings.SetInputContentHeight, value);
    }

    public nuint InputContentWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.InputContentWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBaseBindings.SetInputContentWidth, value);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.InputHeight);
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.InputWidth);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.OutputHeight);
    }

    public MTLTexture OutputTexture
    {
        get => GetProperty(ref field, MTLFXSpatialScalerBaseBindings.OutputTexture);
        set => SetProperty(ref field, MTLFXSpatialScalerBaseBindings.SetOutputTexture, value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.OutputTextureFormat);
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.OutputTextureUsage);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseBindings.OutputWidth);
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
