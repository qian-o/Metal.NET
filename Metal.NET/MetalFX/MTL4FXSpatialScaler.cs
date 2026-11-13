namespace Metal.NET;

public readonly struct MTL4FXSpatialScaler(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLFXSpatialScalerBase(MTL4FXSpatialScaler value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4FXSpatialScaler value) => new(value.NativePtr);

    public MTL4FXSpatialScaler Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXSpatialScalerBindings.ColorTextureUsage);
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXSpatialScalerBindings.OutputTextureUsage);
    }

    public nuint InputContentWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXSpatialScalerBindings.InputContentWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXSpatialScalerBindings.SetInputContentWidth, value);
    }

    public nuint InputContentHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXSpatialScalerBindings.InputContentHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXSpatialScalerBindings.SetInputContentHeight, value);
    }

    public MTLTexture ColorTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXSpatialScalerBindings.ColorTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXSpatialScalerBindings.SetColorTexture, value.NativePtr);
    }

    public MTLTexture OutputTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXSpatialScalerBindings.OutputTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXSpatialScalerBindings.SetOutputTexture, value.NativePtr);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXSpatialScalerBindings.ColorTextureFormat);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXSpatialScalerBindings.OutputTextureFormat);
    }

    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXSpatialScalerBindings.InputWidth);
    }

    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXSpatialScalerBindings.InputHeight);
    }

    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXSpatialScalerBindings.OutputWidth);
    }

    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXSpatialScalerBindings.OutputHeight);
    }

    public MTLFXSpatialScalerColorProcessingMode ColorProcessingMode
    {
        get => (MTLFXSpatialScalerColorProcessingMode)ObjectiveC.MsgSendLong(NativePtr, MTL4FXSpatialScalerBindings.ColorProcessingMode);
    }

    public MTLFence Fence
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXSpatialScalerBindings.Fence));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXSpatialScalerBindings.SetFence, value.NativePtr);
    }

    public void Encode(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4FXSpatialScalerBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTL4FXSpatialScalerBindings
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
