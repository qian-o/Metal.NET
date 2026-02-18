namespace Metal.NET;

public partial class MTLFXTemporalDenoisedScalerDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFXTemporalDenoisedScalerDescriptor");

    public MTLFXTemporalDenoisedScalerDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.ColorTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetColorTextureFormat, (nuint)value);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.DepthTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetDepthTextureFormat, (nuint)value);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.MotionTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetMotionTextureFormat, (nuint)value);
    }

    public MTLPixelFormat DiffuseAlbedoTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.DiffuseAlbedoTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetDiffuseAlbedoTextureFormat, (nuint)value);
    }

    public MTLPixelFormat SpecularAlbedoTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SpecularAlbedoTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetSpecularAlbedoTextureFormat, (nuint)value);
    }

    public MTLPixelFormat NormalTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.NormalTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetNormalTextureFormat, (nuint)value);
    }

    public MTLPixelFormat RoughnessTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.RoughnessTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetRoughnessTextureFormat, (nuint)value);
    }

    public MTLPixelFormat SpecularHitDistanceTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SpecularHitDistanceTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetSpecularHitDistanceTextureFormat, (nuint)value);
    }

    public MTLPixelFormat DenoiseStrengthMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.DenoiseStrengthMaskTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetDenoiseStrengthMaskTextureFormat, (nuint)value);
    }

    public MTLPixelFormat TransparencyOverlayTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.TransparencyOverlayTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetTransparencyOverlayTextureFormat, (nuint)value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.OutputTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetOutputTextureFormat, (nuint)value);
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.InputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetInputWidth, value);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.InputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetInputHeight, value);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.OutputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetOutputWidth, value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.OutputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetOutputHeight, value);
    }

    public bool RequiresSynchronousInitialization
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.RequiresSynchronousInitialization);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetRequiresSynchronousInitialization, (Bool8)value);
    }

    public bool IsAutoExposureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.IsAutoExposureEnabled);
    }

    public bool IsInputContentPropertiesEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.IsInputContentPropertiesEnabled);
    }

    public float InputContentMinScale
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.InputContentMinScale);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetInputContentMinScale, value);
    }

    public float InputContentMaxScale
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.InputContentMaxScale);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetInputContentMaxScale, value);
    }

    public bool IsReactiveMaskTextureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.IsReactiveMaskTextureEnabled);
    }

    public MTLPixelFormat ReactiveMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.ReactiveMaskTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetReactiveMaskTextureFormat, (nuint)value);
    }

    public bool IsSpecularHitDistanceTextureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.IsSpecularHitDistanceTextureEnabled);
    }

    public bool IsDenoiseStrengthMaskTextureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.IsDenoiseStrengthMaskTextureEnabled);
    }

    public bool IsTransparencyOverlayTextureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.IsTransparencyOverlayTextureEnabled);
    }

    public void SetAutoExposureEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetAutoExposureEnabled, (Bool8)enabled);
    }

    public void SetInputContentPropertiesEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetInputContentPropertiesEnabled, (Bool8)enabled);
    }

    public void SetReactiveMaskTextureEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetReactiveMaskTextureEnabled, (Bool8)enabled);
    }

    public void SetSpecularHitDistanceTextureEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetSpecularHitDistanceTextureEnabled, (Bool8)enabled);
    }

    public void SetDenoiseStrengthMaskTextureEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetDenoiseStrengthMaskTextureEnabled, (Bool8)enabled);
    }

    public void SetTransparencyOverlayTextureEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetTransparencyOverlayTextureEnabled, (Bool8)enabled);
    }

    public MTLFXTemporalDenoisedScaler? NewTemporalDenoisedScaler(MTLDevice device)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.NewTemporalDenoisedScalerWithDevice, device.NativePtr);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTL4FXTemporalDenoisedScaler? NewTemporalDenoisedScaler(MTLDevice device, MTL4Compiler compiler)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.NewTemporalDenoisedScalerWithDeviceCompiler, device.NativePtr, compiler.NativePtr);
        return ptr is not 0 ? new(ptr) : null;
    }

    public static float SupportedInputContentMinScale(MTLDevice device)
    {
        return ObjectiveCRuntime.MsgSendFloat(Class, MTLFXTemporalDenoisedScalerDescriptorSelector.MTLFXTemporalDenoisedScalerDescriptor, device.NativePtr);
    }

    public static float SupportedInputContentMaxScale(MTLDevice device)
    {
        return ObjectiveCRuntime.MsgSendFloat(Class, MTLFXTemporalDenoisedScalerDescriptorSelector.MTLFXTemporalDenoisedScalerDescriptor, device.NativePtr);
    }

    public static bool SupportsMetal4FX(MTLDevice device)
    {
        return ObjectiveCRuntime.MsgSendBool(Class, MTLFXTemporalDenoisedScalerDescriptorSelector.MTLFXTemporalDenoisedScalerDescriptor, device.NativePtr);
    }

    public static bool SupportsDevice(MTLDevice device)
    {
        return ObjectiveCRuntime.MsgSendBool(Class, MTLFXTemporalDenoisedScalerDescriptorSelector.MTLFXTemporalDenoisedScalerDescriptor, device.NativePtr);
    }
}

