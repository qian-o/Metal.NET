namespace Metal.NET;

file class MTLSamplerDescriptorSelector
{
    public static readonly Selector SetBorderColor_ = Selector.Register("setBorderColor:");
    public static readonly Selector SetCompareFunction_ = Selector.Register("setCompareFunction:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
    public static readonly Selector SetLodAverage_ = Selector.Register("setLodAverage:");
    public static readonly Selector SetLodBias_ = Selector.Register("setLodBias:");
    public static readonly Selector SetLodMaxClamp_ = Selector.Register("setLodMaxClamp:");
    public static readonly Selector SetLodMinClamp_ = Selector.Register("setLodMinClamp:");
    public static readonly Selector SetMagFilter_ = Selector.Register("setMagFilter:");
    public static readonly Selector SetMaxAnisotropy_ = Selector.Register("setMaxAnisotropy:");
    public static readonly Selector SetMinFilter_ = Selector.Register("setMinFilter:");
    public static readonly Selector SetMipFilter_ = Selector.Register("setMipFilter:");
    public static readonly Selector SetNormalizedCoordinates_ = Selector.Register("setNormalizedCoordinates:");
    public static readonly Selector SetRAddressMode_ = Selector.Register("setRAddressMode:");
    public static readonly Selector SetReductionMode_ = Selector.Register("setReductionMode:");
    public static readonly Selector SetSAddressMode_ = Selector.Register("setSAddressMode:");
    public static readonly Selector SetSupportArgumentBuffers_ = Selector.Register("setSupportArgumentBuffers:");
    public static readonly Selector SetTAddressMode_ = Selector.Register("setTAddressMode:");
}

public class MTLSamplerDescriptor : IDisposable
{
    public MTLSamplerDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetBorderColor_, (nint)(uint)borderColor);
    }

    public void SetCompareFunction(MTLCompareFunction compareFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetCompareFunction_, (nint)(uint)compareFunction);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetLabel_, label.NativePtr);
    }

    public void SetLodAverage(Bool8 lodAverage)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetLodAverage_, (nint)lodAverage.Value);
    }

    public void SetLodBias(float lodBias)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetLodBias_, lodBias);
    }

    public void SetLodMaxClamp(float lodMaxClamp)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetLodMaxClamp_, lodMaxClamp);
    }

    public void SetLodMinClamp(float lodMinClamp)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetLodMinClamp_, lodMinClamp);
    }

    public void SetMagFilter(MTLSamplerMinMagFilter magFilter)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetMagFilter_, (nint)(uint)magFilter);
    }

    public void SetMaxAnisotropy(nuint maxAnisotropy)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetMaxAnisotropy_, (nint)maxAnisotropy);
    }

    public void SetMinFilter(MTLSamplerMinMagFilter minFilter)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetMinFilter_, (nint)(uint)minFilter);
    }

    public void SetMipFilter(MTLSamplerMipFilter mipFilter)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetMipFilter_, (nint)(uint)mipFilter);
    }

    public void SetNormalizedCoordinates(Bool8 normalizedCoordinates)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetNormalizedCoordinates_, (nint)normalizedCoordinates.Value);
    }

    public void SetRAddressMode(MTLSamplerAddressMode rAddressMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetRAddressMode_, (nint)(uint)rAddressMode);
    }

    public void SetReductionMode(MTLSamplerReductionMode reductionMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetReductionMode_, (nint)(uint)reductionMode);
    }

    public void SetSAddressMode(MTLSamplerAddressMode sAddressMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetSAddressMode_, (nint)(uint)sAddressMode);
    }

    public void SetSupportArgumentBuffers(Bool8 supportArgumentBuffers)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetSupportArgumentBuffers_, (nint)supportArgumentBuffers.Value);
    }

    public void SetTAddressMode(MTLSamplerAddressMode tAddressMode)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLSamplerDescriptorSelector.SetTAddressMode_, (nint)(uint)tAddressMode);
    }

}
