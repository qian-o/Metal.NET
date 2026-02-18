namespace Metal.NET;

public class MTLSamplerDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLSamplerDescriptor");

    public MTLSamplerDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLSamplerDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLSamplerDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLSamplerBorderColor BorderColor
    {
        get => (MTLSamplerBorderColor)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLSamplerDescriptorSelector.BorderColor);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetBorderColor, (ulong)value);
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSamplerDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetLabel, value.NativePtr);
    }

    public Bool8 LodAverage
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLSamplerDescriptorSelector.LodAverage);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetLodAverage, value);
    }

    public float LodBias
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLSamplerDescriptorSelector.LodBias);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetLodBias, value);
    }

    public float LodMaxClamp
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLSamplerDescriptorSelector.LodMaxClamp);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetLodMaxClamp, value);
    }

    public float LodMinClamp
    {
        get => ObjectiveCRuntime.MsgSendFloat(NativePtr, MTLSamplerDescriptorSelector.LodMinClamp);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetLodMinClamp, value);
    }

    public MTLSamplerMinMagFilter MagFilter
    {
        get => (MTLSamplerMinMagFilter)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLSamplerDescriptorSelector.MagFilter);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetMagFilter, (ulong)value);
    }

    public nuint MaxAnisotropy
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLSamplerDescriptorSelector.MaxAnisotropy);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetMaxAnisotropy, value);
    }

    public MTLSamplerMinMagFilter MinFilter
    {
        get => (MTLSamplerMinMagFilter)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLSamplerDescriptorSelector.MinFilter);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetMinFilter, (ulong)value);
    }

    public MTLSamplerMipFilter MipFilter
    {
        get => (MTLSamplerMipFilter)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLSamplerDescriptorSelector.MipFilter);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetMipFilter, (ulong)value);
    }

    public Bool8 NormalizedCoordinates
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLSamplerDescriptorSelector.NormalizedCoordinates);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetNormalizedCoordinates, value);
    }

    public MTLSamplerAddressMode RAddressMode
    {
        get => (MTLSamplerAddressMode)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLSamplerDescriptorSelector.RAddressMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetRAddressMode, (ulong)value);
    }

    public MTLSamplerReductionMode ReductionMode
    {
        get => (MTLSamplerReductionMode)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLSamplerDescriptorSelector.ReductionMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetReductionMode, (ulong)value);
    }

    public MTLSamplerAddressMode SAddressMode
    {
        get => (MTLSamplerAddressMode)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLSamplerDescriptorSelector.SAddressMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetSAddressMode, (ulong)value);
    }

    public Bool8 SupportArgumentBuffers
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLSamplerDescriptorSelector.SupportArgumentBuffers);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetSupportArgumentBuffers, value);
    }

    public MTLSamplerAddressMode TAddressMode
    {
        get => (MTLSamplerAddressMode)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLSamplerDescriptorSelector.TAddressMode);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetTAddressMode, (ulong)value);
    }

    public static implicit operator nint(MTLSamplerDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLSamplerDescriptor(nint value)
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
}

file class MTLSamplerDescriptorSelector
{
    public static readonly Selector BorderColor = Selector.Register("borderColor");

    public static readonly Selector SetBorderColor = Selector.Register("setBorderColor:");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector LodAverage = Selector.Register("lodAverage");

    public static readonly Selector SetLodAverage = Selector.Register("setLodAverage:");

    public static readonly Selector LodBias = Selector.Register("lodBias");

    public static readonly Selector SetLodBias = Selector.Register("setLodBias:");

    public static readonly Selector LodMaxClamp = Selector.Register("lodMaxClamp");

    public static readonly Selector SetLodMaxClamp = Selector.Register("setLodMaxClamp:");

    public static readonly Selector LodMinClamp = Selector.Register("lodMinClamp");

    public static readonly Selector SetLodMinClamp = Selector.Register("setLodMinClamp:");

    public static readonly Selector MagFilter = Selector.Register("magFilter");

    public static readonly Selector SetMagFilter = Selector.Register("setMagFilter:");

    public static readonly Selector MaxAnisotropy = Selector.Register("maxAnisotropy");

    public static readonly Selector SetMaxAnisotropy = Selector.Register("setMaxAnisotropy:");

    public static readonly Selector MinFilter = Selector.Register("minFilter");

    public static readonly Selector SetMinFilter = Selector.Register("setMinFilter:");

    public static readonly Selector MipFilter = Selector.Register("mipFilter");

    public static readonly Selector SetMipFilter = Selector.Register("setMipFilter:");

    public static readonly Selector NormalizedCoordinates = Selector.Register("normalizedCoordinates");

    public static readonly Selector SetNormalizedCoordinates = Selector.Register("setNormalizedCoordinates:");

    public static readonly Selector RAddressMode = Selector.Register("rAddressMode");

    public static readonly Selector SetRAddressMode = Selector.Register("setRAddressMode:");

    public static readonly Selector ReductionMode = Selector.Register("reductionMode");

    public static readonly Selector SetReductionMode = Selector.Register("setReductionMode:");

    public static readonly Selector SAddressMode = Selector.Register("sAddressMode");

    public static readonly Selector SetSAddressMode = Selector.Register("setSAddressMode:");

    public static readonly Selector SupportArgumentBuffers = Selector.Register("supportArgumentBuffers");

    public static readonly Selector SetSupportArgumentBuffers = Selector.Register("setSupportArgumentBuffers:");

    public static readonly Selector TAddressMode = Selector.Register("tAddressMode");

    public static readonly Selector SetTAddressMode = Selector.Register("setTAddressMode:");
}
