namespace Metal.NET;

public class MTLResourceViewPool(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLResourceID BaseResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLResourceViewPoolBindings.BaseResourceID);
    }

    public MTLDevice? Device
    {
        get => GetProperty(ref field, MTLResourceViewPoolBindings.Device);
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTLResourceViewPoolBindings.Label);
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
    public static readonly Selector BaseResourceID = "baseResourceID";

    public static readonly Selector CopyResourceViewsFromPool = "copyResourceViewsFromPool:sourceRange:destinationIndex:";

    public static readonly Selector Device = "device";

    public static readonly Selector Label = "label";

    public static readonly Selector ResourceViewCount = "resourceViewCount";
}
