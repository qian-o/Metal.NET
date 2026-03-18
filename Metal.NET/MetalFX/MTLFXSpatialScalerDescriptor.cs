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

    public MTLPixelFormat ColorTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXSpatialScalerDescriptorBindings.ColorTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetColorTextureFormat, (nuint)value);
    }

    public MTLPixelFormat OutputTextureFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLFXSpatialScalerDescriptorBindings.OutputTextureFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetOutputTextureFormat, (nuint)value);
    }

    public nuint InputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.InputWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetInputWidth, value);
    }

    public nuint InputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.InputHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetInputHeight, value);
    }

    public nuint OutputWidth
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.OutputWidth);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetOutputWidth, value);
    }

    public nuint OutputHeight
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.OutputHeight);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetOutputHeight, value);
    }

    public MTLFXSpatialScalerColorProcessingMode ColorProcessingMode
    {
        get => (MTLFXSpatialScalerColorProcessingMode)ObjectiveC.MsgSendLong(NativePtr, MTLFXSpatialScalerDescriptorBindings.ColorProcessingMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLFXSpatialScalerDescriptorBindings.SetColorProcessingMode, (nint)value);
    }

    public MTLFXSpatialScaler NewSpatialScaler(MTLDevice device)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.NewSpatialScalerWithDevice, device.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTL4FXSpatialScaler NewSpatialScaler(MTLDevice device, MTL4Compiler compiler)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLFXSpatialScalerDescriptorBindings.NewSpatialScalerWithDeviceCompiler, device.NativePtr, compiler.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public static bool SupportsMetal4FX(MTLDevice device)
    {
        return ObjectiveC.MsgSendBool(MTLFXSpatialScalerDescriptorBindings.Class, MTLFXSpatialScalerDescriptorBindings.SupportsMetal4FX, device.NativePtr);
    }

    public static bool SupportsDevice(MTLDevice device)
    {
        return ObjectiveC.MsgSendBool(MTLFXSpatialScalerDescriptorBindings.Class, MTLFXSpatialScalerDescriptorBindings.SupportsDevice, device.NativePtr);
    }
}

file static class MTLFXSpatialScalerDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLFXSpatialScalerDescriptor");

    public static readonly Selector ColorProcessingMode = "colorProcessingMode";

    public static readonly Selector ColorTextureFormat = "colorTextureFormat";

    public static readonly Selector InputHeight = "inputHeight";

    public static readonly Selector InputWidth = "inputWidth";

    public static readonly Selector NewSpatialScalerWithDevice = "newSpatialScalerWithDevice:";

    public static readonly Selector NewSpatialScalerWithDeviceCompiler = "newSpatialScalerWithDevice:compiler:";

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
