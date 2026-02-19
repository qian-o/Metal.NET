namespace Metal.NET;

public class MTLStencilDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLStencilDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLStencilDescriptorBindings.Class))
    {
    }

    public MTLStencilOperation DepthFailureOperation
    {
        get => (MTLStencilOperation)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStencilDescriptorBindings.DepthFailureOperation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetDepthFailureOperation, (nuint)value);
    }

    public MTLStencilOperation DepthStencilPassOperation
    {
        get => (MTLStencilOperation)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStencilDescriptorBindings.DepthStencilPassOperation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetDepthStencilPassOperation, (nuint)value);
    }

    public uint ReadMask
    {
        get => ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLStencilDescriptorBindings.ReadMask);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetReadMask, value);
    }

    public MTLCompareFunction StencilCompareFunction
    {
        get => (MTLCompareFunction)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStencilDescriptorBindings.StencilCompareFunction);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetStencilCompareFunction, (nuint)value);
    }

    public MTLStencilOperation StencilFailureOperation
    {
        get => (MTLStencilOperation)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStencilDescriptorBindings.StencilFailureOperation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetStencilFailureOperation, (nuint)value);
    }

    public uint WriteMask
    {
        get => ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLStencilDescriptorBindings.WriteMask);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetWriteMask, value);
    }
}

file static class MTLStencilDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStencilDescriptor");

    public static readonly Selector DepthFailureOperation = Selector.Register("depthFailureOperation");

    public static readonly Selector DepthStencilPassOperation = Selector.Register("depthStencilPassOperation");

    public static readonly Selector ReadMask = Selector.Register("readMask");

    public static readonly Selector SetDepthFailureOperation = Selector.Register("setDepthFailureOperation:");

    public static readonly Selector SetDepthStencilPassOperation = Selector.Register("setDepthStencilPassOperation:");

    public static readonly Selector SetReadMask = Selector.Register("setReadMask:");

    public static readonly Selector SetStencilCompareFunction = Selector.Register("setStencilCompareFunction:");

    public static readonly Selector SetStencilFailureOperation = Selector.Register("setStencilFailureOperation:");

    public static readonly Selector SetWriteMask = Selector.Register("setWriteMask:");

    public static readonly Selector StencilCompareFunction = Selector.Register("stencilCompareFunction");

    public static readonly Selector StencilFailureOperation = Selector.Register("stencilFailureOperation");

    public static readonly Selector WriteMask = Selector.Register("writeMask");
}
