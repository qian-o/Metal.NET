namespace Metal.NET;

public class MTLFXFrameInterpolatorBase(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public float AspectRatio
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.AspectRatio);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetAspectRatio, value);
    }

    public MTLTexture? ColorTexture
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.ColorTexture);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetColorTexture, value);
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
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.DepthTexture);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetDepthTexture, value);
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
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.Fence);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetFence, value);
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
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.MotionTexture);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetMotionTexture, value);
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
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.OutputTexture);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetOutputTexture, value);
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
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.PrevColorTexture);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetPrevColorTexture, value);
    }

    public bool ShouldResetHistory
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXFrameInterpolatorBaseBindings.ShouldResetHistory);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetShouldResetHistory, (Bool8)value);
    }

    public MTLTexture? UiTexture
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.UiTexture);
    }

    public MTLPixelFormat UiTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.UiTextureFormat);
    }

    public MTLTextureUsage UiTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.UiTextureUsage);
    }

    public void SetUITexture(MTLTexture uiTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetUITexture, uiTexture.NativePtr);
    }

    public void SetDepthReversed(bool depthReversed)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetDepthReversed, (Bool8)depthReversed);
    }
}

file static class MTLFXFrameInterpolatorBaseBindings
{
    public static readonly Selector AspectRatio = "aspectRatio";

    public static readonly Selector ColorTexture = "colorTexture";

    public static readonly Selector ColorTextureFormat = "colorTextureFormat";

    public static readonly Selector ColorTextureUsage = "colorTextureUsage";

    public static readonly Selector DeltaTime = "deltaTime";

    public static readonly Selector DepthTexture = "depthTexture";

    public static readonly Selector DepthTextureFormat = "depthTextureFormat";

    public static readonly Selector DepthTextureUsage = "depthTextureUsage";

    public static readonly Selector FarPlane = "farPlane";

    public static readonly Selector Fence = "fence";

    public static readonly Selector FieldOfView = "fieldOfView";

    public static readonly Selector InputHeight = "inputHeight";

    public static readonly Selector InputWidth = "inputWidth";

    public static readonly Selector IsDepthReversed = "isDepthReversed";

    public static readonly Selector IsUITextureComposited = "isUITextureComposited";

    public static readonly Selector JitterOffsetX = "jitterOffsetX";

    public static readonly Selector JitterOffsetY = "jitterOffsetY";

    public static readonly Selector MotionTexture = "motionTexture";

    public static readonly Selector MotionTextureFormat = "motionTextureFormat";

    public static readonly Selector MotionTextureUsage = "motionTextureUsage";

    public static readonly Selector MotionVectorScaleX = "motionVectorScaleX";

    public static readonly Selector MotionVectorScaleY = "motionVectorScaleY";

    public static readonly Selector NearPlane = "nearPlane";

    public static readonly Selector OutputHeight = "outputHeight";

    public static readonly Selector OutputTexture = "outputTexture";

    public static readonly Selector OutputTextureFormat = "outputTextureFormat";

    public static readonly Selector OutputTextureUsage = "outputTextureUsage";

    public static readonly Selector OutputWidth = "outputWidth";

    public static readonly Selector PrevColorTexture = "prevColorTexture";

    public static readonly Selector SetAspectRatio = "setAspectRatio:";

    public static readonly Selector SetColorTexture = "setColorTexture:";

    public static readonly Selector SetDeltaTime = "setDeltaTime:";

    public static readonly Selector SetDepthReversed = "setDepthReversed:";

    public static readonly Selector SetDepthTexture = "setDepthTexture:";

    public static readonly Selector SetFarPlane = "setFarPlane:";

    public static readonly Selector SetFence = "setFence:";

    public static readonly Selector SetFieldOfView = "setFieldOfView:";

    public static readonly Selector SetIsUITextureComposited = "setIsUITextureComposited:";

    public static readonly Selector SetJitterOffsetX = "setJitterOffsetX:";

    public static readonly Selector SetJitterOffsetY = "setJitterOffsetY:";

    public static readonly Selector SetMotionTexture = "setMotionTexture:";

    public static readonly Selector SetMotionVectorScaleX = "setMotionVectorScaleX:";

    public static readonly Selector SetMotionVectorScaleY = "setMotionVectorScaleY:";

    public static readonly Selector SetNearPlane = "setNearPlane:";

    public static readonly Selector SetOutputTexture = "setOutputTexture:";

    public static readonly Selector SetPrevColorTexture = "setPrevColorTexture:";

    public static readonly Selector SetShouldResetHistory = "setShouldResetHistory:";

    public static readonly Selector SetUITexture = "setUITexture:";

    public static readonly Selector ShouldResetHistory = "shouldResetHistory";

    public static readonly Selector UiTexture = "uiTexture";

    public static readonly Selector UiTextureFormat = "uiTextureFormat";

    public static readonly Selector UiTextureUsage = "uiTextureFormat";
}
