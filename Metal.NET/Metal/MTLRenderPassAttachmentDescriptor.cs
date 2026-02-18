namespace Metal.NET;

public class MTLRenderPassAttachmentDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassAttachmentDescriptor");

    public MTLRenderPassAttachmentDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLRenderPassAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLRenderPassAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint DepthPlane
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorSelector.DepthPlane);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetDepthPlane, value);
    }

    public nuint Level
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorSelector.Level);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetLevel, value);
    }

    public MTLLoadAction LoadAction
    {
        get => (MTLLoadAction)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLRenderPassAttachmentDescriptorSelector.LoadAction);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetLoadAction, (ulong)value);
    }

    public nuint ResolveDepthPlane
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorSelector.ResolveDepthPlane);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveDepthPlane, value);
    }

    public nuint ResolveLevel
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorSelector.ResolveLevel);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveLevel, value);
    }

    public nuint ResolveSlice
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorSelector.ResolveSlice);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveSlice, value);
    }

    public MTLTexture ResolveTexture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassAttachmentDescriptorSelector.ResolveTexture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetResolveTexture, value.NativePtr);
    }

    public nuint Slice
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorSelector.Slice);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetSlice, value);
    }

    public MTLStoreAction StoreAction
    {
        get => (MTLStoreAction)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLRenderPassAttachmentDescriptorSelector.StoreAction);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetStoreAction, (ulong)value);
    }

    public MTLStoreActionOptions StoreActionOptions
    {
        get => (MTLStoreActionOptions)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLRenderPassAttachmentDescriptorSelector.StoreActionOptions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetStoreActionOptions, (ulong)value);
    }

    public MTLTexture Texture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassAttachmentDescriptorSelector.Texture));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorSelector.SetTexture, value.NativePtr);
    }

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
