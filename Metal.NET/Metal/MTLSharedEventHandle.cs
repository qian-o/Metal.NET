namespace Metal.NET;

public class MTLSharedEventHandle(nint nativePtr) : NativeObject(nativePtr)
{
    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLSharedEventHandleBindings.Label);

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

file static class MTLSharedEventHandleBindings
{
    public static readonly Selector Label = Selector.Register("label");
}
