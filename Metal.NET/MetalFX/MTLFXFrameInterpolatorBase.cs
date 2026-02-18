namespace Metal.NET;

public partial class MTLFXFrameInterpolatorBase : NativeObject
{
    public MTLFXFrameInterpolatorBase(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseSelector.ColorTextureUsage);
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseSelector.OutputTextureUsage);
    }

    public MTLTextureUsage DepthTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseSelector.DepthTextureUsage);
    }

    public MTLTextureUsage MotionTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseSelector.MotionTextureUsage);
    }

    public MTLTextureUsage UiTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseSelector.UiTextureFormat);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseSelector.ColorTextureFormat);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseSelector.DepthTextureFormat);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseSelector.MotionTextureFormat);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseSelector.OutputTextureFormat);
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseSelector.InputWidth);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseSelector.InputHeight);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseSelector.OutputWidth);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseSelector.OutputHeight);
    }

    public MTLPixelFormat UiTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseSelector.UiTextureFormat);
    }

    public MTLTexture? ColorTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorBaseSelector.ColorTexture);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetColorTexture, value?.NativePtr ?? 0);
    }

    public MTLTexture? PrevColorTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorBaseSelector.PrevColorTexture);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetPrevColorTexture, value?.NativePtr ?? 0);
    }

    public MTLTexture? DepthTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorBaseSelector.DepthTexture);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetDepthTexture, value?.NativePtr ?? 0);
    }

    public MTLTexture? MotionTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorBaseSelector.MotionTexture);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetMotionTexture, value?.NativePtr ?? 0);
    }

    public float MotionVectorScaleX
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseSelector.MotionVectorScaleX);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetMotionVectorScaleX, value);
    }

    public float MotionVectorScaleY
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseSelector.MotionVectorScaleY);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetMotionVectorScaleY, value);
    }

    public float DeltaTime
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseSelector.DeltaTime);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetDeltaTime, value);
    }

    public float NearPlane
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseSelector.NearPlane);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetNearPlane, value);
    }

    public float FarPlane
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseSelector.FarPlane);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetFarPlane, value);
    }

    public float FieldOfView
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseSelector.FieldOfView);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetFieldOfView, value);
    }

    public float AspectRatio
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseSelector.AspectRatio);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetAspectRatio, value);
    }

    public MTLTexture? UiTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorBaseSelector.UiTexture);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public float JitterOffsetX
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseSelector.JitterOffsetX);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetJitterOffsetX, value);
    }

    public float JitterOffsetY
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseSelector.JitterOffsetY);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetJitterOffsetY, value);
    }

    public bool IsUITextureComposited
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXFrameInterpolatorBaseSelector.IsUITextureComposited);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetIsUITextureComposited, (Bool8)value);
    }

    public bool ShouldResetHistory
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXFrameInterpolatorBaseSelector.ShouldResetHistory);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetShouldResetHistory, (Bool8)value);
    }

    public MTLTexture? OutputTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorBaseSelector.OutputTexture);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetOutputTexture, value?.NativePtr ?? 0);
    }

    public MTLFence? Fence
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorBaseSelector.Fence);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetFence, value?.NativePtr ?? 0);
    }

    public bool IsDepthReversed
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXFrameInterpolatorBaseSelector.IsDepthReversed);
    }

    public void SetUITexture(MTLTexture uiTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetUITexture, uiTexture.NativePtr);
    }

    public void SetDepthReversed(bool depthReversed)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseSelector.SetDepthReversed, (Bool8)depthReversed);
    }
}

file static class MTLFXFrameInterpolatorBaseSelector
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

    public static readonly Selector SetDepthReversed = Selector.Register("setDepthReversed:");

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

    public static readonly Selector SetUITexture = Selector.Register("setUITexture:");

    public static readonly Selector ShouldResetHistory = Selector.Register("shouldResetHistory");

    public static readonly Selector UiTexture = Selector.Register("uiTexture");

    public static readonly Selector UiTextureFormat = Selector.Register("uiTextureFormat");
}
