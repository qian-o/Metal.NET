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

    public nuint DepthPlane
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorSelector.DepthPlane);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetDepthPlane, (nuint)value);
    }

    public nuint Level
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorSelector.Level);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetLevel, (nuint)value);
    }

    public MTLLoadAction LoadAction
    {
        get => (MTLLoadAction)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLRenderPassAttachmentDescriptorSelector.LoadAction));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetLoadAction, (uint)value);
    }

    public nuint ResolveDepthPlane
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorSelector.ResolveDepthPlane);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveDepthPlane, (nuint)value);
    }

    public nuint ResolveLevel
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorSelector.ResolveLevel);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveLevel, (nuint)value);
    }

    public nuint ResolveSlice
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorSelector.ResolveSlice);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveSlice, (nuint)value);
    }

    public MTLTexture ResolveTexture
    {
        get => new MTLTexture(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassAttachmentDescriptorSelector.ResolveTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveTexture, value.NativePtr);
    }

    public nuint Slice
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorSelector.Slice);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetSlice, (nuint)value);
    }

    public MTLStoreAction StoreAction
    {
        get => (MTLStoreAction)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLRenderPassAttachmentDescriptorSelector.StoreAction));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetStoreAction, (uint)value);
    }

    public nuint StoreActionOptions
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorSelector.StoreActionOptions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetStoreActionOptions, (nuint)value);
    }

    public MTLTexture Texture
    {
        get => new MTLTexture(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassAttachmentDescriptorSelector.Texture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetTexture, value.NativePtr);
    }

}

file class MTLRenderPassAttachmentDescriptorSelector
{
    public static readonly Selector DepthPlane = Selector.Register("depthPlane");

    public static readonly Selector SetDepthPlane = Selector.Register("setDepthPlane:");

    public static readonly Selector Level = Selector.Register("level");

    public static readonly Selector SetLevel = Selector.Register("setLevel:");

    public static readonly Selector LoadAction = Selector.Register("loadAction");

    public static readonly Selector SetLoadAction = Selector.Register("setLoadAction:");

    public static readonly Selector ResolveDepthPlane = Selector.Register("resolveDepthPlane");

    public static readonly Selector SetResolveDepthPlane = Selector.Register("setResolveDepthPlane:");

    public static readonly Selector ResolveLevel = Selector.Register("resolveLevel");

    public static readonly Selector SetResolveLevel = Selector.Register("setResolveLevel:");

    public static readonly Selector ResolveSlice = Selector.Register("resolveSlice");

    public static readonly Selector SetResolveSlice = Selector.Register("setResolveSlice:");

    public static readonly Selector ResolveTexture = Selector.Register("resolveTexture");

    public static readonly Selector SetResolveTexture = Selector.Register("setResolveTexture:");

    public static readonly Selector Slice = Selector.Register("slice");

    public static readonly Selector SetSlice = Selector.Register("setSlice:");

    public static readonly Selector StoreAction = Selector.Register("storeAction");

    public static readonly Selector SetStoreAction = Selector.Register("setStoreAction:");

    public static readonly Selector StoreActionOptions = Selector.Register("storeActionOptions");

    public static readonly Selector SetStoreActionOptions = Selector.Register("setStoreActionOptions:");

    public static readonly Selector Texture = Selector.Register("texture");

    public static readonly Selector SetTexture = Selector.Register("setTexture:");
}
