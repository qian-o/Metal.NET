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

    public float InputContentMaxScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerDescriptorBindings.InputContentMaxScale);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputContentMaxScale, value);
    }

    public float InputContentMinScale
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLFXTemporalScalerDescriptorBindings.InputContentMinScale);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputContentMinScale, value);
    }

    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.InputHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputHeight, value);
    }

    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.InputWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputWidth, value);
    }

    public Bool8 IsAutoExposureEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorBindings.IsAutoExposureEnabled);
    }

    public Bool8 IsInputContentPropertiesEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorBindings.IsInputContentPropertiesEnabled);
    }

    public Bool8 IsReactiveMaskTextureEnabled
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorBindings.IsReactiveMaskTextureEnabled);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerDescriptorBindings.MotionTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetMotionTextureFormat, (nuint)value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.OutputHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetOutputHeight, value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerDescriptorBindings.OutputTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetOutputTextureFormat, (nuint)value);
    }

    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.OutputWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetOutputWidth, value);
    }

    public MTLPixelFormat ReactiveMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXTemporalScalerDescriptorBindings.ReactiveMaskTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetReactiveMaskTextureFormat, (nuint)value);
    }

    public Bool8 RequiresSynchronousInitialization
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorBindings.RequiresSynchronousInitialization);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetRequiresSynchronousInitialization, value);
    }

    public void SetAutoExposureEnabled(bool enabled)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetAutoExposureEnabled, enabled);
    }

    public void SetInputContentPropertiesEnabled(bool enabled)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetInputContentPropertiesEnabled, enabled);
    }

    public void SetReactiveMaskTextureEnabled(bool enabled)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorBindings.SetReactiveMaskTextureEnabled, enabled);
    }

    public MTLFXTemporalScaler NewTemporalScaler(MTLDevice pDevice)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.NewTemporalScaler, pDevice.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4FXTemporalScaler NewTemporalScaler(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXTemporalScalerDescriptorBindings.NewTemporalScalerWithDevicecompiler, pDevice.NativePtr, pCompiler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static float SupportedInputContentMinScale(MTLDevice pDevice)
    {
        return ObjectiveC.MsgSendFloat(MTLFXTemporalScalerDescriptorBindings.Class, MTLFXTemporalScalerDescriptorBindings.SupportedInputContentMinScale, pDevice.NativePtr);
    }

    public static float SupportedInputContentMaxScale(MTLDevice pDevice)
    {
        return ObjectiveC.MsgSendFloat(MTLFXTemporalScalerDescriptorBindings.Class, MTLFXTemporalScalerDescriptorBindings.SupportedInputContentMaxScale, pDevice.NativePtr);
    }

    public static bool SupportsDevice(MTLDevice pDevice)
    {
        return ObjectiveC.MsgSendBool(MTLFXTemporalScalerDescriptorBindings.Class, MTLFXTemporalScalerDescriptorBindings.SupportsDevice, pDevice.NativePtr);
    }

    public static bool SupportsMetal4FX(MTLDevice pDevice)
    {
        return ObjectiveC.MsgSendBool(MTLFXTemporalScalerDescriptorBindings.Class, MTLFXTemporalScalerDescriptorBindings.SupportsMetal4FX, pDevice.NativePtr);
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
