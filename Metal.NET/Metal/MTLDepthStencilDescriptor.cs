namespace Metal.NET;

public class MTLDepthStencilDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLDepthStencilDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLDepthStencilDescriptorSelector.Class))
    {
    }

    public MTLStencilDescriptor? BackFaceStencil
    {
        get => GetNullableObject<MTLStencilDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDepthStencilDescriptorSelector.BackFaceStencil));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetBackFaceStencil, value?.NativePtr ?? 0);
    }

    public MTLCompareFunction DepthCompareFunction
    {
        get => (MTLCompareFunction)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDepthStencilDescriptorSelector.DepthCompareFunction);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetDepthCompareFunction, (nuint)value);
    }

    public bool DepthWriteEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDepthStencilDescriptorSelector.DepthWriteEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetDepthWriteEnabled, (Bool8)value);
    }

    public MTLStencilDescriptor? FrontFaceStencil
    {
        get => GetNullableObject<MTLStencilDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDepthStencilDescriptorSelector.FrontFaceStencil));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetFrontFaceStencil, value?.NativePtr ?? 0);
    }

    public bool IsDepthWriteEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDepthStencilDescriptorSelector.IsDepthWriteEnabled);
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDepthStencilDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }
}

file static class MTLDepthStencilDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLDepthStencilDescriptor");

    public static readonly Selector BackFaceStencil = Selector.Register("backFaceStencil");

    public static readonly Selector DepthCompareFunction = Selector.Register("depthCompareFunction");

    public static readonly Selector DepthWriteEnabled = Selector.Register("isDepthWriteEnabled");

    public static readonly Selector FrontFaceStencil = Selector.Register("frontFaceStencil");

    public static readonly Selector IsDepthWriteEnabled = Selector.Register("isDepthWriteEnabled");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetBackFaceStencil = Selector.Register("setBackFaceStencil:");

    public static readonly Selector SetDepthCompareFunction = Selector.Register("setDepthCompareFunction:");

    public static readonly Selector SetDepthWriteEnabled = Selector.Register("setDepthWriteEnabled:");

    public static readonly Selector SetFrontFaceStencil = Selector.Register("setFrontFaceStencil:");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
