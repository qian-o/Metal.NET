namespace Metal.NET;

public class MTLStructType(nint nativePtr, bool retain) : MTLType(nativePtr, retain)
{
    public MTLStructType() : this(ObjectiveCRuntime.AllocInit(MTLStructTypeBindings.Class), false)
    {
    }

    public NSArray? Members
    {
        get => GetProperty(ref field, MTLStructTypeBindings.Members);
    }

    public MTLStructMember? MemberByName(NSString name)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeBindings.MemberByName, name.NativePtr);

        return nativePtr is not 0 ? new(nativePtr, true) : null;
    }
}

file static class MTLStructTypeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStructType");

    public static readonly Selector MemberByName = "memberByName:";

    public static readonly Selector Members = "members";
}
