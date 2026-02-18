namespace Metal.NET;

public class MTLStructType(nint nativePtr) : MTLType(nativePtr)
{
    public MTLStructType() : this(ObjectiveCRuntime.AllocInit(MTLStructTypeSelector.Class))
    {
    }

    public NSArray? Members
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeSelector.Members));
    }

    public MTLStructMember? MemberByName(NSString name)
    {
        return GetNullableObject<MTLStructMember>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeSelector.MemberByName, name.NativePtr));
    }
}

file static class MTLStructTypeSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStructType");

    public static readonly Selector MemberByName = Selector.Register("memberByName:");

    public static readonly Selector Members = Selector.Register("members");
}
