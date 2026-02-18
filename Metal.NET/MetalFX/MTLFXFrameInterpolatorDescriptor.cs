namespace Metal.NET;

public class MTLFXFrameInterpolatorDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLFXFrameInterpolatorDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLFXFrameInterpolatorDescriptorSelector.Class))
    {
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.ColorTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetColorTextureFormat, (nuint)value);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.DepthTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetDepthTextureFormat, (nuint)value);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.InputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetInputHeight, value);
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.InputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetInputWidth, value);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.MotionTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetMotionTextureFormat, (nuint)value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.OutputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetOutputHeight, value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.OutputTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetOutputTextureFormat, (nuint)value);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.OutputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetOutputWidth, value);
    }

    public MTLFXFrameInterpolatableScaler? Scaler
    {
        get => GetNullableObject<MTLFXFrameInterpolatableScaler>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.Scaler));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.SetScaler, value?.NativePtr ?? 0);
    }

    public MTLPixelFormat UiTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.UiTextureFormat);
    }

    public MTLFXFrameInterpolator? NewFrameInterpolator(MTLDevice pDevice)
    {
        return GetNullableObject<MTLFXFrameInterpolator>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.NewFrameInterpolator, pDevice.NativePtr));
    }

    public MTL4FXFrameInterpolator? NewFrameInterpolator(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        return GetNullableObject<MTL4FXFrameInterpolator>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorDescriptorSelector.NewFrameInterpolator, pDevice.NativePtr, pCompiler.NativePtr));
    }

    public static bool SupportsMetal4FX(MTLDevice device)
    {
        return ObjectiveCRuntime.MsgSendBool(MTLFXFrameInterpolatorDescriptorSelector.Class, MTLFXFrameInterpolatorDescriptorSelector.SupportsMetal4FX, device.NativePtr);
    }

    public static bool SupportsDevice(MTLDevice device)
    {
        return ObjectiveCRuntime.MsgSendBool(MTLFXFrameInterpolatorDescriptorSelector.Class, MTLFXFrameInterpolatorDescriptorSelector.SupportsDevice, device.NativePtr);
    }
}

file static class MTLFXFrameInterpolatorDescriptorSelector
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
