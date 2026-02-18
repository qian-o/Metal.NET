namespace Metal.NET;

public class MTLFXSpatialScalerDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLFXSpatialScalerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLFXSpatialScalerDescriptorSelector.Class))
    {
    }

    public MTLFXSpatialScalerColorProcessingMode ColorProcessingMode
    {
        get => (MTLFXSpatialScalerColorProcessingMode)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerDescriptorSelector.ColorProcessingMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetColorProcessingMode, (nint)value);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorSelector.ColorTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetColorTextureFormat, (nuint)value);
    }

    public nuint InputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorSelector.InputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetInputHeight, value);
    }

    public nuint InputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorSelector.InputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetInputWidth, value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorSelector.OutputHeight);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetOutputHeight, value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorSelector.OutputTextureFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetOutputTextureFormat, (nuint)value);
    }

    public nuint OutputWidth
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorSelector.OutputWidth);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorSelector.SetOutputWidth, value);
    }

    public MTLFXSpatialScaler? NewSpatialScaler(MTLDevice pDevice)
    {
        return GetNullableObject<MTLFXSpatialScaler>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerDescriptorSelector.NewSpatialScaler, pDevice.NativePtr));
    }

    public MTL4FXSpatialScaler? NewSpatialScaler(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        return GetNullableObject<MTL4FXSpatialScaler>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerDescriptorSelector.NewSpatialScaler, pDevice.NativePtr, pCompiler.NativePtr));
    }

    public static bool SupportsDevice(MTLDevice pDevice)
    {
        return ObjectiveCRuntime.MsgSendBool(MTLFXSpatialScalerDescriptorSelector.Class, MTLFXSpatialScalerDescriptorSelector.SupportsDevice, pDevice.NativePtr);
    }

    public static bool SupportsMetal4FX(MTLDevice pDevice)
    {
        return ObjectiveCRuntime.MsgSendBool(MTLFXSpatialScalerDescriptorSelector.Class, MTLFXSpatialScalerDescriptorSelector.SupportsMetal4FX, pDevice.NativePtr);
    }
}

file static class MTLFXSpatialScalerDescriptorSelector
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
