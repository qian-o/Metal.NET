namespace Metal.NET;

public readonly struct MTLFXFrameInterpolatorDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLFXFrameInterpolatorDescriptor value) => new(value.NativePtr);

    public MTLFXFrameInterpolatorDescriptor() : this(ObjectiveC.AllocInit(MTLFXFrameInterpolatorDescriptorBindings.Class))
    {
    }

    public MTLFXFrameInterpolatorDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
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
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetUITextureFormat, (nuint)value);
    }

    public MTLFXFrameInterpolatableScaler Scaler
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.Scaler));
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetScaler, value.NativePtr);
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

    public Bool8 IsDistortionTextureEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.IsDistortionTextureEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetDistortionTextureEnabled, value);
    }

    public Bool8 RequiresPrevColorTexture
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.RequiresPrevColorTexture);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.SetRequiresPrevColorTexture, value);
    }

    public MTLFXFrameInterpolator MakeFrameInterpolator(MTLDevice device)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.NewFrameInterpolatorWithDevice, device.NativePtr);

        return new(nativePtr);
    }

    public MTL4FXFrameInterpolator MakeFrameInterpolator(MTLDevice device, MTL4Compiler compiler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXFrameInterpolatorDescriptorBindings.NewFrameInterpolatorWithDevice_Compiler, device.NativePtr, compiler.NativePtr);

        return new(nativePtr);
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

    public static readonly Selector IsDistortionTextureEnabled = "isDistortionTextureEnabled";

    public static readonly Selector MotionTextureFormat = "motionTextureFormat";

    public static readonly Selector NewFrameInterpolatorWithDevice = "newFrameInterpolatorWithDevice:";

    public static readonly Selector NewFrameInterpolatorWithDevice_Compiler = "newFrameInterpolatorWithDevice:compiler:";

    public static readonly Selector OutputHeight = "outputHeight";

    public static readonly Selector OutputTextureFormat = "outputTextureFormat";

    public static readonly Selector OutputWidth = "outputWidth";

    public static readonly Selector RequiresPrevColorTexture = "requiresPrevColorTexture";

    public static readonly Selector Scaler = "scaler";

    public static readonly Selector SetColorTextureFormat = "setColorTextureFormat:";

    public static readonly Selector SetDepthTextureFormat = "setDepthTextureFormat:";

    public static readonly Selector SetDistortionTextureEnabled = "setDistortionTextureEnabled:";

    public static readonly Selector SetInputHeight = "setInputHeight:";

    public static readonly Selector SetInputWidth = "setInputWidth:";

    public static readonly Selector SetMotionTextureFormat = "setMotionTextureFormat:";

    public static readonly Selector SetOutputHeight = "setOutputHeight:";

    public static readonly Selector SetOutputTextureFormat = "setOutputTextureFormat:";

    public static readonly Selector SetOutputWidth = "setOutputWidth:";

    public static readonly Selector SetRequiresPrevColorTexture = "setRequiresPrevColorTexture:";

    public static readonly Selector SetScaler = "setScaler:";

    public static readonly Selector SetUITextureFormat = "setUITextureFormat:";

    public static readonly Selector SupportsDevice = "supportsDevice:";

    public static readonly Selector SupportsMetal4FX = "supportsMetal4FX:";

    public static readonly Selector UiTextureFormat = "uiTextureFormat";
}
