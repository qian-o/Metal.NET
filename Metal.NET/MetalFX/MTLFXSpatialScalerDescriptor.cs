namespace Metal.NET;

public class MTLFXSpatialScalerDescriptor(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public MTLFXSpatialScalerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLFXSpatialScalerDescriptorBindings.Class), false)
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
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerDescriptorBindings.NewSpatialScaler, pDevice.NativePtr);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public MTL4FXSpatialScaler? NewSpatialScaler(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFXSpatialScalerDescriptorBindings.NewSpatialScalerWithDevicecompiler, pDevice.NativePtr, pCompiler.NativePtr);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
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

    public static readonly Selector ColorProcessingMode = "colorProcessingMode";

    public static readonly Selector ColorTextureFormat = "colorTextureFormat";

    public static readonly Selector InputHeight = "inputHeight";

    public static readonly Selector InputWidth = "inputWidth";

    public static readonly Selector NewSpatialScaler = "newSpatialScalerWithDevice:";

    public static readonly Selector NewSpatialScalerWithDevicecompiler = "newSpatialScalerWithDevice:compiler:";

    public static readonly Selector OutputHeight = "outputHeight";

    public static readonly Selector OutputTextureFormat = "outputTextureFormat";

    public static readonly Selector OutputWidth = "outputWidth";

    public static readonly Selector SetColorProcessingMode = "setColorProcessingMode:";

    public static readonly Selector SetColorTextureFormat = "setColorTextureFormat:";

    public static readonly Selector SetInputHeight = "setInputHeight:";

    public static readonly Selector SetInputWidth = "setInputWidth:";

    public static readonly Selector SetOutputHeight = "setOutputHeight:";

    public static readonly Selector SetOutputTextureFormat = "setOutputTextureFormat:";

    public static readonly Selector SetOutputWidth = "setOutputWidth:";

    public static readonly Selector SupportsDevice = "supportsDevice:";

    public static readonly Selector SupportsMetal4FX = "supportsMetal4FX:";
}
