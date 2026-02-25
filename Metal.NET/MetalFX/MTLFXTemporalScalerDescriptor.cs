namespace Metal.NET;

public class MTLFXTemporalScalerDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFXTemporalScalerDescriptor>
{
    public static MTLFXTemporalScalerDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static MTLFXTemporalScalerDescriptor Null => Create(0, false);
    public static MTLFXTemporalScalerDescriptor Empty => Null;

    public MTLFXTemporalScalerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLFXTemporalScalerDescriptorBindings.Class), true)
    {
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.ColorTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetColorTextureFormat, (nuint)value);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.DepthTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetDepthTextureFormat, (nuint)value);
    }

    public float InputContentMaxScale
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerDescriptorBindings.InputContentMaxScale);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputContentMaxScale, value);
    }

    public float InputContentMinScale
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerDescriptorBindings.InputContentMinScale);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputContentMinScale, value);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.InputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputHeight, value);
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.InputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputWidth, value);
    }

    public Bool8 IsAutoExposureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorBindings.IsAutoExposureEnabled);
    }

    public Bool8 IsInputContentPropertiesEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorBindings.IsInputContentPropertiesEnabled);
    }

    public Bool8 IsReactiveMaskTextureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorBindings.IsReactiveMaskTextureEnabled);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.MotionTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetMotionTextureFormat, (nuint)value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.OutputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetOutputHeight, value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.OutputTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetOutputTextureFormat, (nuint)value);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.OutputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetOutputWidth, value);
    }

    public MTLPixelFormat ReactiveMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.ReactiveMaskTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetReactiveMaskTextureFormat, (nuint)value);
    }

    public Bool8 RequiresSynchronousInitialization
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorBindings.RequiresSynchronousInitialization);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetRequiresSynchronousInitialization, value);
    }

    public void SetAutoExposureEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetAutoExposureEnabled, (Bool8)enabled);
    }

    public void SetInputContentPropertiesEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputContentPropertiesEnabled, (Bool8)enabled);
    }

    public void SetReactiveMaskTextureEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetReactiveMaskTextureEnabled, (Bool8)enabled);
    }

    public MTLFXTemporalScaler NewTemporalScaler(MTLDevice pDevice)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerDescriptorBindings.NewTemporalScaler, pDevice.NativePtr);

        return new(nativePtr, true);
    }

    public MTL4FXTemporalScaler NewTemporalScaler(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerDescriptorBindings.NewTemporalScalerWithDevicecompiler, pDevice.NativePtr, pCompiler.NativePtr);

        return new(nativePtr, true);
    }

    public static float SupportedInputContentMinScale(MTLDevice pDevice)
    {
        return ObjectiveCRuntime.MsgSendFloat(MTLFXTemporalScalerDescriptorBindings.Class, MTLFXTemporalScalerDescriptorBindings.SupportedInputContentMinScale, pDevice.NativePtr);
    }

    public static float SupportedInputContentMaxScale(MTLDevice pDevice)
    {
        return ObjectiveCRuntime.MsgSendFloat(MTLFXTemporalScalerDescriptorBindings.Class, MTLFXTemporalScalerDescriptorBindings.SupportedInputContentMaxScale, pDevice.NativePtr);
    }

    public static bool SupportsDevice(MTLDevice pDevice)
    {
        return ObjectiveCRuntime.MsgSendBool(MTLFXTemporalScalerDescriptorBindings.Class, MTLFXTemporalScalerDescriptorBindings.SupportsDevice, pDevice.NativePtr);
    }

    public static bool SupportsMetal4FX(MTLDevice pDevice)
    {
        return ObjectiveCRuntime.MsgSendBool(MTLFXTemporalScalerDescriptorBindings.Class, MTLFXTemporalScalerDescriptorBindings.SupportsMetal4FX, pDevice.NativePtr);
    }
}

file static class MTLFXTemporalScalerDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFXTemporalScalerDescriptor");

    public static readonly Selector ColorTextureFormat = "colorTextureFormat";

    public static readonly Selector DepthTextureFormat = "depthTextureFormat";

    public static readonly Selector InputContentMaxScale = "inputContentMaxScale";

    public static readonly Selector InputContentMinScale = "inputContentMinScale";

    public static readonly Selector InputHeight = "inputHeight";

    public static readonly Selector InputWidth = "inputWidth";

    public static readonly Selector IsAutoExposureEnabled = "isAutoExposureEnabled";

    public static readonly Selector IsInputContentPropertiesEnabled = "isInputContentPropertiesEnabled";

    public static readonly Selector IsReactiveMaskTextureEnabled = "isReactiveMaskTextureEnabled";

    public static readonly Selector MotionTextureFormat = "motionTextureFormat";

    public static readonly Selector NewTemporalScaler = "newTemporalScalerWithDevice:";

    public static readonly Selector NewTemporalScalerWithDevicecompiler = "newTemporalScalerWithDevice:compiler:";

    public static readonly Selector OutputHeight = "outputHeight";

    public static readonly Selector OutputTextureFormat = "outputTextureFormat";

    public static readonly Selector OutputWidth = "outputWidth";

    public static readonly Selector ReactiveMaskTextureFormat = "reactiveMaskTextureFormat";

    public static readonly Selector RequiresSynchronousInitialization = "requiresSynchronousInitialization";

    public static readonly Selector SetAutoExposureEnabled = "setAutoExposureEnabled:";

    public static readonly Selector SetColorTextureFormat = "setColorTextureFormat:";

    public static readonly Selector SetDepthTextureFormat = "setDepthTextureFormat:";

    public static readonly Selector SetInputContentMaxScale = "setInputContentMaxScale:";

    public static readonly Selector SetInputContentMinScale = "setInputContentMinScale:";

    public static readonly Selector SetInputContentPropertiesEnabled = "setInputContentPropertiesEnabled:";

    public static readonly Selector SetInputHeight = "setInputHeight:";

    public static readonly Selector SetInputWidth = "setInputWidth:";

    public static readonly Selector SetMotionTextureFormat = "setMotionTextureFormat:";

    public static readonly Selector SetOutputHeight = "setOutputHeight:";

    public static readonly Selector SetOutputTextureFormat = "setOutputTextureFormat:";

    public static readonly Selector SetOutputWidth = "setOutputWidth:";

    public static readonly Selector SetReactiveMaskTextureEnabled = "setReactiveMaskTextureEnabled:";

    public static readonly Selector SetReactiveMaskTextureFormat = "setReactiveMaskTextureFormat:";

    public static readonly Selector SetRequiresSynchronousInitialization = "setRequiresSynchronousInitialization:";

    public static readonly Selector SupportedInputContentMaxScale = "supportedInputContentMaxScaleForDevice:";

    public static readonly Selector SupportedInputContentMinScale = "supportedInputContentMinScaleForDevice:";

    public static readonly Selector SupportsDevice = "supportsDevice:";

    public static readonly Selector SupportsMetal4FX = "supportsMetal4FX:";
}
