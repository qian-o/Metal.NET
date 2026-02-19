namespace Metal.NET;

public class MTLRenderPassAttachmentDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
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
        get => GetProperty(ref field, MTLRenderPassAttachmentDescriptorBindings.ResolveTexture);
        set => SetProperty(ref field, MTLRenderPassAttachmentDescriptorBindings.SetResolveTexture, value);
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
        get => GetProperty(ref field, MTLRenderPassAttachmentDescriptorBindings.Texture);
        set => SetProperty(ref field, MTLRenderPassAttachmentDescriptorBindings.SetTexture, value);
    }
}

file static class MTLRenderPassAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassAttachmentDescriptor");

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
