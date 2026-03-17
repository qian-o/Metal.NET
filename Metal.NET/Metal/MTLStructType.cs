namespace Metal.NET;

/// <summary>
/// A description of a structure.
/// </summary>
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

    #region Obtaining information about struct members - Properties

    /// <summary>
    /// An array of instances that describe the fields in the struct.
    /// </summary>
    public MTLStructMember[] Members
    {
        get => GetArrayProperty<MTLStructMember>(MTLStructTypeBindings.Members);
    }
    #endregion

    #region Obtaining information about struct members - Methods

    /// <summary>
    /// Provides a representation of a struct member.
    /// </summary>
    public MTLStructMember MemberByName(NSString name)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLStructTypeBindings.MemberByName, name.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion
}

file static class MTLStructTypeBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLStructType");

    public static readonly Selector MemberByName = "memberByName:";

    public static readonly Selector Members = "members";
}
