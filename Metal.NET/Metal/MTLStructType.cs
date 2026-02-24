namespace Metal.NET;

public class MTLStructType(nint nativePtr) : MTLType(nativePtr), INativeObject<MTLStructType>
{
    public static MTLStructType Create(nint nativePtr) => new(nativePtr);
    public MTLStructType() : this(ObjectiveCRuntime.AllocInit(MTLStructTypeBindings.Class))
    {
    }

    public NSArray Members
    {
        get => GetProperty(ref field, MTLStructTypeBindings.Members);
    }

    public MTLStructMember MemberByName(NSString name)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeBindings.MemberByName, name.NativePtr);

        return new(nativePtr);
    }
}

file static class MTLStructTypeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStructType");

    public static readonly Selector MemberByName = "memberByName:";

    public static readonly Selector Members = "members";
}
