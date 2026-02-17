namespace Metal.NET;

public class MTLFXTemporalDenoisedScalerDescriptor : IDisposable
{
    public MTLFXTemporalDenoisedScalerDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLFXTemporalDenoisedScalerDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFXTemporalDenoisedScalerDescriptor");

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.ColorTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetColorTextureFormat, (uint)value);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.DepthTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetDepthTextureFormat, (uint)value);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.MotionTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetMotionTextureFormat, (uint)value);
    }

    public MTLPixelFormat DiffuseAlbedoTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.DiffuseAlbedoTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetDiffuseAlbedoTextureFormat, (uint)value);
    }

    public MTLPixelFormat SpecularAlbedoTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SpecularAlbedoTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetSpecularAlbedoTextureFormat, (uint)value);
    }

    public MTLPixelFormat NormalTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.NormalTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetNormalTextureFormat, (uint)value);
    }

    public MTLPixelFormat RoughnessTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.RoughnessTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetRoughnessTextureFormat, (uint)value);
    }

    public MTLPixelFormat SpecularHitDistanceTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SpecularHitDistanceTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetSpecularHitDistanceTextureFormat, (uint)value);
    }

    public MTLPixelFormat DenoiseStrengthMaskTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.DenoiseStrengthMaskTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetDenoiseStrengthMaskTextureFormat, (uint)value);
    }

    public MTLPixelFormat TransparencyOverlayTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.TransparencyOverlayTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetTransparencyOverlayTextureFormat, (uint)value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.OutputTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetOutputTextureFormat, (uint)value);
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

    public Bool8 RequiresSynchronousInitialization
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.RequiresSynchronousInitialization);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetRequiresSynchronousInitialization, value);
    }

    public Bool8 IsAutoExposureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.IsAutoExposureEnabled);
    }

    public Bool8 IsInputContentPropertiesEnabled
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

    public Bool8 IsReactiveMaskTextureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.IsReactiveMaskTextureEnabled);
    }

    public MTLPixelFormat ReactiveMaskTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.ReactiveMaskTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetReactiveMaskTextureFormat, (uint)value);
    }

    public Bool8 IsSpecularHitDistanceTextureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.IsSpecularHitDistanceTextureEnabled);
    }

    public Bool8 IsDenoiseStrengthMaskTextureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.IsDenoiseStrengthMaskTextureEnabled);
    }

    public Bool8 IsTransparencyOverlayTextureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.IsTransparencyOverlayTextureEnabled);
    }

    public void SetAutoExposureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetAutoExposureEnabled, enabled);
    }

    public void SetInputContentPropertiesEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetInputContentPropertiesEnabled, enabled);
    }

    public void SetReactiveMaskTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetReactiveMaskTextureEnabled, enabled);
    }

    public void SetSpecularHitDistanceTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetSpecularHitDistanceTextureEnabled, enabled);
    }

    public void SetDenoiseStrengthMaskTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetDenoiseStrengthMaskTextureEnabled, enabled);
    }

    public void SetTransparencyOverlayTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetTransparencyOverlayTextureEnabled, enabled);
    }

    public MTLFXTemporalDenoisedScaler NewTemporalDenoisedScaler(MTLDevice device)
    {
        MTLFXTemporalDenoisedScaler result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.NewTemporalDenoisedScaler, device.NativePtr));

        return result;
    }

    public MTLFXTemporalDenoisedScaler NewTemporalDenoisedScaler(MTLDevice device, MTL4Compiler compiler)
    {
        MTLFXTemporalDenoisedScaler result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.NewTemporalDenoisedScalerCompiler, device.NativePtr, compiler.NativePtr));

        return result;
    }

    public static implicit operator nint(MTLFXTemporalDenoisedScalerDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXTemporalDenoisedScalerDescriptor(nint value)
    {
        return new(value);
    }

    public static float SupportedInputContentMinScale(MTLDevice device)
    {
        float result = ObjectiveCRuntime.MsgSendFloat(Class, MTLFXTemporalDenoisedScalerDescriptorSelector.SupportedInputContentMinScale, device.NativePtr);

        return result;
    }

    public static float SupportedInputContentMaxScale(MTLDevice device)
    {
        float result = ObjectiveCRuntime.MsgSendFloat(Class, MTLFXTemporalDenoisedScalerDescriptorSelector.SupportedInputContentMaxScale, device.NativePtr);

        return result;
    }

    public static Bool8 SupportsMetal4FX(MTLDevice device)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(Class, MTLFXTemporalDenoisedScalerDescriptorSelector.SupportsMetal4FX, device.NativePtr);

        return result;
    }

    public static Bool8 SupportsDevice(MTLDevice device)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(Class, MTLFXTemporalDenoisedScalerDescriptorSelector.SupportsDevice, device.NativePtr);

        return result;
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLFXTemporalDenoisedScalerDescriptorSelector
{
    public static readonly Selector ColorTextureFormat = Selector.Register("colorTextureFormat");

    public static readonly Selector SetColorTextureFormat = Selector.Register("setColorTextureFormat:");

    public static readonly Selector DepthTextureFormat = Selector.Register("depthTextureFormat");

    public static readonly Selector SetDepthTextureFormat = Selector.Register("setDepthTextureFormat:");

    public static readonly Selector MotionTextureFormat = Selector.Register("motionTextureFormat");

    public static readonly Selector SetMotionTextureFormat = Selector.Register("setMotionTextureFormat:");

    public static readonly Selector DiffuseAlbedoTextureFormat = Selector.Register("diffuseAlbedoTextureFormat");

    public static readonly Selector SetDiffuseAlbedoTextureFormat = Selector.Register("setDiffuseAlbedoTextureFormat:");

    public static readonly Selector SpecularAlbedoTextureFormat = Selector.Register("specularAlbedoTextureFormat");

    public static readonly Selector SetSpecularAlbedoTextureFormat = Selector.Register("setSpecularAlbedoTextureFormat:");

    public static readonly Selector NormalTextureFormat = Selector.Register("normalTextureFormat");

    public static readonly Selector SetNormalTextureFormat = Selector.Register("setNormalTextureFormat:");

    public static readonly Selector RoughnessTextureFormat = Selector.Register("roughnessTextureFormat");

    public static readonly Selector SetRoughnessTextureFormat = Selector.Register("setRoughnessTextureFormat:");

    public static readonly Selector SpecularHitDistanceTextureFormat = Selector.Register("specularHitDistanceTextureFormat");

    public static readonly Selector SetSpecularHitDistanceTextureFormat = Selector.Register("setSpecularHitDistanceTextureFormat:");

    public static readonly Selector DenoiseStrengthMaskTextureFormat = Selector.Register("denoiseStrengthMaskTextureFormat");

    public static readonly Selector SetDenoiseStrengthMaskTextureFormat = Selector.Register("setDenoiseStrengthMaskTextureFormat:");

    public static readonly Selector TransparencyOverlayTextureFormat = Selector.Register("transparencyOverlayTextureFormat");

    public static readonly Selector SetTransparencyOverlayTextureFormat = Selector.Register("setTransparencyOverlayTextureFormat:");

    public static readonly Selector OutputTextureFormat = Selector.Register("outputTextureFormat");

    public static readonly Selector SetOutputTextureFormat = Selector.Register("setOutputTextureFormat:");

    public static readonly Selector InputWidth = Selector.Register("inputWidth");

    public static readonly Selector SetInputWidth = Selector.Register("setInputWidth:");

    public static readonly Selector InputHeight = Selector.Register("inputHeight");

    public static readonly Selector SetInputHeight = Selector.Register("setInputHeight:");

    public static readonly Selector OutputWidth = Selector.Register("outputWidth");

    public static readonly Selector SetOutputWidth = Selector.Register("setOutputWidth:");

    public static readonly Selector OutputHeight = Selector.Register("outputHeight");

    public static readonly Selector SetOutputHeight = Selector.Register("setOutputHeight:");

    public static readonly Selector RequiresSynchronousInitialization = Selector.Register("requiresSynchronousInitialization");

    public static readonly Selector SetRequiresSynchronousInitialization = Selector.Register("setRequiresSynchronousInitialization:");

    public static readonly Selector IsAutoExposureEnabled = Selector.Register("isAutoExposureEnabled");

    public static readonly Selector IsInputContentPropertiesEnabled = Selector.Register("isInputContentPropertiesEnabled");

    public static readonly Selector InputContentMinScale = Selector.Register("inputContentMinScale");

    public static readonly Selector SetInputContentMinScale = Selector.Register("setInputContentMinScale:");

    public static readonly Selector InputContentMaxScale = Selector.Register("inputContentMaxScale");

    public static readonly Selector SetInputContentMaxScale = Selector.Register("setInputContentMaxScale:");

    public static readonly Selector IsReactiveMaskTextureEnabled = Selector.Register("isReactiveMaskTextureEnabled");

    public static readonly Selector ReactiveMaskTextureFormat = Selector.Register("reactiveMaskTextureFormat");

    public static readonly Selector SetReactiveMaskTextureFormat = Selector.Register("setReactiveMaskTextureFormat:");

    public static readonly Selector IsSpecularHitDistanceTextureEnabled = Selector.Register("isSpecularHitDistanceTextureEnabled");

    public static readonly Selector IsDenoiseStrengthMaskTextureEnabled = Selector.Register("isDenoiseStrengthMaskTextureEnabled");

    public static readonly Selector IsTransparencyOverlayTextureEnabled = Selector.Register("isTransparencyOverlayTextureEnabled");

    public static readonly Selector SetAutoExposureEnabled = Selector.Register("setAutoExposureEnabled:");

    public static readonly Selector SetInputContentPropertiesEnabled = Selector.Register("setInputContentPropertiesEnabled:");

    public static readonly Selector SetReactiveMaskTextureEnabled = Selector.Register("setReactiveMaskTextureEnabled:");

    public static readonly Selector SetSpecularHitDistanceTextureEnabled = Selector.Register("setSpecularHitDistanceTextureEnabled:");

    public static readonly Selector SetDenoiseStrengthMaskTextureEnabled = Selector.Register("setDenoiseStrengthMaskTextureEnabled:");

    public static readonly Selector SetTransparencyOverlayTextureEnabled = Selector.Register("setTransparencyOverlayTextureEnabled:");

    public static readonly Selector NewTemporalDenoisedScaler = Selector.Register("newTemporalDenoisedScaler:");

    public static readonly Selector NewTemporalDenoisedScalerCompiler = Selector.Register("newTemporalDenoisedScaler:compiler:");

    public static readonly Selector SupportedInputContentMinScale = Selector.Register("supportedInputContentMinScale:");

    public static readonly Selector SupportedInputContentMaxScale = Selector.Register("supportedInputContentMaxScale:");

    public static readonly Selector SupportsMetal4FX = Selector.Register("supportsMetal4FX:");

    public static readonly Selector SupportsDevice = Selector.Register("supportsDevice:");
}
