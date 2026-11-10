namespace Metal.NET;

public readonly struct MTLRenderPassStencilAttachmentDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLRenderPassAttachmentDescriptor(MTLRenderPassStencilAttachmentDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLRenderPassStencilAttachmentDescriptor value) => new(value.NativePtr);

    public MTLRenderPassStencilAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLRenderPassStencilAttachmentDescriptorBindings.Class))
    {
    }

    public MTLRenderPassStencilAttachmentDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public uint ClearStencil
    {
        get => ObjectiveC.MsgSendUInt(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.ClearStencil);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.SetClearStencil, value);
    }

    public MTLMultisampleStencilResolveFilter StencilResolveFilter
    {
        get => (MTLMultisampleStencilResolveFilter)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.StencilResolveFilter);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.SetStencilResolveFilter, (nuint)value);
    }

    public MTLTexture Texture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.Texture));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.SetTexture, value.NativePtr);
    }

    public nuint Level
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.Level);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.SetLevel, value);
    }

    public nuint Slice
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.Slice);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.SetSlice, value);
    }

    public nuint DepthPlane
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.DepthPlane);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.SetDepthPlane, value);
    }

    public MTLTexture ResolveTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.ResolveTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.SetResolveTexture, value.NativePtr);
    }

    public nuint ResolveLevel
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.ResolveLevel);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.SetResolveLevel, value);
    }

    public nuint ResolveSlice
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.ResolveSlice);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.SetResolveSlice, value);
    }

    public nuint ResolveDepthPlane
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.ResolveDepthPlane);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.SetResolveDepthPlane, value);
    }

    public MTLLoadAction LoadAction
    {
        get => (MTLLoadAction)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.LoadAction);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.SetLoadAction, (nuint)value);
    }

    public MTLStoreAction StoreAction
    {
        get => (MTLStoreAction)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.StoreAction);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.SetStoreAction, (nuint)value);
    }

    /// <summary>
    /// Deprecated: Store action options have no effect on Apple Silicon
    /// </summary>
    [Obsolete("Store action options have no effect on Apple Silicon")]
    public MTLStoreActionOptions StoreActionOptions
    {
        get => (MTLStoreActionOptions)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.StoreActionOptions);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassStencilAttachmentDescriptorBindings.SetStoreActionOptions, (nuint)value);
    }
}

file static class MTLRenderPassStencilAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPassStencilAttachmentDescriptor");

    public static readonly Selector ClearStencil = "clearStencil";

    public static readonly Selector DepthPlane = "depthPlane";

    public static readonly Selector Level = "level";

    public static readonly Selector LoadAction = "loadAction";

    public static readonly Selector ResolveDepthPlane = "resolveDepthPlane";

    public static readonly Selector ResolveLevel = "resolveLevel";

    public static readonly Selector ResolveSlice = "resolveSlice";

    public static readonly Selector ResolveTexture = "resolveTexture";

    public static readonly Selector SetClearStencil = "setClearStencil:";

    public static readonly Selector SetDepthPlane = "setDepthPlane:";

    public static readonly Selector SetLevel = "setLevel:";

    public static readonly Selector SetLoadAction = "setLoadAction:";

    public static readonly Selector SetResolveDepthPlane = "setResolveDepthPlane:";

    public static readonly Selector SetResolveLevel = "setResolveLevel:";

    public static readonly Selector SetResolveSlice = "setResolveSlice:";

    public static readonly Selector SetResolveTexture = "setResolveTexture:";

    public static readonly Selector SetSlice = "setSlice:";

    public static readonly Selector SetStencilResolveFilter = "setStencilResolveFilter:";

    public static readonly Selector SetStoreAction = "setStoreAction:";

    public static readonly Selector SetStoreActionOptions = "setStoreActionOptions:";

    public static readonly Selector SetTexture = "setTexture:";

    public static readonly Selector Slice = "slice";

    public static readonly Selector StencilResolveFilter = "stencilResolveFilter";

    public static readonly Selector StoreAction = "storeAction";

    public static readonly Selector StoreActionOptions = "storeActionOptions";

    public static readonly Selector Texture = "texture";
}
