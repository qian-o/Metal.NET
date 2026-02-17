namespace Metal.NET;

public class MTLSamplerDescriptor : IDisposable
{
    public MTLSamplerDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLSamplerDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLSamplerDescriptor");

    public static MTLSamplerDescriptor New()
    {
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLSamplerDescriptor(ptr);
    }

    public void SetBorderColor(MTLSamplerBorderColor borderColor)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetBorderColor, (nint)(uint)borderColor);
    }

    public void SetCompareFunction(MTLCompareFunction compareFunction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetCompareFunction, (nint)(uint)compareFunction);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetLabel, label.NativePtr);
    }

    public void SetLodAverage(Bool8 lodAverage)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetLodAverage, (nint)lodAverage.Value);
    }

    public void SetLodBias(float lodBias)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetLodBias, lodBias);
    }

    public void SetLodMaxClamp(float lodMaxClamp)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetLodMaxClamp, lodMaxClamp);
    }

    public void SetLodMinClamp(float lodMinClamp)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetLodMinClamp, lodMinClamp);
    }

    public void SetMagFilter(MTLSamplerMinMagFilter magFilter)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetMagFilter, (nint)(uint)magFilter);
    }

    public void SetMaxAnisotropy(uint maxAnisotropy)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetMaxAnisotropy, (nint)maxAnisotropy);
    }

    public void SetMinFilter(MTLSamplerMinMagFilter minFilter)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetMinFilter, (nint)(uint)minFilter);
    }

    public void SetMipFilter(MTLSamplerMipFilter mipFilter)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetMipFilter, (nint)(uint)mipFilter);
    }

    public void SetNormalizedCoordinates(Bool8 normalizedCoordinates)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetNormalizedCoordinates, (nint)normalizedCoordinates.Value);
    }

    public void SetRAddressMode(MTLSamplerAddressMode rAddressMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetRAddressMode, (nint)(uint)rAddressMode);
    }

    public void SetReductionMode(MTLSamplerReductionMode reductionMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetReductionMode, (nint)(uint)reductionMode);
    }

    public void SetSAddressMode(MTLSamplerAddressMode sAddressMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetSAddressMode, (nint)(uint)sAddressMode);
    }

    public void SetSupportArgumentBuffers(Bool8 supportArgumentBuffers)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetSupportArgumentBuffers, (nint)supportArgumentBuffers.Value);
    }

    public void SetTAddressMode(MTLSamplerAddressMode tAddressMode)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLSamplerDescriptorSelector.SetTAddressMode, (nint)(uint)tAddressMode);
    }

}

file class MTLSamplerDescriptorSelector
{
    public static readonly Selector SetBorderColor = Selector.Register("setBorderColor:");

    public static readonly Selector SetCompareFunction = Selector.Register("setCompareFunction:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetLodAverage = Selector.Register("setLodAverage:");

    public static readonly Selector SetLodBias = Selector.Register("setLodBias:");

    public static readonly Selector SetLodMaxClamp = Selector.Register("setLodMaxClamp:");

    public static readonly Selector SetLodMinClamp = Selector.Register("setLodMinClamp:");

    public static readonly Selector SetMagFilter = Selector.Register("setMagFilter:");

    public static readonly Selector SetMaxAnisotropy = Selector.Register("setMaxAnisotropy:");

    public static readonly Selector SetMinFilter = Selector.Register("setMinFilter:");

    public static readonly Selector SetMipFilter = Selector.Register("setMipFilter:");

    public static readonly Selector SetNormalizedCoordinates = Selector.Register("setNormalizedCoordinates:");

    public static readonly Selector SetRAddressMode = Selector.Register("setRAddressMode:");

    public static readonly Selector SetReductionMode = Selector.Register("setReductionMode:");

    public static readonly Selector SetSAddressMode = Selector.Register("setSAddressMode:");

    public static readonly Selector SetSupportArgumentBuffers = Selector.Register("setSupportArgumentBuffers:");

    public static readonly Selector SetTAddressMode = Selector.Register("setTAddressMode:");
}
