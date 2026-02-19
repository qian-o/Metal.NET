namespace Metal.NET;

public readonly struct MTLFXFrameInterpolatorBase(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public float AspectRatio
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.AspectRatio);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetAspectRatio, value);
    }

    public MTLTexture? ColorTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorBaseBindings.ColorTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetColorTexture, value?.NativePtr ?? 0);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.ColorTextureFormat);
    }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.ColorTextureUsage);
    }

    public float DeltaTime
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.DeltaTime);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetDeltaTime, value);
    }

    public MTLTexture? DepthTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorBaseBindings.DepthTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetDepthTexture, value?.NativePtr ?? 0);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.DepthTextureFormat);
    }

    public MTLTextureUsage DepthTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.DepthTextureUsage);
    }

    public float FarPlane
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.FarPlane);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetFarPlane, value);
    }

    public MTLFence? Fence
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorBaseBindings.Fence);
            return ptr is not 0 ? new MTLFence(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetFence, value?.NativePtr ?? 0);
    }

    public float FieldOfView
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.FieldOfView);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetFieldOfView, value);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.InputHeight);
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.InputWidth);
    }

    public bool IsDepthReversed
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXFrameInterpolatorBaseBindings.IsDepthReversed);
    }

    public bool IsUITextureComposited
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXFrameInterpolatorBaseBindings.IsUITextureComposited);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetIsUITextureComposited, (Bool8)value);
    }

    public float JitterOffsetX
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.JitterOffsetX);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetJitterOffsetX, value);
    }

    public float JitterOffsetY
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.JitterOffsetY);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetJitterOffsetY, value);
    }

    public MTLTexture? MotionTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetMotionTexture, value?.NativePtr ?? 0);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionTextureFormat);
    }

    public MTLTextureUsage MotionTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionTextureUsage);
    }

    public float MotionVectorScaleX
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionVectorScaleX);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetMotionVectorScaleX, value);
    }

    public float MotionVectorScaleY
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionVectorScaleY);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetMotionVectorScaleY, value);
    }

    public float NearPlane
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.NearPlane);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetNearPlane, value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputHeight);
    }

    public MTLTexture? OutputTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetOutputTexture, value?.NativePtr ?? 0);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputTextureFormat);
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputTextureUsage);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputWidth);
    }

    public MTLTexture? PrevColorTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorBaseBindings.PrevColorTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetPrevColorTexture, value?.NativePtr ?? 0);
    }

    public bool ShouldResetHistory
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXFrameInterpolatorBaseBindings.ShouldResetHistory);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetShouldResetHistory, (Bool8)value);
    }

    public MTLTexture? UiTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorBaseBindings.UiTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
    }

    public MTLPixelFormat UiTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.UiTextureFormat);
    }

    public MTLTextureUsage UiTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.UiTextureUsage);
    }
}

file static class MTLFXFrameInterpolatorBaseBindings
{
    public static readonly Selector AspectRatio = Selector.Register("aspectRatio");

    public static readonly Selector ColorTexture = Selector.Register("colorTexture");

    public static readonly Selector ColorTextureFormat = Selector.Register("colorTextureFormat");

    public static readonly Selector ColorTextureUsage = Selector.Register("colorTextureUsage");

    public static readonly Selector DeltaTime = Selector.Register("deltaTime");

    public static readonly Selector DepthTexture = Selector.Register("depthTexture");

    public static readonly Selector DepthTextureFormat = Selector.Register("depthTextureFormat");

    public static readonly Selector DepthTextureUsage = Selector.Register("depthTextureUsage");

    public static readonly Selector FarPlane = Selector.Register("farPlane");

    public static readonly Selector Fence = Selector.Register("fence");

    public static readonly Selector FieldOfView = Selector.Register("fieldOfView");

    public static readonly Selector InputHeight = Selector.Register("inputHeight");

    public static readonly Selector InputWidth = Selector.Register("inputWidth");

    public static readonly Selector IsDepthReversed = Selector.Register("isDepthReversed");

    public static readonly Selector IsUITextureComposited = Selector.Register("isUITextureComposited");

    public static readonly Selector JitterOffsetX = Selector.Register("jitterOffsetX");

    public static readonly Selector JitterOffsetY = Selector.Register("jitterOffsetY");

    public static readonly Selector MotionTexture = Selector.Register("motionTexture");

    public static readonly Selector MotionTextureFormat = Selector.Register("motionTextureFormat");

    public static readonly Selector MotionTextureUsage = Selector.Register("motionTextureUsage");

    public static readonly Selector MotionVectorScaleX = Selector.Register("motionVectorScaleX");

    public static readonly Selector MotionVectorScaleY = Selector.Register("motionVectorScaleY");

    public static readonly Selector NearPlane = Selector.Register("nearPlane");

    public static readonly Selector OutputHeight = Selector.Register("outputHeight");

    public static readonly Selector OutputTexture = Selector.Register("outputTexture");

    public static readonly Selector OutputTextureFormat = Selector.Register("outputTextureFormat");

    public static readonly Selector OutputTextureUsage = Selector.Register("outputTextureUsage");

    public static readonly Selector OutputWidth = Selector.Register("outputWidth");

    public static readonly Selector PrevColorTexture = Selector.Register("prevColorTexture");

    public static readonly Selector SetAspectRatio = Selector.Register("setAspectRatio:");

    public static readonly Selector SetColorTexture = Selector.Register("setColorTexture:");

    public static readonly Selector SetDeltaTime = Selector.Register("setDeltaTime:");

    public static readonly Selector SetDepthTexture = Selector.Register("setDepthTexture:");

    public static readonly Selector SetFarPlane = Selector.Register("setFarPlane:");

    public static readonly Selector SetFence = Selector.Register("setFence:");

    public static readonly Selector SetFieldOfView = Selector.Register("setFieldOfView:");

    public static readonly Selector SetIsUITextureComposited = Selector.Register("setIsUITextureComposited:");

    public static readonly Selector SetJitterOffsetX = Selector.Register("setJitterOffsetX:");

    public static readonly Selector SetJitterOffsetY = Selector.Register("setJitterOffsetY:");

    public static readonly Selector SetMotionTexture = Selector.Register("setMotionTexture:");

    public static readonly Selector SetMotionVectorScaleX = Selector.Register("setMotionVectorScaleX:");

    public static readonly Selector SetMotionVectorScaleY = Selector.Register("setMotionVectorScaleY:");

    public static readonly Selector SetNearPlane = Selector.Register("setNearPlane:");

    public static readonly Selector SetOutputTexture = Selector.Register("setOutputTexture:");

    public static readonly Selector SetPrevColorTexture = Selector.Register("setPrevColorTexture:");

    public static readonly Selector SetShouldResetHistory = Selector.Register("setShouldResetHistory:");

    public static readonly Selector ShouldResetHistory = Selector.Register("shouldResetHistory");

    public static readonly Selector UiTexture = Selector.Register("uiTexture");

    public static readonly Selector UiTextureFormat = Selector.Register("uiTextureFormat");

    public static readonly Selector UiTextureUsage = Selector.Register("uiTextureFormat");
}
