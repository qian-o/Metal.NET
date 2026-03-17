namespace Metal.NET;

public class MTLFXTemporalScalerDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFXTemporalScalerDescriptor>
{
    #region INativeObject
    public static new MTLFXTemporalScalerDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXTemporalScalerDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFXTemporalScalerDescriptor() : this(ObjectiveC.AllocInit(MTLFXTemporalScalerDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerDescriptorBindings.ColorTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetColorTextureFormat, (nuint)value);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerDescriptorBindings.DepthTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetDepthTextureFormat, (nuint)value);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerDescriptorBindings.MotionTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetMotionTextureFormat, (nuint)value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerDescriptorBindings.OutputTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetOutputTextureFormat, (nuint)value);
    }

    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.InputWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputWidth, value);
    }

    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.InputHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputHeight, value);
    }

    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.OutputWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetOutputWidth, value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.OutputHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetOutputHeight, value);
    }

    public Bool8 IsAutoExposureEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorBindings.IsAutoExposureEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetIsAutoExposureEnabled, value);
    }

    public Bool8 RequiresSynchronousInitialization
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorBindings.RequiresSynchronousInitialization);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetRequiresSynchronousInitialization, value);
    }

    public Bool8 IsInputContentPropertiesEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorBindings.IsInputContentPropertiesEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetIsInputContentPropertiesEnabled, value);
    }

    public float InputContentMinScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerDescriptorBindings.InputContentMinScale);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputContentMinScale, value);
    }

    public float InputContentMaxScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerDescriptorBindings.InputContentMaxScale);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputContentMaxScale, value);
    }

    public Bool8 IsReactiveMaskTextureEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorBindings.IsReactiveMaskTextureEnabled);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetIsReactiveMaskTextureEnabled, value);
    }

    public MTLPixelFormat ReactiveMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerDescriptorBindings.ReactiveMaskTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetReactiveMaskTextureFormat, (nuint)value);
    }

    public MTLFXTemporalScaler NewTemporalScalerWithDevice(MTLDevice device)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.NewTemporalScalerWithDevice, device.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLFXTemporalScaler NewTemporalScaler(MTLDevice device)
    {
        return NewTemporalScalerWithDevice(device);
    }

    public MTL4FXTemporalScaler NewTemporalScalerWithDeviceCompiler(MTLDevice device, MTL4Compiler compiler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.NewTemporalScalerWithDeviceCompiler, device.NativePtr, compiler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4FXTemporalScaler NewTemporalScaler(MTLDevice device, MTL4Compiler compiler)
    {
        return NewTemporalScalerWithDeviceCompiler(device, compiler);
    }

    public static float SupportedInputContentMinScaleForDevice(MTLDevice device)
    {
        return ObjectiveC.MsgSendFloat(MTLFXTemporalScalerDescriptorBindings.Class, MTLFXTemporalScalerDescriptorBindings.SupportedInputContentMinScaleForDevice, device.NativePtr);
    }

    public static float SupportedInputContentMaxScaleForDevice(MTLDevice device)
    {
        return ObjectiveC.MsgSendFloat(MTLFXTemporalScalerDescriptorBindings.Class, MTLFXTemporalScalerDescriptorBindings.SupportedInputContentMaxScaleForDevice, device.NativePtr);
    }

    public static bool SupportsDevice(MTLDevice device)
    {
        return ObjectiveC.MsgSendBool(MTLFXTemporalScalerDescriptorBindings.Class, MTLFXTemporalScalerDescriptorBindings.SupportsDevice, device.NativePtr);
    }

    public static bool SupportsMetal4FX(MTLDevice device)
    {
        return ObjectiveC.MsgSendBool(MTLFXTemporalScalerDescriptorBindings.Class, MTLFXTemporalScalerDescriptorBindings.SupportsMetal4FX, device.NativePtr);
    }
}

file static class MTLFXTemporalScalerDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFXTemporalScalerDescriptor");

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

    public static readonly Selector NewTemporalScalerWithDevice = "newTemporalScalerWithDevice:";

    public static readonly Selector NewTemporalScalerWithDeviceCompiler = "newTemporalScalerWithDevice:compiler:";

    public static readonly Selector OutputHeight = "outputHeight";

    public static readonly Selector OutputTextureFormat = "outputTextureFormat";

    public static readonly Selector OutputWidth = "outputWidth";

    public static readonly Selector ReactiveMaskTextureFormat = "reactiveMaskTextureFormat";

    public static readonly Selector RequiresSynchronousInitialization = "requiresSynchronousInitialization";

    public static readonly Selector SetColorTextureFormat = "setColorTextureFormat:";

    public static readonly Selector SetDepthTextureFormat = "setDepthTextureFormat:";

    public static readonly Selector SetInputContentMaxScale = "setInputContentMaxScale:";

    public static readonly Selector SetInputContentMinScale = "setInputContentMinScale:";

    public static readonly Selector SetInputHeight = "setInputHeight:";

    public static readonly Selector SetInputWidth = "setInputWidth:";

    public static readonly Selector SetIsAutoExposureEnabled = "setAutoExposureEnabled:";

    public static readonly Selector SetIsInputContentPropertiesEnabled = "setInputContentPropertiesEnabled:";

    public static readonly Selector SetIsReactiveMaskTextureEnabled = "setReactiveMaskTextureEnabled:";

    public static readonly Selector SetMotionTextureFormat = "setMotionTextureFormat:";

    public static readonly Selector SetOutputHeight = "setOutputHeight:";

    public static readonly Selector SetOutputTextureFormat = "setOutputTextureFormat:";

    public static readonly Selector SetOutputWidth = "setOutputWidth:";

    public static readonly Selector SetReactiveMaskTextureFormat = "setReactiveMaskTextureFormat:";

    public static readonly Selector SetRequiresSynchronousInitialization = "setRequiresSynchronousInitialization:";

    public static readonly Selector SupportedInputContentMaxScaleForDevice = "supportedInputContentMaxScaleForDevice:";

    public static readonly Selector SupportedInputContentMinScaleForDevice = "supportedInputContentMinScaleForDevice:";

    public static readonly Selector SupportsDevice = "supportsDevice:";

    public static readonly Selector SupportsMetal4FX = "supportsMetal4FX:";
}
