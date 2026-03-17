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

    public MTLStructMember MemberByName(NSString name)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLStructTypeBindings.MemberByName, name.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLStructTypeBindings
{
    public static readonly Selector MemberByName = "memberByName:";
}
