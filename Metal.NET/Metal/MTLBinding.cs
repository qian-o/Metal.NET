namespace Metal.NET;

public class MTLBinding(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLBinding>
{
    #region INativeObject
    public static new MTLBinding Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLBinding New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLBindingBindings.Access);
    }

    public nuint Index
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBindingBindings.Index);
    }

    public Bool8 IsArgument
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLBindingBindings.IsArgument);
    }

    public Bool8 IsUsed
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLBindingBindings.IsUsed);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLBindingBindings.Name);
    }

    public MTLBindingType Type
    {
        get => (MTLBindingType)ObjectiveC.MsgSendLong(NativePtr, MTLBindingBindings.Type);
    }
    #endregion

    /// <summary>
    /// Deprecated: please use isArgument instead
    /// </summary>
    [Obsolete("please use isArgument instead")]
    public Bool8 Argument
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLBindingBindings.Argument);
    }

    /// <summary>
    /// Deprecated: please use isUsed instead
    /// </summary>
    [Obsolete("please use isUsed instead")]
    public Bool8 Used
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLBindingBindings.Used);
    }
}

file static class MTLBindingBindings
{
    public static readonly Selector Access = "access";

    public static readonly Selector Argument = "isArgument";

    public static readonly Selector Index = "index";

    public static readonly Selector IsArgument = "isArgument";

    public static readonly Selector IsUsed = "isUsed";

    public static readonly Selector Name = "name";

    public static readonly Selector Type = "type";

    public static readonly Selector Used = "isUsed";
}
