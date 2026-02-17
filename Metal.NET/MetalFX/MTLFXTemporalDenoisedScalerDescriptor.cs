namespace Metal.NET;

public class MTLFXTemporalDenoisedScalerDescriptor : IDisposable
{
    public MTLFXTemporalDenoisedScalerDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFXTemporalDenoisedScalerDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFXTemporalDenoisedScalerDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXTemporalDenoisedScalerDescriptor(nint value)
    {
        return new(value);
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFXTemporalDenoisedScalerDescriptor");

    public void SetColorTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetColorTextureFormat, (nint)(uint)pixelFormat);
    }

    public void SetDepthTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetDepthTextureFormat, (nint)(uint)pixelFormat);
    }

    public void SetMotionTextureFormat(MTLPixelFormat pixelFormal)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetMotionTextureFormat, (nint)(uint)pixelFormal);
    }

    public void SetDiffuseAlbedoTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetDiffuseAlbedoTextureFormat, (nint)(uint)pixelFormat);
    }

    public void SetSpecularAlbedoTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetSpecularAlbedoTextureFormat, (nint)(uint)pixelFormat);
    }

    public void SetNormalTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetNormalTextureFormat, (nint)(uint)pixelFormat);
    }

    public void SetRoughnessTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetRoughnessTextureFormat, (nint)(uint)pixelFormat);
    }

    public void SetSpecularHitDistanceTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetSpecularHitDistanceTextureFormat, (nint)(uint)pixelFormat);
    }

    public void SetDenoiseStrengthMaskTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetDenoiseStrengthMaskTextureFormat, (nint)(uint)pixelFormat);
    }

    public void SetTransparencyOverlayTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetTransparencyOverlayTextureFormat, (nint)(uint)pixelFormat);
    }

    public void SetOutputTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetOutputTextureFormat, (nint)(uint)pixelFormat);
    }

    public void SetInputWidth(uint inputWidth)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetInputWidth, (nint)inputWidth);
    }

    public void SetInputHeight(uint inputHeight)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetInputHeight, (nint)inputHeight);
    }

    public void SetOutputWidth(uint outputWidth)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetOutputWidth, (nint)outputWidth);
    }

    public void SetOutputHeight(uint outputHeight)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetOutputHeight, (nint)outputHeight);
    }

    public void SetRequiresSynchronousInitialization(Bool8 requiresSynchronousInitialization)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetRequiresSynchronousInitialization, (nint)requiresSynchronousInitialization.Value);
    }

    public void SetAutoExposureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetAutoExposureEnabled, (nint)enabled.Value);
    }

    public void SetInputContentPropertiesEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetInputContentPropertiesEnabled, (nint)enabled.Value);
    }

    public void SetInputContentMinScale(float inputContentMinScale)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetInputContentMinScale, inputContentMinScale);
    }

    public void SetInputContentMaxScale(float inputContentMaxScale)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetInputContentMaxScale, inputContentMaxScale);
    }

    public void SetReactiveMaskTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetReactiveMaskTextureEnabled, (nint)enabled.Value);
    }

    public void SetReactiveMaskTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetReactiveMaskTextureFormat, (nint)(uint)pixelFormat);
    }

    public void SetSpecularHitDistanceTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetSpecularHitDistanceTextureEnabled, (nint)enabled.Value);
    }

    public void SetDenoiseStrengthMaskTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetDenoiseStrengthMaskTextureEnabled, (nint)enabled.Value);
    }

    public void SetTransparencyOverlayTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetTransparencyOverlayTextureEnabled, (nint)enabled.Value);
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

    public static float SupportedInputContentMinScale(MTLDevice device)
    {
        float result = BitConverter.Int32BitsToSingle((int)ObjectiveCRuntime.MsgSendPtr(s_class, MTLFXTemporalDenoisedScalerDescriptorSelector.SupportedInputContentMinScale, device.NativePtr));

        return result;
    }

    public static float SupportedInputContentMaxScale(MTLDevice device)
    {
        float result = BitConverter.Int32BitsToSingle((int)ObjectiveCRuntime.MsgSendPtr(s_class, MTLFXTemporalDenoisedScalerDescriptorSelector.SupportedInputContentMaxScale, device.NativePtr));

        return result;
    }

    public static Bool8 SupportsMetal4FX(MTLDevice device)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(s_class, MTLFXTemporalDenoisedScalerDescriptorSelector.SupportsMetal4FX, device.NativePtr) is not 0;

        return result;
    }

    public static Bool8 SupportsDevice(MTLDevice device)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(s_class, MTLFXTemporalDenoisedScalerDescriptorSelector.SupportsDevice, device.NativePtr) is not 0;

        return result;
    }

}

file class MTLFXTemporalDenoisedScalerDescriptorSelector
{
    public static readonly Selector SetColorTextureFormat = Selector.Register("setColorTextureFormat:");

    public static readonly Selector SetDepthTextureFormat = Selector.Register("setDepthTextureFormat:");

    public static readonly Selector SetMotionTextureFormat = Selector.Register("setMotionTextureFormat:");

    public static readonly Selector SetDiffuseAlbedoTextureFormat = Selector.Register("setDiffuseAlbedoTextureFormat:");

    public static readonly Selector SetSpecularAlbedoTextureFormat = Selector.Register("setSpecularAlbedoTextureFormat:");

    public static readonly Selector SetNormalTextureFormat = Selector.Register("setNormalTextureFormat:");

    public static readonly Selector SetRoughnessTextureFormat = Selector.Register("setRoughnessTextureFormat:");

    public static readonly Selector SetSpecularHitDistanceTextureFormat = Selector.Register("setSpecularHitDistanceTextureFormat:");

    public static readonly Selector SetDenoiseStrengthMaskTextureFormat = Selector.Register("setDenoiseStrengthMaskTextureFormat:");

    public static readonly Selector SetTransparencyOverlayTextureFormat = Selector.Register("setTransparencyOverlayTextureFormat:");

    public static readonly Selector SetOutputTextureFormat = Selector.Register("setOutputTextureFormat:");

    public static readonly Selector SetInputWidth = Selector.Register("setInputWidth:");

    public static readonly Selector SetInputHeight = Selector.Register("setInputHeight:");

    public static readonly Selector SetOutputWidth = Selector.Register("setOutputWidth:");

    public static readonly Selector SetOutputHeight = Selector.Register("setOutputHeight:");

    public static readonly Selector SetRequiresSynchronousInitialization = Selector.Register("setRequiresSynchronousInitialization:");

    public static readonly Selector SetAutoExposureEnabled = Selector.Register("setAutoExposureEnabled:");

    public static readonly Selector SetInputContentPropertiesEnabled = Selector.Register("setInputContentPropertiesEnabled:");

    public static readonly Selector SetInputContentMinScale = Selector.Register("setInputContentMinScale:");

    public static readonly Selector SetInputContentMaxScale = Selector.Register("setInputContentMaxScale:");

    public static readonly Selector SetReactiveMaskTextureEnabled = Selector.Register("setReactiveMaskTextureEnabled:");

    public static readonly Selector SetReactiveMaskTextureFormat = Selector.Register("setReactiveMaskTextureFormat:");

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
