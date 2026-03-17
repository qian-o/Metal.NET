namespace Metal.NET;

/// <summary>
/// A set of properties that configure a temporal scaling effect, and a factory method that creates the effect.
/// </summary>
public class MTLFXTemporalScalerDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFXTemporalScalerDescriptor>
{
    #region INativeObject
    public static new MTLFXTemporalScalerDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXTemporalScalerDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFXTemporalScalerDescriptor() : this(ObjectiveC.AllocInit(MTLFXTemporalScalerDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Configuring a temporal effect’s input - Properties

    /// <summary>
    /// The width of the input color texture for the temporal scaler you create with this descriptor.
    /// </summary>
    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.InputWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputWidth, value);
    }

    /// <summary>
    /// The height of the input color texture for the temporal scaler you create with this descriptor.
    /// </summary>
    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.InputHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputHeight, value);
    }

    /// <summary>
    /// A Boolean value that indicates whether the temporal scaler you create with this descriptor uses dynamic resolution.
    /// </summary>
    public Bool8 IsInputContentPropertiesEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorBindings.IsInputContentPropertiesEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputContentPropertiesEnabled, value);
    }

    /// <summary>
    /// The smallest scale factor the temporal scaler you create with this descriptor can use to generate output textures.
    /// </summary>
    public float InputContentMinScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerDescriptorBindings.InputContentMinScale);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputContentMinScale, value);
    }

    /// <summary>
    /// The largest scale factor the temporal scaler you create with this descriptor can use to generate output textures.
    /// </summary>
    public float InputContentMaxScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerDescriptorBindings.InputContentMaxScale);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputContentMaxScale, value);
    }

    /// <summary>
    /// The pixel format of the input color texture for the temporal scaler you create with this descriptor.
    /// </summary>
    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerDescriptorBindings.ColorTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetColorTextureFormat, (nuint)value);
    }

    /// <summary>
    /// The pixel format of the input motion texture for the temporal scaler you create with this descriptor.
    /// </summary>
    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerDescriptorBindings.MotionTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetMotionTextureFormat, (nuint)value);
    }

    /// <summary>
    /// The pixel format of the input depth texture for the temporal scaler you create with this descriptor.
    /// </summary>
    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerDescriptorBindings.DepthTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetDepthTextureFormat, (nuint)value);
    }

    /// <summary>
    /// A Boolean value that indicates whether MetalFX calculates the exposure for each frame.
    /// </summary>
    public Bool8 IsAutoExposureEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorBindings.IsAutoExposureEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetAutoExposureEnabled, value);
    }

    /// <summary>
    /// A Boolean value that indicates whether MetalFX compiles a temporal scaling effect’s underlying upscaler as it creates the instance.
    /// </summary>
    public Bool8 RequiresSynchronousInitialization
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorBindings.RequiresSynchronousInitialization);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetRequiresSynchronousInitialization, value);
    }

    /// <summary>
    /// A Boolean value that indicates whether a temporal scaler you create with the descriptor applies a reactive mask.
    /// </summary>
    public Bool8 IsReactiveMaskTextureEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorBindings.IsReactiveMaskTextureEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetReactiveMaskTextureEnabled, value);
    }

    /// <summary>
    /// The pixel format of the reactive mask input texture for a temporal scaler you create with the descriptor.
    /// </summary>
    public MTLPixelFormat ReactiveMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerDescriptorBindings.ReactiveMaskTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetReactiveMaskTextureFormat, (nuint)value);
    }
    #endregion

    #region Configuring a temporal effect’s output - Properties

    /// <summary>
    /// The width of the output color texture for the temporal scaler you create with this descriptor.
    /// </summary>
    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.OutputWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetOutputWidth, value);
    }

    /// <summary>
    /// The height of the output color texture for the temporal scaler you create with this descriptor.
    /// </summary>
    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.OutputHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetOutputHeight, value);
    }

    /// <summary>
    /// The pixel format of the output color texture for the temporal scaler you create with this descriptor.
    /// </summary>
    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerDescriptorBindings.OutputTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetOutputTextureFormat, (nuint)value);
    }
    #endregion

    #region Checking a GPU device’s scaling support - Methods

    /// <summary>
    /// Returns a Boolean value that indicates whether the temporal scaler works with a GPU.
    /// </summary>
    public static bool SupportsDevice(MTLDevice pDevice)
    {
        return ObjectiveC.MsgSendBool(MTLFXTemporalScalerDescriptorBindings.Class, MTLFXTemporalScalerDescriptorBindings.SupportsDevice, pDevice.NativePtr);
    }

    /// <summary>
    /// Returns the smallest temporal scaling factor the device supports as a floating-point value.
    /// </summary>
    public static float SupportedInputContentMinScale(MTLDevice pDevice)
    {
        return ObjectiveC.MsgSendFloat(MTLFXTemporalScalerDescriptorBindings.Class, MTLFXTemporalScalerDescriptorBindings.SupportedInputContentMinScale, pDevice.NativePtr);
    }

    /// <summary>
    /// Returns the largest temporal scaling factor the device supports as a floating-point value.
    /// </summary>
    public static float SupportedInputContentMaxScale(MTLDevice pDevice)
    {
        return ObjectiveC.MsgSendFloat(MTLFXTemporalScalerDescriptorBindings.Class, MTLFXTemporalScalerDescriptorBindings.SupportedInputContentMaxScale, pDevice.NativePtr);
    }
    #endregion

    #region Creating temporal scaling effect instances - Methods

    /// <summary>
    /// Creates a temporal scaler instance from this descriptor’s current property values.
    /// </summary>
    public MTLFXTemporalScaler NewTemporalScaler(MTLDevice pDevice)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.NewTemporalScaler, pDevice.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Creates a temporal scaler instance from this descriptor’s current property values.
    /// </summary>
    public MTL4FXTemporalScaler NewTemporalScaler(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.NewTemporalScalerWithDevicecompiler, pDevice.NativePtr, pCompiler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Type Methods - Methods

    /// <summary>
    /// Queries whether a Metal device supports temporal scaling compatible with Metal 4.
    /// </summary>
    public static bool SupportsMetal4FX(MTLDevice pDevice)
    {
        return ObjectiveC.MsgSendBool(MTLFXTemporalScalerDescriptorBindings.Class, MTLFXTemporalScalerDescriptorBindings.SupportsMetal4FX, pDevice.NativePtr);
    }
    #endregion
}

file static class MTLFXTemporalScalerDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFXTemporalScalerDescriptor");

    public static readonly Selector ColorTextureFormat = "colorTextureFormat";

    public static readonly Selector DepthTextureFormat = "depthTextureFormat";

    public static readonly Selector InputContentMaxScale = "inputContentMaxScale";

    public static readonly Selector InputContentMinScale = "inputContentMinScale";

    public static readonly Selector InputHeight = "inputHeight";

    public static readonly Selector InputWidth = "inputWidth";

    public static readonly Selector IsAutoExposureEnabled = "isAutoExposureEnabled";

    public static readonly Selector IsInputContentPropertiesEnabled = "isInputContentPropertiesEnabled";

    public static readonly Selector IsReactiveMaskTextureEnabled = "isReactiveMaskTextureEnabled";

    public static readonly Selector MotionTextureFormat = "motionTextureFormat";

    public static readonly Selector NewTemporalScaler = "newTemporalScalerWithDevice:";

    public static readonly Selector NewTemporalScalerWithDevicecompiler = "newTemporalScalerWithDevice:compiler:";

    public static readonly Selector OutputHeight = "outputHeight";

    public static readonly Selector OutputTextureFormat = "outputTextureFormat";

    public static readonly Selector OutputWidth = "outputWidth";

    public static readonly Selector ReactiveMaskTextureFormat = "reactiveMaskTextureFormat";

    public static readonly Selector RequiresSynchronousInitialization = "requiresSynchronousInitialization";

    public static readonly Selector SetAutoExposureEnabled = "setAutoExposureEnabled:";

    public static readonly Selector SetColorTextureFormat = "setColorTextureFormat:";

    public static readonly Selector SetDepthTextureFormat = "setDepthTextureFormat:";

    public static readonly Selector SetInputContentMaxScale = "setInputContentMaxScale:";

    public static readonly Selector SetInputContentMinScale = "setInputContentMinScale:";

    public static readonly Selector SetInputContentPropertiesEnabled = "setInputContentPropertiesEnabled:";

    public static readonly Selector SetInputHeight = "setInputHeight:";

    public static readonly Selector SetInputWidth = "setInputWidth:";

    public static readonly Selector SetMotionTextureFormat = "setMotionTextureFormat:";

    public static readonly Selector SetOutputHeight = "setOutputHeight:";

    public static readonly Selector SetOutputTextureFormat = "setOutputTextureFormat:";

    public static readonly Selector SetOutputWidth = "setOutputWidth:";

    public static readonly Selector SetReactiveMaskTextureEnabled = "setReactiveMaskTextureEnabled:";

    public static readonly Selector SetReactiveMaskTextureFormat = "setReactiveMaskTextureFormat:";

    public static readonly Selector SetRequiresSynchronousInitialization = "setRequiresSynchronousInitialization:";

    public static readonly Selector SupportedInputContentMaxScale = "supportedInputContentMaxScaleForDevice:";

    public static readonly Selector SupportedInputContentMinScale = "supportedInputContentMinScaleForDevice:";

    public static readonly Selector SupportsDevice = "supportsDevice:";

    public static readonly Selector SupportsMetal4FX = "supportsMetal4FX:";
}
