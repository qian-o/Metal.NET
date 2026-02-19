namespace Metal.NET;

public class MTLFXTemporalDenoisedScalerDescriptor(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public MTLFXTemporalDenoisedScalerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLFXTemporalDenoisedScalerDescriptorBindings.Class), false)
    {
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.ColorTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetColorTextureFormat, (nuint)value);
    }

    public MTLPixelFormat DenoiseStrengthMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.DenoiseStrengthMaskTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetDenoiseStrengthMaskTextureFormat, (nuint)value);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.DepthTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetDepthTextureFormat, (nuint)value);
    }

    public MTLPixelFormat DiffuseAlbedoTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.DiffuseAlbedoTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetDiffuseAlbedoTextureFormat, (nuint)value);
    }

    public float InputContentMaxScale
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.InputContentMaxScale);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetInputContentMaxScale, value);
    }

    public float InputContentMinScale
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.InputContentMinScale);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetInputContentMinScale, value);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.InputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetInputHeight, value);
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.InputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetInputWidth, value);
    }

    public bool IsAutoExposureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.IsAutoExposureEnabled);
    }

    public bool IsDenoiseStrengthMaskTextureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.IsDenoiseStrengthMaskTextureEnabled);
    }

    public bool IsInputContentPropertiesEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.IsInputContentPropertiesEnabled);
    }

    public bool IsReactiveMaskTextureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.IsReactiveMaskTextureEnabled);
    }

    public bool IsSpecularHitDistanceTextureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.IsSpecularHitDistanceTextureEnabled);
    }

    public bool IsTransparencyOverlayTextureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.IsTransparencyOverlayTextureEnabled);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.MotionTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetMotionTextureFormat, (nuint)value);
    }

    public MTLPixelFormat NormalTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.NormalTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetNormalTextureFormat, (nuint)value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.OutputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetOutputHeight, value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.OutputTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetOutputTextureFormat, (nuint)value);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.OutputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetOutputWidth, value);
    }

    public MTLPixelFormat ReactiveMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.ReactiveMaskTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetReactiveMaskTextureFormat, (nuint)value);
    }

    public bool RequiresSynchronousInitialization
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.RequiresSynchronousInitialization);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetRequiresSynchronousInitialization, (Bool8)value);
    }

    public MTLPixelFormat RoughnessTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.RoughnessTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetRoughnessTextureFormat, (nuint)value);
    }

    public MTLPixelFormat SpecularAlbedoTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SpecularAlbedoTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetSpecularAlbedoTextureFormat, (nuint)value);
    }

    public MTLPixelFormat SpecularHitDistanceTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SpecularHitDistanceTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetSpecularHitDistanceTextureFormat, (nuint)value);
    }

    public MTLPixelFormat TransparencyOverlayTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.TransparencyOverlayTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetTransparencyOverlayTextureFormat, (nuint)value);
    }

    public void SetAutoExposureEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetAutoExposureEnabled, (Bool8)enabled);
    }

    public void SetInputContentPropertiesEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetInputContentPropertiesEnabled, (Bool8)enabled);
    }

    public void SetReactiveMaskTextureEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetReactiveMaskTextureEnabled, (Bool8)enabled);
    }

    public void SetSpecularHitDistanceTextureEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetSpecularHitDistanceTextureEnabled, (Bool8)enabled);
    }

    public void SetDenoiseStrengthMaskTextureEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetDenoiseStrengthMaskTextureEnabled, (Bool8)enabled);
    }

    public void SetTransparencyOverlayTextureEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.SetTransparencyOverlayTextureEnabled, (Bool8)enabled);
    }

    public MTLFXTemporalDenoisedScaler? NewTemporalDenoisedScaler(MTLDevice device)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.NewTemporalDenoisedScaler, device.NativePtr);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public MTL4FXTemporalDenoisedScaler? NewTemporalDenoisedScaler(MTLDevice device, MTL4Compiler compiler)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.NewTemporalDenoisedScalerWithDevicecompiler, device.NativePtr, compiler.NativePtr);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public static float SupportedInputContentMinScale(MTLDevice device)
    {
        return ObjectiveCRuntime.MsgSendFloat(MTLFXTemporalDenoisedScalerDescriptorBindings.Class, MTLFXTemporalDenoisedScalerDescriptorBindings.SupportedInputContentMinScale, device.NativePtr);
    }

    public static float SupportedInputContentMaxScale(MTLDevice device)
    {
        return ObjectiveCRuntime.MsgSendFloat(MTLFXTemporalDenoisedScalerDescriptorBindings.Class, MTLFXTemporalDenoisedScalerDescriptorBindings.SupportedInputContentMaxScale, device.NativePtr);
    }

    public static bool SupportsMetal4FX(MTLDevice device)
    {
        return ObjectiveCRuntime.MsgSendBool(MTLFXTemporalDenoisedScalerDescriptorBindings.Class, MTLFXTemporalDenoisedScalerDescriptorBindings.SupportsMetal4FX, device.NativePtr);
    }

    public static bool SupportsDevice(MTLDevice device)
    {
        return ObjectiveCRuntime.MsgSendBool(MTLFXTemporalDenoisedScalerDescriptorBindings.Class, MTLFXTemporalDenoisedScalerDescriptorBindings.SupportsDevice, device.NativePtr);
    }
}

file static class MTLFXTemporalDenoisedScalerDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFXTemporalDenoisedScalerDescriptor");

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
