namespace Metal.NET;

file class MTLFXTemporalScalerDescriptorSelector
{
    public static readonly Selector SetColorTextureFormat_ = Selector.Register("setColorTextureFormat:");
    public static readonly Selector SetDepthTextureFormat_ = Selector.Register("setDepthTextureFormat:");
    public static readonly Selector SetMotionTextureFormat_ = Selector.Register("setMotionTextureFormat:");
    public static readonly Selector SetOutputTextureFormat_ = Selector.Register("setOutputTextureFormat:");
    public static readonly Selector SetInputWidth_ = Selector.Register("setInputWidth:");
    public static readonly Selector SetInputHeight_ = Selector.Register("setInputHeight:");
    public static readonly Selector SetOutputWidth_ = Selector.Register("setOutputWidth:");
    public static readonly Selector SetOutputHeight_ = Selector.Register("setOutputHeight:");
    public static readonly Selector SetAutoExposureEnabled_ = Selector.Register("setAutoExposureEnabled:");
    public static readonly Selector SetInputContentPropertiesEnabled_ = Selector.Register("setInputContentPropertiesEnabled:");
    public static readonly Selector SetRequiresSynchronousInitialization_ = Selector.Register("setRequiresSynchronousInitialization:");
    public static readonly Selector SetReactiveMaskTextureEnabled_ = Selector.Register("setReactiveMaskTextureEnabled:");
    public static readonly Selector SetReactiveMaskTextureFormat_ = Selector.Register("setReactiveMaskTextureFormat:");
    public static readonly Selector SetInputContentMinScale_ = Selector.Register("setInputContentMinScale:");
    public static readonly Selector SetInputContentMaxScale_ = Selector.Register("setInputContentMaxScale:");
    public static readonly Selector NewTemporalScaler_ = Selector.Register("newTemporalScaler:");
    public static readonly Selector NewTemporalScaler_pCompiler_ = Selector.Register("newTemporalScaler:pCompiler:");
    public static readonly Selector SupportedInputContentMinScale_ = Selector.Register("supportedInputContentMinScale:");
    public static readonly Selector SupportedInputContentMaxScale_ = Selector.Register("supportedInputContentMaxScale:");
    public static readonly Selector SupportsDevice_ = Selector.Register("supportsDevice:");
    public static readonly Selector SupportsMetal4FX_ = Selector.Register("supportsMetal4FX:");
}

public class MTLFXTemporalScalerDescriptor : IDisposable
{
    public MTLFXTemporalScalerDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLFXTemporalScalerDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFXTemporalScalerDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXTemporalScalerDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFXTemporalScalerDescriptor");

    public void SetColorTextureFormat(MTLPixelFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetColorTextureFormat_, (nint)(uint)format);
    }

    public void SetDepthTextureFormat(MTLPixelFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetDepthTextureFormat_, (nint)(uint)format);
    }

    public void SetMotionTextureFormat(MTLPixelFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetMotionTextureFormat_, (nint)(uint)format);
    }

    public void SetOutputTextureFormat(MTLPixelFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetOutputTextureFormat_, (nint)(uint)format);
    }

    public void SetInputWidth(nuint width)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetInputWidth_, (nint)width);
    }

    public void SetInputHeight(nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetInputHeight_, (nint)height);
    }

    public void SetOutputWidth(nuint width)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetOutputWidth_, (nint)width);
    }

    public void SetOutputHeight(nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetOutputHeight_, (nint)height);
    }

    public void SetAutoExposureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetAutoExposureEnabled_, (nint)enabled.Value);
    }

    public void SetInputContentPropertiesEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetInputContentPropertiesEnabled_, (nint)enabled.Value);
    }

    public void SetRequiresSynchronousInitialization(Bool8 requiresSynchronousInitialization)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetRequiresSynchronousInitialization_, (nint)requiresSynchronousInitialization.Value);
    }

    public void SetReactiveMaskTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetReactiveMaskTextureEnabled_, (nint)enabled.Value);
    }

    public void SetReactiveMaskTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetReactiveMaskTextureFormat_, (nint)(uint)pixelFormat);
    }

    public void SetInputContentMinScale(float scale)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetInputContentMinScale_, scale);
    }

    public void SetInputContentMaxScale(float scale)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetInputContentMaxScale_, scale);
    }

    public MTLFXTemporalScaler NewTemporalScaler(MTLDevice pDevice)
    {
        var result = new MTLFXTemporalScaler(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.NewTemporalScaler_, pDevice.NativePtr));

        return result;
    }

    public MTLFXTemporalScaler NewTemporalScaler(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        var result = new MTLFXTemporalScaler(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.NewTemporalScaler_pCompiler_, pDevice.NativePtr, pCompiler.NativePtr));

        return result;
    }

    public static float SupportedInputContentMinScale(MTLDevice pDevice)
    {
        var result = BitConverter.Int32BitsToSingle((int)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalScalerDescriptorSelector.SupportedInputContentMinScale_, pDevice.NativePtr));

        return result;
    }

    public static float SupportedInputContentMaxScale(MTLDevice pDevice)
    {
        var result = BitConverter.Int32BitsToSingle((int)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalScalerDescriptorSelector.SupportedInputContentMaxScale_, pDevice.NativePtr));

        return result;
    }

    public static Bool8 SupportsDevice(MTLDevice pDevice)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalScalerDescriptorSelector.SupportsDevice_, pDevice.NativePtr) is not 0;

        return result;
    }

    public static Bool8 SupportsMetal4FX(MTLDevice pDevice)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalScalerDescriptorSelector.SupportsMetal4FX_, pDevice.NativePtr) is not 0;

        return result;
    }

}
