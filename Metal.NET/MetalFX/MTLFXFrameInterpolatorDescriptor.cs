namespace Metal.NET;

public readonly struct MTLFXFrameInterpolatorDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLFXFrameInterpolatorDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLFXFrameInterpolatorDescriptorBindings.Class))
    {
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.ColorTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetColorTextureFormat, (nuint)value);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.DepthTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetDepthTextureFormat, (nuint)value);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.InputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetInputHeight, value);
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.InputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetInputWidth, value);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.MotionTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetMotionTextureFormat, (nuint)value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.OutputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetOutputHeight, value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.OutputTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetOutputTextureFormat, (nuint)value);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.OutputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetOutputWidth, value);
    }

    public MTLFXFrameInterpolatableScaler? Scaler
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.Scaler);
            return ptr is not 0 ? new MTLFXFrameInterpolatableScaler(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetScaler, value?.NativePtr ?? 0);
    }

    public MTLPixelFormat UiTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.UiTextureFormat);
    }

    public MTLFXFrameInterpolator? NewFrameInterpolator(MTLDevice pDevice)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.NewFrameInterpolator, pDevice.NativePtr);
        return ptr is not 0 ? new MTLFXFrameInterpolator(ptr) : default;
    }

    public MTL4FXFrameInterpolator? NewFrameInterpolator(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.NewFrameInterpolator, pDevice.NativePtr, pCompiler.NativePtr);
        return ptr is not 0 ? new MTL4FXFrameInterpolator(ptr) : default;
    }

    public static bool SupportsMetal4FX(MTLDevice device)
    {
        return ObjectiveCRuntime.MsgSendBool(MTLFXFrameInterpolatorDescriptorBindings.Class, MTLFXFrameInterpolatorDescriptorBindings.SupportsMetal4FX, device.NativePtr);
    }

    public static bool SupportsDevice(MTLDevice device)
    {
        return ObjectiveCRuntime.MsgSendBool(MTLFXFrameInterpolatorDescriptorBindings.Class, MTLFXFrameInterpolatorDescriptorBindings.SupportsDevice, device.NativePtr);
    }
}

file static class MTLFXFrameInterpolatorDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFXFrameInterpolatorDescriptor");

    public static readonly Selector ColorTextureFormat = Selector.Register("colorTextureFormat");

    public static readonly Selector DepthTextureFormat = Selector.Register("depthTextureFormat");

    public static readonly Selector InputHeight = Selector.Register("inputHeight");

    public static readonly Selector InputWidth = Selector.Register("inputWidth");

    public static readonly Selector MotionTextureFormat = Selector.Register("motionTextureFormat");

    public static readonly Selector NewFrameInterpolator = Selector.Register("newFrameInterpolatorWithDevice:");

    public static readonly Selector OutputHeight = Selector.Register("outputHeight");

    public static readonly Selector OutputTextureFormat = Selector.Register("outputTextureFormat");

    public static readonly Selector OutputWidth = Selector.Register("outputWidth");

    public static readonly Selector Scaler = Selector.Register("scaler");

    public static readonly Selector SetColorTextureFormat = Selector.Register("setColorTextureFormat:");

    public static readonly Selector SetDepthTextureFormat = Selector.Register("setDepthTextureFormat:");

    public static readonly Selector SetInputHeight = Selector.Register("setInputHeight:");

    public static readonly Selector SetInputWidth = Selector.Register("setInputWidth:");

    public static readonly Selector SetMotionTextureFormat = Selector.Register("setMotionTextureFormat:");

    public static readonly Selector SetOutputHeight = Selector.Register("setOutputHeight:");

    public static readonly Selector SetOutputTextureFormat = Selector.Register("setOutputTextureFormat:");

    public static readonly Selector SetOutputWidth = Selector.Register("setOutputWidth:");

    public static readonly Selector SetScaler = Selector.Register("setScaler:");

    public static readonly Selector SupportsDevice = Selector.Register("supportsDevice:");

    public static readonly Selector SupportsMetal4FX = Selector.Register("supportsMetal4FX:");

    public static readonly Selector UiTextureFormat = Selector.Register("uiTextureFormat");
}
