namespace Metal.NET;

public class MTLStructType(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLStructType() : this(ObjectiveCRuntime.AllocInit(MTLStructTypeBindings.Class))
    {
    }

    public NSArray? Members
    {
        get => GetProperty<NSArray>(ref field, MTLStructTypeBindings.Members);
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

    public static readonly Selector MemberByName = "memberByName:";

    public static readonly Selector Members = "members";
}
