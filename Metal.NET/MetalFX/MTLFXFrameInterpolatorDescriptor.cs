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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLFXFrameInterpolatorDescriptor");

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.ColorTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetColorTextureFormat, (uint)value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.OutputTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetOutputTextureFormat, (uint)value);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.DepthTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetDepthTextureFormat, (uint)value);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.MotionTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetMotionTextureFormat, (uint)value);
    }

    public MTLPixelFormat UiTextureFormat => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.UiTextureFormat));

    public MTLFXFrameInterpolatableScaler Scaler
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.Scaler));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetScaler, value.NativePtr);
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.InputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetInputWidth, (nuint)value);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.InputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetInputHeight, (nuint)value);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.OutputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetOutputWidth, (nuint)value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.OutputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetOutputHeight, (nuint)value);
    }

    public void SetUITextureFormat(MTLPixelFormat uiTextureFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetUITextureFormat, (uint)uiTextureFormat);
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

    public static Bool8 SupportsMetal4FX(MTLDevice device)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(s_class, MTLFXFrameInterpolatorDescriptorSelector.SupportsMetal4FX, device.NativePtr);

        return result;
    }

    public static Bool8 SupportsDevice(MTLDevice device)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(s_class, MTLFXFrameInterpolatorDescriptorSelector.SupportsDevice, device.NativePtr);

        return result;
    }

}

file class MTLFXFrameInterpolatorDescriptorSelector
{
    public static readonly Selector ColorTextureFormat = Selector.Register("colorTextureFormat");

    public static readonly Selector SetColorTextureFormat = Selector.Register("setColorTextureFormat:");

    public static readonly Selector OutputTextureFormat = Selector.Register("outputTextureFormat");

    public static readonly Selector SetOutputTextureFormat = Selector.Register("setOutputTextureFormat:");

    public static readonly Selector DepthTextureFormat = Selector.Register("depthTextureFormat");

    public static readonly Selector SetDepthTextureFormat = Selector.Register("setDepthTextureFormat:");

    public static readonly Selector MotionTextureFormat = Selector.Register("motionTextureFormat");

    public static readonly Selector SetMotionTextureFormat = Selector.Register("setMotionTextureFormat:");

    public static readonly Selector UiTextureFormat = Selector.Register("uiTextureFormat");

    public static readonly Selector Scaler = Selector.Register("scaler");

    public static readonly Selector SetScaler = Selector.Register("setScaler:");

    public static readonly Selector InputWidth = Selector.Register("inputWidth");

    public static readonly Selector SetInputWidth = Selector.Register("setInputWidth:");

    public static readonly Selector InputHeight = Selector.Register("inputHeight");

    public static readonly Selector SetInputHeight = Selector.Register("setInputHeight:");

    public static readonly Selector OutputWidth = Selector.Register("outputWidth");

    public static readonly Selector SetOutputWidth = Selector.Register("setOutputWidth:");

    public static readonly Selector OutputHeight = Selector.Register("outputHeight");

    public static readonly Selector SetOutputHeight = Selector.Register("setOutputHeight:");

    public static readonly Selector SetUITextureFormat = Selector.Register("setUITextureFormat:");

    public static readonly Selector NewFrameInterpolator = Selector.Register("newFrameInterpolator:");

    public static readonly Selector NewFrameInterpolatorPCompiler = Selector.Register("newFrameInterpolator:pCompiler:");

    public static readonly Selector SupportsMetal4FX = Selector.Register("supportsMetal4FX:");

    public static readonly Selector SupportsDevice = Selector.Register("supportsDevice:");
}
