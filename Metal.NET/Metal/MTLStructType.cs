namespace Metal.NET;

public class MTLStructType(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLStructType() : this(ObjectiveCRuntime.AllocInit(MTLStructTypeBindings.Class))
    {
    }

    public NSArray? Members
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeBindings.Members);

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

    public MTLStructMember? MemberByName(NSString name)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeBindings.MemberByName, name.NativePtr);
        return ptr is not 0 ? new MTLStructMember(ptr) : null;
    }
}

file static class MTLStructTypeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStructType");

    public static readonly Selector MemberByName = Selector.Register("memberByName:");

    public static readonly Selector Members = Selector.Register("members");
}
