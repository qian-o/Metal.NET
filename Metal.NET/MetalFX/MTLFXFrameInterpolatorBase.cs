namespace Metal.NET;

public class MTLFXFrameInterpolatorBase(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFXFrameInterpolatorBase>
{
    #region INativeObject
    public static new MTLFXFrameInterpolatorBase Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXFrameInterpolatorBase New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public float AspectRatio
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.AspectRatio);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetAspectRatio, value);
    }

    public MTLTexture ColorTexture
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.ColorTexture);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetColorTexture, value);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.ColorTextureFormat);
    }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.ColorTextureUsage);
    }

    public float DeltaTime
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.DeltaTime);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetDeltaTime, value);
    }

    public MTLTexture DepthTexture
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.DepthTexture);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetDepthTexture, value);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.DepthTextureFormat);
    }

    public MTLTextureUsage DepthTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.DepthTextureUsage);
    }

    public float FarPlane
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.FarPlane);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetFarPlane, value);
    }

    public MTLFence Fence
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.Fence);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetFence, value);
    }

    public float FieldOfView
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.FieldOfView);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetFieldOfView, value);
    }

    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.InputHeight);
    }

    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.InputWidth);
    }

    public Bool8 IsDepthReversed
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXFrameInterpolatorBaseBindings.IsDepthReversed);
    }

    public Bool8 IsUITextureComposited
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXFrameInterpolatorBaseBindings.IsUITextureComposited);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetIsUITextureComposited, value);
    }

    public float JitterOffsetX
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.JitterOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetJitterOffsetX, value);
    }

    public float JitterOffsetY
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.JitterOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetJitterOffsetY, value);
    }

    public MTLTexture MotionTexture
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.MotionTexture);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetMotionTexture, value);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionTextureFormat);
    }

    public MTLTextureUsage MotionTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionTextureUsage);
    }

    public float MotionVectorScaleX
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionVectorScaleX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetMotionVectorScaleX, value);
    }

    public float MotionVectorScaleY
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionVectorScaleY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetMotionVectorScaleY, value);
    }

    public float NearPlane
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.NearPlane);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetNearPlane, value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputHeight);
    }

    public MTLTexture OutputTexture
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.OutputTexture);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetOutputTexture, value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputTextureFormat);
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputTextureUsage);
    }

    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputWidth);
    }

    public MTLTexture PrevColorTexture
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.PrevColorTexture);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetPrevColorTexture, value);
    }

    public Bool8 ShouldResetHistory
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXFrameInterpolatorBaseBindings.ShouldResetHistory);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetShouldResetHistory, value);
    }

    public MTLTexture UiTexture
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.UiTexture);
    }

    public MTLPixelFormat UiTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.UiTextureFormat);
    }

    public MTLTextureUsage UiTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.UiTextureUsage);
    }

    public void SetUITexture(MTLTexture uiTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetUITexture, uiTexture.NativePtr);
    }

    public void SetDepthReversed(bool depthReversed)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetDepthReversed, (Bool8)depthReversed);
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
