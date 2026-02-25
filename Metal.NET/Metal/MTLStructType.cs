namespace Metal.NET;

public class MTLStructType(nint nativePtr, NativeObjectOwnership ownership) : MTLType(nativePtr, ownership), INativeObject<MTLStructType>
{
    public static new MTLStructType Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLStructType Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLStructType() : this(ObjectiveCRuntime.AllocInit(MTLStructTypeBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLStructMember[] Members
    {
        get => GetArrayProperty<MTLStructMember>(MTLStructTypeBindings.Members);
    }

    public MTLStructMember MemberByName(NSString name)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructTypeBindings.MemberByName, name.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLStructTypeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStructType");

    public static readonly Selector MemberByName = "memberByName:";

    public static readonly Selector Members = "members";
}
