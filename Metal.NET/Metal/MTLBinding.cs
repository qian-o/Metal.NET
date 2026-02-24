namespace Metal.NET;

public class MTLBinding(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLBinding>
{
    public static MTLBinding Create(nint nativePtr) => new(nativePtr);

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBindingBindings.Access);
    }

    public bool Argument
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBindingBindings.Argument);
    }

    public nuint Index
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBindingBindings.Index);
    }

    public bool IsArgument
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBindingBindings.IsArgument);
    }

    public bool IsUsed
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

    public bool Used
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
