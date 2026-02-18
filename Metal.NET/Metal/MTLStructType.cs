namespace Metal.NET;

public class MTLStructType(nint nativePtr) : MTLType(nativePtr)
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStructType");

    public NSArray Members
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeSelector.Members));
    }

    public static implicit operator nint(MTLStructType value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLStructType(nint value)
    {
        return new(value);
    }

    public MTLStructMember MemberByName(NSString name)
    {
        MTLStructMember result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeSelector.MemberByName, name.NativePtr));

        return result;
    }
}

file class MTLStructTypeSelector
{
    public static readonly Selector Members = Selector.Register("members");

    public static readonly Selector MemberByName = Selector.Register("memberByName:");
}
