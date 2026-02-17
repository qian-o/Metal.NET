namespace Metal.NET;

file class MTLFXTemporalDenoisedScalerDescriptorSelector
{
    public static readonly Selector SetColorTextureFormat_ = Selector.Register("setColorTextureFormat:");
    public static readonly Selector SetDepthTextureFormat_ = Selector.Register("setDepthTextureFormat:");
    public static readonly Selector SetMotionTextureFormat_ = Selector.Register("setMotionTextureFormat:");
    public static readonly Selector SetDiffuseAlbedoTextureFormat_ = Selector.Register("setDiffuseAlbedoTextureFormat:");
    public static readonly Selector SetSpecularAlbedoTextureFormat_ = Selector.Register("setSpecularAlbedoTextureFormat:");
    public static readonly Selector SetNormalTextureFormat_ = Selector.Register("setNormalTextureFormat:");
    public static readonly Selector SetRoughnessTextureFormat_ = Selector.Register("setRoughnessTextureFormat:");
    public static readonly Selector SetSpecularHitDistanceTextureFormat_ = Selector.Register("setSpecularHitDistanceTextureFormat:");
    public static readonly Selector SetDenoiseStrengthMaskTextureFormat_ = Selector.Register("setDenoiseStrengthMaskTextureFormat:");
    public static readonly Selector SetTransparencyOverlayTextureFormat_ = Selector.Register("setTransparencyOverlayTextureFormat:");
    public static readonly Selector SetOutputTextureFormat_ = Selector.Register("setOutputTextureFormat:");
    public static readonly Selector SetInputWidth_ = Selector.Register("setInputWidth:");
    public static readonly Selector SetInputHeight_ = Selector.Register("setInputHeight:");
    public static readonly Selector SetOutputWidth_ = Selector.Register("setOutputWidth:");
    public static readonly Selector SetOutputHeight_ = Selector.Register("setOutputHeight:");
    public static readonly Selector SetRequiresSynchronousInitialization_ = Selector.Register("setRequiresSynchronousInitialization:");
    public static readonly Selector SetAutoExposureEnabled_ = Selector.Register("setAutoExposureEnabled:");
    public static readonly Selector SetInputContentPropertiesEnabled_ = Selector.Register("setInputContentPropertiesEnabled:");
    public static readonly Selector SetInputContentMinScale_ = Selector.Register("setInputContentMinScale:");
    public static readonly Selector SetInputContentMaxScale_ = Selector.Register("setInputContentMaxScale:");
    public static readonly Selector SetReactiveMaskTextureEnabled_ = Selector.Register("setReactiveMaskTextureEnabled:");
    public static readonly Selector SetReactiveMaskTextureFormat_ = Selector.Register("setReactiveMaskTextureFormat:");
    public static readonly Selector SetSpecularHitDistanceTextureEnabled_ = Selector.Register("setSpecularHitDistanceTextureEnabled:");
    public static readonly Selector SetDenoiseStrengthMaskTextureEnabled_ = Selector.Register("setDenoiseStrengthMaskTextureEnabled:");
    public static readonly Selector SetTransparencyOverlayTextureEnabled_ = Selector.Register("setTransparencyOverlayTextureEnabled:");
    public static readonly Selector NewTemporalDenoisedScaler_ = Selector.Register("newTemporalDenoisedScaler:");
    public static readonly Selector NewTemporalDenoisedScaler_compiler_ = Selector.Register("newTemporalDenoisedScaler:compiler:");
    public static readonly Selector SupportedInputContentMinScale_ = Selector.Register("supportedInputContentMinScale:");
    public static readonly Selector SupportedInputContentMaxScale_ = Selector.Register("supportedInputContentMaxScale:");
    public static readonly Selector SupportsMetal4FX_ = Selector.Register("supportsMetal4FX:");
    public static readonly Selector SupportsDevice_ = Selector.Register("supportsDevice:");
}

