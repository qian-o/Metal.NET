namespace Metal.NET;

public readonly struct MTLBinding(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

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

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBindingBindings.Name);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
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
    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector Argument = Selector.Register("isArgument");

    public static readonly Selector Index = Selector.Register("index");

    public static readonly Selector IsArgument = Selector.Register("isArgument");

    public static readonly Selector IsUsed = Selector.Register("isUsed");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector Type = Selector.Register("type");

    public static readonly Selector Used = Selector.Register("isUsed");
}
