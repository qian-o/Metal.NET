namespace Metal.NET;

public class MTLResourceViewPool(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLResourceID BaseResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLResourceViewPoolBindings.BaseResourceID);
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceViewPoolBindings.Device);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLDevice(ptr);
            }

            return field;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceViewPoolBindings.Label);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
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
