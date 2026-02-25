namespace Metal.NET;

public class MTLStructType(nint nativePtr, bool ownsReference) : MTLType(nativePtr, ownsReference), INativeObject<MTLStructType>
{
    public static new MTLStructType Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLStructType() : this(ObjectiveCRuntime.AllocInit(MTLStructTypeBindings.Class), true)
    {
    }

    public NSArray<MTLStructMember> Members
    {
        get => GetProperty(ref field, MTLStructTypeBindings.Members);
    }

    public MTLStructMember MemberByName(NSString name)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeBindings.MemberByName, name.NativePtr);

        return new(nativePtr, false);
    }
}

file static class MTLStructTypeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStructType");

    public static readonly Selector MemberByName = "memberByName:";

    public static readonly Selector Members = "members";
}
