namespace Metal.NET;

public class MTLFXSpatialScalerDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFXSpatialScalerDescriptor");

    public MTLFXSpatialScalerDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLFXSpatialScalerDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLFXSpatialScalerDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXSpatialScalerDescriptorSelector.ColorTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetColorTextureFormat, (ulong)value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXSpatialScalerDescriptorSelector.OutputTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetOutputTextureFormat, (ulong)value);
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorSelector.InputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetInputWidth, value);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorSelector.InputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetInputHeight, value);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorSelector.OutputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetOutputWidth, value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorSelector.OutputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetOutputHeight, value);
    }

    public MTLFXSpatialScalerColorProcessingMode ColorProcessingMode
    {
        get => (MTLFXSpatialScalerColorProcessingMode)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLFXSpatialScalerDescriptorSelector.ColorProcessingMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetColorProcessingMode, (ulong)value);
    }

    public static implicit operator nint(MTLFXSpatialScalerDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXSpatialScalerDescriptor(nint value)
    {
        return new(value);
    }

    public MTLFXSpatialScaler NewSpatialScaler(MTLDevice device)
    {
        MTLFXSpatialScaler result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerDescriptorSelector.NewSpatialScalerWithDevice, device.NativePtr));

        return result;
    }

    public MTL4FXSpatialScaler NewSpatialScaler(MTLDevice device, MTL4Compiler compiler)
    {
        MTL4FXSpatialScaler result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerDescriptorSelector.NewSpatialScalerWithDeviceCompiler, device.NativePtr, compiler.NativePtr));

        return result;
    }

    public static Bool8 SupportsDevice(MTLDevice device)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(Class, MTLFXSpatialScalerDescriptorSelector.SupportsDevice, device.NativePtr);

        return result;
    }

    public static Bool8 SupportsMetal4FX(MTLDevice device)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(Class, MTLFXSpatialScalerDescriptorSelector.SupportsMetal4FX, device.NativePtr);

        return result;
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
}

file class MTLFXSpatialScalerDescriptorSelector
{
    public static readonly Selector ColorTextureFormat = Selector.Register("colorTextureFormat");

    public static readonly Selector SetColorTextureFormat = Selector.Register("setColorTextureFormat:");

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

    public static readonly Selector ColorProcessingMode = Selector.Register("colorProcessingMode");

    public static readonly Selector SetColorProcessingMode = Selector.Register("setColorProcessingMode:");

    public static readonly Selector NewSpatialScalerWithDevice = Selector.Register("newSpatialScalerWithDevice:");

    public static readonly Selector NewSpatialScalerWithDeviceCompiler = Selector.Register("newSpatialScalerWithDevice:compiler:");

    public static readonly Selector SupportsDevice = Selector.Register("supportsDevice:");

    public static readonly Selector SupportsMetal4FX = Selector.Register("supportsMetal4FX:");
}
