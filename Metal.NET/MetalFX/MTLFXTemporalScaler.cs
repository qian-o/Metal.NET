namespace Metal.NET;

public readonly struct MTLFXTemporalScaler(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLFXTemporalScalerBase(MTLFXTemporalScaler value) => new(value.NativePtr);

    public static implicit operator MTLFXFrameInterpolatableScaler(MTLFXTemporalScaler value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLFXTemporalScaler value) => new(value.NativePtr);

    public MTLFXTemporalScaler Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBindings.ColorTextureUsage);
    }

    public MTLTextureUsage DepthTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBindings.DepthTextureUsage);
    }

    public MTLTextureUsage MotionTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBindings.MotionTextureUsage);
    }

    public MTLTextureUsage ReactiveMaskTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBindings.ReactiveMaskTextureUsage);
    }

    /// <summary>
    /// Deprecated: Use reactiveMaskTextureUsage instead
    /// </summary>
    [Obsolete("Use reactiveMaskTextureUsage instead")]
    public MTLTextureUsage ReactiveTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBindings.ReactiveTextureUsage);
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBindings.OutputTextureUsage);
    }

    public nuint InputContentWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBindings.InputContentWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetInputContentWidth, value);
    }

    public nuint InputContentHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBindings.InputContentHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetInputContentHeight, value);
    }

    public nuint ColorContentOffsetX
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBindings.ColorContentOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetColorContentOffsetX, value);
    }

    public nuint ColorContentOffsetY
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBindings.ColorContentOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetColorContentOffsetY, value);
    }

    public nuint DepthContentOffsetX
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBindings.DepthContentOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetDepthContentOffsetX, value);
    }

    public nuint DepthContentOffsetY
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBindings.DepthContentOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetDepthContentOffsetY, value);
    }

    public nuint MotionContentOffsetX
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBindings.MotionContentOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetMotionContentOffsetX, value);
    }

    public nuint MotionContentOffsetY
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBindings.MotionContentOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetMotionContentOffsetY, value);
    }

    public nuint ReactiveMaskContentOffsetX
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBindings.ReactiveMaskContentOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetReactiveMaskContentOffsetX, value);
    }

    public nuint ReactiveMaskContentOffsetY
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBindings.ReactiveMaskContentOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetReactiveMaskContentOffsetY, value);
    }

    public nuint OutputOffsetX
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBindings.OutputOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetOutputOffsetX, value);
    }

    public nuint OutputOffsetY
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBindings.OutputOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetOutputOffsetY, value);
    }

    public MTLTexture ColorTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalScalerBindings.ColorTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetColorTexture, value.NativePtr);
    }

    public MTLTexture DepthTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalScalerBindings.DepthTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetDepthTexture, value.NativePtr);
    }

    public MTLTexture MotionTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalScalerBindings.MotionTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetMotionTexture, value.NativePtr);
    }

    public MTLTexture OutputTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalScalerBindings.OutputTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetOutputTexture, value.NativePtr);
    }

    public MTLTexture ExposureTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalScalerBindings.ExposureTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetExposureTexture, value.NativePtr);
    }

    public MTLTexture ReactiveMaskTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalScalerBindings.ReactiveMaskTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetReactiveMaskTexture, value.NativePtr);
    }

    public float PreExposure
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerBindings.PreExposure);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetPreExposure, value);
    }

    public float JitterOffsetX
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerBindings.JitterOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetJitterOffsetX, value);
    }

    public float JitterOffsetY
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerBindings.JitterOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetJitterOffsetY, value);
    }

    public float MotionVectorScaleX
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerBindings.MotionVectorScaleX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetMotionVectorScaleX, value);
    }

    public float MotionVectorScaleY
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerBindings.MotionVectorScaleY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetMotionVectorScaleY, value);
    }

    public Bool8 Reset
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalScalerBindings.Reset);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetReset, value);
    }

    public Bool8 IsDepthReversed
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalScalerBindings.IsDepthReversed);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetDepthReversed, value);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBindings.ColorTextureFormat);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBindings.DepthTextureFormat);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBindings.MotionTextureFormat);
    }

    public MTLPixelFormat ReactiveMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBindings.ReactiveMaskTextureFormat);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerBindings.OutputTextureFormat);
    }

    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBindings.InputWidth);
    }

    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBindings.InputHeight);
    }

    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBindings.OutputWidth);
    }

    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBindings.OutputHeight);
    }

    public float InputContentMinScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerBindings.InputContentMinScale);
    }

    public float InputContentMaxScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerBindings.InputContentMaxScale);
    }

    public MTLFence Fence
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalScalerBindings.Fence));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.SetFence, value.NativePtr);
    }

    public void Encode(MTLCommandBuffer commandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTLFXTemporalScalerBindings
{
    public static readonly Selector ColorContentOffsetX = "colorContentOffsetX";

    public static readonly Selector ColorContentOffsetY = "colorContentOffsetY";

    public static readonly Selector ColorTexture = "colorTexture";

    public static readonly Selector ColorTextureFormat = "colorTextureFormat";

    public static readonly Selector ColorTextureUsage = "colorTextureUsage";

    public static readonly Selector DepthContentOffsetX = "depthContentOffsetX";

    public static readonly Selector DepthContentOffsetY = "depthContentOffsetY";

    public static readonly Selector DepthTexture = "depthTexture";

    public static readonly Selector DepthTextureFormat = "depthTextureFormat";

    public static readonly Selector DepthTextureUsage = "depthTextureUsage";

    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";

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

    public static readonly Selector MotionContentOffsetX = "motionContentOffsetX";

    public static readonly Selector MotionContentOffsetY = "motionContentOffsetY";

    public static readonly Selector MotionTexture = "motionTexture";

    public static readonly Selector MotionTextureFormat = "motionTextureFormat";

    public static readonly Selector MotionTextureUsage = "motionTextureUsage";

    public static readonly Selector MotionVectorScaleX = "motionVectorScaleX";

    public static readonly Selector MotionVectorScaleY = "motionVectorScaleY";

    public static readonly Selector OutputHeight = "outputHeight";

    public static readonly Selector OutputOffsetX = "outputOffsetX";

    public static readonly Selector OutputOffsetY = "outputOffsetY";

    public static readonly Selector OutputTexture = "outputTexture";

    public static readonly Selector OutputTextureFormat = "outputTextureFormat";

    public static readonly Selector OutputTextureUsage = "outputTextureUsage";

    public static readonly Selector OutputWidth = "outputWidth";

    public static readonly Selector PreExposure = "preExposure";

    public static readonly Selector ReactiveMaskContentOffsetX = "reactiveMaskContentOffsetX";

    public static readonly Selector ReactiveMaskContentOffsetY = "reactiveMaskContentOffsetY";

    public static readonly Selector ReactiveMaskTexture = "reactiveMaskTexture";

    public static readonly Selector ReactiveMaskTextureFormat = "reactiveMaskTextureFormat";

    public static readonly Selector ReactiveMaskTextureUsage = "reactiveMaskTextureUsage";

    public static readonly Selector ReactiveTextureUsage = "reactiveTextureUsage";

    public static readonly Selector Reset = "reset";

    public static readonly Selector SetColorContentOffsetX = "setColorContentOffsetX:";

    public static readonly Selector SetColorContentOffsetY = "setColorContentOffsetY:";

    public static readonly Selector SetColorTexture = "setColorTexture:";

    public static readonly Selector SetDepthContentOffsetX = "setDepthContentOffsetX:";

    public static readonly Selector SetDepthContentOffsetY = "setDepthContentOffsetY:";

    public static readonly Selector SetDepthReversed = "setDepthReversed:";

    public static readonly Selector SetDepthTexture = "setDepthTexture:";

    public static readonly Selector SetExposureTexture = "setExposureTexture:";

    public static readonly Selector SetFence = "setFence:";

    public static readonly Selector SetInputContentHeight = "setInputContentHeight:";

    public static readonly Selector SetInputContentWidth = "setInputContentWidth:";

    public static readonly Selector SetJitterOffsetX = "setJitterOffsetX:";

    public static readonly Selector SetJitterOffsetY = "setJitterOffsetY:";

    public static readonly Selector SetMotionContentOffsetX = "setMotionContentOffsetX:";

    public static readonly Selector SetMotionContentOffsetY = "setMotionContentOffsetY:";

    public static readonly Selector SetMotionTexture = "setMotionTexture:";

    public static readonly Selector SetMotionVectorScaleX = "setMotionVectorScaleX:";

    public static readonly Selector SetMotionVectorScaleY = "setMotionVectorScaleY:";

    public static readonly Selector SetOutputOffsetX = "setOutputOffsetX:";

    public static readonly Selector SetOutputOffsetY = "setOutputOffsetY:";

    public static readonly Selector SetOutputTexture = "setOutputTexture:";

    public static readonly Selector SetPreExposure = "setPreExposure:";

    public static readonly Selector SetReactiveMaskContentOffsetX = "setReactiveMaskContentOffsetX:";

    public static readonly Selector SetReactiveMaskContentOffsetY = "setReactiveMaskContentOffsetY:";

    public static readonly Selector SetReactiveMaskTexture = "setReactiveMaskTexture:";

    public static readonly Selector SetReset = "setReset:";
}
