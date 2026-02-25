namespace Metal.NET;

public class MTLStructType(nint nativePtr, bool ownsReference) : MTLType(nativePtr, ownsReference), INativeObject<MTLStructType>
{
    public static new MTLStructType Null { get; } = new(0, false);

    public static new MTLStructType Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLStructType() : this(ObjectiveCRuntime.AllocInit(MTLStructTypeBindings.Class), true)
    {
    }

    public MTLStructMember[] Members
    {
        get => GetArrayProperty<MTLStructMember>(MTLStructTypeBindings.Members);
    }

    public MTLStructMember MemberByName(NSString name)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeBindings.MemberByName, name.NativePtr);

        ObjectiveCRuntime.Retain(nativePtr);

        return new(nativePtr, true);
    }
}

file static class MTLStructTypeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStructType");

    public static readonly Selector MemberByName = "memberByName:";

    public static readonly Selector Members = "members";
}
