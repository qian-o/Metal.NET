namespace Metal.NET;

public class MTLArchitecture(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLArchitecture() : this(ObjectiveCRuntime.AllocInit(MTLArchitectureBindings.Class))
    {
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArchitectureBindings.Name);

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

file static class MTLArchitectureBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLArchitecture");

    public static readonly Selector Name = Selector.Register("name");
}
