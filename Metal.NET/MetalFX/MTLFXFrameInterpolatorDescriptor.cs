namespace Metal.NET;

public class MTLFXFrameInterpolatorDescriptor : IDisposable
{
    public MTLFXFrameInterpolatorDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetColorTextureFormat, (nint)(uint)colorTextureFormat);
    }

    public void SetOutputTextureFormat(MTLPixelFormat outputTextureFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetOutputTextureFormat, (nint)(uint)outputTextureFormat);
    }

    public void SetDepthTextureFormat(MTLPixelFormat depthTextureFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetDepthTextureFormat, (nint)(uint)depthTextureFormat);
    }

    public void SetMotionTextureFormat(MTLPixelFormat motionTextureFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetMotionTextureFormat, (nint)(uint)motionTextureFormat);
    }

    public void SetUITextureFormat(MTLPixelFormat uiTextureFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetUITextureFormat, (nint)(uint)uiTextureFormat);
    }

    public void SetScaler(MTLFXFrameInterpolatableScaler scaler)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetScaler, scaler.NativePtr);
    }

    public void SetInputWidth(uint inputWidth)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetInputWidth, (nint)inputWidth);
    }

    public void SetInputHeight(uint inputHeight)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetInputHeight, (nint)inputHeight);
    }

    public void SetOutputWidth(uint outputWidth)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetOutputWidth, (nint)outputWidth);
    }

    public void SetOutputHeight(uint outputHeight)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetOutputHeight, (nint)outputHeight);
    }

    public MTLFXFrameInterpolator NewFrameInterpolator(MTLDevice pDevice)
    {
        MTLFXFrameInterpolator result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.NewFrameInterpolator, pDevice.NativePtr));

        return result;
    }

    public MTLFXFrameInterpolator NewFrameInterpolator(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        MTLFXFrameInterpolator result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.NewFrameInterpolatorPCompiler, pDevice.NativePtr, pCompiler.NativePtr));

        return result;
    }

    public static Bool8 SupportsMetal4FX(MTLDevice device)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(s_class, MTLFXFrameInterpolatorDescriptorSelector.SupportsMetal4FX, device.NativePtr) is not 0;

        return result;
    }

    public static Bool8 SupportsDevice(MTLDevice device)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(s_class, MTLFXFrameInterpolatorDescriptorSelector.SupportsDevice, device.NativePtr) is not 0;

        return result;
    }

}

file class MTLFXFrameInterpolatorDescriptorSelector
{
    public static readonly Selector SetColorTextureFormat = Selector.Register("setColorTextureFormat:");

    public static readonly Selector SetOutputTextureFormat = Selector.Register("setOutputTextureFormat:");

    public static readonly Selector SetDepthTextureFormat = Selector.Register("setDepthTextureFormat:");

    public static readonly Selector SetMotionTextureFormat = Selector.Register("setMotionTextureFormat:");

    public static readonly Selector SetUITextureFormat = Selector.Register("setUITextureFormat:");

    public static readonly Selector SetScaler = Selector.Register("setScaler:");

    public static readonly Selector SetInputWidth = Selector.Register("setInputWidth:");

    public static readonly Selector SetInputHeight = Selector.Register("setInputHeight:");

    public static readonly Selector SetOutputWidth = Selector.Register("setOutputWidth:");

    public static readonly Selector SetOutputHeight = Selector.Register("setOutputHeight:");

    public static readonly Selector NewFrameInterpolator = Selector.Register("newFrameInterpolator:");

    public static readonly Selector NewFrameInterpolatorPCompiler = Selector.Register("newFrameInterpolator:pCompiler:");

    public static readonly Selector SupportsMetal4FX = Selector.Register("supportsMetal4FX:");

    public static readonly Selector SupportsDevice = Selector.Register("supportsDevice:");
}
