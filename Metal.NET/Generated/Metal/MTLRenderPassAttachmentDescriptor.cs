namespace Metal.NET;

public partial class MTLRenderPassAttachmentDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRenderPassAttachmentDescriptor>
{
    #region INativeObject
    public static new MTLRenderPassAttachmentDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPassAttachmentDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLRenderPassAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLRenderPassAttachmentDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLTexture Texture
    {
        get => GetProperty(ref field, MTLRenderPassAttachmentDescriptorBindings.Texture);
        set => SetProperty(ref field, MTLRenderPassAttachmentDescriptorBindings.SetTexture, value);
    }

    public nuint Level
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorBindings.Level);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetLevel, value);
    }

    public nuint Slice
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorBindings.Slice);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetSlice, value);
    }

    public nuint DepthPlane
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorBindings.DepthPlane);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetDepthPlane, value);
    }

    public MTLTexture ResolveTexture
    {
        get => GetProperty(ref field, MTLRenderPassAttachmentDescriptorBindings.ResolveTexture);
        set => SetProperty(ref field, MTLRenderPassAttachmentDescriptorBindings.SetResolveTexture, value);
    }

    public nuint ResolveLevel
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorBindings.ResolveLevel);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetResolveLevel, value);
    }

    public nuint ResolveSlice
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorBindings.ResolveSlice);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetResolveSlice, value);
    }

    public nuint ResolveDepthPlane
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassAttachmentDescriptorBindings.ResolveDepthPlane);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetResolveDepthPlane, value);
    }

    public MTLLoadAction LoadAction
    {
        get => (MTLLoadAction)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPassAttachmentDescriptorBindings.LoadAction);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetLoadAction, (nuint)value);
    }

    public MTLStoreAction StoreAction
    {
        get => (MTLStoreAction)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPassAttachmentDescriptorBindings.StoreAction);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetStoreAction, (nuint)value);
    }

    public MTLStoreActionOptions StoreActionOptions
    {
        get => (MTLStoreActionOptions)ObjectiveC.MsgSendULong(NativePtr, MTLRenderPassAttachmentDescriptorBindings.StoreActionOptions);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassAttachmentDescriptorBindings.SetStoreActionOptions, (nuint)value);
    }
}

file static class MTLRenderPassAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPassAttachmentDescriptor");

    public static readonly Selector DepthPlane = "depthPlane";

    public static readonly Selector Level = "level";

    public static readonly Selector LoadAction = "loadAction";

    public static readonly Selector ResolveDepthPlane = "resolveDepthPlane";

    public static readonly Selector ResolveLevel = "resolveLevel";

    public static readonly Selector ResolveSlice = "resolveSlice";

    public static readonly Selector ResolveTexture = "resolveTexture";

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
