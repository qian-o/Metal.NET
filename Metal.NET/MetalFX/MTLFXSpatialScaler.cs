namespace Metal.NET;

public readonly struct MTLFXSpatialScaler(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLFXSpatialScalerBase(MTLFXSpatialScaler value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLFXSpatialScaler value) => new(value.NativePtr);

    public MTLFXSpatialScaler Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXSpatialScalerBindings.ColorTextureUsage);
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXSpatialScalerBindings.OutputTextureUsage);
    }

    public nuint InputContentWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBindings.InputContentWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerBindings.SetInputContentWidth, value);
    }

    public nuint InputContentHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBindings.InputContentHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerBindings.SetInputContentHeight, value);
    }

    public MTLTexture ColorTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXSpatialScalerBindings.ColorTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerBindings.SetColorTexture, value.NativePtr);
    }

    public MTLTexture OutputTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXSpatialScalerBindings.OutputTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerBindings.SetOutputTexture, value.NativePtr);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXSpatialScalerBindings.ColorTextureFormat);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXSpatialScalerBindings.OutputTextureFormat);
    }

    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBindings.InputWidth);
    }

    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBindings.InputHeight);
    }

    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBindings.OutputWidth);
    }

    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerBindings.OutputHeight);
    }

    public MTLFXSpatialScalerColorProcessingMode ColorProcessingMode
    {
        get => (MTLFXSpatialScalerColorProcessingMode)ObjectiveC.MsgSendLong(NativePtr, MTLFXSpatialScalerBindings.ColorProcessingMode);
    }

    public MTLFence Fence
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXSpatialScalerBindings.Fence));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerBindings.SetFence, value.NativePtr);
    }

    public void Encode(MTLCommandBuffer commandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTLFXSpatialScalerBindings
{
    public static readonly Selector ColorProcessingMode = "colorProcessingMode";

    public static readonly Selector ColorTexture = "colorTexture";

    public static readonly Selector ColorTextureFormat = "colorTextureFormat";

    public static readonly Selector ColorTextureUsage = "colorTextureUsage";

    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";

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
