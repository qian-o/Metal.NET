namespace Metal.NET;

file class MTLFXFrameInterpolatorDescriptorSelector
{
    public static readonly Selector SetColorTextureFormat_ = Selector.Register("setColorTextureFormat:");
    public static readonly Selector SetOutputTextureFormat_ = Selector.Register("setOutputTextureFormat:");
    public static readonly Selector SetDepthTextureFormat_ = Selector.Register("setDepthTextureFormat:");
    public static readonly Selector SetMotionTextureFormat_ = Selector.Register("setMotionTextureFormat:");
    public static readonly Selector SetUITextureFormat_ = Selector.Register("setUITextureFormat:");
    public static readonly Selector SetScaler_ = Selector.Register("setScaler:");
    public static readonly Selector SetInputWidth_ = Selector.Register("setInputWidth:");
    public static readonly Selector SetInputHeight_ = Selector.Register("setInputHeight:");
    public static readonly Selector SetOutputWidth_ = Selector.Register("setOutputWidth:");
    public static readonly Selector SetOutputHeight_ = Selector.Register("setOutputHeight:");
    public static readonly Selector NewFrameInterpolator_ = Selector.Register("newFrameInterpolator:");
    public static readonly Selector NewFrameInterpolator_pCompiler_ = Selector.Register("newFrameInterpolator:pCompiler:");
    public static readonly Selector SupportsMetal4FX_ = Selector.Register("supportsMetal4FX:");
    public static readonly Selector SupportsDevice_ = Selector.Register("supportsDevice:");
}

public class MTLFXFrameInterpolatorDescriptor : IDisposable
{
    public MTLFXFrameInterpolatorDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLFXFrameInterpolatorDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLFXFrameInterpolatorDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXFrameInterpolatorDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFXFrameInterpolatorDescriptor");

    public void SetColorTextureFormat(MTLPixelFormat colorTextureFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetColorTextureFormat_, (nint)(uint)colorTextureFormat);
    }

    public void SetOutputTextureFormat(MTLPixelFormat outputTextureFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetOutputTextureFormat_, (nint)(uint)outputTextureFormat);
    }

    public void SetDepthTextureFormat(MTLPixelFormat depthTextureFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetDepthTextureFormat_, (nint)(uint)depthTextureFormat);
    }

    public void SetMotionTextureFormat(MTLPixelFormat motionTextureFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetMotionTextureFormat_, (nint)(uint)motionTextureFormat);
    }

    public void SetUITextureFormat(MTLPixelFormat uiTextureFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetUITextureFormat_, (nint)(uint)uiTextureFormat);
    }

    public void SetScaler(MTLFXFrameInterpolatableScaler scaler)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetScaler_, scaler.NativePtr);
    }

    public void SetInputWidth(nuint inputWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetInputWidth_, (nint)inputWidth);
    }

    public void SetInputHeight(nuint inputHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetInputHeight_, (nint)inputHeight);
    }

    public void SetOutputWidth(nuint outputWidth)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetOutputWidth_, (nint)outputWidth);
    }

    public void SetOutputHeight(nuint outputHeight)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetOutputHeight_, (nint)outputHeight);
    }

    public MTLFXFrameInterpolator NewFrameInterpolator(MTLDevice pDevice)
    {
        var result = new MTLFXFrameInterpolator(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.NewFrameInterpolator_, pDevice.NativePtr));

        return result;
    }

    public MTLFXFrameInterpolator NewFrameInterpolator(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        var result = new MTLFXFrameInterpolator(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.NewFrameInterpolator_pCompiler_, pDevice.NativePtr, pCompiler.NativePtr));

        return result;
    }

    public static Bool8 SupportsMetal4FX(MTLDevice device)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXFrameInterpolatorDescriptorSelector.SupportsMetal4FX_, device.NativePtr) is not 0;

        return result;
    }

    public static Bool8 SupportsDevice(MTLDevice device)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLFXFrameInterpolatorDescriptorSelector.SupportsDevice_, device.NativePtr) is not 0;

        return result;
    }

}
