namespace Metal.NET;

public class MTLFXFrameInterpolatorDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFXFrameInterpolatorDescriptor>
{
    #region INativeObject
    public static new MTLFXFrameInterpolatorDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXFrameInterpolatorDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFXFrameInterpolatorDescriptor() : this(ObjectiveC.AllocInit(MTLFXFrameInterpolatorDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.ColorTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetColorTextureFormat, (nuint)value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.OutputTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetOutputTextureFormat, (nuint)value);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.DepthTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetDepthTextureFormat, (nuint)value);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.MotionTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetMotionTextureFormat, (nuint)value);
    }

    public MTLPixelFormat UiTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.UiTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetUiTextureFormat, (nuint)value);
    }

    public MTLFXFrameInterpolatableScaler Scaler
    {
        get => GetProperty(ref field, MTLFXFrameInterpolatorDescriptorBindings.Scaler);
        set => SetProperty(ref field, MTLFXFrameInterpolatorDescriptorBindings.SetScaler, value);
    }

    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.InputWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetInputWidth, value);
    }

    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.InputHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetInputHeight, value);
    }

    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.OutputWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetOutputWidth, value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.OutputHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetOutputHeight, value);
    }

    public MTLFXFrameInterpolator MakeFrameInterpolator(MTLDevice device)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.NewFrameInterpolatorWithDevice, device.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4FXFrameInterpolator MakeFrameInterpolator(MTLDevice device, MTL4Compiler compiler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.NewFrameInterpolatorWithDeviceCompiler, device.NativePtr, compiler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static bool SupportsMetal4FX(MTLDevice device)
    {
        return ObjectiveC.MsgSendBool(MTLFXFrameInterpolatorDescriptorBindings.Class, MTLFXFrameInterpolatorDescriptorBindings.SupportsMetal4FX, device.NativePtr);
    }

    public static bool SupportsDevice(MTLDevice device)
    {
        return ObjectiveC.MsgSendBool(MTLFXFrameInterpolatorDescriptorBindings.Class, MTLFXFrameInterpolatorDescriptorBindings.SupportsDevice, device.NativePtr);
    }
}

file static class MTLFXFrameInterpolatorDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFXFrameInterpolatorDescriptor");

    public static readonly Selector ColorTextureFormat = "colorTextureFormat";

    public static readonly Selector DepthTextureFormat = "depthTextureFormat";

    public static readonly Selector InputHeight = "inputHeight";

    public static readonly Selector InputWidth = "inputWidth";

    public static readonly Selector MotionTextureFormat = "motionTextureFormat";

    public static readonly Selector NewFrameInterpolatorWithDevice = "newFrameInterpolatorWithDevice:";

    public static readonly Selector NewFrameInterpolatorWithDeviceCompiler = "newFrameInterpolatorWithDevice:compiler:";

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

    public static readonly Selector SetUiTextureFormat = "setUITextureFormat:";

    public static readonly Selector SupportsDevice = "supportsDevice:";

    public static readonly Selector SupportsMetal4FX = "supportsMetal4FX:";

    public static readonly Selector UiTextureFormat = "uiTextureFormat";
}
