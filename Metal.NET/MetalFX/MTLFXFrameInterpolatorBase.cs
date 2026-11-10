namespace Metal.NET;

public readonly struct MTLFXFrameInterpolatorBase(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLFXFrameInterpolatorBase value) => new(value.NativePtr);

    public MTLFXFrameInterpolatorBase Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.ColorTextureUsage);
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputTextureUsage);
    }

    public MTLTextureUsage DepthTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.DepthTextureUsage);
    }

    public MTLTextureUsage MotionTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionTextureUsage);
    }

    public MTLTextureUsage UiTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.UiTextureUsage);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.ColorTextureFormat);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.DepthTextureFormat);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionTextureFormat);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputTextureFormat);
    }

    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.InputWidth);
    }

    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.InputHeight);
    }

    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputWidth);
    }

    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputHeight);
    }

    public MTLPixelFormat UiTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.UiTextureFormat);
    }

    public nuint ContentWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.ContentWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetContentWidth, value);
    }

    public nuint ContentHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.ContentHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetContentHeight, value);
    }

    public nuint DepthContentOffsetX
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.DepthContentOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetDepthContentOffsetX, value);
    }

    public nuint DepthContentOffsetY
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.DepthContentOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetDepthContentOffsetY, value);
    }

    public nuint MotionContentOffsetX
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionContentOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetMotionContentOffsetX, value);
    }

    public nuint MotionContentOffsetY
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionContentOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetMotionContentOffsetY, value);
    }

    public nuint OutputOffsetX
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetOutputOffsetX, value);
    }

    public nuint OutputOffsetY
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetOutputOffsetY, value);
    }

    public nuint DistortionOffsetX
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.DistortionOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetDistortionOffsetX, value);
    }

    public nuint DistortionOffsetY
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.DistortionOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetDistortionOffsetY, value);
    }

    public nuint DistortionWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.DistortionWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetDistortionWidth, value);
    }

    public nuint DistortionHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.DistortionHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetDistortionHeight, value);
    }

    public MTLTexture ColorTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.ColorTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetColorTexture, value.NativePtr);
    }

    public MTLTexture PrevColorTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.PrevColorTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetPrevColorTexture, value.NativePtr);
    }

    public MTLTexture DepthTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.DepthTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetDepthTexture, value.NativePtr);
    }

    public MTLTexture MotionTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetMotionTexture, value.NativePtr);
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

    public float DeltaTime
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.DeltaTime);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetDeltaTime, value);
    }

    public float NearPlane
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.NearPlane);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetNearPlane, value);
    }

    public float FarPlane
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.FarPlane);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetFarPlane, value);
    }

    public float FieldOfView
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.FieldOfView);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetFieldOfView, value);
    }

    public float AspectRatio
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.AspectRatio);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetAspectRatio, value);
    }

    public SimdFloat4x4 WorldToViewMatrix
    {
        get => ObjectiveC.MsgSendSimdFloat4x4(NativePtr, MTLFXFrameInterpolatorBaseBindings.WorldToViewMatrix);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetWorldToViewMatrix, value);
    }

    public SimdFloat4x4 ViewToClipMatrix
    {
        get => ObjectiveC.MsgSendSimdFloat4x4(NativePtr, MTLFXFrameInterpolatorBaseBindings.ViewToClipMatrix);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetViewToClipMatrix, value);
    }

    public MTLTexture UiTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.UiTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetUITexture, value.NativePtr);
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

    public Bool8 IsUITextureComposited
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXFrameInterpolatorBaseBindings.IsUITextureComposited);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetIsUITextureComposited, value);
    }

    public Bool8 ShouldResetHistory
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXFrameInterpolatorBaseBindings.ShouldResetHistory);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetShouldResetHistory, value);
    }

    public MTLTexture OutputTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetOutputTexture, value.NativePtr);
    }

    public MTLTexture DistortionTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.DistortionTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetDistortionTexture, value.NativePtr);
    }

    public MTLFence Fence
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.Fence));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetFence, value.NativePtr);
    }

    public Bool8 IsDepthReversed
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXFrameInterpolatorBaseBindings.IsDepthReversed);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetDepthReversed, value);
    }
}

