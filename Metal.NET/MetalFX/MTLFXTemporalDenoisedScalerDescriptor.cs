namespace Metal.NET;

public class MTLFXTemporalDenoisedScalerDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFXTemporalDenoisedScalerDescriptor>
{
    #region INativeObject
    public static new MTLFXTemporalDenoisedScalerDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXTemporalDenoisedScalerDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFXTemporalDenoisedScalerDescriptor() : this(ObjectiveC.AllocInit(MTLFXTemporalDenoisedScalerDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>The pixel format of the input color texture for the scaler you create with this descriptor.</summary>
    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.ColorTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetColorTextureFormat, (nuint)value);
    }

    /// <summary>The pixel format of the input denoise strength mask texture for the scaler you create with this descriptor.</summary>
    public MTLPixelFormat DenoiseStrengthMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.DenoiseStrengthMaskTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetDenoiseStrengthMaskTextureFormat, (nuint)value);
    }

    /// <summary>The pixel format of the input depth texture for the scaler you create with this descriptor.</summary>
    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.DepthTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetDepthTextureFormat, (nuint)value);
    }

    /// <summary>The pixel format of the input diffuse albedo texture for the scaler you create with this descriptor.</summary>
    public MTLPixelFormat DiffuseAlbedoTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.DiffuseAlbedoTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetDiffuseAlbedoTextureFormat, (nuint)value);
    }

    /// <summary>The height, in pixels, of the input color texture for the denoiser scaler.</summary>
    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.InputHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetInputHeight, value);
    }

    /// <summary>The width, in pixels, of the input color texture for the denoiser scaler.</summary>
    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.InputWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetInputWidth, value);
    }

    /// <summary>A Boolean value that indicates whether MetalFX calculates the exposure for each frame.</summary>
    public Bool8 IsAutoExposureEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.IsAutoExposureEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetAutoExposureEnabled, value);
    }

    /// <summary>A Boolean value indicating whether the scaler evaluates a denoise strength mask texture as part of its operation.</summary>
    public Bool8 IsDenoiseStrengthMaskTextureEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.IsDenoiseStrengthMaskTextureEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetDenoiseStrengthMaskTextureEnabled, value);
    }

    /// <summary>A Boolean value that indicates whether a scaler you create from this descriptor applies a reactive mask.</summary>
    public Bool8 IsReactiveMaskTextureEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.IsReactiveMaskTextureEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetReactiveMaskTextureEnabled, value);
    }

    /// <summary>A Boolean value indicating whether the scaler evaluates a specular hit distance texture as part of its operation.</summary>
    public Bool8 IsSpecularHitDistanceTextureEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.IsSpecularHitDistanceTextureEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetSpecularHitDistanceTextureEnabled, value);
    }

    /// <summary>A Boolean value indicating whether the scaler evaluates a transparency overlay texture as part of its operation.</summary>
    public Bool8 IsTransparencyOverlayTextureEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.IsTransparencyOverlayTextureEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetTransparencyOverlayTextureEnabled, value);
    }

    /// <summary>The pixel format of the input motion texture for the scaler you create with this descriptor.</summary>
    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.MotionTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetMotionTextureFormat, (nuint)value);
    }

    /// <summary>The pixel format of the input normal texture for the scaler you create with this descriptor.</summary>
    public MTLPixelFormat NormalTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.NormalTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetNormalTextureFormat, (nuint)value);
    }

    /// <summary>The height, in pixels, of the input color texture for the denoiser scaler.</summary>
    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.OutputHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetOutputHeight, value);
    }

    /// <summary>The pixel format of the output color texture for the scaler you create with this descriptor.</summary>
    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.OutputTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetOutputTextureFormat, (nuint)value);
    }

    /// <summary>The width, in pixels, of the output color texture for the denoiser scaler.</summary>
    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.OutputWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetOutputWidth, value);
    }

    /// <summary>The pixel format of the reactive mask input texture for a scaler you create from this descriptor.</summary>
    public MTLPixelFormat ReactiveMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.ReactiveMaskTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetReactiveMaskTextureFormat, (nuint)value);
    }

    /// <summary>A Boolean value that indicates whether MetalFX compiles a temporal scaling effect’s underlying upscaler as it creates the instance.</summary>
    public Bool8 RequiresSynchronousInitialization
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.RequiresSynchronousInitialization);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetRequiresSynchronousInitialization, value);
    }

    /// <summary>The pixel format of the input roughness texture for the scaler you create with this descriptor.</summary>
    public MTLPixelFormat RoughnessTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.RoughnessTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetRoughnessTextureFormat, (nuint)value);
    }

    /// <summary>The pixel format of the input specular albedo texture for the scaler you create with this descriptor.</summary>
    public MTLPixelFormat SpecularAlbedoTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SpecularAlbedoTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetSpecularAlbedoTextureFormat, (nuint)value);
    }

    /// <summary>The pixel format of the input specular hit texture for the scaler you create with this descriptor.</summary>
    public MTLPixelFormat SpecularHitDistanceTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SpecularHitDistanceTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetSpecularHitDistanceTextureFormat, (nuint)value);
    }

    /// <summary>The pixel format of the input transparency overlay texture for the scaler you create with this descriptor.</summary>
    public MTLPixelFormat TransparencyOverlayTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.TransparencyOverlayTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetTransparencyOverlayTextureFormat, (nuint)value);
    }
    #endregion

    public Bool8 IsInputContentPropertiesEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.IsInputContentPropertiesEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetInputContentPropertiesEnabled, value);
    }

    public float InputContentMinScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.InputContentMinScale);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetInputContentMinScale, value);
    }

    public float InputContentMaxScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.InputContentMaxScale);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetInputContentMaxScale, value);
    }

    #region Instance Methods - Methods

    /// <summary>Creates a denoiser scaler instance for a Metal device.</summary>
    public MTLFXTemporalDenoisedScaler NewTemporalDenoisedScaler(MTLDevice device)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.NewTemporalDenoisedScaler, device.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Creates a denoiser scaler instance for a Metal device.</summary>
    public MTL4FXTemporalDenoisedScaler NewTemporalDenoisedScaler(MTLDevice device, MTL4Compiler compiler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.NewTemporalDenoisedScalerWithDevicecompiler, device.NativePtr, compiler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Type Methods - Methods

    /// <summary>Returns the largest temporal scaling factor the device supports as a floating-point value.</summary>
    public static float SupportedInputContentMaxScale(MTLDevice device)
    {
        return ObjectiveC.MsgSendFloat(MTLFXTemporalDenoisedScalerDescriptorBindings.Class, MTLFXTemporalDenoisedScalerDescriptorBindings.SupportedInputContentMaxScale, device.NativePtr);
    }

    /// <summary>Returns the smallest temporal scaling factor the device supports as a floating-point value.</summary>
    public static float SupportedInputContentMinScale(MTLDevice device)
    {
        return ObjectiveC.MsgSendFloat(MTLFXTemporalDenoisedScalerDescriptorBindings.Class, MTLFXTemporalDenoisedScalerDescriptorBindings.SupportedInputContentMinScale, device.NativePtr);
    }

    /// <summary>Queries whether a Metal device supports denoising scaling.</summary>
    public static bool SupportsDevice(MTLDevice device)
    {
        return ObjectiveC.MsgSendBool(MTLFXTemporalDenoisedScalerDescriptorBindings.Class, MTLFXTemporalDenoisedScalerDescriptorBindings.SupportsDevice, device.NativePtr);
    }

    /// <summary>Queries whether a Metal device supports denosing scaling compatible on Metal 4.</summary>
    public static bool SupportsMetal4FX(MTLDevice device)
    {
        return ObjectiveC.MsgSendBool(MTLFXTemporalDenoisedScalerDescriptorBindings.Class, MTLFXTemporalDenoisedScalerDescriptorBindings.SupportsMetal4FX, device.NativePtr);
    }
    #endregion
}

file static class MTLFXTemporalDenoisedScalerDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFXTemporalDenoisedScalerDescriptor");

    public static readonly Selector ColorTextureFormat = "colorTextureFormat";

    public static readonly Selector DenoiseStrengthMaskTextureFormat = "denoiseStrengthMaskTextureFormat";

    public static readonly Selector DepthTextureFormat = "depthTextureFormat";

    public static readonly Selector DiffuseAlbedoTextureFormat = "diffuseAlbedoTextureFormat";

    public static readonly Selector InputContentMaxScale = "inputContentMaxScale";

    public static readonly Selector InputContentMinScale = "inputContentMinScale";

    public static readonly Selector InputHeight = "inputHeight";

    public static readonly Selector InputWidth = "inputWidth";

    public static readonly Selector IsAutoExposureEnabled = "isAutoExposureEnabled";

    public static readonly Selector IsDenoiseStrengthMaskTextureEnabled = "isDenoiseStrengthMaskTextureEnabled";

    public static readonly Selector IsInputContentPropertiesEnabled = "isInputContentPropertiesEnabled";

    public static readonly Selector IsReactiveMaskTextureEnabled = "isReactiveMaskTextureEnabled";

    public static readonly Selector IsSpecularHitDistanceTextureEnabled = "isSpecularHitDistanceTextureEnabled";

    public static readonly Selector IsTransparencyOverlayTextureEnabled = "isTransparencyOverlayTextureEnabled";

    public static readonly Selector MotionTextureFormat = "motionTextureFormat";

    public static readonly Selector NewTemporalDenoisedScaler = "newTemporalDenoisedScalerWithDevice:";

    public static readonly Selector NewTemporalDenoisedScalerWithDevicecompiler = "newTemporalDenoisedScalerWithDevice:compiler:";

    public static readonly Selector NormalTextureFormat = "normalTextureFormat";

    public static readonly Selector OutputHeight = "outputHeight";

    public static readonly Selector OutputTextureFormat = "outputTextureFormat";

    public static readonly Selector OutputWidth = "outputWidth";

    public static readonly Selector ReactiveMaskTextureFormat = "reactiveMaskTextureFormat";

    public static readonly Selector RequiresSynchronousInitialization = "requiresSynchronousInitialization";

    public static readonly Selector RoughnessTextureFormat = "roughnessTextureFormat";

    public static readonly Selector SetAutoExposureEnabled = "setAutoExposureEnabled:";

    public static readonly Selector SetColorTextureFormat = "setColorTextureFormat:";

    public static readonly Selector SetDenoiseStrengthMaskTextureEnabled = "setDenoiseStrengthMaskTextureEnabled:";

    public static readonly Selector SetDenoiseStrengthMaskTextureFormat = "setDenoiseStrengthMaskTextureFormat:";

    public static readonly Selector SetDepthTextureFormat = "setDepthTextureFormat:";

    public static readonly Selector SetDiffuseAlbedoTextureFormat = "setDiffuseAlbedoTextureFormat:";

    public static readonly Selector SetInputContentMaxScale = "setInputContentMaxScale:";

    public static readonly Selector SetInputContentMinScale = "setInputContentMinScale:";

    public static readonly Selector SetInputContentPropertiesEnabled = "setInputContentPropertiesEnabled:";

    public static readonly Selector SetInputHeight = "setInputHeight:";

    public static readonly Selector SetInputWidth = "setInputWidth:";

    public static readonly Selector SetMotionTextureFormat = "setMotionTextureFormat:";

    public static readonly Selector SetNormalTextureFormat = "setNormalTextureFormat:";

    public static readonly Selector SetOutputHeight = "setOutputHeight:";

    public static readonly Selector SetOutputTextureFormat = "setOutputTextureFormat:";

    public static readonly Selector SetOutputWidth = "setOutputWidth:";

    public static readonly Selector SetReactiveMaskTextureEnabled = "setReactiveMaskTextureEnabled:";

    public static readonly Selector SetReactiveMaskTextureFormat = "setReactiveMaskTextureFormat:";

    public static readonly Selector SetRequiresSynchronousInitialization = "setRequiresSynchronousInitialization:";

    public static readonly Selector SetRoughnessTextureFormat = "setRoughnessTextureFormat:";

    public static readonly Selector SetSpecularAlbedoTextureFormat = "setSpecularAlbedoTextureFormat:";

    public static readonly Selector SetSpecularHitDistanceTextureEnabled = "setSpecularHitDistanceTextureEnabled:";

    public static readonly Selector SetSpecularHitDistanceTextureFormat = "setSpecularHitDistanceTextureFormat:";

    public static readonly Selector SetTransparencyOverlayTextureEnabled = "setTransparencyOverlayTextureEnabled:";

    public static readonly Selector SetTransparencyOverlayTextureFormat = "setTransparencyOverlayTextureFormat:";

    public static readonly Selector SpecularAlbedoTextureFormat = "specularAlbedoTextureFormat";

    public static readonly Selector SpecularHitDistanceTextureFormat = "specularHitDistanceTextureFormat";

    public static readonly Selector SupportedInputContentMaxScale = "supportedInputContentMaxScaleForDevice:";

    public static readonly Selector SupportedInputContentMinScale = "supportedInputContentMinScaleForDevice:";

    public static readonly Selector SupportsDevice = "supportsDevice:";

    public static readonly Selector SupportsMetal4FX = "supportsMetal4FX:";

    public static readonly Selector TransparencyOverlayTextureFormat = "transparencyOverlayTextureFormat";
}
