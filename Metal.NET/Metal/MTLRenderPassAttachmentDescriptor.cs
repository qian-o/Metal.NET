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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetDepthPlane, (nint)depthPlane);
    }

    public void SetLevel(uint level)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetLevel, (nint)level);
    }

    public void SetLoadAction(MTLLoadAction loadAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetLoadAction, (nint)(uint)loadAction);
    }

    public void SetResolveDepthPlane(uint resolveDepthPlane)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveDepthPlane, (nint)resolveDepthPlane);
    }

    public void SetResolveLevel(uint resolveLevel)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveLevel, (nint)resolveLevel);
    }

    public void SetResolveSlice(uint resolveSlice)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveSlice, (nint)resolveSlice);
    }

    public void SetResolveTexture(MTLTexture resolveTexture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveTexture, resolveTexture.NativePtr);
    }

    public void SetSlice(uint slice)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetSlice, (nint)slice);
    }

    public void SetStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetStoreAction, (nint)(uint)storeAction);
    }

    public void SetStoreActionOptions(uint storeActionOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetStoreActionOptions, (nint)storeActionOptions);
    }

    public void SetTexture(MTLTexture texture)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetTexture, texture.NativePtr);
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
