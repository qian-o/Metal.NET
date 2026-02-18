namespace Metal.NET;

public partial class MTLStencilDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStencilDescriptor");

    public MTLStencilDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLStencilOperation DepthFailureOperation
    {
        get => (MTLStencilOperation)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStencilDescriptorSelector.DepthFailureOperation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorSelector.SetDepthFailureOperation, (nuint)value);
    }

    public MTLStencilOperation DepthStencilPassOperation
    {
        get => (MTLStencilOperation)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStencilDescriptorSelector.DepthStencilPassOperation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorSelector.SetDepthStencilPassOperation, (nuint)value);
    }

    public uint ReadMask
    {
        get => ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLStencilDescriptorSelector.ReadMask);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorSelector.SetReadMask, value);
    }

    public MTLCompareFunction StencilCompareFunction
    {
        get => (MTLCompareFunction)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStencilDescriptorSelector.StencilCompareFunction);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorSelector.SetStencilCompareFunction, (nuint)value);
    }

    public MTLStencilOperation StencilFailureOperation
    {
        get => (MTLStencilOperation)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStencilDescriptorSelector.StencilFailureOperation);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorSelector.SetStencilFailureOperation, (nuint)value);
    }

    public uint WriteMask
    {
        get => ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLStencilDescriptorSelector.WriteMask);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorSelector.SetWriteMask, value);
    }
}

file static class MTLStencilDescriptorSelector
{
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
