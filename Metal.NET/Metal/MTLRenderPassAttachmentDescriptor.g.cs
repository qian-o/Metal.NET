namespace Metal.NET;

public class MTLRenderPassAttachmentDescriptor : IDisposable
{
    public MTLRenderPassAttachmentDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void SetDepthPlane(uint depthPlane)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetDepthPlane, (nint)depthPlane);
    }

    public void SetLevel(uint level)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetLevel, (nint)level);
    }

    public void SetLoadAction(MTLLoadAction loadAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetLoadAction, (nint)(uint)loadAction);
    }

    public void SetResolveDepthPlane(uint resolveDepthPlane)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveDepthPlane, (nint)resolveDepthPlane);
    }

    public void SetResolveLevel(uint resolveLevel)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveLevel, (nint)resolveLevel);
    }

    public void SetResolveSlice(uint resolveSlice)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveSlice, (nint)resolveSlice);
    }

    public void SetResolveTexture(MTLTexture resolveTexture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveTexture, resolveTexture.NativePtr);
    }

    public void SetSlice(uint slice)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetSlice, (nint)slice);
    }

    public void SetStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetStoreAction, (nint)(uint)storeAction);
    }

    public void SetStoreActionOptions(uint storeActionOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetStoreActionOptions, (nint)storeActionOptions);
    }

    public void SetTexture(MTLTexture texture)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetTexture, texture.NativePtr);
    }

}

file class MTLRenderPassAttachmentDescriptorSelector
{
    public static readonly Selector SetDepthPlane = Selector.Register("setDepthPlane:");
    public static readonly Selector SetLevel = Selector.Register("setLevel:");
    public static readonly Selector SetLoadAction = Selector.Register("setLoadAction:");
    public static readonly Selector SetResolveDepthPlane = Selector.Register("setResolveDepthPlane:");
    public static readonly Selector SetResolveLevel = Selector.Register("setResolveLevel:");
    public static readonly Selector SetResolveSlice = Selector.Register("setResolveSlice:");
    public static readonly Selector SetResolveTexture = Selector.Register("setResolveTexture:");
    public static readonly Selector SetSlice = Selector.Register("setSlice:");
    public static readonly Selector SetStoreAction = Selector.Register("setStoreAction:");
    public static readonly Selector SetStoreActionOptions = Selector.Register("setStoreActionOptions:");
    public static readonly Selector SetTexture = Selector.Register("setTexture:");
}
