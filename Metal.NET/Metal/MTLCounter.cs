namespace Metal.NET;

public class MTLCounter(nint nativePtr) : NativeObject(nativePtr)
{
    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLCounterBindings.Name);

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

file static class MTLCounterBindings
{
    public static readonly Selector Name = Selector.Register("name");
}
