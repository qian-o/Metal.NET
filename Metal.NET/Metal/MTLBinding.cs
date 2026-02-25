namespace Metal.NET;

public class MTLBinding(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLBinding>
{
    public static MTLBinding Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBindingBindings.Access);
    }

    public Bool8 Argument
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBindingBindings.Argument);
    }

    public nuint Index
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBindingBindings.Index);
    }

    public Bool8 IsArgument
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBindingBindings.IsArgument);
    }

    public Bool8 IsUsed
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBindingBindings.IsUsed);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLBindingBindings.Name);
    }

    public MTLBindingType Type
    {
        get => (MTLBindingType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBindingBindings.Type);
    }

    public Bool8 Used
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBindingBindings.Used);
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
