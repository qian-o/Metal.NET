namespace Metal.NET;

public class MTLFXTemporalScalerDescriptor : IDisposable
{
    public MTLFXTemporalScalerDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetColorTextureFormat, (nint)(uint)format);
    }

    public void SetDepthTextureFormat(MTLPixelFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetDepthTextureFormat, (nint)(uint)format);
    }

    public void SetMotionTextureFormat(MTLPixelFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetMotionTextureFormat, (nint)(uint)format);
    }

    public void SetOutputTextureFormat(MTLPixelFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetOutputTextureFormat, (nint)(uint)format);
    }

    public void SetInputWidth(uint width)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetInputWidth, (nint)width);
    }

    public void SetInputHeight(uint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetInputHeight, (nint)height);
    }

    public void SetOutputWidth(uint width)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetOutputWidth, (nint)width);
    }

    public void SetOutputHeight(uint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetOutputHeight, (nint)height);
    }

    public void SetAutoExposureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetAutoExposureEnabled, (nint)enabled.Value);
    }

    public void SetInputContentPropertiesEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetInputContentPropertiesEnabled, (nint)enabled.Value);
    }

    public void SetRequiresSynchronousInitialization(Bool8 requiresSynchronousInitialization)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetRequiresSynchronousInitialization, (nint)requiresSynchronousInitialization.Value);
    }

    public void SetReactiveMaskTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetReactiveMaskTextureEnabled, (nint)enabled.Value);
    }

    public void SetReactiveMaskTextureFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetReactiveMaskTextureFormat, (nint)(uint)pixelFormat);
    }

    public void SetInputContentMinScale(float scale)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetInputContentMinScale, scale);
    }

    public void SetInputContentMaxScale(float scale)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetInputContentMaxScale, scale);
    }

    public MTLFXTemporalScaler NewTemporalScaler(MTLDevice pDevice)
    {
        var result = new MTLFXTemporalScaler(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.NewTemporalScaler, pDevice.NativePtr));

        return result;
    }

    public MTLFXTemporalScaler NewTemporalScaler(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        var result = new MTLFXTemporalScaler(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.NewTemporalScalerPCompiler, pDevice.NativePtr, pCompiler.NativePtr));

        return result;
    }

    public static float SupportedInputContentMinScale(MTLDevice pDevice)
    {
        var result = BitConverter.Int32BitsToSingle((int)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalScalerDescriptorSelector.SupportedInputContentMinScale, pDevice.NativePtr));

        return result;
    }

    public static float SupportedInputContentMaxScale(MTLDevice pDevice)
    {
        var result = BitConverter.Int32BitsToSingle((int)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalScalerDescriptorSelector.SupportedInputContentMaxScale, pDevice.NativePtr));

        return result;
    }

    public static Bool8 SupportsDevice(MTLDevice pDevice)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalScalerDescriptorSelector.SupportsDevice, pDevice.NativePtr) is not 0;

        return result;
    }

    public static Bool8 SupportsMetal4FX(MTLDevice pDevice)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXTemporalScalerDescriptorSelector.SupportsMetal4FX, pDevice.NativePtr) is not 0;

        return result;
    }

}

file class MTLFXTemporalScalerDescriptorSelector
{
    public static readonly Selector SetColorTextureFormat = Selector.Register("setColorTextureFormat:");
    public static readonly Selector SetDepthTextureFormat = Selector.Register("setDepthTextureFormat:");
    public static readonly Selector SetMotionTextureFormat = Selector.Register("setMotionTextureFormat:");
    public static readonly Selector SetOutputTextureFormat = Selector.Register("setOutputTextureFormat:");
    public static readonly Selector SetInputWidth = Selector.Register("setInputWidth:");
    public static readonly Selector SetInputHeight = Selector.Register("setInputHeight:");
    public static readonly Selector SetOutputWidth = Selector.Register("setOutputWidth:");
    public static readonly Selector SetOutputHeight = Selector.Register("setOutputHeight:");
    public static readonly Selector SetAutoExposureEnabled = Selector.Register("setAutoExposureEnabled:");
    public static readonly Selector SetInputContentPropertiesEnabled = Selector.Register("setInputContentPropertiesEnabled:");
    public static readonly Selector SetRequiresSynchronousInitialization = Selector.Register("setRequiresSynchronousInitialization:");
    public static readonly Selector SetReactiveMaskTextureEnabled = Selector.Register("setReactiveMaskTextureEnabled:");
    public static readonly Selector SetReactiveMaskTextureFormat = Selector.Register("setReactiveMaskTextureFormat:");
    public static readonly Selector SetInputContentMinScale = Selector.Register("setInputContentMinScale:");
    public static readonly Selector SetInputContentMaxScale = Selector.Register("setInputContentMaxScale:");
    public static readonly Selector NewTemporalScaler = Selector.Register("newTemporalScaler:");
    public static readonly Selector NewTemporalScalerPCompiler = Selector.Register("newTemporalScaler:pCompiler:");
    public static readonly Selector SupportedInputContentMinScale = Selector.Register("supportedInputContentMinScale:");
    public static readonly Selector SupportedInputContentMaxScale = Selector.Register("supportedInputContentMaxScale:");
    public static readonly Selector SupportsDevice = Selector.Register("supportsDevice:");
    public static readonly Selector SupportsMetal4FX = Selector.Register("supportsMetal4FX:");
}
