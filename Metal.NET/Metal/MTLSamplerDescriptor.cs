namespace Metal.NET;

public class MTLSamplerDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLSamplerDescriptor>
{
    public static MTLSamplerDescriptor Create(nint nativePtr) => new(nativePtr, true);

    public static MTLSamplerDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLSamplerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLSamplerDescriptorBindings.Class), true)
    {
    }

    public MTLSamplerBorderColor BorderColor
    {
        get => (MTLSamplerBorderColor)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLSamplerDescriptorBindings.BorderColor);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetBorderColor, (nuint)value);
    }

    public MTLCompareFunction CompareFunction
    {
        get => (MTLCompareFunction)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLSamplerDescriptorBindings.CompareFunction);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetCompareFunction, (nuint)value);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLSamplerDescriptorBindings.Label);
        set => SetProperty(ref field, MTLSamplerDescriptorBindings.SetLabel, value);
    }

    public bool LodAverage
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLSamplerDescriptorBindings.LodAverage);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodAverage, (Bool8)value);
    }

    public float LodBias
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLSamplerDescriptorBindings.LodBias);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodBias, value);
    }

    public float LodMaxClamp
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLSamplerDescriptorBindings.LodMaxClamp);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodMaxClamp, value);
    }

    public float LodMinClamp
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLSamplerDescriptorBindings.LodMinClamp);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodMinClamp, value);
    }

    public MTLSamplerMinMagFilter MagFilter
    {
        get => (MTLSamplerMinMagFilter)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLSamplerDescriptorBindings.MagFilter);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMagFilter, (nuint)value);
    }

    public nuint MaxAnisotropy
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLSamplerDescriptorBindings.MaxAnisotropy);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMaxAnisotropy, value);
    }

    public MTLSamplerMinMagFilter MinFilter
    {
        get => (MTLSamplerMinMagFilter)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLSamplerDescriptorBindings.MinFilter);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMinFilter, (nuint)value);
    }

    public MTLSamplerMipFilter MipFilter
    {
        get => (MTLSamplerMipFilter)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLSamplerDescriptorBindings.MipFilter);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMipFilter, (nuint)value);
    }

    public bool NormalizedCoordinates
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLSamplerDescriptorBindings.NormalizedCoordinates);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetNormalizedCoordinates, (Bool8)value);
    }

    public MTLSamplerAddressMode RAddressMode
    {
        get => (MTLSamplerAddressMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLSamplerDescriptorBindings.RAddressMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetRAddressMode, (nuint)value);
    }

    public MTLSamplerReductionMode ReductionMode
    {
        get => (MTLSamplerReductionMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLSamplerDescriptorBindings.ReductionMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetReductionMode, (nuint)value);
    }

    public MTLSamplerAddressMode SAddressMode
    {
        get => (MTLSamplerAddressMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLSamplerDescriptorBindings.SAddressMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetSAddressMode, (nuint)value);
    }

    public bool SupportArgumentBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLSamplerDescriptorBindings.SupportArgumentBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetSupportArgumentBuffers, (Bool8)value);
    }

    public MTLSamplerAddressMode TAddressMode
    {
        get => (MTLSamplerAddressMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLSamplerDescriptorBindings.TAddressMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetTAddressMode, (nuint)value);
    }
}

file static class MTLSamplerDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLSamplerDescriptor");

    public static readonly Selector BorderColor = "borderColor";

    public static readonly Selector CompareFunction = "compareFunction";

    public static readonly Selector Label = "label";

    public static readonly Selector LodAverage = "lodAverage";

    public static readonly Selector LodBias = "lodBias";

    public static readonly Selector LodMaxClamp = "lodMaxClamp";

    public static readonly Selector LodMinClamp = "lodMinClamp";

    public static readonly Selector MagFilter = "magFilter";

    public static readonly Selector MaxAnisotropy = "maxAnisotropy";

    public static readonly Selector MinFilter = "minFilter";

    public static readonly Selector MipFilter = "mipFilter";

    public static readonly Selector NormalizedCoordinates = "normalizedCoordinates";

    public static readonly Selector RAddressMode = "rAddressMode";

    public static readonly Selector ReductionMode = "reductionMode";

    public static readonly Selector SAddressMode = "sAddressMode";

    public static readonly Selector SetBorderColor = "setBorderColor:";

    public static readonly Selector SetCompareFunction = "setCompareFunction:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetLodAverage = "setLodAverage:";

    public static readonly Selector SetLodBias = "setLodBias:";

    public static readonly Selector SetLodMaxClamp = "setLodMaxClamp:";

    public static readonly Selector SetLodMinClamp = "setLodMinClamp:";

    public static readonly Selector SetMagFilter = "setMagFilter:";

    public static readonly Selector SetMaxAnisotropy = "setMaxAnisotropy:";

    public static readonly Selector SetMinFilter = "setMinFilter:";

    public static readonly Selector SetMipFilter = "setMipFilter:";

    public static readonly Selector SetNormalizedCoordinates = "setNormalizedCoordinates:";

    public static readonly Selector SetRAddressMode = "setRAddressMode:";

    public static readonly Selector SetReductionMode = "setReductionMode:";

    public static readonly Selector SetSAddressMode = "setSAddressMode:";

    public static readonly Selector SetSupportArgumentBuffers = "setSupportArgumentBuffers:";

    public static readonly Selector SetTAddressMode = "setTAddressMode:";

    public static readonly Selector SupportArgumentBuffers = "supportArgumentBuffers";

    public static readonly Selector TAddressMode = "tAddressMode";
}
