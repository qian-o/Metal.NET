namespace Metal.NET;

public partial class MTLFXTemporalScalerDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFXTemporalScalerDescriptor");

    public MTLFXTemporalScalerDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorSelector.ColorTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetColorTextureFormat, (nuint)value);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorSelector.DepthTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetDepthTextureFormat, (nuint)value);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorSelector.MotionTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetMotionTextureFormat, (nuint)value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorSelector.OutputTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetOutputTextureFormat, (nuint)value);
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorSelector.InputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetInputWidth, value);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorSelector.InputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetInputHeight, value);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorSelector.OutputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetOutputWidth, value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorSelector.OutputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetOutputHeight, value);
    }

    public bool IsAutoExposureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorSelector.IsAutoExposureEnabled);
    }

    public bool IsInputContentPropertiesEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorSelector.IsInputContentPropertiesEnabled);
    }

    public bool RequiresSynchronousInitialization
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorSelector.RequiresSynchronousInitialization);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetRequiresSynchronousInitialization, (Bool8)value);
    }

    public bool IsReactiveMaskTextureEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorSelector.IsReactiveMaskTextureEnabled);
    }

    public MTLPixelFormat ReactiveMaskTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXTemporalScalerDescriptorSelector.ReactiveMaskTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetReactiveMaskTextureFormat, (nuint)value);
    }

    public float InputContentMinScale
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerDescriptorSelector.InputContentMinScale);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetInputContentMinScale, value);
    }

    public float InputContentMaxScale
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLFXTemporalScalerDescriptorSelector.InputContentMaxScale);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetInputContentMaxScale, value);
    }

    public void SetAutoExposureEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetAutoExposureEnabled, (Bool8)enabled);
    }

    public void SetInputContentPropertiesEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetInputContentPropertiesEnabled, (Bool8)enabled);
    }

    public void SetReactiveMaskTextureEnabled(bool enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetReactiveMaskTextureEnabled, (Bool8)enabled);
    }

    public MTLFXTemporalScaler? NewTemporalScaler(MTLDevice pDevice)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerDescriptorSelector.NewTemporalScaler, pDevice.NativePtr);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTL4FXTemporalScaler? NewTemporalScaler(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerDescriptorSelector.NewTemporalScaler, pDevice.NativePtr, pCompiler.NativePtr);
        return ptr is not 0 ? new(ptr) : null;
    }

    public static float SupportedInputContentMinScale(MTLDevice pDevice)
    {
        return ObjectiveCRuntime.MsgSendFloat(Class, MTLFXTemporalScalerDescriptorSelector.MTLFXTemporalScalerDescriptor, pDevice.NativePtr);
    }

    public static float SupportedInputContentMaxScale(MTLDevice pDevice)
    {
        return ObjectiveCRuntime.MsgSendFloat(Class, MTLFXTemporalScalerDescriptorSelector.MTLFXTemporalScalerDescriptor, pDevice.NativePtr);
    }

    public static bool SupportsDevice(MTLDevice pDevice)
    {
        return ObjectiveCRuntime.MsgSendBool(Class, MTLFXTemporalScalerDescriptorSelector.SupportsDevice, pDevice.NativePtr);
    }

    public static bool SupportsMetal4FX(MTLDevice pDevice)
    {
        return ObjectiveCRuntime.MsgSendBool(Class, MTLFXTemporalScalerDescriptorSelector.SupportsMetal4FX, pDevice.NativePtr);
    }
}

file static class MTLFXTemporalScalerDescriptorSelector
{
    public static readonly Selector ColorTextureFormat = Selector.Register("colorTextureFormat");

    public static readonly Selector DepthTextureFormat = Selector.Register("depthTextureFormat");

    public static readonly Selector InputContentMaxScale = Selector.Register("inputContentMaxScale");

    public static readonly Selector InputContentMinScale = Selector.Register("inputContentMinScale");

    public static readonly Selector InputHeight = Selector.Register("inputHeight");

    public static readonly Selector InputWidth = Selector.Register("inputWidth");

    public static readonly Selector IsAutoExposureEnabled = Selector.Register("isAutoExposureEnabled");

    public static readonly Selector IsInputContentPropertiesEnabled = Selector.Register("isInputContentPropertiesEnabled");

    public static readonly Selector IsReactiveMaskTextureEnabled = Selector.Register("isReactiveMaskTextureEnabled");

    public static readonly Selector MotionTextureFormat = Selector.Register("motionTextureFormat");

    public static readonly Selector MTLFXTemporalScalerDescriptor = Selector.Register("MTLFXTemporalScalerDescriptor");

    public static readonly Selector NewTemporalScaler = Selector.Register("newTemporalScaler:");

    public static readonly Selector OutputHeight = Selector.Register("outputHeight");

    public static readonly Selector OutputTextureFormat = Selector.Register("outputTextureFormat");

    public static readonly Selector OutputWidth = Selector.Register("outputWidth");

    public static readonly Selector ReactiveMaskTextureFormat = Selector.Register("reactiveMaskTextureFormat");

    public static readonly Selector RequiresSynchronousInitialization = Selector.Register("requiresSynchronousInitialization");

    public static readonly Selector SetAutoExposureEnabled = Selector.Register("setAutoExposureEnabled:");

    public static readonly Selector SetColorTextureFormat = Selector.Register("setColorTextureFormat:");

    public static readonly Selector SetDepthTextureFormat = Selector.Register("setDepthTextureFormat:");

    public static readonly Selector SetInputContentMaxScale = Selector.Register("setInputContentMaxScale:");

    public static readonly Selector SetInputContentMinScale = Selector.Register("setInputContentMinScale:");

    public static readonly Selector SetInputContentPropertiesEnabled = Selector.Register("setInputContentPropertiesEnabled:");

    public static readonly Selector SetInputHeight = Selector.Register("setInputHeight:");

    public static readonly Selector SetInputWidth = Selector.Register("setInputWidth:");

    public static readonly Selector SetMotionTextureFormat = Selector.Register("setMotionTextureFormat:");

    public static readonly Selector SetOutputHeight = Selector.Register("setOutputHeight:");

    public static readonly Selector SetOutputTextureFormat = Selector.Register("setOutputTextureFormat:");

    public static readonly Selector SetOutputWidth = Selector.Register("setOutputWidth:");

    public static readonly Selector SetReactiveMaskTextureEnabled = Selector.Register("setReactiveMaskTextureEnabled:");

    public static readonly Selector SetReactiveMaskTextureFormat = Selector.Register("setReactiveMaskTextureFormat:");

    public static readonly Selector SetRequiresSynchronousInitialization = Selector.Register("setRequiresSynchronousInitialization:");

    public static readonly Selector SupportsDevice = Selector.Register("supportsDevice:");

    public static readonly Selector SupportsMetal4FX = Selector.Register("supportsMetal4FX:");
}
