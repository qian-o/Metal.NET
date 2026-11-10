namespace Metal.NET;

public readonly struct MTL4FXFrameInterpolator(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLFXFrameInterpolatorBase(MTL4FXFrameInterpolator value) => new(value.NativePtr);

    public static implicit operator NSObject(MTL4FXFrameInterpolator value) => new(value.NativePtr);

    public MTL4FXFrameInterpolator Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXFrameInterpolatorBindings.ColorTextureUsage);
    }

    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXFrameInterpolatorBindings.OutputTextureUsage);
    }

    public MTLTextureUsage DepthTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXFrameInterpolatorBindings.DepthTextureUsage);
    }

    public MTLTextureUsage MotionTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXFrameInterpolatorBindings.MotionTextureUsage);
    }

    public MTLTextureUsage UiTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTL4FXFrameInterpolatorBindings.UiTextureUsage);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXFrameInterpolatorBindings.ColorTextureFormat);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXFrameInterpolatorBindings.DepthTextureFormat);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXFrameInterpolatorBindings.MotionTextureFormat);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXFrameInterpolatorBindings.OutputTextureFormat);
    }

    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXFrameInterpolatorBindings.InputWidth);
    }

    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXFrameInterpolatorBindings.InputHeight);
    }

    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXFrameInterpolatorBindings.OutputWidth);
    }

    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXFrameInterpolatorBindings.OutputHeight);
    }

    public MTLPixelFormat UiTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTL4FXFrameInterpolatorBindings.UiTextureFormat);
    }

    public nuint ContentWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXFrameInterpolatorBindings.ContentWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetContentWidth, value);
    }

    public nuint ContentHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXFrameInterpolatorBindings.ContentHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetContentHeight, value);
    }

    public nuint DepthContentOffsetX
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXFrameInterpolatorBindings.DepthContentOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetDepthContentOffsetX, value);
    }

    public nuint DepthContentOffsetY
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXFrameInterpolatorBindings.DepthContentOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetDepthContentOffsetY, value);
    }

    public nuint MotionContentOffsetX
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXFrameInterpolatorBindings.MotionContentOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetMotionContentOffsetX, value);
    }

    public nuint MotionContentOffsetY
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXFrameInterpolatorBindings.MotionContentOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetMotionContentOffsetY, value);
    }

    public nuint OutputOffsetX
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXFrameInterpolatorBindings.OutputOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetOutputOffsetX, value);
    }

    public nuint OutputOffsetY
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXFrameInterpolatorBindings.OutputOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetOutputOffsetY, value);
    }

    public nuint DistortionOffsetX
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXFrameInterpolatorBindings.DistortionOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetDistortionOffsetX, value);
    }

    public nuint DistortionOffsetY
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXFrameInterpolatorBindings.DistortionOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetDistortionOffsetY, value);
    }

    public nuint DistortionWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXFrameInterpolatorBindings.DistortionWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetDistortionWidth, value);
    }

    public nuint DistortionHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4FXFrameInterpolatorBindings.DistortionHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetDistortionHeight, value);
    }

    public MTLTexture ColorTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXFrameInterpolatorBindings.ColorTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetColorTexture, value.NativePtr);
    }

    public MTLTexture PrevColorTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXFrameInterpolatorBindings.PrevColorTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetPrevColorTexture, value.NativePtr);
    }

    public MTLTexture DepthTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXFrameInterpolatorBindings.DepthTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetDepthTexture, value.NativePtr);
    }

    public MTLTexture MotionTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXFrameInterpolatorBindings.MotionTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetMotionTexture, value.NativePtr);
    }

    public float MotionVectorScaleX
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4FXFrameInterpolatorBindings.MotionVectorScaleX);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetMotionVectorScaleX, value);
    }

    public float MotionVectorScaleY
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4FXFrameInterpolatorBindings.MotionVectorScaleY);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetMotionVectorScaleY, value);
    }

    public float DeltaTime
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4FXFrameInterpolatorBindings.DeltaTime);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetDeltaTime, value);
    }

    public float NearPlane
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4FXFrameInterpolatorBindings.NearPlane);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetNearPlane, value);
    }

    public float FarPlane
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4FXFrameInterpolatorBindings.FarPlane);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetFarPlane, value);
    }

    public float FieldOfView
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4FXFrameInterpolatorBindings.FieldOfView);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetFieldOfView, value);
    }

    public float AspectRatio
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4FXFrameInterpolatorBindings.AspectRatio);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetAspectRatio, value);
    }

    public SimdFloat4x4 WorldToViewMatrix
    {
        get => ObjectiveC.MsgSendSimdFloat4x4(NativePtr, MTL4FXFrameInterpolatorBindings.WorldToViewMatrix);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetWorldToViewMatrix, value);
    }

    public SimdFloat4x4 ViewToClipMatrix
    {
        get => ObjectiveC.MsgSendSimdFloat4x4(NativePtr, MTL4FXFrameInterpolatorBindings.ViewToClipMatrix);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetViewToClipMatrix, value);
    }

    public MTLTexture UiTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXFrameInterpolatorBindings.UiTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetUITexture, value.NativePtr);
    }

    public float JitterOffsetX
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4FXFrameInterpolatorBindings.JitterOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetJitterOffsetX, value);
    }

    public float JitterOffsetY
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTL4FXFrameInterpolatorBindings.JitterOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetJitterOffsetY, value);
    }

    public Bool8 IsUITextureComposited
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4FXFrameInterpolatorBindings.IsUITextureComposited);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetIsUITextureComposited, value);
    }

    public Bool8 ShouldResetHistory
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4FXFrameInterpolatorBindings.ShouldResetHistory);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetShouldResetHistory, value);
    }

    public MTLTexture OutputTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXFrameInterpolatorBindings.OutputTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetOutputTexture, value.NativePtr);
    }

    public MTLTexture DistortionTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXFrameInterpolatorBindings.DistortionTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetDistortionTexture, value.NativePtr);
    }

    public MTLFence Fence
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTL4FXFrameInterpolatorBindings.Fence));
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetFence, value.NativePtr);
    }

    public Bool8 IsDepthReversed
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTL4FXFrameInterpolatorBindings.IsDepthReversed);
        set => ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.SetDepthReversed, value);
    }

    public void Encode(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTL4FXFrameInterpolatorBindings
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

    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";

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
