namespace Metal.NET;

public readonly struct MTLRenderPassAttachmentDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLRenderPassAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassAttachmentDescriptorBindings.Class))
    {
    }

    public nuint DepthPlane
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorBindings.DepthPlane);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetDepthPlane, value);
    }

    public nuint Level
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorBindings.Level);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetLevel, value);
    }

    public MTLLoadAction LoadAction
    {
        get => (MTLLoadAction)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorBindings.LoadAction);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetLoadAction, (nuint)value);
    }

    public nuint ResolveDepthPlane
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorBindings.ResolveDepthPlane);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetResolveDepthPlane, value);
    }

    public nuint ResolveLevel
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorBindings.ResolveLevel);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetResolveLevel, value);
    }

    public nuint ResolveSlice
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorBindings.ResolveSlice);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetResolveSlice, value);
    }

    public MTLTexture? ResolveTexture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassAttachmentDescriptorBindings.ResolveTexture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetResolveTexture, value?.NativePtr ?? 0);
    }

    public nuint Slice
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorBindings.Slice);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetSlice, value);
    }

    public MTLStoreAction StoreAction
    {
        get => (MTLStoreAction)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorBindings.StoreAction);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetStoreAction, (nuint)value);
    }

    public MTLStoreActionOptions StoreActionOptions
    {
        get => (MTLStoreActionOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorBindings.StoreActionOptions);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetStoreActionOptions, (nuint)value);
    }

    public MTLTexture? Texture
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassAttachmentDescriptorBindings.Texture);
            return ptr is not 0 ? new MTLTexture(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetTexture, value?.NativePtr ?? 0);
    }
}

file static class MTLRenderPassAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassAttachmentDescriptor");

    public static readonly Selector DepthPlane = Selector.Register("depthPlane");

    public static readonly Selector Level = Selector.Register("level");

    public static readonly Selector LoadAction = Selector.Register("loadAction");

    public static readonly Selector ResolveDepthPlane = Selector.Register("resolveDepthPlane");

    public static readonly Selector ResolveLevel = Selector.Register("resolveLevel");

    public static readonly Selector ResolveSlice = Selector.Register("resolveSlice");

    public static readonly Selector ResolveTexture = Selector.Register("resolveTexture");

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

    public static readonly Selector Slice = Selector.Register("slice");

    public static readonly Selector StoreAction = Selector.Register("storeAction");

    public static readonly Selector StoreActionOptions = Selector.Register("storeActionOptions");

    public static readonly Selector Texture = Selector.Register("texture");
}
