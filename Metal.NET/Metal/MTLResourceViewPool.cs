namespace Metal.NET;

public class MTLResourceViewPool(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLResourceViewPool>
{
    #region INativeObject
    public static new MTLResourceViewPool Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLResourceViewPool New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLResourceID BaseResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLResourceViewPoolBindings.BaseResourceID);
    }

    public nuint ResourceViewCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResourceViewPoolBindings.ResourceViewCount);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLResourceViewPoolBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLResourceViewPoolBindings.Label);
    }

    public MTLResourceID CopyResourceViewsFromPoolSourceRangeDestinationIndex(MTLResourceViewPool sourcePool, NSRange sourceRange, nuint destinationIndex)
    {
        return ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLResourceViewPoolBindings.CopyResourceViewsFromPool, sourcePool.NativePtr, sourceRange, destinationIndex);
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
