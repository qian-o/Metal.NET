namespace Metal.NET;

public class MTLFXSpatialScalerDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLFXSpatialScalerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLFXSpatialScalerDescriptorBindings.Class))
    {
    }

    public MTLFXSpatialScalerColorProcessingMode ColorProcessingMode
    {
        get => (MTLFXSpatialScalerColorProcessingMode)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerDescriptorBindings.ColorProcessingMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetColorProcessingMode, (nint)value);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.ColorTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetColorTextureFormat, (nuint)value);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.InputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetInputHeight, value);
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.InputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetInputWidth, value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.OutputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetOutputHeight, value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.OutputTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetOutputTextureFormat, (nuint)value);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.OutputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetOutputWidth, value);
    }

    public MTLFXSpatialScaler? NewSpatialScaler(MTLDevice pDevice)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerDescriptorBindings.NewSpatialScaler, pDevice.NativePtr);
        return ptr is not 0 ? new MTLFXSpatialScaler(ptr) : null;
    }

    public MTL4FXSpatialScaler? NewSpatialScaler(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerDescriptorBindings.NewSpatialScaler, pDevice.NativePtr, pCompiler.NativePtr);
        return ptr is not 0 ? new MTL4FXSpatialScaler(ptr) : null;
    }

    public static bool SupportsDevice(MTLDevice pDevice)
    {
        return ObjectiveCRuntime.MsgSendBool(MTLFXSpatialScalerDescriptorBindings.Class, MTLFXSpatialScalerDescriptorBindings.SupportsDevice, pDevice.NativePtr);
    }

    public static bool SupportsMetal4FX(MTLDevice pDevice)
    {
        return ObjectiveCRuntime.MsgSendBool(MTLFXSpatialScalerDescriptorBindings.Class, MTLFXSpatialScalerDescriptorBindings.SupportsMetal4FX, pDevice.NativePtr);
    }
}

file static class MTLFXSpatialScalerDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFXSpatialScalerDescriptor");

    public static readonly Selector ColorProcessingMode = Selector.Register("colorProcessingMode");

    public static readonly Selector ColorTextureFormat = Selector.Register("colorTextureFormat");

    public static readonly Selector InputHeight = Selector.Register("inputHeight");

    public static readonly Selector InputWidth = Selector.Register("inputWidth");

    public static readonly Selector NewSpatialScaler = Selector.Register("newSpatialScalerWithDevice:");

    public static readonly Selector OutputHeight = Selector.Register("outputHeight");

    public static readonly Selector OutputTextureFormat = Selector.Register("outputTextureFormat");

    public static readonly Selector OutputWidth = Selector.Register("outputWidth");

    public static readonly Selector SetColorProcessingMode = Selector.Register("setColorProcessingMode:");

    public static readonly Selector SetColorTextureFormat = Selector.Register("setColorTextureFormat:");

    public static readonly Selector SetInputHeight = Selector.Register("setInputHeight:");

    public static readonly Selector SetInputWidth = Selector.Register("setInputWidth:");

    public static readonly Selector SetOutputHeight = Selector.Register("setOutputHeight:");

    public static readonly Selector SetOutputTextureFormat = Selector.Register("setOutputTextureFormat:");

    public static readonly Selector SetOutputWidth = Selector.Register("setOutputWidth:");

    public static readonly Selector SupportsDevice = Selector.Register("supportsDevice:");

    public static readonly Selector SupportsMetal4FX = Selector.Register("supportsMetal4FX:");
}
