namespace Metal.NET;

public class MTLFXTemporalScalerDescriptor : IDisposable
{
    public MTLFXTemporalScalerDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLFXTemporalScalerDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFXTemporalScalerDescriptor");

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalScalerDescriptorSelector.ColorTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetColorTextureFormat, (uint)value);
    }

    public MTLPixelFormat DepthTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalScalerDescriptorSelector.DepthTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetDepthTextureFormat, (uint)value);
    }

    public MTLPixelFormat MotionTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalScalerDescriptorSelector.MotionTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetMotionTextureFormat, (uint)value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalScalerDescriptorSelector.OutputTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetOutputTextureFormat, (uint)value);
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

    public Bool8 IsAutoExposureEnabled => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorSelector.IsAutoExposureEnabled);

    public Bool8 IsInputContentPropertiesEnabled => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorSelector.IsInputContentPropertiesEnabled);

    public Bool8 RequiresSynchronousInitialization
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorSelector.RequiresSynchronousInitialization);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetRequiresSynchronousInitialization, value);
    }

    public Bool8 IsReactiveMaskTextureEnabled => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLFXTemporalScalerDescriptorSelector.IsReactiveMaskTextureEnabled);

    public MTLPixelFormat ReactiveMaskTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLFXTemporalScalerDescriptorSelector.ReactiveMaskTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetReactiveMaskTextureFormat, (uint)value);
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

    public void SetAutoExposureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetAutoExposureEnabled, enabled);
    }

    public void SetInputContentPropertiesEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetInputContentPropertiesEnabled, enabled);
    }

    public void SetReactiveMaskTextureEnabled(Bool8 enabled)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerDescriptorSelector.SetReactiveMaskTextureEnabled, enabled);
    }

    public MTLFXTemporalScaler NewTemporalScaler(MTLDevice pDevice)
    {
        MTLFXTemporalScaler result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerDescriptorSelector.NewTemporalScaler, pDevice.NativePtr));

        return result;
    }

    public MTLFXTemporalScaler NewTemporalScaler(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        MTLFXTemporalScaler result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXTemporalScalerDescriptorSelector.NewTemporalScalerPCompiler, pDevice.NativePtr, pCompiler.NativePtr));

        return result;
    }

    public static implicit operator nint(MTLFXTemporalScalerDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXTemporalScalerDescriptor(nint value)
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

    public static float SupportedInputContentMinScale(MTLDevice pDevice)
    {
        float result = ObjectiveCRuntime.MsgSendFloat(Class, MTLFXTemporalScalerDescriptorSelector.SupportedInputContentMinScale, pDevice.NativePtr);

        return result;
    }

    public static float SupportedInputContentMaxScale(MTLDevice pDevice)
    {
        float result = ObjectiveCRuntime.MsgSendFloat(Class, MTLFXTemporalScalerDescriptorSelector.SupportedInputContentMaxScale, pDevice.NativePtr);

        return result;
    }

    public static Bool8 SupportsDevice(MTLDevice pDevice)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(Class, MTLFXTemporalScalerDescriptorSelector.SupportsDevice, pDevice.NativePtr);

        return result;
    }

    public static Bool8 SupportsMetal4FX(MTLDevice pDevice)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(Class, MTLFXTemporalScalerDescriptorSelector.SupportsMetal4FX, pDevice.NativePtr);

        return result;
    }
}

file class MTLFXTemporalScalerDescriptorSelector
{
    public static readonly Selector ColorTextureFormat = Selector.Register("colorTextureFormat");

    public static readonly Selector SetColorTextureFormat = Selector.Register("setColorTextureFormat:");

    public static readonly Selector DepthTextureFormat = Selector.Register("depthTextureFormat");

    public static readonly Selector SetDepthTextureFormat = Selector.Register("setDepthTextureFormat:");

    public static readonly Selector MotionTextureFormat = Selector.Register("motionTextureFormat");

    public static readonly Selector SetMotionTextureFormat = Selector.Register("setMotionTextureFormat:");

    public static readonly Selector OutputTextureFormat = Selector.Register("outputTextureFormat");

    public static readonly Selector SetOutputTextureFormat = Selector.Register("setOutputTextureFormat:");

    public static readonly Selector InputWidth = Selector.Register("inputWidth");

    public static readonly Selector SetInputWidth = Selector.Register("setInputWidth:");

    public static readonly Selector InputHeight = Selector.Register("inputHeight");

    public static readonly Selector SetInputHeight = Selector.Register("setInputHeight:");

    public static readonly Selector OutputWidth = Selector.Register("outputWidth");

    public static readonly Selector SetOutputWidth = Selector.Register("setOutputWidth:");

    public static readonly Selector OutputHeight = Selector.Register("outputHeight");

    public static readonly Selector SetOutputHeight = Selector.Register("setOutputHeight:");

    public static readonly Selector IsAutoExposureEnabled = Selector.Register("isAutoExposureEnabled");

    public static readonly Selector IsInputContentPropertiesEnabled = Selector.Register("isInputContentPropertiesEnabled");

    public static readonly Selector RequiresSynchronousInitialization = Selector.Register("requiresSynchronousInitialization");

    public static readonly Selector SetRequiresSynchronousInitialization = Selector.Register("setRequiresSynchronousInitialization:");

    public static readonly Selector IsReactiveMaskTextureEnabled = Selector.Register("isReactiveMaskTextureEnabled");

    public static readonly Selector ReactiveMaskTextureFormat = Selector.Register("reactiveMaskTextureFormat");

    public static readonly Selector SetReactiveMaskTextureFormat = Selector.Register("setReactiveMaskTextureFormat:");

    public static readonly Selector InputContentMinScale = Selector.Register("inputContentMinScale");

    public static readonly Selector SetInputContentMinScale = Selector.Register("setInputContentMinScale:");

    public static readonly Selector InputContentMaxScale = Selector.Register("inputContentMaxScale");

    public static readonly Selector SetInputContentMaxScale = Selector.Register("setInputContentMaxScale:");

    public static readonly Selector SetAutoExposureEnabled = Selector.Register("setAutoExposureEnabled:");

    public static readonly Selector SetInputContentPropertiesEnabled = Selector.Register("setInputContentPropertiesEnabled:");

    public static readonly Selector SetReactiveMaskTextureEnabled = Selector.Register("setReactiveMaskTextureEnabled:");

    public static readonly Selector NewTemporalScaler = Selector.Register("newTemporalScaler:");

    public static readonly Selector NewTemporalScalerPCompiler = Selector.Register("newTemporalScaler:pCompiler:");

    public static readonly Selector SupportedInputContentMinScale = Selector.Register("supportedInputContentMinScale:");

    public static readonly Selector SupportedInputContentMaxScale = Selector.Register("supportedInputContentMaxScale:");

    public static readonly Selector SupportsDevice = Selector.Register("supportsDevice:");

    public static readonly Selector SupportsMetal4FX = Selector.Register("supportsMetal4FX:");
}
