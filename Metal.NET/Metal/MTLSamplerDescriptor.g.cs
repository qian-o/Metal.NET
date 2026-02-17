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
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLSamplerDescriptor(ptr);
    }

    public void SetBorderColor(MTLSamplerBorderColor borderColor)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetBorderColor, (nint)(uint)borderColor);
    }

    public void SetCompareFunction(MTLCompareFunction compareFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetCompareFunction, (nint)(uint)compareFunction);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetLabel, label.NativePtr);
    }

    public void SetLodAverage(Bool8 lodAverage)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetLodAverage, (nint)lodAverage.Value);
    }

    public void SetLodBias(float lodBias)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetLodBias, lodBias);
    }

    public void SetLodMaxClamp(float lodMaxClamp)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetLodMaxClamp, lodMaxClamp);
    }

    public void SetLodMinClamp(float lodMinClamp)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetLodMinClamp, lodMinClamp);
    }

    public void SetMagFilter(MTLSamplerMinMagFilter magFilter)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetMagFilter, (nint)(uint)magFilter);
    }

    public void SetMaxAnisotropy(uint maxAnisotropy)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetMaxAnisotropy, (nint)maxAnisotropy);
    }

    public void SetMinFilter(MTLSamplerMinMagFilter minFilter)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetMinFilter, (nint)(uint)minFilter);
    }

    public void SetMipFilter(MTLSamplerMipFilter mipFilter)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetMipFilter, (nint)(uint)mipFilter);
    }

    public void SetNormalizedCoordinates(Bool8 normalizedCoordinates)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetNormalizedCoordinates, (nint)normalizedCoordinates.Value);
    }

    public void SetRAddressMode(MTLSamplerAddressMode rAddressMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetRAddressMode, (nint)(uint)rAddressMode);
    }

    public void SetReductionMode(MTLSamplerReductionMode reductionMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetReductionMode, (nint)(uint)reductionMode);
    }

    public void SetSAddressMode(MTLSamplerAddressMode sAddressMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetSAddressMode, (nint)(uint)sAddressMode);
    }

    public void SetSupportArgumentBuffers(Bool8 supportArgumentBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetSupportArgumentBuffers, (nint)supportArgumentBuffers.Value);
    }

    public void SetTAddressMode(MTLSamplerAddressMode tAddressMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetTAddressMode, (nint)(uint)tAddressMode);
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
