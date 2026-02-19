namespace Metal.NET;

public class MTLStencilDescriptor(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLStencilDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLStencilDescriptorBindings.Class), true)
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

    public static readonly Selector DepthFailureOperation = "depthFailureOperation";

    public static readonly Selector DepthStencilPassOperation = "depthStencilPassOperation";

    public static readonly Selector ReadMask = "readMask";

    public static readonly Selector SetDepthFailureOperation = "setDepthFailureOperation:";

    public static readonly Selector SetDepthStencilPassOperation = "setDepthStencilPassOperation:";

    public static readonly Selector SetReadMask = "setReadMask:";

    public static readonly Selector SetStencilCompareFunction = "setStencilCompareFunction:";

    public static readonly Selector SetStencilFailureOperation = "setStencilFailureOperation:";

    public static readonly Selector SetWriteMask = "setWriteMask:";

    public static readonly Selector StencilCompareFunction = "stencilCompareFunction";

    public static readonly Selector StencilFailureOperation = "stencilFailureOperation";

    public static readonly Selector WriteMask = "writeMask";
}
