namespace Metal.NET;

public class MTLStencilDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStencilDescriptor");

    public MTLStencilDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLStencilDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLStencilDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLStencilOperation DepthFailureOperation
    {
        get => (MTLStencilOperation)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLStencilDescriptorSelector.DepthFailureOperation));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorSelector.SetDepthFailureOperation, (ulong)value);
    }

    public MTLStencilOperation DepthStencilPassOperation
    {
        get => (MTLStencilOperation)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLStencilDescriptorSelector.DepthStencilPassOperation));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorSelector.SetDepthStencilPassOperation, (ulong)value);
    }

    public uint ReadMask
    {
        get => ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLStencilDescriptorSelector.ReadMask);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorSelector.SetReadMask, value);
    }

    public MTLCompareFunction StencilCompareFunction
    {
        get => (MTLCompareFunction)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLStencilDescriptorSelector.StencilCompareFunction));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorSelector.SetStencilCompareFunction, (ulong)value);
    }

    public MTLStencilOperation StencilFailureOperation
    {
        get => (MTLStencilOperation)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLStencilDescriptorSelector.StencilFailureOperation));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorSelector.SetStencilFailureOperation, (ulong)value);
    }

    public uint WriteMask
    {
        get => ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLStencilDescriptorSelector.WriteMask);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLStencilDescriptorSelector.SetWriteMask, value);
    }

    public static implicit operator nint(MTLStencilDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLStencilDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLStencilDescriptorSelector
{
    public static readonly Selector DepthFailureOperation = Selector.Register("depthFailureOperation");

    public static readonly Selector SetDepthFailureOperation = Selector.Register("setDepthFailureOperation:");

    public static readonly Selector DepthStencilPassOperation = Selector.Register("depthStencilPassOperation");

    public static readonly Selector SetDepthStencilPassOperation = Selector.Register("setDepthStencilPassOperation:");

    public static readonly Selector ReadMask = Selector.Register("readMask");

    public static readonly Selector SetReadMask = Selector.Register("setReadMask:");

    public static readonly Selector StencilCompareFunction = Selector.Register("stencilCompareFunction");

    public static readonly Selector SetStencilCompareFunction = Selector.Register("setStencilCompareFunction:");

    public static readonly Selector StencilFailureOperation = Selector.Register("stencilFailureOperation");

    public static readonly Selector SetStencilFailureOperation = Selector.Register("setStencilFailureOperation:");

    public static readonly Selector WriteMask = Selector.Register("writeMask");

    public static readonly Selector SetWriteMask = Selector.Register("setWriteMask:");
}
