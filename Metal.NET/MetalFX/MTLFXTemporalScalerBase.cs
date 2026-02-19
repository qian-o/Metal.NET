namespace Metal.NET;

public class MTLFXTemporalScalerBase(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLTexture? ColorTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerBaseBindings.ColorTexture);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLTexture(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetColorTexture, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.ColorTextureFormat);
    }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.ColorTextureUsage);
    }

    public MTLTexture? DepthTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerBaseBindings.DepthTexture);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLTexture(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetDepthTexture, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.DepthTextureFormat);
    }

    public MTLTextureUsage DepthTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.DepthTextureUsage);
    }

    public MTLTexture? ExposureTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerBaseBindings.ExposureTexture);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLTexture(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetExposureTexture, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLFence? Fence
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerBaseBindings.Fence);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLFence(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetFence, value?.NativePtr ?? 0);
            field = value;
        }
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

    public bool IsDepthReversed
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

    public MTLTexture? MotionTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerBaseBindings.MotionTexture);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLTexture(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetMotionTexture, value?.NativePtr ?? 0);
            field = value;
        }
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

    public MTLTexture? OutputTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerBaseBindings.OutputTexture);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLTexture(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetOutputTexture, value?.NativePtr ?? 0);
            field = value;
        }
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

    public MTLTexture? ReactiveMaskTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerBaseBindings.ReactiveMaskTexture);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLTexture(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetReactiveMaskTexture, value?.NativePtr ?? 0);
            field = value;
        }
    }

    public MTLPixelFormat ReactiveTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.ReactiveTextureFormat);
    }

    public MTLTextureUsage ReactiveTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerBaseBindings.ReactiveTextureUsage);
    }

    public bool Reset
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalScalerBaseBindings.Reset);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBaseBindings.SetReset, (Bool8)value);
    }
}

file static class MTLFXTemporalScalerBaseBindings
{
    public static readonly Selector ColorTexture = Selector.Register("colorTexture");

    public static readonly Selector ColorTextureFormat = Selector.Register("colorTextureFormat");

    public static readonly Selector ColorTextureUsage = Selector.Register("colorTextureUsage");

    public static readonly Selector DepthTexture = Selector.Register("depthTexture");

    public static readonly Selector DepthTextureFormat = Selector.Register("depthTextureFormat");

    public static readonly Selector DepthTextureUsage = Selector.Register("depthTextureUsage");

    public static readonly Selector ExposureTexture = Selector.Register("exposureTexture");

    public static readonly Selector Fence = Selector.Register("fence");

    public static readonly Selector InputContentHeight = Selector.Register("inputContentHeight");

    public static readonly Selector InputContentMaxScale = Selector.Register("inputContentMaxScale");

    public static readonly Selector InputContentMinScale = Selector.Register("inputContentMinScale");

    public static readonly Selector InputContentWidth = Selector.Register("inputContentWidth");

    public static readonly Selector InputHeight = Selector.Register("inputHeight");

    public static readonly Selector InputWidth = Selector.Register("inputWidth");

    public static readonly Selector IsDepthReversed = Selector.Register("isDepthReversed");

    public static readonly Selector JitterOffsetX = Selector.Register("jitterOffsetX");

    public static readonly Selector JitterOffsetY = Selector.Register("jitterOffsetY");

    public static readonly Selector MotionTexture = Selector.Register("motionTexture");

    public static readonly Selector MotionTextureFormat = Selector.Register("motionTextureFormat");

    public static readonly Selector MotionTextureUsage = Selector.Register("motionTextureUsage");

    public static readonly Selector MotionVectorScaleX = Selector.Register("motionVectorScaleX");

    public static readonly Selector MotionVectorScaleY = Selector.Register("motionVectorScaleY");

    public static readonly Selector OutputHeight = Selector.Register("outputHeight");

    public static readonly Selector OutputTexture = Selector.Register("outputTexture");

    public static readonly Selector OutputTextureFormat = Selector.Register("outputTextureFormat");

    public static readonly Selector OutputTextureUsage = Selector.Register("outputTextureUsage");

    public static readonly Selector OutputWidth = Selector.Register("outputWidth");

    public static readonly Selector PreExposure = Selector.Register("preExposure");

    public static readonly Selector ReactiveMaskTexture = Selector.Register("reactiveMaskTexture");

    public static readonly Selector ReactiveTextureFormat = Selector.Register("reactiveTextureFormat");

    public static readonly Selector ReactiveTextureUsage = Selector.Register("reactiveTextureUsage");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector SetColorTexture = Selector.Register("setColorTexture:");

    public static readonly Selector SetDepthTexture = Selector.Register("setDepthTexture:");

    public static readonly Selector SetExposureTexture = Selector.Register("setExposureTexture:");

    public static readonly Selector SetFence = Selector.Register("setFence:");

    public static readonly Selector SetInputContentHeight = Selector.Register("setInputContentHeight:");

    public static readonly Selector SetInputContentWidth = Selector.Register("setInputContentWidth:");

    public static readonly Selector SetJitterOffsetX = Selector.Register("setJitterOffsetX:");

    public static readonly Selector SetJitterOffsetY = Selector.Register("setJitterOffsetY:");

    public static readonly Selector SetMotionTexture = Selector.Register("setMotionTexture:");

    public static readonly Selector SetMotionVectorScaleX = Selector.Register("setMotionVectorScaleX:");

    public static readonly Selector SetMotionVectorScaleY = Selector.Register("setMotionVectorScaleY:");

    public static readonly Selector SetOutputTexture = Selector.Register("setOutputTexture:");

    public static readonly Selector SetPreExposure = Selector.Register("setPreExposure:");

    public static readonly Selector SetReactiveMaskTexture = Selector.Register("setReactiveMaskTexture:");

    public static readonly Selector SetReset = Selector.Register("setReset:");
}
