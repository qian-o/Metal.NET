namespace Metal.NET;

public readonly struct MTLStencilDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLStencilDescriptor value) => new(value.NativePtr);

    public MTLStencilDescriptor() : this(ObjectiveC.AllocInit(MTLStencilDescriptorBindings.Class))
    {
    }

    public MTLStencilDescriptor Retain()
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

    public MTLCompareFunction StencilCompareFunction
    {
        get => (MTLCompareFunction)ObjectiveC.MsgSendULong(NativePtr, MTLStencilDescriptorBindings.StencilCompareFunction);
        set => ObjectiveC.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetStencilCompareFunction, (nuint)value);
    }

    public MTLStencilOperation StencilFailureOperation
    {
        get => (MTLStencilOperation)ObjectiveC.MsgSendULong(NativePtr, MTLStencilDescriptorBindings.StencilFailureOperation);
        set => ObjectiveC.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetStencilFailureOperation, (nuint)value);
    }

    public MTLStencilOperation DepthFailureOperation
    {
        get => (MTLStencilOperation)ObjectiveC.MsgSendULong(NativePtr, MTLStencilDescriptorBindings.DepthFailureOperation);
        set => ObjectiveC.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetDepthFailureOperation, (nuint)value);
    }

    public MTLStencilOperation DepthStencilPassOperation
    {
        get => (MTLStencilOperation)ObjectiveC.MsgSendULong(NativePtr, MTLStencilDescriptorBindings.DepthStencilPassOperation);
        set => ObjectiveC.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetDepthStencilPassOperation, (nuint)value);
    }

    public uint ReadMask
    {
        get => ObjectiveC.MsgSendUInt(NativePtr, MTLStencilDescriptorBindings.ReadMask);
        set => ObjectiveC.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetReadMask, value);
    }

    public uint WriteMask
    {
        get => ObjectiveC.MsgSendUInt(NativePtr, MTLStencilDescriptorBindings.WriteMask);
        set => ObjectiveC.MsgSend(NativePtr, MTLStencilDescriptorBindings.SetWriteMask, value);
    }
}

file static class MTLStencilDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLStencilDescriptor");

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
