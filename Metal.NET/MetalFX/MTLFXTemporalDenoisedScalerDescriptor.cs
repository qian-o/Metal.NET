namespace Metal.NET;

public class MTLFXTemporalDenoisedScalerDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLFXTemporalDenoisedScalerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLFXTemporalDenoisedScalerDescriptorBindings.Class))
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

    public MTLFXTemporalDenoisedScaler? NewTemporalDenoisedScaler(MTLDevice device)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.NewTemporalDenoisedScaler, device.NativePtr);
        return ptr is not 0 ? new MTLFXTemporalDenoisedScaler(ptr) : null;
    }

    public MTL4FXTemporalDenoisedScaler? NewTemporalDenoisedScaler(MTLDevice device, MTL4Compiler compiler)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerDescriptorBindings.NewTemporalDenoisedScaler, device.NativePtr, compiler.NativePtr);
        return ptr is not 0 ? new MTL4FXTemporalDenoisedScaler(ptr) : null;
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

    public static readonly Selector NewTemporalDenoisedScaler = Selector.Register("newTemporalDenoisedScalerWithDevice:");

    public static readonly Selector NormalTextureFormat = Selector.Register("normalTextureFormat");

    public static readonly Selector OutputHeight = Selector.Register("outputHeight");

    public static readonly Selector OutputTextureFormat = Selector.Register("outputTextureFormat");

    public static readonly Selector OutputWidth = Selector.Register("outputWidth");

    public static readonly Selector ReactiveMaskTextureFormat = Selector.Register("reactiveMaskTextureFormat");

    public static readonly Selector RequiresSynchronousInitialization = Selector.Register("requiresSynchronousInitialization");

    public static readonly Selector RoughnessTextureFormat = Selector.Register("roughnessTextureFormat");

    public static readonly Selector SetColorTextureFormat = Selector.Register("setColorTextureFormat:");

    public static readonly Selector SetDenoiseStrengthMaskTextureFormat = Selector.Register("setDenoiseStrengthMaskTextureFormat:");

    public static readonly Selector SetDepthTextureFormat = Selector.Register("setDepthTextureFormat:");

    public static readonly Selector SetDiffuseAlbedoTextureFormat = Selector.Register("setDiffuseAlbedoTextureFormat:");

    public static readonly Selector SetInputContentMaxScale = Selector.Register("setInputContentMaxScale:");

    public static readonly Selector SetInputContentMinScale = Selector.Register("setInputContentMinScale:");

    public static readonly Selector SetInputHeight = Selector.Register("setInputHeight:");

    public static readonly Selector SetInputWidth = Selector.Register("setInputWidth:");

    public static readonly Selector SetMotionTextureFormat = Selector.Register("setMotionTextureFormat:");

    public static readonly Selector SetNormalTextureFormat = Selector.Register("setNormalTextureFormat:");

    public static readonly Selector SetOutputHeight = Selector.Register("setOutputHeight:");

    public static readonly Selector SetOutputTextureFormat = Selector.Register("setOutputTextureFormat:");

    public static readonly Selector SetOutputWidth = Selector.Register("setOutputWidth:");

    public static readonly Selector SetReactiveMaskTextureFormat = Selector.Register("setReactiveMaskTextureFormat:");

    public static readonly Selector SetRequiresSynchronousInitialization = Selector.Register("setRequiresSynchronousInitialization:");

    public static readonly Selector SetRoughnessTextureFormat = Selector.Register("setRoughnessTextureFormat:");

    public static readonly Selector SetSpecularAlbedoTextureFormat = Selector.Register("setSpecularAlbedoTextureFormat:");

    public static readonly Selector SetSpecularHitDistanceTextureFormat = Selector.Register("setSpecularHitDistanceTextureFormat:");

    public static readonly Selector SetTransparencyOverlayTextureFormat = Selector.Register("setTransparencyOverlayTextureFormat:");

    public static readonly Selector SpecularAlbedoTextureFormat = Selector.Register("specularAlbedoTextureFormat");

    public static readonly Selector SpecularHitDistanceTextureFormat = Selector.Register("specularHitDistanceTextureFormat");

    public static readonly Selector SupportedInputContentMaxScale = Selector.Register("supportedInputContentMaxScaleForDevice:");

    public static readonly Selector SupportedInputContentMinScale = Selector.Register("supportedInputContentMinScaleForDevice:");

    public static readonly Selector SupportsDevice = Selector.Register("supportsDevice:");

    public static readonly Selector SupportsMetal4FX = Selector.Register("supportsMetal4FX:");

    public static readonly Selector TransparencyOverlayTextureFormat = Selector.Register("transparencyOverlayTextureFormat");
}
