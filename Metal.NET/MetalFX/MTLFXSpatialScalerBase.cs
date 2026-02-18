namespace Metal.NET;

public class MTLFXSpatialScalerBase(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLFXSpatialScalerColorProcessingMode ColorProcessingMode
    {
        get => (MTLFXSpatialScalerColorProcessingMode)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerBaseSelector.ColorProcessingMode);
    }

    public MTLTexture? ColorTexture
    {
        get => GetNullableObject<MTLTexture>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerBaseSelector.ColorTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetColorTexture, value?.NativePtr ?? 0);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseSelector.ColorTextureFormat);
    }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseSelector.ColorTextureUsage);
    }

    public MTLFence? Fence
    {
        get => GetNullableObject<MTLFence>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerBaseSelector.Fence));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetFence, value?.NativePtr ?? 0);
    }

    public nuint InputContentHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseSelector.InputContentHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetInputContentHeight, value);
    }

    public nuint InputContentWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseSelector.InputContentWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetInputContentWidth, value);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseSelector.InputHeight);
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseSelector.InputWidth);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseSelector.OutputHeight);
    }

    public MTLTexture? OutputTexture
    {
        get => GetNullableObject<MTLTexture>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerBaseSelector.OutputTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetOutputTexture, value?.NativePtr ?? 0);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseSelector.OutputTextureFormat);
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseSelector.OutputTextureUsage);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseSelector.OutputWidth);
    }
}

file static class MTLFXSpatialScalerBaseSelector
{
    public static readonly Selector ColorProcessingMode = Selector.Register("colorProcessingMode");

    public static readonly Selector ColorTexture = Selector.Register("colorTexture");

    public static readonly Selector ColorTextureFormat = Selector.Register("colorTextureFormat");

    public static readonly Selector ColorTextureUsage = Selector.Register("colorTextureUsage");

    public static readonly Selector Fence = Selector.Register("fence");

    public static readonly Selector InputContentHeight = Selector.Register("inputContentHeight");

    public static readonly Selector InputContentWidth = Selector.Register("inputContentWidth");

    public static readonly Selector InputHeight = Selector.Register("inputHeight");

    public static readonly Selector InputWidth = Selector.Register("inputWidth");

    public static readonly Selector OutputHeight = Selector.Register("outputHeight");

    public static readonly Selector OutputTexture = Selector.Register("outputTexture");

    public static readonly Selector OutputTextureFormat = Selector.Register("outputTextureFormat");

    public static readonly Selector OutputTextureUsage = Selector.Register("outputTextureUsage");

    public static readonly Selector OutputWidth = Selector.Register("outputWidth");

    public static readonly Selector SetColorTexture = Selector.Register("setColorTexture:");

    public static readonly Selector SetFence = Selector.Register("setFence:");

    public static readonly Selector SetInputContentHeight = Selector.Register("setInputContentHeight:");

    public static readonly Selector SetInputContentWidth = Selector.Register("setInputContentWidth:");

    public static readonly Selector SetOutputTexture = Selector.Register("setOutputTexture:");
}
