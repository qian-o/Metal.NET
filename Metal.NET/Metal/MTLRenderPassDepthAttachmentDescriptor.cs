namespace Metal.NET;

public readonly struct MTLRenderPassDepthAttachmentDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLRenderPassAttachmentDescriptor(MTLRenderPassDepthAttachmentDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLRenderPassDepthAttachmentDescriptor value) => new(value.NativePtr);

    public MTLRenderPassDepthAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLRenderPassDepthAttachmentDescriptorBindings.Class))
    {
    }

    public MTLRenderPassDepthAttachmentDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public double ClearDepth
    {
        get => ObjectiveC.MsgSendDouble(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.ClearDepth);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetClearDepth, value);
    }

    public MTLMultisampleDepthResolveFilter DepthResolveFilter
    {
        get => (MTLMultisampleDepthResolveFilter)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.DepthResolveFilter);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetDepthResolveFilter, (nuint)value);
    }

    public MTLTexture Texture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.Texture));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetTexture, value.NativePtr);
    }

    public nuint Level
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.Level);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetLevel, value);
    }

    public nuint Slice
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.Slice);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetSlice, value);
    }

    public nuint DepthPlane
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.DepthPlane);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetDepthPlane, value);
    }

    public MTLTexture ResolveTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.ResolveTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetResolveTexture, value.NativePtr);
    }

    public nuint ResolveLevel
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.ResolveLevel);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetResolveLevel, value);
    }

    public nuint ResolveSlice
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.ResolveSlice);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetResolveSlice, value);
    }

    public nuint ResolveDepthPlane
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.ResolveDepthPlane);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetResolveDepthPlane, value);
    }

    public MTLLoadAction LoadAction
    {
        get => (MTLLoadAction)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.LoadAction);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetLoadAction, (nuint)value);
    }

    public MTLStoreAction StoreAction
    {
        get => (MTLStoreAction)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.StoreAction);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetStoreAction, (nuint)value);
    }

    /// <summary>
    /// Deprecated: Store action options have no effect on Apple Silicon
    /// </summary>
    [Obsolete("Store action options have no effect on Apple Silicon")]
    public MTLStoreActionOptions StoreActionOptions
    {
        get => (MTLStoreActionOptions)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.StoreActionOptions);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassDepthAttachmentDescriptorBindings.SetStoreActionOptions, (nuint)value);
    }
}

file static class MTLRenderPassDepthAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPassDepthAttachmentDescriptor");

    public static readonly Selector ClearDepth = "clearDepth";

    public static readonly Selector DepthPlane = "depthPlane";

    public static readonly Selector DepthResolveFilter = "depthResolveFilter";

    public static readonly Selector Level = "level";

    public static readonly Selector LoadAction = "loadAction";

    public static readonly Selector ResolveDepthPlane = "resolveDepthPlane";

    public static readonly Selector ResolveLevel = "resolveLevel";

    public static readonly Selector ResolveSlice = "resolveSlice";

    public static readonly Selector ResolveTexture = "resolveTexture";

    public static readonly Selector SetClearDepth = "setClearDepth:";

    public static readonly Selector SetDepthPlane = "setDepthPlane:";

    public static readonly Selector SetDepthResolveFilter = "setDepthResolveFilter:";

    public static readonly Selector SetLevel = "setLevel:";

    public static readonly Selector SetLoadAction = "setLoadAction:";

    public static readonly Selector SetResolveDepthPlane = "setResolveDepthPlane:";

    public static readonly Selector SetResolveLevel = "setResolveLevel:";

    public static readonly Selector SetResolveSlice = "setResolveSlice:";

    public static readonly Selector SetResolveTexture = "setResolveTexture:";

    public static readonly Selector SetSlice = "setSlice:";

    public static readonly Selector SetStoreAction = "setStoreAction:";

    public static readonly Selector SetStoreActionOptions = "setStoreActionOptions:";

    public static readonly Selector SetTexture = "setTexture:";

    public static readonly Selector Slice = "slice";

    public static readonly Selector StoreAction = "storeAction";

    public static readonly Selector StoreActionOptions = "storeActionOptions";

    public static readonly Selector Texture = "texture";
}
