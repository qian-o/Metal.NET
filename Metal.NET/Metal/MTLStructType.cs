namespace Metal.NET;

public class MTLStructType(nint nativePtr, bool ownsReference, bool allowGCRelease) : MTLType(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLStructType>
{
    public static new MTLStructType Null { get; } = new(0, false, false);

    public static new MTLStructType Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public MTLStructType() : this(ObjectiveCRuntime.AllocInit(MTLStructTypeBindings.Class), true, true)
    {
    }

    public MTLStructMember[] Members
    {
        get => GetArrayProperty<MTLStructMember>(MTLStructTypeBindings.Members);
    }

    public MTLStructMember MemberByName(NSString name)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeBindings.MemberByName, name.NativePtr);

        return new(nativePtr, true, false);
    }
}

file static class MTLStructTypeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStructType");

    public static readonly Selector MemberByName = "memberByName:";

    public static readonly Selector Members = "members";
}
