namespace Metal.NET;

file class MTLRenderPassAttachmentDescriptorSelector
{
    public static readonly Selector SetDepthPlane_ = Selector.Register("setDepthPlane:");
    public static readonly Selector SetLevel_ = Selector.Register("setLevel:");
    public static readonly Selector SetLoadAction_ = Selector.Register("setLoadAction:");
    public static readonly Selector SetResolveDepthPlane_ = Selector.Register("setResolveDepthPlane:");
    public static readonly Selector SetResolveLevel_ = Selector.Register("setResolveLevel:");
    public static readonly Selector SetResolveSlice_ = Selector.Register("setResolveSlice:");
    public static readonly Selector SetResolveTexture_ = Selector.Register("setResolveTexture:");
    public static readonly Selector SetSlice_ = Selector.Register("setSlice:");
    public static readonly Selector SetStoreAction_ = Selector.Register("setStoreAction:");
    public static readonly Selector SetStoreActionOptions_ = Selector.Register("setStoreActionOptions:");
    public static readonly Selector SetTexture_ = Selector.Register("setTexture:");
}

public class MTLRenderPassAttachmentDescriptor : IDisposable
{
    public MTLRenderPassAttachmentDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLRenderPassAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRenderPassAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPassAttachmentDescriptor(nint value)
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

    public void SetDepthPlane(nuint depthPlane)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetDepthPlane_, (nint)depthPlane);
    }

    public void SetLevel(nuint level)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetLevel_, (nint)level);
    }

    public void SetLoadAction(MTLLoadAction loadAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetLoadAction_, (nint)(uint)loadAction);
    }

    public void SetResolveDepthPlane(nuint resolveDepthPlane)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveDepthPlane_, (nint)resolveDepthPlane);
    }

    public void SetResolveLevel(nuint resolveLevel)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveLevel_, (nint)resolveLevel);
    }

    public void SetResolveSlice(nuint resolveSlice)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveSlice_, (nint)resolveSlice);
    }

    public void SetResolveTexture(MTLTexture resolveTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveTexture_, resolveTexture.NativePtr);
    }

    public void SetSlice(nuint slice)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetSlice_, (nint)slice);
    }

    public void SetStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetStoreAction_, (nint)(uint)storeAction);
    }

    public void SetStoreActionOptions(nuint storeActionOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetStoreActionOptions_, (nint)storeActionOptions);
    }

    public void SetTexture(MTLTexture texture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetTexture_, texture.NativePtr);
    }

}
