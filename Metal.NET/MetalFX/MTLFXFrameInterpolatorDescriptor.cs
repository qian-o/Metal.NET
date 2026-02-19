namespace Metal.NET;

public class MTLFXFrameInterpolatorDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
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
        get => GetProperty(ref field, MTLFXFrameInterpolatorDescriptorBindings.Scaler);
        set => SetProperty(ref field, MTLFXFrameInterpolatorDescriptorBindings.SetScaler, value);
    }

    public MTLPixelFormat UiTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.UiTextureFormat);
    }

    public MTLFXFrameInterpolator? NewFrameInterpolator(MTLDevice pDevice)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.NewFrameInterpolator, pDevice.NativePtr);
        return ptr is not 0 ? new MTLFXFrameInterpolator(ptr) : null;
    }

    public MTL4FXFrameInterpolator? NewFrameInterpolator(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.NewFrameInterpolator, pDevice.NativePtr, pCompiler.NativePtr);
        return ptr is not 0 ? new MTL4FXFrameInterpolator(ptr) : null;
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

    public static readonly Selector ColorTextureFormat = "colorTextureFormat";

    public static readonly Selector DepthTextureFormat = "depthTextureFormat";

    public static readonly Selector InputHeight = "inputHeight";

    public static readonly Selector InputWidth = "inputWidth";

    public static readonly Selector MotionTextureFormat = "motionTextureFormat";

    public static readonly Selector NewFrameInterpolator = "newFrameInterpolatorWithDevice:";

    public static readonly Selector OutputHeight = "outputHeight";

    public static readonly Selector OutputTextureFormat = "outputTextureFormat";

    public static readonly Selector OutputWidth = "outputWidth";

    public static readonly Selector Scaler = "scaler";

    public static readonly Selector SetColorTextureFormat = "setColorTextureFormat:";

    public static readonly Selector SetDepthTextureFormat = "setDepthTextureFormat:";

    public static readonly Selector SetInputHeight = "setInputHeight:";

    public static readonly Selector SetInputWidth = "setInputWidth:";

    public static readonly Selector SetMotionTextureFormat = "setMotionTextureFormat:";

    public static readonly Selector SetOutputHeight = "setOutputHeight:";

    public static readonly Selector SetOutputTextureFormat = "setOutputTextureFormat:";

    public static readonly Selector SetOutputWidth = "setOutputWidth:";

    public static readonly Selector SetScaler = "setScaler:";

    public static readonly Selector SupportsDevice = "supportsDevice:";

    public static readonly Selector SupportsMetal4FX = "supportsMetal4FX:";

    public static readonly Selector UiTextureFormat = "uiTextureFormat";
}
