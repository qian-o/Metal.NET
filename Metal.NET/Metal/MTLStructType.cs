namespace Metal.NET;

public class MTLStructType(nint nativePtr, NativeObjectOwnership ownership) : MTLType(nativePtr, ownership), INativeObject<MTLStructType>
{
    #region INativeObject
    public static new MTLStructType Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLStructType New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLStructType() : this(ObjectiveC.AllocInit(MTLStructTypeBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLStructMember[] Members
    {
        get => GetArrayProperty<MTLStructMember>(MTLStructTypeBindings.Members);
    }

    public MTLStructMember MemberByName(NSString name)
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTLStructTypeBindings.MemberByName, name.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLStructTypeBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLStructType");

    public static readonly Selector MemberByName = "memberByName:";

    public static readonly Selector Members = "members";
}
