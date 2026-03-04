namespace Metal.NET;

public class MTLBinding(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLBinding>
{
    public static MTLBinding Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLBinding Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLBindingBindings.Access);
    }

    public Bool8 Argument
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLBindingBindings.Argument);
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
