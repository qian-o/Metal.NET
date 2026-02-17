namespace Metal.NET;

file class MTLFXSpatialScalerDescriptorSelector
{
    public static readonly Selector SetColorTextureFormat_ = Selector.Register("setColorTextureFormat:");
    public static readonly Selector SetOutputTextureFormat_ = Selector.Register("setOutputTextureFormat:");
    public static readonly Selector SetInputWidth_ = Selector.Register("setInputWidth:");
    public static readonly Selector SetInputHeight_ = Selector.Register("setInputHeight:");
    public static readonly Selector SetOutputWidth_ = Selector.Register("setOutputWidth:");
    public static readonly Selector SetOutputHeight_ = Selector.Register("setOutputHeight:");
    public static readonly Selector SetColorProcessingMode_ = Selector.Register("setColorProcessingMode:");
    public static readonly Selector NewSpatialScaler_ = Selector.Register("newSpatialScaler:");
    public static readonly Selector NewSpatialScaler_pCompiler_ = Selector.Register("newSpatialScaler:pCompiler:");
    public static readonly Selector SupportsDevice_ = Selector.Register("supportsDevice:");
    public static readonly Selector SupportsMetal4FX_ = Selector.Register("supportsMetal4FX:");
}

public class MTLFXSpatialScalerDescriptor : IDisposable
{
    public MTLFXSpatialScalerDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLFXSpatialScalerDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFXSpatialScalerDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXSpatialScalerDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFXSpatialScalerDescriptor");

    public void SetColorTextureFormat(MTLPixelFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetColorTextureFormat_, (nint)(uint)format);
    }

    public void SetOutputTextureFormat(MTLPixelFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetOutputTextureFormat_, (nint)(uint)format);
    }

    public void SetInputWidth(nuint width)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetInputWidth_, (nint)width);
    }

    public void SetInputHeight(nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetInputHeight_, (nint)height);
    }

    public void SetOutputWidth(nuint width)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetOutputWidth_, (nint)width);
    }

    public void SetOutputHeight(nuint height)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetOutputHeight_, (nint)height);
    }

    public void SetColorProcessingMode(MTLFXSpatialScalerColorProcessingMode mode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetColorProcessingMode_, (nint)(uint)mode);
    }

    public MTLFXSpatialScaler NewSpatialScaler(MTLDevice pDevice)
    {
        var result = new MTLFXSpatialScaler(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.NewSpatialScaler_, pDevice.NativePtr));

        return result;
    }

    public MTLFXSpatialScaler NewSpatialScaler(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        var result = new MTLFXSpatialScaler(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.NewSpatialScaler_pCompiler_, pDevice.NativePtr, pCompiler.NativePtr));

        return result;
    }

    public static Bool8 SupportsDevice(MTLDevice pDevice)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXSpatialScalerDescriptorSelector.SupportsDevice_, pDevice.NativePtr) is not 0;

        return result;
    }

    public static Bool8 SupportsMetal4FX(MTLDevice pDevice)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXSpatialScalerDescriptorSelector.SupportsMetal4FX_, pDevice.NativePtr) is not 0;

        return result;
    }

}
