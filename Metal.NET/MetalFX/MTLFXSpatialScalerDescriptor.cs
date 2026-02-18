namespace Metal.NET;

public class MTLFXSpatialScalerDescriptor : IDisposable
{
    public MTLFXSpatialScalerDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLFXSpatialScalerDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFXSpatialScalerDescriptor");

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorSelector.ColorTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetColorTextureFormat, (nuint)value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorSelector.OutputTextureFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetOutputTextureFormat, (nuint)value);
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
        get => (MTLFXSpatialScalerColorProcessingMode)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorSelector.ColorProcessingMode));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetColorProcessingMode, (nuint)value);
    }

    public MTLFXSpatialScaler NewSpatialScaler(MTLDevice pDevice)
    {
        MTLFXSpatialScaler result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerDescriptorSelector.NewSpatialScaler, pDevice.NativePtr));

        return result;
    }

    public MTLFXSpatialScaler NewSpatialScaler(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        MTLFXSpatialScaler result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerDescriptorSelector.NewSpatialScalerPCompiler, pDevice.NativePtr, pCompiler.NativePtr));

        return result;
    }

    public static implicit operator nint(MTLFXSpatialScalerDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXSpatialScalerDescriptor(nint value)
    {
        return new(value);
    }

    public static Bool8 SupportsDevice(MTLDevice pDevice)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(Class, MTLFXSpatialScalerDescriptorSelector.SupportsDevice, pDevice.NativePtr);

        return result;
    }

    public static Bool8 SupportsMetal4FX(MTLDevice pDevice)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(Class, MTLFXSpatialScalerDescriptorSelector.SupportsMetal4FX, pDevice.NativePtr);

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

    public static readonly Selector NewSpatialScaler = Selector.Register("newSpatialScaler:");

    public static readonly Selector NewSpatialScalerPCompiler = Selector.Register("newSpatialScaler:pCompiler:");

    public static readonly Selector SupportsDevice = Selector.Register("supportsDevice:");

    public static readonly Selector SupportsMetal4FX = Selector.Register("supportsMetal4FX:");
}
