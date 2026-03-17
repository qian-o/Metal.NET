namespace Metal.NET;

/// <summary>
/// A set of properties that configure a frame interpolator, and a factory method that creates the effect.
/// </summary>
public class MTLFXFrameInterpolatorDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFXFrameInterpolatorDescriptor>
{
    #region INativeObject
    public static new MTLFXFrameInterpolatorDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXFrameInterpolatorDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFXFrameInterpolatorDescriptor() : this(ObjectiveC.AllocInit(MTLFXFrameInterpolatorDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// The pixel format of the input color texture for the frame interpolator you create with this descriptor.
    /// </summary>
    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.ColorTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetColorTextureFormat, (nuint)value);
    }

    /// <summary>
    /// The pixel format of the input depth texture for the frame interpolator you create with this descriptor.
    /// </summary>
    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.DepthTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetDepthTextureFormat, (nuint)value);
    }

    /// <summary>
    /// The height, in pixels, of the input motion and depth texture for the frame interpolator.
    /// </summary>
    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.InputHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetInputHeight, value);
    }

    /// <summary>
    /// The width, in pixels, of the input motion and depth texture for the frame interpolator.
    /// </summary>
    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.InputWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetInputWidth, value);
    }

    /// <summary>
    /// The pixel format of the input motion texture for the frame interpolator you create with this descriptor.
    /// </summary>
    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.MotionTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetMotionTextureFormat, (nuint)value);
    }

    /// <summary>
    /// The height, in pixels, of the output color texture for the frame interpolator.
    /// </summary>
    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.OutputHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetOutputHeight, value);
    }

    /// <summary>
    /// The pixel format of the output color texture for the frame interpolator you create with this descriptor.
    /// </summary>
    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.OutputTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetOutputTextureFormat, (nuint)value);
    }

    /// <summary>
    /// The width, in pixels, of the output color texture for the frame interpolator.
    /// </summary>
    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.OutputWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetOutputWidth, value);
    }

    public MTLFXFrameInterpolatableScaler Scaler
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorDescriptorBindings.Scaler);
        set => SetProperty(ref field, MTLFXFrameInterpolatorDescriptorBindings.SetScaler, value);
    }

    /// <summary>
    /// The pixel format for the frame interpolator of an input texture containing your game’s custom UI.
    /// </summary>
    public MTLPixelFormat UiTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.UiTextureFormat);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>
    /// Creates a frame interpolator instance for a Metal device.
    /// </summary>
    public MTLFXFrameInterpolator NewFrameInterpolator(MTLDevice pDevice)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.NewFrameInterpolator, pDevice.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a frame interpolator instance for a Metal device.
    /// </summary>
    public MTL4FXFrameInterpolator NewFrameInterpolator(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.NewFrameInterpolatorWithDevicecompiler, pDevice.NativePtr, pCompiler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Type Methods - Methods

    /// <summary>
    /// Queries whether a Metal device supports frame interpolation.
    /// </summary>
    public static bool SupportsDevice(MTLDevice device)
    {
        return ObjectiveC.MsgSendBool(MTLFXFrameInterpolatorDescriptorBindings.Class, MTLFXFrameInterpolatorDescriptorBindings.SupportsDevice, device.NativePtr);
    }

    /// <summary>
    /// Queries whether a Metal device supports frame interpolation compatible with a Metal 4 command buffer.
    /// </summary>
    public static bool SupportsMetal4FX(MTLDevice device)
    {
        return ObjectiveC.MsgSendBool(MTLFXFrameInterpolatorDescriptorBindings.Class, MTLFXFrameInterpolatorDescriptorBindings.SupportsMetal4FX, device.NativePtr);
    }
    #endregion

    public void SetUITextureFormat(MTLPixelFormat uiTextureFormat)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetUITextureFormat, (nuint)uiTextureFormat);
    }
}

file static class MTLFXFrameInterpolatorDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFXFrameInterpolatorDescriptor");

    public static readonly Selector ColorTextureFormat = "colorTextureFormat";

    public static readonly Selector DepthTextureFormat = "depthTextureFormat";

    public static readonly Selector InputHeight = "inputHeight";

    public static readonly Selector InputWidth = "inputWidth";

    public static readonly Selector MotionTextureFormat = "motionTextureFormat";

    public static readonly Selector NewFrameInterpolator = "newFrameInterpolatorWithDevice:";

    public static readonly Selector NewFrameInterpolatorWithDevicecompiler = "newFrameInterpolatorWithDevice:compiler:";

    public static readonly Selector OutputHeight = "outputHeight";

    public static readonly Selector OutputTextureFormat = "outputTextureFormat";

    public static readonly Selector OutputWidth = "outputWidth";

    public static readonly Selector Scaler = "scaler";

    public static readonly Selector SetColorTextureFormat = "setColorTextureFormat:";

    public static readonly Selector SetDepthTextureFormat = "setDepthTextureFormat:";

    public static readonly Selector SetInputHeight = "setInputHeight:";

    public static readonly Selector SetInputWidth = "setInputWidth:";

    public static readonly Selector SetMotionTextureFormat = "setMotionTextureFormat:";

    public static readonly Selector SetOutputHeight = "setOutputHeight:";

    public static readonly Selector SetOutputTextureFormat = "setOutputTextureFormat:";

    public static readonly Selector SetOutputWidth = "setOutputWidth:";

    public static readonly Selector SetScaler = "setScaler:";

    public static readonly Selector SetUITextureFormat = "setUITextureFormat:";

    public static readonly Selector SupportsDevice = "supportsDevice:";

    public static readonly Selector SupportsMetal4FX = "supportsMetal4FX:";

    public static readonly Selector UiTextureFormat = "uiTextureFormat";
}
