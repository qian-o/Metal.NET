namespace Metal.NET;

public class MTLFXSpatialScalerDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLFXSpatialScalerDescriptor>
{
    #region INativeObject
    public static new MTLFXSpatialScalerDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXSpatialScalerDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLFXSpatialScalerDescriptor() : this(ObjectiveC.AllocInit(MTLFXSpatialScalerDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLFXSpatialScalerColorProcessingMode ColorProcessingMode
    {
        get => (MTLFXSpatialScalerColorProcessingMode)ObjectiveC.MsgSendLong(NativePtr, MTLFXSpatialScalerDescriptorBindings.ColorProcessingMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetColorProcessingMode, (nint)value);
    }

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXSpatialScalerDescriptorBindings.ColorTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetColorTextureFormat, (nuint)value);
    }

    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.InputHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetInputHeight, value);
    }

    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.InputWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetInputWidth, value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.OutputHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetOutputHeight, value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXSpatialScalerDescriptorBindings.OutputTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetOutputTextureFormat, (nuint)value);
    }

    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.OutputWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetOutputWidth, value);
    }

    public MTLFXSpatialScaler NewSpatialScaler(MTLDevice pDevice)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.NewSpatialScaler, pDevice.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4FXSpatialScaler NewSpatialScaler(MTLDevice pDevice, MTL4Compiler pCompiler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.NewSpatialScalerWithDevicecompiler, pDevice.NativePtr, pCompiler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static bool SupportsDevice(MTLDevice pDevice)
    {
        return ObjectiveC.MsgSendBool(MTLFXSpatialScalerDescriptorBindings.Class, MTLFXSpatialScalerDescriptorBindings.SupportsDevice, pDevice.NativePtr);
    }

    public static bool SupportsMetal4FX(MTLDevice pDevice)
    {
        return ObjectiveC.MsgSendBool(MTLFXSpatialScalerDescriptorBindings.Class, MTLFXSpatialScalerDescriptorBindings.SupportsMetal4FX, pDevice.NativePtr);
    }
}

file static class MTLFXSpatialScalerDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFXSpatialScalerDescriptor");

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
