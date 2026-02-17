namespace Metal.NET;

public class MTLFXSpatialScalerBase : IDisposable
{
    public MTLFXSpatialScalerBase(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFXSpatialScalerBase()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXSpatialScalerBaseSelector.ColorTextureUsage));
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXSpatialScalerBaseSelector.OutputTextureUsage));
    }

    public nuint InputContentWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseSelector.InputContentWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetInputContentWidth, value);
    }

    public nuint InputContentHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseSelector.InputContentHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetInputContentHeight, value);
    }

    public MTLTexture ColorTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerBaseSelector.ColorTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetColorTexture, value.NativePtr);
    }

    public MTLTexture OutputTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerBaseSelector.OutputTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetOutputTexture, value.NativePtr);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXSpatialScalerBaseSelector.ColorTextureFormat));
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXSpatialScalerBaseSelector.OutputTextureFormat));
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseSelector.InputWidth);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseSelector.InputHeight);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseSelector.OutputWidth);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBaseSelector.OutputHeight);
    }

    public MTLFXSpatialScalerColorProcessingMode ColorProcessingMode
    {
        get => (MTLFXSpatialScalerColorProcessingMode)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXSpatialScalerBaseSelector.ColorProcessingMode));
    }

    public MTLFence Fence
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerBaseSelector.Fence));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerBaseSelector.SetFence, value.NativePtr);
    }

    public static implicit operator nint(MTLFXSpatialScalerBase value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXSpatialScalerBase(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLFXSpatialScalerBaseSelector
{
    public static readonly Selector ColorTextureUsage = Selector.Register("colorTextureUsage");

    public static readonly Selector OutputTextureUsage = Selector.Register("outputTextureUsage");

    public static readonly Selector InputContentWidth = Selector.Register("inputContentWidth");

    public static readonly Selector SetInputContentWidth = Selector.Register("setInputContentWidth:");

    public static readonly Selector InputContentHeight = Selector.Register("inputContentHeight");

    public static readonly Selector SetInputContentHeight = Selector.Register("setInputContentHeight:");

    public static readonly Selector ColorTexture = Selector.Register("colorTexture");

    public static readonly Selector SetColorTexture = Selector.Register("setColorTexture:");

    public static readonly Selector OutputTexture = Selector.Register("outputTexture");

    public static readonly Selector SetOutputTexture = Selector.Register("setOutputTexture:");

    public static readonly Selector ColorTextureFormat = Selector.Register("colorTextureFormat");

    public static readonly Selector OutputTextureFormat = Selector.Register("outputTextureFormat");

    public static readonly Selector InputWidth = Selector.Register("inputWidth");

    public static readonly Selector InputHeight = Selector.Register("inputHeight");

    public static readonly Selector OutputWidth = Selector.Register("outputWidth");

    public static readonly Selector OutputHeight = Selector.Register("outputHeight");

    public static readonly Selector ColorProcessingMode = Selector.Register("colorProcessingMode");

    public static readonly Selector Fence = Selector.Register("fence");

    public static readonly Selector SetFence = Selector.Register("setFence:");
}
