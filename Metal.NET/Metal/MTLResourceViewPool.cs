namespace Metal.NET;

public class MTLResourceViewPool(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLResourceID BaseResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLResourceViewPoolSelector.BaseResourceID);
    }

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceViewPoolSelector.Device));
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceViewPoolSelector.Label));
    }

    public nuint ResourceViewCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceViewPoolSelector.ResourceViewCount);
    }

    public MTLResourceID CopyResourceViewsFromPool(MTLResourceViewPool sourcePool, NSRange sourceRange, nuint destinationIndex)
    {
        return ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLResourceViewPoolSelector.CopyResourceViewsFromPool, sourcePool.NativePtr, sourceRange, destinationIndex);
    }
}

file static class MTLResourceViewPoolSelector
{
    public static readonly Selector BaseResourceID = Selector.Register("baseResourceID");

    public static readonly Selector CopyResourceViewsFromPool = Selector.Register("copyResourceViewsFromPool:sourceRange:destinationIndex:");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector ResourceViewCount = Selector.Register("resourceViewCount");
}