public class MTLFXTemporalDenoisedScalerDescriptor : IDisposable
{
    public MTLFXTemporalDenoisedScalerDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetColorTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetDepthTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetDepthTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetMotionTextureFormat(MTLPixelFormat pixelFormal)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetMotionTextureFormat_, (nint)(uint)pixelFormal);
    }

    public void SetDiffuseAlbedoTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetDiffuseAlbedoTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetSpecularAlbedoTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetSpecularAlbedoTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetNormalTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetNormalTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetRoughnessTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetRoughnessTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetSpecularHitDistanceTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetSpecularHitDistanceTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetDenoiseStrengthMaskTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetDenoiseStrengthMaskTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetTransparencyOverlayTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetTransparencyOverlayTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetOutputTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetOutputTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetInputWidth(nuint inputWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetInputWidth_, (nint)inputWidth);
    }

    public void SetInputHeight(nuint inputHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetInputHeight_, (nint)inputHeight);
    }

    public void SetOutputWidth(nuint outputWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetOutputWidth_, (nint)outputWidth);
    }

    public void SetOutputHeight(nuint outputHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetOutputHeight_, (nint)outputHeight);
    }

    public void SetRequiresSynchronousInitialization(Bool8 requiresSynchronousInitialization)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetRequiresSynchronousInitialization_, (nint)requiresSynchronousInitialization.Value);
    }

    public void SetAutoExposureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetAutoExposureEnabled_, (nint)enabled.Value);
    }

    public void SetInputContentPropertiesEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetInputContentPropertiesEnabled_, (nint)enabled.Value);
    }

    public void SetInputContentMinScale(float inputContentMinScale)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetInputContentMinScale_, inputContentMinScale);
    }

    public void SetInputContentMaxScale(float inputContentMaxScale)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetInputContentMaxScale_, inputContentMaxScale);
    }

    public void SetReactiveMaskTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetReactiveMaskTextureEnabled_, (nint)enabled.Value);
    }

    public void SetReactiveMaskTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetReactiveMaskTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetSpecularHitDistanceTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetSpecularHitDistanceTextureEnabled_, (nint)enabled.Value);
    }

    public void SetDenoiseStrengthMaskTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetDenoiseStrengthMaskTextureEnabled_, (nint)enabled.Value);
    }

    public void SetTransparencyOverlayTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.SetTransparencyOverlayTextureEnabled_, (nint)enabled.Value);
    }

    public MTLFXTemporalDenoisedScaler NewTemporalDenoisedScaler(MTLDevice device)
    {
        var result = new MTLFXTemporalDenoisedScaler(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.NewTemporalDenoisedScaler_, device.NativePtr));

        return result;
    }

    public MTLFXTemporalDenoisedScaler NewTemporalDenoisedScaler(MTLDevice device, MTL4Compiler compiler)
    {
        var result = new MTLFXTemporalDenoisedScaler(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXTemporalDenoisedScalerDescriptorSelector.NewTemporalDenoisedScaler_compiler_, device.NativePtr, compiler.NativePtr));

        return result;
    }

    public static float SupportedInputContentMinScale(MTLDevice device)
    {
        var result = BitConverter.Int32BitsToSingle((int)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalDenoisedScalerDescriptorSelector.SupportedInputContentMinScale_, device.NativePtr));

        return result;
    }

    public static float SupportedInputContentMaxScale(MTLDevice device)
    {
        var result = BitConverter.Int32BitsToSingle((int)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalDenoisedScalerDescriptorSelector.SupportedInputContentMaxScale_, device.NativePtr));

        return result;
    }

    public static Bool8 SupportsMetal4FX(MTLDevice device)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalDenoisedScalerDescriptorSelector.SupportsMetal4FX_, device.NativePtr) is not 0;

        return result;
    }

    public static Bool8 SupportsDevice(MTLDevice device)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalDenoisedScalerDescriptorSelector.SupportsDevice_, device.NativePtr) is not 0;

        return result;
    }

}
