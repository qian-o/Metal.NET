namespace Metal.NET;

public readonly struct MTLResourceViewPool(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLResourceID BaseResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLResourceViewPoolBindings.BaseResourceID);
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceViewPoolBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceViewPoolBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }

    public nuint ResourceViewCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceViewPoolBindings.ResourceViewCount);
    }

    public MTLResourceID CopyResourceViewsFromPool(MTLResourceViewPool sourcePool, NSRange sourceRange, nuint destinationIndex)
    {
        return ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLResourceViewPoolBindings.CopyResourceViewsFromPool, sourcePool.NativePtr, sourceRange, destinationIndex);
    }
}

file static class MTLResourceViewPoolBindings
{
    public static readonly Selector BaseResourceID = Selector.Register("baseResourceID");

    public static readonly Selector CopyResourceViewsFromPool = Selector.Register("copyResourceViewsFromPool:sourceRange:destinationIndex:");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector ResourceViewCount = Selector.Register("resourceViewCount");
}