file static class MTLFXTemporalDenoisedScalerDescriptorSelector
{
    public static readonly Selector ColorTextureFormat = Selector.Register("colorTextureFormat");

    public static readonly Selector DenoiseStrengthMaskTextureFormat = Selector.Register("denoiseStrengthMaskTextureFormat");

    public static readonly Selector DepthTextureFormat = Selector.Register("depthTextureFormat");

    public static readonly Selector DiffuseAlbedoTextureFormat = Selector.Register("diffuseAlbedoTextureFormat");

    public static readonly Selector InputContentMaxScale = Selector.Register("inputContentMaxScale");

    public static readonly Selector InputContentMinScale = Selector.Register("inputContentMinScale");

    public static readonly Selector InputHeight = Selector.Register("inputHeight");

    public static readonly Selector InputWidth = Selector.Register("inputWidth");

    public static readonly Selector IsAutoExposureEnabled = Selector.Register("isAutoExposureEnabled");

    public static readonly Selector IsDenoiseStrengthMaskTextureEnabled = Selector.Register("isDenoiseStrengthMaskTextureEnabled");

    public static readonly Selector IsInputContentPropertiesEnabled = Selector.Register("isInputContentPropertiesEnabled");

    public static readonly Selector IsReactiveMaskTextureEnabled = Selector.Register("isReactiveMaskTextureEnabled");

    public static readonly Selector IsSpecularHitDistanceTextureEnabled = Selector.Register("isSpecularHitDistanceTextureEnabled");

    public static readonly Selector IsTransparencyOverlayTextureEnabled = Selector.Register("isTransparencyOverlayTextureEnabled");

    public static readonly Selector MotionTextureFormat = Selector.Register("motionTextureFormat");

    public static readonly Selector MTLFXTemporalDenoisedScalerDescriptor = Selector.Register("MTLFXTemporalDenoisedScalerDescriptor");

    public static readonly Selector NewTemporalDenoisedScalerWithDevice = Selector.Register("newTemporalDenoisedScalerWithDevice:");

    public static readonly Selector NewTemporalDenoisedScalerWithDeviceCompiler = Selector.Register("newTemporalDenoisedScalerWithDevice:compiler:");

    public static readonly Selector NormalTextureFormat = Selector.Register("normalTextureFormat");

    public static readonly Selector OutputHeight = Selector.Register("outputHeight");

    public static readonly Selector OutputTextureFormat = Selector.Register("outputTextureFormat");

    public static readonly Selector OutputWidth = Selector.Register("outputWidth");

    public static readonly Selector ReactiveMaskTextureFormat = Selector.Register("reactiveMaskTextureFormat");

    public static readonly Selector RequiresSynchronousInitialization = Selector.Register("requiresSynchronousInitialization");

    public static readonly Selector RoughnessTextureFormat = Selector.Register("roughnessTextureFormat");

    public static readonly Selector SetAutoExposureEnabled = Selector.Register("setAutoExposureEnabled:");

    public static readonly Selector SetColorTextureFormat = Selector.Register("setColorTextureFormat:");

    public static readonly Selector SetDenoiseStrengthMaskTextureEnabled = Selector.Register("setDenoiseStrengthMaskTextureEnabled:");

    public static readonly Selector SetDenoiseStrengthMaskTextureFormat = Selector.Register("setDenoiseStrengthMaskTextureFormat:");

    public static readonly Selector SetDepthTextureFormat = Selector.Register("setDepthTextureFormat:");

    public static readonly Selector SetDiffuseAlbedoTextureFormat = Selector.Register("setDiffuseAlbedoTextureFormat:");

    public static readonly Selector SetInputContentMaxScale = Selector.Register("setInputContentMaxScale:");

    public static readonly Selector SetInputContentMinScale = Selector.Register("setInputContentMinScale:");

    public static readonly Selector SetInputContentPropertiesEnabled = Selector.Register("setInputContentPropertiesEnabled:");

    public static readonly Selector SetInputHeight = Selector.Register("setInputHeight:");

    public static readonly Selector SetInputWidth = Selector.Register("setInputWidth:");

    public static readonly Selector SetMotionTextureFormat = Selector.Register("setMotionTextureFormat:");

    public static readonly Selector SetNormalTextureFormat = Selector.Register("setNormalTextureFormat:");

    public static readonly Selector SetOutputHeight = Selector.Register("setOutputHeight:");

    public static readonly Selector SetOutputTextureFormat = Selector.Register("setOutputTextureFormat:");

    public static readonly Selector SetOutputWidth = Selector.Register("setOutputWidth:");

    public static readonly Selector SetReactiveMaskTextureEnabled = Selector.Register("setReactiveMaskTextureEnabled:");

    public static readonly Selector SetReactiveMaskTextureFormat = Selector.Register("setReactiveMaskTextureFormat:");

    public static readonly Selector SetRequiresSynchronousInitialization = Selector.Register("setRequiresSynchronousInitialization:");

    public static readonly Selector SetRoughnessTextureFormat = Selector.Register("setRoughnessTextureFormat:");

    public static readonly Selector SetSpecularAlbedoTextureFormat = Selector.Register("setSpecularAlbedoTextureFormat:");

    public static readonly Selector SetSpecularHitDistanceTextureEnabled = Selector.Register("setSpecularHitDistanceTextureEnabled:");

    public static readonly Selector SetSpecularHitDistanceTextureFormat = Selector.Register("setSpecularHitDistanceTextureFormat:");

    public static readonly Selector SetTransparencyOverlayTextureEnabled = Selector.Register("setTransparencyOverlayTextureEnabled:");

    public static readonly Selector SetTransparencyOverlayTextureFormat = Selector.Register("setTransparencyOverlayTextureFormat:");

    public static readonly Selector SpecularAlbedoTextureFormat = Selector.Register("specularAlbedoTextureFormat");

    public static readonly Selector SpecularHitDistanceTextureFormat = Selector.Register("specularHitDistanceTextureFormat");

    public static readonly Selector TransparencyOverlayTextureFormat = Selector.Register("transparencyOverlayTextureFormat");
}
