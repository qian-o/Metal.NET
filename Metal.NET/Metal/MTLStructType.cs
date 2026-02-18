namespace Metal.NET;

public partial class MTLStructType : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStructType");

    public MTLStructType(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? Members
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeSelector.Members);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLStructMember? MemberByName(NSString name)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeSelector.MemberByName, name.NativePtr);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLStructTypeSelector
{
    public static readonly Selector MemberByName = Selector.Register("memberByName:");

    public static readonly Selector Members = Selector.Register("members");
}
