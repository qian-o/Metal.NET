namespace Metal.NET;

public class MTLFXTemporalScalerBase(nint nativePtr, bool ownsReference) : MTLFXFrameInterpolatableScaler(nativePtr, ownsReference), INativeObject<MTLFXTemporalScalerBase>
{
    public static new MTLFXTemporalScalerBase Null { get; } = new(0, false);

    public static new MTLFXTemporalScalerBase Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLTexture ColorTexture
    {
        get => GetProperty(ref field, MTLFXTemporalScalerBaseBindings.ColorTexture);
        set => SetProperty(ref field, MTLFXTemporalScalerBaseBindings.SetColorTexture, value);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.ColorTextureFormat);
    }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.ColorTextureUsage);
    }

    public MTLTexture DepthTexture
    {
        get => GetProperty(ref field, MTLFXTemporalScalerBaseBindings.DepthTexture);
        set => SetProperty(ref field, MTLFXTemporalScalerBaseBindings.SetDepthTexture, value);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.DepthTextureFormat);
    }

    public MTLTextureUsage DepthTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.DepthTextureUsage);
    }

    public MTLTexture ExposureTexture
    {
        get => GetProperty(ref field, MTLFXTemporalScalerBaseBindings.ExposureTexture);
        set => SetProperty(ref field, MTLFXTemporalScalerBaseBindings.SetExposureTexture, value);
    }

    public MTLFence Fence
    {
        get => GetProperty(ref field, MTLFXTemporalScalerBaseBindings.Fence);
        set => SetProperty(ref field, MTLFXTemporalScalerBaseBindings.SetFence, value);
    }

    public nuint InputContentHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.InputContentHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetInputContentHeight, value);
    }

    public float InputContentMaxScale
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseBindings.InputContentMaxScale);
    }

    public float InputContentMinScale
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseBindings.InputContentMinScale);
    }

    public nuint InputContentWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.InputContentWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetInputContentWidth, value);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.InputHeight);
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.InputWidth);
    }

    public Bool8 IsDepthReversed
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalScalerBaseBindings.IsDepthReversed);
    }

    public float JitterOffsetX
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseBindings.JitterOffsetX);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetJitterOffsetX, value);
    }

    public float JitterOffsetY
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseBindings.JitterOffsetY);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetJitterOffsetY, value);
    }

    public MTLTexture MotionTexture
    {
        get => GetProperty(ref field, MTLFXTemporalScalerBaseBindings.MotionTexture);
        set => SetProperty(ref field, MTLFXTemporalScalerBaseBindings.SetMotionTexture, value);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.MotionTextureFormat);
    }

    public MTLTextureUsage MotionTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.MotionTextureUsage);
    }

    public float MotionVectorScaleX
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseBindings.MotionVectorScaleX);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetMotionVectorScaleX, value);
    }

    public float MotionVectorScaleY
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseBindings.MotionVectorScaleY);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetMotionVectorScaleY, value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.OutputHeight);
    }

    public MTLTexture OutputTexture
    {
        get => GetProperty(ref field, MTLFXTemporalScalerBaseBindings.OutputTexture);
        set => SetProperty(ref field, MTLFXTemporalScalerBaseBindings.SetOutputTexture, value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.OutputTextureFormat);
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.OutputTextureUsage);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.OutputWidth);
    }

    public float PreExposure
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseBindings.PreExposure);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetPreExposure, value);
    }

    public MTLTexture ReactiveMaskTexture
    {
        get => GetProperty(ref field, MTLFXTemporalScalerBaseBindings.ReactiveMaskTexture);
        set => SetProperty(ref field, MTLFXTemporalScalerBaseBindings.SetReactiveMaskTexture, value);
    }

    public MTLPixelFormat ReactiveTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.ReactiveTextureFormat);
    }

    public MTLTextureUsage ReactiveTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.ReactiveTextureUsage);
    }

    public Bool8 Reset
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalScalerBaseBindings.Reset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetReset, value);
    }

    public void SetDepthReversed(bool depthReversed)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetDepthReversed, (Bool8)depthReversed);
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
