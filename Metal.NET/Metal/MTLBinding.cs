namespace Metal.NET;

public readonly struct MTLBinding(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLBinding value) => new(value.NativePtr);

    public MTLBinding Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLBindingBindings.Name));
    }

    public MTLBindingType Type
    {
        get => (MTLBindingType)ObjectiveC.MsgSendLong(NativePtr, MTLBindingBindings.Type);
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLBindingBindings.Access);
    }

    public nuint Index
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBindingBindings.Index);
    }

    public Bool8 IsUsed
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLBindingBindings.IsUsed);
    }

    public Bool8 IsArgument
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLBindingBindings.IsArgument);
    }
}

file static class MTLBindingBindings
{
    public static readonly Selector Access = "access";

    public static readonly Selector Index = "index";

    public static readonly Selector IsArgument = "isArgument";

    public static readonly Selector IsUsed = "isUsed";

    public static readonly Selector Name = "name";

    public static readonly Selector Type = "type";
}
