namespace Metal.NET;

public class MTLIOFileHandle(nint nativePtr) : NativeObject(nativePtr)
{
    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIOFileHandleBindings.Label);

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
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLIOFileHandleBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
    }
}

file static class MTLIOFileHandleBindings
{
    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
