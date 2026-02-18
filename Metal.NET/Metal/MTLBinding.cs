namespace Metal.NET;

public class MTLBinding(nint nativePtr) : NativeObject(nativePtr)
{

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBindingSelector.Access);
    }

    public bool Argument
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBindingSelector.Argument);
    }

    public nuint Index
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLBindingSelector.Index);
    }

    public bool IsArgument
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBindingSelector.IsArgument);
    }

    public bool IsUsed
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBindingSelector.IsUsed);
    }

    public NSString? Name
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBindingSelector.Name));
    }

    public MTLBindingType Type
    {
        get => (MTLBindingType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBindingSelector.Type);
    }

    public bool Used
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLBindingSelector.Used);
    }
}

file static class MTLBindingSelector
{
    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector Argument = Selector.Register("isArgument");

    public static readonly Selector Index = Selector.Register("index");

    public static readonly Selector IsArgument = Selector.Register("isArgument");

    public static readonly Selector IsUsed = Selector.Register("isUsed");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector Type = Selector.Register("type");

    public static readonly Selector Used = Selector.Register("isUsed");
}
