namespace Metal.NET;

public readonly struct MTLStructType(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLStructType() : this(ObjectiveCRuntime.AllocInit(MTLStructTypeBindings.Class))
    {
    }

    public NSArray? Members
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeBindings.Members);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }

    public MTLStructMember? MemberByName(NSString name)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeBindings.MemberByName, name.NativePtr);
        return ptr is not 0 ? new MTLStructMember(ptr) : default;
    }
}

file static class MTLStructTypeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStructType");

    public static readonly Selector MemberByName = Selector.Register("memberByName:");

    public static readonly Selector Members = Selector.Register("members");
}
