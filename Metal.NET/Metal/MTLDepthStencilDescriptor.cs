namespace Metal.NET;

public readonly struct MTLDepthStencilDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLDepthStencilDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLDepthStencilDescriptorBindings.Class))
    {
    }

    public MTLStencilDescriptor? BackFaceStencil
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDepthStencilDescriptorBindings.BackFaceStencil);
            return ptr is not 0 ? new MTLStencilDescriptor(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetBackFaceStencil, value?.NativePtr ?? 0);
    }

    public MTLCompareFunction DepthCompareFunction
    {
        get => (MTLCompareFunction)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLDepthStencilDescriptorBindings.DepthCompareFunction);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetDepthCompareFunction, (nuint)value);
    }

    public bool DepthWriteEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDepthStencilDescriptorBindings.DepthWriteEnabled);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetDepthWriteEnabled, (Bool8)value);
    }

    public MTLStencilDescriptor? FrontFaceStencil
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDepthStencilDescriptorBindings.FrontFaceStencil);
            return ptr is not 0 ? new MTLStencilDescriptor(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetFrontFaceStencil, value?.NativePtr ?? 0);
    }

    public bool IsDepthWriteEnabled
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLDepthStencilDescriptorBindings.IsDepthWriteEnabled);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLDepthStencilDescriptorBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLDepthStencilDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
    }
}

file static class MTLDepthStencilDescriptorBindings
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
