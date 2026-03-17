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

    #region Instance Properties - Properties

    /// <summary>
    /// The ratio between width and height of the screen.
    /// </summary>
    public float AspectRatio
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.AspectRatio);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetAspectRatio, value);
    }

    /// <summary>
    /// The color texture that this frame interpolator evaluates.
    /// </summary>
    public MTLTexture ColorTexture
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.ColorTexture);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetColorTexture, value);
    }

    /// <summary>
    /// The pixel format of the input color texture for this frame interpolator.
    /// </summary>
    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.ColorTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input color texture needs in order to support this frame interpolator.
    /// </summary>
    public MTLTextureUsage ColorTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.ColorTextureUsage);
    }

    /// <summary>
    /// The length of the time interval, in seconds, between time of current and previous frame.
    /// </summary>
    public float DeltaTime
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.DeltaTime);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetDeltaTime, value);
    }

    /// <summary>
    /// The depth texture this frame interpolator evaluates.
    /// </summary>
    public MTLTexture DepthTexture
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.DepthTexture);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetDepthTexture, value);
    }

    /// <summary>
    /// The pixel format of the input depth texture for this frame interpolator.
    /// </summary>
    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.DepthTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input depth texture needs in order to support this frame interpolator.
    /// </summary>
    public MTLTextureUsage DepthTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.DepthTextureUsage);
    }

    /// <summary>
    /// The far plane distance that corresponds to the frustrum that renders the scene into the color buffer.
    /// </summary>
    public float FarPlane
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.FarPlane);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetFarPlane, value);
    }

    /// <summary>
    /// An optional fence that this frame interpolator waits for and updates.
    /// </summary>
    public MTLFence Fence
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.Fence);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetFence, value);
    }

    /// <summary>
    /// The vertical field of view angle, in degrees, of the camera that renders the scene into the color buffer.
    /// </summary>
    public float FieldOfView
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.FieldOfView);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetFieldOfView, value);
    }

    /// <summary>
    /// The height, in pixels, of the input color texture for the frame interpolator.
    /// </summary>
    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.InputHeight);
    }

    /// <summary>
    /// The width, in pixels, of the input color texture for the frame interpolator.
    /// </summary>
    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.InputWidth);
    }

    /// <summary>
    /// A Boolean value that indicates whether the depth texture uses zero to represent the farthest distance.
    /// </summary>
    public Bool8 IsDepthReversed
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXFrameInterpolatorBaseBindings.IsDepthReversed);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetDepthReversed, value);
    }

    /// <summary>
    /// A Boolean value that controls whether this frame interpolator interprets the color texture to include your game’s custom UI.
    /// </summary>
    public Bool8 IsUITextureComposited
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXFrameInterpolatorBaseBindings.IsUITextureComposited);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetIsUITextureComposited, value);
    }

    /// <summary>
    /// The horizontal component of the subpixel sampling coordinate you use to generate the color texture input.
    /// </summary>
    public float JitterOffsetX
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.JitterOffsetX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetJitterOffsetX, value);
    }

    /// <summary>
    /// The vertical component of the subpixel sampling coordinate you use to generate the color texture input.
    /// </summary>
    public float JitterOffsetY
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.JitterOffsetY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetJitterOffsetY, value);
    }

    /// <summary>
    /// The motion texture this frame interpolator evaluates.
    /// </summary>
    public MTLTexture MotionTexture
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.MotionTexture);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetMotionTexture, value);
    }

    /// <summary>
    /// The pixel format of the input motion texture for this frame interpolator.
    /// </summary>
    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input motion texture needs in order to support this frame interpolator.
    /// </summary>
    public MTLTextureUsage MotionTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionTextureUsage);
    }

    /// <summary>
    /// The horizontal scale factor the frame interpolator applies to the input motion texture.
    /// </summary>
    public float MotionVectorScaleX
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionVectorScaleX);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetMotionVectorScaleX, value);
    }

    /// <summary>
    /// The vertical scale factor the frame interpolator applies to the input motion texture.
    /// </summary>
    public float MotionVectorScaleY
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.MotionVectorScaleY);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetMotionVectorScaleY, value);
    }

    /// <summary>
    /// The near plane distance that corresponds to the frustrum that renders the scene into the color buffer.
    /// </summary>
    public float NearPlane
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXFrameInterpolatorBaseBindings.NearPlane);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetNearPlane, value);
    }

    /// <summary>
    /// The height, in pixels, of the output color texture for the frame interpolator.
    /// </summary>
    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputHeight);
    }

    /// <summary>
    /// The output texture into which this frame interpolator writes its output.
    /// </summary>
    public MTLTexture OutputTexture
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.OutputTexture);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetOutputTexture, value);
    }

    /// <summary>
    /// The pixel format of the output color texture for this frame interpolator.
    /// </summary>
    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s output color texture needs in order to support this frame interpolator.
    /// </summary>
    public MTLTextureUsage OutputTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputTextureUsage);
    }

    /// <summary>
    /// The width, in pixels, of the output color texture for the frame interpolator.
    /// </summary>
    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorBaseBindings.OutputWidth);
    }

    /// <summary>
    /// The previous color texture for this frame interpolator during the last call to encode work into a command buffer.
    /// </summary>
    public MTLTexture PrevColorTexture
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.PrevColorTexture);
        set => SetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.SetPrevColorTexture, value);
    }

    /// <summary>
    /// A Boolean property indicating whether to reset history.
    /// </summary>
    public Bool8 ShouldResetHistory
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXFrameInterpolatorBaseBindings.ShouldResetHistory);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetShouldResetHistory, value);
    }

    /// <summary>
    /// An optional texture containing your game’s custom UI that this frame interpolator evaluates.
    /// </summary>
    public MTLTexture UiTexture
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorBaseBindings.UiTexture);
    }

    /// <summary>
    /// The pixel format of the input UI texture for the frame interpolator.
    /// </summary>
    public MTLPixelFormat UiTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.UiTextureFormat);
    }

    /// <summary>
    /// The minimal texture usage options that your app’s input UI texture needs in order to support this frame interpolator.
    /// </summary>
    public MTLTextureUsage UiTextureUsage
    {
        get => (MTLTextureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorBaseBindings.UiTextureUsage);
    }
    #endregion

    public void SetUITexture(MTLTexture uiTexture)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorBaseBindings.SetUITexture, uiTexture.NativePtr);
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