file static class MTLFXFrameInterpolatorBaseBindings
{
    public static readonly Selector AspectRatio = "aspectRatio";

    public static readonly Selector ColorTexture = "colorTexture";

    public static readonly Selector ColorTextureFormat = "colorTextureFormat";

    public static readonly Selector ColorTextureUsage = "colorTextureUsage";

    public static readonly Selector ContentHeight = "contentHeight";

    public static readonly Selector ContentWidth = "contentWidth";

    public static readonly Selector DeltaTime = "deltaTime";

    public static readonly Selector DepthContentOffsetX = "depthContentOffsetX";

    public static readonly Selector DepthContentOffsetY = "depthContentOffsetY";

    public static readonly Selector DepthTexture = "depthTexture";

    public static readonly Selector DepthTextureFormat = "depthTextureFormat";

    public static readonly Selector DepthTextureUsage = "depthTextureUsage";

    public static readonly Selector DistortionHeight = "distortionHeight";

    public static readonly Selector DistortionOffsetX = "distortionOffsetX";

    public static readonly Selector DistortionOffsetY = "distortionOffsetY";

    public static readonly Selector DistortionTexture = "distortionTexture";

    public static readonly Selector DistortionWidth = "distortionWidth";

    public static readonly Selector FarPlane = "farPlane";

    public static readonly Selector Fence = "fence";

    public static readonly Selector FieldOfView = "fieldOfView";

    public static readonly Selector InputHeight = "inputHeight";

    public static readonly Selector InputWidth = "inputWidth";

    public static readonly Selector IsDepthReversed = "isDepthReversed";

    public static readonly Selector IsUITextureComposited = "isUITextureComposited";

    public static readonly Selector JitterOffsetX = "jitterOffsetX";

    public static readonly Selector JitterOffsetY = "jitterOffsetY";

    public static readonly Selector MotionContentOffsetX = "motionContentOffsetX";

    public static readonly Selector MotionContentOffsetY = "motionContentOffsetY";

    public static readonly Selector MotionTexture = "motionTexture";

    public static readonly Selector MotionTextureFormat = "motionTextureFormat";

    public static readonly Selector MotionTextureUsage = "motionTextureUsage";

    public static readonly Selector MotionVectorScaleX = "motionVectorScaleX";

    public static readonly Selector MotionVectorScaleY = "motionVectorScaleY";

    public static readonly Selector NearPlane = "nearPlane";

    public static readonly Selector OutputHeight = "outputHeight";

    public static readonly Selector OutputOffsetX = "outputOffsetX";

    public static readonly Selector OutputOffsetY = "outputOffsetY";

    public static readonly Selector OutputTexture = "outputTexture";

    public static readonly Selector OutputTextureFormat = "outputTextureFormat";

    public static readonly Selector OutputTextureUsage = "outputTextureUsage";

    public static readonly Selector OutputWidth = "outputWidth";

    public static readonly Selector PrevColorTexture = "prevColorTexture";

    public static readonly Selector SetAspectRatio = "setAspectRatio:";

    public static readonly Selector SetColorTexture = "setColorTexture:";

    public static readonly Selector SetContentHeight = "setContentHeight:";

    public static readonly Selector SetContentWidth = "setContentWidth:";

    public static readonly Selector SetDeltaTime = "setDeltaTime:";

    public static readonly Selector SetDepthContentOffsetX = "setDepthContentOffsetX:";

    public static readonly Selector SetDepthContentOffsetY = "setDepthContentOffsetY:";

    public static readonly Selector SetDepthReversed = "setDepthReversed:";

    public static readonly Selector SetDepthTexture = "setDepthTexture:";

    public static readonly Selector SetDistortionHeight = "setDistortionHeight:";

    public static readonly Selector SetDistortionOffsetX = "setDistortionOffsetX:";

    public static readonly Selector SetDistortionOffsetY = "setDistortionOffsetY:";

    public static readonly Selector SetDistortionTexture = "setDistortionTexture:";

    public static readonly Selector SetDistortionWidth = "setDistortionWidth:";

    public static readonly Selector SetFarPlane = "setFarPlane:";

    public static readonly Selector SetFence = "setFence:";

    public static readonly Selector SetFieldOfView = "setFieldOfView:";

    public static readonly Selector SetIsUITextureComposited = "setIsUITextureComposited:";

    public static readonly Selector SetJitterOffsetX = "setJitterOffsetX:";

    public static readonly Selector SetJitterOffsetY = "setJitterOffsetY:";

    public static readonly Selector SetMotionContentOffsetX = "setMotionContentOffsetX:";

    public static readonly Selector SetMotionContentOffsetY = "setMotionContentOffsetY:";

    public static readonly Selector SetMotionTexture = "setMotionTexture:";

    public static readonly Selector SetMotionVectorScaleX = "setMotionVectorScaleX:";

    public static readonly Selector SetMotionVectorScaleY = "setMotionVectorScaleY:";

    public static readonly Selector SetNearPlane = "setNearPlane:";

    public static readonly Selector SetOutputOffsetX = "setOutputOffsetX:";

    public static readonly Selector SetOutputOffsetY = "setOutputOffsetY:";

    public static readonly Selector SetOutputTexture = "setOutputTexture:";

    public static readonly Selector SetPrevColorTexture = "setPrevColorTexture:";

    public static readonly Selector SetShouldResetHistory = "setShouldResetHistory:";

    public static readonly Selector SetUITexture = "setUITexture:";

    public static readonly Selector SetViewToClipMatrix = "setViewToClipMatrix:";

    public static readonly Selector SetWorldToViewMatrix = "setWorldToViewMatrix:";

    public static readonly Selector ShouldResetHistory = "shouldResetHistory";

    public static readonly Selector UiTexture = "uiTexture";

    public static readonly Selector UiTextureFormat = "uiTextureFormat";

    public static readonly Selector UiTextureUsage = "uiTextureUsage";

    public static readonly Selector ViewToClipMatrix = "viewToClipMatrix";

    public static readonly Selector WorldToViewMatrix = "worldToViewMatrix";
}
