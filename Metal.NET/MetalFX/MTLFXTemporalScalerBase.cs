namespace Metal.NET;

public class MTLFXTemporalScalerBase : IDisposable
{
    public MTLFXTemporalScalerBase(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLFXTemporalScalerBase()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalScalerBaseSelector.ColorTextureUsage));
    }

    public MTLTextureUsage DepthTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalScalerBaseSelector.DepthTextureUsage));
    }

    public MTLTextureUsage MotionTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalScalerBaseSelector.MotionTextureUsage));
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalScalerBaseSelector.OutputTextureUsage));
    }

    public nuint InputContentWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseSelector.InputContentWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetInputContentWidth, value);
    }

    public nuint InputContentHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseSelector.InputContentHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetInputContentHeight, value);
    }

    public MTLTexture ColorTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerBaseSelector.ColorTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetColorTexture, value.NativePtr);
    }

    public MTLTexture DepthTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerBaseSelector.DepthTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetDepthTexture, value.NativePtr);
    }

    public MTLTexture MotionTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerBaseSelector.MotionTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetMotionTexture, value.NativePtr);
    }

    public MTLTexture OutputTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerBaseSelector.OutputTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetOutputTexture, value.NativePtr);
    }

    public MTLTexture ExposureTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerBaseSelector.ExposureTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetExposureTexture, value.NativePtr);
    }

    public float PreExposure
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseSelector.PreExposure);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetPreExposure, value);
    }

    public float JitterOffsetX
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseSelector.JitterOffsetX);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetJitterOffsetX, value);
    }

    public float JitterOffsetY
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseSelector.JitterOffsetY);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetJitterOffsetY, value);
    }

    public float MotionVectorScaleX
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseSelector.MotionVectorScaleX);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetMotionVectorScaleX, value);
    }

    public float MotionVectorScaleY
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseSelector.MotionVectorScaleY);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetMotionVectorScaleY, value);
    }

    public MTLTexture ReactiveMaskTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerBaseSelector.ReactiveMaskTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetReactiveMaskTexture, value.NativePtr);
    }

    public MTLTextureUsage ReactiveTextureUsage
    {
        get => (MTLTextureUsage)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalScalerBaseSelector.ReactiveTextureUsage));
    }

    public Bool8 Reset
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalScalerBaseSelector.Reset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetReset, value);
    }

    public Bool8 IsDepthReversed
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalScalerBaseSelector.IsDepthReversed);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalScalerBaseSelector.ColorTextureFormat));
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalScalerBaseSelector.DepthTextureFormat));
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalScalerBaseSelector.MotionTextureFormat));
    }

    public MTLPixelFormat ReactiveTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalScalerBaseSelector.ReactiveTextureFormat));
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalScalerBaseSelector.OutputTextureFormat));
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseSelector.InputWidth);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseSelector.InputHeight);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseSelector.OutputWidth);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseSelector.OutputHeight);
    }

    public float InputContentMinScale
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseSelector.InputContentMinScale);
    }

    public float InputContentMaxScale
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerBaseSelector.InputContentMaxScale);
    }

    public MTLFence Fence
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerBaseSelector.Fence));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetFence, value.NativePtr);
    }

    public void SetDepthReversed(Bool8 depthReversed)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseSelector.SetDepthReversed, depthReversed);
    }

    public static implicit operator nint(MTLFXTemporalScalerBase value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXTemporalScalerBase(nint value)
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

file class MTLFXTemporalScalerBaseSelector
{
    public static readonly Selector ColorTextureUsage = Selector.Register("colorTextureUsage");

    public static readonly Selector DepthTextureUsage = Selector.Register("depthTextureUsage");

    public static readonly Selector MotionTextureUsage = Selector.Register("motionTextureUsage");

    public static readonly Selector OutputTextureUsage = Selector.Register("outputTextureUsage");

    public static readonly Selector InputContentWidth = Selector.Register("inputContentWidth");

    public static readonly Selector SetInputContentWidth = Selector.Register("setInputContentWidth:");

    public static readonly Selector InputContentHeight = Selector.Register("inputContentHeight");

    public static readonly Selector SetInputContentHeight = Selector.Register("setInputContentHeight:");

    public static readonly Selector ColorTexture = Selector.Register("colorTexture");

    public static readonly Selector SetColorTexture = Selector.Register("setColorTexture:");

    public static readonly Selector DepthTexture = Selector.Register("depthTexture");

    public static readonly Selector SetDepthTexture = Selector.Register("setDepthTexture:");

    public static readonly Selector MotionTexture = Selector.Register("motionTexture");

    public static readonly Selector SetMotionTexture = Selector.Register("setMotionTexture:");

    public static readonly Selector OutputTexture = Selector.Register("outputTexture");

    public static readonly Selector SetOutputTexture = Selector.Register("setOutputTexture:");

    public static readonly Selector ExposureTexture = Selector.Register("exposureTexture");

    public static readonly Selector SetExposureTexture = Selector.Register("setExposureTexture:");

    public static readonly Selector PreExposure = Selector.Register("preExposure");

    public static readonly Selector SetPreExposure = Selector.Register("setPreExposure:");

    public static readonly Selector JitterOffsetX = Selector.Register("jitterOffsetX");

    public static readonly Selector SetJitterOffsetX = Selector.Register("setJitterOffsetX:");

    public static readonly Selector JitterOffsetY = Selector.Register("jitterOffsetY");

    public static readonly Selector SetJitterOffsetY = Selector.Register("setJitterOffsetY:");

    public static readonly Selector MotionVectorScaleX = Selector.Register("motionVectorScaleX");

    public static readonly Selector SetMotionVectorScaleX = Selector.Register("setMotionVectorScaleX:");

    public static readonly Selector MotionVectorScaleY = Selector.Register("motionVectorScaleY");

    public static readonly Selector SetMotionVectorScaleY = Selector.Register("setMotionVectorScaleY:");

    public static readonly Selector ReactiveMaskTexture = Selector.Register("reactiveMaskTexture");

    public static readonly Selector SetReactiveMaskTexture = Selector.Register("setReactiveMaskTexture:");

    public static readonly Selector ReactiveTextureUsage = Selector.Register("reactiveTextureUsage");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetReset = Selector.Register("setReset:");

    public static readonly Selector IsDepthReversed = Selector.Register("isDepthReversed");

    public static readonly Selector ColorTextureFormat = Selector.Register("colorTextureFormat");

    public static readonly Selector DepthTextureFormat = Selector.Register("depthTextureFormat");

    public static readonly Selector MotionTextureFormat = Selector.Register("motionTextureFormat");

    public static readonly Selector ReactiveTextureFormat = Selector.Register("reactiveTextureFormat");

    public static readonly Selector OutputTextureFormat = Selector.Register("outputTextureFormat");

    public static readonly Selector InputWidth = Selector.Register("inputWidth");

    public static readonly Selector InputHeight = Selector.Register("inputHeight");

    public static readonly Selector OutputWidth = Selector.Register("outputWidth");

    public static readonly Selector OutputHeight = Selector.Register("outputHeight");

    public static readonly Selector InputContentMinScale = Selector.Register("inputContentMinScale");

    public static readonly Selector InputContentMaxScale = Selector.Register("inputContentMaxScale");

    public static readonly Selector Fence = Selector.Register("fence");

    public static readonly Selector SetFence = Selector.Register("setFence:");

    public static readonly Selector SetDepthReversed = Selector.Register("setDepthReversed:");
}
