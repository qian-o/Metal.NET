namespace Metal.NET;

public class MTLSamplerDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLSamplerDescriptor>
{
    #region INativeObject
    public static new MTLSamplerDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLSamplerDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLSamplerDescriptor() : this(ObjectiveC.AllocInit(MTLSamplerDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLSamplerMinMagFilter MinFilter
    {
        get => (MTLSamplerMinMagFilter)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.MinFilter);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMinFilter, (nuint)value);
    }

    public MTLSamplerMinMagFilter MagFilter
    {
        get => (MTLSamplerMinMagFilter)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.MagFilter);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMagFilter, (nuint)value);
    }

    public MTLSamplerMipFilter MipFilter
    {
        get => (MTLSamplerMipFilter)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.MipFilter);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMipFilter, (nuint)value);
    }

    public nuint MaxAnisotropy
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLSamplerDescriptorBindings.MaxAnisotropy);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMaxAnisotropy, value);
    }

    public MTLSamplerAddressMode SAddressMode
    {
        get => (MTLSamplerAddressMode)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.SAddressMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetSAddressMode, (nuint)value);
    }

    public MTLSamplerAddressMode TAddressMode
    {
        get => (MTLSamplerAddressMode)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.TAddressMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetTAddressMode, (nuint)value);
    }

    public MTLSamplerAddressMode RAddressMode
    {
        get => (MTLSamplerAddressMode)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.RAddressMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetRAddressMode, (nuint)value);
    }

    public MTLSamplerBorderColor BorderColor
    {
        get => (MTLSamplerBorderColor)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.BorderColor);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetBorderColor, (nuint)value);
    }

    public MTLSamplerReductionMode ReductionMode
    {
        get => (MTLSamplerReductionMode)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.ReductionMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetReductionMode, (nuint)value);
    }

    public Bool8 NormalizedCoordinates
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLSamplerDescriptorBindings.NormalizedCoordinates);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetNormalizedCoordinates, value);
    }

    public float LodMinClamp
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLSamplerDescriptorBindings.LodMinClamp);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodMinClamp, value);
    }

    public float LodMaxClamp
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLSamplerDescriptorBindings.LodMaxClamp);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodMaxClamp, value);
    }

    public Bool8 LodAverage
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLSamplerDescriptorBindings.LodAverage);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodAverage, value);
    }

    public float LodBias
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLSamplerDescriptorBindings.LodBias);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodBias, value);
    }

    public MTLCompareFunction CompareFunction
    {
        get => (MTLCompareFunction)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.CompareFunction);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetCompareFunction, (nuint)value);
    }

    public Bool8 SupportArgumentBuffers
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLSamplerDescriptorBindings.SupportArgumentBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetSupportArgumentBuffers, value);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLSamplerDescriptorBindings.Label);
        set => SetProperty(ref field, MTLSamplerDescriptorBindings.SetLabel, value);
    }

    public MTLSamplerMinMagFilter MinFilter
    {
        get => (MTLSamplerMinMagFilter)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.MinFilter);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMinFilter, (nuint)value);
    }

    public MTLSamplerMinMagFilter MagFilter
    {
        get => (MTLSamplerMinMagFilter)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.MagFilter);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMagFilter, (nuint)value);
    }

    public MTLSamplerMipFilter MipFilter
    {
        get => (MTLSamplerMipFilter)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.MipFilter);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMipFilter, (nuint)value);
    }

    public nuint MaxAnisotropy
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLSamplerDescriptorBindings.MaxAnisotropy);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMaxAnisotropy, value);
    }

    public MTLSamplerAddressMode SAddressMode
    {
        get => (MTLSamplerAddressMode)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.SAddressMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetSAddressMode, (nuint)value);
    }

    public MTLSamplerAddressMode TAddressMode
    {
        get => (MTLSamplerAddressMode)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.TAddressMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetTAddressMode, (nuint)value);
    }

    public MTLSamplerAddressMode RAddressMode
    {
        get => (MTLSamplerAddressMode)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.RAddressMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetRAddressMode, (nuint)value);
    }

    public MTLSamplerBorderColor BorderColor
    {
        get => (MTLSamplerBorderColor)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.BorderColor);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetBorderColor, (nuint)value);
    }

    public MTLSamplerReductionMode ReductionMode
    {
        get => (MTLSamplerReductionMode)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.ReductionMode);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetReductionMode, (nuint)value);
    }

    public Bool8 NormalizedCoordinates
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLSamplerDescriptorBindings.NormalizedCoordinates);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetNormalizedCoordinates, value);
    }

    public float LodMinClamp
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLSamplerDescriptorBindings.LodMinClamp);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodMinClamp, value);
    }

    public float LodMaxClamp
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLSamplerDescriptorBindings.LodMaxClamp);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodMaxClamp, value);
    }

    public Bool8 LodAverage
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLSamplerDescriptorBindings.LodAverage);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodAverage, value);
    }

    public float LodBias
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLSamplerDescriptorBindings.LodBias);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodBias, value);
    }

    public MTLCompareFunction CompareFunction
    {
        get => (MTLCompareFunction)ObjectiveC.MsgSendULong(NativePtr, MTLSamplerDescriptorBindings.CompareFunction);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetCompareFunction, (nuint)value);
    }

    public Bool8 SupportArgumentBuffers
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLSamplerDescriptorBindings.SupportArgumentBuffers);
        set => ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetSupportArgumentBuffers, value);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLSamplerDescriptorBindings.Label);
        set => SetProperty(ref field, MTLSamplerDescriptorBindings.SetLabel, value);
    }

    public void SetMinFilter(MTLSamplerMinMagFilter minFilter)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMinFilter, (nuint)minFilter);
    }

    public void SetMagFilter(MTLSamplerMinMagFilter magFilter)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMagFilter, (nuint)magFilter);
    }

    public void SetMipFilter(MTLSamplerMipFilter mipFilter)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMipFilter, (nuint)mipFilter);
    }

    public void SetMaxAnisotropy(nuint maxAnisotropy)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetMaxAnisotropy, maxAnisotropy);
    }

    public void SetSAddressMode(MTLSamplerAddressMode sAddressMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetSAddressMode, (nuint)sAddressMode);
    }

    public void SetTAddressMode(MTLSamplerAddressMode tAddressMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetTAddressMode, (nuint)tAddressMode);
    }

    public void SetRAddressMode(MTLSamplerAddressMode rAddressMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetRAddressMode, (nuint)rAddressMode);
    }

    public void SetBorderColor(MTLSamplerBorderColor borderColor)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetBorderColor, (nuint)borderColor);
    }

    public void SetReductionMode(MTLSamplerReductionMode reductionMode)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetReductionMode, (nuint)reductionMode);
    }

    public void SetNormalizedCoordinates(bool normalizedCoordinates)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetNormalizedCoordinates, normalizedCoordinates);
    }

    public void SetLodMinClamp(float lodMinClamp)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodMinClamp, lodMinClamp);
    }

    public void SetLodMaxClamp(float lodMaxClamp)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodMaxClamp, lodMaxClamp);
    }

    public void SetLodAverage(bool lodAverage)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodAverage, lodAverage);
    }

    public void SetLodBias(float lodBias)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLodBias, lodBias);
    }

    public void SetCompareFunction(MTLCompareFunction compareFunction)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetCompareFunction, (nuint)compareFunction);
    }

    public void SetSupportArgumentBuffers(bool supportArgumentBuffers)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetSupportArgumentBuffers, supportArgumentBuffers);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveC.MsgSend(NativePtr, MTLSamplerDescriptorBindings.SetLabel, label.NativePtr);
    }
}

file static class MTLSamplerDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLSamplerDescriptor");

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
