namespace Metal.NET;

public readonly struct MTLRenderPassColorAttachmentDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLRenderPassAttachmentDescriptor(MTLRenderPassColorAttachmentDescriptor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLRenderPassColorAttachmentDescriptor value) => new(value.NativePtr);

    public MTLRenderPassColorAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLRenderPassColorAttachmentDescriptorBindings.Class))
    {
    }

    public MTLRenderPassColorAttachmentDescriptor Retain()
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

    public MTLClearColor ClearColor
    {
        get => ObjectiveC.MsgSendMTLClearColor(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.ClearColor);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.SetClearColor, value);
    }

    public MTLTexture Texture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.Texture));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.SetTexture, value.NativePtr);
    }

    public nuint Level
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.Level);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.SetLevel, value);
    }

    public nuint Slice
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.Slice);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.SetSlice, value);
    }

    public nuint DepthPlane
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.DepthPlane);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.SetDepthPlane, value);
    }

    public MTLTexture ResolveTexture
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.ResolveTexture));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.SetResolveTexture, value.NativePtr);
    }

    public nuint ResolveLevel
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.ResolveLevel);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.SetResolveLevel, value);
    }

    public nuint ResolveSlice
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.ResolveSlice);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.SetResolveSlice, value);
    }

    public nuint ResolveDepthPlane
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.ResolveDepthPlane);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.SetResolveDepthPlane, value);
    }

    public MTLLoadAction LoadAction
    {
        get => (MTLLoadAction)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.LoadAction);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.SetLoadAction, (nuint)value);
    }

    public MTLStoreAction StoreAction
    {
        get => (MTLStoreAction)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.StoreAction);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.SetStoreAction, (nuint)value);
    }

    /// <summary>
    /// Deprecated: Store action options have no effect on Apple Silicon
    /// </summary>
    [Obsolete("Store action options have no effect on Apple Silicon")]
    public MTLStoreActionOptions StoreActionOptions
    {
        get => (MTLStoreActionOptions)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.StoreActionOptions);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassColorAttachmentDescriptorBindings.SetStoreActionOptions, (nuint)value);
    }
}

file static class MTLRenderPassColorAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPassColorAttachmentDescriptor");

    public static readonly Selector ClearColor = "clearColor";

    public static readonly Selector DepthPlane = "depthPlane";

    public static readonly Selector Level = "level";

    public static readonly Selector LoadAction = "loadAction";

    public static readonly Selector ResolveDepthPlane = "resolveDepthPlane";

    public static readonly Selector ResolveLevel = "resolveLevel";

    public static readonly Selector ResolveSlice = "resolveSlice";

    public static readonly Selector ResolveTexture = "resolveTexture";

    public static readonly Selector SetClearColor = "setClearColor:";

    public static readonly Selector SetDepthPlane = "setDepthPlane:";

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
