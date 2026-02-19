namespace Metal.NET;

public class MTLCounterSet(nint nativePtr) : NativeObject(nativePtr)
{
    public NSArray? Counters
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSetBindings.Counters);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSArray(ptr);
            }

            return field;
        }
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterSetBindings.Name);

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
}

file static class MTLCounterSetBindings
{
    public static readonly Selector Counters = Selector.Register("counters");

    public static readonly Selector Name = Selector.Register("name");
}
